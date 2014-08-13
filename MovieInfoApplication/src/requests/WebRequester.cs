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
        //could move to it's own class
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
                Console.WriteLine("Could not connect to Rotten Tomatoes.\n\n");
                //Environment.Exit(1);
                return "{}";
            }
        }
    }
}
