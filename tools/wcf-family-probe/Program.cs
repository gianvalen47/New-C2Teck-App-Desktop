using System.Data;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;

var serviceName = args.FirstOrDefault()
    ?? Environment.GetEnvironmentVariable("SIGECOM_TARGET_SERVICE")
    ?? "SeguridadService";

var serviceUrl = Environment.GetEnvironmentVariable($"SIGECOM_{serviceName.ToUpperInvariant().Replace('-', '_')}_URL")
    ?? BuildDefaultUrl(serviceName);

var company = Environment.GetEnvironmentVariable("SIGECOM_COD_EMP") ?? "08";
var username = Environment.GetEnvironmentVariable("SIGECOM_USERNAME") ?? "grios";
var password = Environment.GetEnvironmentVariable("SIGECOM_PASSWORD") ?? "123";
var domain = Environment.GetEnvironmentVariable("SIGECOM_DOMAIN");

Console.WriteLine($"Family probe: service={serviceName}, url={serviceUrl}, company={company}, user={username}");

try
{
    switch (serviceName)
    {
        case "SeguridadService":
            ProbeSeguridad(serviceUrl, company, username, password, domain);
            return;
        case "ClienteService":
            ProbeCliente(serviceUrl, company, username, password, domain);
            return;
        case "GuiaRemisionService":
            ProbeGuia(serviceUrl, company, username, password, domain);
            return;
        case "FacturaService":
            ProbeFactura(serviceUrl, company, username, password, domain);
            return;
        case "BoletaService":
            ProbeBoleta(serviceUrl, company, username, password, domain);
            return;
        case "SunatService":
            ProbeSunat(serviceUrl, company, username, password, domain);
            return;
        default:
            Console.WriteLine($"Unsupported target: {serviceName}");
            Console.WriteLine("Accepted values: SeguridadService, ClienteService, GuiaRemisionService, FacturaService, BoletaService, SunatService");
            Environment.Exit(2);
            return;
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Probe error: {ex.GetType().FullName} - {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner: {ex.InnerException.GetType().FullName} - {ex.InnerException.Message}");
    }
    Environment.Exit(1);
}

static string BuildDefaultUrl(string serviceName) => serviceName switch
{
    "SeguridadService" => "net.tcp://192.168.10.252/ServicioBLL/SeguridadService/",
    "ClienteService" => "net.tcp://192.168.10.252/ServicioBLL/ClienteService/",
    "GuiaRemisionService" => "net.tcp://192.168.10.252/ServicioBLL/GuiaRemisionService/",
    "FacturaService" => "net.tcp://192.168.10.252/ServicioBLL/FacturaService/",
    "BoletaService" => "net.tcp://192.168.10.252/ServicioBLL/BoletaService/",
    "SunatService" => "net.tcp://192.168.10.252/ServicioBLL/SunatService/",
    _ => throw new ArgumentOutOfRangeException(nameof(serviceName), serviceName, "Unsupported service")
};

static NetTcpBinding CreateBinding() => new NetTcpBinding(SecurityMode.Transport)
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
            ProtectionLevel = ProtectionLevel.EncryptAndSign,
        }
    }
};

static void ApplyWindowsCredentials<T>(ChannelFactory<T> factory, string? username, string? password, string? domain) where T : class
{
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
}

static void ProbeSeguridad(string serviceUrl, string company, string username, string password, string? domain)
{
    var factory = new ChannelFactory<ISeguridadService>(CreateBinding(), new EndpointAddress(serviceUrl));
    ApplyWindowsCredentials(factory, username, password, domain);
    var channel = factory.CreateChannel();

    Console.WriteLine("Calling ValidarAccesoUsuario(...)");
    var result = channel.ValidarAccesoUsuario(username, password, 1);
    Console.WriteLine($"ValidarAccesoUsuario = {result}");

    Console.WriteLine("Calling MostrarMultiEmpresa(...)");
    var ds = channel.MostrarMultiEmpresa(username);
    DumpDataset(ds, "MostrarMultiEmpresa");

    ((ICommunicationObject)channel).Close();
    factory.Close();
}

