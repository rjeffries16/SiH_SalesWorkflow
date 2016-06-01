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
	/// This class is the base class for any <see cref="VwReportingLeadsAndSalesBoardProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwReportingLeadsAndSalesBoardProviderBaseCore : EntityViewProviderBase<VwReportingLeadsAndSalesBoard>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwReportingLeadsAndSalesBoard&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwReportingLeadsAndSalesBoard&gt;"/></returns>
		protected static VList&lt;VwReportingLeadsAndSalesBoard&gt; Fill(DataSet dataSet, VList<VwReportingLeadsAndSalesBoard> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwReportingLeadsAndSalesBoard>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwReportingLeadsAndSalesBoard&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwReportingLeadsAndSalesBoard>"/></returns>
		protected static VList&lt;VwReportingLeadsAndSalesBoard&gt; Fill(DataTable dataTable, VList<VwReportingLeadsAndSalesBoard> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwReportingLeadsAndSalesBoard c = new VwReportingLeadsAndSalesBoard();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.LeadCreateDate = (Convert.IsDBNull(row["LeadCreateDate"]))?DateTime.MinValue:(System.DateTime?)row["LeadCreateDate"];
					c.SoldToPerson = (Convert.IsDBNull(row["Sold to Person"]))?string.Empty:(System.String)row["Sold to Person"];
					c.SaleDate = (Convert.IsDBNull(row["Sale Date"]))?DateTime.MinValue:(System.DateTime?)row["Sale Date"];
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
		/// Fill an <see cref="VList&lt;VwReportingLeadsAndSalesBoard&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwReportingLeadsAndSalesBoard&gt;"/></returns>
		protected VList<VwReportingLeadsAndSalesBoard> Fill(IDataReader reader, VList<VwReportingLeadsAndSalesBoard> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwReportingLeadsAndSalesBoard entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwReportingLeadsAndSalesBoard>("VwReportingLeadsAndSalesBoard",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwReportingLeadsAndSalesBoard();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.Leadid)))?null:(System.String)reader[((int)VwReportingLeadsAndSalesBoardColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.FirstName = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.FirstName)))?null:(System.String)reader[((int)VwReportingLeadsAndSalesBoardColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.LastName)))?null:(System.String)reader[((int)VwReportingLeadsAndSalesBoardColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwReportingLeadsAndSalesBoardColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.LeadCreateDate = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.LeadCreateDate)))?null:(System.DateTime?)reader[((int)VwReportingLeadsAndSalesBoardColumn.LeadCreateDate)];
					//entity.LeadCreateDate = (Convert.IsDBNull(reader["LeadCreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["LeadCreateDate"];
					entity.SoldToPerson = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.SoldToPerson)))?null:(System.String)reader[((int)VwReportingLeadsAndSalesBoardColumn.SoldToPerson)];
					//entity.SoldToPerson = (Convert.IsDBNull(reader["Sold to Person"]))?string.Empty:(System.String)reader["Sold to Person"];
					entity.SaleDate = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.SaleDate)))?null:(System.DateTime?)reader[((int)VwReportingLeadsAndSalesBoardColumn.SaleDate)];
					//entity.SaleDate = (Convert.IsDBNull(reader["Sale Date"]))?DateTime.MinValue:(System.DateTime?)reader["Sale Date"];
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
		/// Refreshes the <see cref="VwReportingLeadsAndSalesBoard"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwReportingLeadsAndSalesBoard"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwReportingLeadsAndSalesBoard entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.Leadid)))?null:(System.String)reader[((int)VwReportingLeadsAndSalesBoardColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.FirstName = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.FirstName)))?null:(System.String)reader[((int)VwReportingLeadsAndSalesBoardColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.LastName)))?null:(System.String)reader[((int)VwReportingLeadsAndSalesBoardColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwReportingLeadsAndSalesBoardColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.LeadCreateDate = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.LeadCreateDate)))?null:(System.DateTime?)reader[((int)VwReportingLeadsAndSalesBoardColumn.LeadCreateDate)];
			//entity.LeadCreateDate = (Convert.IsDBNull(reader["LeadCreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["LeadCreateDate"];
			entity.SoldToPerson = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.SoldToPerson)))?null:(System.String)reader[((int)VwReportingLeadsAndSalesBoardColumn.SoldToPerson)];
			//entity.SoldToPerson = (Convert.IsDBNull(reader["Sold to Person"]))?string.Empty:(System.String)reader["Sold to Person"];
			entity.SaleDate = (reader.IsDBNull(((int)VwReportingLeadsAndSalesBoardColumn.SaleDate)))?null:(System.DateTime?)reader[((int)VwReportingLeadsAndSalesBoardColumn.SaleDate)];
			//entity.SaleDate = (Convert.IsDBNull(reader["Sale Date"]))?DateTime.MinValue:(System.DateTime?)reader["Sale Date"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwReportingLeadsAndSalesBoard"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwReportingLeadsAndSalesBoard"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwReportingLeadsAndSalesBoard entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.LeadCreateDate = (Convert.IsDBNull(dataRow["LeadCreateDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadCreateDate"];
			entity.SoldToPerson = (Convert.IsDBNull(dataRow["Sold to Person"]))?string.Empty:(System.String)dataRow["Sold to Person"];
			entity.SaleDate = (Convert.IsDBNull(dataRow["Sale Date"]))?DateTime.MinValue:(System.DateTime?)dataRow["Sale Date"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwReportingLeadsAndSalesBoardFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingLeadsAndSalesBoard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingLeadsAndSalesBoardFilterBuilder : SqlFilterBuilder<VwReportingLeadsAndSalesBoardColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardFilterBuilder class.
		/// </summary>
		public VwReportingLeadsAndSalesBoardFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingLeadsAndSalesBoardFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingLeadsAndSalesBoardFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingLeadsAndSalesBoardFilterBuilder

	#region VwReportingLeadsAndSalesBoardParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingLeadsAndSalesBoard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingLeadsAndSalesBoardParameterBuilder : ParameterizedSqlFilterBuilder<VwReportingLeadsAndSalesBoardColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardParameterBuilder class.
		/// </summary>
		public VwReportingLeadsAndSalesBoardParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingLeadsAndSalesBoardParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingLeadsAndSalesBoardParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingLeadsAndSalesBoardParameterBuilder
	
	#region VwReportingLeadsAndSalesBoardSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingLeadsAndSalesBoard"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwReportingLeadsAndSalesBoardSortBuilder : SqlSortBuilder<VwReportingLeadsAndSalesBoardColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardSqlSortBuilder class.
		/// </summary>
		public VwReportingLeadsAndSalesBoardSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwReportingLeadsAndSalesBoardSortBuilder

} // end namespace
