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
	/// Represents the DataRepository.VwLeadContactToolCompleteProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadContactToolCompleteDataSourceDesigner))]
	public class VwLeadContactToolCompleteDataSource : ReadOnlyDataSource<VwLeadContactToolComplete>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteDataSource class.
		/// </summary>
		public VwLeadContactToolCompleteDataSource() : base(new VwLeadContactToolCompleteService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadContactToolCompleteDataSourceView used by the VwLeadContactToolCompleteDataSource.
		/// </summary>
		protected VwLeadContactToolCompleteDataSourceView VwLeadContactToolCompleteView
		{
			get { return ( View as VwLeadContactToolCompleteDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadContactToolCompleteDataSourceView class that is to be
		/// used by the VwLeadContactToolCompleteDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadContactToolCompleteDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadContactToolComplete, Object> GetNewDataSourceView()
		{
			return new VwLeadContactToolCompleteDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadContactToolCompleteDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadContactToolCompleteDataSourceView : ReadOnlyDataSourceView<VwLeadContactToolComplete>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadContactToolCompleteDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadContactToolCompleteDataSourceView(VwLeadContactToolCompleteDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadContactToolCompleteDataSource VwLeadContactToolCompleteOwner
		{
			get { return Owner as VwLeadContactToolCompleteDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadContactToolCompleteService VwLeadContactToolCompleteProvider
		{
			get { return Provider as VwLeadContactToolCompleteService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadContactToolCompleteDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadContactToolCompleteDataSource class.
	/// </summary>
	public class VwLeadContactToolCompleteDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadContactToolComplete>
	{
	}

	#endregion VwLeadContactToolCompleteDataSourceDesigner

	#region VwLeadContactToolCompleteFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactToolComplete"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolCompleteFilter : SqlFilter<VwLeadContactToolCompleteColumn>
	{
	}

	#endregion VwLeadContactToolCompleteFilter

	#region VwLeadContactToolCompleteExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactToolComplete"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolCompleteExpressionBuilder : SqlExpressionBuilder<VwLeadContactToolCompleteColumn>
	{
	}
	
	#endregion VwLeadContactToolCompleteExpressionBuilder		
}

