#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using SalesWorkflow.Entities;
using SalesWorkflow.Data;
using SalesWorkflow.Data.Bases;
using SalesWorkflow;
#endregion

namespace SalesWorkflow.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.VwSalesStatsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwSalesStatsDataSourceDesigner))]
	public class VwSalesStatsDataSource : ReadOnlyDataSource<VwSalesStats>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsDataSource class.
		/// </summary>
		public VwSalesStatsDataSource() : base(new VwSalesStatsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwSalesStatsDataSourceView used by the VwSalesStatsDataSource.
		/// </summary>
		protected VwSalesStatsDataSourceView VwSalesStatsView
		{
			get { return ( View as VwSalesStatsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwSalesStatsDataSourceView class that is to be
		/// used by the VwSalesStatsDataSource.
		/// </summary>
		/// <returns>An instance of the VwSalesStatsDataSourceView class.</returns>
		protected override BaseDataSourceView<VwSalesStats, Object> GetNewDataSourceView()
		{
			return new VwSalesStatsDataSourceView(this, DefaultViewName);
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
	/// Supports the VwSalesStatsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwSalesStatsDataSourceView : ReadOnlyDataSourceView<VwSalesStats>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwSalesStatsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwSalesStatsDataSourceView(VwSalesStatsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwSalesStatsDataSource VwSalesStatsOwner
		{
			get { return Owner as VwSalesStatsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwSalesStatsService VwSalesStatsProvider
		{
			get { return Provider as VwSalesStatsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwSalesStatsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwSalesStatsDataSource class.
	/// </summary>
	public class VwSalesStatsDataSourceDesigner : ReadOnlyDataSourceDesigner<VwSalesStats>
	{
	}

	#endregion VwSalesStatsDataSourceDesigner

	#region VwSalesStatsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwSalesStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwSalesStatsFilter : SqlFilter<VwSalesStatsColumn>
	{
	}

	#endregion VwSalesStatsFilter

	#region VwSalesStatsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwSalesStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwSalesStatsExpressionBuilder : SqlExpressionBuilder<VwSalesStatsColumn>
	{
	}
	
	#endregion VwSalesStatsExpressionBuilder		
}

