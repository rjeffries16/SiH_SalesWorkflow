#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using SalesWorkflow.Entities;
using SalesWorkflow.Data;
using SalesWorkflow.Data.Bases;
using SalesWorkflow;
#endregion

namespace SalesWorkflow.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.ZohoLeadsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ZohoLeadsDataSourceDesigner))]
	public class ZohoLeadsDataSource : ProviderDataSource<ZohoLeads, ZohoLeadsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsDataSource class.
		/// </summary>
		public ZohoLeadsDataSource() : base(new ZohoLeadsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ZohoLeadsDataSourceView used by the ZohoLeadsDataSource.
		/// </summary>
		protected ZohoLeadsDataSourceView ZohoLeadsView
		{
			get { return ( View as ZohoLeadsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ZohoLeadsDataSource control invokes to retrieve data.
		/// </summary>
		public ZohoLeadsSelectMethod SelectMethod
		{
			get
			{
				ZohoLeadsSelectMethod selectMethod = ZohoLeadsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ZohoLeadsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ZohoLeadsDataSourceView class that is to be
		/// used by the ZohoLeadsDataSource.
		/// </summary>
		/// <returns>An instance of the ZohoLeadsDataSourceView class.</returns>
		protected override BaseDataSourceView<ZohoLeads, ZohoLeadsKey> GetNewDataSourceView()
		{
			return new ZohoLeadsDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the ZohoLeadsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ZohoLeadsDataSourceView : ProviderDataSourceView<ZohoLeads, ZohoLeadsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ZohoLeadsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ZohoLeadsDataSourceView(ZohoLeadsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ZohoLeadsDataSource ZohoLeadsOwner
		{
			get { return Owner as ZohoLeadsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ZohoLeadsSelectMethod SelectMethod
		{
			get { return ZohoLeadsOwner.SelectMethod; }
			set { ZohoLeadsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ZohoLeadsService ZohoLeadsProvider
		{
			get { return Provider as ZohoLeadsService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ZohoLeads> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ZohoLeads> results = null;
			ZohoLeads item;
			count = 0;
			
			System.String _leadid_nullable;
			System.Int64 _leadpk;

			switch ( SelectMethod )
			{
				case ZohoLeadsSelectMethod.Get:
					ZohoLeadsKey entityKey  = new ZohoLeadsKey();
					entityKey.Load(values);
					item = ZohoLeadsProvider.Get(entityKey);
					results = new TList<ZohoLeads>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ZohoLeadsSelectMethod.GetAll:
                    results = ZohoLeadsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ZohoLeadsSelectMethod.GetPaged:
					results = ZohoLeadsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ZohoLeadsSelectMethod.Find:
					if ( FilterParameters != null )
						results = ZohoLeadsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ZohoLeadsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ZohoLeadsSelectMethod.GetByLeadpk:
					_leadpk = ( values["Leadpk"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["Leadpk"], typeof(System.Int64)) : (long)0;
					item = ZohoLeadsProvider.GetByLeadpk(_leadpk);
					results = new TList<ZohoLeads>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ZohoLeadsSelectMethod.GetByLeadid:
					_leadid_nullable = (System.String) EntityUtil.ChangeType(values["Leadid"], typeof(System.String));
					results = ZohoLeadsProvider.GetByLeadid(_leadid_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == ZohoLeadsSelectMethod.Get || SelectMethod == ZohoLeadsSelectMethod.GetByLeadpk )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				ZohoLeads entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ZohoLeadsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<ZohoLeads> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ZohoLeadsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ZohoLeadsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ZohoLeadsDataSource class.
	/// </summary>
	public class ZohoLeadsDataSourceDesigner : ProviderDataSourceDesigner<ZohoLeads, ZohoLeadsKey>
	{
		/// <summary>
		/// Initializes a new instance of the ZohoLeadsDataSourceDesigner class.
		/// </summary>
		public ZohoLeadsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ZohoLeadsSelectMethod SelectMethod
		{
			get { return ((ZohoLeadsDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new ZohoLeadsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ZohoLeadsDataSourceActionList

	/// <summary>
	/// Supports the ZohoLeadsDataSourceDesigner class.
	/// </summary>
	internal class ZohoLeadsDataSourceActionList : DesignerActionList
	{
		private ZohoLeadsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ZohoLeadsDataSourceActionList(ZohoLeadsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ZohoLeadsSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion ZohoLeadsDataSourceActionList
	
	#endregion ZohoLeadsDataSourceDesigner
	
	#region ZohoLeadsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ZohoLeadsDataSource.SelectMethod property.
	/// </summary>
	public enum ZohoLeadsSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByLeadid method.
		/// </summary>
		GetByLeadid,
		/// <summary>
		/// Represents the GetByLeadpk method.
		/// </summary>
		GetByLeadpk
	}
	
	#endregion ZohoLeadsSelectMethod

	#region ZohoLeadsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoLeadsFilter : SqlFilter<ZohoLeadsColumn>
	{
	}
	
	#endregion ZohoLeadsFilter

	#region ZohoLeadsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoLeadsExpressionBuilder : SqlExpressionBuilder<ZohoLeadsColumn>
	{
	}
	
	#endregion ZohoLeadsExpressionBuilder	

	#region ZohoLeadsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ZohoLeadsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoLeadsProperty : ChildEntityProperty<ZohoLeadsChildEntityTypes>
	{
	}
	
	#endregion ZohoLeadsProperty
}

