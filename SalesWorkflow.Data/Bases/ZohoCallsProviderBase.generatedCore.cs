#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using SalesWorkflow.Entities;
using SalesWorkflow.Data;

#endregion

namespace SalesWorkflow.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ZohoCallsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ZohoCallsProviderBaseCore : EntityProviderBase<SalesWorkflow.Entities.ZohoCalls, SalesWorkflow.Entities.ZohoCallsKey>
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
		public override bool Delete(TransactionManager transactionManager, SalesWorkflow.Entities.ZohoCallsKey key)
		{
			return Delete(transactionManager, key.CallPk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_callPk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _callPk)
		{
			return Delete(null, _callPk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_callPk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _callPk);		
		
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
		public override SalesWorkflow.Entities.ZohoCalls Get(TransactionManager transactionManager, SalesWorkflow.Entities.ZohoCallsKey key, int start, int pageLength)
		{
			return GetByCallPk(transactionManager, key.CallPk, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZohoCalls index.
		/// </summary>
		/// <param name="_callPk"></param>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.ZohoCalls"/> class.</returns>
		public SalesWorkflow.Entities.ZohoCalls GetByCallPk(System.Int64 _callPk)
		{
			int count = -1;
			return GetByCallPk(null,_callPk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoCalls index.
		/// </summary>
		/// <param name="_callPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.ZohoCalls"/> class.</returns>
		public SalesWorkflow.Entities.ZohoCalls GetByCallPk(System.Int64 _callPk, int start, int pageLength)
		{
			int count = -1;
			return GetByCallPk(null, _callPk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoCalls index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_callPk"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.ZohoCalls"/> class.</returns>
		public SalesWorkflow.Entities.ZohoCalls GetByCallPk(TransactionManager transactionManager, System.Int64 _callPk)
		{
			int count = -1;
			return GetByCallPk(transactionManager, _callPk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoCalls index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_callPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.ZohoCalls"/> class.</returns>
		public SalesWorkflow.Entities.ZohoCalls GetByCallPk(TransactionManager transactionManager, System.Int64 _callPk, int start, int pageLength)
		{
			int count = -1;
			return GetByCallPk(transactionManager, _callPk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoCalls index.
		/// </summary>
		/// <param name="_callPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.ZohoCalls"/> class.</returns>
		public SalesWorkflow.Entities.ZohoCalls GetByCallPk(System.Int64 _callPk, int start, int pageLength, out int count)
		{
			return GetByCallPk(null, _callPk, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoCalls index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_callPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.ZohoCalls"/> class.</returns>
		public abstract SalesWorkflow.Entities.ZohoCalls GetByCallPk(TransactionManager transactionManager, System.Int64 _callPk, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ZohoCallsLeadID index.
		/// </summary>
		/// <param name="_leadid"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoCalls&gt;"/> class.</returns>
		public TList<ZohoCalls> GetByLeadid(System.String _leadid)
		{
			int count = -1;
			return GetByLeadid(null,_leadid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ZohoCallsLeadID index.
		/// </summary>
		/// <param name="_leadid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoCalls&gt;"/> class.</returns>
		public TList<ZohoCalls> GetByLeadid(System.String _leadid, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadid(null, _leadid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ZohoCallsLeadID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoCalls&gt;"/> class.</returns>
		public TList<ZohoCalls> GetByLeadid(TransactionManager transactionManager, System.String _leadid)
		{
			int count = -1;
			return GetByLeadid(transactionManager, _leadid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ZohoCallsLeadID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoCalls&gt;"/> class.</returns>
		public TList<ZohoCalls> GetByLeadid(TransactionManager transactionManager, System.String _leadid, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadid(transactionManager, _leadid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ZohoCallsLeadID index.
		/// </summary>
		/// <param name="_leadid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoCalls&gt;"/> class.</returns>
		public TList<ZohoCalls> GetByLeadid(System.String _leadid, int start, int pageLength, out int count)
		{
			return GetByLeadid(null, _leadid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ZohoCallsLeadID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;ZohoCalls&gt;"/> class.</returns>
		public abstract TList<ZohoCalls> GetByLeadid(TransactionManager transactionManager, System.String _leadid, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ZohoCalls&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ZohoCalls&gt;"/></returns>
		public static TList<ZohoCalls> Fill(IDataReader reader, TList<ZohoCalls> rows, int start, int pageLength)
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
				
				SalesWorkflow.Entities.ZohoCalls c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ZohoCalls")
					.Append("|").Append((System.Int64)reader[((int)ZohoCallsColumn.CallPk - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ZohoCalls>(
					key.ToString(), // EntityTrackingKey
					"ZohoCalls",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SalesWorkflow.Entities.ZohoCalls();
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
					c.Accountid = (reader.IsDBNull(((int)ZohoCallsColumn.Accountid - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Accountid - 1)];
					c.Billable = (reader.IsDBNull(((int)ZohoCallsColumn.Billable - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Billable - 1)];
					c.CallDuration = (reader.IsDBNull(((int)ZohoCallsColumn.CallDuration - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallDuration - 1)];
					c.SafeNameCallDurationInMinutes = (reader.IsDBNull(((int)ZohoCallsColumn.SafeNameCallDurationInMinutes - 1)))?null:(System.Double?)reader[((int)ZohoCallsColumn.SafeNameCallDurationInMinutes - 1)];
					c.SafeNameCallDurationInSeconds = (reader.IsDBNull(((int)ZohoCallsColumn.SafeNameCallDurationInSeconds - 1)))?null:(System.Double?)reader[((int)ZohoCallsColumn.SafeNameCallDurationInSeconds - 1)];
					c.CallOwner = (reader.IsDBNull(((int)ZohoCallsColumn.CallOwner - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallOwner - 1)];
					c.CallOwnerId = (reader.IsDBNull(((int)ZohoCallsColumn.CallOwnerId - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallOwnerId - 1)];
					c.CallPurpose = (reader.IsDBNull(((int)ZohoCallsColumn.CallPurpose - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallPurpose - 1)];
					c.CallResult = (reader.IsDBNull(((int)ZohoCallsColumn.CallResult - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallResult - 1)];
					c.CallStartTime = (reader.IsDBNull(((int)ZohoCallsColumn.CallStartTime - 1)))?null:(System.DateTime?)reader[((int)ZohoCallsColumn.CallStartTime - 1)];
					c.CallType = (reader.IsDBNull(((int)ZohoCallsColumn.CallType - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallType - 1)];
					c.ContactId = (reader.IsDBNull(((int)ZohoCallsColumn.ContactId - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.ContactId - 1)];
					c.CreatedBy = (reader.IsDBNull(((int)ZohoCallsColumn.CreatedBy - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CreatedBy - 1)];
					c.CreatedTime = (reader.IsDBNull(((int)ZohoCallsColumn.CreatedTime - 1)))?null:(System.DateTime?)reader[((int)ZohoCallsColumn.CreatedTime - 1)];
					c.Leadid = (reader.IsDBNull(((int)ZohoCallsColumn.Leadid - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Leadid - 1)];
					c.ModifiedTime = (reader.IsDBNull(((int)ZohoCallsColumn.ModifiedTime - 1)))?null:(System.DateTime?)reader[((int)ZohoCallsColumn.ModifiedTime - 1)];
					c.Potentialid = (reader.IsDBNull(((int)ZohoCallsColumn.Potentialid - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Potentialid - 1)];
					c.RelatedTo = (reader.IsDBNull(((int)ZohoCallsColumn.RelatedTo - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.RelatedTo - 1)];
					c.Semodule = (reader.IsDBNull(((int)ZohoCallsColumn.Semodule - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Semodule - 1)];
					c.Subject = (reader.IsDBNull(((int)ZohoCallsColumn.Subject - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Subject - 1)];
					c.Taskid = (reader.IsDBNull(((int)ZohoCallsColumn.Taskid - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Taskid - 1)];
					c.WhoIdId = (reader.IsDBNull(((int)ZohoCallsColumn.WhoIdId - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.WhoIdId - 1)];
					c.CallPk = (System.Int64)reader[((int)ZohoCallsColumn.CallPk - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SalesWorkflow.Entities.ZohoCalls"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SalesWorkflow.Entities.ZohoCalls"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SalesWorkflow.Entities.ZohoCalls entity)
		{
			if (!reader.Read()) return;
			
			entity.Accountid = (reader.IsDBNull(((int)ZohoCallsColumn.Accountid - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Accountid - 1)];
			entity.Billable = (reader.IsDBNull(((int)ZohoCallsColumn.Billable - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Billable - 1)];
			entity.CallDuration = (reader.IsDBNull(((int)ZohoCallsColumn.CallDuration - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallDuration - 1)];
			entity.SafeNameCallDurationInMinutes = (reader.IsDBNull(((int)ZohoCallsColumn.SafeNameCallDurationInMinutes - 1)))?null:(System.Double?)reader[((int)ZohoCallsColumn.SafeNameCallDurationInMinutes - 1)];
			entity.SafeNameCallDurationInSeconds = (reader.IsDBNull(((int)ZohoCallsColumn.SafeNameCallDurationInSeconds - 1)))?null:(System.Double?)reader[((int)ZohoCallsColumn.SafeNameCallDurationInSeconds - 1)];
			entity.CallOwner = (reader.IsDBNull(((int)ZohoCallsColumn.CallOwner - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallOwner - 1)];
			entity.CallOwnerId = (reader.IsDBNull(((int)ZohoCallsColumn.CallOwnerId - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallOwnerId - 1)];
			entity.CallPurpose = (reader.IsDBNull(((int)ZohoCallsColumn.CallPurpose - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallPurpose - 1)];
			entity.CallResult = (reader.IsDBNull(((int)ZohoCallsColumn.CallResult - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallResult - 1)];
			entity.CallStartTime = (reader.IsDBNull(((int)ZohoCallsColumn.CallStartTime - 1)))?null:(System.DateTime?)reader[((int)ZohoCallsColumn.CallStartTime - 1)];
			entity.CallType = (reader.IsDBNull(((int)ZohoCallsColumn.CallType - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CallType - 1)];
			entity.ContactId = (reader.IsDBNull(((int)ZohoCallsColumn.ContactId - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.ContactId - 1)];
			entity.CreatedBy = (reader.IsDBNull(((int)ZohoCallsColumn.CreatedBy - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.CreatedBy - 1)];
			entity.CreatedTime = (reader.IsDBNull(((int)ZohoCallsColumn.CreatedTime - 1)))?null:(System.DateTime?)reader[((int)ZohoCallsColumn.CreatedTime - 1)];
			entity.Leadid = (reader.IsDBNull(((int)ZohoCallsColumn.Leadid - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Leadid - 1)];
			entity.ModifiedTime = (reader.IsDBNull(((int)ZohoCallsColumn.ModifiedTime - 1)))?null:(System.DateTime?)reader[((int)ZohoCallsColumn.ModifiedTime - 1)];
			entity.Potentialid = (reader.IsDBNull(((int)ZohoCallsColumn.Potentialid - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Potentialid - 1)];
			entity.RelatedTo = (reader.IsDBNull(((int)ZohoCallsColumn.RelatedTo - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.RelatedTo - 1)];
			entity.Semodule = (reader.IsDBNull(((int)ZohoCallsColumn.Semodule - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Semodule - 1)];
			entity.Subject = (reader.IsDBNull(((int)ZohoCallsColumn.Subject - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Subject - 1)];
			entity.Taskid = (reader.IsDBNull(((int)ZohoCallsColumn.Taskid - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.Taskid - 1)];
			entity.WhoIdId = (reader.IsDBNull(((int)ZohoCallsColumn.WhoIdId - 1)))?null:(System.String)reader[((int)ZohoCallsColumn.WhoIdId - 1)];
			entity.CallPk = (System.Int64)reader[((int)ZohoCallsColumn.CallPk - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SalesWorkflow.Entities.ZohoCalls"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SalesWorkflow.Entities.ZohoCalls"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SalesWorkflow.Entities.ZohoCalls entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Accountid = Convert.IsDBNull(dataRow["ACCOUNTID"]) ? null : (System.String)dataRow["ACCOUNTID"];
			entity.Billable = Convert.IsDBNull(dataRow["Billable"]) ? null : (System.String)dataRow["Billable"];
			entity.CallDuration = Convert.IsDBNull(dataRow["Call Duration"]) ? null : (System.String)dataRow["Call Duration"];
			entity.SafeNameCallDurationInMinutes = Convert.IsDBNull(dataRow["Call Duration (in minutes)"]) ? null : (System.Double?)dataRow["Call Duration (in minutes)"];
			entity.SafeNameCallDurationInSeconds = Convert.IsDBNull(dataRow["Call Duration (in seconds)"]) ? null : (System.Double?)dataRow["Call Duration (in seconds)"];
			entity.CallOwner = Convert.IsDBNull(dataRow["Call Owner"]) ? null : (System.String)dataRow["Call Owner"];
			entity.CallOwnerId = Convert.IsDBNull(dataRow["Call Owner Id"]) ? null : (System.String)dataRow["Call Owner Id"];
			entity.CallPurpose = Convert.IsDBNull(dataRow["Call Purpose"]) ? null : (System.String)dataRow["Call Purpose"];
			entity.CallResult = Convert.IsDBNull(dataRow["Call Result"]) ? null : (System.String)dataRow["Call Result"];
			entity.CallStartTime = Convert.IsDBNull(dataRow["Call Start Time"]) ? null : (System.DateTime?)dataRow["Call Start Time"];
			entity.CallType = Convert.IsDBNull(dataRow["Call Type"]) ? null : (System.String)dataRow["Call Type"];
			entity.ContactId = Convert.IsDBNull(dataRow["ContactID"]) ? null : (System.String)dataRow["ContactID"];
			entity.CreatedBy = Convert.IsDBNull(dataRow["CreatedBy"]) ? null : (System.String)dataRow["CreatedBy"];
			entity.CreatedTime = Convert.IsDBNull(dataRow["Created Time"]) ? null : (System.DateTime?)dataRow["Created Time"];
			entity.Leadid = Convert.IsDBNull(dataRow["LEADID"]) ? null : (System.String)dataRow["LEADID"];
			entity.ModifiedTime = Convert.IsDBNull(dataRow["Modified Time"]) ? null : (System.DateTime?)dataRow["Modified Time"];
			entity.Potentialid = Convert.IsDBNull(dataRow["POTENTIALID"]) ? null : (System.String)dataRow["POTENTIALID"];
			entity.RelatedTo = Convert.IsDBNull(dataRow["RELATED To"]) ? null : (System.String)dataRow["RELATED To"];
			entity.Semodule = Convert.IsDBNull(dataRow["SEMODULE"]) ? null : (System.String)dataRow["SEMODULE"];
			entity.Subject = Convert.IsDBNull(dataRow["Subject"]) ? null : (System.String)dataRow["Subject"];
			entity.Taskid = Convert.IsDBNull(dataRow["TASKID"]) ? null : (System.String)dataRow["TASKID"];
			entity.WhoIdId = Convert.IsDBNull(dataRow["Who Id Id"]) ? null : (System.String)dataRow["Who Id Id"];
			entity.CallPk = (System.Int64)dataRow["CallPK"];
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
		/// <param name="entity">The <see cref="SalesWorkflow.Entities.ZohoCalls"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SalesWorkflow.Entities.ZohoCalls Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SalesWorkflow.Entities.ZohoCalls entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SalesWorkflow.Entities.ZohoCalls object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SalesWorkflow.Entities.ZohoCalls instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SalesWorkflow.Entities.ZohoCalls Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SalesWorkflow.Entities.ZohoCalls entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ZohoCallsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SalesWorkflow.Entities.ZohoCalls</c>
	///</summary>
	public enum ZohoCallsChildEntityTypes
	{
	}
	
	#endregion ZohoCallsChildEntityTypes
	
	#region ZohoCallsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ZohoCallsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoCallsFilterBuilder : SqlFilterBuilder<ZohoCallsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoCallsFilterBuilder class.
		/// </summary>
		public ZohoCallsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoCallsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoCallsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoCallsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoCallsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoCallsFilterBuilder
	
	#region ZohoCallsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ZohoCallsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoCallsParameterBuilder : ParameterizedSqlFilterBuilder<ZohoCallsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoCallsParameterBuilder class.
		/// </summary>
		public ZohoCallsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoCallsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoCallsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoCallsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoCallsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoCallsParameterBuilder
	
	#region ZohoCallsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ZohoCallsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoCalls"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ZohoCallsSortBuilder : SqlSortBuilder<ZohoCallsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoCallsSqlSortBuilder class.
		/// </summary>
		public ZohoCallsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ZohoCallsSortBuilder
	
} // end namespace
