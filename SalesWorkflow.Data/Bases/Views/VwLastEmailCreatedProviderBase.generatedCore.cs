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
	/// This class is the base class for any <see cref="VwLastEmailCreatedProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwLastEmailCreatedProviderBaseCore : EntityViewProviderBase<VwLastEmailCreated>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwLastEmailCreated&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwLastEmailCreated&gt;"/></returns>
		protected static VList&lt;VwLastEmailCreated&gt; Fill(DataSet dataSet, VList<VwLastEmailCreated> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwLastEmailCreated>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwLastEmailCreated&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwLastEmailCreated>"/></returns>
		protected static VList&lt;VwLastEmailCreated&gt; Fill(DataTable dataTable, VList<VwLastEmailCreated> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwLastEmailCreated c = new VwLastEmailCreated();
					c.LastEmailCreated = (Convert.IsDBNull(row["LastEmailCreated"]))?string.Empty:(System.String)row["LastEmailCreated"];
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
		/// Fill an <see cref="VList&lt;VwLastEmailCreated&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwLastEmailCreated&gt;"/></returns>
		protected VList<VwLastEmailCreated> Fill(IDataReader reader, VList<VwLastEmailCreated> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwLastEmailCreated entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwLastEmailCreated>("VwLastEmailCreated",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwLastEmailCreated();
					}
					
					entity.SuppressEntityEvents = true;

					entity.LastEmailCreated = (reader.IsDBNull(((int)VwLastEmailCreatedColumn.LastEmailCreated)))?null:(System.String)reader[((int)VwLastEmailCreatedColumn.LastEmailCreated)];
					//entity.LastEmailCreated = (Convert.IsDBNull(reader["LastEmailCreated"]))?string.Empty:(System.String)reader["LastEmailCreated"];
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
		/// Refreshes the <see cref="VwLastEmailCreated"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLastEmailCreated"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwLastEmailCreated entity)
		{
			reader.Read();
			entity.LastEmailCreated = (reader.IsDBNull(((int)VwLastEmailCreatedColumn.LastEmailCreated)))?null:(System.String)reader[((int)VwLastEmailCreatedColumn.LastEmailCreated)];
			//entity.LastEmailCreated = (Convert.IsDBNull(reader["LastEmailCreated"]))?string.Empty:(System.String)reader["LastEmailCreated"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwLastEmailCreated"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLastEmailCreated"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwLastEmailCreated entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.LastEmailCreated = (Convert.IsDBNull(dataRow["LastEmailCreated"]))?string.Empty:(System.String)dataRow["LastEmailCreated"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwLastEmailCreatedFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastEmailCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastEmailCreatedFilterBuilder : SqlFilterBuilder<VwLastEmailCreatedColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedFilterBuilder class.
		/// </summary>
		public VwLastEmailCreatedFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLastEmailCreatedFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLastEmailCreatedFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLastEmailCreatedFilterBuilder

	#region VwLastEmailCreatedParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastEmailCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastEmailCreatedParameterBuilder : ParameterizedSqlFilterBuilder<VwLastEmailCreatedColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedParameterBuilder class.
		/// </summary>
		public VwLastEmailCreatedParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLastEmailCreatedParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLastEmailCreatedParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLastEmailCreatedParameterBuilder
	
	#region VwLastEmailCreatedSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastEmailCreated"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwLastEmailCreatedSortBuilder : SqlSortBuilder<VwLastEmailCreatedColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedSqlSortBuilder class.
		/// </summary>
		public VwLastEmailCreatedSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwLastEmailCreatedSortBuilder

} // end namespace
