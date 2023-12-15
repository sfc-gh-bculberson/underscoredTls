using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

string underscoreUri = "https://sfsenorthamerica_demo226.snowflakecomputing.com/";
string dashUri = "https://sfsenorthamerica-demo226.snowflakecomputing.com/";

async Task CheckHostCertificate(string uri)
{
    var handler = new HttpClientHandler();
    var client = new HttpClient(handler);
    try
    {
        using (var msg = new HttpRequestMessage(HttpMethod.Get, uri))
        {
            using (var response = await client.SendAsync(msg))
            {
                Console.WriteLine($"Hostname {uri} is ok");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Hostname {uri} is NOT ok {ex}");
    }
}

await CheckHostCertificate(underscoreUri);
await CheckHostCertificate(dashUri);
