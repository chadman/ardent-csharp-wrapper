using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardent.Payments.Entity;
using System.Net;
using System.IO;

namespace Ardent.Payments {
    public class TransactionManager {
        public static string RequestPayment(Transaction transaction) {
            string url = @"https://secure.goemerchant.com/secure/gateway/xmlgateway.aspx";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";

            byte[] transactionBytes = System.Text.Encoding.GetEncoding(1252).GetBytes(transaction.ToXml());
            webRequest.ContentLength = transactionBytes.Length;

            using (Stream writer = webRequest.GetRequestStream())
                writer.Write(transactionBytes, 0, transactionBytes.Length);

            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse()) {
                //Only for debug
                using (var stream = new StreamReader(webResponse.GetResponseStream())) {
                    return stream.ReadToEnd();
                }
            }

            //Stream postData = webRequest.GetRequestStream();
            //postData.Write(transactionBytes, 0, transactionBytes.Length);
            //postData.Close();

            //HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            //StreamReader responseReader = new StreamReader(webRequest.GetRequestStream(), System.Text.Encoding.GetEncoding(1252));
            //string html = responseReader.ReadToEnd();

            //responseReader.Close();
            //webResponse.Close();

            //return html;
        }
    }
}
