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
	/// Represents the DataRepository.VwCallableLeadsWithCallsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwCallableLeadsWithCallsDataSourceDesigner))]
	public class VwCallableLeadsWithCallsDataSource : ReadOnlyDataSource<VwCallableLeadsWithCalls>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsDataSource class.
		/// </summary>
		public VwCallableLeadsWithCallsDataSource() : base(new VwCallableLeadsWithCallsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwCallableLeadsWithCallsDataSourceView used by the VwCallableLeadsWithCallsDataSource.
		/// </summary>
		protected VwCallableLeadsWithCallsDataSourceView VwCallableLeadsWithCallsView
		{
			get { return ( View as VwCallableLeadsWithCallsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwCallableLeadsWithCallsDataSourceView class that is to be
		/// used by the VwCallableLeadsWithCallsDataSource.
		/// </summary>
		/// <returns>An instance of the VwCallableLeadsWithCallsDataSourceView class.</returns>
		protected override BaseDataSourceView<VwCallableLeadsWithCalls, Object> GetNewDataSourceView()
		{
			return new VwCallableLeadsWithCallsDataSourceView(this, DefaultViewName);
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
	/// Supports the VwCallableLeadsWithCallsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwCallableLeadsWithCallsDataSourceView : ReadOnlyDataSourceView<VwCallableLeadsWithCalls>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwCallableLeadsWithCallsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwCallableLeadsWithCallsDataSourceView(VwCallableLeadsWithCallsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwCallableLeadsWithCallsDataSource VwCallableLeadsWithCallsOwner
		{
			get { return Owner as VwCallableLeadsWithCallsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwCallableLeadsWithCallsService VwCallableLeadsWithCallsProvider
		{
			get { return Provider as VwCallableLeadsWithCallsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwCallableLeadsWithCallsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwCallableLeadsWithCallsDataSource class.
	/// </summary>
	public class VwCallableLeadsWithCallsDataSourceDesigner : ReadOnlyDataSourceDesigner<VwCallableLeadsWithCalls>
	{
	}

	#endregion VwCallableLeadsWithCallsDataSourceDesigner

	#region VwCallableLeadsWithCallsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsFilter : SqlFilter<VwCallableLeadsWithCallsColumn>
	{
	}

	#endregion VwCallableLeadsWithCallsFilter

	#region VwCallableLeadsWithCallsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsExpressionBuilder : SqlExpressionBuilder<VwCallableLeadsWithCallsColumn>
	{
	}
	
	#endregion VwCallableLeadsWithCallsExpressionBuilder		
}

