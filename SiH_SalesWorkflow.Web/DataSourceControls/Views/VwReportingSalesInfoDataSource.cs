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
	/// Represents the DataRepository.VwReportingSalesInfoProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwReportingSalesInfoDataSourceDesigner))]
	public class VwReportingSalesInfoDataSource : ReadOnlyDataSource<VwReportingSalesInfo>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoDataSource class.
		/// </summary>
		public VwReportingSalesInfoDataSource() : base(new VwReportingSalesInfoService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwReportingSalesInfoDataSourceView used by the VwReportingSalesInfoDataSource.
		/// </summary>
		protected VwReportingSalesInfoDataSourceView VwReportingSalesInfoView
		{
			get { return ( View as VwReportingSalesInfoDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwReportingSalesInfoDataSourceView class that is to be
		/// used by the VwReportingSalesInfoDataSource.
		/// </summary>
		/// <returns>An instance of the VwReportingSalesInfoDataSourceView class.</returns>
		protected override BaseDataSourceView<VwReportingSalesInfo, Object> GetNewDataSourceView()
		{
			return new VwReportingSalesInfoDataSourceView(this, DefaultViewName);
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
	/// Supports the VwReportingSalesInfoDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwReportingSalesInfoDataSourceView : ReadOnlyDataSourceView<VwReportingSalesInfo>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwReportingSalesInfoDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwReportingSalesInfoDataSourceView(VwReportingSalesInfoDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwReportingSalesInfoDataSource VwReportingSalesInfoOwner
		{
			get { return Owner as VwReportingSalesInfoDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwReportingSalesInfoService VwReportingSalesInfoProvider
		{
			get { return Provider as VwReportingSalesInfoService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwReportingSalesInfoDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwReportingSalesInfoDataSource class.
	/// </summary>
	public class VwReportingSalesInfoDataSourceDesigner : ReadOnlyDataSourceDesigner<VwReportingSalesInfo>
	{
	}

	#endregion VwReportingSalesInfoDataSourceDesigner

	#region VwReportingSalesInfoFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingSalesInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingSalesInfoFilter : SqlFilter<VwReportingSalesInfoColumn>
	{
	}

	#endregion VwReportingSalesInfoFilter

	#region VwReportingSalesInfoExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingSalesInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingSalesInfoExpressionBuilder : SqlExpressionBuilder<VwReportingSalesInfoColumn>
	{
	}
	
	#endregion VwReportingSalesInfoExpressionBuilder		
}

