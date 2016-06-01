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
	/// Represents the DataRepository.VwReportingZohoCallsConnectedAfterDateProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwReportingZohoCallsConnectedAfterDateDataSourceDesigner))]
	public class VwReportingZohoCallsConnectedAfterDateDataSource : ReadOnlyDataSource<VwReportingZohoCallsConnectedAfterDate>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateDataSource class.
		/// </summary>
		public VwReportingZohoCallsConnectedAfterDateDataSource() : base(new VwReportingZohoCallsConnectedAfterDateService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwReportingZohoCallsConnectedAfterDateDataSourceView used by the VwReportingZohoCallsConnectedAfterDateDataSource.
		/// </summary>
		protected VwReportingZohoCallsConnectedAfterDateDataSourceView VwReportingZohoCallsConnectedAfterDateView
		{
			get { return ( View as VwReportingZohoCallsConnectedAfterDateDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwReportingZohoCallsConnectedAfterDateDataSourceView class that is to be
		/// used by the VwReportingZohoCallsConnectedAfterDateDataSource.
		/// </summary>
		/// <returns>An instance of the VwReportingZohoCallsConnectedAfterDateDataSourceView class.</returns>
		protected override BaseDataSourceView<VwReportingZohoCallsConnectedAfterDate, Object> GetNewDataSourceView()
		{
			return new VwReportingZohoCallsConnectedAfterDateDataSourceView(this, DefaultViewName);
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
	/// Supports the VwReportingZohoCallsConnectedAfterDateDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwReportingZohoCallsConnectedAfterDateDataSourceView : ReadOnlyDataSourceView<VwReportingZohoCallsConnectedAfterDate>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwReportingZohoCallsConnectedAfterDateDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwReportingZohoCallsConnectedAfterDateDataSourceView(VwReportingZohoCallsConnectedAfterDateDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwReportingZohoCallsConnectedAfterDateDataSource VwReportingZohoCallsConnectedAfterDateOwner
		{
			get { return Owner as VwReportingZohoCallsConnectedAfterDateDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwReportingZohoCallsConnectedAfterDateService VwReportingZohoCallsConnectedAfterDateProvider
		{
			get { return Provider as VwReportingZohoCallsConnectedAfterDateService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwReportingZohoCallsConnectedAfterDateDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwReportingZohoCallsConnectedAfterDateDataSource class.
	/// </summary>
	public class VwReportingZohoCallsConnectedAfterDateDataSourceDesigner : ReadOnlyDataSourceDesigner<VwReportingZohoCallsConnectedAfterDate>
	{
	}

	#endregion VwReportingZohoCallsConnectedAfterDateDataSourceDesigner

	#region VwReportingZohoCallsConnectedAfterDateFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingZohoCallsConnectedAfterDate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingZohoCallsConnectedAfterDateFilter : SqlFilter<VwReportingZohoCallsConnectedAfterDateColumn>
	{
	}

	#endregion VwReportingZohoCallsConnectedAfterDateFilter

	#region VwReportingZohoCallsConnectedAfterDateExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingZohoCallsConnectedAfterDate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingZohoCallsConnectedAfterDateExpressionBuilder : SqlExpressionBuilder<VwReportingZohoCallsConnectedAfterDateColumn>
	{
	}
	
	#endregion VwReportingZohoCallsConnectedAfterDateExpressionBuilder		
}

