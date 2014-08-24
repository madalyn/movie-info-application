using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

namespace MovieInfoApplication.requests
{
    public class WebRequester
    {
        private static WebRequester instance;
        private int failures = 0;

        private WebRequester()
        {
            //the singleton class constuctor
        }

        public static WebRequester getInstance()
        {
            if (instance == null)
            {
                instance = new WebRequester();
            }

            return instance;
        }

        public string doWebRequest(string url)
        {
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = null;
            HttpStatusCode status;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                status = response.StatusCode;
            }
            catch (Exception e)
            {
                status = HttpStatusCode.Forbidden;
            }

            if (status == HttpStatusCode.OK)
            {
                failures = 0;
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string json = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();

                return json;
            }
            else if (failures < 2)
            {
                failures++;
                Thread.Sleep(1000);
                return doWebRequest(url);
            }
            else
            {
                failures = 0;
                //print out more appropriate message
                Console.WriteLine("Could not connect to " + url + "\n\n");
                return "{}";
            }
        }
    }
}
