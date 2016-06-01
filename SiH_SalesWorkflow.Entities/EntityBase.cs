using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace SiH_SalesWorkflow.Entities
{

	/// <summary>
	/// The base object for each database table entity.
	/// </summary>
	[Serializable]
	public abstract partial class EntityBase : EntityBaseCore
	{
	
	}
}