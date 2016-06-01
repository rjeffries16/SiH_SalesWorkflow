#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using SalesWorkflow.Entities;
using SalesWorkflow.Data;

#endregion

namespace SalesWorkflow.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="LeadContactedProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LeadContactedProviderBaseCore : EntityProviderBase<SalesWorkflow.Entities.LeadContacted, SalesWorkflow.Entities.LeadContactedKey>
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
		public override bool Delete(TransactionManager transactionManager, SalesWorkflow.Entities.LeadContactedKey key)
		{
			return Delete(transactionManager, key.LeadContactedPk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_leadContactedPk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _leadContactedPk)
		{
			return Delete(null, _leadContactedPk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadContactedPk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _leadContactedPk);		
		
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
		public override SalesWorkflow.Entities.LeadContacted Get(TransactionManager transactionManager, SalesWorkflow.Entities.LeadContactedKey key, int start, int pageLength)
		{
			return GetByLeadContactedPk(transactionManager, key.LeadContactedPk, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key LeadContactedPK index.
		/// </summary>
		/// <param name="_leadContactedPk"></param>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.LeadContacted"/> class.</returns>
		public SalesWorkflow.Entities.LeadContacted GetByLeadContactedPk(System.Int64 _leadContactedPk)
		{
			int count = -1;
			return GetByLeadContactedPk(null,_leadContactedPk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LeadContactedPK index.
		/// </summary>
		/// <param name="_leadContactedPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.LeadContacted"/> class.</returns>
		public SalesWorkflow.Entities.LeadContacted GetByLeadContactedPk(System.Int64 _leadContactedPk, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadContactedPk(null, _leadContactedPk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LeadContactedPK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadContactedPk"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.LeadContacted"/> class.</returns>
		public SalesWorkflow.Entities.LeadContacted GetByLeadContactedPk(TransactionManager transactionManager, System.Int64 _leadContactedPk)
		{
			int count = -1;
			return GetByLeadContactedPk(transactionManager, _leadContactedPk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LeadContactedPK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadContactedPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.LeadContacted"/> class.</returns>
		public SalesWorkflow.Entities.LeadContacted GetByLeadContactedPk(TransactionManager transactionManager, System.Int64 _leadContactedPk, int start, int pageLength)
		{
			int count = -1;
			return GetByLeadContactedPk(transactionManager, _leadContactedPk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LeadContactedPK index.
		/// </summary>
		/// <param name="_leadContactedPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.LeadContacted"/> class.</returns>
		public SalesWorkflow.Entities.LeadContacted GetByLeadContactedPk(System.Int64 _leadContactedPk, int start, int pageLength, out int count)
		{
			return GetByLeadContactedPk(null, _leadContactedPk, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the LeadContactedPK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_leadContactedPk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SalesWorkflow.Entities.LeadContacted"/> class.</returns>
		public abstract SalesWorkflow.Entities.LeadContacted GetByLeadContactedPk(TransactionManager transactionManager, System.Int64 _leadContactedPk, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;LeadContacted&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;LeadContacted&gt;"/></returns>
		public static TList<LeadContacted> Fill(IDataReader reader, TList<LeadContacted> rows, int start, int pageLength)
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
				
				SalesWorkflow.Entities.LeadContacted c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("LeadContacted")
					.Append("|").Append((System.Int64)reader[((int)LeadContactedColumn.LeadContactedPk - 1)]).ToString();
					c = EntityManager.LocateOrCreate<LeadContacted>(
					key.ToString(), // EntityTrackingKey
					"LeadContacted",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SalesWorkflow.Entities.LeadContacted();
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
					c.Leadid = (System.String)reader[((int)LeadContactedColumn.Leadid - 1)];
					c.UserId = (System.String)reader[((int)LeadContactedColumn.UserId - 1)];
					c.LeadContactPhone = (reader.IsDBNull(((int)LeadContactedColumn.LeadContactPhone - 1)))?null:(System.Boolean?)reader[((int)LeadContactedColumn.LeadContactPhone - 1)];
					c.LeadContactEmail = (reader.IsDBNull(((int)LeadContactedColumn.LeadContactEmail - 1)))?null:(System.Boolean?)reader[((int)LeadContactedColumn.LeadContactEmail - 1)];
					c.LeadContactDts = (reader.IsDBNull(((int)LeadContactedColumn.LeadContactDts - 1)))?null:(System.String)reader[((int)LeadContactedColumn.LeadContactDts - 1)];
					c.LeadContactedPk = (System.Int64)reader[((int)LeadContactedColumn.LeadContactedPk - 1)];
					c.ThisEventDts = (reader.IsDBNull(((int)LeadContactedColumn.ThisEventDts - 1)))?null:(System.DateTime?)reader[((int)LeadContactedColumn.ThisEventDts - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SalesWorkflow.Entities.LeadContacted"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SalesWorkflow.Entities.LeadContacted"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SalesWorkflow.Entities.LeadContacted entity)
		{
			if (!reader.Read()) return;
			
			entity.Leadid = (System.String)reader[((int)LeadContactedColumn.Leadid - 1)];
			entity.UserId = (System.String)reader[((int)LeadContactedColumn.UserId - 1)];
			entity.LeadContactPhone = (reader.IsDBNull(((int)LeadContactedColumn.LeadContactPhone - 1)))?null:(System.Boolean?)reader[((int)LeadContactedColumn.LeadContactPhone - 1)];
			entity.LeadContactEmail = (reader.IsDBNull(((int)LeadContactedColumn.LeadContactEmail - 1)))?null:(System.Boolean?)reader[((int)LeadContactedColumn.LeadContactEmail - 1)];
			entity.LeadContactDts = (reader.IsDBNull(((int)LeadContactedColumn.LeadContactDts - 1)))?null:(System.String)reader[((int)LeadContactedColumn.LeadContactDts - 1)];
			entity.LeadContactedPk = (System.Int64)reader[((int)LeadContactedColumn.LeadContactedPk - 1)];
			entity.ThisEventDts = (reader.IsDBNull(((int)LeadContactedColumn.ThisEventDts - 1)))?null:(System.DateTime?)reader[((int)LeadContactedColumn.ThisEventDts - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SalesWorkflow.Entities.LeadContacted"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SalesWorkflow.Entities.LeadContacted"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SalesWorkflow.Entities.LeadContacted entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Leadid = (System.String)dataRow["LEADID"];
			entity.UserId = (System.String)dataRow["USER_ID"];
			entity.LeadContactPhone = Convert.IsDBNull(dataRow["LeadContactPhone"]) ? null : (System.Boolean?)dataRow["LeadContactPhone"];
			entity.LeadContactEmail = Convert.IsDBNull(dataRow["LeadContactEmail"]) ? null : (System.Boolean?)dataRow["LeadContactEmail"];
			entity.LeadContactDts = Convert.IsDBNull(dataRow["LeadContactDts"]) ? null : (System.String)dataRow["LeadContactDts"];
			entity.LeadContactedPk = (System.Int64)dataRow["LeadContactedPK"];
			entity.ThisEventDts = Convert.IsDBNull(dataRow["ThisEventDts"]) ? null : (System.DateTime?)dataRow["ThisEventDts"];
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
		/// <param name="entity">The <see cref="SalesWorkflow.Entities.LeadContacted"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SalesWorkflow.Entities.LeadContacted Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SalesWorkflow.Entities.LeadContacted entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SalesWorkflow.Entities.LeadContacted object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SalesWorkflow.Entities.LeadContacted instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SalesWorkflow.Entities.LeadContacted Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SalesWorkflow.Entities.LeadContacted entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region LeadContactedChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SalesWorkflow.Entities.LeadContacted</c>
	///</summary>
	public enum LeadContactedChildEntityTypes
	{
	}
	
	#endregion LeadContactedChildEntityTypes
	
	#region LeadContactedFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LeadContactedColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadContacted"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadContactedFilterBuilder : SqlFilterBuilder<LeadContactedColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadContactedFilterBuilder class.
		/// </summary>
		public LeadContactedFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadContactedFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadContactedFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadContactedFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadContactedFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadContactedFilterBuilder
	
	#region LeadContactedParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LeadContactedColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadContacted"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadContactedParameterBuilder : ParameterizedSqlFilterBuilder<LeadContactedColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadContactedParameterBuilder class.
		/// </summary>
		public LeadContactedParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadContactedParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadContactedParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadContactedParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadContactedParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadContactedParameterBuilder
	
	#region LeadContactedSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;LeadContactedColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadContacted"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class LeadContactedSortBuilder : SqlSortBuilder<LeadContactedColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadContactedSqlSortBuilder class.
		/// </summary>
		public LeadContactedSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion LeadContactedSortBuilder
	
} // end namespace
