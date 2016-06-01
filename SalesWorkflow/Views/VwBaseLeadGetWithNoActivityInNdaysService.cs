
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
	/// An component type implementation of the 'vw_BaseLeadGetWithNoActivityInNDays' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class VwBaseLeadGetWithNoActivityInNdaysService : SalesWorkflow.VwBaseLeadGetWithNoActivityInNdaysServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityInNdaysService class.
		/// </summary>
		public VwBaseLeadGetWithNoActivityInNdaysService() : base()
		{
		}
		
	}//End Class


} // end namespace
