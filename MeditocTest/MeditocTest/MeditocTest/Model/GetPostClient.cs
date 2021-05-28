using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeditocTest.Model
{
    static public class GetPostClient
    {
        static private string GetURLGET(string ApiFunction)
        {
            return $"{Settings.Instance.URLPATH}{ApiFunction}?api_key={Settings.APIKEY}&language={Settings.Instance.Language}";
        }
        static public async Task<RequesStatus> GET(string method)
        {
            try
            {
                string url = GetPostClient.GetURLGET(method);
                WebRequest wrqst = WebRequest.Create(url);
                WebResponse wrsp = wrqst.GetResponse();

                using (var oSR = new StreamReader(wrsp.GetResponseStream()))
                {
                    var task = oSR.ReadToEndAsync();
                    string response = await task;

                    dynamic objresponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                    oSR.Close();
                    return RequesStatus.OK(objresponse);
                }
            }
            catch(Exception ex)
            {
                return RequesStatus.Error(ex.Message);
            }
        }
        static public RequesStatus GETSync(string method)
        {
            try
            {
                string url = GetPostClient.GetURLGET(method);
                WebRequest wrqst = WebRequest.Create(url);
                WebResponse wrsp = wrqst.GetResponse();

                using (var oSR = new StreamReader(wrsp.GetResponseStream()))
                {
                    //var task = oSR.ReadToEndAsync();
                    string response = oSR.ReadToEnd();

                    dynamic objresponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                    oSR.Close();
                    return RequesStatus.OK(objresponse);
                }
            }
            catch (Exception ex)
            {
                return RequesStatus.Error(ex.Message);
            }
        }
    }
}
