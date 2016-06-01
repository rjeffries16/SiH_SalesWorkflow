#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Data;

#endregion

namespace SiH_SalesWorkflow.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="LeadHoldAndCallProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LeadHoldAndCallProviderBaseCore : EntityProviderBase<SiH_SalesWorkflow.Entities.LeadHoldAndCall, SiH_SalesWorkflow.Entities.LeadHoldAndCallKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.LeadHoldAndCallKey key)
		{
			return Delete(transactionManager, key.LeadHoldAndCallPk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_leadHoldAndCallPk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _leadHoldAndCallPk)
		{
			return Delete(null, _leadHoldAndCallPk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadHoldAndCallPk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _leadHoldAndCallPk);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override SiH_SalesWorkflow.Entities.LeadHoldAndCall Get(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.LeadHoldAndCallKey key, int start, int pageLength)
		{
			return GetByLeadHoldAndCallPk(transactionManager, key.LeadHoldAndCallPk, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_LeadHoldAndCall index.
		/// </summary>
		/// <param name="_leadHoldAndCallPk"></param>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> class.</returns>
		public SiH_SalesWorkflow.Entities.LeadHoldAndCall GetByLeadHoldAndCallPk(System.Int64 _leadHoldAndCallPk)
		{
			int count = -1;
			return GetByLeadHoldAndCallPk(null,_leadHoldAndCallPk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LeadHoldAndCall index.
		/// </summary>
		/// <param name="_leadHoldAndCallPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> class.</returns>
		public SiH_SalesWorkflow.Entities.LeadHoldAndCall GetByLeadHoldAndCallPk(System.Int64 _leadHoldAndCallPk, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadHoldAndCallPk(null, _leadHoldAndCallPk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LeadHoldAndCall index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadHoldAndCallPk"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> class.</returns>
		public SiH_SalesWorkflow.Entities.LeadHoldAndCall GetByLeadHoldAndCallPk(TransactionManager transactionManager, System.Int64 _leadHoldAndCallPk)
		{
			int count = -1;
			return GetByLeadHoldAndCallPk(transactionManager, _leadHoldAndCallPk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LeadHoldAndCall index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadHoldAndCallPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> class.</returns>
		public SiH_SalesWorkflow.Entities.LeadHoldAndCall GetByLeadHoldAndCallPk(TransactionManager transactionManager, System.Int64 _leadHoldAndCallPk, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadHoldAndCallPk(transactionManager, _leadHoldAndCallPk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LeadHoldAndCall index.
		/// </summary>
		/// <param name="_leadHoldAndCallPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> class.</returns>
		public SiH_SalesWorkflow.Entities.LeadHoldAndCall GetByLeadHoldAndCallPk(System.Int64 _leadHoldAndCallPk, int start, int pageLength, out int count)
		{
			return GetByLeadHoldAndCallPk(null, _leadHoldAndCallPk, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LeadHoldAndCall index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadHoldAndCallPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> class.</returns>
		public abstract SiH_SalesWorkflow.Entities.LeadHoldAndCall GetByLeadHoldAndCallPk(TransactionManager transactionManager, System.Int64 _leadHoldAndCallPk, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;LeadHoldAndCall&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;LeadHoldAndCall&gt;"/></returns>
		public static TList<LeadHoldAndCall> Fill(IDataReader reader, TList<LeadHoldAndCall> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				SiH_SalesWorkflow.Entities.LeadHoldAndCall c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("LeadHoldAndCall")
					.Append("|").Append((System.Int64)reader[((int)LeadHoldAndCallColumn.LeadHoldAndCallPk - 1)]).ToString();
					c = EntityManager.LocateOrCreate<LeadHoldAndCall>(
					key.ToString(), // EntityTrackingKey
					"LeadHoldAndCall",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SiH_SalesWorkflow.Entities.LeadHoldAndCall();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.Leadid = (System.String)reader[((int)LeadHoldAndCallColumn.Leadid - 1)];
					c.UserId = (System.String)reader[((int)LeadHoldAndCallColumn.UserId - 1)];
					c.LeadHoldDts = (System.DateTime)reader[((int)LeadHoldAndCallColumn.LeadHoldDts - 1)];
					c.LeadCalled = (reader.IsDBNull(((int)LeadHoldAndCallColumn.LeadCalled - 1)))?null:(System.Boolean?)reader[((int)LeadHoldAndCallColumn.LeadCalled - 1)];
					c.LeadDefered = (reader.IsDBNull(((int)LeadHoldAndCallColumn.LeadDefered - 1)))?null:(System.Boolean?)reader[((int)LeadHoldAndCallColumn.LeadDefered - 1)];
					c.LeadActionDts = (reader.IsDBNull(((int)LeadHoldAndCallColumn.LeadActionDts - 1)))?null:(System.DateTime?)reader[((int)LeadHoldAndCallColumn.LeadActionDts - 1)];
					c.LeadHoldAndCallPk = (System.Int64)reader[((int)LeadHoldAndCallColumn.LeadHoldAndCallPk - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SiH_SalesWorkflow.Entities.LeadHoldAndCall entity)
		{
			if (!reader.Read()) return;
			
			entity.Leadid = (System.String)reader[((int)LeadHoldAndCallColumn.Leadid - 1)];
			entity.UserId = (System.String)reader[((int)LeadHoldAndCallColumn.UserId - 1)];
			entity.LeadHoldDts = (System.DateTime)reader[((int)LeadHoldAndCallColumn.LeadHoldDts - 1)];
			entity.LeadCalled = (reader.IsDBNull(((int)LeadHoldAndCallColumn.LeadCalled - 1)))?null:(System.Boolean?)reader[((int)LeadHoldAndCallColumn.LeadCalled - 1)];
			entity.LeadDefered = (reader.IsDBNull(((int)LeadHoldAndCallColumn.LeadDefered - 1)))?null:(System.Boolean?)reader[((int)LeadHoldAndCallColumn.LeadDefered - 1)];
			entity.LeadActionDts = (reader.IsDBNull(((int)LeadHoldAndCallColumn.LeadActionDts - 1)))?null:(System.DateTime?)reader[((int)LeadHoldAndCallColumn.LeadActionDts - 1)];
			entity.LeadHoldAndCallPk = (System.Int64)reader[((int)LeadHoldAndCallColumn.LeadHoldAndCallPk - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SiH_SalesWorkflow.Entities.LeadHoldAndCall entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (System.String)dataRow["LEADID"];
			entity.UserId = (System.String)dataRow["USER_ID"];
			entity.LeadHoldDts = (System.DateTime)dataRow["LeadHoldDts"];
			entity.LeadCalled = Convert.IsDBNull(dataRow["LeadCalled"]) ? null : (System.Boolean?)dataRow["LeadCalled"];
			entity.LeadDefered = Convert.IsDBNull(dataRow["LeadDefered"]) ? null : (System.Boolean?)dataRow["LeadDefered"];
			entity.LeadActionDts = Convert.IsDBNull(dataRow["LeadActionDts"]) ? null : (System.DateTime?)dataRow["LeadActionDts"];
			entity.LeadHoldAndCallPk = (System.Int64)dataRow["LeadHoldAndCallPK"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="SiH_SalesWorkflow.Entities.LeadHoldAndCall"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SiH_SalesWorkflow.Entities.LeadHoldAndCall Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.LeadHoldAndCall entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the SiH_SalesWorkflow.Entities.LeadHoldAndCall object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SiH_SalesWorkflow.Entities.LeadHoldAndCall instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SiH_SalesWorkflow.Entities.LeadHoldAndCall Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.LeadHoldAndCall entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region LeadHoldAndCallChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SiH_SalesWorkflow.Entities.LeadHoldAndCall</c>
	///</summary>
	public enum LeadHoldAndCallChildEntityTypes
	{
	}
	
	#endregion LeadHoldAndCallChildEntityTypes
	
	#region LeadHoldAndCallFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LeadHoldAndCallColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadHoldAndCallFilterBuilder : SqlFilterBuilder<LeadHoldAndCallColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallFilterBuilder class.
		/// </summary>
		public LeadHoldAndCallFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadHoldAndCallFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadHoldAndCallFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadHoldAndCallFilterBuilder
	
	#region LeadHoldAndCallParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LeadHoldAndCallColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadHoldAndCallParameterBuilder : ParameterizedSqlFilterBuilder<LeadHoldAndCallColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallParameterBuilder class.
		/// </summary>
		public LeadHoldAndCallParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadHoldAndCallParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadHoldAndCallParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadHoldAndCallParameterBuilder
	
	#region LeadHoldAndCallSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;LeadHoldAndCallColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadHoldAndCall"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class LeadHoldAndCallSortBuilder : SqlSortBuilder<LeadHoldAndCallColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallSqlSortBuilder class.
		/// </summary>
		public LeadHoldAndCallSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion LeadHoldAndCallSortBuilder
	
} // end namespace
