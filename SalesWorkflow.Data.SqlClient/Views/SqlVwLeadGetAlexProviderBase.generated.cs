﻿/*
	File Generated by NetTiers templates [www.nettiers.net]
	Generated on : Thursday, May 12, 2016
	Important: Do not modify this file. Edit the file VwLeadGetAlex.cs instead.
*/

#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SalesWorkflow.Entities;
using SalesWorkflow.Data.Bases;

#endregion

namespace SalesWorkflow.Data.SqlClient
{
/// <summary>
///	This class is the base repository for the CRUD operations on the VwLeadGetAlex objects.
/// </summary>
public abstract partial class SqlVwLeadGetAlexProviderBase : VwLeadGetAlexProviderBase
{
	
	string _connectionString;
    bool _useStoredProcedure;
    string _providerInvariantName;
		
	#region Constructors
	
	/// <summary>
	/// Creates a new <see cref="SqlVwLeadGetAlexProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	protected SqlVwLeadGetAlexProviderBase()
	{		
	}
	
	/// <summary>
	/// Creates a new <see cref="SqlVwLeadGetAlexProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we use stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlVwLeadGetAlexProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}
			
	#endregion 
	
	#region Public properties
	/// <summary>
    /// Gets or sets the connection string.
    /// </summary>
    /// <value>The connection string.</value>
    public string ConnectionString
	{
		get {return this._connectionString;}
		set {this._connectionString = value;}
	}
	
	/// <summary>
    /// Gets or sets a value indicating whether to use stored procedures.
    /// </summary>
    /// <value><c>true</c> if we choose to use stored procedures; otherwise, <c>false</c>.</value>
	public bool UseStoredProcedure
	{
		get {return this._useStoredProcedure;}
		set {this._useStoredProcedure = value;}
	}
	
	/// <summary>
    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
    /// </summary>
    /// <value>The name of the provider invariant.</value>
    public string ProviderInvariantName
    {
        get { return this._providerInvariantName; }
        set { this._providerInvariantName = value; }
    }
	#endregion
		
	
	#region GetAll Methods
	
	/// <summary>
	/// Gets All rows from the DataSource.
	/// </summary>
	/// <param name="transactionManager"><see cref="TransactionManager"/> object.</param>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pageLength">Number of rows to return.</param>
	/// <param name="count">The total number of rows in the data source.</param>
	/// <remarks></remarks>
	/// <returns>Returns a typed collection of VwLeadGetAlex objects.</returns>
	public override VList<VwLeadGetAlex> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
	{
		SqlDatabase database = new SqlDatabase(this._connectionString);
		DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.vw_LeadGetAlex_Get_List", _useStoredProcedure);
		
		IDataReader reader = null;
		//Create Collection
		VList<VwLeadGetAlex> rows = new VList<VwLeadGetAlex>();
		
		try
		{
			if (transactionManager != null)
			{
				reader = Utility.ExecuteReader(transactionManager, commandWrapper);
			}
			else
			{
				reader = Utility.ExecuteReader(database, commandWrapper);
			}
		
			Fill(reader, rows, start, pageLength);
			count = rows.Count;

			if(reader.NextResult())
			{
				if(reader.Read())
				{
					count = reader.GetInt32(0);
				}
			}
		}
		finally
		{
			if (reader != null)
				reader.Close();
		}
		return rows;
	}//end getall
	
	#endregion
	
	#region Get Methods
			
	/// <summary>
	/// Gets a page of rows from the DataSource.
	/// </summary>
	/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
	/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pageLength">Number of rows to return.</param>
	/// <param name="count">The total number of rows in the data source.</param>
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <remarks></remarks>
	/// <returns>Returns a typed collection of VwLeadGetAlex objects.</returns>
	public override VList<VwLeadGetAlex> Get(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
	{
		SqlDatabase database = new SqlDatabase(this._connectionString);
		DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.vw_LeadGetAlex_Get", _useStoredProcedure);

		database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
		database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
	
		IDataReader reader = null;
		//Create Collection
		VList<VwLeadGetAlex> rows = new VList<VwLeadGetAlex>();
		
		try
		{
			if (transactionManager != null)
			{
				reader = Utility.ExecuteReader(transactionManager,commandWrapper);
			}
			else
			{
				reader = Utility.ExecuteReader(database, commandWrapper);
			}

			Fill(reader, rows, start, pageLength);
			count = rows.Count;

			if(reader.NextResult())
			{
				if(reader.Read())
				{
					count = reader.GetInt32(0);
				}
			}
		}
		finally
		{
		     if (reader != null)
		     	 reader.Close();
		}
		return rows;
	}
	
	#endregion
	
	#region Find Methods
	
	#region Parameterized Find Methods
	
	/// <summary>
	/// Returns rows from the DataSource that meet the parameter conditions.
	/// </summary>
	/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
	/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
	/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
	/// <param name="start">Row number at which to start reading.</param>
	/// <param name="pageLength">Number of rows to return.</param>
	/// <param name="count">out. The number of rows that match this query.</param>
	/// <returns>Returns a typed collection of VwLeadGetAlex objects.</returns>
	public override VList<VwLeadGetAlex> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
	{
		SqlFilterParameterCollection filter = null;
		
		if (parameters == null)
			filter = new SqlFilterParameterCollection();
		else 
			filter = parameters.GetParameters();
			
		SqlDatabase database = new SqlDatabase(this._connectionString);
		DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.vw_LeadGetAlex_Find_Dynamic", typeof(VwLeadGetAlexColumn), filter, orderBy, start, pageLength);
		
		SqlFilterParameter param;

		for ( int i = 0; i < filter.Count; i++ )
		{
			param = filter[i];
			database.AddInParameter(commandWrapper, param.Name, param.DbType, param.GetValue());
		}

		VList<VwLeadGetAlex> rows = new VList<VwLeadGetAlex>();
		IDataReader reader = null;
		
		try
		{
			if ( transactionManager != null )
			{
				reader = Utility.ExecuteReader(transactionManager, commandWrapper);
			}
			else
			{
				reader = Utility.ExecuteReader(database, commandWrapper);
			}
			
			Fill(reader, rows, start, pageLength);
			count = rows.Count;
			
			if ( reader.NextResult() )
			{
				if ( reader.Read() )
				{
					count = reader.GetInt32(0);
				}
			}
		}
		finally
		{
			if ( reader != null )
				reader.Close();
		}
		
		return rows;
	}
	
	#endregion Parameterized Find Methods

	#endregion 

	#region Custom Methods
	

	#endregion


	}//end class
} // end namespace
