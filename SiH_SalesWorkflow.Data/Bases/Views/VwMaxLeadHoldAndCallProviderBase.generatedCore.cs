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
	/// This class is the base class for any <see cref="VwMaxLeadHoldAndCallProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwMaxLeadHoldAndCallProviderBaseCore : EntityViewProviderBase<VwMaxLeadHoldAndCall>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwMaxLeadHoldAndCall&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwMaxLeadHoldAndCall&gt;"/></returns>
		protected static VList&lt;VwMaxLeadHoldAndCall&gt; Fill(DataSet dataSet, VList<VwMaxLeadHoldAndCall> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwMaxLeadHoldAndCall>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwMaxLeadHoldAndCall&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwMaxLeadHoldAndCall>"/></returns>
		protected static VList&lt;VwMaxLeadHoldAndCall&gt; Fill(DataTable dataTable, VList<VwMaxLeadHoldAndCall> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwMaxLeadHoldAndCall c = new VwMaxLeadHoldAndCall();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.LeadHoldDts = (Convert.IsDBNull(row["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)row["LeadHoldDts"];
					c.LeadActionDts = (Convert.IsDBNull(row["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)row["LeadActionDts"];
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
		/// Fill an <see cref="VList&lt;VwMaxLeadHoldAndCall&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwMaxLeadHoldAndCall&gt;"/></returns>
		protected VList<VwMaxLeadHoldAndCall> Fill(IDataReader reader, VList<VwMaxLeadHoldAndCall> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwMaxLeadHoldAndCall entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwMaxLeadHoldAndCall>("VwMaxLeadHoldAndCall",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwMaxLeadHoldAndCall();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (System.String)reader[((int)VwMaxLeadHoldAndCallColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.LeadHoldDts = (reader.IsDBNull(((int)VwMaxLeadHoldAndCallColumn.LeadHoldDts)))?null:(System.DateTime?)reader[((int)VwMaxLeadHoldAndCallColumn.LeadHoldDts)];
					//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadHoldDts"];
					entity.LeadActionDts = (reader.IsDBNull(((int)VwMaxLeadHoldAndCallColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwMaxLeadHoldAndCallColumn.LeadActionDts)];
					//entity.LeadActionDts = (Convert.IsDBNull(reader["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadActionDts"];
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
		/// Refreshes the <see cref="VwMaxLeadHoldAndCall"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwMaxLeadHoldAndCall"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwMaxLeadHoldAndCall entity)
		{
			reader.Read();
			entity.Leadid = (System.String)reader[((int)VwMaxLeadHoldAndCallColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.LeadHoldDts = (reader.IsDBNull(((int)VwMaxLeadHoldAndCallColumn.LeadHoldDts)))?null:(System.DateTime?)reader[((int)VwMaxLeadHoldAndCallColumn.LeadHoldDts)];
			//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadHoldDts"];
			entity.LeadActionDts = (reader.IsDBNull(((int)VwMaxLeadHoldAndCallColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwMaxLeadHoldAndCallColumn.LeadActionDts)];
			//entity.LeadActionDts = (Convert.IsDBNull(reader["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadActionDts"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwMaxLeadHoldAndCall"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwMaxLeadHoldAndCall"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwMaxLeadHoldAndCall entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.LeadHoldDts = (Convert.IsDBNull(dataRow["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadHoldDts"];
			entity.LeadActionDts = (Convert.IsDBNull(dataRow["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadActionDts"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwMaxLeadHoldAndCallFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwMaxLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwMaxLeadHoldAndCallFilterBuilder : SqlFilterBuilder<VwMaxLeadHoldAndCallColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallFilterBuilder class.
		/// </summary>
		public VwMaxLeadHoldAndCallFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwMaxLeadHoldAndCallFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwMaxLeadHoldAndCallFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwMaxLeadHoldAndCallFilterBuilder

	#region VwMaxLeadHoldAndCallParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwMaxLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwMaxLeadHoldAndCallParameterBuilder : ParameterizedSqlFilterBuilder<VwMaxLeadHoldAndCallColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallParameterBuilder class.
		/// </summary>
		public VwMaxLeadHoldAndCallParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwMaxLeadHoldAndCallParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwMaxLeadHoldAndCallParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwMaxLeadHoldAndCallParameterBuilder
	
	#region VwMaxLeadHoldAndCallSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwMaxLeadHoldAndCall"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwMaxLeadHoldAndCallSortBuilder : SqlSortBuilder<VwMaxLeadHoldAndCallColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallSqlSortBuilder class.
		/// </summary>
		public VwMaxLeadHoldAndCallSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwMaxLeadHoldAndCallSortBuilder

} // end namespace
