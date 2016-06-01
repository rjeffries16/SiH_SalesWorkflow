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
	/// This class is the base class for any <see cref="VwCallableLeadsWithCallsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwCallableLeadsWithCallsProviderBaseCore : EntityViewProviderBase<VwCallableLeadsWithCalls>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwCallableLeadsWithCalls&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwCallableLeadsWithCalls&gt;"/></returns>
		protected static VList&lt;VwCallableLeadsWithCalls&gt; Fill(DataSet dataSet, VList<VwCallableLeadsWithCalls> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwCallableLeadsWithCalls>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwCallableLeadsWithCalls&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwCallableLeadsWithCalls>"/></returns>
		protected static VList&lt;VwCallableLeadsWithCalls&gt; Fill(DataTable dataTable, VList<VwCallableLeadsWithCalls> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwCallableLeadsWithCalls c = new VwCallableLeadsWithCalls();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.Phone = (Convert.IsDBNull(row["Phone"]))?string.Empty:(System.String)row["Phone"];
					c.CallStartTime = (Convert.IsDBNull(row["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)row["Call Start Time"];
					c.Hour = (Convert.IsDBNull(row["HOUR"]))?(int)0:(System.Int32?)row["HOUR"];
					c.Daytype = (Convert.IsDBNull(row["DAYTYPE"]))?string.Empty:(System.String)row["DAYTYPE"];
					c.TimeZone = (Convert.IsDBNull(row["Time Zone"]))?string.Empty:(System.String)row["Time Zone"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.DayOfWeek = (Convert.IsDBNull(row["DayOfWeek"]))?(int)0:(System.Int32?)row["DayOfWeek"];
					c.Rating = (Convert.IsDBNull(row["Rating"]))?string.Empty:(System.String)row["Rating"];
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
		/// Fill an <see cref="VList&lt;VwCallableLeadsWithCalls&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwCallableLeadsWithCalls&gt;"/></returns>
		protected VList<VwCallableLeadsWithCalls> Fill(IDataReader reader, VList<VwCallableLeadsWithCalls> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwCallableLeadsWithCalls entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwCallableLeadsWithCalls>("VwCallableLeadsWithCalls",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwCallableLeadsWithCalls();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.Leadid)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.FirstName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.FirstName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.LastName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.Phone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.Phone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
					entity.CallStartTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsColumn.CallStartTime)];
					//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
					entity.Hour = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.Hour)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsColumn.Hour)];
					//entity.Hour = (Convert.IsDBNull(reader["HOUR"]))?(int)0:(System.Int32?)reader["HOUR"];
					entity.Daytype = (System.String)reader[((int)VwCallableLeadsWithCallsColumn.Daytype)];
					//entity.Daytype = (Convert.IsDBNull(reader["DAYTYPE"]))?string.Empty:(System.String)reader["DAYTYPE"];
					entity.TimeZone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.TimeZone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.TimeZone)];
					//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.DayOfWeek = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.DayOfWeek)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsColumn.DayOfWeek)];
					//entity.DayOfWeek = (Convert.IsDBNull(reader["DayOfWeek"]))?(int)0:(System.Int32?)reader["DayOfWeek"];
					entity.Rating = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.Rating)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.Rating)];
					//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
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
		/// Refreshes the <see cref="VwCallableLeadsWithCalls"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwCallableLeadsWithCalls"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwCallableLeadsWithCalls entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.Leadid)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.FirstName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.FirstName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.LastName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.Phone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.Phone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			entity.CallStartTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsColumn.CallStartTime)];
			//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
			entity.Hour = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.Hour)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsColumn.Hour)];
			//entity.Hour = (Convert.IsDBNull(reader["HOUR"]))?(int)0:(System.Int32?)reader["HOUR"];
			entity.Daytype = (System.String)reader[((int)VwCallableLeadsWithCallsColumn.Daytype)];
			//entity.Daytype = (Convert.IsDBNull(reader["DAYTYPE"]))?string.Empty:(System.String)reader["DAYTYPE"];
			entity.TimeZone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.TimeZone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.TimeZone)];
			//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.DayOfWeek = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.DayOfWeek)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsColumn.DayOfWeek)];
			//entity.DayOfWeek = (Convert.IsDBNull(reader["DayOfWeek"]))?(int)0:(System.Int32?)reader["DayOfWeek"];
			entity.Rating = (reader.IsDBNull(((int)VwCallableLeadsWithCallsColumn.Rating)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsColumn.Rating)];
			//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwCallableLeadsWithCalls"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwCallableLeadsWithCalls"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwCallableLeadsWithCalls entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.Phone = (Convert.IsDBNull(dataRow["Phone"]))?string.Empty:(System.String)dataRow["Phone"];
			entity.CallStartTime = (Convert.IsDBNull(dataRow["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Call Start Time"];
			entity.Hour = (Convert.IsDBNull(dataRow["HOUR"]))?(int)0:(System.Int32?)dataRow["HOUR"];
			entity.Daytype = (Convert.IsDBNull(dataRow["DAYTYPE"]))?string.Empty:(System.String)dataRow["DAYTYPE"];
			entity.TimeZone = (Convert.IsDBNull(dataRow["Time Zone"]))?string.Empty:(System.String)dataRow["Time Zone"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.DayOfWeek = (Convert.IsDBNull(dataRow["DayOfWeek"]))?(int)0:(System.Int32?)dataRow["DayOfWeek"];
			entity.Rating = (Convert.IsDBNull(dataRow["Rating"]))?string.Empty:(System.String)dataRow["Rating"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwCallableLeadsWithCallsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsFilterBuilder : SqlFilterBuilder<VwCallableLeadsWithCallsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsFilterBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsFilterBuilder

	#region VwCallableLeadsWithCallsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsParameterBuilder : ParameterizedSqlFilterBuilder<VwCallableLeadsWithCallsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsParameterBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsParameterBuilder
	
	#region VwCallableLeadsWithCallsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCalls"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwCallableLeadsWithCallsSortBuilder : SqlSortBuilder<VwCallableLeadsWithCallsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsSqlSortBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwCallableLeadsWithCallsSortBuilder

} // end namespace
