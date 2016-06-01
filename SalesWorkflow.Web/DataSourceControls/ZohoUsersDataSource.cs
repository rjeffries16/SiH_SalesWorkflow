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
	/// Represents the DataRepository.ZohoUsersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ZohoUsersDataSourceDesigner))]
	public class ZohoUsersDataSource : ProviderDataSource<ZohoUsers, ZohoUsersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoUsersDataSource class.
		/// </summary>
		public ZohoUsersDataSource() : base(new ZohoUsersService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ZohoUsersDataSourceView used by the ZohoUsersDataSource.
		/// </summary>
		protected ZohoUsersDataSourceView ZohoUsersView
		{
			get { return ( View as ZohoUsersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ZohoUsersDataSource control invokes to retrieve data.
		/// </summary>
		public ZohoUsersSelectMethod SelectMethod
		{
			get
			{
				ZohoUsersSelectMethod selectMethod = ZohoUsersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ZohoUsersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ZohoUsersDataSourceView class that is to be
		/// used by the ZohoUsersDataSource.
		/// </summary>
		/// <returns>An instance of the ZohoUsersDataSourceView class.</returns>
		protected override BaseDataSourceView<ZohoUsers, ZohoUsersKey> GetNewDataSourceView()
		{
			return new ZohoUsersDataSourceView(this, DefaultViewName);
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
	/// Supports the ZohoUsersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ZohoUsersDataSourceView : ProviderDataSourceView<ZohoUsers, ZohoUsersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoUsersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ZohoUsersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ZohoUsersDataSourceView(ZohoUsersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ZohoUsersDataSource ZohoUsersOwner
		{
			get { return Owner as ZohoUsersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ZohoUsersSelectMethod SelectMethod
		{
			get { return ZohoUsersOwner.SelectMethod; }
			set { ZohoUsersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ZohoUsersService ZohoUsersProvider
		{
			get { return Provider as ZohoUsersService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ZohoUsers> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ZohoUsers> results = null;
			ZohoUsers item;
			count = 0;
			
			System.Int64 _userpk;

			switch ( SelectMethod )
			{
				case ZohoUsersSelectMethod.Get:
					ZohoUsersKey entityKey  = new ZohoUsersKey();
					entityKey.Load(values);
					item = ZohoUsersProvider.Get(entityKey);
					results = new TList<ZohoUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ZohoUsersSelectMethod.GetAll:
                    results = ZohoUsersProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ZohoUsersSelectMethod.GetPaged:
					results = ZohoUsersProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ZohoUsersSelectMethod.Find:
					if ( FilterParameters != null )
						results = ZohoUsersProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ZohoUsersProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ZohoUsersSelectMethod.GetByUserpk:
					_userpk = ( values["Userpk"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["Userpk"], typeof(System.Int64)) : (long)0;
					item = ZohoUsersProvider.GetByUserpk(_userpk);
					results = new TList<ZohoUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
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
			if ( SelectMethod == ZohoUsersSelectMethod.Get || SelectMethod == ZohoUsersSelectMethod.GetByUserpk )
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
				ZohoUsers entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ZohoUsersProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ZohoUsers> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ZohoUsersProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ZohoUsersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ZohoUsersDataSource class.
	/// </summary>
	public class ZohoUsersDataSourceDesigner : ProviderDataSourceDesigner<ZohoUsers, ZohoUsersKey>
	{
		/// <summary>
		/// Initializes a new instance of the ZohoUsersDataSourceDesigner class.
		/// </summary>
		public ZohoUsersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ZohoUsersSelectMethod SelectMethod
		{
			get { return ((ZohoUsersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ZohoUsersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ZohoUsersDataSourceActionList

	/// <summary>
	/// Supports the ZohoUsersDataSourceDesigner class.
	/// </summary>
	internal class ZohoUsersDataSourceActionList : DesignerActionList
	{
		private ZohoUsersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ZohoUsersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ZohoUsersDataSourceActionList(ZohoUsersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ZohoUsersSelectMethod SelectMethod
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

	#endregion ZohoUsersDataSourceActionList
	
	#endregion ZohoUsersDataSourceDesigner
	
	#region ZohoUsersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ZohoUsersDataSource.SelectMethod property.
	/// </summary>
	public enum ZohoUsersSelectMethod
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
		/// Represents the GetByUserpk method.
		/// </summary>
		GetByUserpk
	}
	
	#endregion ZohoUsersSelectMethod

	#region ZohoUsersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoUsersFilter : SqlFilter<ZohoUsersColumn>
	{
	}
	
	#endregion ZohoUsersFilter

	#region ZohoUsersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoUsersExpressionBuilder : SqlExpressionBuilder<ZohoUsersColumn>
	{
	}
	
	#endregion ZohoUsersExpressionBuilder	

	#region ZohoUsersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ZohoUsersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoUsersProperty : ChildEntityProperty<ZohoUsersChildEntityTypes>
	{
	}
	
	#endregion ZohoUsersProperty
}

