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
	/// Represents the DataRepository.VwAllLeadsWithCallsAndPeriodsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwAllLeadsWithCallsAndPeriodsDataSourceDesigner))]
	public class VwAllLeadsWithCallsAndPeriodsDataSource : ReadOnlyDataSource<VwAllLeadsWithCallsAndPeriods>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwAllLeadsWithCallsAndPeriodsDataSource class.
		/// </summary>
		public VwAllLeadsWithCallsAndPeriodsDataSource() : base(new VwAllLeadsWithCallsAndPeriodsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwAllLeadsWithCallsAndPeriodsDataSourceView used by the VwAllLeadsWithCallsAndPeriodsDataSource.
		/// </summary>
		protected VwAllLeadsWithCallsAndPeriodsDataSourceView VwAllLeadsWithCallsAndPeriodsView
		{
			get { return ( View as VwAllLeadsWithCallsAndPeriodsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwAllLeadsWithCallsAndPeriodsDataSourceView class that is to be
		/// used by the VwAllLeadsWithCallsAndPeriodsDataSource.
		/// </summary>
		/// <returns>An instance of the VwAllLeadsWithCallsAndPeriodsDataSourceView class.</returns>
		protected override BaseDataSourceView<VwAllLeadsWithCallsAndPeriods, Object> GetNewDataSourceView()
		{
			return new VwAllLeadsWithCallsAndPeriodsDataSourceView(this, DefaultViewName);
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
	/// Supports the VwAllLeadsWithCallsAndPeriodsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwAllLeadsWithCallsAndPeriodsDataSourceView : ReadOnlyDataSourceView<VwAllLeadsWithCallsAndPeriods>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwAllLeadsWithCallsAndPeriodsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwAllLeadsWithCallsAndPeriodsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwAllLeadsWithCallsAndPeriodsDataSourceView(VwAllLeadsWithCallsAndPeriodsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwAllLeadsWithCallsAndPeriodsDataSource VwAllLeadsWithCallsAndPeriodsOwner
		{
			get { return Owner as VwAllLeadsWithCallsAndPeriodsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwAllLeadsWithCallsAndPeriodsService VwAllLeadsWithCallsAndPeriodsProvider
		{
			get { return Provider as VwAllLeadsWithCallsAndPeriodsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwAllLeadsWithCallsAndPeriodsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwAllLeadsWithCallsAndPeriodsDataSource class.
	/// </summary>
	public class VwAllLeadsWithCallsAndPeriodsDataSourceDesigner : ReadOnlyDataSourceDesigner<VwAllLeadsWithCallsAndPeriods>
	{
	}

	#endregion VwAllLeadsWithCallsAndPeriodsDataSourceDesigner

	#region VwAllLeadsWithCallsAndPeriodsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwAllLeadsWithCallsAndPeriods"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwAllLeadsWithCallsAndPeriodsFilter : SqlFilter<VwAllLeadsWithCallsAndPeriodsColumn>
	{
	}

	#endregion VwAllLeadsWithCallsAndPeriodsFilter

	#region VwAllLeadsWithCallsAndPeriodsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwAllLeadsWithCallsAndPeriods"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwAllLeadsWithCallsAndPeriodsExpressionBuilder : SqlExpressionBuilder<VwAllLeadsWithCallsAndPeriodsColumn>
	{
	}
	
	#endregion VwAllLeadsWithCallsAndPeriodsExpressionBuilder		
}

