﻿#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using SalesWorkflow.Entities;
using SalesWorkflow.Data;

#endregion

namespace SalesWorkflow.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ZohoLeadsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ZohoLeadsProviderBase : ZohoLeadsProviderBaseCore
	{
	} // end class
} // end namespace
