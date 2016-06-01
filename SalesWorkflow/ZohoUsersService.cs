
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
	/// An component type implementation of the 'ZohoUsers' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ZohoUsersService : SalesWorkflow.ZohoUsersServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ZohoUsersService class.
		/// </summary>
		public ZohoUsersService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
