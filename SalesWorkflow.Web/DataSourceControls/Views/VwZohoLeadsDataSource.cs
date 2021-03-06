﻿#region Using Directives
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
	/// Represents the DataRepository.VwZohoLeadsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwZohoLeadsDataSourceDesigner))]
	public class VwZohoLeadsDataSource : ReadOnlyDataSource<VwZohoLeads>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsDataSource class.
		/// </summary>
		public VwZohoLeadsDataSource() : base(new VwZohoLeadsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwZohoLeadsDataSourceView used by the VwZohoLeadsDataSource.
		/// </summary>
		protected VwZohoLeadsDataSourceView VwZohoLeadsView
		{
			get { return ( View as VwZohoLeadsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwZohoLeadsDataSourceView class that is to be
		/// used by the VwZohoLeadsDataSource.
		/// </summary>
		/// <returns>An instance of the VwZohoLeadsDataSourceView class.</returns>
		protected override BaseDataSourceView<VwZohoLeads, Object> GetNewDataSourceView()
		{
			return new VwZohoLeadsDataSourceView(this, DefaultViewName);
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
	/// Supports the VwZohoLeadsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwZohoLeadsDataSourceView : ReadOnlyDataSourceView<VwZohoLeads>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwZohoLeadsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwZohoLeadsDataSourceView(VwZohoLeadsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwZohoLeadsDataSource VwZohoLeadsOwner
		{
			get { return Owner as VwZohoLeadsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwZohoLeadsService VwZohoLeadsProvider
		{
			get { return Provider as VwZohoLeadsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwZohoLeadsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwZohoLeadsDataSource class.
	/// </summary>
	public class VwZohoLeadsDataSourceDesigner : ReadOnlyDataSourceDesigner<VwZohoLeads>
	{
	}

	#endregion VwZohoLeadsDataSourceDesigner

	#region VwZohoLeadsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsFilter : SqlFilter<VwZohoLeadsColumn>
	{
	}

	#endregion VwZohoLeadsFilter

	#region VwZohoLeadsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsExpressionBuilder : SqlExpressionBuilder<VwZohoLeadsColumn>
	{
	}
	
	#endregion VwZohoLeadsExpressionBuilder		
}

