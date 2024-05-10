using Domain;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DataAccess;

public class StoreRepository 
{
    
    private readonly string url =
        "https://eda.yandex.ru/api/v2/menu/retrieve/kfc_oxgae?longitude=37.738063&latitude=55.711726&autoTranslate=false";
    private readonly string json;

    public StoreRepository() => json = GetContent(url);

    public Store GetStore() => JsonConvert.DeserializeObject<Store>(json);
    
    private string GetContent(string url)
    {
        HttpWebRequest request =
            (HttpWebRequest)WebRequest.Create(url);

        request.Method = "GET";
        request.Accept = "application/json";
        request.UserAgent = "Mozilla/5.0 ....";

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        StringBuilder output = new StringBuilder();
        output.Append(reader.ReadToEnd());
        response.Close();
        return output.ToString();
    }
}