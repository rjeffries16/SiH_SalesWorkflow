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
	/// Represents the DataRepository.VwBaseLeadGetWithNoActivityIn60DaysProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwBaseLeadGetWithNoActivityIn60DaysDataSourceDesigner))]
	public class VwBaseLeadGetWithNoActivityIn60DaysDataSource : ReadOnlyDataSource<VwBaseLeadGetWithNoActivityIn60Days>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityIn60DaysDataSource class.
		/// </summary>
		public VwBaseLeadGetWithNoActivityIn60DaysDataSource() : base(new VwBaseLeadGetWithNoActivityIn60DaysService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwBaseLeadGetWithNoActivityIn60DaysDataSourceView used by the VwBaseLeadGetWithNoActivityIn60DaysDataSource.
		/// </summary>
		protected VwBaseLeadGetWithNoActivityIn60DaysDataSourceView VwBaseLeadGetWithNoActivityIn60DaysView
		{
			get { return ( View as VwBaseLeadGetWithNoActivityIn60DaysDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwBaseLeadGetWithNoActivityIn60DaysDataSourceView class that is to be
		/// used by the VwBaseLeadGetWithNoActivityIn60DaysDataSource.
		/// </summary>
		/// <returns>An instance of the VwBaseLeadGetWithNoActivityIn60DaysDataSourceView class.</returns>
		protected override BaseDataSourceView<VwBaseLeadGetWithNoActivityIn60Days, Object> GetNewDataSourceView()
		{
			return new VwBaseLeadGetWithNoActivityIn60DaysDataSourceView(this, DefaultViewName);
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
	/// Supports the VwBaseLeadGetWithNoActivityIn60DaysDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwBaseLeadGetWithNoActivityIn60DaysDataSourceView : ReadOnlyDataSourceView<VwBaseLeadGetWithNoActivityIn60Days>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityIn60DaysDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwBaseLeadGetWithNoActivityIn60DaysDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwBaseLeadGetWithNoActivityIn60DaysDataSourceView(VwBaseLeadGetWithNoActivityIn60DaysDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwBaseLeadGetWithNoActivityIn60DaysDataSource VwBaseLeadGetWithNoActivityIn60DaysOwner
		{
			get { return Owner as VwBaseLeadGetWithNoActivityIn60DaysDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwBaseLeadGetWithNoActivityIn60DaysService VwBaseLeadGetWithNoActivityIn60DaysProvider
		{
			get { return Provider as VwBaseLeadGetWithNoActivityIn60DaysService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwBaseLeadGetWithNoActivityIn60DaysDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwBaseLeadGetWithNoActivityIn60DaysDataSource class.
	/// </summary>
	public class VwBaseLeadGetWithNoActivityIn60DaysDataSourceDesigner : ReadOnlyDataSourceDesigner<VwBaseLeadGetWithNoActivityIn60Days>
	{
	}

	#endregion VwBaseLeadGetWithNoActivityIn60DaysDataSourceDesigner

	#region VwBaseLeadGetWithNoActivityIn60DaysFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetWithNoActivityIn60Days"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetWithNoActivityIn60DaysFilter : SqlFilter<VwBaseLeadGetWithNoActivityIn60DaysColumn>
	{
	}

	#endregion VwBaseLeadGetWithNoActivityIn60DaysFilter

	#region VwBaseLeadGetWithNoActivityIn60DaysExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetWithNoActivityIn60Days"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetWithNoActivityIn60DaysExpressionBuilder : SqlExpressionBuilder<VwBaseLeadGetWithNoActivityIn60DaysColumn>
	{
	}
	
	#endregion VwBaseLeadGetWithNoActivityIn60DaysExpressionBuilder		
}

