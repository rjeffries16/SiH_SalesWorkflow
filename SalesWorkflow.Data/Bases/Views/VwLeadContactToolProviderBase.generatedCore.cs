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
	/// This class is the base class for any <see cref="VwLeadContactToolProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwLeadContactToolProviderBaseCore : EntityViewProviderBase<VwLeadContactTool>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwLeadContactTool&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwLeadContactTool&gt;"/></returns>
		protected static VList&lt;VwLeadContactTool&gt; Fill(DataSet dataSet, VList<VwLeadContactTool> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwLeadContactTool>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwLeadContactTool&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwLeadContactTool>"/></returns>
		protected static VList&lt;VwLeadContactTool&gt; Fill(DataTable dataTable, VList<VwLeadContactTool> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwLeadContactTool c = new VwLeadContactTool();
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.LastVisitedTime = (Convert.IsDBNull(row["Last Visited Time"]))?string.Empty:(System.String)row["Last Visited Time"];
					c.LeadOwner = (Convert.IsDBNull(row["Lead Owner"]))?string.Empty:(System.String)row["Lead Owner"];
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.CreatedTime = (Convert.IsDBNull(row["Created Time"]))?DateTime.MinValue:(System.DateTime?)row["Created Time"];
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
		/// Fill an <see cref="VList&lt;VwLeadContactTool&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwLeadContactTool&gt;"/></returns>
		protected VList<VwLeadContactTool> Fill(IDataReader reader, VList<VwLeadContactTool> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwLeadContactTool entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwLeadContactTool>("VwLeadContactTool",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwLeadContactTool();
					}
					
					entity.SuppressEntityEvents = true;

					entity.FirstName = (reader.IsDBNull(((int)VwLeadContactToolColumn.FirstName)))?null:(System.String)reader[((int)VwLeadContactToolColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwLeadContactToolColumn.LastName)))?null:(System.String)reader[((int)VwLeadContactToolColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.LastVisitedTime = (reader.IsDBNull(((int)VwLeadContactToolColumn.LastVisitedTime)))?null:(System.String)reader[((int)VwLeadContactToolColumn.LastVisitedTime)];
					//entity.LastVisitedTime = (Convert.IsDBNull(reader["Last Visited Time"]))?string.Empty:(System.String)reader["Last Visited Time"];
					entity.LeadOwner = (reader.IsDBNull(((int)VwLeadContactToolColumn.LeadOwner)))?null:(System.String)reader[((int)VwLeadContactToolColumn.LeadOwner)];
					//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
					entity.Leadid = (reader.IsDBNull(((int)VwLeadContactToolColumn.Leadid)))?null:(System.String)reader[((int)VwLeadContactToolColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.CreatedTime = (reader.IsDBNull(((int)VwLeadContactToolColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwLeadContactToolColumn.CreatedTime)];
					//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
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
		/// Refreshes the <see cref="VwLeadContactTool"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadContactTool"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwLeadContactTool entity)
		{
			reader.Read();
			entity.FirstName = (reader.IsDBNull(((int)VwLeadContactToolColumn.FirstName)))?null:(System.String)reader[((int)VwLeadContactToolColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwLeadContactToolColumn.LastName)))?null:(System.String)reader[((int)VwLeadContactToolColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.LastVisitedTime = (reader.IsDBNull(((int)VwLeadContactToolColumn.LastVisitedTime)))?null:(System.String)reader[((int)VwLeadContactToolColumn.LastVisitedTime)];
			//entity.LastVisitedTime = (Convert.IsDBNull(reader["Last Visited Time"]))?string.Empty:(System.String)reader["Last Visited Time"];
			entity.LeadOwner = (reader.IsDBNull(((int)VwLeadContactToolColumn.LeadOwner)))?null:(System.String)reader[((int)VwLeadContactToolColumn.LeadOwner)];
			//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
			entity.Leadid = (reader.IsDBNull(((int)VwLeadContactToolColumn.Leadid)))?null:(System.String)reader[((int)VwLeadContactToolColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.CreatedTime = (reader.IsDBNull(((int)VwLeadContactToolColumn.CreatedTime)))?null:(System.DateTime?)reader[((int)VwLeadContactToolColumn.CreatedTime)];
			//entity.CreatedTime = (Convert.IsDBNull(reader["Created Time"]))?DateTime.MinValue:(System.DateTime?)reader["Created Time"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwLeadContactTool"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadContactTool"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwLeadContactTool entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.LastVisitedTime = (Convert.IsDBNull(dataRow["Last Visited Time"]))?string.Empty:(System.String)dataRow["Last Visited Time"];
			entity.LeadOwner = (Convert.IsDBNull(dataRow["Lead Owner"]))?string.Empty:(System.String)dataRow["Lead Owner"];
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.CreatedTime = (Convert.IsDBNull(dataRow["Created Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Created Time"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwLeadContactToolFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactTool"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolFilterBuilder : SqlFilterBuilder<VwLeadContactToolColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolFilterBuilder class.
		/// </summary>
		public VwLeadContactToolFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadContactToolFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadContactToolFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadContactToolFilterBuilder

	#region VwLeadContactToolParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactTool"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolParameterBuilder : ParameterizedSqlFilterBuilder<VwLeadContactToolColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolParameterBuilder class.
		/// </summary>
		public VwLeadContactToolParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadContactToolParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadContactToolParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadContactToolParameterBuilder
	
	#region VwLeadContactToolSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactTool"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwLeadContactToolSortBuilder : SqlSortBuilder<VwLeadContactToolColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolSqlSortBuilder class.
		/// </summary>
		public VwLeadContactToolSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwLeadContactToolSortBuilder

} // end namespace
