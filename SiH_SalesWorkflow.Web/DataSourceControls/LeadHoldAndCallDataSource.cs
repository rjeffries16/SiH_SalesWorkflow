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
	/// Represents the DataRepository.LeadHoldAndCallProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LeadHoldAndCallDataSourceDesigner))]
	public class LeadHoldAndCallDataSource : ProviderDataSource<LeadHoldAndCall, LeadHoldAndCallKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallDataSource class.
		/// </summary>
		public LeadHoldAndCallDataSource() : base(new LeadHoldAndCallService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LeadHoldAndCallDataSourceView used by the LeadHoldAndCallDataSource.
		/// </summary>
		protected LeadHoldAndCallDataSourceView LeadHoldAndCallView
		{
			get { return ( View as LeadHoldAndCallDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LeadHoldAndCallDataSource control invokes to retrieve data.
		/// </summary>
		public LeadHoldAndCallSelectMethod SelectMethod
		{
			get
			{
				LeadHoldAndCallSelectMethod selectMethod = LeadHoldAndCallSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LeadHoldAndCallSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LeadHoldAndCallDataSourceView class that is to be
		/// used by the LeadHoldAndCallDataSource.
		/// </summary>
		/// <returns>An instance of the LeadHoldAndCallDataSourceView class.</returns>
		protected override BaseDataSourceView<LeadHoldAndCall, LeadHoldAndCallKey> GetNewDataSourceView()
		{
			return new LeadHoldAndCallDataSourceView(this, DefaultViewName);
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
	/// Supports the LeadHoldAndCallDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LeadHoldAndCallDataSourceView : ProviderDataSourceView<LeadHoldAndCall, LeadHoldAndCallKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LeadHoldAndCallDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LeadHoldAndCallDataSourceView(LeadHoldAndCallDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LeadHoldAndCallDataSource LeadHoldAndCallOwner
		{
			get { return Owner as LeadHoldAndCallDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LeadHoldAndCallSelectMethod SelectMethod
		{
			get { return LeadHoldAndCallOwner.SelectMethod; }
			set { LeadHoldAndCallOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LeadHoldAndCallService LeadHoldAndCallProvider
		{
			get { return Provider as LeadHoldAndCallService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LeadHoldAndCall> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LeadHoldAndCall> results = null;
			LeadHoldAndCall item;
			count = 0;
			
			System.Int64 _leadHoldAndCallPk;

			switch ( SelectMethod )
			{
				case LeadHoldAndCallSelectMethod.Get:
					LeadHoldAndCallKey entityKey  = new LeadHoldAndCallKey();
					entityKey.Load(values);
					item = LeadHoldAndCallProvider.Get(entityKey);
					results = new TList<LeadHoldAndCall>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LeadHoldAndCallSelectMethod.GetAll:
                    results = LeadHoldAndCallProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LeadHoldAndCallSelectMethod.GetPaged:
					results = LeadHoldAndCallProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LeadHoldAndCallSelectMethod.Find:
					if ( FilterParameters != null )
						results = LeadHoldAndCallProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LeadHoldAndCallProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LeadHoldAndCallSelectMethod.GetByLeadHoldAndCallPk:
					_leadHoldAndCallPk = ( values["LeadHoldAndCallPk"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["LeadHoldAndCallPk"], typeof(System.Int64)) : (long)0;
					item = LeadHoldAndCallProvider.GetByLeadHoldAndCallPk(_leadHoldAndCallPk);
					results = new TList<LeadHoldAndCall>();
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
			if ( SelectMethod == LeadHoldAndCallSelectMethod.Get || SelectMethod == LeadHoldAndCallSelectMethod.GetByLeadHoldAndCallPk )
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
				LeadHoldAndCall entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LeadHoldAndCallProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LeadHoldAndCall> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LeadHoldAndCallProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LeadHoldAndCallDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LeadHoldAndCallDataSource class.
	/// </summary>
	public class LeadHoldAndCallDataSourceDesigner : ProviderDataSourceDesigner<LeadHoldAndCall, LeadHoldAndCallKey>
	{
		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallDataSourceDesigner class.
		/// </summary>
		public LeadHoldAndCallDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadHoldAndCallSelectMethod SelectMethod
		{
			get { return ((LeadHoldAndCallDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LeadHoldAndCallDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LeadHoldAndCallDataSourceActionList

	/// <summary>
	/// Supports the LeadHoldAndCallDataSourceDesigner class.
	/// </summary>
	internal class LeadHoldAndCallDataSourceActionList : DesignerActionList
	{
		private LeadHoldAndCallDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LeadHoldAndCallDataSourceActionList(LeadHoldAndCallDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadHoldAndCallSelectMethod SelectMethod
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

	#endregion LeadHoldAndCallDataSourceActionList
	
	#endregion LeadHoldAndCallDataSourceDesigner
	
	#region LeadHoldAndCallSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LeadHoldAndCallDataSource.SelectMethod property.
	/// </summary>
	public enum LeadHoldAndCallSelectMethod
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
		/// Represents the GetByLeadHoldAndCallPk method.
		/// </summary>
		GetByLeadHoldAndCallPk
	}
	
	#endregion LeadHoldAndCallSelectMethod

	#region LeadHoldAndCallFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadHoldAndCallFilter : SqlFilter<LeadHoldAndCallColumn>
	{
	}
	
	#endregion LeadHoldAndCallFilter

	#region LeadHoldAndCallExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadHoldAndCallExpressionBuilder : SqlExpressionBuilder<LeadHoldAndCallColumn>
	{
	}
	
	#endregion LeadHoldAndCallExpressionBuilder	

	#region LeadHoldAndCallProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LeadHoldAndCallChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadHoldAndCallProperty : ChildEntityProperty<LeadHoldAndCallChildEntityTypes>
	{
	}
	
	#endregion LeadHoldAndCallProperty
}

