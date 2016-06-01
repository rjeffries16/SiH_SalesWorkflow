
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
	/// <summary>
	/// An component type implementation of the 'LeadContacted' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class LeadContactedService : SalesWorkflow.LeadContactedServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the LeadContactedService class.
		/// </summary>
		public LeadContactedService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
