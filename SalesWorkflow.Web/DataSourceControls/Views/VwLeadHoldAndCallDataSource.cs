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
	/// Represents the DataRepository.VwLeadHoldAndCallProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadHoldAndCallDataSourceDesigner))]
	public class VwLeadHoldAndCallDataSource : ReadOnlyDataSource<VwLeadHoldAndCall>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallDataSource class.
		/// </summary>
		public VwLeadHoldAndCallDataSource() : base(new VwLeadHoldAndCallService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadHoldAndCallDataSourceView used by the VwLeadHoldAndCallDataSource.
		/// </summary>
		protected VwLeadHoldAndCallDataSourceView VwLeadHoldAndCallView
		{
			get { return ( View as VwLeadHoldAndCallDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadHoldAndCallDataSourceView class that is to be
		/// used by the VwLeadHoldAndCallDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadHoldAndCallDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadHoldAndCall, Object> GetNewDataSourceView()
		{
			return new VwLeadHoldAndCallDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadHoldAndCallDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadHoldAndCallDataSourceView : ReadOnlyDataSourceView<VwLeadHoldAndCall>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadHoldAndCallDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadHoldAndCallDataSourceView(VwLeadHoldAndCallDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadHoldAndCallDataSource VwLeadHoldAndCallOwner
		{
			get { return Owner as VwLeadHoldAndCallDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadHoldAndCallService VwLeadHoldAndCallProvider
		{
			get { return Provider as VwLeadHoldAndCallService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadHoldAndCallDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadHoldAndCallDataSource class.
	/// </summary>
	public class VwLeadHoldAndCallDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadHoldAndCall>
	{
	}

	#endregion VwLeadHoldAndCallDataSourceDesigner

	#region VwLeadHoldAndCallFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadHoldAndCallFilter : SqlFilter<VwLeadHoldAndCallColumn>
	{
	}

	#endregion VwLeadHoldAndCallFilter

	#region VwLeadHoldAndCallExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadHoldAndCallExpressionBuilder : SqlExpressionBuilder<VwLeadHoldAndCallColumn>
	{
	}
	
	#endregion VwLeadHoldAndCallExpressionBuilder		
}

