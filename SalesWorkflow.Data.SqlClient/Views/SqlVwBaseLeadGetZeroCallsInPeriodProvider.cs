﻿#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;

using SalesWorkflow.Entities;
using SalesWorkflow.Data;

#endregion

namespace SalesWorkflow.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="VwBaseLeadGetZeroCallsInPeriod"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class SqlVwBaseLeadGetZeroCallsInPeriodProvider: SqlVwBaseLeadGetZeroCallsInPeriodProviderBase
	{		
		/// <summary>
		/// Creates a new <see cref="SqlVwBaseLeadGetZeroCallsInPeriodProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="connectionString">The connection string to the database.</param>
		/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
		/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
		public SqlVwBaseLeadGetZeroCallsInPeriodProvider(string connectionString, bool useStoredProcedure, string providerInvariantName): base(connectionString, useStoredProcedure, providerInvariantName){}
	}
}