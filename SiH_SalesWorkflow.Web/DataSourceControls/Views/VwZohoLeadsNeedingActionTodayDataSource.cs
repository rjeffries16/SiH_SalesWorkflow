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
	/// Represents the DataRepository.VwZohoLeadsNeedingActionTodayProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwZohoLeadsNeedingActionTodayDataSourceDesigner))]
	public class VwZohoLeadsNeedingActionTodayDataSource : ReadOnlyDataSource<VwZohoLeadsNeedingActionToday>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsNeedingActionTodayDataSource class.
		/// </summary>
		public VwZohoLeadsNeedingActionTodayDataSource() : base(new VwZohoLeadsNeedingActionTodayService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwZohoLeadsNeedingActionTodayDataSourceView used by the VwZohoLeadsNeedingActionTodayDataSource.
		/// </summary>
		protected VwZohoLeadsNeedingActionTodayDataSourceView VwZohoLeadsNeedingActionTodayView
		{
			get { return ( View as VwZohoLeadsNeedingActionTodayDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwZohoLeadsNeedingActionTodayDataSourceView class that is to be
		/// used by the VwZohoLeadsNeedingActionTodayDataSource.
		/// </summary>
		/// <returns>An instance of the VwZohoLeadsNeedingActionTodayDataSourceView class.</returns>
		protected override BaseDataSourceView<VwZohoLeadsNeedingActionToday, Object> GetNewDataSourceView()
		{
			return new VwZohoLeadsNeedingActionTodayDataSourceView(this, DefaultViewName);
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
	/// Supports the VwZohoLeadsNeedingActionTodayDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwZohoLeadsNeedingActionTodayDataSourceView : ReadOnlyDataSourceView<VwZohoLeadsNeedingActionToday>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsNeedingActionTodayDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwZohoLeadsNeedingActionTodayDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwZohoLeadsNeedingActionTodayDataSourceView(VwZohoLeadsNeedingActionTodayDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwZohoLeadsNeedingActionTodayDataSource VwZohoLeadsNeedingActionTodayOwner
		{
			get { return Owner as VwZohoLeadsNeedingActionTodayDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwZohoLeadsNeedingActionTodayService VwZohoLeadsNeedingActionTodayProvider
		{
			get { return Provider as VwZohoLeadsNeedingActionTodayService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwZohoLeadsNeedingActionTodayDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwZohoLeadsNeedingActionTodayDataSource class.
	/// </summary>
	public class VwZohoLeadsNeedingActionTodayDataSourceDesigner : ReadOnlyDataSourceDesigner<VwZohoLeadsNeedingActionToday>
	{
	}

	#endregion VwZohoLeadsNeedingActionTodayDataSourceDesigner

	#region VwZohoLeadsNeedingActionTodayFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsNeedingActionToday"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsNeedingActionTodayFilter : SqlFilter<VwZohoLeadsNeedingActionTodayColumn>
	{
	}

	#endregion VwZohoLeadsNeedingActionTodayFilter

	#region VwZohoLeadsNeedingActionTodayExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsNeedingActionToday"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsNeedingActionTodayExpressionBuilder : SqlExpressionBuilder<VwZohoLeadsNeedingActionTodayColumn>
	{
	}
	
	#endregion VwZohoLeadsNeedingActionTodayExpressionBuilder		
}

