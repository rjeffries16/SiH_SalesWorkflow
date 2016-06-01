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
	/// This class is the base class for any <see cref="VwLastCallCreatedProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwLastCallCreatedProviderBaseCore : EntityViewProviderBase<VwLastCallCreated>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwLastCallCreated&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwLastCallCreated&gt;"/></returns>
		protected static VList&lt;VwLastCallCreated&gt; Fill(DataSet dataSet, VList<VwLastCallCreated> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwLastCallCreated>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwLastCallCreated&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwLastCallCreated>"/></returns>
		protected static VList&lt;VwLastCallCreated&gt; Fill(DataTable dataTable, VList<VwLastCallCreated> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwLastCallCreated c = new VwLastCallCreated();
					c.LastCallCreated = (Convert.IsDBNull(row["last call created"]))?DateTime.MinValue:(System.DateTime?)row["last call created"];
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
		/// Fill an <see cref="VList&lt;VwLastCallCreated&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwLastCallCreated&gt;"/></returns>
		protected VList<VwLastCallCreated> Fill(IDataReader reader, VList<VwLastCallCreated> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwLastCallCreated entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwLastCallCreated>("VwLastCallCreated",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwLastCallCreated();
					}
					
					entity.SuppressEntityEvents = true;

					entity.LastCallCreated = (reader.IsDBNull(((int)VwLastCallCreatedColumn.LastCallCreated)))?null:(System.DateTime?)reader[((int)VwLastCallCreatedColumn.LastCallCreated)];
					//entity.LastCallCreated = (Convert.IsDBNull(reader["last call created"]))?DateTime.MinValue:(System.DateTime?)reader["last call created"];
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
		/// Refreshes the <see cref="VwLastCallCreated"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLastCallCreated"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwLastCallCreated entity)
		{
			reader.Read();
			entity.LastCallCreated = (reader.IsDBNull(((int)VwLastCallCreatedColumn.LastCallCreated)))?null:(System.DateTime?)reader[((int)VwLastCallCreatedColumn.LastCallCreated)];
			//entity.LastCallCreated = (Convert.IsDBNull(reader["last call created"]))?DateTime.MinValue:(System.DateTime?)reader["last call created"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwLastCallCreated"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLastCallCreated"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwLastCallCreated entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.LastCallCreated = (Convert.IsDBNull(dataRow["last call created"]))?DateTime.MinValue:(System.DateTime?)dataRow["last call created"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwLastCallCreatedFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastCallCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastCallCreatedFilterBuilder : SqlFilterBuilder<VwLastCallCreatedColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedFilterBuilder class.
		/// </summary>
		public VwLastCallCreatedFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLastCallCreatedFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLastCallCreatedFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLastCallCreatedFilterBuilder

	#region VwLastCallCreatedParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastCallCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastCallCreatedParameterBuilder : ParameterizedSqlFilterBuilder<VwLastCallCreatedColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedParameterBuilder class.
		/// </summary>
		public VwLastCallCreatedParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLastCallCreatedParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLastCallCreatedParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLastCallCreatedParameterBuilder
	
	#region VwLastCallCreatedSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastCallCreated"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwLastCallCreatedSortBuilder : SqlSortBuilder<VwLastCallCreatedColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedSqlSortBuilder class.
		/// </summary>
		public VwLastCallCreatedSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwLastCallCreatedSortBuilder

} // end namespace
