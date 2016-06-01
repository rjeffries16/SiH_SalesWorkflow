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
    /// A designer class for a strongly typed repeater <c>VwLeadsAndCallsRepeater</c>
    /// </summary>
	public class VwLeadsAndCallsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VwLeadsAndCallsRepeaterDesigner"/> class.
        /// </summary>
		public VwLeadsAndCallsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is VwLeadsAndCallsRepeater))
			{ 
				throw new ArgumentException("Component is not a VwLeadsAndCallsRepeater."); 
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
			VwLeadsAndCallsRepeater z = (VwLeadsAndCallsRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="VwLeadsAndCallsRepeater"/> Type.
    /// </summary>
	[Designer(typeof(VwLeadsAndCallsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:VwLeadsAndCallsRepeater runat=\"server\"></{0}:VwLeadsAndCallsRepeater>")]
	public class VwLeadsAndCallsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VwLeadsAndCallsRepeater"/> class.
        /// </summary>
		public VwLeadsAndCallsRepeater()
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
		[TemplateContainer(typeof(VwLeadsAndCallsItem))]
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
		[TemplateContainer(typeof(VwLeadsAndCallsItem))]
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
        [TemplateContainer(typeof(VwLeadsAndCallsItem))]
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
		[TemplateContainer(typeof(VwLeadsAndCallsItem))]
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
		[TemplateContainer(typeof(VwLeadsAndCallsItem))]
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
						SalesWorkflow.Entities.VwLeadsAndCalls entity = o as SalesWorkflow.Entities.VwLeadsAndCalls;
						VwLeadsAndCallsItem container = new VwLeadsAndCallsItem(entity);
	
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
	public class VwLeadsAndCallsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private SalesWorkflow.Entities.VwLeadsAndCalls _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VwLeadsAndCallsItem"/> class.
        /// </summary>
		public VwLeadsAndCallsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VwLeadsAndCallsItem"/> class.
        /// </summary>
		public VwLeadsAndCallsItem(SalesWorkflow.Entities.VwLeadsAndCalls entity)
			: base()
		{
			_entity = entity;
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
        /// Gets the LastName
        /// </summary>
        /// <value>The LastName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LastName
		{
			get { return _entity.LastName; }
		}
        /// <summary>
        /// Gets the FirstName
        /// </summary>
        /// <value>The FirstName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FirstName
		{
			get { return _entity.FirstName; }
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
        /// Gets the LastActivityTime
        /// </summary>
        /// <value>The LastActivityTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? LastActivityTime
		{
			get { return _entity.LastActivityTime; }
		}
        /// <summary>
        /// Gets the LastVisitedTime
        /// </summary>
        /// <value>The LastVisitedTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LastVisitedTime
		{
			get { return _entity.LastVisitedTime; }
		}
        /// <summary>
        /// Gets the LeadOwner
        /// </summary>
        /// <value>The LeadOwner.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LeadOwner
		{
			get { return _entity.LeadOwner; }
		}
        /// <summary>
        /// Gets the LeadSource
        /// </summary>
        /// <value>The LeadSource.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LeadSource
		{
			get { return _entity.LeadSource; }
		}
        /// <summary>
        /// Gets the Rating
        /// </summary>
        /// <value>The Rating.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Rating
		{
			get { return _entity.Rating; }
		}
        /// <summary>
        /// Gets the LeadStatus
        /// </summary>
        /// <value>The LeadStatus.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LeadStatus
		{
			get { return _entity.LeadStatus; }
		}
        /// <summary>
        /// Gets the TimeZone
        /// </summary>
        /// <value>The TimeZone.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TimeZone
		{
			get { return _entity.TimeZone; }
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
        /// Gets the CreatedBy
        /// </summary>
        /// <value>The CreatedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CreatedBy
		{
			get { return _entity.CreatedBy; }
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

	}
}
