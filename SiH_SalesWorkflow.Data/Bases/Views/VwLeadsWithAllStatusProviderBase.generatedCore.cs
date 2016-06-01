#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Data;

#endregion

namespace SiH_SalesWorkflow.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="VwLeadsWithAllStatusProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwLeadsWithAllStatusProviderBaseCore : EntityViewProviderBase<VwLeadsWithAllStatus>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwLeadsWithAllStatus&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwLeadsWithAllStatus&gt;"/></returns>
		protected static VList&lt;VwLeadsWithAllStatus&gt; Fill(DataSet dataSet, VList<VwLeadsWithAllStatus> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwLeadsWithAllStatus>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwLeadsWithAllStatus&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwLeadsWithAllStatus>"/></returns>
		protected static VList&lt;VwLeadsWithAllStatus&gt; Fill(DataTable dataTable, VList<VwLeadsWithAllStatus> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwLeadsWithAllStatus c = new VwLeadsWithAllStatus();
					c.LeadStatus = (Convert.IsDBNull(row["Lead Status"]))?string.Empty:(System.String)row["Lead Status"];
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.Email = (Convert.IsDBNull(row["Email"]))?string.Empty:(System.String)row["Email"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.IfNoLongerInterested = (Convert.IsDBNull(row["If No Longer Interested"]))?string.Empty:(System.String)row["If No Longer Interested"];
					c.LastActivityTime = (Convert.IsDBNull(row["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)row["Last Activity Time"];
					c.LastVisitedTime = (Convert.IsDBNull(row["Last Visited Time"]))?string.Empty:(System.String)row["Last Visited Time"];
					c.LeadOwner = (Convert.IsDBNull(row["Lead Owner"]))?string.Empty:(System.String)row["Lead Owner"];
					c.Rating = (Convert.IsDBNull(row["Rating"]))?string.Empty:(System.String)row["Rating"];
					c.State = (Convert.IsDBNull(row["State"]))?string.Empty:(System.String)row["State"];
					c.TimeZone = (Convert.IsDBNull(row["Time Zone"]))?string.Empty:(System.String)row["Time Zone"];
					c.Phone = (Convert.IsDBNull(row["Phone"]))?string.Empty:(System.String)row["Phone"];
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
		/// Fill an <see cref="VList&lt;VwLeadsWithAllStatus&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwLeadsWithAllStatus&gt;"/></returns>
		protected VList<VwLeadsWithAllStatus> Fill(IDataReader reader, VList<VwLeadsWithAllStatus> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwLeadsWithAllStatus entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwLeadsWithAllStatus>("VwLeadsWithAllStatus",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwLeadsWithAllStatus();
					}
					
					entity.SuppressEntityEvents = true;

					entity.LeadStatus = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LeadStatus)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.LeadStatus)];
					//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
					entity.Leadid = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.Leadid)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwLeadsWithAllStatusColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.Email = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.Email)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.Email)];
					//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
					entity.FirstName = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.FirstName)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LastName)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.IfNoLongerInterested = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.IfNoLongerInterested)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.IfNoLongerInterested)];
					//entity.IfNoLongerInterested = (Convert.IsDBNull(reader["If No Longer Interested"]))?string.Empty:(System.String)reader["If No Longer Interested"];
					entity.LastActivityTime = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LastActivityTime)))?null:(System.DateTime?)reader[((int)VwLeadsWithAllStatusColumn.LastActivityTime)];
					//entity.LastActivityTime = (Convert.IsDBNull(reader["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)reader["Last Activity Time"];
					entity.LastVisitedTime = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LastVisitedTime)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.LastVisitedTime)];
					//entity.LastVisitedTime = (Convert.IsDBNull(reader["Last Visited Time"]))?string.Empty:(System.String)reader["Last Visited Time"];
					entity.LeadOwner = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LeadOwner)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.LeadOwner)];
					//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
					entity.Rating = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.Rating)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.Rating)];
					//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
					entity.State = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.State)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.State)];
					//entity.State = (Convert.IsDBNull(reader["State"]))?string.Empty:(System.String)reader["State"];
					entity.TimeZone = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.TimeZone)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.TimeZone)];
					//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
					entity.Phone = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.Phone)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
					entity.LeadHoldDts = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LeadHoldDts)))?null:(System.DateTime?)reader[((int)VwLeadsWithAllStatusColumn.LeadHoldDts)];
					//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadHoldDts"];
					entity.LeadActionDts = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwLeadsWithAllStatusColumn.LeadActionDts)];
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
		/// Refreshes the <see cref="VwLeadsWithAllStatus"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadsWithAllStatus"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwLeadsWithAllStatus entity)
		{
			reader.Read();
			entity.LeadStatus = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LeadStatus)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.LeadStatus)];
			//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
			entity.Leadid = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.Leadid)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwLeadsWithAllStatusColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.Email = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.Email)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.Email)];
			//entity.Email = (Convert.IsDBNull(reader["Email"]))?string.Empty:(System.String)reader["Email"];
			entity.FirstName = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.FirstName)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LastName)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.IfNoLongerInterested = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.IfNoLongerInterested)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.IfNoLongerInterested)];
			//entity.IfNoLongerInterested = (Convert.IsDBNull(reader["If No Longer Interested"]))?string.Empty:(System.String)reader["If No Longer Interested"];
			entity.LastActivityTime = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LastActivityTime)))?null:(System.DateTime?)reader[((int)VwLeadsWithAllStatusColumn.LastActivityTime)];
			//entity.LastActivityTime = (Convert.IsDBNull(reader["Last Activity Time"]))?DateTime.MinValue:(System.DateTime?)reader["Last Activity Time"];
			entity.LastVisitedTime = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LastVisitedTime)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.LastVisitedTime)];
			//entity.LastVisitedTime = (Convert.IsDBNull(reader["Last Visited Time"]))?string.Empty:(System.String)reader["Last Visited Time"];
			entity.LeadOwner = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LeadOwner)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.LeadOwner)];
			//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
			entity.Rating = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.Rating)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.Rating)];
			//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
			entity.State = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.State)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.State)];
			//entity.State = (Convert.IsDBNull(reader["State"]))?string.Empty:(System.String)reader["State"];
			entity.TimeZone = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.TimeZone)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.TimeZone)];
			//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
			entity.Phone = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.Phone)))?null:(System.String)reader[((int)VwLeadsWithAllStatusColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			entity.LeadHoldDts = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LeadHoldDts)))?null:(System.DateTime?)reader[((int)VwLeadsWithAllStatusColumn.LeadHoldDts)];
			//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadHoldDts"];
			entity.LeadActionDts = (reader.IsDBNull(((int)VwLeadsWithAllStatusColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwLeadsWithAllStatusColumn.LeadActionDts)];
			//entity.LeadActionDts = (Convert.IsDBNull(reader["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadActionDts"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwLeadsWithAllStatus"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadsWithAllStatus"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwLeadsWithAllStatus entity)
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
			entity.LeadOwner = (Convert.IsDBNull(dataRow["Lead Owner"]))?string.Empty:(System.String)dataRow["Lead Owner"];
			entity.Rating = (Convert.IsDBNull(dataRow["Rating"]))?string.Empty:(System.String)dataRow["Rating"];
			entity.State = (Convert.IsDBNull(dataRow["State"]))?string.Empty:(System.String)dataRow["State"];
			entity.TimeZone = (Convert.IsDBNull(dataRow["Time Zone"]))?string.Empty:(System.String)dataRow["Time Zone"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?string.Empty:(System.String)dataRow["Phone"];
			entity.LeadHoldDts = (Convert.IsDBNull(dataRow["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadHoldDts"];
			entity.LeadActionDts = (Convert.IsDBNull(dataRow["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadActionDts"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwLeadsWithAllStatusFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithAllStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsWithAllStatusFilterBuilder : SqlFilterBuilder<VwLeadsWithAllStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusFilterBuilder class.
		/// </summary>
		public VwLeadsWithAllStatusFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadsWithAllStatusFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadsWithAllStatusFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadsWithAllStatusFilterBuilder

	#region VwLeadsWithAllStatusParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithAllStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsWithAllStatusParameterBuilder : ParameterizedSqlFilterBuilder<VwLeadsWithAllStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusParameterBuilder class.
		/// </summary>
		public VwLeadsWithAllStatusParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadsWithAllStatusParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadsWithAllStatusParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadsWithAllStatusParameterBuilder
	
	#region VwLeadsWithAllStatusSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithAllStatus"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwLeadsWithAllStatusSortBuilder : SqlSortBuilder<VwLeadsWithAllStatusColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusSqlSortBuilder class.
		/// </summary>
		public VwLeadsWithAllStatusSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwLeadsWithAllStatusSortBuilder

} // end namespace