static void ProbeCliente(string serviceUrl, string company, string username, string password, string? domain)
{
    var factory = new ChannelFactory<IClienteService>(CreateBinding(), new EndpointAddress(serviceUrl));
    ApplyWindowsCredentials(factory, username, password, domain);
    var channel = factory.CreateChannel();

    var filtro = new Cliente { IdCliente = 0, DesCli = string.Empty, RucCli = string.Empty, DniCli = string.Empty };
    Console.WriteLine("Calling ClienteService.Filtrar(...)");
    var ds = channel.Filtrar(company, filtro);
    DumpDataset(ds, "ClienteService.Filtrar");

    ((ICommunicationObject)channel).Close();
    factory.Close();
}

static void ProbeGuia(string serviceUrl, string company, string username, string password, string? domain)
{
    var factory = new ChannelFactory<IGuiaRemisionService>(CreateBinding(), new EndpointAddress(serviceUrl));
    ApplyWindowsCredentials(factory, username, password, domain);
    var channel = factory.CreateChannel();

    Console.WriteLine("Calling GuiaRemisionService.Filtrar(...)");
    var ds = channel.Filtrar(0, 0, 0, 0, 0, string.Empty, 0);
    DumpDataset(ds, "GuiaRemisionService.Filtrar");

    ((ICommunicationObject)channel).Close();
    factory.Close();
}

static void ProbeFactura(string serviceUrl, string company, string username, string password, string? domain)
{
    var factory = new ChannelFactory<IFacturaService>(CreateBinding(), new EndpointAddress(serviceUrl));
    ApplyWindowsCredentials(factory, username, password, domain);
    var channel = factory.CreateChannel();

    Console.WriteLine("Calling FacturaService.Filtrar(...)");
    var ds = channel.Filtrar(company, new Factura());
    DumpDataset(ds, "FacturaService.Filtrar");

    ((ICommunicationObject)channel).Close();
    factory.Close();
}

static void ProbeBoleta(string serviceUrl, string company, string username, string password, string? domain)
{
    var factory = new ChannelFactory<IBoletaService>(CreateBinding(), new EndpointAddress(serviceUrl));
    ApplyWindowsCredentials(factory, username, password, domain);
    var channel = factory.CreateChannel();

    Console.WriteLine("Calling BoletaService.Filtrar(...)");
    var ds = channel.Filtrar(company, new Boleta());
    DumpDataset(ds, "BoletaService.Filtrar");

    ((ICommunicationObject)channel).Close();
    factory.Close();
}

static void ProbeSunat(string serviceUrl, string company, string username, string password, string? domain)
{
    var factory = new ChannelFactory<ISunatService>(CreateBinding(), new EndpointAddress(serviceUrl));
    ApplyWindowsCredentials(factory, username, password, domain);
    var channel = factory.CreateChannel();

    Console.WriteLine("Calling SunatService.Consultar(...)");
    var ds = channel.Consultar(company, new SunatRequest());
    DumpDataset(ds, "SunatService.Consultar");

    ((ICommunicationObject)channel).Close();
    factory.Close();
}

static void DumpDataset(DataSet? ds, string label)
{
    if (ds == null)
    {
        Console.WriteLine($"{label}: null DataSet");
        return;
    }

    Console.WriteLine($"{label}: {ds.Tables.Count} tables");
    for (var i = 0; i < ds.Tables.Count; i++)
    {
        var table = ds.Tables[i];
        Console.WriteLine($"  Table[{i}] rows={table.Rows.Count}, columns={table.Columns.Count}");
        for (var rowIndex = 0; rowIndex < Math.Min(3, table.Rows.Count); rowIndex++)
        {
            var row = table.Rows[rowIndex];
            Console.WriteLine("   " + string.Join(" | ", table.Columns.Cast<DataColumn>().Select(c =>
            {
                var cell = row.IsNull(c) ? "<null>" : row[c];
                return $"{c.ColumnName}={cell}";
            })));
        }
    }
}

