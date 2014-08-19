using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace MovieInfoApplication.requests
{
    public class WebRequester
    {
        private static WebRequester instance;

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
            try
            {
                WebRequest request = WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string json = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();

                return json;
            }
            catch (Exception e)
            {
                //throw new ApplicationException("Could not connect to Rotten Tomatoes.\n\n", e);
                //print out more appropriate message
                Console.WriteLine("Could not connect to url.\n\n");
                //Environment.Exit(1);
                return "{}";
            }
        }
    }
}
