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
	/// Represents the DataRepository.VwLeadGetJennProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadGetJennDataSourceDesigner))]
	public class VwLeadGetJennDataSource : ReadOnlyDataSource<VwLeadGetJenn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJennDataSource class.
		/// </summary>
		public VwLeadGetJennDataSource() : base(new VwLeadGetJennService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadGetJennDataSourceView used by the VwLeadGetJennDataSource.
		/// </summary>
		protected VwLeadGetJennDataSourceView VwLeadGetJennView
		{
			get { return ( View as VwLeadGetJennDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadGetJennDataSourceView class that is to be
		/// used by the VwLeadGetJennDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadGetJennDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadGetJenn, Object> GetNewDataSourceView()
		{
			return new VwLeadGetJennDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadGetJennDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadGetJennDataSourceView : ReadOnlyDataSourceView<VwLeadGetJenn>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJennDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadGetJennDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadGetJennDataSourceView(VwLeadGetJennDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadGetJennDataSource VwLeadGetJennOwner
		{
			get { return Owner as VwLeadGetJennDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadGetJennService VwLeadGetJennProvider
		{
			get { return Provider as VwLeadGetJennService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadGetJennDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadGetJennDataSource class.
	/// </summary>
	public class VwLeadGetJennDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadGetJenn>
	{
	}

	#endregion VwLeadGetJennDataSourceDesigner

	#region VwLeadGetJennFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetJenn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetJennFilter : SqlFilter<VwLeadGetJennColumn>
	{
	}

	#endregion VwLeadGetJennFilter

	#region VwLeadGetJennExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetJenn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetJennExpressionBuilder : SqlExpressionBuilder<VwLeadGetJennColumn>
	{
	}
	
	#endregion VwLeadGetJennExpressionBuilder		
}

