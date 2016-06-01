#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Data;
using SiH_SalesWorkflow.Data.Bases;
using SiH_SalesWorkflow;
#endregion

namespace SiH_SalesWorkflow.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.ZohoCallsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ZohoCallsDataSourceDesigner))]
	public class ZohoCallsDataSource : ProviderDataSource<ZohoCalls, ZohoCallsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoCallsDataSource class.
		/// </summary>
		public ZohoCallsDataSource() : base(new ZohoCallsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ZohoCallsDataSourceView used by the ZohoCallsDataSource.
		/// </summary>
		protected ZohoCallsDataSourceView ZohoCallsView
		{
			get { return ( View as ZohoCallsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ZohoCallsDataSource control invokes to retrieve data.
		/// </summary>
		public ZohoCallsSelectMethod SelectMethod
		{
			get
			{
				ZohoCallsSelectMethod selectMethod = ZohoCallsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ZohoCallsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ZohoCallsDataSourceView class that is to be
		/// used by the ZohoCallsDataSource.
		/// </summary>
		/// <returns>An instance of the ZohoCallsDataSourceView class.</returns>
		protected override BaseDataSourceView<ZohoCalls, ZohoCallsKey> GetNewDataSourceView()
		{
			return new ZohoCallsDataSourceView(this, DefaultViewName);
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
	/// Supports the ZohoCallsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ZohoCallsDataSourceView : ProviderDataSourceView<ZohoCalls, ZohoCallsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoCallsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ZohoCallsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ZohoCallsDataSourceView(ZohoCallsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ZohoCallsDataSource ZohoCallsOwner
		{
			get { return Owner as ZohoCallsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ZohoCallsSelectMethod SelectMethod
		{
			get { return ZohoCallsOwner.SelectMethod; }
			set { ZohoCallsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ZohoCallsService ZohoCallsProvider
		{
			get { return Provider as ZohoCallsService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ZohoCalls> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ZohoCalls> results = null;
			ZohoCalls item;
			count = 0;
			
			System.Int64 _callPk;
			System.String _leadid_nullable;

			switch ( SelectMethod )
			{
				case ZohoCallsSelectMethod.Get:
					ZohoCallsKey entityKey  = new ZohoCallsKey();
					entityKey.Load(values);
					item = ZohoCallsProvider.Get(entityKey);
					results = new TList<ZohoCalls>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ZohoCallsSelectMethod.GetAll:
                    results = ZohoCallsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ZohoCallsSelectMethod.GetPaged:
					results = ZohoCallsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ZohoCallsSelectMethod.Find:
					if ( FilterParameters != null )
						results = ZohoCallsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ZohoCallsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ZohoCallsSelectMethod.GetByCallPk:
					_callPk = ( values["CallPk"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["CallPk"], typeof(System.Int64)) : (long)0;
					item = ZohoCallsProvider.GetByCallPk(_callPk);
					results = new TList<ZohoCalls>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ZohoCallsSelectMethod.GetByLeadid:
					_leadid_nullable = (System.String) EntityUtil.ChangeType(values["Leadid"], typeof(System.String));
					results = ZohoCallsProvider.GetByLeadid(_leadid_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ZohoCallsSelectMethod.Get || SelectMethod == ZohoCallsSelectMethod.GetByCallPk )
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
				ZohoCalls entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ZohoCallsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ZohoCalls> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ZohoCallsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ZohoCallsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ZohoCallsDataSource class.
	/// </summary>
	public class ZohoCallsDataSourceDesigner : ProviderDataSourceDesigner<ZohoCalls, ZohoCallsKey>
	{
		/// <summary>
		/// Initializes a new instance of the ZohoCallsDataSourceDesigner class.
		/// </summary>
		public ZohoCallsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ZohoCallsSelectMethod SelectMethod
		{
			get { return ((ZohoCallsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ZohoCallsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ZohoCallsDataSourceActionList

	/// <summary>
	/// Supports the ZohoCallsDataSourceDesigner class.
	/// </summary>
	internal class ZohoCallsDataSourceActionList : DesignerActionList
	{
		private ZohoCallsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ZohoCallsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ZohoCallsDataSourceActionList(ZohoCallsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ZohoCallsSelectMethod SelectMethod
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

	#endregion ZohoCallsDataSourceActionList
	
	#endregion ZohoCallsDataSourceDesigner
	
	#region ZohoCallsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ZohoCallsDataSource.SelectMethod property.
	/// </summary>
	public enum ZohoCallsSelectMethod
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
		/// Represents the GetByCallPk method.
		/// </summary>
		GetByCallPk,
		/// <summary>
		/// Represents the GetByLeadid method.
		/// </summary>
		GetByLeadid
	}
	
	#endregion ZohoCallsSelectMethod

	#region ZohoCallsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoCallsFilter : SqlFilter<ZohoCallsColumn>
	{
	}
	
	#endregion ZohoCallsFilter

	#region ZohoCallsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoCallsExpressionBuilder : SqlExpressionBuilder<ZohoCallsColumn>
	{
	}
	
	#endregion ZohoCallsExpressionBuilder	

	#region ZohoCallsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ZohoCallsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoCallsProperty : ChildEntityProperty<ZohoCallsChildEntityTypes>
	{
	}
	
	#endregion ZohoCallsProperty
}

