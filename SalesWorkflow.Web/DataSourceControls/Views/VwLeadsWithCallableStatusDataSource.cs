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
	/// Represents the DataRepository.VwLeadsWithCallableStatusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadsWithCallableStatusDataSourceDesigner))]
	public class VwLeadsWithCallableStatusDataSource : ReadOnlyDataSource<VwLeadsWithCallableStatus>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithCallableStatusDataSource class.
		/// </summary>
		public VwLeadsWithCallableStatusDataSource() : base(new VwLeadsWithCallableStatusService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadsWithCallableStatusDataSourceView used by the VwLeadsWithCallableStatusDataSource.
		/// </summary>
		protected VwLeadsWithCallableStatusDataSourceView VwLeadsWithCallableStatusView
		{
			get { return ( View as VwLeadsWithCallableStatusDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadsWithCallableStatusDataSourceView class that is to be
		/// used by the VwLeadsWithCallableStatusDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadsWithCallableStatusDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadsWithCallableStatus, Object> GetNewDataSourceView()
		{
			return new VwLeadsWithCallableStatusDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadsWithCallableStatusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadsWithCallableStatusDataSourceView : ReadOnlyDataSourceView<VwLeadsWithCallableStatus>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithCallableStatusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadsWithCallableStatusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadsWithCallableStatusDataSourceView(VwLeadsWithCallableStatusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadsWithCallableStatusDataSource VwLeadsWithCallableStatusOwner
		{
			get { return Owner as VwLeadsWithCallableStatusDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadsWithCallableStatusService VwLeadsWithCallableStatusProvider
		{
			get { return Provider as VwLeadsWithCallableStatusService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadsWithCallableStatusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadsWithCallableStatusDataSource class.
	/// </summary>
	public class VwLeadsWithCallableStatusDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadsWithCallableStatus>
	{
	}

	#endregion VwLeadsWithCallableStatusDataSourceDesigner

	#region VwLeadsWithCallableStatusFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithCallableStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsWithCallableStatusFilter : SqlFilter<VwLeadsWithCallableStatusColumn>
	{
	}

	#endregion VwLeadsWithCallableStatusFilter

	#region VwLeadsWithCallableStatusExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithCallableStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsWithCallableStatusExpressionBuilder : SqlExpressionBuilder<VwLeadsWithCallableStatusColumn>
	{
	}
	
	#endregion VwLeadsWithCallableStatusExpressionBuilder		
}

