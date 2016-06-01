using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiH_SalesWorkflow.Data;
using SiH_SalesWorkflow.Entities;

namespace SiH_SalesWorkFlowWebApp.HelperCode
{
    public class GetLead
    {

        public class Lead
        {
            public String LeadId { get; set; } 
            public String Url {get;set;} 
            public DateTime VoidTime {get;set;}
            public String LeadName { get; set; }
        }
        public GetLead()
        {
            //if (UserName != String.Empty && UserName != null)
            //    return GetLead(UserName);
        }
        public GetLead(String userName)
        {

        }
        public String UserName { get; set; }
        public Lead NextDataIssue(String userId, String whereClause)
        {

            Lead nextLead = new Lead();
            try
            {
                
                String orderByClause = "[Created Time] desc";
                VList<VwZohoLeadsWithLocalTimeNoActionToday> vlgs = DataRepository.VwZohoLeadsWithLocalTimeNoActionTodayProvider.Get(whereClause, orderByClause);

                nextLead.LeadId = vlgs[0].Leadid;
                nextLead.Url = "https://crm.zoho.com/crm/EntityInfo.do?module=Leads&id=" + vlgs[0].Leadid;
                nextLead.VoidTime = DateTime.UtcNow.AddMinutes(30);
                nextLead.LeadName = vlgs[0].FirstName + " " + vlgs[0].LastName;
            }
            catch (Exception ex)
            {
                nextLead.LeadName = "error";
            }
            return nextLead;
        }
        public Lead GetTimList(String userId)
        {
            Lead nextLead = new Lead();
            try
            {
                String whereClause = "[Created Time] < '2/1/2016' and [Created Time] > '1/3/2016'";// String.Format("[Lead Owner Id] = '{0}' or [Lead Owner Id] is null", userId);
                String orderByClause = "[Created Time] desc";

                VList<VwLeadContactTool> vlgs = DataRepository.VwLeadContactToolProvider.Get(whereClause, orderByClause);
                nextLead.LeadId = vlgs[0].Leadid;
                nextLead.Url = "https://crm.zoho.com/crm/EntityInfo.do?module=Leads&id=" + vlgs[0].Leadid;
                nextLead.VoidTime = DateTime.UtcNow.AddMinutes(30);
                nextLead.LeadName = vlgs[0].FirstName + " " + vlgs[0].LastName;
            }
            catch (Exception ex)
            {

            }
            return nextLead;
        }
        public Lead GetChrisList(String userId)
        {
            Lead nextLead = new Lead();
            try
            {
                String whereClause = "[Created Time] < '2/1/2016' and [Created Time] > '1/3/2016'";// String.Format("[Lead Owner Id] = '{0}' or [Lead Owner Id] is null", userId);
                String orderByClause = "[Created Time] ";

                VList<VwLeadContactTool> vlgs = DataRepository.VwLeadContactToolProvider.Get(whereClause, orderByClause);
                nextLead.LeadId = vlgs[0].Leadid;
                nextLead.Url = "https://crm.zoho.com/crm/EntityInfo.do?module=Leads&id=" + vlgs[0].Leadid;
                nextLead.VoidTime = DateTime.UtcNow.AddMinutes(30);
                nextLead.LeadName = vlgs[0].FirstName + " " + vlgs[0].LastName;
            }
            catch (Exception ex)
            {

            }
            return nextLead;
        }
        public Lead GetJennLead(String userId)
        {
            Lead nextLead = new Lead();
            try
            {
                String whereClause = String.Format("[Lead Owner Id] IN ('{0}','1359242000002712055','1359242000000692001') or [Lead Owner Id] is null", userId);


                String orderByClause = "Priority,[total calls],[Created Time] desc";

                VList<VwLeadGetJenn> vlgs = DataRepository.VwLeadGetJennProvider.Get(whereClause, orderByClause);
                nextLead.LeadId = vlgs[0].Leadid;
                nextLead.Url = "https://crm.zoho.com/crm/EntityInfo.do?module=Leads&id=" + vlgs[0].Leadid;
                nextLead.VoidTime = DateTime.UtcNow.AddMinutes(30);
                nextLead.LeadName = vlgs[0].FirstName + " " + vlgs[0].LastName;
            }
            catch (Exception ex)
            {

            }
            return nextLead;
        }
        public Lead GetJoEllenLead(String userId, String timeZone)
        {
            Lead nextLead = new Lead();
            try
            {
                String whereClause = String.Format("([Lead Owner Id] = '{0}' or [Lead Owner Id] is null) and [time zone] = '{1}'", userId, timeZone);
                String orderByClause = "Priority,[total calls],[Created Time] desc";

                VList<VwLeadGetJoEllen> vlgs = DataRepository.VwLeadGetJoEllenProvider.Get(whereClause, orderByClause);
                nextLead.LeadId = vlgs[0].Leadid;
                nextLead.Url = "https://crm.zoho.com/crm/EntityInfo.do?module=Leads&id=" + vlgs[0].Leadid;
                nextLead.VoidTime = DateTime.UtcNow.AddMinutes(30);
                nextLead.LeadName = vlgs[0].FirstName + " " + vlgs[0].LastName;
            }
            catch (Exception ex)
            {

            }
            return nextLead;
        }
        public Lead GetAlexLead(String userId, String timeZone)
        {
            Lead nextLead = new Lead();
            try
            {
                if (timeZone == "'P (+0)'")
                    timeZone = "'H (-2)','A (-1)','P (+0)'";
                else
                    timeZone = string.Format("''", timeZone);
                String whereClause = String.Format("([Lead Owner Id] = '{0}' or [Lead Owner Id] is null) and [time zone] in ({1})", userId, timeZone);
                String orderByClause = "Priority,[total calls],[Created Time] desc";

                VList<VwLeadGetAlex> vlgs = DataRepository.VwLeadGetAlexProvider.Get(whereClause, orderByClause);
                nextLead.LeadId = vlgs[0].Leadid;
                nextLead.Url = "https://crm.zoho.com/crm/EntityInfo.do?module=Leads&id=" + vlgs[0].Leadid;
                nextLead.VoidTime = DateTime.UtcNow.AddMinutes(30);
                nextLead.LeadName = vlgs[0].FirstName + " " + vlgs[0].LastName;
            }
            catch (Exception ex)
            {

            }
            return nextLead;
        }
        public Lead GetCraigLead(String userId, String timeZone)
        {
            Lead nextLead = new Lead();
            try
            {
                String whereClause = String.Format("([Lead Owner Id] = '{0}' or [Lead Owner Id] is null) and [time zone] = '{1}'", userId, timeZone);
                String orderByClause = "Priority,[total calls],[Created Time] desc";

                VList<VwLeadGetCraig> vlgs = DataRepository.VwLeadGetCraigProvider.Get(whereClause, orderByClause);
                nextLead.LeadId = vlgs[0].Leadid;
                nextLead.Url = "https://crm.zoho.com/crm/EntityInfo.do?module=Leads&id=" + vlgs[0].Leadid;
                nextLead.VoidTime = DateTime.UtcNow.AddMinutes(30);
                nextLead.LeadName = vlgs[0].FirstName + " " + vlgs[0].LastName;
            }
            catch (Exception ex)
            {

            }
            return nextLead;
        }
        public Lead GetRichardLead(String userId, String timeZone)
        {
            Lead nextLead = new Lead();
            try
            {
                String whereClause = String.Format("([Lead Owner Id] = '{0}' or [Lead Owner Id] is null) and [time zone] = '{1}'", userId, timeZone);
                String orderByClause = "Priority,[total calls],[Created Time] desc";

                VList< VwLeadGetRichard> vlgs = DataRepository.VwLeadGetRichardProvider.Get(whereClause, orderByClause);
                nextLead.LeadId = vlgs[0].Leadid;
                nextLead.Url = "https://crm.zoho.com/crm/EntityInfo.do?module=Leads&id=" + vlgs[0].Leadid;
                nextLead.VoidTime = DateTime.UtcNow.AddMinutes(30);
                nextLead.LeadName = vlgs[0].FirstName + " " + vlgs[0].LastName;
            }
            catch (Exception ex)
            {

            }
            return nextLead;
        }
        public Lead NextLead(String userId, String timeZone)
        {
            
            String userName = GetUserName(userId);
            if (userName == "Tim Lloyd")
                return GetTimList(userId);
            if(userName =="Chris Lloyd")
                return GetChrisList(userId);
            if (userName == "Jennifer Kissell")
                return GetJennLead(userId);
            if (userName == "JoEllen Brooks")
                return GetJoEllenLead(userId, timeZone);
            if (userName == "Alex Posey")
                return GetAlexLead(userId, timeZone);
            if (userName == "Craig Colwell")
                return GetCraigLead(userId, timeZone);
            if (userName == "Richard Collins")
                return GetRichardLead(userId, timeZone);
            return null;            
        }
        private String GetUserName(String userId)
        {

            TList<ZohoUsers> users = DataRepository.ZohoUsersProvider.GetAll();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserId == userId)
                {
                    return users[i].FirstName + " " + users[i].LastName;
                }
            }
            return "";
        }
    }
}