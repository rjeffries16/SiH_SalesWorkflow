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
	/// Represents the DataRepository.VwDeferedLeadsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwDeferedLeadsDataSourceDesigner))]
	public class VwDeferedLeadsDataSource : ReadOnlyDataSource<VwDeferedLeads>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsDataSource class.
		/// </summary>
		public VwDeferedLeadsDataSource() : base(new VwDeferedLeadsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwDeferedLeadsDataSourceView used by the VwDeferedLeadsDataSource.
		/// </summary>
		protected VwDeferedLeadsDataSourceView VwDeferedLeadsView
		{
			get { return ( View as VwDeferedLeadsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwDeferedLeadsDataSourceView class that is to be
		/// used by the VwDeferedLeadsDataSource.
		/// </summary>
		/// <returns>An instance of the VwDeferedLeadsDataSourceView class.</returns>
		protected override BaseDataSourceView<VwDeferedLeads, Object> GetNewDataSourceView()
		{
			return new VwDeferedLeadsDataSourceView(this, DefaultViewName);
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
	/// Supports the VwDeferedLeadsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwDeferedLeadsDataSourceView : ReadOnlyDataSourceView<VwDeferedLeads>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwDeferedLeadsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwDeferedLeadsDataSourceView(VwDeferedLeadsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwDeferedLeadsDataSource VwDeferedLeadsOwner
		{
			get { return Owner as VwDeferedLeadsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwDeferedLeadsService VwDeferedLeadsProvider
		{
			get { return Provider as VwDeferedLeadsService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwDeferedLeadsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwDeferedLeadsDataSource class.
	/// </summary>
	public class VwDeferedLeadsDataSourceDesigner : ReadOnlyDataSourceDesigner<VwDeferedLeads>
	{
	}

	#endregion VwDeferedLeadsDataSourceDesigner

	#region VwDeferedLeadsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwDeferedLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwDeferedLeadsFilter : SqlFilter<VwDeferedLeadsColumn>
	{
	}

	#endregion VwDeferedLeadsFilter

	#region VwDeferedLeadsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwDeferedLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwDeferedLeadsExpressionBuilder : SqlExpressionBuilder<VwDeferedLeadsColumn>
	{
	}
	
	#endregion VwDeferedLeadsExpressionBuilder		
}

