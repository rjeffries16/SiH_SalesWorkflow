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
	/// Represents the DataRepository.VwLeadGetProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadGetDataSourceDesigner))]
	public class VwLeadGetDataSource : ReadOnlyDataSource<VwLeadGet>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetDataSource class.
		/// </summary>
		public VwLeadGetDataSource() : base(new VwLeadGetService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadGetDataSourceView used by the VwLeadGetDataSource.
		/// </summary>
		protected VwLeadGetDataSourceView VwLeadGetView
		{
			get { return ( View as VwLeadGetDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadGetDataSourceView class that is to be
		/// used by the VwLeadGetDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadGetDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadGet, Object> GetNewDataSourceView()
		{
			return new VwLeadGetDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadGetDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadGetDataSourceView : ReadOnlyDataSourceView<VwLeadGet>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadGetDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadGetDataSourceView(VwLeadGetDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadGetDataSource VwLeadGetOwner
		{
			get { return Owner as VwLeadGetDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadGetService VwLeadGetProvider
		{
			get { return Provider as VwLeadGetService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadGetDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadGetDataSource class.
	/// </summary>
	public class VwLeadGetDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadGet>
	{
	}

	#endregion VwLeadGetDataSourceDesigner

	#region VwLeadGetFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetFilter : SqlFilter<VwLeadGetColumn>
	{
	}

	#endregion VwLeadGetFilter

	#region VwLeadGetExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetExpressionBuilder : SqlExpressionBuilder<VwLeadGetColumn>
	{
	}
	
	#endregion VwLeadGetExpressionBuilder		
}

