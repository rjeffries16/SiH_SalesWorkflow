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
	/// This class is the base class for any <see cref="VwReportingSalesInfoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwReportingSalesInfoProviderBaseCore : EntityViewProviderBase<VwReportingSalesInfo>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwReportingSalesInfo&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwReportingSalesInfo&gt;"/></returns>
		protected static VList&lt;VwReportingSalesInfo&gt; Fill(DataSet dataSet, VList<VwReportingSalesInfo> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwReportingSalesInfo>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwReportingSalesInfo&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwReportingSalesInfo>"/></returns>
		protected static VList&lt;VwReportingSalesInfo&gt; Fill(DataTable dataTable, VList<VwReportingSalesInfo> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwReportingSalesInfo c = new VwReportingSalesInfo();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.LeadCreateDate = (Convert.IsDBNull(row["LeadCreateDate"]))?DateTime.MinValue:(System.DateTime?)row["LeadCreateDate"];
					c.SoldToPerson = (Convert.IsDBNull(row["Sold to Person"]))?string.Empty:(System.String)row["Sold to Person"];
					c.SaleDate = (Convert.IsDBNull(row["Sale Date"]))?DateTime.MinValue:(System.DateTime?)row["Sale Date"];
					c.DaysToSale = (Convert.IsDBNull(row["DaysToSale"]))?(int)0:(System.Int32?)row["DaysToSale"];
					c.CallCount = (Convert.IsDBNull(row["CallCount"]))?(int)0:(System.Int32?)row["CallCount"];
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
		/// Fill an <see cref="VList&lt;VwReportingSalesInfo&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwReportingSalesInfo&gt;"/></returns>
		protected VList<VwReportingSalesInfo> Fill(IDataReader reader, VList<VwReportingSalesInfo> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwReportingSalesInfo entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwReportingSalesInfo>("VwReportingSalesInfo",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwReportingSalesInfo();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.Leadid)))?null:(System.String)reader[((int)VwReportingSalesInfoColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.FirstName = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.FirstName)))?null:(System.String)reader[((int)VwReportingSalesInfoColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.LastName)))?null:(System.String)reader[((int)VwReportingSalesInfoColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwReportingSalesInfoColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.LeadCreateDate = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.LeadCreateDate)))?null:(System.DateTime?)reader[((int)VwReportingSalesInfoColumn.LeadCreateDate)];
					//entity.LeadCreateDate = (Convert.IsDBNull(reader["LeadCreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["LeadCreateDate"];
					entity.SoldToPerson = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.SoldToPerson)))?null:(System.String)reader[((int)VwReportingSalesInfoColumn.SoldToPerson)];
					//entity.SoldToPerson = (Convert.IsDBNull(reader["Sold to Person"]))?string.Empty:(System.String)reader["Sold to Person"];
					entity.SaleDate = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.SaleDate)))?null:(System.DateTime?)reader[((int)VwReportingSalesInfoColumn.SaleDate)];
					//entity.SaleDate = (Convert.IsDBNull(reader["Sale Date"]))?DateTime.MinValue:(System.DateTime?)reader["Sale Date"];
					entity.DaysToSale = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.DaysToSale)))?null:(System.Int32?)reader[((int)VwReportingSalesInfoColumn.DaysToSale)];
					//entity.DaysToSale = (Convert.IsDBNull(reader["DaysToSale"]))?(int)0:(System.Int32?)reader["DaysToSale"];
					entity.CallCount = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.CallCount)))?null:(System.Int32?)reader[((int)VwReportingSalesInfoColumn.CallCount)];
					//entity.CallCount = (Convert.IsDBNull(reader["CallCount"]))?(int)0:(System.Int32?)reader["CallCount"];
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
		/// Refreshes the <see cref="VwReportingSalesInfo"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwReportingSalesInfo"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwReportingSalesInfo entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.Leadid)))?null:(System.String)reader[((int)VwReportingSalesInfoColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.FirstName = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.FirstName)))?null:(System.String)reader[((int)VwReportingSalesInfoColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.LastName)))?null:(System.String)reader[((int)VwReportingSalesInfoColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwReportingSalesInfoColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.LeadCreateDate = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.LeadCreateDate)))?null:(System.DateTime?)reader[((int)VwReportingSalesInfoColumn.LeadCreateDate)];
			//entity.LeadCreateDate = (Convert.IsDBNull(reader["LeadCreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["LeadCreateDate"];
			entity.SoldToPerson = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.SoldToPerson)))?null:(System.String)reader[((int)VwReportingSalesInfoColumn.SoldToPerson)];
			//entity.SoldToPerson = (Convert.IsDBNull(reader["Sold to Person"]))?string.Empty:(System.String)reader["Sold to Person"];
			entity.SaleDate = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.SaleDate)))?null:(System.DateTime?)reader[((int)VwReportingSalesInfoColumn.SaleDate)];
			//entity.SaleDate = (Convert.IsDBNull(reader["Sale Date"]))?DateTime.MinValue:(System.DateTime?)reader["Sale Date"];
			entity.DaysToSale = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.DaysToSale)))?null:(System.Int32?)reader[((int)VwReportingSalesInfoColumn.DaysToSale)];
			//entity.DaysToSale = (Convert.IsDBNull(reader["DaysToSale"]))?(int)0:(System.Int32?)reader["DaysToSale"];
			entity.CallCount = (reader.IsDBNull(((int)VwReportingSalesInfoColumn.CallCount)))?null:(System.Int32?)reader[((int)VwReportingSalesInfoColumn.CallCount)];
			//entity.CallCount = (Convert.IsDBNull(reader["CallCount"]))?(int)0:(System.Int32?)reader["CallCount"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwReportingSalesInfo"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwReportingSalesInfo"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwReportingSalesInfo entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.LeadCreateDate = (Convert.IsDBNull(dataRow["LeadCreateDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadCreateDate"];
			entity.SoldToPerson = (Convert.IsDBNull(dataRow["Sold to Person"]))?string.Empty:(System.String)dataRow["Sold to Person"];
			entity.SaleDate = (Convert.IsDBNull(dataRow["Sale Date"]))?DateTime.MinValue:(System.DateTime?)dataRow["Sale Date"];
			entity.DaysToSale = (Convert.IsDBNull(dataRow["DaysToSale"]))?(int)0:(System.Int32?)dataRow["DaysToSale"];
			entity.CallCount = (Convert.IsDBNull(dataRow["CallCount"]))?(int)0:(System.Int32?)dataRow["CallCount"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwReportingSalesInfoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingSalesInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingSalesInfoFilterBuilder : SqlFilterBuilder<VwReportingSalesInfoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoFilterBuilder class.
		/// </summary>
		public VwReportingSalesInfoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingSalesInfoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingSalesInfoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingSalesInfoFilterBuilder

	#region VwReportingSalesInfoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingSalesInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingSalesInfoParameterBuilder : ParameterizedSqlFilterBuilder<VwReportingSalesInfoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoParameterBuilder class.
		/// </summary>
		public VwReportingSalesInfoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingSalesInfoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingSalesInfoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingSalesInfoParameterBuilder
	
	#region VwReportingSalesInfoSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingSalesInfo"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwReportingSalesInfoSortBuilder : SqlSortBuilder<VwReportingSalesInfoColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoSqlSortBuilder class.
		/// </summary>
		public VwReportingSalesInfoSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwReportingSalesInfoSortBuilder

} // end namespace
