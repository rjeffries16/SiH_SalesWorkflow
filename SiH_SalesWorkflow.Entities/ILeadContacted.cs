﻿using System;
using System.ComponentModel;

namespace SiH_SalesWorkflow.Entities
{
	/// <summary>
	///		The data structure representation of the 'LeadContacted' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ILeadContacted 
	{
		/// <summary>			
		/// LeadContactedPK : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "LeadContacted"</remarks>
		System.Int64 LeadContactedPk { get; set; }
				
		
		
		/// <summary>
		/// LEADID : 
		/// </summary>
		System.String  Leadid  { get; set; }
		
		/// <summary>
		/// USER_ID : 
		/// </summary>
		System.String  UserId  { get; set; }
		
		/// <summary>
		/// LeadContactPhone : 
		/// </summary>
		System.Boolean?  LeadContactPhone  { get; set; }
		
		/// <summary>
		/// LeadContactEmail : 
		/// </summary>
		System.Boolean?  LeadContactEmail  { get; set; }
		
		/// <summary>
		/// LeadContactDts : 
		/// </summary>
		System.String  LeadContactDts  { get; set; }
		
		/// <summary>
		/// ThisEventDts : 
		/// </summary>
		System.DateTime?  ThisEventDts  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


