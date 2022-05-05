using System;
using System.Net.Http;

namespace ZeusLibrary
{
    public class Infra
    {
        public static string GetResponse(string requestUri, out Exception exception)
        {
            string strValue = null;
            exception = null;
            try
            {
                HttpClient client = new();
                HttpRequestMessage request = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(requestUri)
                };

                using (var response = client.Send(request))
                {
                    response.EnsureSuccessStatusCode();
                    strValue = response.Content.ReadAsStringAsync().Result.ToString();
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return strValue;
        }
    }
}