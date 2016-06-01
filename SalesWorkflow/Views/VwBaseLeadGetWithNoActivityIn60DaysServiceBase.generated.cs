﻿
/*
	File generated by NetTiers templates [www.nettiers.net]
	Generated on : Thursday, May 12, 2016
	Important: Do not modify this file. Edit the file VwBaseLeadGetWithNoActivityIn60Days.cs instead.
*/

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Security;
using System.Data;

using SalesWorkflow.Entities;
using SalesWorkflow.Entities.Validation;
using Entities = SalesWorkflow.Entities;
using SalesWorkflow.Data;
using SalesWorkflow.Data.Bases;


using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion 

namespace SalesWorkflow
{		
	
	///<summary>
	/// An object representation of the 'vw_BaseLeadGetWithNoActivityIn60Days' View.
	///</summary>
	/// <remarks>
	/// IMPORTANT!!! You should not modify this partial  class, modify the VwBaseLeadGetWithNoActivityIn60Days.cs file instead.
	/// All custom implementations should be done in the <see cref="VwBaseLeadGetWithNoActivityIn60Days"/> class.
	/// </remarks>
	[DataObject]
	public partial class VwBaseLeadGetWithNoActivityIn60DaysServiceBase : ServiceViewBase<VwBaseLeadGetWithNoActivityIn60Days>
	{

		#region Constructors
		///<summary>
		/// Creates a new <see cref="VwBaseLeadGetWithNoActivityIn60Days"/> instance .
		///</summary>
		public VwBaseLeadGetWithNoActivityIn60DaysServiceBase() : base()
		{
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="VwBaseLeadGetWithNoActivityIn60Days"/> instance.
		///</summary>
		///<param name="_createdBy"></param>
		///<param name="_createdTime"></param>
		///<param name="_firstName"></param>
		///<param name="_lastName"></param>
		///<param name="_ifNoLongerInterested"></param>
		///<param name="_lastActivityTime"></param>
		///<param name="_lastVisitedTime"></param>
		///<param name="_leadOwner"></param>
		///<param name="_leadSource"></param>
		///<param name="_leadStatus"></param>
		///<param name="_leadid"></param>
		///<param name="_rating"></param>
		///<param name="_state"></param>
		///<param name="_timeZone"></param>
		///<param name="_localTime"></param>
		///<param name="_url"></param>
		///<param name="_website"></param>
		///<param name="_worries"></param>
		///<param name="_leadpk"></param>
		///<param name="_wday811"></param>
		///<param name="_wday112"></param>
		///<param name="_wday25"></param>
		///<param name="_wday58"></param>
		///<param name="_sat811"></param>
		///<param name="_sat112"></param>
		///<param name="_sat25"></param>
		///<param name="_sat58"></param>
		///<param name="_sun811"></param>
		///<param name="_sun112"></param>
		///<param name="_sun25"></param>
		///<param name="_sun58"></param>
		///<param name="_leadOwnerId"></param>
		///<param name="_totalCalls"></param>
		public static VwBaseLeadGetWithNoActivityIn60Days CreateVwBaseLeadGetWithNoActivityIn60Days(System.String _createdBy, System.DateTime? _createdTime, System.String _firstName, System.String _lastName, System.String _ifNoLongerInterested, System.DateTime? _lastActivityTime, System.String _lastVisitedTime, System.String _leadOwner, System.String _leadSource, System.String _leadStatus, System.String _leadid, System.String _rating, System.String _state, System.String _timeZone, System.DateTime? _localTime, System.String _url, System.String _website, System.String _worries, System.Int64 _leadpk, System.Int32? _wday811, System.Int32? _wday112, System.Int32? _wday25, System.Int32? _wday58, System.Int32? _sat811, System.Int32? _sat112, System.Int32? _sat25, System.Int32? _sat58, System.Int32? _sun811, System.Int32? _sun112, System.Int32? _sun25, System.Int32? _sun58, System.String _leadOwnerId, System.Int32? _totalCalls)
		{
			VwBaseLeadGetWithNoActivityIn60Days newEntityVwBaseLeadGetWithNoActivityIn60Days = new VwBaseLeadGetWithNoActivityIn60Days();
			newEntityVwBaseLeadGetWithNoActivityIn60Days.CreatedBy  = _createdBy;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.CreatedTime  = _createdTime;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.FirstName  = _firstName;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.LastName  = _lastName;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.IfNoLongerInterested  = _ifNoLongerInterested;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.LastActivityTime  = _lastActivityTime;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.LastVisitedTime  = _lastVisitedTime;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.LeadOwner  = _leadOwner;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.LeadSource  = _leadSource;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.LeadStatus  = _leadStatus;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Leadid  = _leadid;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Rating  = _rating;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.State  = _state;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.TimeZone  = _timeZone;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.LocalTime  = _localTime;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Url  = _url;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Website  = _website;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Worries  = _worries;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Leadpk  = _leadpk;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Wday811  = _wday811;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Wday112  = _wday112;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Wday25  = _wday25;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Wday58  = _wday58;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Sat811  = _sat811;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Sat112  = _sat112;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Sat25  = _sat25;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Sat58  = _sat58;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Sun811  = _sun811;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Sun112  = _sun112;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Sun25  = _sun25;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.Sun58  = _sun58;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.LeadOwnerId  = _leadOwnerId;
			newEntityVwBaseLeadGetWithNoActivityIn60Days.TotalCalls  = _totalCalls;
			return newEntityVwBaseLeadGetWithNoActivityIn60Days;
		}
		#endregion Constructors

		#region Fields
		//private static SecurityContext<VwBaseLeadGetWithNoActivityIn60Days> securityContext = new SecurityContext<VwBaseLeadGetWithNoActivityIn60Days>();
		private static readonly string layerExceptionPolicy = "ServiceLayerExceptionPolicy";
		private static readonly bool noTranByDefault = false;
		private static readonly int defaultMaxRecords = 10000;
		#endregion 
		
		#region Data Access Methods
			
		#region Get 
		/// <summary>
		/// Attempts to do a parameterized version of a simple whereclause. 
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
        /// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <remarks>Does NOT Support Advanced Operations such as SubSelects.  See GetPaged for that functionality.</remarks>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		public override VList<VwBaseLeadGetWithNoActivityIn60Days> Get(string whereClause, string orderBy)
		{
			int totalCount = -1;
			return Get(whereClause, orderBy, 0, defaultMaxRecords, out totalCount);
		}

		/// <summary>
		/// Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
        /// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">out parameter to get total records for query</param>
		/// <remarks>Does NOT Support Advanced Operations such as SubSelects.  See GetPaged for that functionality.</remarks>
		/// <returns>Returns a typed collection TList{VwBaseLeadGetWithNoActivityIn60Days} of <c>VwBaseLeadGetWithNoActivityIn60Days</c> objects.</returns>
		public override VList<VwBaseLeadGetWithNoActivityIn60Days> Get(string whereClause, string orderBy, int start, int pageLength, out int totalCount)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("Get");
								
			// get this data
			VList<VwBaseLeadGetWithNoActivityIn60Days> list = null;
			totalCount = -1;
			TransactionManager transactionManager = null; 

			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
					
				//Access repository
				list = dataProvider.VwBaseLeadGetWithNoActivityIn60DaysProvider.Get(transactionManager, whereClause, orderBy, start, pageLength, out totalCount);
				
				//if borrowed tran, leave open for next call
			}
            catch (Exception exc)
            {
				//if open, rollback, it's possible this is part of a larger commit
                if (transactionManager != null && transactionManager.IsOpen) 
					transactionManager.Rollback();
				
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
			}
			return list;
		}
		
