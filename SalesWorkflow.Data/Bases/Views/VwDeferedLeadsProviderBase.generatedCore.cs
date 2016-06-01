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
	/// This class is the base class for any <see cref="VwDeferedLeadsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwDeferedLeadsProviderBaseCore : EntityViewProviderBase<VwDeferedLeads>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwDeferedLeads&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwDeferedLeads&gt;"/></returns>
		protected static VList&lt;VwDeferedLeads&gt; Fill(DataSet dataSet, VList<VwDeferedLeads> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwDeferedLeads>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwDeferedLeads&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwDeferedLeads>"/></returns>
		protected static VList&lt;VwDeferedLeads&gt; Fill(DataTable dataTable, VList<VwDeferedLeads> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwDeferedLeads c = new VwDeferedLeads();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
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
		/// Fill an <see cref="VList&lt;VwDeferedLeads&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwDeferedLeads&gt;"/></returns>
		protected VList<VwDeferedLeads> Fill(IDataReader reader, VList<VwDeferedLeads> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwDeferedLeads entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwDeferedLeads>("VwDeferedLeads",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwDeferedLeads();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (System.String)reader[((int)VwDeferedLeadsColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
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
		/// Refreshes the <see cref="VwDeferedLeads"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwDeferedLeads"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwDeferedLeads entity)
		{
			reader.Read();
			entity.Leadid = (System.String)reader[((int)VwDeferedLeadsColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwDeferedLeads"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwDeferedLeads"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwDeferedLeads entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwDeferedLeadsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwDeferedLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwDeferedLeadsFilterBuilder : SqlFilterBuilder<VwDeferedLeadsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsFilterBuilder class.
		/// </summary>
		public VwDeferedLeadsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwDeferedLeadsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwDeferedLeadsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwDeferedLeadsFilterBuilder

	#region VwDeferedLeadsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwDeferedLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwDeferedLeadsParameterBuilder : ParameterizedSqlFilterBuilder<VwDeferedLeadsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsParameterBuilder class.
		/// </summary>
		public VwDeferedLeadsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwDeferedLeadsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwDeferedLeadsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwDeferedLeadsParameterBuilder
	
	#region VwDeferedLeadsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwDeferedLeads"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwDeferedLeadsSortBuilder : SqlSortBuilder<VwDeferedLeadsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsSqlSortBuilder class.
		/// </summary>
		public VwDeferedLeadsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwDeferedLeadsSortBuilder

} // end namespace
