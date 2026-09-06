import os
import signal
import socket
import subprocess
import sys
import threading
import time
from typing import Optional


def stream_reader(pipe, prefix: str) -> None:
    try:
        for line in iter(pipe.readline, ""):
            if not line:
                break
            print(f"[{prefix}] {line.rstrip()}")
    except Exception:
        pass


class ManagedProcess:
    def __init__(self, cmd, cwd: Optional[str] = None, env: Optional[dict] = None, name: Optional[str] = None):
        self.cmd = cmd
        self.cwd = cwd
        self.env = env
        self.name = name or (cmd[0] if isinstance(cmd, (list, tuple)) else cmd)
        self.proc: Optional[subprocess.Popen] = None
        self._stdout_thread: Optional[threading.Thread] = None
        self._stderr_thread: Optional[threading.Thread] = None

    def start(self):
        creationflags = 0
        preexec_fn = None
        # Create new process group so we can kill whole group
        if os.name == "nt":
            creationflags = subprocess.CREATE_NEW_PROCESS_GROUP
        else:
            preexec_fn = os.setsid

        print(f"Starting {self.name}: {' '.join(self.cmd) if isinstance(self.cmd, (list,tuple)) else self.cmd}")
        self.proc = subprocess.Popen(
            self.cmd,
            cwd=self.cwd,
            env=self.env,
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE,
            text=True,
            bufsize=1,
            creationflags=creationflags,
            preexec_fn=preexec_fn,
        )

        if self.proc.stdout:
            self._stdout_thread = threading.Thread(target=stream_reader, args=(self.proc.stdout, self.name), daemon=True)
            self._stdout_thread.start()
        if self.proc.stderr:
            self._stderr_thread = threading.Thread(target=stream_reader, args=(self.proc.stderr, self.name + "-ERR"), daemon=True)
            self._stderr_thread.start()

    def terminate(self, timeout: float = 5.0):
        if not self.proc:
            return
        try:
            print(f"Terminating {self.name} (pid={self.proc.pid})")
            if os.name == "nt":
                # Send CTRL_BREAK_EVENT to the process group
                try:
                    self.proc.send_signal(signal.CTRL_BREAK_EVENT)
                except Exception:
                    self.proc.terminate()
            else:
                # send SIGTERM to the process group
                try:
                    os.killpg(os.getpgid(self.proc.pid), signal.SIGTERM)
                except Exception:
                    self.proc.terminate()

            try:
                self.proc.wait(timeout=timeout)
            except subprocess.TimeoutExpired:
                print(f"{self.name} did not exit, killing...")
                try:
                    if os.name == "nt":
                        self.proc.kill()
                    else:
                        os.killpg(os.getpgid(self.proc.pid), signal.SIGKILL)
                except Exception:
                    self.proc.kill()
        except Exception as e:
            print(f"Error terminating {self.name}: {e}")

    def poll(self) -> Optional[int]:
        return self.proc.poll() if self.proc else None


def get_available_port(start_port: int = 8000) -> int:
    port = start_port
    while True:
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sock:
            sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
            try:
                sock.bind(("127.0.0.1", port))
                return port
            except OSError:
                port += 1


def main():
    backend_port = get_available_port(8000)
    uvicorn_cmd = [
        sys.executable,
        "-m",
        "uvicorn",
        "main:app",
        "--reload",
        "--host",
        "127.0.0.1",
        "--port",
        str(backend_port),
    ]
    npm_cmd = ["npm.cmd", "run", "dev", "--", "--host", "127.0.0.1"] if os.name == "nt" else ["npm", "run", "dev", "--", "--host", "127.0.0.1"]

    # Environment for frontend: ensure npm in PATH
    env = os.environ.copy()

    backend = ManagedProcess(uvicorn_cmd, cwd=os.path.join(os.getcwd(), "backend"), env=env, name="backend")
    frontend = ManagedProcess(npm_cmd, cwd=os.getcwd(), env=env, name="frontend")

    # Start both
    backend.start()
    frontend.start()

    shutting_down = threading.Event()

    def handle_exit(signum, frame):
        print(f"Received signal {signum}, shutting down")
        shutting_down.set()

    signal.signal(signal.SIGINT, handle_exit)
    try:
        signal.signal(signal.SIGTERM, handle_exit)
    except Exception:
        pass

    try:
        while not shutting_down.is_set():
            # If any process exits unexpectedly, shutdown the other
            b_status = backend.poll()
            f_status = frontend.poll()
            if b_status is not None:
                print(f"Backend exited with {b_status}, shutting down frontend...")
                shutting_down.set()
                break
            if f_status is not None:
                print(f"Frontend exited with {f_status}, shutting down backend...")
                shutting_down.set()
                break
            time.sleep(0.5)
    except KeyboardInterrupt:
        shutting_down.set()

    # Terminate both
    frontend.terminate()
    backend.terminate()

    print("All processes terminated. Exiting.")


if __name__ == "__main__":
    main()
