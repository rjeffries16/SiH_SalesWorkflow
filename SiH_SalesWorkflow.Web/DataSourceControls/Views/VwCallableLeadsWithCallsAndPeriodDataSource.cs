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
	/// Represents the DataRepository.VwCallableLeadsWithCallsAndPeriodProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwCallableLeadsWithCallsAndPeriodDataSourceDesigner))]
	public class VwCallableLeadsWithCallsAndPeriodDataSource : ReadOnlyDataSource<VwCallableLeadsWithCallsAndPeriod>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodDataSource class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodDataSource() : base(new VwCallableLeadsWithCallsAndPeriodService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwCallableLeadsWithCallsAndPeriodDataSourceView used by the VwCallableLeadsWithCallsAndPeriodDataSource.
		/// </summary>
		protected VwCallableLeadsWithCallsAndPeriodDataSourceView VwCallableLeadsWithCallsAndPeriodView
		{
			get { return ( View as VwCallableLeadsWithCallsAndPeriodDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwCallableLeadsWithCallsAndPeriodDataSourceView class that is to be
		/// used by the VwCallableLeadsWithCallsAndPeriodDataSource.
		/// </summary>
		/// <returns>An instance of the VwCallableLeadsWithCallsAndPeriodDataSourceView class.</returns>
		protected override BaseDataSourceView<VwCallableLeadsWithCallsAndPeriod, Object> GetNewDataSourceView()
		{
			return new VwCallableLeadsWithCallsAndPeriodDataSourceView(this, DefaultViewName);
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
	/// Supports the VwCallableLeadsWithCallsAndPeriodDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwCallableLeadsWithCallsAndPeriodDataSourceView : ReadOnlyDataSourceView<VwCallableLeadsWithCallsAndPeriod>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwCallableLeadsWithCallsAndPeriodDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwCallableLeadsWithCallsAndPeriodDataSourceView(VwCallableLeadsWithCallsAndPeriodDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwCallableLeadsWithCallsAndPeriodDataSource VwCallableLeadsWithCallsAndPeriodOwner
		{
			get { return Owner as VwCallableLeadsWithCallsAndPeriodDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwCallableLeadsWithCallsAndPeriodService VwCallableLeadsWithCallsAndPeriodProvider
		{
			get { return Provider as VwCallableLeadsWithCallsAndPeriodService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwCallableLeadsWithCallsAndPeriodDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwCallableLeadsWithCallsAndPeriodDataSource class.
	/// </summary>
	public class VwCallableLeadsWithCallsAndPeriodDataSourceDesigner : ReadOnlyDataSourceDesigner<VwCallableLeadsWithCallsAndPeriod>
	{
	}

	#endregion VwCallableLeadsWithCallsAndPeriodDataSourceDesigner

	#region VwCallableLeadsWithCallsAndPeriodFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodFilter : SqlFilter<VwCallableLeadsWithCallsAndPeriodColumn>
	{
	}

	#endregion VwCallableLeadsWithCallsAndPeriodFilter

	#region VwCallableLeadsWithCallsAndPeriodExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodExpressionBuilder : SqlExpressionBuilder<VwCallableLeadsWithCallsAndPeriodColumn>
	{
	}
	
	#endregion VwCallableLeadsWithCallsAndPeriodExpressionBuilder		
}

