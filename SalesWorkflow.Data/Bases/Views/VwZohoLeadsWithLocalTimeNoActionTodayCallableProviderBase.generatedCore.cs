﻿#region Using directives

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
	/// This class is the base class for any <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallableProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwZohoLeadsWithLocalTimeNoActionTodayCallableProviderBaseCore : EntityViewProviderBase<VwZohoLeadsWithLocalTimeNoActionTodayCallable>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwZohoLeadsWithLocalTimeNoActionTodayCallable&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwZohoLeadsWithLocalTimeNoActionTodayCallable&gt;"/></returns>
		protected static VList&lt;VwZohoLeadsWithLocalTimeNoActionTodayCallable&gt; Fill(DataSet dataSet, VList<VwZohoLeadsWithLocalTimeNoActionTodayCallable> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwZohoLeadsWithLocalTimeNoActionTodayCallable>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwZohoLeadsWithLocalTimeNoActionTodayCallable&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwZohoLeadsWithLocalTimeNoActionTodayCallable>"/></returns>
		protected static VList&lt;VwZohoLeadsWithLocalTimeNoActionTodayCallable&gt; Fill(DataTable dataTable, VList<VwZohoLeadsWithLocalTimeNoActionTodayCallable> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwZohoLeadsWithLocalTimeNoActionTodayCallable c = new VwZohoLeadsWithLocalTimeNoActionTodayCallable();
					c.CreatedBy = (Convert.IsDBNull(row["Created By"]))?string.Empty:(System.String)row["Created By"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.IfNoLongerInterested = (Convert.IsDBNull(row["If No Longer Interested"]))?string.Empty:(System.String)row["If No Longer Interested"];
					c.LastActivityTime = (Convert.IsDBNull(row["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)row["Last Activity Time"];
					c.LastVisitedTime = (Convert.IsDBNull(row["Last Visited Time"]))?string.Empty:(System.String)row["Last Visited Time"];
					c.LeadOwner = (Convert.IsDBNull(row["Lead Owner"]))?string.Empty:(System.String)row["Lead Owner"];
					c.LeadSource = (Convert.IsDBNull(row["Lead Source"]))?string.Empty:(System.String)row["Lead Source"];
					c.LeadStatus = (Convert.IsDBNull(row["Lead Status"]))?string.Empty:(System.String)row["Lead Status"];
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.Rating = (Convert.IsDBNull(row["Rating"]))?string.Empty:(System.String)row["Rating"];
					c.State = (Convert.IsDBNull(row["State"]))?string.Empty:(System.String)row["State"];
					c.TimeZone = (Convert.IsDBNull(row["Time Zone"]))?string.Empty:(System.String)row["Time Zone"];
					c.LocalTime = (Convert.IsDBNull(row["LocalTime"]))?DateTime.MinValue:(System.DateTime?)row["LocalTime"];
					c.Url = (Convert.IsDBNull(row["URL"]))?string.Empty:(System.String)row["URL"];
					c.Website = (Convert.IsDBNull(row["Website"]))?string.Empty:(System.String)row["Website"];
					c.Worries = (Convert.IsDBNull(row["Worries"]))?string.Empty:(System.String)row["Worries"];
					c.Leadpk = (Convert.IsDBNull(row["LEADPK"]))?(long)0:(System.Int64)row["LEADPK"];
					c.Wday811 = (Convert.IsDBNull(row["WDay8-11"]))?(int)0:(System.Int32?)row["WDay8-11"];
					c.Wday112 = (Convert.IsDBNull(row["WDay11-2"]))?(int)0:(System.Int32?)row["WDay11-2"];
					c.Wday25 = (Convert.IsDBNull(row["WDay2-5"]))?(int)0:(System.Int32?)row["WDay2-5"];
					c.Wday58 = (Convert.IsDBNull(row["WDay5-8"]))?(int)0:(System.Int32?)row["WDay5-8"];
					c.Sat811 = (Convert.IsDBNull(row["Sat8-11"]))?(int)0:(System.Int32?)row["Sat8-11"];
					c.Sat112 = (Convert.IsDBNull(row["Sat11-2"]))?(int)0:(System.Int32?)row["Sat11-2"];
					c.Sat25 = (Convert.IsDBNull(row["Sat2-5"]))?(int)0:(System.Int32?)row["Sat2-5"];
					c.Sat58 = (Convert.IsDBNull(row["Sat5-8"]))?(int)0:(System.Int32?)row["Sat5-8"];
					c.Sun112 = (Convert.IsDBNull(row["Sun11-2"]))?(int)0:(System.Int32?)row["Sun11-2"];
					c.Sun811 = (Convert.IsDBNull(row["Sun8-11"]))?(int)0:(System.Int32?)row["Sun8-11"];
					c.Sun25 = (Convert.IsDBNull(row["Sun2-5"]))?(int)0:(System.Int32?)row["Sun2-5"];
					c.Sun58 = (Convert.IsDBNull(row["Sun5-8"]))?(int)0:(System.Int32?)row["Sun5-8"];
					c.UserId = (Convert.IsDBNull(row["USER_ID"]))?string.Empty:(System.String)row["USER_ID"];
					c.LeadHoldDts = (Convert.IsDBNull(row["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)row["LeadHoldDts"];
					c.LeadCalled = (Convert.IsDBNull(row["LeadCalled"]))?false:(System.Boolean?)row["LeadCalled"];
					c.LeadDefered = (Convert.IsDBNull(row["LeadDefered"]))?false:(System.Boolean?)row["LeadDefered"];
					c.LeadActionDts = (Convert.IsDBNull(row["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)row["LeadActionDts"];
					c.LeadOwnerId = (Convert.IsDBNull(row["Lead Owner Id"]))?string.Empty:(System.String)row["Lead Owner Id"];
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
		/// Fill an <see cref="VList&lt;VwZohoLeadsWithLocalTimeNoActionTodayCallable&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwZohoLeadsWithLocalTimeNoActionTodayCallable&gt;"/></returns>
		protected VList<VwZohoLeadsWithLocalTimeNoActionTodayCallable> Fill(IDataReader reader, VList<VwZohoLeadsWithLocalTimeNoActionTodayCallable> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwZohoLeadsWithLocalTimeNoActionTodayCallable entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwZohoLeadsWithLocalTimeNoActionTodayCallable>("VwZohoLeadsWithLocalTimeNoActionTodayCallable",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwZohoLeadsWithLocalTimeNoActionTodayCallable();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CreatedBy = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.CreatedBy)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.CreatedBy)];
					//entity.CreatedBy = (Convert.IsDBNull(reader["Created By"]))?string.Empty:(System.String)reader["Created By"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.FirstName = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.FirstName)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastName)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.IfNoLongerInterested = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.IfNoLongerInterested)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.IfNoLongerInterested)];
					//entity.IfNoLongerInterested = (Convert.IsDBNull(reader["If No Longer Interested"]))?string.Empty:(System.String)reader["If No Longer Interested"];
					entity.LastActivityTime = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastActivityTime)))?null:(System.DateTime?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastActivityTime)];
					//entity.LastActivityTime = (Convert.IsDBNull(reader["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)reader["Last Activity Time"];
					entity.LastVisitedTime = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastVisitedTime)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastVisitedTime)];
					//entity.LastVisitedTime = (Convert.IsDBNull(reader["Last Visited Time"]))?string.Empty:(System.String)reader["Last Visited Time"];
					entity.LeadOwner = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadOwner)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadOwner)];
					//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
					entity.LeadSource = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadSource)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadSource)];
					//entity.LeadSource = (Convert.IsDBNull(reader["Lead Source"]))?string.Empty:(System.String)reader["Lead Source"];
					entity.LeadStatus = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadStatus)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadStatus)];
					//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
					entity.Leadid = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Leadid)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.Rating = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Rating)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Rating)];
					//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
					entity.State = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.State)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.State)];
					//entity.State = (Convert.IsDBNull(reader["State"]))?string.Empty:(System.String)reader["State"];
					entity.TimeZone = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.TimeZone)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.TimeZone)];
					//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
					entity.LocalTime = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LocalTime)))?null:(System.DateTime?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LocalTime)];
					//entity.LocalTime = (Convert.IsDBNull(reader["LocalTime"]))?DateTime.MinValue:(System.DateTime?)reader["LocalTime"];
					entity.Url = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Url)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Url)];
					//entity.Url = (Convert.IsDBNull(reader["URL"]))?string.Empty:(System.String)reader["URL"];
					entity.Website = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Website)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Website)];
					//entity.Website = (Convert.IsDBNull(reader["Website"]))?string.Empty:(System.String)reader["Website"];
					entity.Worries = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Worries)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Worries)];
					//entity.Worries = (Convert.IsDBNull(reader["Worries"]))?string.Empty:(System.String)reader["Worries"];
					entity.Leadpk = (System.Int64)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Leadpk)];
					//entity.Leadpk = (Convert.IsDBNull(reader["LEADPK"]))?(long)0:(System.Int64)reader["LEADPK"];
					entity.Wday811 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday811)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday811)];
					//entity.Wday811 = (Convert.IsDBNull(reader["WDay8-11"]))?(int)0:(System.Int32?)reader["WDay8-11"];
					entity.Wday112 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday112)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday112)];
					//entity.Wday112 = (Convert.IsDBNull(reader["WDay11-2"]))?(int)0:(System.Int32?)reader["WDay11-2"];
					entity.Wday25 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday25)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday25)];
					//entity.Wday25 = (Convert.IsDBNull(reader["WDay2-5"]))?(int)0:(System.Int32?)reader["WDay2-5"];
					entity.Wday58 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday58)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday58)];
					//entity.Wday58 = (Convert.IsDBNull(reader["WDay5-8"]))?(int)0:(System.Int32?)reader["WDay5-8"];
					entity.Sat811 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat811)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat811)];
					//entity.Sat811 = (Convert.IsDBNull(reader["Sat8-11"]))?(int)0:(System.Int32?)reader["Sat8-11"];
					entity.Sat112 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat112)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat112)];
					//entity.Sat112 = (Convert.IsDBNull(reader["Sat11-2"]))?(int)0:(System.Int32?)reader["Sat11-2"];
					entity.Sat25 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat25)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat25)];
					//entity.Sat25 = (Convert.IsDBNull(reader["Sat2-5"]))?(int)0:(System.Int32?)reader["Sat2-5"];
					entity.Sat58 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat58)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat58)];
					//entity.Sat58 = (Convert.IsDBNull(reader["Sat5-8"]))?(int)0:(System.Int32?)reader["Sat5-8"];
					entity.Sun112 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun112)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun112)];
					//entity.Sun112 = (Convert.IsDBNull(reader["Sun11-2"]))?(int)0:(System.Int32?)reader["Sun11-2"];
					entity.Sun811 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun811)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun811)];
					//entity.Sun811 = (Convert.IsDBNull(reader["Sun8-11"]))?(int)0:(System.Int32?)reader["Sun8-11"];
					entity.Sun25 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun25)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun25)];
					//entity.Sun25 = (Convert.IsDBNull(reader["Sun2-5"]))?(int)0:(System.Int32?)reader["Sun2-5"];
					entity.Sun58 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun58)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun58)];
					//entity.Sun58 = (Convert.IsDBNull(reader["Sun5-8"]))?(int)0:(System.Int32?)reader["Sun5-8"];
					entity.UserId = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.UserId)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["USER_ID"]))?string.Empty:(System.String)reader["USER_ID"];
					entity.LeadHoldDts = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadHoldDts)))?null:(System.DateTime?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadHoldDts)];
					//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadHoldDts"];
					entity.LeadCalled = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadCalled)))?null:(System.Boolean?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadCalled)];
					//entity.LeadCalled = (Convert.IsDBNull(reader["LeadCalled"]))?false:(System.Boolean?)reader["LeadCalled"];
					entity.LeadDefered = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadDefered)))?null:(System.Boolean?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadDefered)];
					//entity.LeadDefered = (Convert.IsDBNull(reader["LeadDefered"]))?false:(System.Boolean?)reader["LeadDefered"];
					entity.LeadActionDts = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadActionDts)];
					//entity.LeadActionDts = (Convert.IsDBNull(reader["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadActionDts"];
					entity.LeadOwnerId = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadOwnerId)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadOwnerId)];
					//entity.LeadOwnerId = (Convert.IsDBNull(reader["Lead Owner Id"]))?string.Empty:(System.String)reader["Lead Owner Id"];
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
		/// Refreshes the <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwZohoLeadsWithLocalTimeNoActionTodayCallable entity)
		{
			reader.Read();
			entity.CreatedBy = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.CreatedBy)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.CreatedBy)];
			//entity.CreatedBy = (Convert.IsDBNull(reader["Created By"]))?string.Empty:(System.String)reader["Created By"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.FirstName = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.FirstName)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastName)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.IfNoLongerInterested = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.IfNoLongerInterested)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.IfNoLongerInterested)];
			//entity.IfNoLongerInterested = (Convert.IsDBNull(reader["If No Longer Interested"]))?string.Empty:(System.String)reader["If No Longer Interested"];
			entity.LastActivityTime = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastActivityTime)))?null:(System.DateTime?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastActivityTime)];
			//entity.LastActivityTime = (Convert.IsDBNull(reader["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)reader["Last Activity Time"];
			entity.LastVisitedTime = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastVisitedTime)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LastVisitedTime)];
			//entity.LastVisitedTime = (Convert.IsDBNull(reader["Last Visited Time"]))?string.Empty:(System.String)reader["Last Visited Time"];
			entity.LeadOwner = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadOwner)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadOwner)];
			//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
			entity.LeadSource = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadSource)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadSource)];
			//entity.LeadSource = (Convert.IsDBNull(reader["Lead Source"]))?string.Empty:(System.String)reader["Lead Source"];
			entity.LeadStatus = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadStatus)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadStatus)];
			//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
			entity.Leadid = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Leadid)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.Rating = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Rating)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Rating)];
			//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
			entity.State = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.State)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.State)];
			//entity.State = (Convert.IsDBNull(reader["State"]))?string.Empty:(System.String)reader["State"];
			entity.TimeZone = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.TimeZone)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.TimeZone)];
			//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
			entity.LocalTime = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LocalTime)))?null:(System.DateTime?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LocalTime)];
			//entity.LocalTime = (Convert.IsDBNull(reader["LocalTime"]))?DateTime.MinValue:(System.DateTime?)reader["LocalTime"];
			entity.Url = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Url)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Url)];
			//entity.Url = (Convert.IsDBNull(reader["URL"]))?string.Empty:(System.String)reader["URL"];
			entity.Website = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Website)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Website)];
			//entity.Website = (Convert.IsDBNull(reader["Website"]))?string.Empty:(System.String)reader["Website"];
			entity.Worries = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Worries)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Worries)];
			//entity.Worries = (Convert.IsDBNull(reader["Worries"]))?string.Empty:(System.String)reader["Worries"];
			entity.Leadpk = (System.Int64)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Leadpk)];
			//entity.Leadpk = (Convert.IsDBNull(reader["LEADPK"]))?(long)0:(System.Int64)reader["LEADPK"];
			entity.Wday811 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday811)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday811)];
			//entity.Wday811 = (Convert.IsDBNull(reader["WDay8-11"]))?(int)0:(System.Int32?)reader["WDay8-11"];
			entity.Wday112 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday112)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday112)];
			//entity.Wday112 = (Convert.IsDBNull(reader["WDay11-2"]))?(int)0:(System.Int32?)reader["WDay11-2"];
			entity.Wday25 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday25)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday25)];
			//entity.Wday25 = (Convert.IsDBNull(reader["WDay2-5"]))?(int)0:(System.Int32?)reader["WDay2-5"];
			entity.Wday58 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday58)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Wday58)];
			//entity.Wday58 = (Convert.IsDBNull(reader["WDay5-8"]))?(int)0:(System.Int32?)reader["WDay5-8"];
			entity.Sat811 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat811)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat811)];
			//entity.Sat811 = (Convert.IsDBNull(reader["Sat8-11"]))?(int)0:(System.Int32?)reader["Sat8-11"];
			entity.Sat112 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat112)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat112)];
			//entity.Sat112 = (Convert.IsDBNull(reader["Sat11-2"]))?(int)0:(System.Int32?)reader["Sat11-2"];
			entity.Sat25 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat25)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat25)];
			//entity.Sat25 = (Convert.IsDBNull(reader["Sat2-5"]))?(int)0:(System.Int32?)reader["Sat2-5"];
			entity.Sat58 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat58)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sat58)];
			//entity.Sat58 = (Convert.IsDBNull(reader["Sat5-8"]))?(int)0:(System.Int32?)reader["Sat5-8"];
			entity.Sun112 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun112)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun112)];
			//entity.Sun112 = (Convert.IsDBNull(reader["Sun11-2"]))?(int)0:(System.Int32?)reader["Sun11-2"];
			entity.Sun811 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun811)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun811)];
			//entity.Sun811 = (Convert.IsDBNull(reader["Sun8-11"]))?(int)0:(System.Int32?)reader["Sun8-11"];
			entity.Sun25 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun25)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun25)];
			//entity.Sun25 = (Convert.IsDBNull(reader["Sun2-5"]))?(int)0:(System.Int32?)reader["Sun2-5"];
			entity.Sun58 = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun58)))?null:(System.Int32?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.Sun58)];
			//entity.Sun58 = (Convert.IsDBNull(reader["Sun5-8"]))?(int)0:(System.Int32?)reader["Sun5-8"];
			entity.UserId = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.UserId)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["USER_ID"]))?string.Empty:(System.String)reader["USER_ID"];
			entity.LeadHoldDts = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadHoldDts)))?null:(System.DateTime?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadHoldDts)];
			//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadHoldDts"];
			entity.LeadCalled = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadCalled)))?null:(System.Boolean?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadCalled)];
			//entity.LeadCalled = (Convert.IsDBNull(reader["LeadCalled"]))?false:(System.Boolean?)reader["LeadCalled"];
			entity.LeadDefered = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadDefered)))?null:(System.Boolean?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadDefered)];
			//entity.LeadDefered = (Convert.IsDBNull(reader["LeadDefered"]))?false:(System.Boolean?)reader["LeadDefered"];
			entity.LeadActionDts = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadActionDts)];
			//entity.LeadActionDts = (Convert.IsDBNull(reader["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadActionDts"];
			entity.LeadOwnerId = (reader.IsDBNull(((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadOwnerId)))?null:(System.String)reader[((int)VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn.LeadOwnerId)];
			//entity.LeadOwnerId = (Convert.IsDBNull(reader["Lead Owner Id"]))?string.Empty:(System.String)reader["Lead Owner Id"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwZohoLeadsWithLocalTimeNoActionTodayCallable entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CreatedBy = (Convert.IsDBNull(dataRow["Created By"]))?string.Empty:(System.String)dataRow["Created By"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.IfNoLongerInterested = (Convert.IsDBNull(dataRow["If No Longer Interested"]))?string.Empty:(System.String)dataRow["If No Longer Interested"];
			entity.LastActivityTime = (Convert.IsDBNull(dataRow["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Last Activity Time"];
			entity.LastVisitedTime = (Convert.IsDBNull(dataRow["Last Visited Time"]))?string.Empty:(System.String)dataRow["Last Visited Time"];
			entity.LeadOwner = (Convert.IsDBNull(dataRow["Lead Owner"]))?string.Empty:(System.String)dataRow["Lead Owner"];
			entity.LeadSource = (Convert.IsDBNull(dataRow["Lead Source"]))?string.Empty:(System.String)dataRow["Lead Source"];
			entity.LeadStatus = (Convert.IsDBNull(dataRow["Lead Status"]))?string.Empty:(System.String)dataRow["Lead Status"];
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.Rating = (Convert.IsDBNull(dataRow["Rating"]))?string.Empty:(System.String)dataRow["Rating"];
			entity.State = (Convert.IsDBNull(dataRow["State"]))?string.Empty:(System.String)dataRow["State"];
			entity.TimeZone = (Convert.IsDBNull(dataRow["Time Zone"]))?string.Empty:(System.String)dataRow["Time Zone"];
			entity.LocalTime = (Convert.IsDBNull(dataRow["LocalTime"]))?DateTime.MinValue:(System.DateTime?)dataRow["LocalTime"];
			entity.Url = (Convert.IsDBNull(dataRow["URL"]))?string.Empty:(System.String)dataRow["URL"];
			entity.Website = (Convert.IsDBNull(dataRow["Website"]))?string.Empty:(System.String)dataRow["Website"];
			entity.Worries = (Convert.IsDBNull(dataRow["Worries"]))?string.Empty:(System.String)dataRow["Worries"];
			entity.Leadpk = (Convert.IsDBNull(dataRow["LEADPK"]))?(long)0:(System.Int64)dataRow["LEADPK"];
			entity.Wday811 = (Convert.IsDBNull(dataRow["WDay8-11"]))?(int)0:(System.Int32?)dataRow["WDay8-11"];
			entity.Wday112 = (Convert.IsDBNull(dataRow["WDay11-2"]))?(int)0:(System.Int32?)dataRow["WDay11-2"];
			entity.Wday25 = (Convert.IsDBNull(dataRow["WDay2-5"]))?(int)0:(System.Int32?)dataRow["WDay2-5"];
			entity.Wday58 = (Convert.IsDBNull(dataRow["WDay5-8"]))?(int)0:(System.Int32?)dataRow["WDay5-8"];
			entity.Sat811 = (Convert.IsDBNull(dataRow["Sat8-11"]))?(int)0:(System.Int32?)dataRow["Sat8-11"];
			entity.Sat112 = (Convert.IsDBNull(dataRow["Sat11-2"]))?(int)0:(System.Int32?)dataRow["Sat11-2"];
			entity.Sat25 = (Convert.IsDBNull(dataRow["Sat2-5"]))?(int)0:(System.Int32?)dataRow["Sat2-5"];
			entity.Sat58 = (Convert.IsDBNull(dataRow["Sat5-8"]))?(int)0:(System.Int32?)dataRow["Sat5-8"];
			entity.Sun112 = (Convert.IsDBNull(dataRow["Sun11-2"]))?(int)0:(System.Int32?)dataRow["Sun11-2"];
			entity.Sun811 = (Convert.IsDBNull(dataRow["Sun8-11"]))?(int)0:(System.Int32?)dataRow["Sun8-11"];
			entity.Sun25 = (Convert.IsDBNull(dataRow["Sun2-5"]))?(int)0:(System.Int32?)dataRow["Sun2-5"];
			entity.Sun58 = (Convert.IsDBNull(dataRow["Sun5-8"]))?(int)0:(System.Int32?)dataRow["Sun5-8"];
			entity.UserId = (Convert.IsDBNull(dataRow["USER_ID"]))?string.Empty:(System.String)dataRow["USER_ID"];
			entity.LeadHoldDts = (Convert.IsDBNull(dataRow["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadHoldDts"];
			entity.LeadCalled = (Convert.IsDBNull(dataRow["LeadCalled"]))?false:(System.Boolean?)dataRow["LeadCalled"];
			entity.LeadDefered = (Convert.IsDBNull(dataRow["LeadDefered"]))?false:(System.Boolean?)dataRow["LeadDefered"];
			entity.LeadActionDts = (Convert.IsDBNull(dataRow["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadActionDts"];
			entity.LeadOwnerId = (Convert.IsDBNull(dataRow["Lead Owner Id"]))?string.Empty:(System.String)dataRow["Lead Owner Id"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwZohoLeadsWithLocalTimeNoActionTodayCallableFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeNoActionTodayCallableFilterBuilder : SqlFilterBuilder<VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableFilterBuilder class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsWithLocalTimeNoActionTodayCallableFilterBuilder

	#region VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder : ParameterizedSqlFilterBuilder<VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder
	
	#region VwZohoLeadsWithLocalTimeNoActionTodayCallableSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwZohoLeadsWithLocalTimeNoActionTodayCallableSortBuilder : SqlSortBuilder<VwZohoLeadsWithLocalTimeNoActionTodayCallableColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableSqlSortBuilder class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwZohoLeadsWithLocalTimeNoActionTodayCallableSortBuilder

} // end namespace
