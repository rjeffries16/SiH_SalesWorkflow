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
	/// Represents the DataRepository.VwMaxLeadHoldAndCallProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwMaxLeadHoldAndCallDataSourceDesigner))]
	public class VwMaxLeadHoldAndCallDataSource : ReadOnlyDataSource<VwMaxLeadHoldAndCall>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallDataSource class.
		/// </summary>
		public VwMaxLeadHoldAndCallDataSource() : base(new VwMaxLeadHoldAndCallService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwMaxLeadHoldAndCallDataSourceView used by the VwMaxLeadHoldAndCallDataSource.
		/// </summary>
		protected VwMaxLeadHoldAndCallDataSourceView VwMaxLeadHoldAndCallView
		{
			get { return ( View as VwMaxLeadHoldAndCallDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwMaxLeadHoldAndCallDataSourceView class that is to be
		/// used by the VwMaxLeadHoldAndCallDataSource.
		/// </summary>
		/// <returns>An instance of the VwMaxLeadHoldAndCallDataSourceView class.</returns>
		protected override BaseDataSourceView<VwMaxLeadHoldAndCall, Object> GetNewDataSourceView()
		{
			return new VwMaxLeadHoldAndCallDataSourceView(this, DefaultViewName);
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
	/// Supports the VwMaxLeadHoldAndCallDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwMaxLeadHoldAndCallDataSourceView : ReadOnlyDataSourceView<VwMaxLeadHoldAndCall>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwMaxLeadHoldAndCallDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwMaxLeadHoldAndCallDataSourceView(VwMaxLeadHoldAndCallDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwMaxLeadHoldAndCallDataSource VwMaxLeadHoldAndCallOwner
		{
			get { return Owner as VwMaxLeadHoldAndCallDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwMaxLeadHoldAndCallService VwMaxLeadHoldAndCallProvider
		{
			get { return Provider as VwMaxLeadHoldAndCallService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwMaxLeadHoldAndCallDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwMaxLeadHoldAndCallDataSource class.
	/// </summary>
	public class VwMaxLeadHoldAndCallDataSourceDesigner : ReadOnlyDataSourceDesigner<VwMaxLeadHoldAndCall>
	{
	}

	#endregion VwMaxLeadHoldAndCallDataSourceDesigner

	#region VwMaxLeadHoldAndCallFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwMaxLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwMaxLeadHoldAndCallFilter : SqlFilter<VwMaxLeadHoldAndCallColumn>
	{
	}

	#endregion VwMaxLeadHoldAndCallFilter

	#region VwMaxLeadHoldAndCallExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwMaxLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwMaxLeadHoldAndCallExpressionBuilder : SqlExpressionBuilder<VwMaxLeadHoldAndCallColumn>
	{
	}
	
	#endregion VwMaxLeadHoldAndCallExpressionBuilder		
}

