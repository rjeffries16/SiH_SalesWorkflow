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
	/// This class is the base class for any <see cref="VwLeadsAndCallsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwLeadsAndCallsProviderBaseCore : EntityViewProviderBase<VwLeadsAndCalls>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwLeadsAndCalls&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwLeadsAndCalls&gt;"/></returns>
		protected static VList&lt;VwLeadsAndCalls&gt; Fill(DataSet dataSet, VList<VwLeadsAndCalls> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwLeadsAndCalls>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwLeadsAndCalls&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwLeadsAndCalls>"/></returns>
		protected static VList&lt;VwLeadsAndCalls&gt; Fill(DataTable dataTable, VList<VwLeadsAndCalls> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwLeadsAndCalls c = new VwLeadsAndCalls();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.LastActivityTime = (Convert.IsDBNull(row["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)row["Last Activity Time"];
					c.LastVisitedTime = (Convert.IsDBNull(row["Last Visited Time"]))?string.Empty:(System.String)row["Last Visited Time"];
					c.LeadOwner = (Convert.IsDBNull(row["Lead Owner"]))?string.Empty:(System.String)row["Lead Owner"];
					c.LeadSource = (Convert.IsDBNull(row["Lead Source"]))?string.Empty:(System.String)row["Lead Source"];
					c.Rating = (Convert.IsDBNull(row["Rating"]))?string.Empty:(System.String)row["Rating"];
					c.LeadStatus = (Convert.IsDBNull(row["Lead Status"]))?string.Empty:(System.String)row["Lead Status"];
					c.TimeZone = (Convert.IsDBNull(row["Time Zone"]))?string.Empty:(System.String)row["Time Zone"];
					c.SafeNameCallDurationInMinutes = (Convert.IsDBNull(row["Call Duration (in minutes)"]))?0.0f:(System.Double?)row["Call Duration (in minutes)"];
					c.CallPurpose = (Convert.IsDBNull(row["Call Purpose"]))?string.Empty:(System.String)row["Call Purpose"];
					c.CallResult = (Convert.IsDBNull(row["Call Result"]))?string.Empty:(System.String)row["Call Result"];
					c.CallStartTime = (Convert.IsDBNull(row["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)row["Call Start Time"];
					c.CreatedBy = (Convert.IsDBNull(row["CreatedBy"]))?string.Empty:(System.String)row["CreatedBy"];
					c.Subject = (Convert.IsDBNull(row["Subject"]))?string.Empty:(System.String)row["Subject"];
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
		/// Fill an <see cref="VList&lt;VwLeadsAndCalls&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwLeadsAndCalls&gt;"/></returns>
		protected VList<VwLeadsAndCalls> Fill(IDataReader reader, VList<VwLeadsAndCalls> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwLeadsAndCalls entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwLeadsAndCalls>("VwLeadsAndCalls",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwLeadsAndCalls();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.Leadid)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.LastName = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LastName)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.FirstName = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.FirstName)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwLeadsAndCallsColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.LastActivityTime = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LastActivityTime)))?null:(System.DateTime?)reader[((int)VwLeadsAndCallsColumn.LastActivityTime)];
					//entity.LastActivityTime = (Convert.IsDBNull(reader["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)reader["Last Activity Time"];
					entity.LastVisitedTime = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LastVisitedTime)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.LastVisitedTime)];
					//entity.LastVisitedTime = (Convert.IsDBNull(reader["Last Visited Time"]))?string.Empty:(System.String)reader["Last Visited Time"];
					entity.LeadOwner = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LeadOwner)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.LeadOwner)];
					//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
					entity.LeadSource = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LeadSource)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.LeadSource)];
					//entity.LeadSource = (Convert.IsDBNull(reader["Lead Source"]))?string.Empty:(System.String)reader["Lead Source"];
					entity.Rating = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.Rating)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.Rating)];
					//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
					entity.LeadStatus = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LeadStatus)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.LeadStatus)];
					//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
					entity.TimeZone = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.TimeZone)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.TimeZone)];
					//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
					entity.SafeNameCallDurationInMinutes = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.SafeNameCallDurationInMinutes)))?null:(System.Double?)reader[((int)VwLeadsAndCallsColumn.SafeNameCallDurationInMinutes)];
					//entity.SafeNameCallDurationInMinutes = (Convert.IsDBNull(reader["Call Duration (in minutes)"]))?0.0f:(System.Double?)reader["Call Duration (in minutes)"];
					entity.CallPurpose = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.CallPurpose)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.CallPurpose)];
					//entity.CallPurpose = (Convert.IsDBNull(reader["Call Purpose"]))?string.Empty:(System.String)reader["Call Purpose"];
					entity.CallResult = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.CallResult)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.CallResult)];
					//entity.CallResult = (Convert.IsDBNull(reader["Call Result"]))?string.Empty:(System.String)reader["Call Result"];
					entity.CallStartTime = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwLeadsAndCallsColumn.CallStartTime)];
					//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
					entity.CreatedBy = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.CreatedBy)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.CreatedBy)];
					//entity.CreatedBy = (Convert.IsDBNull(reader["CreatedBy"]))?string.Empty:(System.String)reader["CreatedBy"];
					entity.Subject = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.Subject)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.Subject)];
					//entity.Subject = (Convert.IsDBNull(reader["Subject"]))?string.Empty:(System.String)reader["Subject"];
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
		/// Refreshes the <see cref="VwLeadsAndCalls"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadsAndCalls"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwLeadsAndCalls entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.Leadid)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.LastName = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LastName)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.FirstName = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.FirstName)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwLeadsAndCallsColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.LastActivityTime = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LastActivityTime)))?null:(System.DateTime?)reader[((int)VwLeadsAndCallsColumn.LastActivityTime)];
			//entity.LastActivityTime = (Convert.IsDBNull(reader["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)reader["Last Activity Time"];
			entity.LastVisitedTime = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LastVisitedTime)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.LastVisitedTime)];
			//entity.LastVisitedTime = (Convert.IsDBNull(reader["Last Visited Time"]))?string.Empty:(System.String)reader["Last Visited Time"];
			entity.LeadOwner = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LeadOwner)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.LeadOwner)];
			//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
			entity.LeadSource = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LeadSource)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.LeadSource)];
			//entity.LeadSource = (Convert.IsDBNull(reader["Lead Source"]))?string.Empty:(System.String)reader["Lead Source"];
			entity.Rating = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.Rating)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.Rating)];
			//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
			entity.LeadStatus = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.LeadStatus)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.LeadStatus)];
			//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
			entity.TimeZone = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.TimeZone)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.TimeZone)];
			//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
			entity.SafeNameCallDurationInMinutes = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.SafeNameCallDurationInMinutes)))?null:(System.Double?)reader[((int)VwLeadsAndCallsColumn.SafeNameCallDurationInMinutes)];
			//entity.SafeNameCallDurationInMinutes = (Convert.IsDBNull(reader["Call Duration (in minutes)"]))?0.0f:(System.Double?)reader["Call Duration (in minutes)"];
			entity.CallPurpose = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.CallPurpose)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.CallPurpose)];
			//entity.CallPurpose = (Convert.IsDBNull(reader["Call Purpose"]))?string.Empty:(System.String)reader["Call Purpose"];
			entity.CallResult = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.CallResult)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.CallResult)];
			//entity.CallResult = (Convert.IsDBNull(reader["Call Result"]))?string.Empty:(System.String)reader["Call Result"];
			entity.CallStartTime = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwLeadsAndCallsColumn.CallStartTime)];
			//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
			entity.CreatedBy = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.CreatedBy)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.CreatedBy)];
			//entity.CreatedBy = (Convert.IsDBNull(reader["CreatedBy"]))?string.Empty:(System.String)reader["CreatedBy"];
			entity.Subject = (reader.IsDBNull(((int)VwLeadsAndCallsColumn.Subject)))?null:(System.String)reader[((int)VwLeadsAndCallsColumn.Subject)];
			//entity.Subject = (Convert.IsDBNull(reader["Subject"]))?string.Empty:(System.String)reader["Subject"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwLeadsAndCalls"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadsAndCalls"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwLeadsAndCalls entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.LastActivityTime = (Convert.IsDBNull(dataRow["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Last Activity Time"];
			entity.LastVisitedTime = (Convert.IsDBNull(dataRow["Last Visited Time"]))?string.Empty:(System.String)dataRow["Last Visited Time"];
			entity.LeadOwner = (Convert.IsDBNull(dataRow["Lead Owner"]))?string.Empty:(System.String)dataRow["Lead Owner"];
			entity.LeadSource = (Convert.IsDBNull(dataRow["Lead Source"]))?string.Empty:(System.String)dataRow["Lead Source"];
			entity.Rating = (Convert.IsDBNull(dataRow["Rating"]))?string.Empty:(System.String)dataRow["Rating"];
			entity.LeadStatus = (Convert.IsDBNull(dataRow["Lead Status"]))?string.Empty:(System.String)dataRow["Lead Status"];
			entity.TimeZone = (Convert.IsDBNull(dataRow["Time Zone"]))?string.Empty:(System.String)dataRow["Time Zone"];
			entity.SafeNameCallDurationInMinutes = (Convert.IsDBNull(dataRow["Call Duration (in minutes)"]))?0.0f:(System.Double?)dataRow["Call Duration (in minutes)"];
			entity.CallPurpose = (Convert.IsDBNull(dataRow["Call Purpose"]))?string.Empty:(System.String)dataRow["Call Purpose"];
			entity.CallResult = (Convert.IsDBNull(dataRow["Call Result"]))?string.Empty:(System.String)dataRow["Call Result"];
			entity.CallStartTime = (Convert.IsDBNull(dataRow["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Call Start Time"];
			entity.CreatedBy = (Convert.IsDBNull(dataRow["CreatedBy"]))?string.Empty:(System.String)dataRow["CreatedBy"];
			entity.Subject = (Convert.IsDBNull(dataRow["Subject"]))?string.Empty:(System.String)dataRow["Subject"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwLeadsAndCallsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsAndCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsAndCallsFilterBuilder : SqlFilterBuilder<VwLeadsAndCallsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsFilterBuilder class.
		/// </summary>
		public VwLeadsAndCallsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadsAndCallsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadsAndCallsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadsAndCallsFilterBuilder

	#region VwLeadsAndCallsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsAndCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsAndCallsParameterBuilder : ParameterizedSqlFilterBuilder<VwLeadsAndCallsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsParameterBuilder class.
		/// </summary>
		public VwLeadsAndCallsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadsAndCallsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadsAndCallsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadsAndCallsParameterBuilder
	
	#region VwLeadsAndCallsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsAndCalls"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwLeadsAndCallsSortBuilder : SqlSortBuilder<VwLeadsAndCallsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsSqlSortBuilder class.
		/// </summary>
		public VwLeadsAndCallsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwLeadsAndCallsSortBuilder

} // end namespace
