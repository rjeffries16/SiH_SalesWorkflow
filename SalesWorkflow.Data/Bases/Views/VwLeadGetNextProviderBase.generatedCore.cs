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
	/// This class is the base class for any <see cref="VwLeadGetNextProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwLeadGetNextProviderBaseCore : EntityViewProviderBase<VwLeadGetNext>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwLeadGetNext&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwLeadGetNext&gt;"/></returns>
		protected static VList&lt;VwLeadGetNext&gt; Fill(DataSet dataSet, VList<VwLeadGetNext> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwLeadGetNext>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwLeadGetNext&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwLeadGetNext>"/></returns>
		protected static VList&lt;VwLeadGetNext&gt; Fill(DataTable dataTable, VList<VwLeadGetNext> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwLeadGetNext c = new VwLeadGetNext();
					c.LeadStatus = (Convert.IsDBNull(row["Lead Status"]))?string.Empty:(System.String)row["Lead Status"];
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.Email = (Convert.IsDBNull(row["Email"]))?string.Empty:(System.String)row["Email"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.IfNoLongerInterested = (Convert.IsDBNull(row["If No Longer Interested"]))?string.Empty:(System.String)row["If No Longer Interested"];
					c.LastActivityTime = (Convert.IsDBNull(row["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)row["Last Activity Time"];
					c.LastVisitedTime = (Convert.IsDBNull(row["Last Visited Time"]))?string.Empty:(System.String)row["Last Visited Time"];
					c.Rating = (Convert.IsDBNull(row["Rating"]))?string.Empty:(System.String)row["Rating"];
					c.State = (Convert.IsDBNull(row["State"]))?string.Empty:(System.String)row["State"];
					c.TimeZone = (Convert.IsDBNull(row["Time Zone"]))?string.Empty:(System.String)row["Time Zone"];
					c.Phone = (Convert.IsDBNull(row["Phone"]))?string.Empty:(System.String)row["Phone"];
					c.Rank = (Convert.IsDBNull(row["Rank"]))?(int)0:(System.Int32)row["Rank"];
					c.LeadOwner = (Convert.IsDBNull(row["Lead Owner"]))?string.Empty:(System.String)row["Lead Owner"];
					c.UserId = (Convert.IsDBNull(row["USER_ID"]))?string.Empty:(System.String)row["USER_ID"];
					c.LeadHoldDts = (Convert.IsDBNull(row["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)row["LeadHoldDts"];
					c.LeadActionDts = (Convert.IsDBNull(row["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)row["LeadActionDts"];
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
		/// Fill an <see cref="VList&lt;VwLeadGetNext&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwLeadGetNext&gt;"/></returns>
		protected VList<VwLeadGetNext> Fill(IDataReader reader, VList<VwLeadGetNext> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwLeadGetNext entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwLeadGetNext>("VwLeadGetNext",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwLeadGetNext();
					}
					
					entity.SuppressEntityEvents = true;

					entity.LeadStatus = (reader.IsDBNull(((int)VwLeadGetNextColumn.LeadStatus)))?null:(System.String)reader[((int)VwLeadGetNextColumn.LeadStatus)];
					//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
					entity.Leadid = (reader.IsDBNull(((int)VwLeadGetNextColumn.Leadid)))?null:(System.String)reader[((int)VwLeadGetNextColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwLeadGetNextColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwLeadGetNextColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.Email = (reader.IsDBNull(((int)VwLeadGetNextColumn.Email)))?null:(System.String)reader[((int)VwLeadGetNextColumn.Email)];
					//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
					entity.FirstName = (reader.IsDBNull(((int)VwLeadGetNextColumn.FirstName)))?null:(System.String)reader[((int)VwLeadGetNextColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwLeadGetNextColumn.LastName)))?null:(System.String)reader[((int)VwLeadGetNextColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.IfNoLongerInterested = (reader.IsDBNull(((int)VwLeadGetNextColumn.IfNoLongerInterested)))?null:(System.String)reader[((int)VwLeadGetNextColumn.IfNoLongerInterested)];
					//entity.IfNoLongerInterested = (Convert.IsDBNull(reader["If No Longer Interested"]))?string.Empty:(System.String)reader["If No Longer Interested"];
					entity.LastActivityTime = (reader.IsDBNull(((int)VwLeadGetNextColumn.LastActivityTime)))?null:(System.DateTime?)reader[((int)VwLeadGetNextColumn.LastActivityTime)];
					//entity.LastActivityTime = (Convert.IsDBNull(reader["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)reader["Last Activity Time"];
					entity.LastVisitedTime = (reader.IsDBNull(((int)VwLeadGetNextColumn.LastVisitedTime)))?null:(System.String)reader[((int)VwLeadGetNextColumn.LastVisitedTime)];
					//entity.LastVisitedTime = (Convert.IsDBNull(reader["Last Visited Time"]))?string.Empty:(System.String)reader["Last Visited Time"];
					entity.Rating = (reader.IsDBNull(((int)VwLeadGetNextColumn.Rating)))?null:(System.String)reader[((int)VwLeadGetNextColumn.Rating)];
					//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
					entity.State = (reader.IsDBNull(((int)VwLeadGetNextColumn.State)))?null:(System.String)reader[((int)VwLeadGetNextColumn.State)];
					//entity.State = (Convert.IsDBNull(reader["State"]))?string.Empty:(System.String)reader["State"];
					entity.TimeZone = (reader.IsDBNull(((int)VwLeadGetNextColumn.TimeZone)))?null:(System.String)reader[((int)VwLeadGetNextColumn.TimeZone)];
					//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
					entity.Phone = (reader.IsDBNull(((int)VwLeadGetNextColumn.Phone)))?null:(System.String)reader[((int)VwLeadGetNextColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
					entity.Rank = (System.Int32)reader[((int)VwLeadGetNextColumn.Rank)];
					//entity.Rank = (Convert.IsDBNull(reader["Rank"]))?(int)0:(System.Int32)reader["Rank"];
					entity.LeadOwner = (reader.IsDBNull(((int)VwLeadGetNextColumn.LeadOwner)))?null:(System.String)reader[((int)VwLeadGetNextColumn.LeadOwner)];
					//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
					entity.UserId = (reader.IsDBNull(((int)VwLeadGetNextColumn.UserId)))?null:(System.String)reader[((int)VwLeadGetNextColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["USER_ID"]))?string.Empty:(System.String)reader["USER_ID"];
					entity.LeadHoldDts = (reader.IsDBNull(((int)VwLeadGetNextColumn.LeadHoldDts)))?null:(System.DateTime?)reader[((int)VwLeadGetNextColumn.LeadHoldDts)];
					//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadHoldDts"];
					entity.LeadActionDts = (reader.IsDBNull(((int)VwLeadGetNextColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwLeadGetNextColumn.LeadActionDts)];
					//entity.LeadActionDts = (Convert.IsDBNull(reader["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadActionDts"];
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
		/// Refreshes the <see cref="VwLeadGetNext"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadGetNext"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwLeadGetNext entity)
		{
			reader.Read();
			entity.LeadStatus = (reader.IsDBNull(((int)VwLeadGetNextColumn.LeadStatus)))?null:(System.String)reader[((int)VwLeadGetNextColumn.LeadStatus)];
			//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
			entity.Leadid = (reader.IsDBNull(((int)VwLeadGetNextColumn.Leadid)))?null:(System.String)reader[((int)VwLeadGetNextColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwLeadGetNextColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwLeadGetNextColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.Email = (reader.IsDBNull(((int)VwLeadGetNextColumn.Email)))?null:(System.String)reader[((int)VwLeadGetNextColumn.Email)];
			//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
			entity.FirstName = (reader.IsDBNull(((int)VwLeadGetNextColumn.FirstName)))?null:(System.String)reader[((int)VwLeadGetNextColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwLeadGetNextColumn.LastName)))?null:(System.String)reader[((int)VwLeadGetNextColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.IfNoLongerInterested = (reader.IsDBNull(((int)VwLeadGetNextColumn.IfNoLongerInterested)))?null:(System.String)reader[((int)VwLeadGetNextColumn.IfNoLongerInterested)];
			//entity.IfNoLongerInterested = (Convert.IsDBNull(reader["If No Longer Interested"]))?string.Empty:(System.String)reader["If No Longer Interested"];
			entity.LastActivityTime = (reader.IsDBNull(((int)VwLeadGetNextColumn.LastActivityTime)))?null:(System.DateTime?)reader[((int)VwLeadGetNextColumn.LastActivityTime)];
			//entity.LastActivityTime = (Convert.IsDBNull(reader["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)reader["Last Activity Time"];
			entity.LastVisitedTime = (reader.IsDBNull(((int)VwLeadGetNextColumn.LastVisitedTime)))?null:(System.String)reader[((int)VwLeadGetNextColumn.LastVisitedTime)];
			//entity.LastVisitedTime = (Convert.IsDBNull(reader["Last Visited Time"]))?string.Empty:(System.String)reader["Last Visited Time"];
			entity.Rating = (reader.IsDBNull(((int)VwLeadGetNextColumn.Rating)))?null:(System.String)reader[((int)VwLeadGetNextColumn.Rating)];
			//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
			entity.State = (reader.IsDBNull(((int)VwLeadGetNextColumn.State)))?null:(System.String)reader[((int)VwLeadGetNextColumn.State)];
			//entity.State = (Convert.IsDBNull(reader["State"]))?string.Empty:(System.String)reader["State"];
			entity.TimeZone = (reader.IsDBNull(((int)VwLeadGetNextColumn.TimeZone)))?null:(System.String)reader[((int)VwLeadGetNextColumn.TimeZone)];
			//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
			entity.Phone = (reader.IsDBNull(((int)VwLeadGetNextColumn.Phone)))?null:(System.String)reader[((int)VwLeadGetNextColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			entity.Rank = (System.Int32)reader[((int)VwLeadGetNextColumn.Rank)];
			//entity.Rank = (Convert.IsDBNull(reader["Rank"]))?(int)0:(System.Int32)reader["Rank"];
			entity.LeadOwner = (reader.IsDBNull(((int)VwLeadGetNextColumn.LeadOwner)))?null:(System.String)reader[((int)VwLeadGetNextColumn.LeadOwner)];
			//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
			entity.UserId = (reader.IsDBNull(((int)VwLeadGetNextColumn.UserId)))?null:(System.String)reader[((int)VwLeadGetNextColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["USER_ID"]))?string.Empty:(System.String)reader["USER_ID"];
			entity.LeadHoldDts = (reader.IsDBNull(((int)VwLeadGetNextColumn.LeadHoldDts)))?null:(System.DateTime?)reader[((int)VwLeadGetNextColumn.LeadHoldDts)];
			//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadHoldDts"];
			entity.LeadActionDts = (reader.IsDBNull(((int)VwLeadGetNextColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwLeadGetNextColumn.LeadActionDts)];
			//entity.LeadActionDts = (Convert.IsDBNull(reader["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadActionDts"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwLeadGetNext"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadGetNext"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwLeadGetNext entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.LeadStatus = (Convert.IsDBNull(dataRow["Lead Status"]))?string.Empty:(System.String)dataRow["Lead Status"];
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.Email = (Convert.IsDBNull(dataRow["Email"]))?string.Empty:(System.String)dataRow["Email"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.IfNoLongerInterested = (Convert.IsDBNull(dataRow["If No Longer Interested"]))?string.Empty:(System.String)dataRow["If No Longer Interested"];
			entity.LastActivityTime = (Convert.IsDBNull(dataRow["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Last Activity Time"];
			entity.LastVisitedTime = (Convert.IsDBNull(dataRow["Last Visited Time"]))?string.Empty:(System.String)dataRow["Last Visited Time"];
			entity.Rating = (Convert.IsDBNull(dataRow["Rating"]))?string.Empty:(System.String)dataRow["Rating"];
			entity.State = (Convert.IsDBNull(dataRow["State"]))?string.Empty:(System.String)dataRow["State"];
			entity.TimeZone = (Convert.IsDBNull(dataRow["Time Zone"]))?string.Empty:(System.String)dataRow["Time Zone"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?string.Empty:(System.String)dataRow["Phone"];
			entity.Rank = (Convert.IsDBNull(dataRow["Rank"]))?(int)0:(System.Int32)dataRow["Rank"];
			entity.LeadOwner = (Convert.IsDBNull(dataRow["Lead Owner"]))?string.Empty:(System.String)dataRow["Lead Owner"];
			entity.UserId = (Convert.IsDBNull(dataRow["USER_ID"]))?string.Empty:(System.String)dataRow["USER_ID"];
			entity.LeadHoldDts = (Convert.IsDBNull(dataRow["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadHoldDts"];
			entity.LeadActionDts = (Convert.IsDBNull(dataRow["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadActionDts"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwLeadGetNextFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetNext"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetNextFilterBuilder : SqlFilterBuilder<VwLeadGetNextColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextFilterBuilder class.
		/// </summary>
		public VwLeadGetNextFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetNextFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetNextFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetNextFilterBuilder

	#region VwLeadGetNextParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetNext"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetNextParameterBuilder : ParameterizedSqlFilterBuilder<VwLeadGetNextColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextParameterBuilder class.
		/// </summary>
		public VwLeadGetNextParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetNextParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetNextParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetNextParameterBuilder
	
	#region VwLeadGetNextSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetNext"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwLeadGetNextSortBuilder : SqlSortBuilder<VwLeadGetNextColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextSqlSortBuilder class.
		/// </summary>
		public VwLeadGetNextSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwLeadGetNextSortBuilder

} // end namespace
