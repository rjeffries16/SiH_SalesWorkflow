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
	/// This class is the base class for any <see cref="ZohoUsersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ZohoUsersProviderBaseCore : EntityProviderBase<SiH_SalesWorkflow.Entities.ZohoUsers, SiH_SalesWorkflow.Entities.ZohoUsersKey>
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
		public override bool Delete(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.ZohoUsersKey key)
		{
			return Delete(transactionManager, key.Userpk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_userpk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _userpk)
		{
			return Delete(null, _userpk);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userpk">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _userpk);		
		
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
		public override SiH_SalesWorkflow.Entities.ZohoUsers Get(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.ZohoUsersKey key, int start, int pageLength)
		{
			return GetByUserpk(transactionManager, key.Userpk, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ZohoUsers index.
		/// </summary>
		/// <param name="_userpk"></param>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> class.</returns>
		public SiH_SalesWorkflow.Entities.ZohoUsers GetByUserpk(System.Int64 _userpk)
		{
			int count = -1;
			return GetByUserpk(null,_userpk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoUsers index.
		/// </summary>
		/// <param name="_userpk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> class.</returns>
		public SiH_SalesWorkflow.Entities.ZohoUsers GetByUserpk(System.Int64 _userpk, int start, int pageLength)
		{
			int count = -1;
			return GetByUserpk(null, _userpk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoUsers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userpk"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> class.</returns>
		public SiH_SalesWorkflow.Entities.ZohoUsers GetByUserpk(TransactionManager transactionManager, System.Int64 _userpk)
		{
			int count = -1;
			return GetByUserpk(transactionManager, _userpk, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoUsers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userpk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> class.</returns>
		public SiH_SalesWorkflow.Entities.ZohoUsers GetByUserpk(TransactionManager transactionManager, System.Int64 _userpk, int start, int pageLength)
		{
			int count = -1;
			return GetByUserpk(transactionManager, _userpk, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoUsers index.
		/// </summary>
		/// <param name="_userpk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> class.</returns>
		public SiH_SalesWorkflow.Entities.ZohoUsers GetByUserpk(System.Int64 _userpk, int start, int pageLength, out int count)
		{
			return GetByUserpk(null, _userpk, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ZohoUsers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userpk"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> class.</returns>
		public abstract SiH_SalesWorkflow.Entities.ZohoUsers GetByUserpk(TransactionManager transactionManager, System.Int64 _userpk, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ZohoUsers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ZohoUsers&gt;"/></returns>
		public static TList<ZohoUsers> Fill(IDataReader reader, TList<ZohoUsers> rows, int start, int pageLength)
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
				
				SiH_SalesWorkflow.Entities.ZohoUsers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ZohoUsers")
					.Append("|").Append((System.Int64)reader[((int)ZohoUsersColumn.Userpk - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ZohoUsers>(
					key.ToString(), // EntityTrackingKey
					"ZohoUsers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SiH_SalesWorkflow.Entities.ZohoUsers();
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
					c.UserId = (reader.IsDBNull(((int)ZohoUsersColumn.UserId - 1)))?null:(System.String)reader[((int)ZohoUsersColumn.UserId - 1)];
					c.FirstName = (reader.IsDBNull(((int)ZohoUsersColumn.FirstName - 1)))?null:(System.String)reader[((int)ZohoUsersColumn.FirstName - 1)];
					c.LastName = (reader.IsDBNull(((int)ZohoUsersColumn.LastName - 1)))?null:(System.String)reader[((int)ZohoUsersColumn.LastName - 1)];
					c.Email = (reader.IsDBNull(((int)ZohoUsersColumn.Email - 1)))?null:(System.String)reader[((int)ZohoUsersColumn.Email - 1)];
					c.Userpk = (System.Int64)reader[((int)ZohoUsersColumn.Userpk - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SiH_SalesWorkflow.Entities.ZohoUsers entity)
		{
			if (!reader.Read()) return;
			
			entity.UserId = (reader.IsDBNull(((int)ZohoUsersColumn.UserId - 1)))?null:(System.String)reader[((int)ZohoUsersColumn.UserId - 1)];
			entity.FirstName = (reader.IsDBNull(((int)ZohoUsersColumn.FirstName - 1)))?null:(System.String)reader[((int)ZohoUsersColumn.FirstName - 1)];
			entity.LastName = (reader.IsDBNull(((int)ZohoUsersColumn.LastName - 1)))?null:(System.String)reader[((int)ZohoUsersColumn.LastName - 1)];
			entity.Email = (reader.IsDBNull(((int)ZohoUsersColumn.Email - 1)))?null:(System.String)reader[((int)ZohoUsersColumn.Email - 1)];
			entity.Userpk = (System.Int64)reader[((int)ZohoUsersColumn.Userpk - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SiH_SalesWorkflow.Entities.ZohoUsers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserId = Convert.IsDBNull(dataRow["USER_ID"]) ? null : (System.String)dataRow["USER_ID"];
			entity.FirstName = Convert.IsDBNull(dataRow["First Name"]) ? null : (System.String)dataRow["First Name"];
			entity.LastName = Convert.IsDBNull(dataRow["Last Name"]) ? null : (System.String)dataRow["Last Name"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Userpk = (System.Int64)dataRow["USERPK"];
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
		/// <param name="entity">The <see cref="SiH_SalesWorkflow.Entities.ZohoUsers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SiH_SalesWorkflow.Entities.ZohoUsers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.ZohoUsers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SiH_SalesWorkflow.Entities.ZohoUsers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SiH_SalesWorkflow.Entities.ZohoUsers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SiH_SalesWorkflow.Entities.ZohoUsers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SiH_SalesWorkflow.Entities.ZohoUsers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ZohoUsersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SiH_SalesWorkflow.Entities.ZohoUsers</c>
	///</summary>
	public enum ZohoUsersChildEntityTypes
	{
	}
	
	#endregion ZohoUsersChildEntityTypes
	
	#region ZohoUsersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ZohoUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoUsersFilterBuilder : SqlFilterBuilder<ZohoUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoUsersFilterBuilder class.
		/// </summary>
		public ZohoUsersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoUsersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoUsersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoUsersFilterBuilder
	
	#region ZohoUsersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ZohoUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoUsersParameterBuilder : ParameterizedSqlFilterBuilder<ZohoUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoUsersParameterBuilder class.
		/// </summary>
		public ZohoUsersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoUsersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoUsersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoUsersParameterBuilder
	
	#region ZohoUsersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ZohoUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoUsers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ZohoUsersSortBuilder : SqlSortBuilder<ZohoUsersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoUsersSqlSortBuilder class.
		/// </summary>
		public ZohoUsersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ZohoUsersSortBuilder
	
} // end namespace
