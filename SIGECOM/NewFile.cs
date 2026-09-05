using System;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;

class Program
{
    // Uso: PruebaWcf "C:\ruta\al\ensamblado\SIGECOM.exe"
    static int Main(string[] args)
    {
        string assemblyPath = args.Length > 0 ? args[0] : @"C:\ruta\al\ensamblado\SIGECOM.exe";
        if (!System.IO.File.Exists(assemblyPath))
        {
            Console.Error.WriteLine("Assembly no encontrado: " + assemblyPath);
            return 1;
        }

        Assembly asm;
        try { asm = Assembly.LoadFrom(assemblyPath); }
        catch (Exception ex) { Console.Error.WriteLine("Error cargando assembly: " + ex); return 2; }

        var clientType = asm.GetTypes().FirstOrDefault(t => t.Name.EndsWith("GuiaRemisionServiceClient", StringComparison.Ordinal));
        if (clientType == null)
        {
            Console.Error.WriteLine("No se encontró ningún tipo cuyo nombre termine en 'GuiaRemisionServiceClient' en el ensamblado.");
            return 3;
        }

        // Binding y endpoint requeridos por la petición
        var binding = new NetTcpBinding(SecurityMode.Transport) { MaxReceivedMessageSize = 65536 };
        binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
        var endpoint = new EndpointAddress("net.tcp://192.168.10.252/ServicioBLL/GuiaRemisionService/");

        object client = null;
        object channelFactory = null;

        try
        {
            // Preferir ctor (Binding, EndpointAddress) del cliente generado
            var ctor = clientType.GetConstructor(new Type[] { typeof(Binding), typeof(EndpointAddress) });
            if (ctor != null)
            {
                client = ctor.Invoke(new object[] { binding, endpoint });
            }
            else
            {
                // Fallback: crear channel vía ChannelFactory<TInterface>
                // Determinar la interfaz T del ClientBase<T>
                Type serviceInterface = null;
                var baseType = clientType.BaseType;
                if (baseType != null && baseType.IsGenericType)
                    serviceInterface = baseType.GetGenericArguments().FirstOrDefault();

                if (serviceInterface == null)
                {
                    Console.Error.WriteLine("No se pudo determinar la interfaz de servicio desde el tipo cliente. Compruebe la generación del cliente.");
                    return 4;
                }

                var factoryType = typeof(ChannelFactory<>).MakeGenericType(serviceInterface);
                channelFactory = Activator.CreateInstance(factoryType, binding, endpoint);
                var createChannel = factoryType.GetMethod("CreateChannel", Type.EmptyTypes);
                client = createChannel.Invoke(channelFactory, null);
            }

            if (client == null) { Console.Error.WriteLine("No se pudo instanciar el cliente."); return 5; }

            // Buscar el método Filtrar y ejecutarlo
            var filtrar = client.GetType().GetMethod("Filtrar") ??
                          client.GetType().GetMethods().FirstOrDefault(m => m.Name == "Filtrar");

            if (filtrar == null)
            {
                Console.Error.WriteLine("No se encontró el método 'Filtrar' en el cliente.");
                return 6;
            }

            var resultado = filtrar.Invoke(client, new object[] { 0, 0, 0, 0, 0, "", 0 });
            Console.WriteLine(resultado?.ToString() ?? "<null>");

            // Cerrar correctamente
            if (client is IClientChannel ch) ch.Close();
            else
            {
                var closeMethod = client.GetType().GetMethod("Close", Type.EmptyTypes);
                closeMethod?.Invoke(client, null);
            }

            if (channelFactory is IClientChannel) { /* nothing */ }
            else
            {
                var closeFactory = channelFactory?.GetType().GetMethod("Close", Type.EmptyTypes);
                closeFactory?.Invoke(channelFactory, null);
            }
        }
        catch (TargetInvocationException tie)
        {
            Console.Error.WriteLine("Error en la invocación: " + (tie.InnerException ?? tie).ToString());
            try { if (client is IClientChannel c) c.Abort(); } catch { }
            try { channelFactory?.GetType().GetMethod("Abort")?.Invoke(channelFactory, null); } catch { }
            return 10;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex);
            try { if (client is IClientChannel c) c.Abort(); } catch { }
            try { channelFactory?.GetType().GetMethod("Abort")?.Invoke(channelFactory, null); } catch { }
            return 11;
        }

        return 0;
    }
}