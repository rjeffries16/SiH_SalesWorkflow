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
	/// Represents the DataRepository.VwBaseLeadContactInFutureProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwBaseLeadContactInFutureDataSourceDesigner))]
	public class VwBaseLeadContactInFutureDataSource : ReadOnlyDataSource<VwBaseLeadContactInFuture>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadContactInFutureDataSource class.
		/// </summary>
		public VwBaseLeadContactInFutureDataSource() : base(new VwBaseLeadContactInFutureService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwBaseLeadContactInFutureDataSourceView used by the VwBaseLeadContactInFutureDataSource.
		/// </summary>
		protected VwBaseLeadContactInFutureDataSourceView VwBaseLeadContactInFutureView
		{
			get { return ( View as VwBaseLeadContactInFutureDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwBaseLeadContactInFutureDataSourceView class that is to be
		/// used by the VwBaseLeadContactInFutureDataSource.
		/// </summary>
		/// <returns>An instance of the VwBaseLeadContactInFutureDataSourceView class.</returns>
		protected override BaseDataSourceView<VwBaseLeadContactInFuture, Object> GetNewDataSourceView()
		{
			return new VwBaseLeadContactInFutureDataSourceView(this, DefaultViewName);
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
	/// Supports the VwBaseLeadContactInFutureDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwBaseLeadContactInFutureDataSourceView : ReadOnlyDataSourceView<VwBaseLeadContactInFuture>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadContactInFutureDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwBaseLeadContactInFutureDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwBaseLeadContactInFutureDataSourceView(VwBaseLeadContactInFutureDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwBaseLeadContactInFutureDataSource VwBaseLeadContactInFutureOwner
		{
			get { return Owner as VwBaseLeadContactInFutureDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwBaseLeadContactInFutureService VwBaseLeadContactInFutureProvider
		{
			get { return Provider as VwBaseLeadContactInFutureService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwBaseLeadContactInFutureDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwBaseLeadContactInFutureDataSource class.
	/// </summary>
	public class VwBaseLeadContactInFutureDataSourceDesigner : ReadOnlyDataSourceDesigner<VwBaseLeadContactInFuture>
	{
	}

	#endregion VwBaseLeadContactInFutureDataSourceDesigner

	#region VwBaseLeadContactInFutureFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadContactInFuture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadContactInFutureFilter : SqlFilter<VwBaseLeadContactInFutureColumn>
	{
	}

	#endregion VwBaseLeadContactInFutureFilter

	#region VwBaseLeadContactInFutureExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadContactInFuture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadContactInFutureExpressionBuilder : SqlExpressionBuilder<VwBaseLeadContactInFutureColumn>
	{
	}
	
	#endregion VwBaseLeadContactInFutureExpressionBuilder		
}