[ServiceContract(Name = "ISeguridad", Namespace = "http://tempuri.org/")]
public interface ISeguridadService
{
    [OperationContract(Action = "http://tempuri.org/ISeguridad/ValidarAccesoUsuario", ReplyAction = "http://tempuri.org/ISeguridad/ValidarAccesoUsuarioResponse")]
    int ValidarAccesoUsuario(string pCodUsu, string pClave, int pIdSistema);

    [OperationContract(Action = "http://tempuri.org/ISeguridad/MostrarMultiEmpresa", ReplyAction = "http://tempuri.org/ISeguridad/MostrarMultiEmpresaResponse")]
    DataSet MostrarMultiEmpresa(string pCodUsu);
}

[DataContract(Name = "Cliente", Namespace = "http://schemas.datacontract.org/2004/07/Models")]
public class Cliente
{
    [DataMember] public int IdCliente { get; set; }
    [DataMember] public string? DesCli { get; set; }
    [DataMember] public string? RucCli { get; set; }
    [DataMember] public string? DniCli { get; set; }
}

[ServiceContract(Name = "IClienteService", Namespace = "http://tempuri.org/")]
public interface IClienteService
{
    [OperationContract(Action = "http://tempuri.org/IClienteService/Filtrar", ReplyAction = "http://tempuri.org/IClienteService/FiltrarResponse")]
    DataSet Filtrar(string pCodEmp, Cliente Clase);
}

[ServiceContract(Name = "IGuiaRemisionService", Namespace = "http://tempuri.org/")]
public interface IGuiaRemisionService
{
    [OperationContract(Action = "http://tempuri.org/IGuiaRemisionService/Filtrar", ReplyAction = "http://tempuri.org/IGuiaRemisionService/FiltrarResponse")]
    DataSet Filtrar(int anio, int mes, int id_locacion, int id_serie_doc, int id_cliente, string estado, int num_doc);
}

[DataContract(Name = "Factura", Namespace = "http://schemas.datacontract.org/2004/07/Models")]
public class Factura
{
    [DataMember] public int IdFactura { get; set; }
    [DataMember] public string? NumDoc { get; set; }
    [DataMember] public string? DesCli { get; set; }
}

[ServiceContract(Name = "IFacturaService", Namespace = "http://tempuri.org/")]
public interface IFacturaService
{
    [OperationContract(Action = "http://tempuri.org/IFacturaService/Filtrar", ReplyAction = "http://tempuri.org/IFacturaService/FiltrarResponse")]
    DataSet Filtrar(string pCodEmp, Factura Clase);
}

[DataContract(Name = "Boleta", Namespace = "http://schemas.datacontract.org/2004/07/Models")]
public class Boleta
{
    [DataMember] public int IdBoleta { get; set; }
    [DataMember] public string? NumDoc { get; set; }
    [DataMember] public string? DesCli { get; set; }
}

[ServiceContract(Name = "IBoletaService", Namespace = "http://tempuri.org/")]
public interface IBoletaService
{
    [OperationContract(Action = "http://tempuri.org/IBoletaService/Filtrar", ReplyAction = "http://tempuri.org/IBoletaService/FiltrarResponse")]
    DataSet Filtrar(string pCodEmp, Boleta Clase);
}

[DataContract(Name = "SunatRequest", Namespace = "http://schemas.datacontract.org/2004/07/Models")]
public class SunatRequest
{
    [DataMember] public string? Fecha { get; set; }
    [DataMember] public string? TipoDoc { get; set; }
    [DataMember] public string? Numero { get; set; }
}

[ServiceContract(Name = "ISunatService", Namespace = "http://tempuri.org/")]
public interface ISunatService
{
    [OperationContract(Action = "http://tempuri.org/ISunatService/Consultar", ReplyAction = "http://tempuri.org/ISunatService/ConsultarResponse")]
    DataSet Consultar(string pCodEmp, SunatRequest Clase);
}
