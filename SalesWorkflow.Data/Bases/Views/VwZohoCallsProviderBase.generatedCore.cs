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
	/// This class is the base class for any <see cref="VwZohoCallsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwZohoCallsProviderBaseCore : EntityViewProviderBase<VwZohoCalls>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwZohoCalls&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwZohoCalls&gt;"/></returns>
		protected static VList&lt;VwZohoCalls&gt; Fill(DataSet dataSet, VList<VwZohoCalls> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwZohoCalls>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwZohoCalls&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwZohoCalls>"/></returns>
		protected static VList&lt;VwZohoCalls&gt; Fill(DataTable dataTable, VList<VwZohoCalls> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwZohoCalls c = new VwZohoCalls();
					c.Taskid = (Convert.IsDBNull(row["TASKID"]))?string.Empty:(System.String)row["TASKID"];
					c.CallPk = (Convert.IsDBNull(row["CallPK"]))?(long)0:(System.Int64)row["CallPK"];
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
		/// Fill an <see cref="VList&lt;VwZohoCalls&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwZohoCalls&gt;"/></returns>
		protected VList<VwZohoCalls> Fill(IDataReader reader, VList<VwZohoCalls> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwZohoCalls entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwZohoCalls>("VwZohoCalls",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwZohoCalls();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Taskid = (reader.IsDBNull(((int)VwZohoCallsColumn.Taskid)))?null:(System.String)reader[((int)VwZohoCallsColumn.Taskid)];
					//entity.Taskid = (Convert.IsDBNull(reader["TASKID"]))?string.Empty:(System.String)reader["TASKID"];
					entity.CallPk = (System.Int64)reader[((int)VwZohoCallsColumn.CallPk)];
					//entity.CallPk = (Convert.IsDBNull(reader["CallPK"]))?(long)0:(System.Int64)reader["CallPK"];
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
		/// Refreshes the <see cref="VwZohoCalls"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwZohoCalls"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwZohoCalls entity)
		{
			reader.Read();
			entity.Taskid = (reader.IsDBNull(((int)VwZohoCallsColumn.Taskid)))?null:(System.String)reader[((int)VwZohoCallsColumn.Taskid)];
			//entity.Taskid = (Convert.IsDBNull(reader["TASKID"]))?string.Empty:(System.String)reader["TASKID"];
			entity.CallPk = (System.Int64)reader[((int)VwZohoCallsColumn.CallPk)];
			//entity.CallPk = (Convert.IsDBNull(reader["CallPK"]))?(long)0:(System.Int64)reader["CallPK"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwZohoCalls"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwZohoCalls"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwZohoCalls entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Taskid = (Convert.IsDBNull(dataRow["TASKID"]))?string.Empty:(System.String)dataRow["TASKID"];
			entity.CallPk = (Convert.IsDBNull(dataRow["CallPK"]))?(long)0:(System.Int64)dataRow["CallPK"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwZohoCallsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoCallsFilterBuilder : SqlFilterBuilder<VwZohoCallsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsFilterBuilder class.
		/// </summary>
		public VwZohoCallsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoCallsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoCallsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoCallsFilterBuilder

	#region VwZohoCallsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoCallsParameterBuilder : ParameterizedSqlFilterBuilder<VwZohoCallsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsParameterBuilder class.
		/// </summary>
		public VwZohoCallsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoCallsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoCallsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoCallsParameterBuilder
	
	#region VwZohoCallsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoCalls"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwZohoCallsSortBuilder : SqlSortBuilder<VwZohoCallsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsSqlSortBuilder class.
		/// </summary>
		public VwZohoCallsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwZohoCallsSortBuilder

} // end namespace
