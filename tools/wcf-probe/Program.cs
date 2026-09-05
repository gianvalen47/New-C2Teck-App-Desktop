using System;
using System.Data;
using System.Net;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Security.Principal;

[DataContract(Name = "Cliente", Namespace = "http://schemas.datacontract.org/2004/07/Models")]
public class Cliente
{
    [DataMember] public int IdCliente { get; set; }
    [DataMember] public string? DesCli { get; set; }
    [DataMember] public string? RucCli { get; set; }
    [DataMember] public string? DniCli { get; set; }
    [DataMember] public SectorCliente? SectorCliente { get; set; }
    [DataMember] public TipoCliente? TipoCliente { get; set; }
}

[DataContract(Name = "SectorCliente", Namespace = "http://schemas.datacontract.org/2004/07/Models")]
public class SectorCliente
{
    [DataMember] public string? CodSec { get; set; }
}

[DataContract(Name = "TipoCliente", Namespace = "http://schemas.datacontract.org/2004/07/Models")]
public class TipoCliente
{
    [DataMember] public int IdTipoCliente { get; set; }
}

[ServiceContract(Name = "IClienteService", Namespace = "http://tempuri.org/")]
public interface IClienteService
{
    [OperationContract(Action = "http://tempuri.org/IClienteService/Filtrar", ReplyAction = "http://tempuri.org/IClienteService/FiltrarResponse")]
    DataSet Filtrar(string pCodEmp, Cliente Clase);
}

class Program
{
    static int Main(string[] args)
    {
        var serviceUrl = Environment.GetEnvironmentVariable("SIGECOM_CLIENTE_SERVICE_URL") ?? "net.tcp://192.168.10.252/ServicioBLL/ClienteService/";
        var company = Environment.GetEnvironmentVariable("SIGECOM_COD_EMP") ?? "01";
        var username = Environment.GetEnvironmentVariable("SIGECOM_USERNAME");
        var password = Environment.GetEnvironmentVariable("SIGECOM_PASSWORD");
        var domain = Environment.GetEnvironmentVariable("SIGECOM_DOMAIN");

        Console.WriteLine($"Probe: calling {serviceUrl} with company={company}");

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
                }
            }
        };

        var endpointIdentity = new System.ServiceModel.DnsEndpointIdentity("192.168.10.252");
        var endpoint = new EndpointAddress(new Uri(serviceUrl), endpointIdentity);

        try
        {
            var factory = new ChannelFactory<IClienteService>(binding, endpoint);

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                factory.Credentials.Windows.ClientCredential = new NetworkCredential(username, password, domain ?? string.Empty);
                factory.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                Console.WriteLine("Using provided credentials.");
            }
            else
            {
                factory.Credentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
                factory.Credentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Delegation;
                Console.WriteLine("Using default network credentials.");
            }

            var channel = factory.CreateChannel();
            Console.WriteLine("Channel created, invoking Filtrar(...)");

            // Allow overriding filters via environment variables for debugging
            var envDes = Environment.GetEnvironmentVariable("SIGECOM_FILTER_DESCLI");
            var envRuc = Environment.GetEnvironmentVariable("SIGECOM_FILTER_RUC");
            var envDni = Environment.GetEnvironmentVariable("SIGECOM_FILTER_DNI");

            var filtro = new Cliente
            {
                IdCliente = 0,
                DesCli = envDes ?? string.Empty,
                RucCli = envRuc ?? string.Empty,
                DniCli = envDni ?? string.Empty,
                SectorCliente = new SectorCliente { CodSec = string.Empty },
                TipoCliente = new TipoCliente { IdTipoCliente = 0 }
            };
            var ds = channel.Filtrar(company, filtro);

            if (ds == null || ds.Tables.Count == 0)
            {
                Console.WriteLine("Result: no tables returned or empty dataset.");
            }
            else
            {
                var t = ds.Tables[0];
                Console.WriteLine($"Tables[0] rows = {t.Rows.Count}");
                var max = Math.Min(5, t.Rows.Count);
                for (int i = 0; i < max; i++)
                {
                    var row = t.Rows[i];
                    Console.WriteLine(string.Join(" | ", t.Columns.Cast<System.Data.DataColumn>().Select(c => c.ColumnName + ":" + (row.IsNull(c) ? "<null>" : row[c].ToString()))));
                }
            }

            ((ICommunicationObject)channel).Close();
            factory.Close();

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Probe error: " + ex.GetType().FullName + " - " + ex.Message);
            if (ex.InnerException != null) Console.WriteLine("Inner: " + ex.InnerException.GetType().FullName + " - " + ex.InnerException.Message);
            return 2;
        }
    }
}
