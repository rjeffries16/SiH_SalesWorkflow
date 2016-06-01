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
	/// This class is the base class for any <see cref="VwLeadHoldAndCallProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwLeadHoldAndCallProviderBaseCore : EntityViewProviderBase<VwLeadHoldAndCall>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwLeadHoldAndCall&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwLeadHoldAndCall&gt;"/></returns>
		protected static VList&lt;VwLeadHoldAndCall&gt; Fill(DataSet dataSet, VList<VwLeadHoldAndCall> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwLeadHoldAndCall>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwLeadHoldAndCall&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwLeadHoldAndCall>"/></returns>
		protected static VList&lt;VwLeadHoldAndCall&gt; Fill(DataTable dataTable, VList<VwLeadHoldAndCall> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwLeadHoldAndCall c = new VwLeadHoldAndCall();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.UserId = (Convert.IsDBNull(row["USER_ID"]))?string.Empty:(System.String)row["USER_ID"];
					c.LeadHoldAndCallPk = (Convert.IsDBNull(row["LeadHoldAndCallPK"]))?(long)0:(System.Int64)row["LeadHoldAndCallPK"];
					c.LeadHoldDts = (Convert.IsDBNull(row["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime)row["LeadHoldDts"];
					c.LeadCalled = (Convert.IsDBNull(row["LeadCalled"]))?false:(System.Boolean?)row["LeadCalled"];
					c.LeadDefered = (Convert.IsDBNull(row["LeadDefered"]))?false:(System.Boolean?)row["LeadDefered"];
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
		/// Fill an <see cref="VList&lt;VwLeadHoldAndCall&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwLeadHoldAndCall&gt;"/></returns>
		protected VList<VwLeadHoldAndCall> Fill(IDataReader reader, VList<VwLeadHoldAndCall> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwLeadHoldAndCall entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwLeadHoldAndCall>("VwLeadHoldAndCall",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwLeadHoldAndCall();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (System.String)reader[((int)VwLeadHoldAndCallColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.UserId = (System.String)reader[((int)VwLeadHoldAndCallColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["USER_ID"]))?string.Empty:(System.String)reader["USER_ID"];
					entity.LeadHoldAndCallPk = (System.Int64)reader[((int)VwLeadHoldAndCallColumn.LeadHoldAndCallPk)];
					//entity.LeadHoldAndCallPk = (Convert.IsDBNull(reader["LeadHoldAndCallPK"]))?(long)0:(System.Int64)reader["LeadHoldAndCallPK"];
					entity.LeadHoldDts = (System.DateTime)reader[((int)VwLeadHoldAndCallColumn.LeadHoldDts)];
					//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime)reader["LeadHoldDts"];
					entity.LeadCalled = (reader.IsDBNull(((int)VwLeadHoldAndCallColumn.LeadCalled)))?null:(System.Boolean?)reader[((int)VwLeadHoldAndCallColumn.LeadCalled)];
					//entity.LeadCalled = (Convert.IsDBNull(reader["LeadCalled"]))?false:(System.Boolean?)reader["LeadCalled"];
					entity.LeadDefered = (reader.IsDBNull(((int)VwLeadHoldAndCallColumn.LeadDefered)))?null:(System.Boolean?)reader[((int)VwLeadHoldAndCallColumn.LeadDefered)];
					//entity.LeadDefered = (Convert.IsDBNull(reader["LeadDefered"]))?false:(System.Boolean?)reader["LeadDefered"];
					entity.LeadActionDts = (reader.IsDBNull(((int)VwLeadHoldAndCallColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwLeadHoldAndCallColumn.LeadActionDts)];
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
		/// Refreshes the <see cref="VwLeadHoldAndCall"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadHoldAndCall"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwLeadHoldAndCall entity)
		{
			reader.Read();
			entity.Leadid = (System.String)reader[((int)VwLeadHoldAndCallColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.UserId = (System.String)reader[((int)VwLeadHoldAndCallColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["USER_ID"]))?string.Empty:(System.String)reader["USER_ID"];
			entity.LeadHoldAndCallPk = (System.Int64)reader[((int)VwLeadHoldAndCallColumn.LeadHoldAndCallPk)];
			//entity.LeadHoldAndCallPk = (Convert.IsDBNull(reader["LeadHoldAndCallPK"]))?(long)0:(System.Int64)reader["LeadHoldAndCallPK"];
			entity.LeadHoldDts = (System.DateTime)reader[((int)VwLeadHoldAndCallColumn.LeadHoldDts)];
			//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime)reader["LeadHoldDts"];
			entity.LeadCalled = (reader.IsDBNull(((int)VwLeadHoldAndCallColumn.LeadCalled)))?null:(System.Boolean?)reader[((int)VwLeadHoldAndCallColumn.LeadCalled)];
			//entity.LeadCalled = (Convert.IsDBNull(reader["LeadCalled"]))?false:(System.Boolean?)reader["LeadCalled"];
			entity.LeadDefered = (reader.IsDBNull(((int)VwLeadHoldAndCallColumn.LeadDefered)))?null:(System.Boolean?)reader[((int)VwLeadHoldAndCallColumn.LeadDefered)];
			//entity.LeadDefered = (Convert.IsDBNull(reader["LeadDefered"]))?false:(System.Boolean?)reader["LeadDefered"];
			entity.LeadActionDts = (reader.IsDBNull(((int)VwLeadHoldAndCallColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwLeadHoldAndCallColumn.LeadActionDts)];
			//entity.LeadActionDts = (Convert.IsDBNull(reader["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadActionDts"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwLeadHoldAndCall"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwLeadHoldAndCall"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwLeadHoldAndCall entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.UserId = (Convert.IsDBNull(dataRow["USER_ID"]))?string.Empty:(System.String)dataRow["USER_ID"];
			entity.LeadHoldAndCallPk = (Convert.IsDBNull(dataRow["LeadHoldAndCallPK"]))?(long)0:(System.Int64)dataRow["LeadHoldAndCallPK"];
			entity.LeadHoldDts = (Convert.IsDBNull(dataRow["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime)dataRow["LeadHoldDts"];
			entity.LeadCalled = (Convert.IsDBNull(dataRow["LeadCalled"]))?false:(System.Boolean?)dataRow["LeadCalled"];
			entity.LeadDefered = (Convert.IsDBNull(dataRow["LeadDefered"]))?false:(System.Boolean?)dataRow["LeadDefered"];
			entity.LeadActionDts = (Convert.IsDBNull(dataRow["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadActionDts"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwLeadHoldAndCallFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadHoldAndCallFilterBuilder : SqlFilterBuilder<VwLeadHoldAndCallColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallFilterBuilder class.
		/// </summary>
		public VwLeadHoldAndCallFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadHoldAndCallFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadHoldAndCallFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadHoldAndCallFilterBuilder

	#region VwLeadHoldAndCallParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadHoldAndCallParameterBuilder : ParameterizedSqlFilterBuilder<VwLeadHoldAndCallColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallParameterBuilder class.
		/// </summary>
		public VwLeadHoldAndCallParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadHoldAndCallParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadHoldAndCallParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadHoldAndCallParameterBuilder
	
	#region VwLeadHoldAndCallSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadHoldAndCall"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwLeadHoldAndCallSortBuilder : SqlSortBuilder<VwLeadHoldAndCallColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallSqlSortBuilder class.
		/// </summary>
		public VwLeadHoldAndCallSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwLeadHoldAndCallSortBuilder

} // end namespace
