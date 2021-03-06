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
	/// Represents the DataRepository.VwLeadCallCountsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadCallCountsDataSourceDesigner))]
	public class VwLeadCallCountsDataSource : ReadOnlyDataSource<VwLeadCallCounts>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsDataSource class.
		/// </summary>
		public VwLeadCallCountsDataSource() : base(new VwLeadCallCountsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadCallCountsDataSourceView used by the VwLeadCallCountsDataSource.
		/// </summary>
		protected VwLeadCallCountsDataSourceView VwLeadCallCountsView
		{
			get { return ( View as VwLeadCallCountsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadCallCountsDataSourceView class that is to be
		/// used by the VwLeadCallCountsDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadCallCountsDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadCallCounts, Object> GetNewDataSourceView()
		{
			return new VwLeadCallCountsDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadCallCountsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadCallCountsDataSourceView : ReadOnlyDataSourceView<VwLeadCallCounts>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadCallCountsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadCallCountsDataSourceView(VwLeadCallCountsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadCallCountsDataSource VwLeadCallCountsOwner
		{
			get { return Owner as VwLeadCallCountsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadCallCountsService VwLeadCallCountsProvider
		{
			get { return Provider as VwLeadCallCountsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadCallCountsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadCallCountsDataSource class.
	/// </summary>
	public class VwLeadCallCountsDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadCallCounts>
	{
	}

	#endregion VwLeadCallCountsDataSourceDesigner

	#region VwLeadCallCountsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadCallCounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadCallCountsFilter : SqlFilter<VwLeadCallCountsColumn>
	{
	}

	#endregion VwLeadCallCountsFilter

	#region VwLeadCallCountsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadCallCounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadCallCountsExpressionBuilder : SqlExpressionBuilder<VwLeadCallCountsColumn>
	{
	}
	
	#endregion VwLeadCallCountsExpressionBuilder		
}

