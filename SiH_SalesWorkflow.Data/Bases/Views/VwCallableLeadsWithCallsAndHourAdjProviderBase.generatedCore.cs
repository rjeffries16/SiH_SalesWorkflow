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
	/// This class is the base class for any <see cref="VwCallableLeadsWithCallsAndHourAdjProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwCallableLeadsWithCallsAndHourAdjProviderBaseCore : EntityViewProviderBase<VwCallableLeadsWithCallsAndHourAdj>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwCallableLeadsWithCallsAndHourAdj&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwCallableLeadsWithCallsAndHourAdj&gt;"/></returns>
		protected static VList&lt;VwCallableLeadsWithCallsAndHourAdj&gt; Fill(DataSet dataSet, VList<VwCallableLeadsWithCallsAndHourAdj> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwCallableLeadsWithCallsAndHourAdj>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwCallableLeadsWithCallsAndHourAdj&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwCallableLeadsWithCallsAndHourAdj>"/></returns>
		protected static VList&lt;VwCallableLeadsWithCallsAndHourAdj&gt; Fill(DataTable dataTable, VList<VwCallableLeadsWithCallsAndHourAdj> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwCallableLeadsWithCallsAndHourAdj c = new VwCallableLeadsWithCallsAndHourAdj();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.Phone = (Convert.IsDBNull(row["Phone"]))?string.Empty:(System.String)row["Phone"];
					c.CallStartTime = (Convert.IsDBNull(row["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)row["Call Start Time"];
					c.Hour = (Convert.IsDBNull(row["HOUR"]))?(int)0:(System.Int32?)row["HOUR"];
					c.Daytype = (Convert.IsDBNull(row["DAYTYPE"]))?string.Empty:(System.String)row["DAYTYPE"];
					c.TimeZone = (Convert.IsDBNull(row["Time Zone"]))?string.Empty:(System.String)row["Time Zone"];
					c.HourAdj = (Convert.IsDBNull(row["HOUR_ADJ"]))?(int)0:(System.Int32?)row["HOUR_ADJ"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.DayOfWeek = (Convert.IsDBNull(row["DayOfWeek"]))?(int)0:(System.Int32?)row["DayOfWeek"];
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
		/// Fill an <see cref="VList&lt;VwCallableLeadsWithCallsAndHourAdj&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwCallableLeadsWithCallsAndHourAdj&gt;"/></returns>
		protected VList<VwCallableLeadsWithCallsAndHourAdj> Fill(IDataReader reader, VList<VwCallableLeadsWithCallsAndHourAdj> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwCallableLeadsWithCallsAndHourAdj entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwCallableLeadsWithCallsAndHourAdj>("VwCallableLeadsWithCallsAndHourAdj",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwCallableLeadsWithCallsAndHourAdj();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.Leadid)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.FirstName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.FirstName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.LastName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.Phone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.Phone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.Phone)];
					//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
					entity.CallStartTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.CallStartTime)];
					//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
					entity.Hour = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.Hour)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.Hour)];
					//entity.Hour = (Convert.IsDBNull(reader["HOUR"]))?(int)0:(System.Int32?)reader["HOUR"];
					entity.Daytype = (System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.Daytype)];
					//entity.Daytype = (Convert.IsDBNull(reader["DAYTYPE"]))?string.Empty:(System.String)reader["DAYTYPE"];
					entity.TimeZone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.TimeZone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.TimeZone)];
					//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
					entity.HourAdj = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.HourAdj)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.HourAdj)];
					//entity.HourAdj = (Convert.IsDBNull(reader["HOUR_ADJ"]))?(int)0:(System.Int32?)reader["HOUR_ADJ"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.DayOfWeek = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.DayOfWeek)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.DayOfWeek)];
					//entity.DayOfWeek = (Convert.IsDBNull(reader["DayOfWeek"]))?(int)0:(System.Int32?)reader["DayOfWeek"];
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
		/// Refreshes the <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwCallableLeadsWithCallsAndHourAdj entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.Leadid)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.FirstName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.FirstName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.LastName)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.Phone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.Phone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.Phone)];
			//entity.Phone = (Convert.IsDBNull(reader["Phone"]))?string.Empty:(System.String)reader["Phone"];
			entity.CallStartTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.CallStartTime)];
			//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
			entity.Hour = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.Hour)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.Hour)];
			//entity.Hour = (Convert.IsDBNull(reader["HOUR"]))?(int)0:(System.Int32?)reader["HOUR"];
			entity.Daytype = (System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.Daytype)];
			//entity.Daytype = (Convert.IsDBNull(reader["DAYTYPE"]))?string.Empty:(System.String)reader["DAYTYPE"];
			entity.TimeZone = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.TimeZone)))?null:(System.String)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.TimeZone)];
			//entity.TimeZone = (Convert.IsDBNull(reader["Time Zone"]))?string.Empty:(System.String)reader["Time Zone"];
			entity.HourAdj = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.HourAdj)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.HourAdj)];
			//entity.HourAdj = (Convert.IsDBNull(reader["HOUR_ADJ"]))?(int)0:(System.Int32?)reader["HOUR_ADJ"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.DayOfWeek = (reader.IsDBNull(((int)VwCallableLeadsWithCallsAndHourAdjColumn.DayOfWeek)))?null:(System.Int32?)reader[((int)VwCallableLeadsWithCallsAndHourAdjColumn.DayOfWeek)];
			//entity.DayOfWeek = (Convert.IsDBNull(reader["DayOfWeek"]))?(int)0:(System.Int32?)reader["DayOfWeek"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwCallableLeadsWithCallsAndHourAdj entity)
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
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.DayOfWeek = (Convert.IsDBNull(dataRow["DayOfWeek"]))?(int)0:(System.Int32?)dataRow["DayOfWeek"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwCallableLeadsWithCallsAndHourAdjFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndHourAdjFilterBuilder : SqlFilterBuilder<VwCallableLeadsWithCallsAndHourAdjColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjFilterBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsAndHourAdjFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndHourAdjFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndHourAdjFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndHourAdjFilterBuilder

	#region VwCallableLeadsWithCallsAndHourAdjParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndHourAdjParameterBuilder : ParameterizedSqlFilterBuilder<VwCallableLeadsWithCallsAndHourAdjColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjParameterBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsAndHourAdjParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndHourAdjParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndHourAdjParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndHourAdjParameterBuilder
	
	#region VwCallableLeadsWithCallsAndHourAdjSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwCallableLeadsWithCallsAndHourAdjSortBuilder : SqlSortBuilder<VwCallableLeadsWithCallsAndHourAdjColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjSqlSortBuilder class.
		/// </summary>
		public VwCallableLeadsWithCallsAndHourAdjSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwCallableLeadsWithCallsAndHourAdjSortBuilder

} // end namespace
