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
	/// This class is the base class for any <see cref="VwCallsByUserProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwCallsByUserProviderBaseCore : EntityViewProviderBase<VwCallsByUser>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VwCallsByUser&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VwCallsByUser&gt;"/></returns>
		protected static VList&lt;VwCallsByUser&gt; Fill(DataSet dataSet, VList<VwCallsByUser> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VwCallsByUser>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VwCallsByUser&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VwCallsByUser>"/></returns>
		protected static VList&lt;VwCallsByUser&gt; Fill(DataTable dataTable, VList<VwCallsByUser> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VwCallsByUser c = new VwCallsByUser();
					c.Leadid = (Convert.IsDBNull(row["LEADID"]))?string.Empty:(System.String)row["LEADID"];
					c.SafeNameCallDurationInSeconds = (Convert.IsDBNull(row["Call Duration (in seconds)"]))?0.0f:(System.Double?)row["Call Duration (in seconds)"];
					c.CallPurpose = (Convert.IsDBNull(row["Call Purpose"]))?string.Empty:(System.String)row["Call Purpose"];
					c.CallResult = (Convert.IsDBNull(row["Call Result"]))?string.Empty:(System.String)row["Call Result"];
					c.CallType = (Convert.IsDBNull(row["Call Type"]))?string.Empty:(System.String)row["Call Type"];
					c.CallStartTime = (Convert.IsDBNull(row["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)row["Call Start Time"];
					c.UserId = (Convert.IsDBNull(row["USER_ID"]))?string.Empty:(System.String)row["USER_ID"];
					c.FirstName = (Convert.IsDBNull(row["First Name"]))?string.Empty:(System.String)row["First Name"];
					c.LastName = (Convert.IsDBNull(row["Last Name"]))?string.Empty:(System.String)row["Last Name"];
					c.CallOwner = (Convert.IsDBNull(row["Call Owner"]))?string.Empty:(System.String)row["Call Owner"];
					c.CallOwnerId = (Convert.IsDBNull(row["Call Owner Id"]))?string.Empty:(System.String)row["Call Owner Id"];
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
		/// Fill an <see cref="VList&lt;VwCallsByUser&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VwCallsByUser&gt;"/></returns>
		protected VList<VwCallsByUser> Fill(IDataReader reader, VList<VwCallsByUser> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VwCallsByUser entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VwCallsByUser>("VwCallsByUser",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VwCallsByUser();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Leadid = (reader.IsDBNull(((int)VwCallsByUserColumn.Leadid)))?null:(System.String)reader[((int)VwCallsByUserColumn.Leadid)];
					//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
					entity.SafeNameCallDurationInSeconds = (reader.IsDBNull(((int)VwCallsByUserColumn.SafeNameCallDurationInSeconds)))?null:(System.Double?)reader[((int)VwCallsByUserColumn.SafeNameCallDurationInSeconds)];
					//entity.SafeNameCallDurationInSeconds = (Convert.IsDBNull(reader["Call Duration (in seconds)"]))?0.0f:(System.Double?)reader["Call Duration (in seconds)"];
					entity.CallPurpose = (reader.IsDBNull(((int)VwCallsByUserColumn.CallPurpose)))?null:(System.String)reader[((int)VwCallsByUserColumn.CallPurpose)];
					//entity.CallPurpose = (Convert.IsDBNull(reader["Call Purpose"]))?string.Empty:(System.String)reader["Call Purpose"];
					entity.CallResult = (reader.IsDBNull(((int)VwCallsByUserColumn.CallResult)))?null:(System.String)reader[((int)VwCallsByUserColumn.CallResult)];
					//entity.CallResult = (Convert.IsDBNull(reader["Call Result"]))?string.Empty:(System.String)reader["Call Result"];
					entity.CallType = (reader.IsDBNull(((int)VwCallsByUserColumn.CallType)))?null:(System.String)reader[((int)VwCallsByUserColumn.CallType)];
					//entity.CallType = (Convert.IsDBNull(reader["Call Type"]))?string.Empty:(System.String)reader["Call Type"];
					entity.CallStartTime = (reader.IsDBNull(((int)VwCallsByUserColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwCallsByUserColumn.CallStartTime)];
					//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
					entity.UserId = (reader.IsDBNull(((int)VwCallsByUserColumn.UserId)))?null:(System.String)reader[((int)VwCallsByUserColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["USER_ID"]))?string.Empty:(System.String)reader["USER_ID"];
					entity.FirstName = (reader.IsDBNull(((int)VwCallsByUserColumn.FirstName)))?null:(System.String)reader[((int)VwCallsByUserColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
					entity.LastName = (reader.IsDBNull(((int)VwCallsByUserColumn.LastName)))?null:(System.String)reader[((int)VwCallsByUserColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
					entity.CallOwner = (reader.IsDBNull(((int)VwCallsByUserColumn.CallOwner)))?null:(System.String)reader[((int)VwCallsByUserColumn.CallOwner)];
					//entity.CallOwner = (Convert.IsDBNull(reader["Call Owner"]))?string.Empty:(System.String)reader["Call Owner"];
					entity.CallOwnerId = (reader.IsDBNull(((int)VwCallsByUserColumn.CallOwnerId)))?null:(System.String)reader[((int)VwCallsByUserColumn.CallOwnerId)];
					//entity.CallOwnerId = (Convert.IsDBNull(reader["Call Owner Id"]))?string.Empty:(System.String)reader["Call Owner Id"];
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
		/// Refreshes the <see cref="VwCallsByUser"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VwCallsByUser"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VwCallsByUser entity)
		{
			reader.Read();
			entity.Leadid = (reader.IsDBNull(((int)VwCallsByUserColumn.Leadid)))?null:(System.String)reader[((int)VwCallsByUserColumn.Leadid)];
			//entity.Leadid = (Convert.IsDBNull(reader["LEADID"]))?string.Empty:(System.String)reader["LEADID"];
			entity.SafeNameCallDurationInSeconds = (reader.IsDBNull(((int)VwCallsByUserColumn.SafeNameCallDurationInSeconds)))?null:(System.Double?)reader[((int)VwCallsByUserColumn.SafeNameCallDurationInSeconds)];
			//entity.SafeNameCallDurationInSeconds = (Convert.IsDBNull(reader["Call Duration (in seconds)"]))?0.0f:(System.Double?)reader["Call Duration (in seconds)"];
			entity.CallPurpose = (reader.IsDBNull(((int)VwCallsByUserColumn.CallPurpose)))?null:(System.String)reader[((int)VwCallsByUserColumn.CallPurpose)];
			//entity.CallPurpose = (Convert.IsDBNull(reader["Call Purpose"]))?string.Empty:(System.String)reader["Call Purpose"];
			entity.CallResult = (reader.IsDBNull(((int)VwCallsByUserColumn.CallResult)))?null:(System.String)reader[((int)VwCallsByUserColumn.CallResult)];
			//entity.CallResult = (Convert.IsDBNull(reader["Call Result"]))?string.Empty:(System.String)reader["Call Result"];
			entity.CallType = (reader.IsDBNull(((int)VwCallsByUserColumn.CallType)))?null:(System.String)reader[((int)VwCallsByUserColumn.CallType)];
			//entity.CallType = (Convert.IsDBNull(reader["Call Type"]))?string.Empty:(System.String)reader["Call Type"];
			entity.CallStartTime = (reader.IsDBNull(((int)VwCallsByUserColumn.CallStartTime)))?null:(System.DateTime?)reader[((int)VwCallsByUserColumn.CallStartTime)];
			//entity.CallStartTime = (Convert.IsDBNull(reader["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)reader["Call Start Time"];
			entity.UserId = (reader.IsDBNull(((int)VwCallsByUserColumn.UserId)))?null:(System.String)reader[((int)VwCallsByUserColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["USER_ID"]))?string.Empty:(System.String)reader["USER_ID"];
			entity.FirstName = (reader.IsDBNull(((int)VwCallsByUserColumn.FirstName)))?null:(System.String)reader[((int)VwCallsByUserColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["First Name"]))?string.Empty:(System.String)reader["First Name"];
			entity.LastName = (reader.IsDBNull(((int)VwCallsByUserColumn.LastName)))?null:(System.String)reader[((int)VwCallsByUserColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["Last Name"]))?string.Empty:(System.String)reader["Last Name"];
			entity.CallOwner = (reader.IsDBNull(((int)VwCallsByUserColumn.CallOwner)))?null:(System.String)reader[((int)VwCallsByUserColumn.CallOwner)];
			//entity.CallOwner = (Convert.IsDBNull(reader["Call Owner"]))?string.Empty:(System.String)reader["Call Owner"];
			entity.CallOwnerId = (reader.IsDBNull(((int)VwCallsByUserColumn.CallOwnerId)))?null:(System.String)reader[((int)VwCallsByUserColumn.CallOwnerId)];
			//entity.CallOwnerId = (Convert.IsDBNull(reader["Call Owner Id"]))?string.Empty:(System.String)reader["Call Owner Id"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VwCallsByUser"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VwCallsByUser"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VwCallsByUser entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (Convert.IsDBNull(dataRow["LEADID"]))?string.Empty:(System.String)dataRow["LEADID"];
			entity.SafeNameCallDurationInSeconds = (Convert.IsDBNull(dataRow["Call Duration (in seconds)"]))?0.0f:(System.Double?)dataRow["Call Duration (in seconds)"];
			entity.CallPurpose = (Convert.IsDBNull(dataRow["Call Purpose"]))?string.Empty:(System.String)dataRow["Call Purpose"];
			entity.CallResult = (Convert.IsDBNull(dataRow["Call Result"]))?string.Empty:(System.String)dataRow["Call Result"];
			entity.CallType = (Convert.IsDBNull(dataRow["Call Type"]))?string.Empty:(System.String)dataRow["Call Type"];
			entity.CallStartTime = (Convert.IsDBNull(dataRow["Call Start Time"]))?DateTime.MinValue:(System.DateTime?)dataRow["Call Start Time"];
			entity.UserId = (Convert.IsDBNull(dataRow["USER_ID"]))?string.Empty:(System.String)dataRow["USER_ID"];
			entity.FirstName = (Convert.IsDBNull(dataRow["First Name"]))?string.Empty:(System.String)dataRow["First Name"];
			entity.LastName = (Convert.IsDBNull(dataRow["Last Name"]))?string.Empty:(System.String)dataRow["Last Name"];
			entity.CallOwner = (Convert.IsDBNull(dataRow["Call Owner"]))?string.Empty:(System.String)dataRow["Call Owner"];
			entity.CallOwnerId = (Convert.IsDBNull(dataRow["Call Owner Id"]))?string.Empty:(System.String)dataRow["Call Owner Id"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VwCallsByUserFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallsByUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallsByUserFilterBuilder : SqlFilterBuilder<VwCallsByUserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserFilterBuilder class.
		/// </summary>
		public VwCallsByUserFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallsByUserFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallsByUserFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallsByUserFilterBuilder

	#region VwCallsByUserParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallsByUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallsByUserParameterBuilder : ParameterizedSqlFilterBuilder<VwCallsByUserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserParameterBuilder class.
		/// </summary>
		public VwCallsByUserParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallsByUserParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallsByUserParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallsByUserParameterBuilder
	
	#region VwCallsByUserSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallsByUser"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VwCallsByUserSortBuilder : SqlSortBuilder<VwCallsByUserColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserSqlSortBuilder class.
		/// </summary>
		public VwCallsByUserSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VwCallsByUserSortBuilder

} // end namespace
