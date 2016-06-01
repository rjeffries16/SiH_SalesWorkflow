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
using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Data;

namespace ZohoAPICaller
{
    public class ZohoReportsAPI
    {
        //https://reportsapi.zoho.com/api/info@safeinhome.com/Zoho%20CRM%20Reports/RAW%20CALLS?ZOHO_ACTION=EXPORT&ZOHO_OUTPUT_FORMAT=XML&ZOHO_ERROR_FORMAT=XML&authtoken=a263834c09c998df6e5499097990a71d&ZOHO_API_VERSION=1.0&ZOHO_CRITERIA=(%22Created%20Time%22%3E%272016-02-02%2014:17:48%27)
        //https://reportsapi.zoho.com/api/info@safeinhome.com/Zoho%20CRM%20Reports/RAW%20LEADS?ZOHO_ACTION=EXPORT&ZOHO_OUTPUT_FORMAT=XML&ZOHO_ERROR_FORMAT=XML&authtoken=a263834c09c998df6e5499097990a71d&ZOHO_API_VERSION=1.0
        private static string zohocrmurl = "https://reportsapi.zoho.com/api/";
        private static string accountEmail = "info@safeinhome.com";
        private static string leadsURL = "/Zoho%20CRM%20Reports/RAW%20LEADS?ZOHO_ACTION=EXPORT&ZOHO_OUTPUT_FORMAT=XML&ZOHO_ERROR_FORMAT=XML&authtoken=a263834c09c998df6e5499097990a71d&ZOHO_API_VERSION=1.0&ZOHO_CRITERIA=(%22Modified%20Time%22%3E%27{0}%27)";
        private static string callsURL = "/Zoho%20CRM%20Reports/RAW%20CALLS?ZOHO_ACTION=EXPORT&ZOHO_OUTPUT_FORMAT=XML&ZOHO_ERROR_FORMAT=XML&authtoken=a263834c09c998df6e5499097990a71d&ZOHO_API_VERSION=1.0&ZOHO_CRITERIA=(%22Created%20Time%22%3E%27{0}%27)";

        public static void UpdateSiHSalesWorkFlowData()
        {
            AddCallsFromZoho();

        }

