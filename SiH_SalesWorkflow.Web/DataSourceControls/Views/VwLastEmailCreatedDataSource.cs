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
	/// Represents the DataRepository.VwLastEmailCreatedProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLastEmailCreatedDataSourceDesigner))]
	public class VwLastEmailCreatedDataSource : ReadOnlyDataSource<VwLastEmailCreated>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedDataSource class.
		/// </summary>
		public VwLastEmailCreatedDataSource() : base(new VwLastEmailCreatedService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLastEmailCreatedDataSourceView used by the VwLastEmailCreatedDataSource.
		/// </summary>
		protected VwLastEmailCreatedDataSourceView VwLastEmailCreatedView
		{
			get { return ( View as VwLastEmailCreatedDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLastEmailCreatedDataSourceView class that is to be
		/// used by the VwLastEmailCreatedDataSource.
		/// </summary>
		/// <returns>An instance of the VwLastEmailCreatedDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLastEmailCreated, Object> GetNewDataSourceView()
		{
			return new VwLastEmailCreatedDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLastEmailCreatedDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLastEmailCreatedDataSourceView : ReadOnlyDataSourceView<VwLastEmailCreated>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLastEmailCreatedDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLastEmailCreatedDataSourceView(VwLastEmailCreatedDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLastEmailCreatedDataSource VwLastEmailCreatedOwner
		{
			get { return Owner as VwLastEmailCreatedDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLastEmailCreatedService VwLastEmailCreatedProvider
		{
			get { return Provider as VwLastEmailCreatedService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLastEmailCreatedDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLastEmailCreatedDataSource class.
	/// </summary>
	public class VwLastEmailCreatedDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLastEmailCreated>
	{
	}

	#endregion VwLastEmailCreatedDataSourceDesigner

	#region VwLastEmailCreatedFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastEmailCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastEmailCreatedFilter : SqlFilter<VwLastEmailCreatedColumn>
	{
	}

	#endregion VwLastEmailCreatedFilter

	#region VwLastEmailCreatedExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastEmailCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastEmailCreatedExpressionBuilder : SqlExpressionBuilder<VwLastEmailCreatedColumn>
	{
	}
	
	#endregion VwLastEmailCreatedExpressionBuilder		
}

