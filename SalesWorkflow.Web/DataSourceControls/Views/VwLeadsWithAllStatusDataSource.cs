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
	/// Represents the DataRepository.VwLeadsWithAllStatusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadsWithAllStatusDataSourceDesigner))]
	public class VwLeadsWithAllStatusDataSource : ReadOnlyDataSource<VwLeadsWithAllStatus>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusDataSource class.
		/// </summary>
		public VwLeadsWithAllStatusDataSource() : base(new VwLeadsWithAllStatusService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadsWithAllStatusDataSourceView used by the VwLeadsWithAllStatusDataSource.
		/// </summary>
		protected VwLeadsWithAllStatusDataSourceView VwLeadsWithAllStatusView
		{
			get { return ( View as VwLeadsWithAllStatusDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadsWithAllStatusDataSourceView class that is to be
		/// used by the VwLeadsWithAllStatusDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadsWithAllStatusDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadsWithAllStatus, Object> GetNewDataSourceView()
		{
			return new VwLeadsWithAllStatusDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadsWithAllStatusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadsWithAllStatusDataSourceView : ReadOnlyDataSourceView<VwLeadsWithAllStatus>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadsWithAllStatusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadsWithAllStatusDataSourceView(VwLeadsWithAllStatusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadsWithAllStatusDataSource VwLeadsWithAllStatusOwner
		{
			get { return Owner as VwLeadsWithAllStatusDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadsWithAllStatusService VwLeadsWithAllStatusProvider
		{
			get { return Provider as VwLeadsWithAllStatusService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadsWithAllStatusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadsWithAllStatusDataSource class.
	/// </summary>
	public class VwLeadsWithAllStatusDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadsWithAllStatus>
	{
	}

	#endregion VwLeadsWithAllStatusDataSourceDesigner

	#region VwLeadsWithAllStatusFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithAllStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsWithAllStatusFilter : SqlFilter<VwLeadsWithAllStatusColumn>
	{
	}

	#endregion VwLeadsWithAllStatusFilter

	#region VwLeadsWithAllStatusExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithAllStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsWithAllStatusExpressionBuilder : SqlExpressionBuilder<VwLeadsWithAllStatusColumn>
	{
	}
	
	#endregion VwLeadsWithAllStatusExpressionBuilder		
}

