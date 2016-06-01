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
	/// Represents the DataRepository.VwReportingLeadsAndSalesBoardProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwReportingLeadsAndSalesBoardDataSourceDesigner))]
	public class VwReportingLeadsAndSalesBoardDataSource : ReadOnlyDataSource<VwReportingLeadsAndSalesBoard>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardDataSource class.
		/// </summary>
		public VwReportingLeadsAndSalesBoardDataSource() : base(new VwReportingLeadsAndSalesBoardService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwReportingLeadsAndSalesBoardDataSourceView used by the VwReportingLeadsAndSalesBoardDataSource.
		/// </summary>
		protected VwReportingLeadsAndSalesBoardDataSourceView VwReportingLeadsAndSalesBoardView
		{
			get { return ( View as VwReportingLeadsAndSalesBoardDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwReportingLeadsAndSalesBoardDataSourceView class that is to be
		/// used by the VwReportingLeadsAndSalesBoardDataSource.
		/// </summary>
		/// <returns>An instance of the VwReportingLeadsAndSalesBoardDataSourceView class.</returns>
		protected override BaseDataSourceView<VwReportingLeadsAndSalesBoard, Object> GetNewDataSourceView()
		{
			return new VwReportingLeadsAndSalesBoardDataSourceView(this, DefaultViewName);
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
	/// Supports the VwReportingLeadsAndSalesBoardDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwReportingLeadsAndSalesBoardDataSourceView : ReadOnlyDataSourceView<VwReportingLeadsAndSalesBoard>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwReportingLeadsAndSalesBoardDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwReportingLeadsAndSalesBoardDataSourceView(VwReportingLeadsAndSalesBoardDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwReportingLeadsAndSalesBoardDataSource VwReportingLeadsAndSalesBoardOwner
		{
			get { return Owner as VwReportingLeadsAndSalesBoardDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwReportingLeadsAndSalesBoardService VwReportingLeadsAndSalesBoardProvider
		{
			get { return Provider as VwReportingLeadsAndSalesBoardService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwReportingLeadsAndSalesBoardDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwReportingLeadsAndSalesBoardDataSource class.
	/// </summary>
	public class VwReportingLeadsAndSalesBoardDataSourceDesigner : ReadOnlyDataSourceDesigner<VwReportingLeadsAndSalesBoard>
	{
	}

	#endregion VwReportingLeadsAndSalesBoardDataSourceDesigner

	#region VwReportingLeadsAndSalesBoardFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingLeadsAndSalesBoard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingLeadsAndSalesBoardFilter : SqlFilter<VwReportingLeadsAndSalesBoardColumn>
	{
	}

	#endregion VwReportingLeadsAndSalesBoardFilter

	#region VwReportingLeadsAndSalesBoardExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingLeadsAndSalesBoard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingLeadsAndSalesBoardExpressionBuilder : SqlExpressionBuilder<VwReportingLeadsAndSalesBoardColumn>
	{
	}
	
	#endregion VwReportingLeadsAndSalesBoardExpressionBuilder		
}

