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
    public partial class DataCleanup : System.Web.UI.Page
    {
         private String UserID = "1359242000001113003";// JENN
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
                if (hdLeadId.Value == "")
                {
                    chkBoxDefer.Enabled = false;
                    chkBoxComplete.Enabled = false;
                }

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
            lblFullName.Text = "";
            lbNextLead.Enabled = true;
            lbNextLead.Visible = true;
            lblCompleteLast.Visible = false;

            chkBoxDefer.Enabled = false;
            chkBoxComplete.Enabled = false;
           
            
        }


        protected void chkBoxDefer_CheckedChanged(object sender, EventArgs e)
        {
            String leadId = hdLeadId.Value;
            HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
            lau.MarkLeadDefered(UserID, leadId);
            //GetNewLead();
            chkBoxDefer.Checked = false;
            chkBoxComplete.Checked = false;
            lblFullName.Text = "";
            lbNextLead.Visible = true;
            lblCompleteLast.Visible = false;
            lbNextLead.Enabled = true;
            chkBoxDefer.Enabled = false;
            chkBoxComplete.Enabled = false;
            
            
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
            SalesWorkflow.HelperCode.GetLead.Lead lead = getLead.NextDataIssue(UserID, txtWhereClause.Text);
            //hlNextLead.NavigateUrl = lead.Url;
            //hlNextLead.Text = lead.LeadId;
            if (lead.LeadName != "error" || lead.LeadName == null)
            {
                HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
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
            }
            else
            {
                lblFullName.Text = "Query Error or Out of Data";
                lblFullName.ForeColor = System.Drawing.Color.Red;
            }
        }
                
    }
}