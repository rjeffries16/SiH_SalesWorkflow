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
	/// Represents the DataRepository.LeadContactedProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LeadContactedDataSourceDesigner))]
	public class LeadContactedDataSource : ProviderDataSource<LeadContacted, LeadContactedKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadContactedDataSource class.
		/// </summary>
		public LeadContactedDataSource() : base(new LeadContactedService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LeadContactedDataSourceView used by the LeadContactedDataSource.
		/// </summary>
		protected LeadContactedDataSourceView LeadContactedView
		{
			get { return ( View as LeadContactedDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LeadContactedDataSource control invokes to retrieve data.
		/// </summary>
		public LeadContactedSelectMethod SelectMethod
		{
			get
			{
				LeadContactedSelectMethod selectMethod = LeadContactedSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LeadContactedSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LeadContactedDataSourceView class that is to be
		/// used by the LeadContactedDataSource.
		/// </summary>
		/// <returns>An instance of the LeadContactedDataSourceView class.</returns>
		protected override BaseDataSourceView<LeadContacted, LeadContactedKey> GetNewDataSourceView()
		{
			return new LeadContactedDataSourceView(this, DefaultViewName);
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
	/// Supports the LeadContactedDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LeadContactedDataSourceView : ProviderDataSourceView<LeadContacted, LeadContactedKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadContactedDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LeadContactedDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LeadContactedDataSourceView(LeadContactedDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LeadContactedDataSource LeadContactedOwner
		{
			get { return Owner as LeadContactedDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LeadContactedSelectMethod SelectMethod
		{
			get { return LeadContactedOwner.SelectMethod; }
			set { LeadContactedOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LeadContactedService LeadContactedProvider
		{
			get { return Provider as LeadContactedService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LeadContacted> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LeadContacted> results = null;
			LeadContacted item;
			count = 0;
			
			System.Int64 _leadContactedPk;

			switch ( SelectMethod )
			{
				case LeadContactedSelectMethod.Get:
					LeadContactedKey entityKey  = new LeadContactedKey();
					entityKey.Load(values);
					item = LeadContactedProvider.Get(entityKey);
					results = new TList<LeadContacted>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LeadContactedSelectMethod.GetAll:
                    results = LeadContactedProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LeadContactedSelectMethod.GetPaged:
					results = LeadContactedProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LeadContactedSelectMethod.Find:
					if ( FilterParameters != null )
						results = LeadContactedProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LeadContactedProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LeadContactedSelectMethod.GetByLeadContactedPk:
					_leadContactedPk = ( values["LeadContactedPk"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["LeadContactedPk"], typeof(System.Int64)) : (long)0;
					item = LeadContactedProvider.GetByLeadContactedPk(_leadContactedPk);
					results = new TList<LeadContacted>();
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
			if ( SelectMethod == LeadContactedSelectMethod.Get || SelectMethod == LeadContactedSelectMethod.GetByLeadContactedPk )
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
				LeadContacted entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LeadContactedProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LeadContacted> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LeadContactedProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LeadContactedDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LeadContactedDataSource class.
	/// </summary>
	public class LeadContactedDataSourceDesigner : ProviderDataSourceDesigner<LeadContacted, LeadContactedKey>
	{
		/// <summary>
		/// Initializes a new instance of the LeadContactedDataSourceDesigner class.
		/// </summary>
		public LeadContactedDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadContactedSelectMethod SelectMethod
		{
			get { return ((LeadContactedDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LeadContactedDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LeadContactedDataSourceActionList

	/// <summary>
	/// Supports the LeadContactedDataSourceDesigner class.
	/// </summary>
	internal class LeadContactedDataSourceActionList : DesignerActionList
	{
		private LeadContactedDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LeadContactedDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LeadContactedDataSourceActionList(LeadContactedDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LeadContactedSelectMethod SelectMethod
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

	#endregion LeadContactedDataSourceActionList
	
	#endregion LeadContactedDataSourceDesigner
	
	#region LeadContactedSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LeadContactedDataSource.SelectMethod property.
	/// </summary>
	public enum LeadContactedSelectMethod
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
		/// Represents the GetByLeadContactedPk method.
		/// </summary>
		GetByLeadContactedPk
	}
	
	#endregion LeadContactedSelectMethod

	#region LeadContactedFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadContacted"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadContactedFilter : SqlFilter<LeadContactedColumn>
	{
	}
	
	#endregion LeadContactedFilter

	#region LeadContactedExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadContacted"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadContactedExpressionBuilder : SqlExpressionBuilder<LeadContactedColumn>
	{
	}
	
	#endregion LeadContactedExpressionBuilder	

	#region LeadContactedProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LeadContactedChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LeadContacted"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadContactedProperty : ChildEntityProperty<LeadContactedChildEntityTypes>
	{
	}
	
	#endregion LeadContactedProperty
}

