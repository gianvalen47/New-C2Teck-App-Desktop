using System.Data;
using System.Net;
using System.Security.Principal;
using System.ServiceModel;

[ServiceContract(Name = "ISeguridad", Namespace = "http://tempuri.org/")]
public interface ISeguridadService
{
    [OperationContract(Action = "http://tempuri.org/ISeguridad/ValidarAccesoUsuario", ReplyAction = "http://tempuri.org/ISeguridad/ValidarAccesoUsuarioResponse")]
    int ValidarAccesoUsuario(string pCodUsu, string pClave, int pIdSistema);

    [OperationContract(Action = "http://tempuri.org/ISeguridad/MostrarMultiEmpresa", ReplyAction = "http://tempuri.org/ISeguridad/MostrarMultiEmpresaResponse")]
    DataSet MostrarMultiEmpresa(string pCodUsu);

    [OperationContract(Action = "http://tempuri.org/ISeguridad/AccesoMultiEmpresa", ReplyAction = "http://tempuri.org/ISeguridad/AccesoMultiEmpresaResponse")]
    bool AccesoMultiEmpresa(string pCodUsu);
}

class Program
{
    static int Main(string[] args)
    {
        var serviceUrl = args.FirstOrDefault()
            ?? Environment.GetEnvironmentVariable("SIGECOM_SEGURIDAD_SERVICE_URL")
            ?? "net.tcp://192.168.10.252/ServicioBLL/SeguridadService/";

        var company = Environment.GetEnvironmentVariable("SIGECOM_COD_EMP") ?? "08";
        var username = Environment.GetEnvironmentVariable("SIGECOM_USERNAME") ?? "grios";
        var password = Environment.GetEnvironmentVariable("SIGECOM_PASSWORD") ?? "123";
        var domain = Environment.GetEnvironmentVariable("SIGECOM_DOMAIN");

        Console.WriteLine($"Security probe: calling {serviceUrl} with company={company}, user={username}");

        var binding = new NetTcpBinding(SecurityMode.Transport)
        {
            CloseTimeout = TimeSpan.FromMinutes(1),
            OpenTimeout = TimeSpan.FromMinutes(1),
            ReceiveTimeout = TimeSpan.FromMinutes(2),
            SendTimeout = TimeSpan.FromMinutes(1),
            MaxBufferPoolSize = 2147483647,
            MaxBufferSize = 2147483647,
            MaxReceivedMessageSize = 2147483647,
            Security = new NetTcpSecurity
            {
                Mode = SecurityMode.Transport,
                Transport = new TcpTransportSecurity
                {
                    ClientCredentialType = TcpClientCredentialType.Windows,
                    ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign,
                }
            }
        };

        try
        {
            var factory = new ChannelFactory<ISeguridadService>(binding, new EndpointAddress(serviceUrl));

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                factory.Credentials.Windows.ClientCredential = new NetworkCredential(username, password, domain ?? string.Empty);
                factory.Credentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
                Console.WriteLine("Using provided credentials.");
            }
            else
            {
                factory.Credentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
                factory.Credentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
                Console.WriteLine("Using default network credentials.");
            }

            var channel = factory.CreateChannel();

            Console.WriteLine("Calling ValidarAccesoUsuario(...)");
            var result = channel.ValidarAccesoUsuario(username, password, 1);
            Console.WriteLine($"ValidarAccesoUsuario result = {result}");

            if (result <= 0)
            {
                Console.WriteLine("Authentication failed at SIGECOM WCF level.");
                ((ICommunicationObject)channel).Close();
                factory.Close();
                return 1;
            }

            Console.WriteLine("Calling MostrarMultiEmpresa(...)");
            var ds = channel.MostrarMultiEmpresa(username);
            if (ds == null || ds.Tables.Count == 0)
            {
                Console.WriteLine("No company data returned.");
                ((ICommunicationObject)channel).Close();
                factory.Close();
                return 0;
            }

            var table = ds.Tables[0];
            Console.WriteLine($"Empresas returned: {table.Rows.Count}");

            for (int i = 0; i < Math.Min(10, table.Rows.Count); i++)
            {
                var row = table.Rows[i];
                Console.WriteLine(string.Join(" | ", table.Columns.Cast<DataColumn>().Select(c =>
                {
                    var cell = row.IsNull(c) ? "<null>" : row[c]?.ToString() ?? "";
                    return $"{c.ColumnName}: {cell}";
                })));
            }

            ((ICommunicationObject)channel).Close();
            factory.Close();
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Probe error: {ex.GetType().FullName} - {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner: {ex.InnerException.GetType().FullName} - {ex.InnerException.Message}");
            }
            return 2;
        }
    }
}
