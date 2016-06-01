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
	/// Represents the DataRepository.VwManualReturnsListProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwManualReturnsListDataSourceDesigner))]
	public class VwManualReturnsListDataSource : ReadOnlyDataSource<VwManualReturnsList>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualReturnsListDataSource class.
		/// </summary>
		public VwManualReturnsListDataSource() : base(new VwManualReturnsListService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwManualReturnsListDataSourceView used by the VwManualReturnsListDataSource.
		/// </summary>
		protected VwManualReturnsListDataSourceView VwManualReturnsListView
		{
			get { return ( View as VwManualReturnsListDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwManualReturnsListDataSourceView class that is to be
		/// used by the VwManualReturnsListDataSource.
		/// </summary>
		/// <returns>An instance of the VwManualReturnsListDataSourceView class.</returns>
		protected override BaseDataSourceView<VwManualReturnsList, Object> GetNewDataSourceView()
		{
			return new VwManualReturnsListDataSourceView(this, DefaultViewName);
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
	/// Supports the VwManualReturnsListDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwManualReturnsListDataSourceView : ReadOnlyDataSourceView<VwManualReturnsList>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualReturnsListDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwManualReturnsListDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwManualReturnsListDataSourceView(VwManualReturnsListDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwManualReturnsListDataSource VwManualReturnsListOwner
		{
			get { return Owner as VwManualReturnsListDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwManualReturnsListService VwManualReturnsListProvider
		{
			get { return Provider as VwManualReturnsListService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwManualReturnsListDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwManualReturnsListDataSource class.
	/// </summary>
	public class VwManualReturnsListDataSourceDesigner : ReadOnlyDataSourceDesigner<VwManualReturnsList>
	{
	}

	#endregion VwManualReturnsListDataSourceDesigner

	#region VwManualReturnsListFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwManualReturnsList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwManualReturnsListFilter : SqlFilter<VwManualReturnsListColumn>
	{
	}

	#endregion VwManualReturnsListFilter

	#region VwManualReturnsListExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwManualReturnsList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwManualReturnsListExpressionBuilder : SqlExpressionBuilder<VwManualReturnsListColumn>
	{
	}
	
	#endregion VwManualReturnsListExpressionBuilder		
}

