using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiH_SalesWorkflow.Data;
using SiH_SalesWorkflow.Entities;
using System.Web;
using System.Net;
using System.Text;
using System.IO;

namespace SalesWorkflow.SalesLeads
{
    public partial class JoEllenList : System.Web.UI.Page
    {
        private String UserID = "1359242000000097001";// JoEllen
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
                lblCallsTodayCount.Text = lau.TodaysCallCount(UserID).ToString();
                lblDeferTodayCount.Text = lau.TodaysDeferCount(UserID).ToString();
                if (hdLeadId.Value == "")
                {
                    chkBoxDefer.Enabled = false;
                    chkBoxComplete.Enabled = false;
                }
                LoadDeferedLeads(UserID);
                LoadCalledLeads(UserID);
            }
            
            
        }

        protected void chkBoxComplete_CheckedChanged(object sender, EventArgs e)
        {
            String leadId = hdLeadId.Value;
            HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
            lau.MarkLeadCalled(UserID, leadId);
           // GetNewLead();
            chkBoxComplete.Checked = false;
            chkBoxDefer.Checked = false;
            lblCallsTodayCount.Text = lau.TodaysCallCount(UserID).ToString();
            lblDeferTodayCount.Text = lau.TodaysDeferCount(UserID).ToString();
            lblFullName.Text = "";
            lbNextLead.Enabled = true;
            lbNextLead.Visible = true;
            lblCompleteLast.Visible = false;

            chkBoxDefer.Enabled = false;
            chkBoxComplete.Enabled = false;
            LoadDeferedLeads(UserID);
            LoadCalledLeads(UserID);
            
        }


        protected void chkBoxDefer_CheckedChanged(object sender, EventArgs e)
        {
            String leadId = hdLeadId.Value;
            HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
            lau.MarkLeadDefered(UserID, leadId);
            //GetNewLead();
            chkBoxDefer.Checked = false;
            chkBoxComplete.Checked = false;
            lblCallsTodayCount.Text = lau.TodaysCallCount(UserID).ToString();
            lblDeferTodayCount.Text = lau.TodaysDeferCount(UserID).ToString();
            lblFullName.Text = "";
            lbNextLead.Visible = true;
            lblCompleteLast.Visible = false;
            lbNextLead.Enabled = true;
            chkBoxDefer.Enabled = false;
            chkBoxComplete.Enabled = false;
            LoadDeferedLeads(UserID);
            LoadCalledLeads(UserID);
            
        }
        private void GetNewLead()
        {
            SalesWorkflow.HelperCode.GetLead getLead = new HelperCode.GetLead();
            SalesWorkflow.HelperCode.GetLead.Lead lead = getLead.NextLead(UserID);
            //hlNextLead.NavigateUrl = lead.Url;
            //hlNextLead.Text = lead.LeadId;

            HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
            lau.HoldLead(UserID, lead.LeadId);
            hdLeadId.Value = lead.LeadId;
            lblCallsTodayCount.Text = lau.TodaysCallCount(UserID).ToString() ;
            //  myiframe.Src = lead.Url;
           // loadPanel( lead.Url);
        }
        

        protected void lbNextLead_Click(object sender, EventArgs e)
        {
            OpenWindow(sender, e);
        }

        protected void OpenWindow(object sender, EventArgs e)
        {
            SalesWorkflow.HelperCode.GetLead getLead = new HelperCode.GetLead();
            SalesWorkflow.HelperCode.GetLead.Lead lead = new SalesWorkflow.HelperCode.GetLead.Lead();
            lead.LeadId = ZohoAPICaller.ZohoAPI.GetAndAssignNewLead(UserID);
            if (lead.LeadId == null || lead.LeadId == "")
                lead = getLead.NextLead(UserID);
            else
            {
                lead.LeadName = "Newly Submitted Lead";
                ZohoLeads newLead = new ZohoLeads();
                newLead.Leadid = lead.LeadId;
                newLead.LastName = lead.LeadName;
                lead.Url = "https://crm.zoho.com/crm/EntityInfo.do?module=Leads&id=" + lead.LeadId;
                DataRepository.ZohoLeadsProvider.Save(newLead);
            }
            //hlNextLead.NavigateUrl = lead.Url;
            //hlNextLead.Text = lead.LeadId;
            HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
            
            if (lead.LeadName != null)
            {
                lau.HoldLead(UserID, lead.LeadId);
                hdLeadId.Value = lead.LeadId;
                lblFullName.Text = lead.LeadName;
                string url = lead.Url;
                string s = "window.open('" + url + "', 'popup_window', 'left=100,top=100,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                chkBoxDefer.Enabled = true;
                chkBoxComplete.Enabled = true;
                lbNextLead.Enabled = false;
                lbNextLead.Visible = false;
                lblCompleteLast.Visible = true; 
                lblFullName.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lblFullName.Text = "List empty please try again after the top of the hour";
                lblFullName.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadCalledLeads(String userId)
        {
            lbCalledLeads.Items.Clear();
            HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
            VList<VwHoldAndCallWithLeadInfo> vhcli =  lau.TodaysCalls(UserID);
            for (int i = 0; i < vhcli.Count; i++)
            {
                lbCalledLeads.Items.Add(vhcli[i].LastName + ", " + vhcli[i].FirstName);
            }
        }
        private void LoadDeferedLeads(String userId)
        {
            lbDeferedLeads.Items.Clear();
            HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
            VList<VwHoldAndCallWithLeadInfo> vhcli = lau.TodaysDefers(UserID);
            for (int i = 0; i < vhcli.Count; i++)
            {
               lbDeferedLeads.Items.Add(vhcli[i].LastName + ", " + vhcli[i].FirstName);
            }
        }
        
    }
}