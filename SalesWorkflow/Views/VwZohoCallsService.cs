
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using SalesWorkflow.Entities;
using SalesWorkflow.Entities.Validation;

using SalesWorkflow.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace SalesWorkflow
{		
	
	///<summary>
	/// An component type implementation of the 'vw_ZohoCalls' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class VwZohoCallsService : SalesWorkflow.VwZohoCallsServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the VwZohoCallsService class.
		/// </summary>
		public VwZohoCallsService() : base()
		{
		}
		
	}//End Class


} // end namespace
