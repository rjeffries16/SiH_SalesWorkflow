﻿#region Using Directives
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
	/// Represents the DataRepository.VwBaseLeadGetLessThanThreeCallsInPeriodProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceDesigner))]
	public class VwBaseLeadGetLessThanThreeCallsInPeriodDataSource : ReadOnlyDataSource<VwBaseLeadGetLessThanThreeCallsInPeriod>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanThreeCallsInPeriodDataSource class.
		/// </summary>
		public VwBaseLeadGetLessThanThreeCallsInPeriodDataSource() : base(new VwBaseLeadGetLessThanThreeCallsInPeriodService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceView used by the VwBaseLeadGetLessThanThreeCallsInPeriodDataSource.
		/// </summary>
		protected VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceView VwBaseLeadGetLessThanThreeCallsInPeriodView
		{
			get { return ( View as VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceView class that is to be
		/// used by the VwBaseLeadGetLessThanThreeCallsInPeriodDataSource.
		/// </summary>
		/// <returns>An instance of the VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceView class.</returns>
		protected override BaseDataSourceView<VwBaseLeadGetLessThanThreeCallsInPeriod, Object> GetNewDataSourceView()
		{
			return new VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceView(this, DefaultViewName);
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
	/// Supports the VwBaseLeadGetLessThanThreeCallsInPeriodDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceView : ReadOnlyDataSourceView<VwBaseLeadGetLessThanThreeCallsInPeriod>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwBaseLeadGetLessThanThreeCallsInPeriodDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceView(VwBaseLeadGetLessThanThreeCallsInPeriodDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwBaseLeadGetLessThanThreeCallsInPeriodDataSource VwBaseLeadGetLessThanThreeCallsInPeriodOwner
		{
			get { return Owner as VwBaseLeadGetLessThanThreeCallsInPeriodDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwBaseLeadGetLessThanThreeCallsInPeriodService VwBaseLeadGetLessThanThreeCallsInPeriodProvider
		{
			get { return Provider as VwBaseLeadGetLessThanThreeCallsInPeriodService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwBaseLeadGetLessThanThreeCallsInPeriodDataSource class.
	/// </summary>
	public class VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceDesigner : ReadOnlyDataSourceDesigner<VwBaseLeadGetLessThanThreeCallsInPeriod>
	{
	}

	#endregion VwBaseLeadGetLessThanThreeCallsInPeriodDataSourceDesigner

	#region VwBaseLeadGetLessThanThreeCallsInPeriodFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetLessThanThreeCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetLessThanThreeCallsInPeriodFilter : SqlFilter<VwBaseLeadGetLessThanThreeCallsInPeriodColumn>
	{
	}

	#endregion VwBaseLeadGetLessThanThreeCallsInPeriodFilter

	#region VwBaseLeadGetLessThanThreeCallsInPeriodExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetLessThanThreeCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetLessThanThreeCallsInPeriodExpressionBuilder : SqlExpressionBuilder<VwBaseLeadGetLessThanThreeCallsInPeriodColumn>
	{
	}
	
	#endregion VwBaseLeadGetLessThanThreeCallsInPeriodExpressionBuilder		
}

