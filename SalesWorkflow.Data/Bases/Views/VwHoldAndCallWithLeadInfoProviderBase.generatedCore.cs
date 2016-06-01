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
	/// This class is the base class for any <see cref="VwHoldAndCallWithLeadInfoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwHoldAndCallWithLeadInfoProviderBaseCore : EntityViewProviderBase<VwHoldAndCallWithLeadInfo>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwHoldAndCallWithLeadInfo&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwHoldAndCallWithLeadInfo&gt;"/></returns>
		protected static VList&lt;VwHoldAndCallWithLeadInfo&gt; Fill(DataSet dataSet, VList<VwHoldAndCallWithLeadInfo> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwHoldAndCallWithLeadInfo>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwHoldAndCallWithLeadInfo&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwHoldAndCallWithLeadInfo>"/></returns>
		protected static VList&lt;VwHoldAndCallWithLeadInfo&gt; Fill(DataTable dataTable, VList<VwHoldAndCallWithLeadInfo> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwHoldAndCallWithLeadInfo c = new VwHoldAndCallWithLeadInfo();
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.LeadStatus = (Convert.IsDBNull(row["Lead Status"]))?string.Empty:(System.String)row["Lead Status"];
					c.Rating = (Convert.IsDBNull(row["Rating"]))?string.Empty:(System.String)row["Rating"];
					c.LeadOwner = (Convert.IsDBNull(row["Lead Owner"]))?string.Empty:(System.String)row["Lead Owner"];
					c.LeadHoldDts = (Convert.IsDBNull(row["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime)row["LeadHoldDts"];
					c.LeadCalled = (Convert.IsDBNull(row["LeadCalled"]))?false:(System.Boolean?)row["LeadCalled"];
					c.LeadDefered = (Convert.IsDBNull(row["LeadDefered"]))?false:(System.Boolean?)row["LeadDefered"];
					c.LeadActionDts = (Convert.IsDBNull(row["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)row["LeadActionDts"];
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.UserId = (Convert.IsDBNull(row["USER_ID"]))?string.Empty:(System.String)row["USER_ID"];
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
		/// Fill an <see cref="VList&lt;VwHoldAndCallWithLeadInfo&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwHoldAndCallWithLeadInfo&gt;"/></returns>
		protected VList<VwHoldAndCallWithLeadInfo> Fill(IDataReader reader, VList<VwHoldAndCallWithLeadInfo> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwHoldAndCallWithLeadInfo entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwHoldAndCallWithLeadInfo>("VwHoldAndCallWithLeadInfo",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwHoldAndCallWithLeadInfo();
					}
					
					entity.SuppressEntityEvents = true;

					entity.FirstName = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.FirstName)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LastName)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.LeadStatus = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LeadStatus)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadStatus)];
					//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
					entity.Rating = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.Rating)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.Rating)];
					//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
					entity.LeadOwner = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LeadOwner)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadOwner)];
					//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
					entity.LeadHoldDts = (System.DateTime)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadHoldDts)];
					//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime)reader["LeadHoldDts"];
					entity.LeadCalled = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LeadCalled)))?null:(System.Boolean?)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadCalled)];
					//entity.LeadCalled = (Convert.IsDBNull(reader["LeadCalled"]))?false:(System.Boolean?)reader["LeadCalled"];
					entity.LeadDefered = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LeadDefered)))?null:(System.Boolean?)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadDefered)];
					//entity.LeadDefered = (Convert.IsDBNull(reader["LeadDefered"]))?false:(System.Boolean?)reader["LeadDefered"];
					entity.LeadActionDts = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadActionDts)];
					//entity.LeadActionDts = (Convert.IsDBNull(reader["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadActionDts"];
					entity.Leadid = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.Leadid)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.UserId = (System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["USER_ID"]))?string.Empty:(System.String)reader["USER_ID"];
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
		/// Refreshes the <see cref="VwHoldAndCallWithLeadInfo"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwHoldAndCallWithLeadInfo"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwHoldAndCallWithLeadInfo entity)
		{
			reader.Read();
			entity.FirstName = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.FirstName)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LastName)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.LeadStatus = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LeadStatus)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadStatus)];
			//entity.LeadStatus = (Convert.IsDBNull(reader["Lead Status"]))?string.Empty:(System.String)reader["Lead Status"];
			entity.Rating = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.Rating)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.Rating)];
			//entity.Rating = (Convert.IsDBNull(reader["Rating"]))?string.Empty:(System.String)reader["Rating"];
			entity.LeadOwner = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LeadOwner)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadOwner)];
			//entity.LeadOwner = (Convert.IsDBNull(reader["Lead Owner"]))?string.Empty:(System.String)reader["Lead Owner"];
			entity.LeadHoldDts = (System.DateTime)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadHoldDts)];
			//entity.LeadHoldDts = (Convert.IsDBNull(reader["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime)reader["LeadHoldDts"];
			entity.LeadCalled = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LeadCalled)))?null:(System.Boolean?)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadCalled)];
			//entity.LeadCalled = (Convert.IsDBNull(reader["LeadCalled"]))?false:(System.Boolean?)reader["LeadCalled"];
			entity.LeadDefered = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LeadDefered)))?null:(System.Boolean?)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadDefered)];
			//entity.LeadDefered = (Convert.IsDBNull(reader["LeadDefered"]))?false:(System.Boolean?)reader["LeadDefered"];
			entity.LeadActionDts = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.LeadActionDts)))?null:(System.DateTime?)reader[((int)VwHoldAndCallWithLeadInfoColumn.LeadActionDts)];
			//entity.LeadActionDts = (Convert.IsDBNull(reader["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)reader["LeadActionDts"];
			entity.Leadid = (reader.IsDBNull(((int)VwHoldAndCallWithLeadInfoColumn.Leadid)))?null:(System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.UserId = (System.String)reader[((int)VwHoldAndCallWithLeadInfoColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["USER_ID"]))?string.Empty:(System.String)reader["USER_ID"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwHoldAndCallWithLeadInfo"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwHoldAndCallWithLeadInfo"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwHoldAndCallWithLeadInfo entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.LeadStatus = (Convert.IsDBNull(dataRow["Lead Status"]))?string.Empty:(System.String)dataRow["Lead Status"];
			entity.Rating = (Convert.IsDBNull(dataRow["Rating"]))?string.Empty:(System.String)dataRow["Rating"];
			entity.LeadOwner = (Convert.IsDBNull(dataRow["Lead Owner"]))?string.Empty:(System.String)dataRow["Lead Owner"];
			entity.LeadHoldDts = (Convert.IsDBNull(dataRow["LeadHoldDts"]))?DateTime.MinValue:(System.DateTime)dataRow["LeadHoldDts"];
			entity.LeadCalled = (Convert.IsDBNull(dataRow["LeadCalled"]))?false:(System.Boolean?)dataRow["LeadCalled"];
			entity.LeadDefered = (Convert.IsDBNull(dataRow["LeadDefered"]))?false:(System.Boolean?)dataRow["LeadDefered"];
			entity.LeadActionDts = (Convert.IsDBNull(dataRow["LeadActionDts"]))?DateTime.MinValue:(System.DateTime?)dataRow["LeadActionDts"];
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.UserId = (Convert.IsDBNull(dataRow["USER_ID"]))?string.Empty:(System.String)dataRow["USER_ID"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwHoldAndCallWithLeadInfoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwHoldAndCallWithLeadInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwHoldAndCallWithLeadInfoFilterBuilder : SqlFilterBuilder<VwHoldAndCallWithLeadInfoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoFilterBuilder class.
		/// </summary>
		public VwHoldAndCallWithLeadInfoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwHoldAndCallWithLeadInfoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwHoldAndCallWithLeadInfoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwHoldAndCallWithLeadInfoFilterBuilder

	#region VwHoldAndCallWithLeadInfoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwHoldAndCallWithLeadInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwHoldAndCallWithLeadInfoParameterBuilder : ParameterizedSqlFilterBuilder<VwHoldAndCallWithLeadInfoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoParameterBuilder class.
		/// </summary>
		public VwHoldAndCallWithLeadInfoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwHoldAndCallWithLeadInfoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwHoldAndCallWithLeadInfoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwHoldAndCallWithLeadInfoParameterBuilder
	
	#region VwHoldAndCallWithLeadInfoSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwHoldAndCallWithLeadInfo"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwHoldAndCallWithLeadInfoSortBuilder : SqlSortBuilder<VwHoldAndCallWithLeadInfoColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoSqlSortBuilder class.
		/// </summary>
		public VwHoldAndCallWithLeadInfoSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwHoldAndCallWithLeadInfoSortBuilder

} // end namespace
