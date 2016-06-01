using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace SalesWorkflow.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>VwReportingZohoCallsConnectedAfterDateRepeater</c>
    /// </summary>
	public class VwReportingZohoCallsConnectedAfterDateRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VwReportingZohoCallsConnectedAfterDateRepeaterDesigner"/> class.
        /// </summary>
		public VwReportingZohoCallsConnectedAfterDateRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is VwReportingZohoCallsConnectedAfterDateRepeater))
			{ 
				throw new ArgumentException("Component is not a VwReportingZohoCallsConnectedAfterDateRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			VwReportingZohoCallsConnectedAfterDateRepeater z = (VwReportingZohoCallsConnectedAfterDateRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="VwReportingZohoCallsConnectedAfterDateRepeater"/> Type.
    /// </summary>
	[Designer(typeof(VwReportingZohoCallsConnectedAfterDateRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:VwReportingZohoCallsConnectedAfterDateRepeater runat=\"server\"></{0}:VwReportingZohoCallsConnectedAfterDateRepeater>")]
	public class VwReportingZohoCallsConnectedAfterDateRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VwReportingZohoCallsConnectedAfterDateRepeater"/> class.
        /// </summary>
		public VwReportingZohoCallsConnectedAfterDateRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(VwReportingZohoCallsConnectedAfterDateItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(VwReportingZohoCallsConnectedAfterDateItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
		/// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(VwReportingZohoCallsConnectedAfterDateItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }

		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(VwReportingZohoCallsConnectedAfterDateItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(VwReportingZohoCallsConnectedAfterDateItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}
		
		
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//		{
//			if (ChildControlsCreated)
//			{
//				return;
//			}
//			Controls.Clear();
//
//			if (m_headerTemplate != null)
//			{
//				Control headerItem = new Control();
//				m_headerTemplate.InstantiateIn(headerItem);
//				Controls.Add(headerItem);
//			}
//
//			
//			if (m_footerTemplate != null)
//			{
//				Control footerItem = new Control();
//				m_footerTemplate.InstantiateIn(footerItem);
//				Controls.Add(footerItem);
//			}
//			ChildControlsCreated = true;
//		}
		
		/// <summary>
      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      /// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      {
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						SalesWorkflow.Entities.VwReportingZohoCallsConnectedAfterDate entity = o as SalesWorkflow.Entities.VwReportingZohoCallsConnectedAfterDate;
						VwReportingZohoCallsConnectedAfterDateItem container = new VwReportingZohoCallsConnectedAfterDateItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}

							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}

							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}            
			//Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }				
		 }
			
			return pos;
		}
		
      /// <summary>
      /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
      /// </summary>
      /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class VwReportingZohoCallsConnectedAfterDateItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private SalesWorkflow.Entities.VwReportingZohoCallsConnectedAfterDate _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VwReportingZohoCallsConnectedAfterDateItem"/> class.
        /// </summary>
		public VwReportingZohoCallsConnectedAfterDateItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VwReportingZohoCallsConnectedAfterDateItem"/> class.
        /// </summary>
		public VwReportingZohoCallsConnectedAfterDateItem(SalesWorkflow.Entities.VwReportingZohoCallsConnectedAfterDate entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the Accountid
        /// </summary>
        /// <value>The Accountid.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Accountid
		{
			get { return _entity.Accountid; }
		}
        /// <summary>
        /// Gets the Billable
        /// </summary>
        /// <value>The Billable.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Billable
		{
			get { return _entity.Billable; }
		}
        /// <summary>
        /// Gets the CallDuration
        /// </summary>
        /// <value>The CallDuration.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CallDuration
		{
			get { return _entity.CallDuration; }
		}
        /// <summary>
        /// Gets the SafeNameCallDurationInMinutes
        /// </summary>
        /// <value>The SafeNameCallDurationInMinutes.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Double? SafeNameCallDurationInMinutes
		{
			get { return _entity.SafeNameCallDurationInMinutes; }
		}
        /// <summary>
        /// Gets the SafeNameCallDurationInSeconds
        /// </summary>
        /// <value>The SafeNameCallDurationInSeconds.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Double? SafeNameCallDurationInSeconds
		{
			get { return _entity.SafeNameCallDurationInSeconds; }
		}
        /// <summary>
        /// Gets the CallOwner
        /// </summary>
        /// <value>The CallOwner.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CallOwner
		{
			get { return _entity.CallOwner; }
		}
        /// <summary>
        /// Gets the CallOwnerId
        /// </summary>
        /// <value>The CallOwnerId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CallOwnerId
		{
			get { return _entity.CallOwnerId; }
		}
        /// <summary>
        /// Gets the CallPurpose
        /// </summary>
        /// <value>The CallPurpose.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CallPurpose
		{
			get { return _entity.CallPurpose; }
		}
        /// <summary>
        /// Gets the CallResult
        /// </summary>
        /// <value>The CallResult.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CallResult
		{
			get { return _entity.CallResult; }
		}
        /// <summary>
        /// Gets the CallStartTime
        /// </summary>
        /// <value>The CallStartTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? CallStartTime
		{
			get { return _entity.CallStartTime; }
		}
        /// <summary>
        /// Gets the CallType
        /// </summary>
        /// <value>The CallType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CallType
		{
			get { return _entity.CallType; }
		}
        /// <summary>
        /// Gets the ContactId
        /// </summary>
        /// <value>The ContactId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ContactId
		{
			get { return _entity.ContactId; }
		}
        /// <summary>
        /// Gets the CreatedBy
        /// </summary>
        /// <value>The CreatedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CreatedBy
		{
			get { return _entity.CreatedBy; }
		}
        /// <summary>
        /// Gets the CreatedTime
        /// </summary>
        /// <value>The CreatedTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? CreatedTime
		{
			get { return _entity.CreatedTime; }
		}
        /// <summary>
        /// Gets the Leadid
        /// </summary>
        /// <value>The Leadid.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Leadid
		{
			get { return _entity.Leadid; }
		}
        /// <summary>
        /// Gets the ModifiedTime
        /// </summary>
        /// <value>The ModifiedTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? ModifiedTime
		{
			get { return _entity.ModifiedTime; }
		}
        /// <summary>
        /// Gets the Potentialid
        /// </summary>
        /// <value>The Potentialid.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Potentialid
		{
			get { return _entity.Potentialid; }
		}
        /// <summary>
        /// Gets the RelatedTo
        /// </summary>
        /// <value>The RelatedTo.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RelatedTo
		{
			get { return _entity.RelatedTo; }
		}
        /// <summary>
        /// Gets the Semodule
        /// </summary>
        /// <value>The Semodule.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Semodule
		{
			get { return _entity.Semodule; }
		}
        /// <summary>
        /// Gets the Subject
        /// </summary>
        /// <value>The Subject.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Subject
		{
			get { return _entity.Subject; }
		}
        /// <summary>
        /// Gets the Taskid
        /// </summary>
        /// <value>The Taskid.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Taskid
		{
			get { return _entity.Taskid; }
		}
        /// <summary>
        /// Gets the WhoIdId
        /// </summary>
        /// <value>The WhoIdId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WhoIdId
		{
			get { return _entity.WhoIdId; }
		}
        /// <summary>
        /// Gets the CallPk
        /// </summary>
        /// <value>The CallPk.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 CallPk
		{
			get { return _entity.CallPk; }
		}

	}
}
