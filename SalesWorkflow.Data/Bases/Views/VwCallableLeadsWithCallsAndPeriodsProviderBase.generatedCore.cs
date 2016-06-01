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
	/// This class is the base class for any <see cref="VwCallableLeadsWithCallsAndPeriodsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwCallableLeadsWithCallsAndPeriodsProviderBaseCore : EntityViewProviderBase<VwCallableLeadsWithCallsAndPeriods>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwCallableLeadsWithCallsAndPeriods&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwCallableLeadsWithCallsAndPeriods&gt;"/></returns>
		protected static VList&lt;VwCallableLeadsWithCallsAndPeriods&gt; Fill(DataSet dataSet, VList<VwCallableLeadsWithCallsAndPeriods> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwCallableLeadsWithCallsAndPeriods>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwCallableLeadsWithCallsAndPeriods&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwCallableLeadsWithCallsAndPeriods>"/></returns>
		protected static VList&lt;VwCallableLeadsWithCallsAndPeriods&gt; Fill(DataTable dataTable, VList<VwCallableLeadsWithCallsAndPeriods> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwCallableLeadsWithCallsAndPeriods c = new VwCallableLeadsWithCallsAndPeriods();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.IfNoLongerInterested = (Convert.IsDBNull(row["If No Longer Interested"]))?string.Empty:(System.String)row["If No Longer Interested"];
					c.LastActivityTime = (Convert.IsDBNull(row["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)row["Last Activity Time"];
					c.LeadOwner = (Convert.IsDBNull(row["Lead Owner"]))?string.Empty:(System.String)row["Lead Owner"];
					c.Rating = (Convert.IsDBNull(row["Rating"]))?string.Empty:(System.String)row["Rating"];
					c.State = (Convert.IsDBNull(row["State"]))?string.Empty:(System.String)row["State"];
					c.TimeZone = (Convert.IsDBNull(row["Time Zone"]))?string.Empty:(System.String)row["Time Zone"];
					c.SatMc = (Convert.IsDBNull(row["SatMC"]))?(int)0:(System.Int32?)row["SatMC"];
					c.SatDc = (Convert.IsDBNull(row["SatDC"]))?(int)0:(System.Int32?)row["SatDC"];
					c.SatAc = (Convert.IsDBNull(row["SatAC"]))?(int)0:(System.Int32?)row["SatAC"];
					c.SatEc = (Convert.IsDBNull(row["SatEC"]))?(int)0:(System.Int32?)row["SatEC"];
					c.SunMc = (Convert.IsDBNull(row["SunMC"]))?(int)0:(System.Int32?)row["SunMC"];
					c.SunDc = (Convert.IsDBNull(row["SunDC"]))?(int)0:(System.Int32?)row["SunDC"];
					c.SunAc = (Convert.IsDBNull(row["SunAC"]))?(int)0:(System.Int32?)row["SunAC"];
					c.SunEc = (Convert.IsDBNull(row["SunEC"]))?(int)0:(System.Int32?)row["SunEC"];
					c.Dmc = (Convert.IsDBNull(row["DMC"]))?(int)0:(System.Int32?)row["DMC"];
					c.Ddc = (Convert.IsDBNull(row["DDC"]))?(int)0:(System.Int32?)row["DDC"];
					c.Dac = (Convert.IsDBNull(row["DAC"]))?(int)0:(System.Int32?)row["DAC"];
					c.Dec = (Convert.IsDBNull(row["DEC"]))?(int)0:(System.Int32?)row["DEC"];
					c.Phone = (Convert.IsDBNull(row["Phone"]))?string.Empty:(System.String)row["Phone"];
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
		/// Fill an <see cref="VList&lt;VwCallableLeadsWithCallsAndPeriods&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwCallableLeadsWithCallsAndPeriods&gt;"/></returns>
		protected VList<VwCallableLeadsWithCallsAndPeriods> Fill(IDataReader reader, VList<VwCallableLeadsWithCallsAndPeriods> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwCallableLeadsWithCallsAndPeriods entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwCallableLeadsWithCallsAndPeriods>("VwCallableLeadsWithCallsAndPeriods",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwCallableLeadsWithCallsAndPeriods();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Leadid)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.FirstName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.FirstName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.LastName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.IfNoLongerInterested = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.IfNoLongerInterested)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.IfNoLongerInterested)];
					//entity.IfNoLongerInterested = (Convert.IsDBNull(reader["If No Longer Interested"]))?string.Empty:(System.String)reader["If No Longer Interested"];
					entity.LastActivityTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.LastActivityTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.LastActivityTime)];
					//entity.LastActivityTime = (Convert.IsDBNull(reader["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)reader["Last Activity Time"];
					entity.LeadOwner = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.LeadOwner)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.LeadOwner)];
					//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
					entity.Rating = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Rating)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Rating)];
					//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
					entity.State = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.State)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.State)];
					//entity.State = (Convert.IsDBNull(reader["State"]))?string.Empty:(System.String)reader["State"];
					entity.TimeZone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.TimeZone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.TimeZone)];
					//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
					entity.SatMc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatMc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatMc)];
					//entity.SatMc = (Convert.IsDBNull(reader["SatMC"]))?(int)0:(System.Int32?)reader["SatMC"];
					entity.SatDc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatDc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatDc)];
					//entity.SatDc = (Convert.IsDBNull(reader["SatDC"]))?(int)0:(System.Int32?)reader["SatDC"];
					entity.SatAc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatAc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatAc)];
					//entity.SatAc = (Convert.IsDBNull(reader["SatAC"]))?(int)0:(System.Int32?)reader["SatAC"];
					entity.SatEc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatEc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatEc)];
					//entity.SatEc = (Convert.IsDBNull(reader["SatEC"]))?(int)0:(System.Int32?)reader["SatEC"];
					entity.SunMc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunMc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunMc)];
					//entity.SunMc = (Convert.IsDBNull(reader["SunMC"]))?(int)0:(System.Int32?)reader["SunMC"];
					entity.SunDc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunDc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunDc)];
					//entity.SunDc = (Convert.IsDBNull(reader["SunDC"]))?(int)0:(System.Int32?)reader["SunDC"];
					entity.SunAc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunAc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunAc)];
					//entity.SunAc = (Convert.IsDBNull(reader["SunAC"]))?(int)0:(System.Int32?)reader["SunAC"];
					entity.SunEc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunEc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunEc)];
					//entity.SunEc = (Convert.IsDBNull(reader["SunEC"]))?(int)0:(System.Int32?)reader["SunEC"];
					entity.Dmc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dmc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dmc)];
					//entity.Dmc = (Convert.IsDBNull(reader["DMC"]))?(int)0:(System.Int32?)reader["DMC"];
					entity.Ddc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Ddc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Ddc)];
					//entity.Ddc = (Convert.IsDBNull(reader["DDC"]))?(int)0:(System.Int32?)reader["DDC"];
					entity.Dac = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dac)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dac)];
					//entity.Dac = (Convert.IsDBNull(reader["DAC"]))?(int)0:(System.Int32?)reader["DAC"];
					entity.Dec = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dec)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dec)];
					//entity.Dec = (Convert.IsDBNull(reader["DEC"]))?(int)0:(System.Int32?)reader["DEC"];
					entity.Phone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Phone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
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
		/// Refreshes the <see cref="VwCallableLeadsWithCallsAndPeriods"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwCallableLeadsWithCallsAndPeriods"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwCallableLeadsWithCallsAndPeriods entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Leadid)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.FirstName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.FirstName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.LastName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.IfNoLongerInterested = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.IfNoLongerInterested)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.IfNoLongerInterested)];
			//entity.IfNoLongerInterested = (Convert.IsDBNull(reader["If No Longer Interested"]))?string.Empty:(System.String)reader["If No Longer Interested"];
			entity.LastActivityTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.LastActivityTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.LastActivityTime)];
			//entity.LastActivityTime = (Convert.IsDBNull(reader["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)reader["Last Activity Time"];
			entity.LeadOwner = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.LeadOwner)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.LeadOwner)];
			//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
			entity.Rating = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Rating)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Rating)];
			//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
			entity.State = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.State)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.State)];
			//entity.State = (Convert.IsDBNull(reader["State"]))?string.Empty:(System.String)reader["State"];
			entity.TimeZone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.TimeZone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.TimeZone)];
			//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
			entity.SatMc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatMc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatMc)];
			//entity.SatMc = (Convert.IsDBNull(reader["SatMC"]))?(int)0:(System.Int32?)reader["SatMC"];
			entity.SatDc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatDc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatDc)];
			//entity.SatDc = (Convert.IsDBNull(reader["SatDC"]))?(int)0:(System.Int32?)reader["SatDC"];
			entity.SatAc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatAc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatAc)];
			//entity.SatAc = (Convert.IsDBNull(reader["SatAC"]))?(int)0:(System.Int32?)reader["SatAC"];
			entity.SatEc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatEc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SatEc)];
			//entity.SatEc = (Convert.IsDBNull(reader["SatEC"]))?(int)0:(System.Int32?)reader["SatEC"];
			entity.SunMc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunMc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunMc)];
			//entity.SunMc = (Convert.IsDBNull(reader["SunMC"]))?(int)0:(System.Int32?)reader["SunMC"];
			entity.SunDc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunDc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunDc)];
			//entity.SunDc = (Convert.IsDBNull(reader["SunDC"]))?(int)0:(System.Int32?)reader["SunDC"];
			entity.SunAc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunAc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunAc)];
			//entity.SunAc = (Convert.IsDBNull(reader["SunAC"]))?(int)0:(System.Int32?)reader["SunAC"];
			entity.SunEc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunEc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.SunEc)];
			//entity.SunEc = (Convert.IsDBNull(reader["SunEC"]))?(int)0:(System.Int32?)reader["SunEC"];
			entity.Dmc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dmc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dmc)];
			//entity.Dmc = (Convert.IsDBNull(reader["DMC"]))?(int)0:(System.Int32?)reader["DMC"];
			entity.Ddc = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Ddc)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Ddc)];
			//entity.Ddc = (Convert.IsDBNull(reader["DDC"]))?(int)0:(System.Int32?)reader["DDC"];
			entity.Dac = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dac)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dac)];
			//entity.Dac = (Convert.IsDBNull(reader["DAC"]))?(int)0:(System.Int32?)reader["DAC"];
			entity.Dec = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dec)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Dec)];
			//entity.Dec = (Convert.IsDBNull(reader["DEC"]))?(int)0:(System.Int32?)reader["DEC"];
			entity.Phone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodsColumn.Phone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodsColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwCallableLeadsWithCallsAndPeriods"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwCallableLeadsWithCallsAndPeriods"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwCallableLeadsWithCallsAndPeriods entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.IfNoLongerInterested = (Convert.IsDBNull(dataRow["If No Longer Interested"]))?string.Empty:(System.String)dataRow["If No Longer Interested"];
			entity.LastActivityTime = (Convert.IsDBNull(dataRow["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Last Activity Time"];
			entity.LeadOwner = (Convert.IsDBNull(dataRow["Lead Owner"]))?string.Empty:(System.String)dataRow["Lead Owner"];
			entity.Rating = (Convert.IsDBNull(dataRow["Rating"]))?string.Empty:(System.String)dataRow["Rating"];
			entity.State = (Convert.IsDBNull(dataRow["State"]))?string.Empty:(System.String)dataRow["State"];
			entity.TimeZone = (Convert.IsDBNull(dataRow["Time Zone"]))?string.Empty:(System.String)dataRow["Time Zone"];
			entity.SatMc = (Convert.IsDBNull(dataRow["SatMC"]))?(int)0:(System.Int32?)dataRow["SatMC"];
			entity.SatDc = (Convert.IsDBNull(dataRow["SatDC"]))?(int)0:(System.Int32?)dataRow["SatDC"];
			entity.SatAc = (Convert.IsDBNull(dataRow["SatAC"]))?(int)0:(System.Int32?)dataRow["SatAC"];
			entity.SatEc = (Convert.IsDBNull(dataRow["SatEC"]))?(int)0:(System.Int32?)dataRow["SatEC"];
			entity.SunMc = (Convert.IsDBNull(dataRow["SunMC"]))?(int)0:(System.Int32?)dataRow["SunMC"];
			entity.SunDc = (Convert.IsDBNull(dataRow["SunDC"]))?(int)0:(System.Int32?)dataRow["SunDC"];
			entity.SunAc = (Convert.IsDBNull(dataRow["SunAC"]))?(int)0:(System.Int32?)dataRow["SunAC"];
			entity.SunEc = (Convert.IsDBNull(dataRow["SunEC"]))?(int)0:(System.Int32?)dataRow["SunEC"];
			entity.Dmc = (Convert.IsDBNull(dataRow["DMC"]))?(int)0:(System.Int32?)dataRow["DMC"];
			entity.Ddc = (Convert.IsDBNull(dataRow["DDC"]))?(int)0:(System.Int32?)dataRow["DDC"];
			entity.Dac = (Convert.IsDBNull(dataRow["DAC"]))?(int)0:(System.Int32?)dataRow["DAC"];
			entity.Dec = (Convert.IsDBNull(dataRow["DEC"]))?(int)0:(System.Int32?)dataRow["DEC"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?string.Empty:(System.String)dataRow["Phone"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwCallableLeadsWithCallsAndPeriodsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriods"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodsFilterBuilder : SqlFilterBuilder<VwCallableLeadsWithCallsAndPeriodsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsFilterBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndPeriodsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndPeriodsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndPeriodsFilterBuilder

	#region VwCallableLeadsWithCallsAndPeriodsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriods"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodsParameterBuilder : ParameterizedSqlFilterBuilder<VwCallableLeadsWithCallsAndPeriodsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsParameterBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndPeriodsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndPeriodsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndPeriodsParameterBuilder
	
	#region VwCallableLeadsWithCallsAndPeriodsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriods"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwCallableLeadsWithCallsAndPeriodsSortBuilder : SqlSortBuilder<VwCallableLeadsWithCallsAndPeriodsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsSqlSortBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwCallableLeadsWithCallsAndPeriodsSortBuilder

} // end namespace
