﻿
/*
	File generated by NetTiers templates [www.nettiers.net]
	Generated on : Thursday, May 12, 2016
	Important: Do not modify this file. Edit the file VwCallableLeadsWithCallsAndPeriod.cs instead.
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

using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Entities.Validation;
using Entities = SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Data;
using SiH_SalesWorkflow.Data.Bases;


using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion 

namespace SiH_SalesWorkflow
{		
	
	///<summary>
	/// An object representation of the 'vw_CallableLeadsWithCallsAndPeriod' View.
	///</summary>
	/// <remarks>
	/// IMPORTANT!!! You should not modify this partial  class, modify the VwCallableLeadsWithCallsAndPeriod.cs file instead.
	/// All custom implementations should be done in the <see cref="VwCallableLeadsWithCallsAndPeriod"/> class.
	/// </remarks>
	[DataObject]
	public partial class VwCallableLeadsWithCallsAndPeriodServiceBase : ServiceViewBase<VwCallableLeadsWithCallsAndPeriod>
	{

		#region Constructors
		///<summary>
		/// Creates a new <see cref="VwCallableLeadsWithCallsAndPeriod"/> instance .
		///</summary>
		public VwCallableLeadsWithCallsAndPeriodServiceBase() : base()
		{
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="VwCallableLeadsWithCallsAndPeriod"/> instance.
		///</summary>
		///<param name="_leadid"></param>
		///<param name="_firstName"></param>
		///<param name="_lastName"></param>
		///<param name="_phone"></param>
		///<param name="_callStartTime"></param>
		///<param name="_hour"></param>
		///<param name="_daytype"></param>
		///<param name="_timeZone"></param>
		///<param name="_hourAdj"></param>
		///<param name="_period"></param>
		///<param name="_createdTime"></param>
		public static VwCallableLeadsWithCallsAndPeriod CreateVwCallableLeadsWithCallsAndPeriod(System.String _leadid, System.String _firstName, System.String _lastName, System.String _phone, System.DateTime? _callStartTime, System.Int32? _hour, System.String _daytype, System.String _timeZone, System.Int32? _hourAdj, System.String _period, System.DateTime? _createdTime)
		{
			VwCallableLeadsWithCallsAndPeriod newEntityVwCallableLeadsWithCallsAndPeriod = new VwCallableLeadsWithCallsAndPeriod();
			newEntityVwCallableLeadsWithCallsAndPeriod.Leadid  = _leadid;
			newEntityVwCallableLeadsWithCallsAndPeriod.FirstName  = _firstName;
			newEntityVwCallableLeadsWithCallsAndPeriod.LastName  = _lastName;
			newEntityVwCallableLeadsWithCallsAndPeriod.Phone  = _phone;
			newEntityVwCallableLeadsWithCallsAndPeriod.CallStartTime  = _callStartTime;
			newEntityVwCallableLeadsWithCallsAndPeriod.Hour  = _hour;
			newEntityVwCallableLeadsWithCallsAndPeriod.Daytype  = _daytype;
			newEntityVwCallableLeadsWithCallsAndPeriod.TimeZone  = _timeZone;
			newEntityVwCallableLeadsWithCallsAndPeriod.HourAdj  = _hourAdj;
			newEntityVwCallableLeadsWithCallsAndPeriod.Period  = _period;
			newEntityVwCallableLeadsWithCallsAndPeriod.CreatedTime  = _createdTime;
			return newEntityVwCallableLeadsWithCallsAndPeriod;
		}
		#endregion Constructors

		#region Fields
		//private static SecurityContext<VwCallableLeadsWithCallsAndPeriod> securityContext = new SecurityContext<VwCallableLeadsWithCallsAndPeriod>();
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
		public override VList<VwCallableLeadsWithCallsAndPeriod> Get(string whereClause, string orderBy)
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
		/// <returns>Returns a typed collection TList{VwCallableLeadsWithCallsAndPeriod} of <c>VwCallableLeadsWithCallsAndPeriod</c> objects.</returns>
		public override VList<VwCallableLeadsWithCallsAndPeriod> Get(string whereClause, string orderBy, int start, int pageLength, out int totalCount)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("Get");
								
			// get this data
			VList<VwCallableLeadsWithCallsAndPeriod> list = null;
			totalCount = -1;
			TransactionManager transactionManager = null; 

			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
					
				//Access repository
				list = dataProvider.VwCallableLeadsWithCallsAndPeriodProvider.Get(transactionManager, whereClause, orderBy, start, pageLength, out totalCount);
				
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
		/// Get a complete collection of <see cref="VwCallableLeadsWithCallsAndPeriod" /> entities.
		/// </summary>
		/// <returns></returns>
		public virtual VList<VwCallableLeadsWithCallsAndPeriod> GetAll() 
		{
			int totalCount = -1;
			return GetAll(0, defaultMaxRecords, out totalCount);
		}

       
		/// <summary>
		/// Get a set portion of a complete list of <see cref="VwCallableLeadsWithCallsAndPeriod" /> entities
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">out parameter, number of total rows in given query.</param>
		/// <returns>a <see cref="TList{VwCallableLeadsWithCallsAndPeriod}"/> </returns>
		public override VList<VwCallableLeadsWithCallsAndPeriod> GetAll(int start, int pageLength, out int totalCount) 
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("GetAll");
			
			// get this data
			VList<VwCallableLeadsWithCallsAndPeriod> list = null;
			totalCount = -1;
			TransactionManager transactionManager = null; 

			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;					

				//Access repository
				list = dataProvider.VwCallableLeadsWithCallsAndPeriodProvider.GetAll(transactionManager, start, pageLength, out totalCount);	
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
		/// Gets a page of <see cref="TList{VwCallableLeadsWithCallsAndPeriod}" /> rows from the DataSource.
		/// </summary>
		/// <param name="totalCount">Out Parameter, Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of <c>VwCallableLeadsWithCallsAndPeriod</c> objects.</returns>
		public virtual VList<VwCallableLeadsWithCallsAndPeriod> GetPaged(out int totalCount)
		{
			return GetPaged(null, null, 0, defaultMaxRecords, out totalCount);
		}
		
		/// <summary>
		/// Gets a page of <see cref="TList{VwCallableLeadsWithCallsAndPeriod}" /> rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of <c>VwCallableLeadsWithCallsAndPeriod</c> objects.</returns>
		public virtual VList<VwCallableLeadsWithCallsAndPeriod> GetPaged(int start, int pageLength, out int totalCount)
		{
			return GetPaged(null, null, start, pageLength, out totalCount);
		}

		/// <summary>
		/// Gets a page of entity rows with a <see cref="TList{VwCallableLeadsWithCallsAndPeriod}" /> from the DataSource with a where clause and order by clause.
		/// </summary>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC).</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="totalCount">Out Parameter, Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of <c>VwCallableLeadsWithCallsAndPeriod</c> objects.</returns>
		public override VList<VwCallableLeadsWithCallsAndPeriod> GetPaged(string whereClause,string orderBy, int start, int pageLength, out int totalCount)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("GetPaged");
			
			// get this data
			VList<VwCallableLeadsWithCallsAndPeriod> list = null;
			totalCount = -1;
			TransactionManager transactionManager = null; 

			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
					
				//Access repository
				list = dataProvider.VwCallableLeadsWithCallsAndPeriodProvider.GetPaged(transactionManager, whereClause, orderBy, start, pageLength, out totalCount);
				
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
		/// <returns>Returns a typed collection of <c>VwCallableLeadsWithCallsAndPeriod</c> objects.</returns>
		public virtual VList<VwCallableLeadsWithCallsAndPeriod> Find(IFilterParameterCollection parameters)
		{
			return Find(parameters, null);
		}
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <returns>Returns a typed collection of <c>VwCallableLeadsWithCallsAndPeriod</c> objects.</returns>
		public virtual VList<VwCallableLeadsWithCallsAndPeriod> Find(IFilterParameterCollection parameters, string orderBy)
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
		/// <returns>Returns a typed collection of <c>VwCallableLeadsWithCallsAndPeriod</c> objects.</returns>
		public override VList<VwCallableLeadsWithCallsAndPeriod> Find(IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			// throws security exception if not authorized
			//SecurityContext.IsAuthorized("Find");
								
			// get this data
			TransactionManager transactionManager = null; 
			VList<VwCallableLeadsWithCallsAndPeriod> list = null;
			count = -1;
			
			try
            {	
				//since this is a read operation, don't create a tran by default, only use tran if provided to us for custom isolation level
				transactionManager = ConnectionScope.ValidateOrCreateTransaction(noTranByDefault);
				NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
					
				//Access repository
				list = dataProvider.VwCallableLeadsWithCallsAndPeriodProvider.Find(transactionManager, parameters, orderBy, start, pageLength, out count);
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



