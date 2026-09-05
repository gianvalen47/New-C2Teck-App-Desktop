using System.Data;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.Json;

namespace SigecoomWcfClient;

[ServiceContract(Name = "IGuiaRemisionService", Namespace = "http://tempuri.org/")]
public interface IGuiaRemisionService
{
    [OperationContract]
    DataSet Filtrar(int Anio, int Mes, int pIdLocacion, int pIdSerieDoc, int pIdCliente, string? pEstado, int pNumDoc);
}

public class GuiaRemisionServiceClient : ClientBase<IGuiaRemisionService>, IGuiaRemisionService
{
    public GuiaRemisionServiceClient(Binding binding, EndpointAddress endpoint)
        : base(binding, endpoint)
    {
    }

    public DataSet Filtrar(int Anio, int Mes, int pIdLocacion, int pIdSerieDoc, int pIdCliente, string? pEstado, int pNumDoc)
    {
        return Channel.Filtrar(Anio, Mes, pIdLocacion, pIdSerieDoc, pIdCliente, pEstado, pNumDoc);
    }
}

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("SIGECOM WCF probe");
        Console.WriteLine("Endpoint: net.tcp://192.168.10.252/ServicioBLL/GuiaRemisionService/");

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

        var endpoint = new EndpointAddress("net.tcp://192.168.10.252/ServicioBLL/GuiaRemisionService/");

        using var client = new GuiaRemisionServiceClient(binding, endpoint);

        try
        {
            // Windows auth uses the current session identity. The VPN must be active and the network path must be reachable.
            var ds = client.Filtrar(0, 0, 0, 0, 0, null, 0);
            Console.WriteLine($"Tables: {ds.Tables.Count}");

            var payload = DataSetToJson(ds);
            Console.WriteLine(payload);
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
