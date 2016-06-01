
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
	/// An component type implementation of the 'vw_BaseLeadGetLessThanThreeCallsInPeriod' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class VwBaseLeadGetLessThanThreeCallsInPeriodService : SiH_SalesWorkflow.VwBaseLeadGetLessThanThreeCallsInPeriodServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanThreeCallsInPeriodService class.
		/// </summary>
		public VwBaseLeadGetLessThanThreeCallsInPeriodService() : base()
		{
		}
		
	}//End Class


} // end namespace
