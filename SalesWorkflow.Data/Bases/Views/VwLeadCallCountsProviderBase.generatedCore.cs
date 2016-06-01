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
	/// This class is the base class for any <see cref="VwLeadCallCountsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwLeadCallCountsProviderBaseCore : EntityViewProviderBase<VwLeadCallCounts>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwLeadCallCounts&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwLeadCallCounts&gt;"/></returns>
		protected static VList&lt;VwLeadCallCounts&gt; Fill(DataSet dataSet, VList<VwLeadCallCounts> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwLeadCallCounts>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwLeadCallCounts&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwLeadCallCounts>"/></returns>
		protected static VList&lt;VwLeadCallCounts&gt; Fill(DataTable dataTable, VList<VwLeadCallCounts> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwLeadCallCounts c = new VwLeadCallCounts();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.CallCount = (Convert.IsDBNull(row["Call Count"]))?(int)0:(System.Int32?)row["Call Count"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.LeadStatus = (Convert.IsDBNull(row["Lead Status"]))?string.Empty:(System.String)row["Lead Status"];
					c.Rating = (Convert.IsDBNull(row["Rating"]))?string.Empty:(System.String)row["Rating"];
					c.LeadOwner = (Convert.IsDBNull(row["Lead Owner"]))?string.Empty:(System.String)row["Lead Owner"];
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
		/// Fill an <see cref="VList&lt;VwLeadCallCounts&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwLeadCallCounts&gt;"/></returns>
		protected VList<VwLeadCallCounts> Fill(IDataReader reader, VList<VwLeadCallCounts> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwLeadCallCounts entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwLeadCallCounts>("VwLeadCallCounts",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwLeadCallCounts();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwLeadCallCountsColumn.Leadid)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.LastName = (reader.IsDBNull(((int)VwLeadCallCountsColumn.LastName)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.FirstName = (reader.IsDBNull(((int)VwLeadCallCountsColumn.FirstName)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.CallCount = (reader.IsDBNull(((int)VwLeadCallCountsColumn.CallCount)))?null:(System.Int32?)reader[((int)VwLeadCallCountsColumn.CallCount)];
					//entity.CallCount = (Convert.IsDBNull(reader["Call Count"]))?(int)0:(System.Int32?)reader["Call Count"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwLeadCallCountsColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwLeadCallCountsColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.LeadStatus = (reader.IsDBNull(((int)VwLeadCallCountsColumn.LeadStatus)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.LeadStatus)];
					//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
					entity.Rating = (reader.IsDBNull(((int)VwLeadCallCountsColumn.Rating)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.Rating)];
					//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
					entity.LeadOwner = (reader.IsDBNull(((int)VwLeadCallCountsColumn.LeadOwner)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.LeadOwner)];
					//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
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
		/// Refreshes the <see cref="VwLeadCallCounts"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadCallCounts"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwLeadCallCounts entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwLeadCallCountsColumn.Leadid)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.LastName = (reader.IsDBNull(((int)VwLeadCallCountsColumn.LastName)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.FirstName = (reader.IsDBNull(((int)VwLeadCallCountsColumn.FirstName)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.CallCount = (reader.IsDBNull(((int)VwLeadCallCountsColumn.CallCount)))?null:(System.Int32?)reader[((int)VwLeadCallCountsColumn.CallCount)];
			//entity.CallCount = (Convert.IsDBNull(reader["Call Count"]))?(int)0:(System.Int32?)reader["Call Count"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwLeadCallCountsColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwLeadCallCountsColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.LeadStatus = (reader.IsDBNull(((int)VwLeadCallCountsColumn.LeadStatus)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.LeadStatus)];
			//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
			entity.Rating = (reader.IsDBNull(((int)VwLeadCallCountsColumn.Rating)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.Rating)];
			//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
			entity.LeadOwner = (reader.IsDBNull(((int)VwLeadCallCountsColumn.LeadOwner)))?null:(System.String)reader[((int)VwLeadCallCountsColumn.LeadOwner)];
			//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwLeadCallCounts"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadCallCounts"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwLeadCallCounts entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.CallCount = (Convert.IsDBNull(dataRow["Call Count"]))?(int)0:(System.Int32?)dataRow["Call Count"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.LeadStatus = (Convert.IsDBNull(dataRow["Lead Status"]))?string.Empty:(System.String)dataRow["Lead Status"];
			entity.Rating = (Convert.IsDBNull(dataRow["Rating"]))?string.Empty:(System.String)dataRow["Rating"];
			entity.LeadOwner = (Convert.IsDBNull(dataRow["Lead Owner"]))?string.Empty:(System.String)dataRow["Lead Owner"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwLeadCallCountsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadCallCounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadCallCountsFilterBuilder : SqlFilterBuilder<VwLeadCallCountsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsFilterBuilder class.
		/// </summary>
		public VwLeadCallCountsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadCallCountsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadCallCountsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadCallCountsFilterBuilder

	#region VwLeadCallCountsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadCallCounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadCallCountsParameterBuilder : ParameterizedSqlFilterBuilder<VwLeadCallCountsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsParameterBuilder class.
		/// </summary>
		public VwLeadCallCountsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadCallCountsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadCallCountsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadCallCountsParameterBuilder
	
	#region VwLeadCallCountsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadCallCounts"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwLeadCallCountsSortBuilder : SqlSortBuilder<VwLeadCallCountsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsSqlSortBuilder class.
		/// </summary>
		public VwLeadCallCountsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwLeadCallCountsSortBuilder

} // end namespace
