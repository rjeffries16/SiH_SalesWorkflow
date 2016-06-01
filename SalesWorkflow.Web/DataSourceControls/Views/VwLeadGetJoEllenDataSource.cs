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
	/// Represents the DataRepository.VwLeadGetJoEllenProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwLeadGetJoEllenDataSourceDesigner))]
	public class VwLeadGetJoEllenDataSource : ReadOnlyDataSource<VwLeadGetJoEllen>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJoEllenDataSource class.
		/// </summary>
		public VwLeadGetJoEllenDataSource() : base(new VwLeadGetJoEllenService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwLeadGetJoEllenDataSourceView used by the VwLeadGetJoEllenDataSource.
		/// </summary>
		protected VwLeadGetJoEllenDataSourceView VwLeadGetJoEllenView
		{
			get { return ( View as VwLeadGetJoEllenDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwLeadGetJoEllenDataSourceView class that is to be
		/// used by the VwLeadGetJoEllenDataSource.
		/// </summary>
		/// <returns>An instance of the VwLeadGetJoEllenDataSourceView class.</returns>
		protected override BaseDataSourceView<VwLeadGetJoEllen, Object> GetNewDataSourceView()
		{
			return new VwLeadGetJoEllenDataSourceView(this, DefaultViewName);
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
	/// Supports the VwLeadGetJoEllenDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwLeadGetJoEllenDataSourceView : ReadOnlyDataSourceView<VwLeadGetJoEllen>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJoEllenDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwLeadGetJoEllenDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwLeadGetJoEllenDataSourceView(VwLeadGetJoEllenDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwLeadGetJoEllenDataSource VwLeadGetJoEllenOwner
		{
			get { return Owner as VwLeadGetJoEllenDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwLeadGetJoEllenService VwLeadGetJoEllenProvider
		{
			get { return Provider as VwLeadGetJoEllenService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwLeadGetJoEllenDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwLeadGetJoEllenDataSource class.
	/// </summary>
	public class VwLeadGetJoEllenDataSourceDesigner : ReadOnlyDataSourceDesigner<VwLeadGetJoEllen>
	{
	}

	#endregion VwLeadGetJoEllenDataSourceDesigner

	#region VwLeadGetJoEllenFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetJoEllen"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetJoEllenFilter : SqlFilter<VwLeadGetJoEllenColumn>
	{
	}

	#endregion VwLeadGetJoEllenFilter

	#region VwLeadGetJoEllenExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetJoEllen"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetJoEllenExpressionBuilder : SqlExpressionBuilder<VwLeadGetJoEllenColumn>
	{
	}
	
	#endregion VwLeadGetJoEllenExpressionBuilder		
}