		#endregion Get Methods
		
		#region GetAll
		/// <summary>
		/// Get a complete collection of <see cref="VwBaseLeadGetWithNoActivityIn60Days" /> entities.
		/// </summary>
		/// <returns></returns>
		public virtual VList<VwBaseLeadGetWithNoActivityIn60Days> GetAll() 
		{
			int totalCount = -1;
			return GetAll(0, defaultMaxRecords, out totalCount);
		}

       
		/// <summary>
		/// Get a set portion of a complete list of <see cref="VwBaseLeadGetWithNoActivityIn60Days" /> entities
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">out parameter, number of total rows in given query.</param>
		/// <returns>a <see cref="TList{VwBaseLeadGetWithNoActivityIn60Days}"/> </returns>
		public override VList<VwBaseLeadGetWithNoActivityIn60Days> GetAll(int start, int pageLength, out int totalCount) 
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("GetAll");
			
			// get this data
			VList<VwBaseLeadGetWithNoActivityIn60Days> list = null;
			totalCount = -1;
			TransactionManager transactionManager = null; 

			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;					

				//Access repository
				list = dataProvider.VwBaseLeadGetWithNoActivityIn60DaysProvider.GetAll(transactionManager, start, pageLength, out totalCount);	
			}
            catch (Exception exc)
            {
				//if open, rollback, it's possible this is part of a larger commit
                if (transactionManager != null && transactionManager.IsOpen) 
					transactionManager.Rollback();
				
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
			}
			return list;
		}
		#endregion GetAll

		#region GetPaged
		/// <summary>
		/// Gets a page of <see cref="TList{VwBaseLeadGetWithNoActivityIn60Days}" /> rows from the DataSource.
		/// </summary>
		/// <param name="totalCount">Out Parameter, Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of <c>VwBaseLeadGetWithNoActivityIn60Days</c> objects.</returns>
		public virtual VList<VwBaseLeadGetWithNoActivityIn60Days> GetPaged(out int totalCount)
		{
			return GetPaged(null, null, 0, defaultMaxRecords, out totalCount);
		}
		
		/// <summary>
		/// Gets a page of <see cref="TList{VwBaseLeadGetWithNoActivityIn60Days}" /> rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of <c>VwBaseLeadGetWithNoActivityIn60Days</c> objects.</returns>
		public virtual VList<VwBaseLeadGetWithNoActivityIn60Days> GetPaged(int start, int pageLength, out int totalCount)
		{
			return GetPaged(null, null, start, pageLength, out totalCount);
		}

		/// <summary>
		/// Gets a page of entity rows with a <see cref="TList{VwBaseLeadGetWithNoActivityIn60Days}" /> from the DataSource with a where clause and order by clause.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC).</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">Out Parameter, Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of <c>VwBaseLeadGetWithNoActivityIn60Days</c> objects.</returns>
		public override VList<VwBaseLeadGetWithNoActivityIn60Days> GetPaged(string whereClause,string orderBy, int start, int pageLength, out int totalCount)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("GetPaged");
			
			// get this data
			VList<VwBaseLeadGetWithNoActivityIn60Days> list = null;
			totalCount = -1;
			TransactionManager transactionManager = null; 

			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
					
				//Access repository
				list = dataProvider.VwBaseLeadGetWithNoActivityIn60DaysProvider.GetPaged(transactionManager, whereClause, orderBy, start, pageLength, out totalCount);
				
				//if borrowed tran, leave open for next call
			}
            catch (Exception exc)
            {
				//if open, rollback, it's possible this is part of a larger commit
                if (transactionManager != null && transactionManager.IsOpen) 
					transactionManager.Rollback();
				
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
			}
			return list;			
		}
		
		/// <summary>
		/// Gets the number of rows in the DataSource that match the specified whereClause.
		/// This method is only provided as a workaround for the ObjectDataSource's need to 
		/// execute another method to discover the total count instead of using another param, like our out param.  
		/// This method should be avoided if using the ObjectDataSource or another method.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="totalCount">Number of rows in the DataSource.</param>
		/// <returns>Returns the number of rows.</returns>
		public int GetTotalItems(string whereClause, out int totalCount)
		{
			GetPaged(whereClause, null, 0, defaultMaxRecords, out totalCount);
			return totalCount;
		}
		#endregion GetPaged	

		#region Find Methods

		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <returns>Returns a typed collection of <c>VwBaseLeadGetWithNoActivityIn60Days</c> objects.</returns>
		public virtual VList<VwBaseLeadGetWithNoActivityIn60Days> Find(IFilterParameterCollection parameters)
		{
			return Find(parameters, null);
		}
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <returns>Returns a typed collection of <c>VwBaseLeadGetWithNoActivityIn60Days</c> objects.</returns>
		public virtual VList<VwBaseLeadGetWithNoActivityIn60Days> Find(IFilterParameterCollection parameters, string orderBy)
		{
			int count = 0;
			return Find(parameters, orderBy, 0, defaultMaxRecords, out count);
		}
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of <c>VwBaseLeadGetWithNoActivityIn60Days</c> objects.</returns>
		public override VList<VwBaseLeadGetWithNoActivityIn60Days> Find(IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("Find");
								
			// get this data
			TransactionManager transactionManager = null; 
			VList<VwBaseLeadGetWithNoActivityIn60Days> list = null;
			count = -1;
			
			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
					
				//Access repository
				list = dataProvider.VwBaseLeadGetWithNoActivityIn60DaysProvider.Find(transactionManager, parameters, orderBy, start, pageLength, out count);
			}
            catch (Exception exc)
            {
				//if open, rollback, it's possible this is part of a larger commit
                if (transactionManager != null && transactionManager.IsOpen) 
					transactionManager.Rollback();
				
				//Handle exception based on policy
                if (DomainUtil.HandleException(exc, layerExceptionPolicy)) 
					throw;
			}
			
			return list;
		}
		
		#endregion Find Methods
		
		#region Custom Methods
		#endregion
		
		#endregion Data Access Methods
		
	
	}//End Class
} // end namespace



