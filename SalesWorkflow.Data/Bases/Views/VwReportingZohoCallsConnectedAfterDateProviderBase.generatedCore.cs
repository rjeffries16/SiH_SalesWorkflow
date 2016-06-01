#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SalesWorkflow.Entities;
using SalesWorkflow.Data;

#endregion

namespace SalesWorkflow.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="VwReportingZohoCallsConnectedAfterDateProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwReportingZohoCallsConnectedAfterDateProviderBaseCore : EntityViewProviderBase<VwReportingZohoCallsConnectedAfterDate>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwReportingZohoCallsConnectedAfterDate&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwReportingZohoCallsConnectedAfterDate&gt;"/></returns>
		protected static VList&lt;VwReportingZohoCallsConnectedAfterDate&gt; Fill(DataSet dataSet, VList<VwReportingZohoCallsConnectedAfterDate> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwReportingZohoCallsConnectedAfterDate>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwReportingZohoCallsConnectedAfterDate&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwReportingZohoCallsConnectedAfterDate>"/></returns>
		protected static VList&lt;VwReportingZohoCallsConnectedAfterDate&gt; Fill(DataTable dataTable, VList<VwReportingZohoCallsConnectedAfterDate> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwReportingZohoCallsConnectedAfterDate c = new VwReportingZohoCallsConnectedAfterDate();
					c.Accountid = (Convert.IsDBNull(row["ACCOUNTID"]))?string.Empty:(System.String)row["ACCOUNTID"];
					c.Billable = (Convert.IsDBNull(row["Billable"]))?string.Empty:(System.String)row["Billable"];
					c.CallDuration = (Convert.IsDBNull(row["Call Duration"]))?string.Empty:(System.String)row["Call Duration"];
					c.SafeNameCallDurationInMinutes = (Convert.IsDBNull(row["Call Duration (in minutes)"]))?0.0f:(System.Double?)row["Call Duration (in minutes)"];
					c.SafeNameCallDurationInSeconds = (Convert.IsDBNull(row["Call Duration (in seconds)"]))?0.0f:(System.Double?)row["Call Duration (in seconds)"];
					c.CallOwner = (Convert.IsDBNull(row["Call Owner"]))?string.Empty:(System.String)row["Call Owner"];
					c.CallOwnerId = (Convert.IsDBNull(row["Call Owner Id"]))?string.Empty:(System.String)row["Call Owner Id"];
					c.CallPurpose = (Convert.IsDBNull(row["Call Purpose"]))?string.Empty:(System.String)row["Call Purpose"];
					c.CallResult = (Convert.IsDBNull(row["Call Result"]))?string.Empty:(System.String)row["Call Result"];
					c.CallStartTime = (Convert.IsDBNull(row["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)row["Call Start Time"];
					c.CallType = (Convert.IsDBNull(row["Call Type"]))?string.Empty:(System.String)row["Call Type"];
					c.ContactId = (Convert.IsDBNull(row["ContactID"]))?string.Empty:(System.String)row["ContactID"];
					c.CreatedBy = (Convert.IsDBNull(row["CreatedBy"]))?string.Empty:(System.String)row["CreatedBy"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.ModifiedTime = (Convert.IsDBNull(row["Modified Time"]))?DateTime.MinValue:(System.DateTime?)row["Modified Time"];
					c.Potentialid = (Convert.IsDBNull(row["POTENTIALID"]))?string.Empty:(System.String)row["POTENTIALID"];
					c.RelatedTo = (Convert.IsDBNull(row["RELATED To"]))?string.Empty:(System.String)row["RELATED To"];
					c.Semodule = (Convert.IsDBNull(row["SEMODULE"]))?string.Empty:(System.String)row["SEMODULE"];
					c.Subject = (Convert.IsDBNull(row["Subject"]))?string.Empty:(System.String)row["Subject"];
					c.Taskid = (Convert.IsDBNull(row["TASKID"]))?string.Empty:(System.String)row["TASKID"];
					c.WhoIdId = (Convert.IsDBNull(row["Who Id Id"]))?string.Empty:(System.String)row["Who Id Id"];
					c.CallPk = (Convert.IsDBNull(row["CallPK"]))?(long)0:(System.Int64)row["CallPK"];
					c.AcceptChanges();
					rows.Add(c);
					pagelen -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		*/	
						
		///<summary>
		/// Fill an <see cref="VList&lt;VwReportingZohoCallsConnectedAfterDate&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwReportingZohoCallsConnectedAfterDate&gt;"/></returns>
		protected VList<VwReportingZohoCallsConnectedAfterDate> Fill(IDataReader reader, VList<VwReportingZohoCallsConnectedAfterDate> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwReportingZohoCallsConnectedAfterDate entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwReportingZohoCallsConnectedAfterDate>("VwReportingZohoCallsConnectedAfterDate",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwReportingZohoCallsConnectedAfterDate();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Accountid = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Accountid)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Accountid)];
					//entity.Accountid = (Convert.IsDBNull(reader["ACCOUNTID"]))?string.Empty:(System.String)reader["ACCOUNTID"];
					entity.Billable = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Billable)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Billable)];
					//entity.Billable = (Convert.IsDBNull(reader["Billable"]))?string.Empty:(System.String)reader["Billable"];
					entity.CallDuration = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallDuration)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallDuration)];
					//entity.CallDuration = (Convert.IsDBNull(reader["Call Duration"]))?string.Empty:(System.String)reader["Call Duration"];
					entity.SafeNameCallDurationInMinutes = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.SafeNameCallDurationInMinutes)))?null:(System.Double?)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.SafeNameCallDurationInMinutes)];
					//entity.SafeNameCallDurationInMinutes = (Convert.IsDBNull(reader["Call Duration (in minutes)"]))?0.0f:(System.Double?)reader["Call Duration (in minutes)"];
					entity.SafeNameCallDurationInSeconds = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.SafeNameCallDurationInSeconds)))?null:(System.Double?)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.SafeNameCallDurationInSeconds)];
					//entity.SafeNameCallDurationInSeconds = (Convert.IsDBNull(reader["Call Duration (in seconds)"]))?0.0f:(System.Double?)reader["Call Duration (in seconds)"];
					entity.CallOwner = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallOwner)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallOwner)];
					//entity.CallOwner = (Convert.IsDBNull(reader["Call Owner"]))?string.Empty:(System.String)reader["Call Owner"];
					entity.CallOwnerId = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallOwnerId)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallOwnerId)];
					//entity.CallOwnerId = (Convert.IsDBNull(reader["Call Owner Id"]))?string.Empty:(System.String)reader["Call Owner Id"];
					entity.CallPurpose = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallPurpose)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallPurpose)];
					//entity.CallPurpose = (Convert.IsDBNull(reader["Call Purpose"]))?string.Empty:(System.String)reader["Call Purpose"];
					entity.CallResult = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallResult)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallResult)];
					//entity.CallResult = (Convert.IsDBNull(reader["Call Result"]))?string.Empty:(System.String)reader["Call Result"];
					entity.CallStartTime = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallStartTime)];
					//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
					entity.CallType = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallType)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallType)];
					//entity.CallType = (Convert.IsDBNull(reader["Call Type"]))?string.Empty:(System.String)reader["Call Type"];
					entity.ContactId = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.ContactId)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.ContactId)];
					//entity.ContactId = (Convert.IsDBNull(reader["ContactID"]))?string.Empty:(System.String)reader["ContactID"];
					entity.CreatedBy = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CreatedBy)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CreatedBy)];
					//entity.CreatedBy = (Convert.IsDBNull(reader["CreatedBy"]))?string.Empty:(System.String)reader["CreatedBy"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.Leadid = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Leadid)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.ModifiedTime = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.ModifiedTime)))?null:(System.DateTime?)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.ModifiedTime)];
					//entity.ModifiedTime = (Convert.IsDBNull(reader["Modified Time"]))?DateTime.MinValue:(System.DateTime?)reader["Modified Time"];
					entity.Potentialid = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Potentialid)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Potentialid)];
					//entity.Potentialid = (Convert.IsDBNull(reader["POTENTIALID"]))?string.Empty:(System.String)reader["POTENTIALID"];
					entity.RelatedTo = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.RelatedTo)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.RelatedTo)];
					//entity.RelatedTo = (Convert.IsDBNull(reader["RELATED To"]))?string.Empty:(System.String)reader["RELATED To"];
					entity.Semodule = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Semodule)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Semodule)];
					//entity.Semodule = (Convert.IsDBNull(reader["SEMODULE"]))?string.Empty:(System.String)reader["SEMODULE"];
					entity.Subject = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Subject)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Subject)];
					//entity.Subject = (Convert.IsDBNull(reader["Subject"]))?string.Empty:(System.String)reader["Subject"];
					entity.Taskid = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Taskid)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Taskid)];
					//entity.Taskid = (Convert.IsDBNull(reader["TASKID"]))?string.Empty:(System.String)reader["TASKID"];
					entity.WhoIdId = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.WhoIdId)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.WhoIdId)];
					//entity.WhoIdId = (Convert.IsDBNull(reader["Who Id Id"]))?string.Empty:(System.String)reader["Who Id Id"];
					entity.CallPk = (System.Int64)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallPk)];
					//entity.CallPk = (Convert.IsDBNull(reader["CallPK"]))?(long)0:(System.Int64)reader["CallPK"];
					entity.AcceptChanges();
					entity.SuppressEntityEvents = false;
					
					rows.Add(entity);
					pageLength -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="VwReportingZohoCallsConnectedAfterDate"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwReportingZohoCallsConnectedAfterDate"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwReportingZohoCallsConnectedAfterDate entity)
		{
			reader.Read();
			entity.Accountid = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Accountid)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Accountid)];
			//entity.Accountid = (Convert.IsDBNull(reader["ACCOUNTID"]))?string.Empty:(System.String)reader["ACCOUNTID"];
			entity.Billable = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Billable)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Billable)];
			//entity.Billable = (Convert.IsDBNull(reader["Billable"]))?string.Empty:(System.String)reader["Billable"];
			entity.CallDuration = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallDuration)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallDuration)];
			//entity.CallDuration = (Convert.IsDBNull(reader["Call Duration"]))?string.Empty:(System.String)reader["Call Duration"];
			entity.SafeNameCallDurationInMinutes = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.SafeNameCallDurationInMinutes)))?null:(System.Double?)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.SafeNameCallDurationInMinutes)];
			//entity.SafeNameCallDurationInMinutes = (Convert.IsDBNull(reader["Call Duration (in minutes)"]))?0.0f:(System.Double?)reader["Call Duration (in minutes)"];
			entity.SafeNameCallDurationInSeconds = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.SafeNameCallDurationInSeconds)))?null:(System.Double?)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.SafeNameCallDurationInSeconds)];
			//entity.SafeNameCallDurationInSeconds = (Convert.IsDBNull(reader["Call Duration (in seconds)"]))?0.0f:(System.Double?)reader["Call Duration (in seconds)"];
			entity.CallOwner = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallOwner)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallOwner)];
			//entity.CallOwner = (Convert.IsDBNull(reader["Call Owner"]))?string.Empty:(System.String)reader["Call Owner"];
			entity.CallOwnerId = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallOwnerId)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallOwnerId)];
			//entity.CallOwnerId = (Convert.IsDBNull(reader["Call Owner Id"]))?string.Empty:(System.String)reader["Call Owner Id"];
			entity.CallPurpose = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallPurpose)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallPurpose)];
			//entity.CallPurpose = (Convert.IsDBNull(reader["Call Purpose"]))?string.Empty:(System.String)reader["Call Purpose"];
			entity.CallResult = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallResult)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallResult)];
			//entity.CallResult = (Convert.IsDBNull(reader["Call Result"]))?string.Empty:(System.String)reader["Call Result"];
			entity.CallStartTime = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallStartTime)];
			//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
			entity.CallType = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CallType)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallType)];
			//entity.CallType = (Convert.IsDBNull(reader["Call Type"]))?string.Empty:(System.String)reader["Call Type"];
			entity.ContactId = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.ContactId)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.ContactId)];
			//entity.ContactId = (Convert.IsDBNull(reader["ContactID"]))?string.Empty:(System.String)reader["ContactID"];
			entity.CreatedBy = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CreatedBy)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CreatedBy)];
			//entity.CreatedBy = (Convert.IsDBNull(reader["CreatedBy"]))?string.Empty:(System.String)reader["CreatedBy"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.Leadid = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Leadid)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.ModifiedTime = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.ModifiedTime)))?null:(System.DateTime?)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.ModifiedTime)];
			//entity.ModifiedTime = (Convert.IsDBNull(reader["Modified Time"]))?DateTime.MinValue:(System.DateTime?)reader["Modified Time"];
			entity.Potentialid = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Potentialid)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Potentialid)];
			//entity.Potentialid = (Convert.IsDBNull(reader["POTENTIALID"]))?string.Empty:(System.String)reader["POTENTIALID"];
			entity.RelatedTo = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.RelatedTo)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.RelatedTo)];
			//entity.RelatedTo = (Convert.IsDBNull(reader["RELATED To"]))?string.Empty:(System.String)reader["RELATED To"];
			entity.Semodule = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Semodule)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Semodule)];
			//entity.Semodule = (Convert.IsDBNull(reader["SEMODULE"]))?string.Empty:(System.String)reader["SEMODULE"];
			entity.Subject = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Subject)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Subject)];
			//entity.Subject = (Convert.IsDBNull(reader["Subject"]))?string.Empty:(System.String)reader["Subject"];
			entity.Taskid = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.Taskid)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.Taskid)];
			//entity.Taskid = (Convert.IsDBNull(reader["TASKID"]))?string.Empty:(System.String)reader["TASKID"];
			entity.WhoIdId = (reader.IsDBNull(((int)VwReportingZohoCallsConnectedAfterDateColumn.WhoIdId)))?null:(System.String)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.WhoIdId)];
			//entity.WhoIdId = (Convert.IsDBNull(reader["Who Id Id"]))?string.Empty:(System.String)reader["Who Id Id"];
			entity.CallPk = (System.Int64)reader[((int)VwReportingZohoCallsConnectedAfterDateColumn.CallPk)];
			//entity.CallPk = (Convert.IsDBNull(reader["CallPK"]))?(long)0:(System.Int64)reader["CallPK"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwReportingZohoCallsConnectedAfterDate"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwReportingZohoCallsConnectedAfterDate"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwReportingZohoCallsConnectedAfterDate entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Accountid = (Convert.IsDBNull(dataRow["ACCOUNTID"]))?string.Empty:(System.String)dataRow["ACCOUNTID"];
			entity.Billable = (Convert.IsDBNull(dataRow["Billable"]))?string.Empty:(System.String)dataRow["Billable"];
			entity.CallDuration = (Convert.IsDBNull(dataRow["Call Duration"]))?string.Empty:(System.String)dataRow["Call Duration"];
			entity.SafeNameCallDurationInMinutes = (Convert.IsDBNull(dataRow["Call Duration (in minutes)"]))?0.0f:(System.Double?)dataRow["Call Duration (in minutes)"];
			entity.SafeNameCallDurationInSeconds = (Convert.IsDBNull(dataRow["Call Duration (in seconds)"]))?0.0f:(System.Double?)dataRow["Call Duration (in seconds)"];
			entity.CallOwner = (Convert.IsDBNull(dataRow["Call Owner"]))?string.Empty:(System.String)dataRow["Call Owner"];
			entity.CallOwnerId = (Convert.IsDBNull(dataRow["Call Owner Id"]))?string.Empty:(System.String)dataRow["Call Owner Id"];
			entity.CallPurpose = (Convert.IsDBNull(dataRow["Call Purpose"]))?string.Empty:(System.String)dataRow["Call Purpose"];
			entity.CallResult = (Convert.IsDBNull(dataRow["Call Result"]))?string.Empty:(System.String)dataRow["Call Result"];
			entity.CallStartTime = (Convert.IsDBNull(dataRow["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Call Start Time"];
			entity.CallType = (Convert.IsDBNull(dataRow["Call Type"]))?string.Empty:(System.String)dataRow["Call Type"];
			entity.ContactId = (Convert.IsDBNull(dataRow["ContactID"]))?string.Empty:(System.String)dataRow["ContactID"];
			entity.CreatedBy = (Convert.IsDBNull(dataRow["CreatedBy"]))?string.Empty:(System.String)dataRow["CreatedBy"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.ModifiedTime = (Convert.IsDBNull(dataRow["Modified Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Modified Time"];
			entity.Potentialid = (Convert.IsDBNull(dataRow["POTENTIALID"]))?string.Empty:(System.String)dataRow["POTENTIALID"];
			entity.RelatedTo = (Convert.IsDBNull(dataRow["RELATED To"]))?string.Empty:(System.String)dataRow["RELATED To"];
			entity.Semodule = (Convert.IsDBNull(dataRow["SEMODULE"]))?string.Empty:(System.String)dataRow["SEMODULE"];
			entity.Subject = (Convert.IsDBNull(dataRow["Subject"]))?string.Empty:(System.String)dataRow["Subject"];
			entity.Taskid = (Convert.IsDBNull(dataRow["TASKID"]))?string.Empty:(System.String)dataRow["TASKID"];
			entity.WhoIdId = (Convert.IsDBNull(dataRow["Who Id Id"]))?string.Empty:(System.String)dataRow["Who Id Id"];
			entity.CallPk = (Convert.IsDBNull(dataRow["CallPK"]))?(long)0:(System.Int64)dataRow["CallPK"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwReportingZohoCallsConnectedAfterDateFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingZohoCallsConnectedAfterDate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingZohoCallsConnectedAfterDateFilterBuilder : SqlFilterBuilder<VwReportingZohoCallsConnectedAfterDateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateFilterBuilder class.
		/// </summary>
		public VwReportingZohoCallsConnectedAfterDateFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingZohoCallsConnectedAfterDateFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingZohoCallsConnectedAfterDateFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingZohoCallsConnectedAfterDateFilterBuilder

	#region VwReportingZohoCallsConnectedAfterDateParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingZohoCallsConnectedAfterDate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingZohoCallsConnectedAfterDateParameterBuilder : ParameterizedSqlFilterBuilder<VwReportingZohoCallsConnectedAfterDateColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateParameterBuilder class.
		/// </summary>
		public VwReportingZohoCallsConnectedAfterDateParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingZohoCallsConnectedAfterDateParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingZohoCallsConnectedAfterDateParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingZohoCallsConnectedAfterDateParameterBuilder
	
	#region VwReportingZohoCallsConnectedAfterDateSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingZohoCallsConnectedAfterDate"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwReportingZohoCallsConnectedAfterDateSortBuilder : SqlSortBuilder<VwReportingZohoCallsConnectedAfterDateColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateSqlSortBuilder class.
		/// </summary>
		public VwReportingZohoCallsConnectedAfterDateSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwReportingZohoCallsConnectedAfterDateSortBuilder

} // end namespace