        private static ZohoCalls SetCallValue(ZohoCalls zc, String name, String value)
        {
            switch (name)
            {
                case "ACCOUNTID":
                    {
                        zc.Accountid = value;
                        break;
                    }
                case "Billable":
                    {
                        zc.Billable = value;
                        break;
                    }
                case "Call Duration":
                    {
                        zc.CallDuration = value;
                        break;
                    }
                case "Call Duration (in minutes)":
                    {
                        zc.CallDuration = value;
                        break;
                    }
                case "Call Duration (in seconds)":
                    {
                        zc.CallDuration = value;
                        break;
                    }
                case "Call Owner":
                    {
                        zc.CallOwner = value;
                        break;
                    }
                case "Call Owner Id":
                    {
                        zc.CallOwnerId = value;
                        break;
                    }
                case "Call Purpose":
                    {
                        zc.CallPurpose = value;
                        break;
                    }
                case "Call Result":
                    {
                        zc.CallResult = value;
                        break;
                    }
                case "Call Start Time":
                    {
                        zc.CallStartTime = Convert.ToDateTime(value);
                        break;
                    }
                case "Call Type":
                    {
                        zc.CallType = value;
                        break;
                    }
                case "ContactID":
                    {
                        zc.ContactId = value;
                        break;
                    }
                case "CreatedBy":
                    {
                        zc.CreatedBy = value;
                        break;
                    }
                case "Created Time":
                    {
                        zc.CreatedTime = Convert.ToDateTime(value);
                        break;
                    }
                case "LEADID":
                    {
                        zc.Leadid = value;
                        break;
                    }
                case "Modified Time":
                    {
                        zc.ModifiedTime = Convert.ToDateTime(value);
                        break;
                    }
                case "POTENTIALID":
                    {
                        zc.Potentialid = value;
                        break;
                    }
                case "RELATED To":
                    {
                        zc.RelatedTo = value;
                        break;
                    }
                case "SEMODULE":
                    {
                        zc.Semodule = value;
                        break;
                    }
                case "Subject":
                    {
                        zc.Subject = value;
                        break;
                    }
                case "TASKID":
                    {
                        zc.Taskid = value;
                        break;
                    }
                case "Who Id Id":
                    {
                        zc.WhoIdId = value;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return zc;
        }


        private static ZohoLeads SetLeadValue(ZohoLeads zl, String name, String value)
        {
            try
            {
                switch (name)
                {

                    case "Activities Involved":
                        {
                            
                            if (value == "Yes")
                                value = "true";
                            else
                                value = "false";
                            zl.ActivitiesInvolved = Convert.ToBoolean(value);
                            break;
                        }
                    case "Calls Involved":
                        {
                            if (value == "Yes")
                                value = "true";
                            else
                                value = "false";
                            zl.CallsInvolved = Convert.ToBoolean(value);
                            break;
                        }
                    case "Company":
                        {
                            zl.Company = value;
                            break;
                        }
                    case "CONVERTED":
                        {
                            if (value == "Yes")
                                value = "true";
                            else
                                value = "false";
                            zl.Converted = Convert.ToBoolean(value);
                            break;
                        }
                    case "Created By":
                        {
                            zl.CreatedBy = value;
                            break;
                        }
                    case "Created Time":
                        {
                            zl.CreatedTime = Convert.ToDateTime(value);
                            break;
                        }
                    case "Email":
                        {
                            zl.Email = value;
                            break;
                        }
                    case "Email Opt Out":
                        {
                            if (value == "Yes")
                                value = "true";
                            else
                                value = "false";
                            zl.EmailOptOut = Convert.ToBoolean(value);
                            break;
                        }
                    case "Events Involved":
                        {
                            if (value == "Yes")
                                value = "true";
                            else
                                value = "false";
                            zl.EventsInvolved = Convert.ToBoolean(value);
                            break;
                        }
                    case "Features of Interest":
                        {
                            zl.FeaturesOfInterest = value;
                            break;
                        }
                    case "First Name":
                        {
                            zl.FirstName = value;
                            break;
                        }
                    case "If No Longer Interested":
                        {
                            zl.IfNoLongerInterested = value;
                            break;
                        }
                    case "Industry":
                        {
                            zl.Industry = value;
                            break;
                        }
                    case "Last Activity Time":
                        {
                            zl.LastActivityTime = Convert.ToDateTime(value);
                            break;
                        }
                    case "Last Name":
                        {
                            zl.LastName = value;
                            break;
                        }
                    case "Last Visited Time":
                        {
                            zl.LastVisitedTime = value;
                            break;
                        }
                    case "Lead Owner Id":
                        {
                            zl.LeadOwner = value;
                            break;
                        }
                    case "Lead Owner":
                        {
                            zl.LeadOwner = value;
                            break;
                        }
                    case "Lead Source":
                        {
                            zl.LeadSource = value;
                            break;
                        }
                    case "Lead Status":
                        {
                            zl.LeadStatus = value;
                            break;
                        }
                    case "LEADID":
                        {
                            zl.Leadid = value;
                            break;
                        }
                    case "Mobile":
                        {
                            zl.Mobile = value;
                            break;
                        }
                    case "Modified By":
                        {
                            zl.ModifiedBy = value;
                            break;
                        }
                    case "Modified Time":
                        {
                            zl.ModifiedTime = Convert.ToDateTime(value);
                            break;
                        }
                    case "Phone":
                        {
                            zl.Phone = value;
                            break;
                        }
                    case "Rating":
                        {
                            zl.Rating = value;
                            break;
                        }
                    case "Secondary Email":
                        {
                            zl.SecondaryEmail = value;
                            break;
                        }
                    case "State":
                        {
                            zl.State = value;
                            break;
                        }
                    case "Submission Time":
                        {
                            zl.SubmissionTime = value;
                            break;
                        }
                    case "Submitted On":
                        {
                            zl.SubmittedOn = Convert.ToDateTime(value);
                            break;
                        }
                    case "Tasks Involved":
                        {
                            if (value == "Yes")
                                value = "true";
                            else
                                value = "false";
                            zl.TasksInvolved = Convert.ToBoolean(value);
                            break;
                        }
                    case "Time Zone":
                        {
                            zl.TimeZone = value;
                            break;
                        }
                    case "URL":
                        {
                            zl.Url = value;
                            break;
                        }
                    case "Website":
                        {
                            zl.Website = value;
                            break;
                        }
                    case "Worries":
                        {
                            zl.Worries = value;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            {

            }
            return zl;

        }
        private static long GetCallByTaskId(String callId)
        {
            VList<VwZohoCalls> vzc = DataRepository.VwZohoCallsProvider.Get("taskid = '" + callId + "'", "");
            if (vzc.Count > 0)
                return vzc[0].CallPk;
            else
                return -1;
        }
        private static long GetLeadByLeadId(String leadId)
        {
            VList<VwZohoLeads> vzl = DataRepository.VwZohoLeadsProvider.Get("LeadId = '" + leadId + "'", "");
            if (vzl.Count > 0)
                return vzl[0].Leadpk;
            else
                return -1;
        }
        private static void AddPhoneCalls(String xml)
        {
         
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            string xpath = "response/result/rows/row";
            var nodes = xmlDoc.SelectNodes(xpath);

            
            foreach (XmlNode childrenNode in nodes)
            {
                ZohoCalls zc = new ZohoCalls();
                string innerXpath = "column";
                var innernodes = childrenNode.SelectNodes(innerXpath);
                
                foreach (XmlNode childrenInnerNode in innernodes)
                {
                    zc = SetCallValue(zc,childrenInnerNode.Attributes[0].Value, childrenInnerNode.InnerText);
                }
                long callPK =GetCallByTaskId(zc.Taskid);
                if (callPK > 0)
                {
                    zc = DataRepository.ZohoCallsProvider.GetByCallPk(callPK);
                    foreach (XmlNode childrenInnerNode in innernodes)
                    {
                        zc = SetCallValue(zc, childrenInnerNode.Attributes[0].Value, childrenInnerNode.InnerText);
                    }                    
                }
                DataRepository.ZohoCallsProvider.Save(zc);
            }         
          }
        public static void AddCallsFromZoho()
        {
            DateTime lastCallCreated = GetLastCallCreated();
                                                                                    //2016-02-02%2014:17:48
            String finalCallUrl = zohocrmurl + accountEmail + String.Format(callsURL, lastCallCreated.ToString("yyyy-MM-dd HH:mm:ss"));
            String xml = AccessCRM(finalCallUrl);
            AddPhoneCalls(xml);
        }
        public static void UpdateLeadsFromZoho()
        {
            DateTime lastCallCreated = GetLastCallCreated();

            String finalCallUrl = zohocrmurl + accountEmail + String.Format(leadsURL, lastCallCreated.ToString("yyyy-MM-dd HH:mm:ss"));

            String xml = AccessCRM(finalCallUrl);
            UpdateLeads(xml);
            
        }
        public static void UpdateLeads(String xml)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            string xpath = "response/result/rows/row";
            var nodes = xmlDoc.SelectNodes(xpath);

            
            foreach (XmlNode childrenNode in nodes)
            {
                ZohoLeads lc = new ZohoLeads();
                string innerXpath = "column";
                var innernodes = childrenNode.SelectNodes(innerXpath);

                foreach (XmlNode childrenInnerNode in innernodes)
                {
                    lc = SetLeadValue(lc, childrenInnerNode.Attributes[0].Value, childrenInnerNode.InnerText);
                }
                long leadpk = GetLeadByLeadId(lc.Leadid);
                if (leadpk > 0) 
                {
                    //lc.Leadpk=leadpk;
                    lc = DataRepository.ZohoLeadsProvider.GetByLeadpk(leadpk);
                    foreach (XmlNode childrenInnerNode in innernodes)
                    {
                        lc = SetLeadValue(lc, childrenInnerNode.Attributes[0].Value, childrenInnerNode.InnerText);
                    }
                }
                DataRepository.ZohoLeadsProvider.Save(lc);
            } 
        }
        public static void ResetCallCount()
        {
            DataRepository.Provider.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "SetPeriodCallCountsALL");
        }

        public static DateTime GetLastCallCreated()
        {
            VList<VwLastCallCreated> lastCall = DataRepository.VwLastCallCreatedProvider.Get();
            if (lastCall.Count > 0)
            {
                if (lastCall[0].LastCallCreated != null)
                    return Convert.ToDateTime(lastCall[0].LastCallCreated);
                else
                    return DateTime.UtcNow.AddHours(-8);
            }
            else
                return DateTime.UtcNow.AddHours(-8);

        }
        public static void ImportZohoData()
        {
            try
            {
                        UpdateLeadsFromZoho();
                AddCallsFromZoho();
                ResetCallCount();

                
            }
            catch (Exception ex)
            {
                                        
            }

                 }

        public static string AccessCRM(string url)
        {

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes("");
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
