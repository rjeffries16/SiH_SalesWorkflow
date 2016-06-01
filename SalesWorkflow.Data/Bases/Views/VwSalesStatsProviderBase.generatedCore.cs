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
	/// This class is the base class for any <see cref="VwSalesStatsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwSalesStatsProviderBaseCore : EntityViewProviderBase<VwSalesStats>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwSalesStats&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwSalesStats&gt;"/></returns>
		protected static VList&lt;VwSalesStats&gt; Fill(DataSet dataSet, VList<VwSalesStats> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwSalesStats>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwSalesStats&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwSalesStats>"/></returns>
		protected static VList&lt;VwSalesStats&gt; Fill(DataTable dataTable, VList<VwSalesStats> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwSalesStats c = new VwSalesStats();
					c.ExternUserCode = (Convert.IsDBNull(row["ExternUserCode"]))?string.Empty:(System.String)row["ExternUserCode"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
					c.SaleDate = (Convert.IsDBNull(row["SaleDate"]))?DateTime.MinValue:(System.DateTime?)row["SaleDate"];
					c.DaysToSale = (Convert.IsDBNull(row["DaysToSale"]))?(int)0:(System.Int32?)row["DaysToSale"];
					c.InstallDate = (Convert.IsDBNull(row["InstallDate"]))?DateTime.MinValue:(System.DateTime?)row["InstallDate"];
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
		/// Fill an <see cref="VList&lt;VwSalesStats&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwSalesStats&gt;"/></returns>
		protected VList<VwSalesStats> Fill(IDataReader reader, VList<VwSalesStats> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwSalesStats entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwSalesStats>("VwSalesStats",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwSalesStats();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ExternUserCode = (reader.IsDBNull(((int)VwSalesStatsColumn.ExternUserCode)))?null:(System.String)reader[((int)VwSalesStatsColumn.ExternUserCode)];
					//entity.ExternUserCode = (Convert.IsDBNull(reader["ExternUserCode"]))?string.Empty:(System.String)reader["ExternUserCode"];
					entity.FirstName = (reader.IsDBNull(((int)VwSalesStatsColumn.FirstName)))?null:(System.String)reader[((int)VwSalesStatsColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwSalesStatsColumn.LastName)))?null:(System.String)reader[((int)VwSalesStatsColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwSalesStatsColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwSalesStatsColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
					entity.SaleDate = (reader.IsDBNull(((int)VwSalesStatsColumn.SaleDate)))?null:(System.DateTime?)reader[((int)VwSalesStatsColumn.SaleDate)];
					//entity.SaleDate = (Convert.IsDBNull(reader["SaleDate"]))?DateTime.MinValue:(System.DateTime?)reader["SaleDate"];
					entity.DaysToSale = (reader.IsDBNull(((int)VwSalesStatsColumn.DaysToSale)))?null:(System.Int32?)reader[((int)VwSalesStatsColumn.DaysToSale)];
					//entity.DaysToSale = (Convert.IsDBNull(reader["DaysToSale"]))?(int)0:(System.Int32?)reader["DaysToSale"];
					entity.InstallDate = (reader.IsDBNull(((int)VwSalesStatsColumn.InstallDate)))?null:(System.DateTime?)reader[((int)VwSalesStatsColumn.InstallDate)];
					//entity.InstallDate = (Convert.IsDBNull(reader["InstallDate"]))?DateTime.MinValue:(System.DateTime?)reader["InstallDate"];
					entity.CallCount = (reader.IsDBNull(((int)VwSalesStatsColumn.CallCount)))?null:(System.Int32?)reader[((int)VwSalesStatsColumn.CallCount)];
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
		/// Refreshes the <see cref="VwSalesStats"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwSalesStats"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwSalesStats entity)
		{
			reader.Read();
			entity.ExternUserCode = (reader.IsDBNull(((int)VwSalesStatsColumn.ExternUserCode)))?null:(System.String)reader[((int)VwSalesStatsColumn.ExternUserCode)];
			//entity.ExternUserCode = (Convert.IsDBNull(reader["ExternUserCode"]))?string.Empty:(System.String)reader["ExternUserCode"];
			entity.FirstName = (reader.IsDBNull(((int)VwSalesStatsColumn.FirstName)))?null:(System.String)reader[((int)VwSalesStatsColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwSalesStatsColumn.LastName)))?null:(System.String)reader[((int)VwSalesStatsColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwSalesStatsColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwSalesStatsColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			entity.SaleDate = (reader.IsDBNull(((int)VwSalesStatsColumn.SaleDate)))?null:(System.DateTime?)reader[((int)VwSalesStatsColumn.SaleDate)];
			//entity.SaleDate = (Convert.IsDBNull(reader["SaleDate"]))?DateTime.MinValue:(System.DateTime?)reader["SaleDate"];
			entity.DaysToSale = (reader.IsDBNull(((int)VwSalesStatsColumn.DaysToSale)))?null:(System.Int32?)reader[((int)VwSalesStatsColumn.DaysToSale)];
			//entity.DaysToSale = (Convert.IsDBNull(reader["DaysToSale"]))?(int)0:(System.Int32?)reader["DaysToSale"];
			entity.InstallDate = (reader.IsDBNull(((int)VwSalesStatsColumn.InstallDate)))?null:(System.DateTime?)reader[((int)VwSalesStatsColumn.InstallDate)];
			//entity.InstallDate = (Convert.IsDBNull(reader["InstallDate"]))?DateTime.MinValue:(System.DateTime?)reader["InstallDate"];
			entity.CallCount = (reader.IsDBNull(((int)VwSalesStatsColumn.CallCount)))?null:(System.Int32?)reader[((int)VwSalesStatsColumn.CallCount)];
			//entity.CallCount = (Convert.IsDBNull(reader["CallCount"]))?(int)0:(System.Int32?)reader["CallCount"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwSalesStats"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwSalesStats"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwSalesStats entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ExternUserCode = (Convert.IsDBNull(dataRow["ExternUserCode"]))?string.Empty:(System.String)dataRow["ExternUserCode"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.SaleDate = (Convert.IsDBNull(dataRow["SaleDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["SaleDate"];
			entity.DaysToSale = (Convert.IsDBNull(dataRow["DaysToSale"]))?(int)0:(System.Int32?)dataRow["DaysToSale"];
			entity.InstallDate = (Convert.IsDBNull(dataRow["InstallDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["InstallDate"];
			entity.CallCount = (Convert.IsDBNull(dataRow["CallCount"]))?(int)0:(System.Int32?)dataRow["CallCount"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwSalesStatsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwSalesStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwSalesStatsFilterBuilder : SqlFilterBuilder<VwSalesStatsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsFilterBuilder class.
		/// </summary>
		public VwSalesStatsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwSalesStatsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwSalesStatsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwSalesStatsFilterBuilder

	#region VwSalesStatsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwSalesStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwSalesStatsParameterBuilder : ParameterizedSqlFilterBuilder<VwSalesStatsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsParameterBuilder class.
		/// </summary>
		public VwSalesStatsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwSalesStatsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwSalesStatsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwSalesStatsParameterBuilder
	
	#region VwSalesStatsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwSalesStats"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwSalesStatsSortBuilder : SqlSortBuilder<VwSalesStatsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsSqlSortBuilder class.
		/// </summary>
		public VwSalesStatsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwSalesStatsSortBuilder

} // end namespace
