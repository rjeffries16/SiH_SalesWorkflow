#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Data;

#endregion

namespace SiH_SalesWorkflow.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ZohoLeadsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ZohoLeadsProviderBaseCore : EntityProviderBase<SiH_SalesWorkflow.Entities.ZohoLeads, SiH_SalesWorkflow.Entities.ZohoLeadsKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.ZohoLeadsKey key)
		{
			return Delete(transactionManager, key.Leadpk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_leadpk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _leadpk)
		{
			return Delete(null, _leadpk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadpk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _leadpk);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override SiH_SalesWorkflow.Entities.ZohoLeads Get(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.ZohoLeadsKey key, int start, int pageLength)
		{
			return GetByLeadpk(transactionManager, key.Leadpk, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key LEADIDINDEX index.
		/// </summary>
		/// <param name="_leadid"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoLeads&gt;"/> class.</returns>
		public TList<ZohoLeads> GetByLeadid(System.String _leadid)
		{
			int count = -1;
			return GetByLeadid(null,_leadid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LEADIDINDEX index.
		/// </summary>
		/// <param name="_leadid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoLeads&gt;"/> class.</returns>
		public TList<ZohoLeads> GetByLeadid(System.String _leadid, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadid(null, _leadid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LEADIDINDEX index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoLeads&gt;"/> class.</returns>
		public TList<ZohoLeads> GetByLeadid(TransactionManager transactionManager, System.String _leadid)
		{
			int count = -1;
			return GetByLeadid(transactionManager, _leadid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LEADIDINDEX index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoLeads&gt;"/> class.</returns>
		public TList<ZohoLeads> GetByLeadid(TransactionManager transactionManager, System.String _leadid, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadid(transactionManager, _leadid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LEADIDINDEX index.
		/// </summary>
		/// <param name="_leadid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoLeads&gt;"/> class.</returns>
		public TList<ZohoLeads> GetByLeadid(System.String _leadid, int start, int pageLength, out int count)
		{
			return GetByLeadid(null, _leadid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the LEADIDINDEX index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoLeads&gt;"/> class.</returns>
		public abstract TList<ZohoLeads> GetByLeadid(TransactionManager transactionManager, System.String _leadid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZohoLeads index.
		/// </summary>
		/// <param name="_leadpk"></param>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> class.</returns>
		public SiH_SalesWorkflow.Entities.ZohoLeads GetByLeadpk(System.Int64 _leadpk)
		{
			int count = -1;
			return GetByLeadpk(null,_leadpk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoLeads index.
		/// </summary>
		/// <param name="_leadpk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> class.</returns>
		public SiH_SalesWorkflow.Entities.ZohoLeads GetByLeadpk(System.Int64 _leadpk, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadpk(null, _leadpk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoLeads index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadpk"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> class.</returns>
		public SiH_SalesWorkflow.Entities.ZohoLeads GetByLeadpk(TransactionManager transactionManager, System.Int64 _leadpk)
		{
			int count = -1;
			return GetByLeadpk(transactionManager, _leadpk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoLeads index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadpk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> class.</returns>
		public SiH_SalesWorkflow.Entities.ZohoLeads GetByLeadpk(TransactionManager transactionManager, System.Int64 _leadpk, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadpk(transactionManager, _leadpk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoLeads index.
		/// </summary>
		/// <param name="_leadpk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> class.</returns>
		public SiH_SalesWorkflow.Entities.ZohoLeads GetByLeadpk(System.Int64 _leadpk, int start, int pageLength, out int count)
		{
			return GetByLeadpk(null, _leadpk, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoLeads index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadpk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> class.</returns>
		public abstract SiH_SalesWorkflow.Entities.ZohoLeads GetByLeadpk(TransactionManager transactionManager, System.Int64 _leadpk, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ZohoLeads&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ZohoLeads&gt;"/></returns>
		public static TList<ZohoLeads> Fill(IDataReader reader, TList<ZohoLeads> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				SiH_SalesWorkflow.Entities.ZohoLeads c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ZohoLeads")
					.Append("|").Append((System.Int64)reader[((int)ZohoLeadsColumn.Leadpk - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ZohoLeads>(
					key.ToString(), // EntityTrackingKey
					"ZohoLeads",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SiH_SalesWorkflow.Entities.ZohoLeads();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.ActivitiesInvolved = (System.Boolean)reader[((int)ZohoLeadsColumn.ActivitiesInvolved - 1)];
					c.CallsInvolved = (System.Boolean)reader[((int)ZohoLeadsColumn.CallsInvolved - 1)];
					c.Company = (reader.IsDBNull(((int)ZohoLeadsColumn.Company - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Company - 1)];
					c.Converted = (System.Boolean)reader[((int)ZohoLeadsColumn.Converted - 1)];
					c.CreatedBy = (reader.IsDBNull(((int)ZohoLeadsColumn.CreatedBy - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.CreatedBy - 1)];
					c.CreatedTime = (reader.IsDBNull(((int)ZohoLeadsColumn.CreatedTime - 1)))?null:(System.DateTime?)reader[((int)ZohoLeadsColumn.CreatedTime - 1)];
					c.Email = (reader.IsDBNull(((int)ZohoLeadsColumn.Email - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Email - 1)];
					c.EmailOptOut = (System.Boolean)reader[((int)ZohoLeadsColumn.EmailOptOut - 1)];
					c.EventsInvolved = (System.Boolean)reader[((int)ZohoLeadsColumn.EventsInvolved - 1)];
					c.FeaturesOfInterest = (reader.IsDBNull(((int)ZohoLeadsColumn.FeaturesOfInterest - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.FeaturesOfInterest - 1)];
					c.FirstName = (reader.IsDBNull(((int)ZohoLeadsColumn.FirstName - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.FirstName - 1)];
					c.SafeNameFirstTimeCallerNewLead = (System.Boolean)reader[((int)ZohoLeadsColumn.SafeNameFirstTimeCallerNewLead - 1)];
					c.IfNoLongerInterested = (reader.IsDBNull(((int)ZohoLeadsColumn.IfNoLongerInterested - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.IfNoLongerInterested - 1)];
					c.Industry = (reader.IsDBNull(((int)ZohoLeadsColumn.Industry - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Industry - 1)];
					c.LastActivityTime = (reader.IsDBNull(((int)ZohoLeadsColumn.LastActivityTime - 1)))?null:(System.DateTime?)reader[((int)ZohoLeadsColumn.LastActivityTime - 1)];
					c.LastName = (reader.IsDBNull(((int)ZohoLeadsColumn.LastName - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LastName - 1)];
					c.LastVisitedTime = (reader.IsDBNull(((int)ZohoLeadsColumn.LastVisitedTime - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LastVisitedTime - 1)];
					c.LeadOwnerId = (reader.IsDBNull(((int)ZohoLeadsColumn.LeadOwnerId - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LeadOwnerId - 1)];
					c.LeadOwner = (reader.IsDBNull(((int)ZohoLeadsColumn.LeadOwner - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LeadOwner - 1)];
					c.LeadSource = (reader.IsDBNull(((int)ZohoLeadsColumn.LeadSource - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LeadSource - 1)];
					c.LeadStatus = (reader.IsDBNull(((int)ZohoLeadsColumn.LeadStatus - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LeadStatus - 1)];
					c.Leadid = (reader.IsDBNull(((int)ZohoLeadsColumn.Leadid - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Leadid - 1)];
					c.Mobile = (reader.IsDBNull(((int)ZohoLeadsColumn.Mobile - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Mobile - 1)];
					c.ModifiedBy = (reader.IsDBNull(((int)ZohoLeadsColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.ModifiedBy - 1)];
					c.ModifiedTime = (reader.IsDBNull(((int)ZohoLeadsColumn.ModifiedTime - 1)))?null:(System.DateTime?)reader[((int)ZohoLeadsColumn.ModifiedTime - 1)];
					c.Phone = (reader.IsDBNull(((int)ZohoLeadsColumn.Phone - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Phone - 1)];
					c.Rating = (reader.IsDBNull(((int)ZohoLeadsColumn.Rating - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Rating - 1)];
					c.SecondaryEmail = (reader.IsDBNull(((int)ZohoLeadsColumn.SecondaryEmail - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.SecondaryEmail - 1)];
					c.State = (reader.IsDBNull(((int)ZohoLeadsColumn.State - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.State - 1)];
					c.SubmissionTime = (reader.IsDBNull(((int)ZohoLeadsColumn.SubmissionTime - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.SubmissionTime - 1)];
					c.SubmittedOn = (reader.IsDBNull(((int)ZohoLeadsColumn.SubmittedOn - 1)))?null:(System.DateTime?)reader[((int)ZohoLeadsColumn.SubmittedOn - 1)];
					c.TasksInvolved = (System.Boolean)reader[((int)ZohoLeadsColumn.TasksInvolved - 1)];
					c.TimeZone = (reader.IsDBNull(((int)ZohoLeadsColumn.TimeZone - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.TimeZone - 1)];
					c.Url = (reader.IsDBNull(((int)ZohoLeadsColumn.Url - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Url - 1)];
					c.Website = (reader.IsDBNull(((int)ZohoLeadsColumn.Website - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Website - 1)];
					c.Worries = (reader.IsDBNull(((int)ZohoLeadsColumn.Worries - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Worries - 1)];
					c.Leadpk = (System.Int64)reader[((int)ZohoLeadsColumn.Leadpk - 1)];
					c.Wday811 = (reader.IsDBNull(((int)ZohoLeadsColumn.Wday811 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Wday811 - 1)];
					c.Wday112 = (reader.IsDBNull(((int)ZohoLeadsColumn.Wday112 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Wday112 - 1)];
					c.Wday25 = (reader.IsDBNull(((int)ZohoLeadsColumn.Wday25 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Wday25 - 1)];
					c.Wday58 = (reader.IsDBNull(((int)ZohoLeadsColumn.Wday58 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Wday58 - 1)];
					c.Sat811 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sat811 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sat811 - 1)];
					c.Sat112 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sat112 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sat112 - 1)];
					c.Sat25 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sat25 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sat25 - 1)];
					c.Sat58 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sat58 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sat58 - 1)];
					c.Sun811 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sun811 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sun811 - 1)];
					c.Sun112 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sun112 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sun112 - 1)];
					c.Sun25 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sun25 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sun25 - 1)];
					c.Sun58 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sun58 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sun58 - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SiH_SalesWorkflow.Entities.ZohoLeads entity)
		{
			if (!reader.Read()) return;
			
			entity.ActivitiesInvolved = (System.Boolean)reader[((int)ZohoLeadsColumn.ActivitiesInvolved - 1)];
			entity.CallsInvolved = (System.Boolean)reader[((int)ZohoLeadsColumn.CallsInvolved - 1)];
			entity.Company = (reader.IsDBNull(((int)ZohoLeadsColumn.Company - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Company - 1)];
			entity.Converted = (System.Boolean)reader[((int)ZohoLeadsColumn.Converted - 1)];
			entity.CreatedBy = (reader.IsDBNull(((int)ZohoLeadsColumn.CreatedBy - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.CreatedBy - 1)];
			entity.CreatedTime = (reader.IsDBNull(((int)ZohoLeadsColumn.CreatedTime - 1)))?null:(System.DateTime?)reader[((int)ZohoLeadsColumn.CreatedTime - 1)];
			entity.Email = (reader.IsDBNull(((int)ZohoLeadsColumn.Email - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Email - 1)];
			entity.EmailOptOut = (System.Boolean)reader[((int)ZohoLeadsColumn.EmailOptOut - 1)];
			entity.EventsInvolved = (System.Boolean)reader[((int)ZohoLeadsColumn.EventsInvolved - 1)];
			entity.FeaturesOfInterest = (reader.IsDBNull(((int)ZohoLeadsColumn.FeaturesOfInterest - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.FeaturesOfInterest - 1)];
			entity.FirstName = (reader.IsDBNull(((int)ZohoLeadsColumn.FirstName - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.FirstName - 1)];
			entity.SafeNameFirstTimeCallerNewLead = (System.Boolean)reader[((int)ZohoLeadsColumn.SafeNameFirstTimeCallerNewLead - 1)];
			entity.IfNoLongerInterested = (reader.IsDBNull(((int)ZohoLeadsColumn.IfNoLongerInterested - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.IfNoLongerInterested - 1)];
			entity.Industry = (reader.IsDBNull(((int)ZohoLeadsColumn.Industry - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Industry - 1)];
			entity.LastActivityTime = (reader.IsDBNull(((int)ZohoLeadsColumn.LastActivityTime - 1)))?null:(System.DateTime?)reader[((int)ZohoLeadsColumn.LastActivityTime - 1)];
			entity.LastName = (reader.IsDBNull(((int)ZohoLeadsColumn.LastName - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LastName - 1)];
			entity.LastVisitedTime = (reader.IsDBNull(((int)ZohoLeadsColumn.LastVisitedTime - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LastVisitedTime - 1)];
			entity.LeadOwnerId = (reader.IsDBNull(((int)ZohoLeadsColumn.LeadOwnerId - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LeadOwnerId - 1)];
			entity.LeadOwner = (reader.IsDBNull(((int)ZohoLeadsColumn.LeadOwner - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LeadOwner - 1)];
			entity.LeadSource = (reader.IsDBNull(((int)ZohoLeadsColumn.LeadSource - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LeadSource - 1)];
			entity.LeadStatus = (reader.IsDBNull(((int)ZohoLeadsColumn.LeadStatus - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.LeadStatus - 1)];
			entity.Leadid = (reader.IsDBNull(((int)ZohoLeadsColumn.Leadid - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Leadid - 1)];
			entity.Mobile = (reader.IsDBNull(((int)ZohoLeadsColumn.Mobile - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Mobile - 1)];
			entity.ModifiedBy = (reader.IsDBNull(((int)ZohoLeadsColumn.ModifiedBy - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.ModifiedBy - 1)];
			entity.ModifiedTime = (reader.IsDBNull(((int)ZohoLeadsColumn.ModifiedTime - 1)))?null:(System.DateTime?)reader[((int)ZohoLeadsColumn.ModifiedTime - 1)];
			entity.Phone = (reader.IsDBNull(((int)ZohoLeadsColumn.Phone - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Phone - 1)];
			entity.Rating = (reader.IsDBNull(((int)ZohoLeadsColumn.Rating - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Rating - 1)];
			entity.SecondaryEmail = (reader.IsDBNull(((int)ZohoLeadsColumn.SecondaryEmail - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.SecondaryEmail - 1)];
			entity.State = (reader.IsDBNull(((int)ZohoLeadsColumn.State - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.State - 1)];
			entity.SubmissionTime = (reader.IsDBNull(((int)ZohoLeadsColumn.SubmissionTime - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.SubmissionTime - 1)];
			entity.SubmittedOn = (reader.IsDBNull(((int)ZohoLeadsColumn.SubmittedOn - 1)))?null:(System.DateTime?)reader[((int)ZohoLeadsColumn.SubmittedOn - 1)];
			entity.TasksInvolved = (System.Boolean)reader[((int)ZohoLeadsColumn.TasksInvolved - 1)];
			entity.TimeZone = (reader.IsDBNull(((int)ZohoLeadsColumn.TimeZone - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.TimeZone - 1)];
			entity.Url = (reader.IsDBNull(((int)ZohoLeadsColumn.Url - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Url - 1)];
			entity.Website = (reader.IsDBNull(((int)ZohoLeadsColumn.Website - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Website - 1)];
			entity.Worries = (reader.IsDBNull(((int)ZohoLeadsColumn.Worries - 1)))?null:(System.String)reader[((int)ZohoLeadsColumn.Worries - 1)];
			entity.Leadpk = (System.Int64)reader[((int)ZohoLeadsColumn.Leadpk - 1)];
			entity.Wday811 = (reader.IsDBNull(((int)ZohoLeadsColumn.Wday811 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Wday811 - 1)];
			entity.Wday112 = (reader.IsDBNull(((int)ZohoLeadsColumn.Wday112 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Wday112 - 1)];
			entity.Wday25 = (reader.IsDBNull(((int)ZohoLeadsColumn.Wday25 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Wday25 - 1)];
			entity.Wday58 = (reader.IsDBNull(((int)ZohoLeadsColumn.Wday58 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Wday58 - 1)];
			entity.Sat811 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sat811 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sat811 - 1)];
			entity.Sat112 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sat112 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sat112 - 1)];
			entity.Sat25 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sat25 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sat25 - 1)];
			entity.Sat58 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sat58 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sat58 - 1)];
			entity.Sun811 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sun811 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sun811 - 1)];
			entity.Sun112 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sun112 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sun112 - 1)];
			entity.Sun25 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sun25 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sun25 - 1)];
			entity.Sun58 = (reader.IsDBNull(((int)ZohoLeadsColumn.Sun58 - 1)))?null:(System.Int32?)reader[((int)ZohoLeadsColumn.Sun58 - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SiH_SalesWorkflow.Entities.ZohoLeads entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ActivitiesInvolved = (System.Boolean)dataRow["Activities Involved"];
			entity.CallsInvolved = (System.Boolean)dataRow["Calls Involved"];
			entity.Company = Convert.IsDBNull(dataRow["Company"]) ? null : (System.String)dataRow["Company"];
			entity.Converted = (System.Boolean)dataRow["CONVERTED"];
			entity.CreatedBy = Convert.IsDBNull(dataRow["Created By"]) ? null : (System.String)dataRow["Created By"];
			entity.CreatedTime = Convert.IsDBNull(dataRow["Created Time"]) ? null : (System.DateTime?)dataRow["Created Time"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.EmailOptOut = (System.Boolean)dataRow["Email Opt Out"];
			entity.EventsInvolved = (System.Boolean)dataRow["Events Involved"];
			entity.FeaturesOfInterest = Convert.IsDBNull(dataRow["Features of Interest"]) ? null : (System.String)dataRow["Features of Interest"];
			entity.FirstName = Convert.IsDBNull(dataRow["First Name"]) ? null : (System.String)dataRow["First Name"];
			entity.SafeNameFirstTimeCallerNewLead = (System.Boolean)dataRow["First Time Caller (new lead)"];
			entity.IfNoLongerInterested = Convert.IsDBNull(dataRow["If No Longer Interested"]) ? null : (System.String)dataRow["If No Longer Interested"];
			entity.Industry = Convert.IsDBNull(dataRow["Industry"]) ? null : (System.String)dataRow["Industry"];
			entity.LastActivityTime = Convert.IsDBNull(dataRow["Last Activity Time"]) ? null : (System.DateTime?)dataRow["Last Activity Time"];
			entity.LastName = Convert.IsDBNull(dataRow["Last Name"]) ? null : (System.String)dataRow["Last Name"];
			entity.LastVisitedTime = Convert.IsDBNull(dataRow["Last Visited Time"]) ? null : (System.String)dataRow["Last Visited Time"];
			entity.LeadOwnerId = Convert.IsDBNull(dataRow["Lead Owner Id"]) ? null : (System.String)dataRow["Lead Owner Id"];
			entity.LeadOwner = Convert.IsDBNull(dataRow["Lead Owner"]) ? null : (System.String)dataRow["Lead Owner"];
			entity.LeadSource = Convert.IsDBNull(dataRow["Lead Source"]) ? null : (System.String)dataRow["Lead Source"];
			entity.LeadStatus = Convert.IsDBNull(dataRow["Lead Status"]) ? null : (System.String)dataRow["Lead Status"];
			entity.Leadid = Convert.IsDBNull(dataRow["LEADID"]) ? null : (System.String)dataRow["LEADID"];
			entity.Mobile = Convert.IsDBNull(dataRow["Mobile"]) ? null : (System.String)dataRow["Mobile"];
			entity.ModifiedBy = Convert.IsDBNull(dataRow["Modified By"]) ? null : (System.String)dataRow["Modified By"];
			entity.ModifiedTime = Convert.IsDBNull(dataRow["Modified Time"]) ? null : (System.DateTime?)dataRow["Modified Time"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.Rating = Convert.IsDBNull(dataRow["Rating"]) ? null : (System.String)dataRow["Rating"];
			entity.SecondaryEmail = Convert.IsDBNull(dataRow["Secondary Email"]) ? null : (System.String)dataRow["Secondary Email"];
			entity.State = Convert.IsDBNull(dataRow["State"]) ? null : (System.String)dataRow["State"];
			entity.SubmissionTime = Convert.IsDBNull(dataRow["Submission Time"]) ? null : (System.String)dataRow["Submission Time"];
			entity.SubmittedOn = Convert.IsDBNull(dataRow["Submitted On"]) ? null : (System.DateTime?)dataRow["Submitted On"];
			entity.TasksInvolved = (System.Boolean)dataRow["Tasks Involved"];
			entity.TimeZone = Convert.IsDBNull(dataRow["Time Zone"]) ? null : (System.String)dataRow["Time Zone"];
			entity.Url = Convert.IsDBNull(dataRow["URL"]) ? null : (System.String)dataRow["URL"];
			entity.Website = Convert.IsDBNull(dataRow["Website"]) ? null : (System.String)dataRow["Website"];
			entity.Worries = Convert.IsDBNull(dataRow["Worries"]) ? null : (System.String)dataRow["Worries"];
			entity.Leadpk = (System.Int64)dataRow["LEADPK"];
			entity.Wday811 = Convert.IsDBNull(dataRow["WDay8-11"]) ? null : (System.Int32?)dataRow["WDay8-11"];
			entity.Wday112 = Convert.IsDBNull(dataRow["WDay11-2"]) ? null : (System.Int32?)dataRow["WDay11-2"];
			entity.Wday25 = Convert.IsDBNull(dataRow["WDay2-5"]) ? null : (System.Int32?)dataRow["WDay2-5"];
			entity.Wday58 = Convert.IsDBNull(dataRow["WDay5-8"]) ? null : (System.Int32?)dataRow["WDay5-8"];
			entity.Sat811 = Convert.IsDBNull(dataRow["Sat8-11"]) ? null : (System.Int32?)dataRow["Sat8-11"];
			entity.Sat112 = Convert.IsDBNull(dataRow["Sat11-2"]) ? null : (System.Int32?)dataRow["Sat11-2"];
			entity.Sat25 = Convert.IsDBNull(dataRow["Sat2-5"]) ? null : (System.Int32?)dataRow["Sat2-5"];
			entity.Sat58 = Convert.IsDBNull(dataRow["Sat5-8"]) ? null : (System.Int32?)dataRow["Sat5-8"];
			entity.Sun811 = Convert.IsDBNull(dataRow["Sun8-11"]) ? null : (System.Int32?)dataRow["Sun8-11"];
			entity.Sun112 = Convert.IsDBNull(dataRow["Sun11-2"]) ? null : (System.Int32?)dataRow["Sun11-2"];
			entity.Sun25 = Convert.IsDBNull(dataRow["Sun2-5"]) ? null : (System.Int32?)dataRow["Sun2-5"];
			entity.Sun58 = Convert.IsDBNull(dataRow["Sun5-8"]) ? null : (System.Int32?)dataRow["Sun5-8"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="SiH_SalesWorkflow.Entities.ZohoLeads"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SiH_SalesWorkflow.Entities.ZohoLeads Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.ZohoLeads entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the SiH_SalesWorkflow.Entities.ZohoLeads object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SiH_SalesWorkflow.Entities.ZohoLeads instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SiH_SalesWorkflow.Entities.ZohoLeads Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.ZohoLeads entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region ZohoLeadsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SiH_SalesWorkflow.Entities.ZohoLeads</c>
	///</summary>
	public enum ZohoLeadsChildEntityTypes
	{
	}
	
	#endregion ZohoLeadsChildEntityTypes
	
	#region ZohoLeadsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ZohoLeadsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoLeadsFilterBuilder : SqlFilterBuilder<ZohoLeadsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsFilterBuilder class.
		/// </summary>
		public ZohoLeadsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoLeadsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoLeadsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoLeadsFilterBuilder
	
	#region ZohoLeadsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ZohoLeadsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoLeadsParameterBuilder : ParameterizedSqlFilterBuilder<ZohoLeadsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsParameterBuilder class.
		/// </summary>
		public ZohoLeadsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoLeadsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoLeadsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoLeadsParameterBuilder
	
	#region ZohoLeadsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ZohoLeadsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoLeads"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ZohoLeadsSortBuilder : SqlSortBuilder<ZohoLeadsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsSqlSortBuilder class.
		/// </summary>
		public ZohoLeadsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ZohoLeadsSortBuilder
	
} // end namespace
