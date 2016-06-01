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
	/// Represents the DataRepository.VwLeadGetRichardProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadGetRichardDataSourceDesigner))]
	public class VwLeadGetRichardDataSource : ReadOnlyDataSource<VwLeadGetRichard>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetRichardDataSource class.
		/// </summary>
		public VwLeadGetRichardDataSource() : base(new VwLeadGetRichardService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadGetRichardDataSourceView used by the VwLeadGetRichardDataSource.
		/// </summary>
		protected VwLeadGetRichardDataSourceView VwLeadGetRichardView
		{
			get { return ( View as VwLeadGetRichardDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadGetRichardDataSourceView class that is to be
		/// used by the VwLeadGetRichardDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadGetRichardDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadGetRichard, Object> GetNewDataSourceView()
		{
			return new VwLeadGetRichardDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadGetRichardDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadGetRichardDataSourceView : ReadOnlyDataSourceView<VwLeadGetRichard>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetRichardDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadGetRichardDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadGetRichardDataSourceView(VwLeadGetRichardDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadGetRichardDataSource VwLeadGetRichardOwner
		{
			get { return Owner as VwLeadGetRichardDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadGetRichardService VwLeadGetRichardProvider
		{
			get { return Provider as VwLeadGetRichardService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadGetRichardDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadGetRichardDataSource class.
	/// </summary>
	public class VwLeadGetRichardDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadGetRichard>
	{
	}

	#endregion VwLeadGetRichardDataSourceDesigner

	#region VwLeadGetRichardFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetRichard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetRichardFilter : SqlFilter<VwLeadGetRichardColumn>
	{
	}

	#endregion VwLeadGetRichardFilter

	#region VwLeadGetRichardExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetRichard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetRichardExpressionBuilder : SqlExpressionBuilder<VwLeadGetRichardColumn>
	{
	}
	
	#endregion VwLeadGetRichardExpressionBuilder		
}

