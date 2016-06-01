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
	/// Represents the DataRepository.VwZohoLeadsWithLocalTimeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwZohoLeadsWithLocalTimeDataSourceDesigner))]
	public class VwZohoLeadsWithLocalTimeDataSource : ReadOnlyDataSource<VwZohoLeadsWithLocalTime>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeDataSource class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeDataSource() : base(new VwZohoLeadsWithLocalTimeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwZohoLeadsWithLocalTimeDataSourceView used by the VwZohoLeadsWithLocalTimeDataSource.
		/// </summary>
		protected VwZohoLeadsWithLocalTimeDataSourceView VwZohoLeadsWithLocalTimeView
		{
			get { return ( View as VwZohoLeadsWithLocalTimeDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwZohoLeadsWithLocalTimeDataSourceView class that is to be
		/// used by the VwZohoLeadsWithLocalTimeDataSource.
		/// </summary>
		/// <returns>An instance of the VwZohoLeadsWithLocalTimeDataSourceView class.</returns>
		protected override BaseDataSourceView<VwZohoLeadsWithLocalTime, Object> GetNewDataSourceView()
		{
			return new VwZohoLeadsWithLocalTimeDataSourceView(this, DefaultViewName);
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
	/// Supports the VwZohoLeadsWithLocalTimeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwZohoLeadsWithLocalTimeDataSourceView : ReadOnlyDataSourceView<VwZohoLeadsWithLocalTime>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwZohoLeadsWithLocalTimeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwZohoLeadsWithLocalTimeDataSourceView(VwZohoLeadsWithLocalTimeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwZohoLeadsWithLocalTimeDataSource VwZohoLeadsWithLocalTimeOwner
		{
			get { return Owner as VwZohoLeadsWithLocalTimeDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwZohoLeadsWithLocalTimeService VwZohoLeadsWithLocalTimeProvider
		{
			get { return Provider as VwZohoLeadsWithLocalTimeService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwZohoLeadsWithLocalTimeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwZohoLeadsWithLocalTimeDataSource class.
	/// </summary>
	public class VwZohoLeadsWithLocalTimeDataSourceDesigner : ReadOnlyDataSourceDesigner<VwZohoLeadsWithLocalTime>
	{
	}

	#endregion VwZohoLeadsWithLocalTimeDataSourceDesigner

	#region VwZohoLeadsWithLocalTimeFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeFilter : SqlFilter<VwZohoLeadsWithLocalTimeColumn>
	{
	}

	#endregion VwZohoLeadsWithLocalTimeFilter

	#region VwZohoLeadsWithLocalTimeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeExpressionBuilder : SqlExpressionBuilder<VwZohoLeadsWithLocalTimeColumn>
	{
	}
	
	#endregion VwZohoLeadsWithLocalTimeExpressionBuilder		
}

