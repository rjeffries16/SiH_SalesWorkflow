#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SalesWorkflow.Web.UI;
#endregion

public partial class LeadHoldAndCallEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "LeadHoldAndCallEdit.aspx?{0}", LeadHoldAndCallDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "LeadHoldAndCallEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "LeadHoldAndCall.aspx");
		FormUtil.SetDefaultMode(FormView1, "LeadHoldAndCallPk");
	}
}


