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
	/// Represents the DataRepository.VwLeadGetNextProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadGetNextDataSourceDesigner))]
	public class VwLeadGetNextDataSource : ReadOnlyDataSource<VwLeadGetNext>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextDataSource class.
		/// </summary>
		public VwLeadGetNextDataSource() : base(new VwLeadGetNextService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadGetNextDataSourceView used by the VwLeadGetNextDataSource.
		/// </summary>
		protected VwLeadGetNextDataSourceView VwLeadGetNextView
		{
			get { return ( View as VwLeadGetNextDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadGetNextDataSourceView class that is to be
		/// used by the VwLeadGetNextDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadGetNextDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadGetNext, Object> GetNewDataSourceView()
		{
			return new VwLeadGetNextDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadGetNextDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadGetNextDataSourceView : ReadOnlyDataSourceView<VwLeadGetNext>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadGetNextDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadGetNextDataSourceView(VwLeadGetNextDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadGetNextDataSource VwLeadGetNextOwner
		{
			get { return Owner as VwLeadGetNextDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadGetNextService VwLeadGetNextProvider
		{
			get { return Provider as VwLeadGetNextService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadGetNextDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadGetNextDataSource class.
	/// </summary>
	public class VwLeadGetNextDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadGetNext>
	{
	}

	#endregion VwLeadGetNextDataSourceDesigner

	#region VwLeadGetNextFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetNext"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetNextFilter : SqlFilter<VwLeadGetNextColumn>
	{
	}

	#endregion VwLeadGetNextFilter

	#region VwLeadGetNextExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetNext"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetNextExpressionBuilder : SqlExpressionBuilder<VwLeadGetNextColumn>
	{
	}
	
	#endregion VwLeadGetNextExpressionBuilder		
}

