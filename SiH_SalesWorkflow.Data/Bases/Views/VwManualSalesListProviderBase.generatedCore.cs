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
	/// This class is the base class for any <see cref="VwManualSalesListProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwManualSalesListProviderBaseCore : EntityViewProviderBase<VwManualSalesList>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwManualSalesList&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwManualSalesList&gt;"/></returns>
		protected static VList&lt;VwManualSalesList&gt; Fill(DataSet dataSet, VList<VwManualSalesList> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwManualSalesList>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwManualSalesList&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwManualSalesList>"/></returns>
		protected static VList&lt;VwManualSalesList&gt; Fill(DataTable dataTable, VList<VwManualSalesList> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwManualSalesList c = new VwManualSalesList();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.LeadStatus = (Convert.IsDBNull(row["Lead Status"]))?string.Empty:(System.String)row["Lead Status"];
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
		/// Fill an <see cref="VList&lt;VwManualSalesList&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwManualSalesList&gt;"/></returns>
		protected VList<VwManualSalesList> Fill(IDataReader reader, VList<VwManualSalesList> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwManualSalesList entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwManualSalesList>("VwManualSalesList",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwManualSalesList();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwManualSalesListColumn.Leadid)))?null:(System.String)reader[((int)VwManualSalesListColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.FirstName = (reader.IsDBNull(((int)VwManualSalesListColumn.FirstName)))?null:(System.String)reader[((int)VwManualSalesListColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwManualSalesListColumn.LastName)))?null:(System.String)reader[((int)VwManualSalesListColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.LeadStatus = (reader.IsDBNull(((int)VwManualSalesListColumn.LeadStatus)))?null:(System.String)reader[((int)VwManualSalesListColumn.LeadStatus)];
					//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
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
		/// Refreshes the <see cref="VwManualSalesList"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwManualSalesList"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwManualSalesList entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwManualSalesListColumn.Leadid)))?null:(System.String)reader[((int)VwManualSalesListColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.FirstName = (reader.IsDBNull(((int)VwManualSalesListColumn.FirstName)))?null:(System.String)reader[((int)VwManualSalesListColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwManualSalesListColumn.LastName)))?null:(System.String)reader[((int)VwManualSalesListColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.LeadStatus = (reader.IsDBNull(((int)VwManualSalesListColumn.LeadStatus)))?null:(System.String)reader[((int)VwManualSalesListColumn.LeadStatus)];
			//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwManualSalesList"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwManualSalesList"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwManualSalesList entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.LeadStatus = (Convert.IsDBNull(dataRow["Lead Status"]))?string.Empty:(System.String)dataRow["Lead Status"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwManualSalesListFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwManualSalesList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwManualSalesListFilterBuilder : SqlFilterBuilder<VwManualSalesListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListFilterBuilder class.
		/// </summary>
		public VwManualSalesListFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwManualSalesListFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwManualSalesListFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwManualSalesListFilterBuilder

	#region VwManualSalesListParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwManualSalesList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwManualSalesListParameterBuilder : ParameterizedSqlFilterBuilder<VwManualSalesListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListParameterBuilder class.
		/// </summary>
		public VwManualSalesListParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwManualSalesListParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwManualSalesListParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwManualSalesListParameterBuilder
	
	#region VwManualSalesListSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwManualSalesList"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwManualSalesListSortBuilder : SqlSortBuilder<VwManualSalesListColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListSqlSortBuilder class.
		/// </summary>
		public VwManualSalesListSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwManualSalesListSortBuilder

} // end namespace
