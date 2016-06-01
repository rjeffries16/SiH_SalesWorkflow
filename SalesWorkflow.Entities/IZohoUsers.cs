﻿using System;
using System.ComponentModel;

namespace SalesWorkflow.Entities
{
	/// <summary>
	///		The data structure representation of the 'ZohoUsers' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IZohoUsers 
	{
		/// <summary>			
		/// USERPK : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ZohoUsers"</remarks>
		System.Int64 Userpk { get; set; }
				
		
		
		/// <summary>
		/// USER_ID : 
		/// </summary>
		System.String  UserId  { get; set; }
		
		/// <summary>
		/// First Name : 
		/// </summary>
		System.String  FirstName  { get; set; }
		
		/// <summary>
		/// Last Name : 
		/// </summary>
		System.String  LastName  { get; set; }
		
		/// <summary>
		/// Email : 
		/// </summary>
		System.String  Email  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


