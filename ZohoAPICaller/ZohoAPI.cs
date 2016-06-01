using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Net.Security;
using System.Xml;

//Add a comment to check TFS source control


namespace ZohoAPICaller
{


    public class ZohoAPI
    {
        public static string zohocrmurl = "https://crm.zoho.com/crm/private/xml/";

        //testaaaa
        private static String GetUnassingedLead(String xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            string xpath = "response/result/Leads/row";
            var nodes = xmlDoc.SelectNodes(xpath);
        
            foreach (XmlNode childrenNode in nodes)
            {

                if (GetCreateDate(childrenNode) > DateTime.UtcNow.AddHours(-9))
                {
                    if (childrenNode.ChildNodes[0].OuterXml.Contains("LEADID") == true)
                        return childrenNode.ChildNodes[0].InnerXml;
                }
            }
            return "";
        }
        private static DateTime GetCreateDate(XmlNode node)
        {
            foreach(XmlNode childrenNode in node)
            {
                if(childrenNode.Attributes[0].Value == "Created Time")
                {
                    return Convert.ToDateTime(childrenNode.InnerText);
                }
            }
            return new DateTime(0);
        }

        public static void SetNewLeadOwner(String leadId, String ownerId)
        {
            String updateXML = String.Format("<row no=\"1\"><FL val=\"SMOWNERID\">{0}</FL></row></Leads>", ownerId);
            APIMethod("Leads", "updateRecord", leadId,updateXML);
        }

        public static String GetAndAssignNewLead(String userId)
        {
            
            String authToken ="7d4ef89c0b1bf4f38e12d378d229d50d";//authToken for Admin/safeinhome
            String result = ZohoAPI.APIMethod("Leads", "getMyRecords",authToken ,"");
            String unassignedLeadId = GetUnassingedLead(result);
            String updateXMLData = String.Format("<Leads><row no=\"1\"><FL val=\"SMOWNERID\">{0}</FL></row></Leads>",userId);
            ZohoAPI.APIMethod("Leads", "updateRecords", authToken, unassignedLeadId,updateXMLData);
            return unassignedLeadId;
        }

        public static String APIMethod(string modulename, string methodname, string authToken, string recordId, string updateXMLData = "")
        {
            string uri = zohocrmurl + modulename + "/" + methodname + "?";
            /* Append your parameters here */


            string postContent = "scope=crmapi";
            postContent = postContent + String.Format("&authtoken={0}", authToken);
            if (methodname.Equals("insertRecords") || methodname.Equals("updateRecords"))
            {
                postContent = postContent + "&xmlData=" + System.Net.WebUtility.UrlEncode(updateXMLData);
            }
            if (methodname.Equals("updateRecords") || methodname.Equals("deleteRecords") || methodname.Equals("getRecordById"))
            {
                postContent = postContent + "&id=" + recordId;
            }
            string result = AccessCRM(uri + postContent,"" );

            return result;
        }

        public static string AccessCRM(string url, string postcontent)
        {

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(postcontent);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

    }
}
    




//public class ZohoCRMAPI
//{

//public static void Main (string[] args)
//{
//string result = APIMethod("Leads","getRecords","508020000000332001");//Change the id,method name, and module name here
//Console.Write(result);
//}


//}