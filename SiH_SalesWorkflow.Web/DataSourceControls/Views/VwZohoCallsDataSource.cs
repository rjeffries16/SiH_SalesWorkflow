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
	/// Represents the DataRepository.VwZohoCallsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwZohoCallsDataSourceDesigner))]
	public class VwZohoCallsDataSource : ReadOnlyDataSource<VwZohoCalls>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsDataSource class.
		/// </summary>
		public VwZohoCallsDataSource() : base(new VwZohoCallsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwZohoCallsDataSourceView used by the VwZohoCallsDataSource.
		/// </summary>
		protected VwZohoCallsDataSourceView VwZohoCallsView
		{
			get { return ( View as VwZohoCallsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwZohoCallsDataSourceView class that is to be
		/// used by the VwZohoCallsDataSource.
		/// </summary>
		/// <returns>An instance of the VwZohoCallsDataSourceView class.</returns>
		protected override BaseDataSourceView<VwZohoCalls, Object> GetNewDataSourceView()
		{
			return new VwZohoCallsDataSourceView(this, DefaultViewName);
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
	/// Supports the VwZohoCallsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwZohoCallsDataSourceView : ReadOnlyDataSourceView<VwZohoCalls>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwZohoCallsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwZohoCallsDataSourceView(VwZohoCallsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwZohoCallsDataSource VwZohoCallsOwner
		{
			get { return Owner as VwZohoCallsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwZohoCallsService VwZohoCallsProvider
		{
			get { return Provider as VwZohoCallsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwZohoCallsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwZohoCallsDataSource class.
	/// </summary>
	public class VwZohoCallsDataSourceDesigner : ReadOnlyDataSourceDesigner<VwZohoCalls>
	{
	}

	#endregion VwZohoCallsDataSourceDesigner

	#region VwZohoCallsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoCallsFilter : SqlFilter<VwZohoCallsColumn>
	{
	}

	#endregion VwZohoCallsFilter

	#region VwZohoCallsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoCallsExpressionBuilder : SqlExpressionBuilder<VwZohoCallsColumn>
	{
	}
	
	#endregion VwZohoCallsExpressionBuilder		
}

