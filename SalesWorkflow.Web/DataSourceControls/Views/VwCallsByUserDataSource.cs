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
	/// Represents the DataRepository.VwCallsByUserProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VwCallsByUserDataSourceDesigner))]
	public class VwCallsByUserDataSource : ReadOnlyDataSource<VwCallsByUser>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserDataSource class.
		/// </summary>
		public VwCallsByUserDataSource() : base(new VwCallsByUserService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VwCallsByUserDataSourceView used by the VwCallsByUserDataSource.
		/// </summary>
		protected VwCallsByUserDataSourceView VwCallsByUserView
		{
			get { return ( View as VwCallsByUserDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VwCallsByUserDataSourceView class that is to be
		/// used by the VwCallsByUserDataSource.
		/// </summary>
		/// <returns>An instance of the VwCallsByUserDataSourceView class.</returns>
		protected override BaseDataSourceView<VwCallsByUser, Object> GetNewDataSourceView()
		{
			return new VwCallsByUserDataSourceView(this, DefaultViewName);
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
	/// Supports the VwCallsByUserDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VwCallsByUserDataSourceView : ReadOnlyDataSourceView<VwCallsByUser>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VwCallsByUserDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VwCallsByUserDataSourceView(VwCallsByUserDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VwCallsByUserDataSource VwCallsByUserOwner
		{
			get { return Owner as VwCallsByUserDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VwCallsByUserService VwCallsByUserProvider
		{
			get { return Provider as VwCallsByUserService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VwCallsByUserDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VwCallsByUserDataSource class.
	/// </summary>
	public class VwCallsByUserDataSourceDesigner : ReadOnlyDataSourceDesigner<VwCallsByUser>
	{
	}

	#endregion VwCallsByUserDataSourceDesigner

	#region VwCallsByUserFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallsByUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallsByUserFilter : SqlFilter<VwCallsByUserColumn>
	{
	}

	#endregion VwCallsByUserFilter

	#region VwCallsByUserExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallsByUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallsByUserExpressionBuilder : SqlExpressionBuilder<VwCallsByUserColumn>
	{
	}
	
	#endregion VwCallsByUserExpressionBuilder		
}

