using System.Data;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.Json;

namespace SigecoomWcfClient;

[ServiceContract(Name = "ISeguridad", Namespace = "http://tempuri.org/")]
public interface ISeguridadService
{
    [OperationContract(Action = "http://tempuri.org/ISeguridad/ValidarAccesoUsuario", ReplyAction = "http://tempuri.org/ISeguridad/ValidarAccesoUsuarioResponse")]
    int ValidarAccesoUsuario(string pCodUsu, string pClave, int pIdSistema);

    [OperationContract(Action = "http://tempuri.org/ISeguridad/MostrarMultiEmpresa", ReplyAction = "http://tempuri.org/ISeguridad/MostrarMultiEmpresaResponse")]
    DataSet MostrarMultiEmpresa(string pCodUsu);
}

public class SeguridadServiceClient : ClientBase<ISeguridadService>, ISeguridadService
{
    public SeguridadServiceClient(Binding binding, EndpointAddress endpoint)
        : base(binding, endpoint)
    {
    }

    public int ValidarAccesoUsuario(string pCodUsu, string pClave, int pIdSistema)
    {
        return Channel.ValidarAccesoUsuario(pCodUsu, pClave, pIdSistema);
    }

    public DataSet MostrarMultiEmpresa(string pCodUsu)
    {
        return Channel.MostrarMultiEmpresa(pCodUsu);
    }
}

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("SIGECOM WCF SECURITY probe");
        Console.WriteLine("Endpoint: net.tcp://192.168.10.252/ServicioBLL/SeguridadService/");

        var binding = new NetTcpBinding(SecurityMode.Transport)
        {
            SendTimeout = TimeSpan.FromMinutes(1),
            ReceiveTimeout = TimeSpan.FromMinutes(5),
            OpenTimeout = TimeSpan.FromMinutes(1),
            CloseTimeout = TimeSpan.FromMinutes(1),
            MaxReceivedMessageSize = 65_536_066,
            MaxBufferSize = 65_536_066,
            TransferMode = TransferMode.Buffered,
            Security =
            {
                Transport = { ClientCredentialType = TcpClientCredentialType.Windows }
            }
        };

        var endpoint = new EndpointAddress("net.tcp://192.168.10.252/ServicioBLL/SeguridadService/");

        using var client = new SeguridadServiceClient(binding, endpoint);

        try
        {
            Console.WriteLine("Validating user ...");
            var code = client.ValidarAccesoUsuario("crios", "Master$5050", 1);
            Console.WriteLine($"ValidarAccesoUsuario returned: {code}");

            Console.WriteLine("Fetching assigned companies ...");
            var ds = client.MostrarMultiEmpresa("crios");
            Console.WriteLine($"Tables: {ds.Tables.Count}");
            Console.WriteLine(DataSetToJson(ds));
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine(ex);
            Environment.ExitCode = 1;
        }
    }

    private static string DataSetToJson(DataSet dataSet)
    {
        var result = new List<object>();

        foreach (DataTable table in dataSet.Tables)
        {
            var rows = new List<Dictionary<string, object?>>();

            foreach (DataRow row in table.Rows)
            {
                var record = new Dictionary<string, object?>();
                foreach (DataColumn column in table.Columns)
                {
                    var value = row[column];
                    record[column.ColumnName] = value is DBNull ? null : value;
                }
                rows.Add(record);
            }

            result.Add(new { table = table.TableName, rows });
        }

        return JsonSerializer.Serialize(result, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}
