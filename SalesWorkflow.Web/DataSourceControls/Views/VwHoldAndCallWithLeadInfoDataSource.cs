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
	/// Represents the DataRepository.VwHoldAndCallWithLeadInfoProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwHoldAndCallWithLeadInfoDataSourceDesigner))]
	public class VwHoldAndCallWithLeadInfoDataSource : ReadOnlyDataSource<VwHoldAndCallWithLeadInfo>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoDataSource class.
		/// </summary>
		public VwHoldAndCallWithLeadInfoDataSource() : base(new VwHoldAndCallWithLeadInfoService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwHoldAndCallWithLeadInfoDataSourceView used by the VwHoldAndCallWithLeadInfoDataSource.
		/// </summary>
		protected VwHoldAndCallWithLeadInfoDataSourceView VwHoldAndCallWithLeadInfoView
		{
			get { return ( View as VwHoldAndCallWithLeadInfoDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwHoldAndCallWithLeadInfoDataSourceView class that is to be
		/// used by the VwHoldAndCallWithLeadInfoDataSource.
		/// </summary>
		/// <returns>An instance of the VwHoldAndCallWithLeadInfoDataSourceView class.</returns>
		protected override BaseDataSourceView<VwHoldAndCallWithLeadInfo, Object> GetNewDataSourceView()
		{
			return new VwHoldAndCallWithLeadInfoDataSourceView(this, DefaultViewName);
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
	/// Supports the VwHoldAndCallWithLeadInfoDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwHoldAndCallWithLeadInfoDataSourceView : ReadOnlyDataSourceView<VwHoldAndCallWithLeadInfo>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwHoldAndCallWithLeadInfoDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwHoldAndCallWithLeadInfoDataSourceView(VwHoldAndCallWithLeadInfoDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwHoldAndCallWithLeadInfoDataSource VwHoldAndCallWithLeadInfoOwner
		{
			get { return Owner as VwHoldAndCallWithLeadInfoDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwHoldAndCallWithLeadInfoService VwHoldAndCallWithLeadInfoProvider
		{
			get { return Provider as VwHoldAndCallWithLeadInfoService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwHoldAndCallWithLeadInfoDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwHoldAndCallWithLeadInfoDataSource class.
	/// </summary>
	public class VwHoldAndCallWithLeadInfoDataSourceDesigner : ReadOnlyDataSourceDesigner<VwHoldAndCallWithLeadInfo>
	{
	}

	#endregion VwHoldAndCallWithLeadInfoDataSourceDesigner

	#region VwHoldAndCallWithLeadInfoFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwHoldAndCallWithLeadInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwHoldAndCallWithLeadInfoFilter : SqlFilter<VwHoldAndCallWithLeadInfoColumn>
	{
	}

	#endregion VwHoldAndCallWithLeadInfoFilter

	#region VwHoldAndCallWithLeadInfoExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwHoldAndCallWithLeadInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwHoldAndCallWithLeadInfoExpressionBuilder : SqlExpressionBuilder<VwHoldAndCallWithLeadInfoColumn>
	{
	}
	
	#endregion VwHoldAndCallWithLeadInfoExpressionBuilder		
}

