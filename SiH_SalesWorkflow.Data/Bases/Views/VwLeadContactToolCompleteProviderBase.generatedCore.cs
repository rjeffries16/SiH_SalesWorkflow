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
	/// This class is the base class for any <see cref="VwLeadContactToolCompleteProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwLeadContactToolCompleteProviderBaseCore : EntityViewProviderBase<VwLeadContactToolComplete>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwLeadContactToolComplete&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwLeadContactToolComplete&gt;"/></returns>
		protected static VList&lt;VwLeadContactToolComplete&gt; Fill(DataSet dataSet, VList<VwLeadContactToolComplete> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwLeadContactToolComplete>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwLeadContactToolComplete&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwLeadContactToolComplete>"/></returns>
		protected static VList&lt;VwLeadContactToolComplete&gt; Fill(DataTable dataTable, VList<VwLeadContactToolComplete> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwLeadContactToolComplete c = new VwLeadContactToolComplete();
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.ThisEventDts = (Convert.IsDBNull(row["ThisEventDts"]))?DateTime.MinValue:(System.DateTime?)row["ThisEventDts"];
					c.LeadContactPhone = (Convert.IsDBNull(row["LeadContactPhone"]))?false:(System.Boolean?)row["LeadContactPhone"];
					c.LeadContactEmail = (Convert.IsDBNull(row["LeadContactEmail"]))?false:(System.Boolean?)row["LeadContactEmail"];
					c.LeadContactDts = (Convert.IsDBNull(row["LeadContactDts"]))?string.Empty:(System.String)row["LeadContactDts"];
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
		/// Fill an <see cref="VList&lt;VwLeadContactToolComplete&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwLeadContactToolComplete&gt;"/></returns>
		protected VList<VwLeadContactToolComplete> Fill(IDataReader reader, VList<VwLeadContactToolComplete> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwLeadContactToolComplete entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwLeadContactToolComplete>("VwLeadContactToolComplete",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwLeadContactToolComplete();
					}
					
					entity.SuppressEntityEvents = true;

					entity.FirstName = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.FirstName)))?null:(System.String)reader[((int)VwLeadContactToolCompleteColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.LastName)))?null:(System.String)reader[((int)VwLeadContactToolCompleteColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.Leadid = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.Leadid)))?null:(System.String)reader[((int)VwLeadContactToolCompleteColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.ThisEventDts = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.ThisEventDts)))?null:(System.DateTime?)reader[((int)VwLeadContactToolCompleteColumn.ThisEventDts)];
					//entity.ThisEventDts = (Convert.IsDBNull(reader["ThisEventDts"]))?DateTime.MinValue:(System.DateTime?)reader["ThisEventDts"];
					entity.LeadContactPhone = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.LeadContactPhone)))?null:(System.Boolean?)reader[((int)VwLeadContactToolCompleteColumn.LeadContactPhone)];
					//entity.LeadContactPhone = (Convert.IsDBNull(reader["LeadContactPhone"]))?false:(System.Boolean?)reader["LeadContactPhone"];
					entity.LeadContactEmail = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.LeadContactEmail)))?null:(System.Boolean?)reader[((int)VwLeadContactToolCompleteColumn.LeadContactEmail)];
					//entity.LeadContactEmail = (Convert.IsDBNull(reader["LeadContactEmail"]))?false:(System.Boolean?)reader["LeadContactEmail"];
					entity.LeadContactDts = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.LeadContactDts)))?null:(System.String)reader[((int)VwLeadContactToolCompleteColumn.LeadContactDts)];
					//entity.LeadContactDts = (Convert.IsDBNull(reader["LeadContactDts"]))?string.Empty:(System.String)reader["LeadContactDts"];
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
		/// Refreshes the <see cref="VwLeadContactToolComplete"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadContactToolComplete"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwLeadContactToolComplete entity)
		{
			reader.Read();
			entity.FirstName = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.FirstName)))?null:(System.String)reader[((int)VwLeadContactToolCompleteColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.LastName)))?null:(System.String)reader[((int)VwLeadContactToolCompleteColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.Leadid = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.Leadid)))?null:(System.String)reader[((int)VwLeadContactToolCompleteColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.ThisEventDts = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.ThisEventDts)))?null:(System.DateTime?)reader[((int)VwLeadContactToolCompleteColumn.ThisEventDts)];
			//entity.ThisEventDts = (Convert.IsDBNull(reader["ThisEventDts"]))?DateTime.MinValue:(System.DateTime?)reader["ThisEventDts"];
			entity.LeadContactPhone = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.LeadContactPhone)))?null:(System.Boolean?)reader[((int)VwLeadContactToolCompleteColumn.LeadContactPhone)];
			//entity.LeadContactPhone = (Convert.IsDBNull(reader["LeadContactPhone"]))?false:(System.Boolean?)reader["LeadContactPhone"];
			entity.LeadContactEmail = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.LeadContactEmail)))?null:(System.Boolean?)reader[((int)VwLeadContactToolCompleteColumn.LeadContactEmail)];
			//entity.LeadContactEmail = (Convert.IsDBNull(reader["LeadContactEmail"]))?false:(System.Boolean?)reader["LeadContactEmail"];
			entity.LeadContactDts = (reader.IsDBNull(((int)VwLeadContactToolCompleteColumn.LeadContactDts)))?null:(System.String)reader[((int)VwLeadContactToolCompleteColumn.LeadContactDts)];
			//entity.LeadContactDts = (Convert.IsDBNull(reader["LeadContactDts"]))?string.Empty:(System.String)reader["LeadContactDts"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwLeadContactToolComplete"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadContactToolComplete"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwLeadContactToolComplete entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.ThisEventDts = (Convert.IsDBNull(dataRow["ThisEventDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["ThisEventDts"];
			entity.LeadContactPhone = (Convert.IsDBNull(dataRow["LeadContactPhone"]))?false:(System.Boolean?)dataRow["LeadContactPhone"];
			entity.LeadContactEmail = (Convert.IsDBNull(dataRow["LeadContactEmail"]))?false:(System.Boolean?)dataRow["LeadContactEmail"];
			entity.LeadContactDts = (Convert.IsDBNull(dataRow["LeadContactDts"]))?string.Empty:(System.String)dataRow["LeadContactDts"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwLeadContactToolCompleteFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactToolComplete"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolCompleteFilterBuilder : SqlFilterBuilder<VwLeadContactToolCompleteColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteFilterBuilder class.
		/// </summary>
		public VwLeadContactToolCompleteFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadContactToolCompleteFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadContactToolCompleteFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadContactToolCompleteFilterBuilder

	#region VwLeadContactToolCompleteParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactToolComplete"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolCompleteParameterBuilder : ParameterizedSqlFilterBuilder<VwLeadContactToolCompleteColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteParameterBuilder class.
		/// </summary>
		public VwLeadContactToolCompleteParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadContactToolCompleteParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadContactToolCompleteParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadContactToolCompleteParameterBuilder
	
	#region VwLeadContactToolCompleteSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactToolComplete"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwLeadContactToolCompleteSortBuilder : SqlSortBuilder<VwLeadContactToolCompleteColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteSqlSortBuilder class.
		/// </summary>
		public VwLeadContactToolCompleteSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwLeadContactToolCompleteSortBuilder

} // end namespace
