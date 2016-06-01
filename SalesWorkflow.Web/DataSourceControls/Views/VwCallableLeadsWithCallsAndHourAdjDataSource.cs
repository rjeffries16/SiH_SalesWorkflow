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
	/// Represents the DataRepository.VwCallableLeadsWithCallsAndHourAdjProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwCallableLeadsWithCallsAndHourAdjDataSourceDesigner))]
	public class VwCallableLeadsWithCallsAndHourAdjDataSource : ReadOnlyDataSource<VwCallableLeadsWithCallsAndHourAdj>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjDataSource class.
		/// </summary>
		public VwCallableLeadsWithCallsAndHourAdjDataSource() : base(new VwCallableLeadsWithCallsAndHourAdjService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwCallableLeadsWithCallsAndHourAdjDataSourceView used by the VwCallableLeadsWithCallsAndHourAdjDataSource.
		/// </summary>
		protected VwCallableLeadsWithCallsAndHourAdjDataSourceView VwCallableLeadsWithCallsAndHourAdjView
		{
			get { return ( View as VwCallableLeadsWithCallsAndHourAdjDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwCallableLeadsWithCallsAndHourAdjDataSourceView class that is to be
		/// used by the VwCallableLeadsWithCallsAndHourAdjDataSource.
		/// </summary>
		/// <returns>An instance of the VwCallableLeadsWithCallsAndHourAdjDataSourceView class.</returns>
		protected override BaseDataSourceView<VwCallableLeadsWithCallsAndHourAdj, Object> GetNewDataSourceView()
		{
			return new VwCallableLeadsWithCallsAndHourAdjDataSourceView(this, DefaultViewName);
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
	/// Supports the VwCallableLeadsWithCallsAndHourAdjDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwCallableLeadsWithCallsAndHourAdjDataSourceView : ReadOnlyDataSourceView<VwCallableLeadsWithCallsAndHourAdj>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwCallableLeadsWithCallsAndHourAdjDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwCallableLeadsWithCallsAndHourAdjDataSourceView(VwCallableLeadsWithCallsAndHourAdjDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwCallableLeadsWithCallsAndHourAdjDataSource VwCallableLeadsWithCallsAndHourAdjOwner
		{
			get { return Owner as VwCallableLeadsWithCallsAndHourAdjDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwCallableLeadsWithCallsAndHourAdjService VwCallableLeadsWithCallsAndHourAdjProvider
		{
			get { return Provider as VwCallableLeadsWithCallsAndHourAdjService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwCallableLeadsWithCallsAndHourAdjDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwCallableLeadsWithCallsAndHourAdjDataSource class.
	/// </summary>
	public class VwCallableLeadsWithCallsAndHourAdjDataSourceDesigner : ReadOnlyDataSourceDesigner<VwCallableLeadsWithCallsAndHourAdj>
	{
	}

	#endregion VwCallableLeadsWithCallsAndHourAdjDataSourceDesigner

	#region VwCallableLeadsWithCallsAndHourAdjFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndHourAdjFilter : SqlFilter<VwCallableLeadsWithCallsAndHourAdjColumn>
	{
	}

	#endregion VwCallableLeadsWithCallsAndHourAdjFilter

	#region VwCallableLeadsWithCallsAndHourAdjExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndHourAdjExpressionBuilder : SqlExpressionBuilder<VwCallableLeadsWithCallsAndHourAdjColumn>
	{
	}
	
	#endregion VwCallableLeadsWithCallsAndHourAdjExpressionBuilder		
}

