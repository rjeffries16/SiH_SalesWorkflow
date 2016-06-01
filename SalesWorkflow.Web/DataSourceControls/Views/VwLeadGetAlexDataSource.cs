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
	/// Represents the DataRepository.VwLeadGetAlexProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadGetAlexDataSourceDesigner))]
	public class VwLeadGetAlexDataSource : ReadOnlyDataSource<VwLeadGetAlex>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetAlexDataSource class.
		/// </summary>
		public VwLeadGetAlexDataSource() : base(new VwLeadGetAlexService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadGetAlexDataSourceView used by the VwLeadGetAlexDataSource.
		/// </summary>
		protected VwLeadGetAlexDataSourceView VwLeadGetAlexView
		{
			get { return ( View as VwLeadGetAlexDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadGetAlexDataSourceView class that is to be
		/// used by the VwLeadGetAlexDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadGetAlexDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadGetAlex, Object> GetNewDataSourceView()
		{
			return new VwLeadGetAlexDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadGetAlexDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadGetAlexDataSourceView : ReadOnlyDataSourceView<VwLeadGetAlex>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetAlexDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadGetAlexDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadGetAlexDataSourceView(VwLeadGetAlexDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadGetAlexDataSource VwLeadGetAlexOwner
		{
			get { return Owner as VwLeadGetAlexDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadGetAlexService VwLeadGetAlexProvider
		{
			get { return Provider as VwLeadGetAlexService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadGetAlexDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadGetAlexDataSource class.
	/// </summary>
	public class VwLeadGetAlexDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadGetAlex>
	{
	}

	#endregion VwLeadGetAlexDataSourceDesigner

	#region VwLeadGetAlexFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetAlex"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetAlexFilter : SqlFilter<VwLeadGetAlexColumn>
	{
	}

	#endregion VwLeadGetAlexFilter

	#region VwLeadGetAlexExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetAlex"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetAlexExpressionBuilder : SqlExpressionBuilder<VwLeadGetAlexColumn>
	{
	}
	
	#endregion VwLeadGetAlexExpressionBuilder		
}

