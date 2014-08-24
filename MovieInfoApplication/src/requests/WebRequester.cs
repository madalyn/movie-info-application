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
            // the singleton class constuctor
        }

        // return the WebRequester instance; making one if necessary
        public static WebRequester getInstance()
        {
            if (instance == null)
            {
                instance = new WebRequester();
            }

            return instance;
        }

        /// <summary>
        /// perform the web request for the desired url
        /// </summary>
        /// <param name="url">the url to make a request to</param>
        /// <returns>the contents of the response (JSON)</returns>
        public string doWebRequest(string url)
        {
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = null;
            HttpStatusCode status;

            // get the status, if there is an exception set status
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                status = response.StatusCode;
            }
            catch (Exception e)
            {
                status = HttpStatusCode.Forbidden;
            }

            // if the status is good then read it 
            // otherwise, try again up to 2 times before giving up
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
                // it may have failed because of a call limit
                // wait then try again
                Thread.Sleep(1000);
                return doWebRequest(url);
            }
            else
            {
                failures = 0;
                // print out appropriate message
                Console.WriteLine("Could not connect to " + url + "\n\n");
                return "{}";
            }
        }
    }
}
