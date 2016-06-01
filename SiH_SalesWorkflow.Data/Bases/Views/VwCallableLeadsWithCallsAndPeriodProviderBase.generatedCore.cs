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
	/// This class is the base class for any <see cref="VwCallableLeadsWithCallsAndPeriodProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwCallableLeadsWithCallsAndPeriodProviderBaseCore : EntityViewProviderBase<VwCallableLeadsWithCallsAndPeriod>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwCallableLeadsWithCallsAndPeriod&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwCallableLeadsWithCallsAndPeriod&gt;"/></returns>
		protected static VList&lt;VwCallableLeadsWithCallsAndPeriod&gt; Fill(DataSet dataSet, VList<VwCallableLeadsWithCallsAndPeriod> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwCallableLeadsWithCallsAndPeriod>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwCallableLeadsWithCallsAndPeriod&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwCallableLeadsWithCallsAndPeriod>"/></returns>
		protected static VList&lt;VwCallableLeadsWithCallsAndPeriod&gt; Fill(DataTable dataTable, VList<VwCallableLeadsWithCallsAndPeriod> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwCallableLeadsWithCallsAndPeriod c = new VwCallableLeadsWithCallsAndPeriod();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.Phone = (Convert.IsDBNull(row["Phone"]))?string.Empty:(System.String)row["Phone"];
					c.CallStartTime = (Convert.IsDBNull(row["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)row["Call Start Time"];
					c.Hour = (Convert.IsDBNull(row["HOUR"]))?(int)0:(System.Int32?)row["HOUR"];
					c.Daytype = (Convert.IsDBNull(row["DAYTYPE"]))?string.Empty:(System.String)row["DAYTYPE"];
					c.TimeZone = (Convert.IsDBNull(row["Time Zone"]))?string.Empty:(System.String)row["Time Zone"];
					c.HourAdj = (Convert.IsDBNull(row["HOUR_ADJ"]))?(int)0:(System.Int32?)row["HOUR_ADJ"];
					c.Period = (Convert.IsDBNull(row["PERIOD"]))?string.Empty:(System.String)row["PERIOD"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
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
		/// Fill an <see cref="VList&lt;VwCallableLeadsWithCallsAndPeriod&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwCallableLeadsWithCallsAndPeriod&gt;"/></returns>
		protected VList<VwCallableLeadsWithCallsAndPeriod> Fill(IDataReader reader, VList<VwCallableLeadsWithCallsAndPeriod> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwCallableLeadsWithCallsAndPeriod entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwCallableLeadsWithCallsAndPeriod>("VwCallableLeadsWithCallsAndPeriod",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwCallableLeadsWithCallsAndPeriod();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.Leadid)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.FirstName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.FirstName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.LastName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.Phone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.Phone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
					entity.CallStartTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.CallStartTime)];
					//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
					entity.Hour = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.Hour)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.Hour)];
					//entity.Hour = (Convert.IsDBNull(reader["HOUR"]))?(int)0:(System.Int32?)reader["HOUR"];
					entity.Daytype = (System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.Daytype)];
					//entity.Daytype = (Convert.IsDBNull(reader["DAYTYPE"]))?string.Empty:(System.String)reader["DAYTYPE"];
					entity.TimeZone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.TimeZone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.TimeZone)];
					//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
					entity.HourAdj = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.HourAdj)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.HourAdj)];
					//entity.HourAdj = (Convert.IsDBNull(reader["HOUR_ADJ"]))?(int)0:(System.Int32?)reader["HOUR_ADJ"];
					entity.Period = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.Period)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.Period)];
					//entity.Period = (Convert.IsDBNull(reader["PERIOD"]))?string.Empty:(System.String)reader["PERIOD"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
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
		/// Refreshes the <see cref="VwCallableLeadsWithCallsAndPeriod"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwCallableLeadsWithCallsAndPeriod"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwCallableLeadsWithCallsAndPeriod entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.Leadid)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.FirstName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.FirstName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.LastName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.Phone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.Phone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			entity.CallStartTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.CallStartTime)];
			//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
			entity.Hour = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.Hour)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.Hour)];
			//entity.Hour = (Convert.IsDBNull(reader["HOUR"]))?(int)0:(System.Int32?)reader["HOUR"];
			entity.Daytype = (System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.Daytype)];
			//entity.Daytype = (Convert.IsDBNull(reader["DAYTYPE"]))?string.Empty:(System.String)reader["DAYTYPE"];
			entity.TimeZone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.TimeZone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.TimeZone)];
			//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
			entity.HourAdj = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.HourAdj)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.HourAdj)];
			//entity.HourAdj = (Convert.IsDBNull(reader["HOUR_ADJ"]))?(int)0:(System.Int32?)reader["HOUR_ADJ"];
			entity.Period = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.Period)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.Period)];
			//entity.Period = (Convert.IsDBNull(reader["PERIOD"]))?string.Empty:(System.String)reader["PERIOD"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndPeriodColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndPeriodColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwCallableLeadsWithCallsAndPeriod"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwCallableLeadsWithCallsAndPeriod"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwCallableLeadsWithCallsAndPeriod entity)
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
			entity.HourAdj = (Convert.IsDBNull(dataRow["HOUR_ADJ"]))?(int)0:(System.Int32?)dataRow["HOUR_ADJ"];
			entity.Period = (Convert.IsDBNull(dataRow["PERIOD"]))?string.Empty:(System.String)dataRow["PERIOD"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwCallableLeadsWithCallsAndPeriodFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodFilterBuilder : SqlFilterBuilder<VwCallableLeadsWithCallsAndPeriodColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodFilterBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndPeriodFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndPeriodFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndPeriodFilterBuilder

	#region VwCallableLeadsWithCallsAndPeriodParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodParameterBuilder : ParameterizedSqlFilterBuilder<VwCallableLeadsWithCallsAndPeriodColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodParameterBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndPeriodParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndPeriodParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndPeriodParameterBuilder
	
	#region VwCallableLeadsWithCallsAndPeriodSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriod"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwCallableLeadsWithCallsAndPeriodSortBuilder : SqlSortBuilder<VwCallableLeadsWithCallsAndPeriodColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodSqlSortBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwCallableLeadsWithCallsAndPeriodSortBuilder

} // end namespace
