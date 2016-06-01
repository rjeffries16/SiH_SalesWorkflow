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
	/// Represents the DataRepository.VwLeadContactToolProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadContactToolDataSourceDesigner))]
	public class VwLeadContactToolDataSource : ReadOnlyDataSource<VwLeadContactTool>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolDataSource class.
		/// </summary>
		public VwLeadContactToolDataSource() : base(new VwLeadContactToolService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadContactToolDataSourceView used by the VwLeadContactToolDataSource.
		/// </summary>
		protected VwLeadContactToolDataSourceView VwLeadContactToolView
		{
			get { return ( View as VwLeadContactToolDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadContactToolDataSourceView class that is to be
		/// used by the VwLeadContactToolDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadContactToolDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadContactTool, Object> GetNewDataSourceView()
		{
			return new VwLeadContactToolDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadContactToolDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadContactToolDataSourceView : ReadOnlyDataSourceView<VwLeadContactTool>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadContactToolDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadContactToolDataSourceView(VwLeadContactToolDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadContactToolDataSource VwLeadContactToolOwner
		{
			get { return Owner as VwLeadContactToolDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadContactToolService VwLeadContactToolProvider
		{
			get { return Provider as VwLeadContactToolService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadContactToolDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadContactToolDataSource class.
	/// </summary>
	public class VwLeadContactToolDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadContactTool>
	{
	}

	#endregion VwLeadContactToolDataSourceDesigner

	#region VwLeadContactToolFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactTool"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolFilter : SqlFilter<VwLeadContactToolColumn>
	{
	}

	#endregion VwLeadContactToolFilter

	#region VwLeadContactToolExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactTool"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolExpressionBuilder : SqlExpressionBuilder<VwLeadContactToolColumn>
	{
	}
	
	#endregion VwLeadContactToolExpressionBuilder		
}

