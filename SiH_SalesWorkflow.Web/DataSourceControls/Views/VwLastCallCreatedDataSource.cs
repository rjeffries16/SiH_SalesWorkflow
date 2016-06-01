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
	/// Represents the DataRepository.VwLastCallCreatedProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLastCallCreatedDataSourceDesigner))]
	public class VwLastCallCreatedDataSource : ReadOnlyDataSource<VwLastCallCreated>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedDataSource class.
		/// </summary>
		public VwLastCallCreatedDataSource() : base(new VwLastCallCreatedService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLastCallCreatedDataSourceView used by the VwLastCallCreatedDataSource.
		/// </summary>
		protected VwLastCallCreatedDataSourceView VwLastCallCreatedView
		{
			get { return ( View as VwLastCallCreatedDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLastCallCreatedDataSourceView class that is to be
		/// used by the VwLastCallCreatedDataSource.
		/// </summary>
		/// <returns>An instance of the VwLastCallCreatedDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLastCallCreated, Object> GetNewDataSourceView()
		{
			return new VwLastCallCreatedDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLastCallCreatedDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLastCallCreatedDataSourceView : ReadOnlyDataSourceView<VwLastCallCreated>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLastCallCreatedDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLastCallCreatedDataSourceView(VwLastCallCreatedDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLastCallCreatedDataSource VwLastCallCreatedOwner
		{
			get { return Owner as VwLastCallCreatedDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLastCallCreatedService VwLastCallCreatedProvider
		{
			get { return Provider as VwLastCallCreatedService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLastCallCreatedDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLastCallCreatedDataSource class.
	/// </summary>
	public class VwLastCallCreatedDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLastCallCreated>
	{
	}

	#endregion VwLastCallCreatedDataSourceDesigner

	#region VwLastCallCreatedFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastCallCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastCallCreatedFilter : SqlFilter<VwLastCallCreatedColumn>
	{
	}

	#endregion VwLastCallCreatedFilter

	#region VwLastCallCreatedExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastCallCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastCallCreatedExpressionBuilder : SqlExpressionBuilder<VwLastCallCreatedColumn>
	{
	}
	
	#endregion VwLastCallCreatedExpressionBuilder		
}

