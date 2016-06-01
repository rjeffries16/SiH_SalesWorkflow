using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiH_SalesWorkflow.Data;
using SiH_SalesWorkflow.Entities;
using System.Net;
using System.Text;
using System.IO;

namespace SiH_SalesWorkFlowWebApp.SalesLeads
{
    public partial class TimList : System.Web.UI.Page
    {
        private String UserID = "1359242000002027125";// Chris
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HelperCode.LeadContactedHelper lc = new HelperCode.LeadContactedHelper();
                lblCallsTodayCount.Text = lc.TodaysCallCount(UserID).ToString();
                
                if (hdLeadId.Value == "")
                {

                    chkBoxConnectedByPhone.Enabled = false;
                    chkBoxNotConnected.Enabled = false;
                    chkConnectedByEmail.Enabled = false;
                }
                LoadCalledLeads(UserID);
            }
            
            
        }

        protected void chkBoxComplete_CheckedChanged(object sender, EventArgs e)
        {
            String leadId = hdLeadId.Value;
            HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
            lau.MarkLeadCalled(UserID, leadId);
           // GetNewLead();
            chkBoxConnectedByPhone.Checked = false;
            chkConnectedByEmail.Checked = false;
            lblCallsTodayCount.Text = lau.TodaysCallCount(UserID).ToString();
            lblFullName.Text = "";
            lbNextLead.Enabled = true;
            lbNextLead.Visible = true;
            lblCompleteLast.Visible = false;

            chkConnectedByEmail.Enabled = false;
            chkBoxConnectedByPhone.Enabled = false;
            chkBoxNotConnected.Enabled = false;
            LoadCalledLeads(UserID);
            
        }


        protected void chkBoxDefer_CheckedChanged(object sender, EventArgs e)
        {
            String leadId = hdLeadId.Value;
            HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
            lau.MarkLeadDefered(UserID, leadId);
            //GetNewLead();
            chkConnectedByEmail.Checked = false;
            chkBoxConnectedByPhone.Checked = false;
            lblCallsTodayCount.Text = lau.TodaysCallCount(UserID).ToString();
            lblFullName.Text = "";
            lbNextLead.Visible = true;
            lblCompleteLast.Visible = false;
            lbNextLead.Enabled = true;
            chkConnectedByEmail.Enabled = false;
            chkBoxConnectedByPhone.Enabled = false;
            chkBoxNotConnected.Enabled = false;
            LoadCalledLeads(UserID);
            
        }
        //private void GetNewLead()
        //{
        //    SiH_SalesWorkFlowWebApp.HelperCode.GetLead getLead = new HelperCode.GetLead();
        //    SiH_SalesWorkFlowWebApp.HelperCode.GetLead.Lead lead = getLead.NextLead(UserID);
        //    //hlNextLead.NavigateUrl = lead.Url;
        //    //hlNextLead.Text = lead.LeadId;

        //    HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
        //    lau.HoldLead(UserID, lead.LeadId);
        //    hdLeadId.Value = lead.LeadId;
        //    lblCallsTodayCount.Text = lau.TodaysCallCount(UserID).ToString() ;
        //    //  myiframe.Src = lead.Url;
        //   // loadPanel( lead.Url);
        //}
        

        protected void lbNextLead_Click(object sender, EventArgs e)
        {
            OpenWindow(sender, e);
        }

        protected void OpenWindow(object sender, EventArgs e)
        {

            SiH_SalesWorkFlowWebApp.HelperCode.GetLead getLead = new HelperCode.GetLead();
            SiH_SalesWorkFlowWebApp.HelperCode.GetLead.Lead lead = new SiH_SalesWorkFlowWebApp.HelperCode.GetLead.Lead();
            
           lead = getLead.NextLead(UserID, "");
            
           
            HelperCode.LeadAndUsers lau = new HelperCode.LeadAndUsers();
            
            if (lead.LeadName != null)
            {
              
                hdLeadId.Value = lead.LeadId;
                lblFullName.Text = lead.LeadName;
                string url = lead.Url;
                string s = "window.open('" + url + "', 'popup_window', 'left=100,top=100,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                chkConnectedByEmail.Enabled = true;
                chkBoxConnectedByPhone.Enabled = true;
                chkBoxNotConnected.Enabled = true;
                lbNextLead.Enabled = false;
                lbNextLead.Visible = false;
                lblCompleteLast.Visible = true; 
                lblFullName.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lblFullName.Text = "Error See Tim";
                lblFullName.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadCalledLeads(String userId)
        {
            lbCalledLeads.Items.Clear();

            VList<VwLeadContactToolComplete> vlctc = DataRepository.VwLeadContactToolCompleteProvider.Get("", "ThisEventDts desc");
            for (int i = 0; i < vlctc.Count; i++)
            {
                lbCalledLeads.Items.Add(vlctc[i].LastName + ", " + vlctc[i].FirstName);
            }
        }

        protected void chkBoxConnectedByPhone_CheckedChanged(object sender, EventArgs e)
        {
            String leadId = hdLeadId.Value;

            LeadContacted lc = new LeadContacted();
            lc.LeadContactPhone = true;
            lc.LeadContactEmail = false;
            lc.Leadid = leadId;
            lc.ThisEventDts = DateTime.UtcNow;
            lc.LeadContactDts = txtContactDate.Text;
            lc.UserId = UserID;
            DataRepository.LeadContactedProvider.Save(lc);
         //   lc.e
            // GetNewLead();
            chkBoxConnectedByPhone.Checked = false;
            chkConnectedByEmail.Checked = false;
            chkBoxNotConnected.Checked = false;
            HelperCode.LeadContactedHelper lch = new HelperCode.LeadContactedHelper();
            lblCallsTodayCount.Text = lch.TodaysCallCount(UserID).ToString();
            lblFullName.Text = "";
            lbNextLead.Enabled = true;
            lbNextLead.Visible = true;
            lblCompleteLast.Visible = false;
            txtContactDate.Text = "";

            chkConnectedByEmail.Enabled = false;
            chkBoxConnectedByPhone.Enabled = false;
            chkBoxNotConnected.Enabled = false;
            LoadCalledLeads(UserID);
            

        }

        protected void chkConnectedByEmail_CheckedChanged(object sender, EventArgs e)
        {
            String leadId = hdLeadId.Value;

            LeadContacted lc = new LeadContacted();
            lc.LeadContactPhone = false;
            lc.LeadContactEmail = true;
            lc.Leadid = leadId;
            lc.ThisEventDts = DateTime.UtcNow;
            lc.LeadContactDts = txtContactDate.Text;
            lc.UserId = UserID;
            DataRepository.LeadContactedProvider.Save(lc);
            //   lc.e
            // GetNewLead();
            chkBoxConnectedByPhone.Checked = false;
            chkConnectedByEmail.Checked = false;
            chkBoxNotConnected.Checked = false;
            HelperCode.LeadContactedHelper lch = new HelperCode.LeadContactedHelper();
            lblCallsTodayCount.Text = lch.TodaysCallCount(UserID).ToString();
            lblFullName.Text = "";
            lbNextLead.Enabled = true;
            lbNextLead.Visible = true;
            lblCompleteLast.Visible = false;
            txtContactDate.Text = "";
            
            chkConnectedByEmail.Enabled = false;
            chkBoxConnectedByPhone.Enabled = false;
            chkBoxNotConnected.Enabled = false;
            LoadCalledLeads(UserID);
        }

        protected void chkBoxNotConnected_CheckedChanged(object sender, EventArgs e)
        {
            String leadId = hdLeadId.Value;

            LeadContacted lc = new LeadContacted();
            lc.LeadContactPhone = false;
            lc.LeadContactEmail = false;
            lc.Leadid = leadId;
            lc.ThisEventDts =  DateTime.UtcNow;
            lc.LeadContactDts = "";
            lc.UserId = UserID;
            DataRepository.LeadContactedProvider.Save(lc);
            //   lc.e
            // GetNewLead();
            chkBoxConnectedByPhone.Checked = false;
            chkConnectedByEmail.Checked = false;
            chkBoxNotConnected.Checked = false;
            HelperCode.LeadContactedHelper lch = new HelperCode.LeadContactedHelper();
            lblCallsTodayCount.Text = lch.TodaysCallCount(UserID).ToString();
            lblFullName.Text = "";
            lbNextLead.Enabled = true;
            lbNextLead.Visible = true;
            lblCompleteLast.Visible = false;
            txtContactDate.Text = "";

            chkConnectedByEmail.Enabled = false;
            chkBoxConnectedByPhone.Enabled = false;
            chkBoxNotConnected.Enabled = false;
            LoadCalledLeads(UserID);
        }
        
        
    }
}