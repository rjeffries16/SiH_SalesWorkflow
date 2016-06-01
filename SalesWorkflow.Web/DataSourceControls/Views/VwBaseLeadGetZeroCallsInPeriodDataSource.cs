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
	/// Represents the DataRepository.VwBaseLeadGetZeroCallsInPeriodProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwBaseLeadGetZeroCallsInPeriodDataSourceDesigner))]
	public class VwBaseLeadGetZeroCallsInPeriodDataSource : ReadOnlyDataSource<VwBaseLeadGetZeroCallsInPeriod>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetZeroCallsInPeriodDataSource class.
		/// </summary>
		public VwBaseLeadGetZeroCallsInPeriodDataSource() : base(new VwBaseLeadGetZeroCallsInPeriodService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwBaseLeadGetZeroCallsInPeriodDataSourceView used by the VwBaseLeadGetZeroCallsInPeriodDataSource.
		/// </summary>
		protected VwBaseLeadGetZeroCallsInPeriodDataSourceView VwBaseLeadGetZeroCallsInPeriodView
		{
			get { return ( View as VwBaseLeadGetZeroCallsInPeriodDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwBaseLeadGetZeroCallsInPeriodDataSourceView class that is to be
		/// used by the VwBaseLeadGetZeroCallsInPeriodDataSource.
		/// </summary>
		/// <returns>An instance of the VwBaseLeadGetZeroCallsInPeriodDataSourceView class.</returns>
		protected override BaseDataSourceView<VwBaseLeadGetZeroCallsInPeriod, Object> GetNewDataSourceView()
		{
			return new VwBaseLeadGetZeroCallsInPeriodDataSourceView(this, DefaultViewName);
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
	/// Supports the VwBaseLeadGetZeroCallsInPeriodDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwBaseLeadGetZeroCallsInPeriodDataSourceView : ReadOnlyDataSourceView<VwBaseLeadGetZeroCallsInPeriod>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetZeroCallsInPeriodDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwBaseLeadGetZeroCallsInPeriodDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwBaseLeadGetZeroCallsInPeriodDataSourceView(VwBaseLeadGetZeroCallsInPeriodDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwBaseLeadGetZeroCallsInPeriodDataSource VwBaseLeadGetZeroCallsInPeriodOwner
		{
			get { return Owner as VwBaseLeadGetZeroCallsInPeriodDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwBaseLeadGetZeroCallsInPeriodService VwBaseLeadGetZeroCallsInPeriodProvider
		{
			get { return Provider as VwBaseLeadGetZeroCallsInPeriodService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwBaseLeadGetZeroCallsInPeriodDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwBaseLeadGetZeroCallsInPeriodDataSource class.
	/// </summary>
	public class VwBaseLeadGetZeroCallsInPeriodDataSourceDesigner : ReadOnlyDataSourceDesigner<VwBaseLeadGetZeroCallsInPeriod>
	{
	}

	#endregion VwBaseLeadGetZeroCallsInPeriodDataSourceDesigner

	#region VwBaseLeadGetZeroCallsInPeriodFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetZeroCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetZeroCallsInPeriodFilter : SqlFilter<VwBaseLeadGetZeroCallsInPeriodColumn>
	{
	}

	#endregion VwBaseLeadGetZeroCallsInPeriodFilter

	#region VwBaseLeadGetZeroCallsInPeriodExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetZeroCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetZeroCallsInPeriodExpressionBuilder : SqlExpressionBuilder<VwBaseLeadGetZeroCallsInPeriodColumn>
	{
	}
	
	#endregion VwBaseLeadGetZeroCallsInPeriodExpressionBuilder		
}

