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
	/// Represents the DataRepository.VwBaseLeadGetWithNoActivityInNdaysProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwBaseLeadGetWithNoActivityInNdaysDataSourceDesigner))]
	public class VwBaseLeadGetWithNoActivityInNdaysDataSource : ReadOnlyDataSource<VwBaseLeadGetWithNoActivityInNdays>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityInNdaysDataSource class.
		/// </summary>
		public VwBaseLeadGetWithNoActivityInNdaysDataSource() : base(new VwBaseLeadGetWithNoActivityInNdaysService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwBaseLeadGetWithNoActivityInNdaysDataSourceView used by the VwBaseLeadGetWithNoActivityInNdaysDataSource.
		/// </summary>
		protected VwBaseLeadGetWithNoActivityInNdaysDataSourceView VwBaseLeadGetWithNoActivityInNdaysView
		{
			get { return ( View as VwBaseLeadGetWithNoActivityInNdaysDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwBaseLeadGetWithNoActivityInNdaysDataSourceView class that is to be
		/// used by the VwBaseLeadGetWithNoActivityInNdaysDataSource.
		/// </summary>
		/// <returns>An instance of the VwBaseLeadGetWithNoActivityInNdaysDataSourceView class.</returns>
		protected override BaseDataSourceView<VwBaseLeadGetWithNoActivityInNdays, Object> GetNewDataSourceView()
		{
			return new VwBaseLeadGetWithNoActivityInNdaysDataSourceView(this, DefaultViewName);
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
	/// Supports the VwBaseLeadGetWithNoActivityInNdaysDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwBaseLeadGetWithNoActivityInNdaysDataSourceView : ReadOnlyDataSourceView<VwBaseLeadGetWithNoActivityInNdays>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityInNdaysDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwBaseLeadGetWithNoActivityInNdaysDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwBaseLeadGetWithNoActivityInNdaysDataSourceView(VwBaseLeadGetWithNoActivityInNdaysDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwBaseLeadGetWithNoActivityInNdaysDataSource VwBaseLeadGetWithNoActivityInNdaysOwner
		{
			get { return Owner as VwBaseLeadGetWithNoActivityInNdaysDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwBaseLeadGetWithNoActivityInNdaysService VwBaseLeadGetWithNoActivityInNdaysProvider
		{
			get { return Provider as VwBaseLeadGetWithNoActivityInNdaysService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwBaseLeadGetWithNoActivityInNdaysDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwBaseLeadGetWithNoActivityInNdaysDataSource class.
	/// </summary>
	public class VwBaseLeadGetWithNoActivityInNdaysDataSourceDesigner : ReadOnlyDataSourceDesigner<VwBaseLeadGetWithNoActivityInNdays>
	{
	}

	#endregion VwBaseLeadGetWithNoActivityInNdaysDataSourceDesigner

	#region VwBaseLeadGetWithNoActivityInNdaysFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetWithNoActivityInNdays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetWithNoActivityInNdaysFilter : SqlFilter<VwBaseLeadGetWithNoActivityInNdaysColumn>
	{
	}

	#endregion VwBaseLeadGetWithNoActivityInNdaysFilter

	#region VwBaseLeadGetWithNoActivityInNdaysExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetWithNoActivityInNdays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetWithNoActivityInNdaysExpressionBuilder : SqlExpressionBuilder<VwBaseLeadGetWithNoActivityInNdaysColumn>
	{
	}
	
	#endregion VwBaseLeadGetWithNoActivityInNdaysExpressionBuilder		
}

