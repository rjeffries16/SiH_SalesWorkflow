#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Data;
using SiH_SalesWorkflow.Data.Bases;
using SiH_SalesWorkflow;
#endregion

namespace SiH_SalesWorkflow.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.VwManualSalesListProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwManualSalesListDataSourceDesigner))]
	public class VwManualSalesListDataSource : ReadOnlyDataSource<VwManualSalesList>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListDataSource class.
		/// </summary>
		public VwManualSalesListDataSource() : base(new VwManualSalesListService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwManualSalesListDataSourceView used by the VwManualSalesListDataSource.
		/// </summary>
		protected VwManualSalesListDataSourceView VwManualSalesListView
		{
			get { return ( View as VwManualSalesListDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwManualSalesListDataSourceView class that is to be
		/// used by the VwManualSalesListDataSource.
		/// </summary>
		/// <returns>An instance of the VwManualSalesListDataSourceView class.</returns>
		protected override BaseDataSourceView<VwManualSalesList, Object> GetNewDataSourceView()
		{
			return new VwManualSalesListDataSourceView(this, DefaultViewName);
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
	/// Supports the VwManualSalesListDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwManualSalesListDataSourceView : ReadOnlyDataSourceView<VwManualSalesList>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwManualSalesListDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwManualSalesListDataSourceView(VwManualSalesListDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwManualSalesListDataSource VwManualSalesListOwner
		{
			get { return Owner as VwManualSalesListDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwManualSalesListService VwManualSalesListProvider
		{
			get { return Provider as VwManualSalesListService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwManualSalesListDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwManualSalesListDataSource class.
	/// </summary>
	public class VwManualSalesListDataSourceDesigner : ReadOnlyDataSourceDesigner<VwManualSalesList>
	{
	}

	#endregion VwManualSalesListDataSourceDesigner

	#region VwManualSalesListFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwManualSalesList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwManualSalesListFilter : SqlFilter<VwManualSalesListColumn>
	{
	}

	#endregion VwManualSalesListFilter

	#region VwManualSalesListExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwManualSalesList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwManualSalesListExpressionBuilder : SqlExpressionBuilder<VwManualSalesListColumn>
	{
	}
	
	#endregion VwManualSalesListExpressionBuilder		
}

