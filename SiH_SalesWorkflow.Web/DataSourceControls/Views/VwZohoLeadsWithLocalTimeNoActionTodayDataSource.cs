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
	/// Represents the DataRepository.VwZohoLeadsWithLocalTimeNoActionTodayProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwZohoLeadsWithLocalTimeNoActionTodayDataSourceDesigner))]
	public class VwZohoLeadsWithLocalTimeNoActionTodayDataSource : ReadOnlyDataSource<VwZohoLeadsWithLocalTimeNoActionToday>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayDataSource class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeNoActionTodayDataSource() : base(new VwZohoLeadsWithLocalTimeNoActionTodayService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwZohoLeadsWithLocalTimeNoActionTodayDataSourceView used by the VwZohoLeadsWithLocalTimeNoActionTodayDataSource.
		/// </summary>
		protected VwZohoLeadsWithLocalTimeNoActionTodayDataSourceView VwZohoLeadsWithLocalTimeNoActionTodayView
		{
			get { return ( View as VwZohoLeadsWithLocalTimeNoActionTodayDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayDataSourceView class that is to be
		/// used by the VwZohoLeadsWithLocalTimeNoActionTodayDataSource.
		/// </summary>
		/// <returns>An instance of the VwZohoLeadsWithLocalTimeNoActionTodayDataSourceView class.</returns>
		protected override BaseDataSourceView<VwZohoLeadsWithLocalTimeNoActionToday, Object> GetNewDataSourceView()
		{
			return new VwZohoLeadsWithLocalTimeNoActionTodayDataSourceView(this, DefaultViewName);
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
	/// Supports the VwZohoLeadsWithLocalTimeNoActionTodayDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwZohoLeadsWithLocalTimeNoActionTodayDataSourceView : ReadOnlyDataSourceView<VwZohoLeadsWithLocalTimeNoActionToday>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwZohoLeadsWithLocalTimeNoActionTodayDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayDataSourceView(VwZohoLeadsWithLocalTimeNoActionTodayDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwZohoLeadsWithLocalTimeNoActionTodayDataSource VwZohoLeadsWithLocalTimeNoActionTodayOwner
		{
			get { return Owner as VwZohoLeadsWithLocalTimeNoActionTodayDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwZohoLeadsWithLocalTimeNoActionTodayService VwZohoLeadsWithLocalTimeNoActionTodayProvider
		{
			get { return Provider as VwZohoLeadsWithLocalTimeNoActionTodayService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwZohoLeadsWithLocalTimeNoActionTodayDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwZohoLeadsWithLocalTimeNoActionTodayDataSource class.
	/// </summary>
	public class VwZohoLeadsWithLocalTimeNoActionTodayDataSourceDesigner : ReadOnlyDataSourceDesigner<VwZohoLeadsWithLocalTimeNoActionToday>
	{
	}

	#endregion VwZohoLeadsWithLocalTimeNoActionTodayDataSourceDesigner

	#region VwZohoLeadsWithLocalTimeNoActionTodayFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionToday"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeNoActionTodayFilter : SqlFilter<VwZohoLeadsWithLocalTimeNoActionTodayColumn>
	{
	}

	#endregion VwZohoLeadsWithLocalTimeNoActionTodayFilter

	#region VwZohoLeadsWithLocalTimeNoActionTodayExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionToday"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeNoActionTodayExpressionBuilder : SqlExpressionBuilder<VwZohoLeadsWithLocalTimeNoActionTodayColumn>
	{
	}
	
	#endregion VwZohoLeadsWithLocalTimeNoActionTodayExpressionBuilder		
}

