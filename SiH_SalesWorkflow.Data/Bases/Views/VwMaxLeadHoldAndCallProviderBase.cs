﻿#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Data;

#endregion

namespace SiH_SalesWorkflow.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="VwMaxLeadHoldAndCallProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VwMaxLeadHoldAndCallProviderBase : VwMaxLeadHoldAndCallProviderBaseCore
	{
	} // end class
} // end namespace
