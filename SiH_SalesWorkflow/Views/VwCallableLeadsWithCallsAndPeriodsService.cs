﻿
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Entities.Validation;

using SiH_SalesWorkflow.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace SiH_SalesWorkflow
{		
	
	///<summary>
	/// An component type implementation of the 'vw_CallableLeadsWithCallsAndPeriods' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class VwCallableLeadsWithCallsAndPeriodsService : SiH_SalesWorkflow.VwCallableLeadsWithCallsAndPeriodsServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsService class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodsService() : base()
		{
		}
		
	}//End Class


} // end namespace
