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
	/// This class is the base class for any <see cref="VwZohoLeadsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwZohoLeadsProviderBaseCore : EntityViewProviderBase<VwZohoLeads>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwZohoLeads&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwZohoLeads&gt;"/></returns>
		protected static VList&lt;VwZohoLeads&gt; Fill(DataSet dataSet, VList<VwZohoLeads> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwZohoLeads>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwZohoLeads&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwZohoLeads>"/></returns>
		protected static VList&lt;VwZohoLeads&gt; Fill(DataTable dataTable, VList<VwZohoLeads> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwZohoLeads c = new VwZohoLeads();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.Leadpk = (Convert.IsDBNull(row["LEADPK"]))?(long)0:(System.Int64)row["LEADPK"];
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
		/// Fill an <see cref="VList&lt;VwZohoLeads&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwZohoLeads&gt;"/></returns>
		protected VList<VwZohoLeads> Fill(IDataReader reader, VList<VwZohoLeads> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwZohoLeads entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwZohoLeads>("VwZohoLeads",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwZohoLeads();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwZohoLeadsColumn.Leadid)))?null:(System.String)reader[((int)VwZohoLeadsColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.Leadpk = (System.Int64)reader[((int)VwZohoLeadsColumn.Leadpk)];
					//entity.Leadpk = (Convert.IsDBNull(reader["LEADPK"]))?(long)0:(System.Int64)reader["LEADPK"];
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
		/// Refreshes the <see cref="VwZohoLeads"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwZohoLeads"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwZohoLeads entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwZohoLeadsColumn.Leadid)))?null:(System.String)reader[((int)VwZohoLeadsColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.Leadpk = (System.Int64)reader[((int)VwZohoLeadsColumn.Leadpk)];
			//entity.Leadpk = (Convert.IsDBNull(reader["LEADPK"]))?(long)0:(System.Int64)reader["LEADPK"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwZohoLeads"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwZohoLeads"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwZohoLeads entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.Leadpk = (Convert.IsDBNull(dataRow["LEADPK"]))?(long)0:(System.Int64)dataRow["LEADPK"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwZohoLeadsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsFilterBuilder : SqlFilterBuilder<VwZohoLeadsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsFilterBuilder class.
		/// </summary>
		public VwZohoLeadsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsFilterBuilder

	#region VwZohoLeadsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsParameterBuilder : ParameterizedSqlFilterBuilder<VwZohoLeadsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsParameterBuilder class.
		/// </summary>
		public VwZohoLeadsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsParameterBuilder
	
	#region VwZohoLeadsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeads"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwZohoLeadsSortBuilder : SqlSortBuilder<VwZohoLeadsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsSqlSortBuilder class.
		/// </summary>
		public VwZohoLeadsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwZohoLeadsSortBuilder

} // end namespace
