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
    /// A designer class for a strongly typed repeater <c>VwCallableLeadsWithCallsAndPeriodsRepeater</c>
    /// </summary>
	public class VwCallableLeadsWithCallsAndPeriodsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VwCallableLeadsWithCallsAndPeriodsRepeaterDesigner"/> class.
        /// </summary>
		public VwCallableLeadsWithCallsAndPeriodsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is VwCallableLeadsWithCallsAndPeriodsRepeater))
			{ 
				throw new ArgumentException("Component is not a VwCallableLeadsWithCallsAndPeriodsRepeater."); 
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
			VwCallableLeadsWithCallsAndPeriodsRepeater z = (VwCallableLeadsWithCallsAndPeriodsRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="VwCallableLeadsWithCallsAndPeriodsRepeater"/> Type.
    /// </summary>
	[Designer(typeof(VwCallableLeadsWithCallsAndPeriodsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:VwCallableLeadsWithCallsAndPeriodsRepeater runat=\"server\"></{0}:VwCallableLeadsWithCallsAndPeriodsRepeater>")]
	public class VwCallableLeadsWithCallsAndPeriodsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VwCallableLeadsWithCallsAndPeriodsRepeater"/> class.
        /// </summary>
		public VwCallableLeadsWithCallsAndPeriodsRepeater()
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
		[TemplateContainer(typeof(VwCallableLeadsWithCallsAndPeriodsItem))]
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
		[TemplateContainer(typeof(VwCallableLeadsWithCallsAndPeriodsItem))]
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
        [TemplateContainer(typeof(VwCallableLeadsWithCallsAndPeriodsItem))]
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
		[TemplateContainer(typeof(VwCallableLeadsWithCallsAndPeriodsItem))]
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
		[TemplateContainer(typeof(VwCallableLeadsWithCallsAndPeriodsItem))]
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
						SalesWorkflow.Entities.VwCallableLeadsWithCallsAndPeriods entity = o as SalesWorkflow.Entities.VwCallableLeadsWithCallsAndPeriods;
						VwCallableLeadsWithCallsAndPeriodsItem container = new VwCallableLeadsWithCallsAndPeriodsItem(entity);
	
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
	public class VwCallableLeadsWithCallsAndPeriodsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private SalesWorkflow.Entities.VwCallableLeadsWithCallsAndPeriods _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VwCallableLeadsWithCallsAndPeriodsItem"/> class.
        /// </summary>
		public VwCallableLeadsWithCallsAndPeriodsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VwCallableLeadsWithCallsAndPeriodsItem"/> class.
        /// </summary>
		public VwCallableLeadsWithCallsAndPeriodsItem(SalesWorkflow.Entities.VwCallableLeadsWithCallsAndPeriods entity)
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
        /// Gets the CreatedTime
        /// </summary>
        /// <value>The CreatedTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? CreatedTime
		{
			get { return _entity.CreatedTime; }
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
        /// Gets the LastName
        /// </summary>
        /// <value>The LastName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LastName
		{
			get { return _entity.LastName; }
		}
        /// <summary>
        /// Gets the IfNoLongerInterested
        /// </summary>
        /// <value>The IfNoLongerInterested.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String IfNoLongerInterested
		{
			get { return _entity.IfNoLongerInterested; }
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
        /// Gets the LeadOwner
        /// </summary>
        /// <value>The LeadOwner.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LeadOwner
		{
			get { return _entity.LeadOwner; }
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
        /// Gets the State
        /// </summary>
        /// <value>The State.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String State
		{
			get { return _entity.State; }
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
        /// Gets the SatMc
        /// </summary>
        /// <value>The SatMc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SatMc
		{
			get { return _entity.SatMc; }
		}
        /// <summary>
        /// Gets the SatDc
        /// </summary>
        /// <value>The SatDc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SatDc
		{
			get { return _entity.SatDc; }
		}
        /// <summary>
        /// Gets the SatAc
        /// </summary>
        /// <value>The SatAc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SatAc
		{
			get { return _entity.SatAc; }
		}
        /// <summary>
        /// Gets the SatEc
        /// </summary>
        /// <value>The SatEc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SatEc
		{
			get { return _entity.SatEc; }
		}
        /// <summary>
        /// Gets the SunMc
        /// </summary>
        /// <value>The SunMc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SunMc
		{
			get { return _entity.SunMc; }
		}
        /// <summary>
        /// Gets the SunDc
        /// </summary>
        /// <value>The SunDc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SunDc
		{
			get { return _entity.SunDc; }
		}
        /// <summary>
        /// Gets the SunAc
        /// </summary>
        /// <value>The SunAc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SunAc
		{
			get { return _entity.SunAc; }
		}
        /// <summary>
        /// Gets the SunEc
        /// </summary>
        /// <value>The SunEc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SunEc
		{
			get { return _entity.SunEc; }
		}
        /// <summary>
        /// Gets the Dmc
        /// </summary>
        /// <value>The Dmc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Dmc
		{
			get { return _entity.Dmc; }
		}
        /// <summary>
        /// Gets the Ddc
        /// </summary>
        /// <value>The Ddc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Ddc
		{
			get { return _entity.Ddc; }
		}
        /// <summary>
        /// Gets the Dac
        /// </summary>
        /// <value>The Dac.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Dac
		{
			get { return _entity.Dac; }
		}
        /// <summary>
        /// Gets the Dec
        /// </summary>
        /// <value>The Dec.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Dec
		{
			get { return _entity.Dec; }
		}
        /// <summary>
        /// Gets the Phone
        /// </summary>
        /// <value>The Phone.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Phone
		{
			get { return _entity.Phone; }
		}

	}
}
