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
	/// Represents the DataRepository.VwLeadsAndCallsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadsAndCallsDataSourceDesigner))]
	public class VwLeadsAndCallsDataSource : ReadOnlyDataSource<VwLeadsAndCalls>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsDataSource class.
		/// </summary>
		public VwLeadsAndCallsDataSource() : base(new VwLeadsAndCallsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadsAndCallsDataSourceView used by the VwLeadsAndCallsDataSource.
		/// </summary>
		protected VwLeadsAndCallsDataSourceView VwLeadsAndCallsView
		{
			get { return ( View as VwLeadsAndCallsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadsAndCallsDataSourceView class that is to be
		/// used by the VwLeadsAndCallsDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadsAndCallsDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadsAndCalls, Object> GetNewDataSourceView()
		{
			return new VwLeadsAndCallsDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadsAndCallsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadsAndCallsDataSourceView : ReadOnlyDataSourceView<VwLeadsAndCalls>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadsAndCallsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadsAndCallsDataSourceView(VwLeadsAndCallsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadsAndCallsDataSource VwLeadsAndCallsOwner
		{
			get { return Owner as VwLeadsAndCallsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadsAndCallsService VwLeadsAndCallsProvider
		{
			get { return Provider as VwLeadsAndCallsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadsAndCallsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadsAndCallsDataSource class.
	/// </summary>
	public class VwLeadsAndCallsDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadsAndCalls>
	{
	}

	#endregion VwLeadsAndCallsDataSourceDesigner

	#region VwLeadsAndCallsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsAndCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsAndCallsFilter : SqlFilter<VwLeadsAndCallsColumn>
	{
	}

	#endregion VwLeadsAndCallsFilter

	#region VwLeadsAndCallsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsAndCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsAndCallsExpressionBuilder : SqlExpressionBuilder<VwLeadsAndCallsColumn>
	{
	}
	
	#endregion VwLeadsAndCallsExpressionBuilder		
}

