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
	/// Represents the DataRepository.VwCallableLeadsWithCallsAndPeriodsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwCallableLeadsWithCallsAndPeriodsDataSourceDesigner))]
	public class VwCallableLeadsWithCallsAndPeriodsDataSource : ReadOnlyDataSource<VwCallableLeadsWithCallsAndPeriods>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsDataSource class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodsDataSource() : base(new VwCallableLeadsWithCallsAndPeriodsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwCallableLeadsWithCallsAndPeriodsDataSourceView used by the VwCallableLeadsWithCallsAndPeriodsDataSource.
		/// </summary>
		protected VwCallableLeadsWithCallsAndPeriodsDataSourceView VwCallableLeadsWithCallsAndPeriodsView
		{
			get { return ( View as VwCallableLeadsWithCallsAndPeriodsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwCallableLeadsWithCallsAndPeriodsDataSourceView class that is to be
		/// used by the VwCallableLeadsWithCallsAndPeriodsDataSource.
		/// </summary>
		/// <returns>An instance of the VwCallableLeadsWithCallsAndPeriodsDataSourceView class.</returns>
		protected override BaseDataSourceView<VwCallableLeadsWithCallsAndPeriods, Object> GetNewDataSourceView()
		{
			return new VwCallableLeadsWithCallsAndPeriodsDataSourceView(this, DefaultViewName);
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
	/// Supports the VwCallableLeadsWithCallsAndPeriodsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwCallableLeadsWithCallsAndPeriodsDataSourceView : ReadOnlyDataSourceView<VwCallableLeadsWithCallsAndPeriods>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwCallableLeadsWithCallsAndPeriodsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwCallableLeadsWithCallsAndPeriodsDataSourceView(VwCallableLeadsWithCallsAndPeriodsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwCallableLeadsWithCallsAndPeriodsDataSource VwCallableLeadsWithCallsAndPeriodsOwner
		{
			get { return Owner as VwCallableLeadsWithCallsAndPeriodsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwCallableLeadsWithCallsAndPeriodsService VwCallableLeadsWithCallsAndPeriodsProvider
		{
			get { return Provider as VwCallableLeadsWithCallsAndPeriodsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwCallableLeadsWithCallsAndPeriodsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwCallableLeadsWithCallsAndPeriodsDataSource class.
	/// </summary>
	public class VwCallableLeadsWithCallsAndPeriodsDataSourceDesigner : ReadOnlyDataSourceDesigner<VwCallableLeadsWithCallsAndPeriods>
	{
	}

	#endregion VwCallableLeadsWithCallsAndPeriodsDataSourceDesigner

	#region VwCallableLeadsWithCallsAndPeriodsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriods"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodsFilter : SqlFilter<VwCallableLeadsWithCallsAndPeriodsColumn>
	{
	}

	#endregion VwCallableLeadsWithCallsAndPeriodsFilter

	#region VwCallableLeadsWithCallsAndPeriodsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriods"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodsExpressionBuilder : SqlExpressionBuilder<VwCallableLeadsWithCallsAndPeriodsColumn>
	{
	}
	
	#endregion VwCallableLeadsWithCallsAndPeriodsExpressionBuilder		
}

