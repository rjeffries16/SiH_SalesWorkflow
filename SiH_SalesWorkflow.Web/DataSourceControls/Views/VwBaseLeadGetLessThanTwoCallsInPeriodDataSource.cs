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
	/// Represents the DataRepository.VwBaseLeadGetLessThanTwoCallsInPeriodProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceDesigner))]
	public class VwBaseLeadGetLessThanTwoCallsInPeriodDataSource : ReadOnlyDataSource<VwBaseLeadGetLessThanTwoCallsInPeriod>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanTwoCallsInPeriodDataSource class.
		/// </summary>
		public VwBaseLeadGetLessThanTwoCallsInPeriodDataSource() : base(new VwBaseLeadGetLessThanTwoCallsInPeriodService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceView used by the VwBaseLeadGetLessThanTwoCallsInPeriodDataSource.
		/// </summary>
		protected VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceView VwBaseLeadGetLessThanTwoCallsInPeriodView
		{
			get { return ( View as VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceView class that is to be
		/// used by the VwBaseLeadGetLessThanTwoCallsInPeriodDataSource.
		/// </summary>
		/// <returns>An instance of the VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceView class.</returns>
		protected override BaseDataSourceView<VwBaseLeadGetLessThanTwoCallsInPeriod, Object> GetNewDataSourceView()
		{
			return new VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceView(this, DefaultViewName);
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
	/// Supports the VwBaseLeadGetLessThanTwoCallsInPeriodDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceView : ReadOnlyDataSourceView<VwBaseLeadGetLessThanTwoCallsInPeriod>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwBaseLeadGetLessThanTwoCallsInPeriodDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceView(VwBaseLeadGetLessThanTwoCallsInPeriodDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwBaseLeadGetLessThanTwoCallsInPeriodDataSource VwBaseLeadGetLessThanTwoCallsInPeriodOwner
		{
			get { return Owner as VwBaseLeadGetLessThanTwoCallsInPeriodDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwBaseLeadGetLessThanTwoCallsInPeriodService VwBaseLeadGetLessThanTwoCallsInPeriodProvider
		{
			get { return Provider as VwBaseLeadGetLessThanTwoCallsInPeriodService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwBaseLeadGetLessThanTwoCallsInPeriodDataSource class.
	/// </summary>
	public class VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceDesigner : ReadOnlyDataSourceDesigner<VwBaseLeadGetLessThanTwoCallsInPeriod>
	{
	}

	#endregion VwBaseLeadGetLessThanTwoCallsInPeriodDataSourceDesigner

	#region VwBaseLeadGetLessThanTwoCallsInPeriodFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetLessThanTwoCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetLessThanTwoCallsInPeriodFilter : SqlFilter<VwBaseLeadGetLessThanTwoCallsInPeriodColumn>
	{
	}

	#endregion VwBaseLeadGetLessThanTwoCallsInPeriodFilter

	#region VwBaseLeadGetLessThanTwoCallsInPeriodExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetLessThanTwoCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetLessThanTwoCallsInPeriodExpressionBuilder : SqlExpressionBuilder<VwBaseLeadGetLessThanTwoCallsInPeriodColumn>
	{
	}
	
	#endregion VwBaseLeadGetLessThanTwoCallsInPeriodExpressionBuilder		
}

