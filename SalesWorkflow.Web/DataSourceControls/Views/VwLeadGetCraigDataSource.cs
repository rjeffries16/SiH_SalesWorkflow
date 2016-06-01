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
	/// Represents the DataRepository.VwLeadGetCraigProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadGetCraigDataSourceDesigner))]
	public class VwLeadGetCraigDataSource : ReadOnlyDataSource<VwLeadGetCraig>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetCraigDataSource class.
		/// </summary>
		public VwLeadGetCraigDataSource() : base(new VwLeadGetCraigService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadGetCraigDataSourceView used by the VwLeadGetCraigDataSource.
		/// </summary>
		protected VwLeadGetCraigDataSourceView VwLeadGetCraigView
		{
			get { return ( View as VwLeadGetCraigDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadGetCraigDataSourceView class that is to be
		/// used by the VwLeadGetCraigDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadGetCraigDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadGetCraig, Object> GetNewDataSourceView()
		{
			return new VwLeadGetCraigDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadGetCraigDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadGetCraigDataSourceView : ReadOnlyDataSourceView<VwLeadGetCraig>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetCraigDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadGetCraigDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadGetCraigDataSourceView(VwLeadGetCraigDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadGetCraigDataSource VwLeadGetCraigOwner
		{
			get { return Owner as VwLeadGetCraigDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadGetCraigService VwLeadGetCraigProvider
		{
			get { return Provider as VwLeadGetCraigService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadGetCraigDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadGetCraigDataSource class.
	/// </summary>
	public class VwLeadGetCraigDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadGetCraig>
	{
	}

	#endregion VwLeadGetCraigDataSourceDesigner

	#region VwLeadGetCraigFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetCraig"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetCraigFilter : SqlFilter<VwLeadGetCraigColumn>
	{
	}

	#endregion VwLeadGetCraigFilter

	#region VwLeadGetCraigExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetCraig"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetCraigExpressionBuilder : SqlExpressionBuilder<VwLeadGetCraigColumn>
	{
	}
	
	#endregion VwLeadGetCraigExpressionBuilder		
}

