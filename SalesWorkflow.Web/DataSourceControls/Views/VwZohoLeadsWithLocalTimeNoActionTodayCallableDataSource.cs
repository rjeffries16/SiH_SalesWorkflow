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
	/// Represents the DataRepository.VwZohoLeadsWithLocalTimeNoActionTodayCallableProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceDesigner))]
	public class VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource : ReadOnlyDataSource<VwZohoLeadsWithLocalTimeNoActionTodayCallable>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource() : base(new VwZohoLeadsWithLocalTimeNoActionTodayCallableService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceView used by the VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource.
		/// </summary>
		protected VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceView VwZohoLeadsWithLocalTimeNoActionTodayCallableView
		{
			get { return ( View as VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceView class that is to be
		/// used by the VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource.
		/// </summary>
		/// <returns>An instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceView class.</returns>
		protected override BaseDataSourceView<VwZohoLeadsWithLocalTimeNoActionTodayCallable, Object> GetNewDataSourceView()
		{
			return new VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceView(this, DefaultViewName);
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
	/// Supports the VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceView : ReadOnlyDataSourceView<VwZohoLeadsWithLocalTimeNoActionTodayCallable>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceView(VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource VwZohoLeadsWithLocalTimeNoActionTodayCallableOwner
		{
			get { return Owner as VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwZohoLeadsWithLocalTimeNoActionTodayCallableService VwZohoLeadsWithLocalTimeNoActionTodayCallableProvider
		{
			get { return Provider as VwZohoLeadsWithLocalTimeNoActionTodayCallableService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSource class.
	/// </summary>
	public class VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceDesigner : ReadOnlyDataSourceDesigner<VwZohoLeadsWithLocalTimeNoActionTodayCallable>
	{
	}

	#endregion VwZohoLeadsWithLocalTimeNoActionTodayCallableDataSourceDesigner

	#region VwZohoLeadsWithLocalTimeNoActionTodayCallableFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeNoActionTodayCallableFilter : SqlFilter<VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn>
	{
	}

	#endregion VwZohoLeadsWithLocalTimeNoActionTodayCallableFilter

	#region VwZohoLeadsWithLocalTimeNoActionTodayCallableExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeNoActionTodayCallableExpressionBuilder : SqlExpressionBuilder<VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn>
	{
	}
	
	#endregion VwZohoLeadsWithLocalTimeNoActionTodayCallableExpressionBuilder		
}

