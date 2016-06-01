﻿using System;
using System.ComponentModel;

namespace SalesWorkflow.Entities
{
	/// <summary>
	///		The data structure representation of the 'ZohoLeads' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IZohoLeads 
	{
		/// <summary>			
		/// LEADPK : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ZohoLeads"</remarks>
		System.Int64 Leadpk { get; set; }
				
		
		
		/// <summary>
		/// Activities Involved : 
		/// </summary>
		System.Boolean  ActivitiesInvolved  { get; set; }
		
		/// <summary>
		/// Calls Involved : 
		/// </summary>
		System.Boolean  CallsInvolved  { get; set; }
		
		/// <summary>
		/// Company : 
		/// </summary>
		System.String  Company  { get; set; }
		
		/// <summary>
		/// CONVERTED : 
		/// </summary>
		System.Boolean  Converted  { get; set; }
		
		/// <summary>
		/// Created By : 
		/// </summary>
		System.String  CreatedBy  { get; set; }
		
		/// <summary>
		/// Created Time : 
		/// </summary>
		System.DateTime?  CreatedTime  { get; set; }
		
		/// <summary>
		/// Email : 
		/// </summary>
		System.String  Email  { get; set; }
		
		/// <summary>
		/// Email Opt Out : 
		/// </summary>
		System.Boolean  EmailOptOut  { get; set; }
		
		/// <summary>
		/// Events Involved : 
		/// </summary>
		System.Boolean  EventsInvolved  { get; set; }
		
		/// <summary>
		/// Features of Interest : 
		/// </summary>
		System.String  FeaturesOfInterest  { get; set; }
		
		/// <summary>
		/// First Name : 
		/// </summary>
		System.String  FirstName  { get; set; }
		
		/// <summary>
		/// First Time Caller (new lead) : 
		/// </summary>
		System.Boolean  SafeNameFirstTimeCallerNewLead  { get; set; }
		
		/// <summary>
		/// If No Longer Interested : 
		/// </summary>
		System.String  IfNoLongerInterested  { get; set; }
		
		/// <summary>
		/// Industry : 
		/// </summary>
		System.String  Industry  { get; set; }
		
		/// <summary>
		/// Last Activity Time : 
		/// </summary>
		System.DateTime?  LastActivityTime  { get; set; }
		
		/// <summary>
		/// Last Name : 
		/// </summary>
		System.String  LastName  { get; set; }
		
		/// <summary>
		/// Last Visited Time : 
		/// </summary>
		System.String  LastVisitedTime  { get; set; }
		
		/// <summary>
		/// Lead Owner Id : 
		/// </summary>
		System.String  LeadOwnerId  { get; set; }
		
		/// <summary>
		/// Lead Owner : 
		/// </summary>
		System.String  LeadOwner  { get; set; }
		
		/// <summary>
		/// Lead Source : 
		/// </summary>
		System.String  LeadSource  { get; set; }
		
		/// <summary>
		/// Lead Status : 
		/// </summary>
		System.String  LeadStatus  { get; set; }
		
		/// <summary>
		/// LEADID : 
		/// </summary>
		System.String  Leadid  { get; set; }
		
		/// <summary>
		/// Mobile : 
		/// </summary>
		System.String  Mobile  { get; set; }
		
		/// <summary>
		/// Modified By : 
		/// </summary>
		System.String  ModifiedBy  { get; set; }
		
		/// <summary>
		/// Modified Time : 
		/// </summary>
		System.DateTime?  ModifiedTime  { get; set; }
		
		/// <summary>
		/// Phone : 
		/// </summary>
		System.String  Phone  { get; set; }
		
		/// <summary>
		/// Rating : 
		/// </summary>
		System.String  Rating  { get; set; }
		
		/// <summary>
		/// Secondary Email : 
		/// </summary>
		System.String  SecondaryEmail  { get; set; }
		
		/// <summary>
		/// State : 
		/// </summary>
		System.String  State  { get; set; }
		
		/// <summary>
		/// Submission Time : 
		/// </summary>
		System.String  SubmissionTime  { get; set; }
		
		/// <summary>
		/// Submitted On : 
		/// </summary>
		System.DateTime?  SubmittedOn  { get; set; }
		
		/// <summary>
		/// Tasks Involved : 
		/// </summary>
		System.Boolean  TasksInvolved  { get; set; }
		
		/// <summary>
		/// Time Zone : 
		/// </summary>
		System.String  TimeZone  { get; set; }
		
		/// <summary>
		/// URL : 
		/// </summary>
		System.String  Url  { get; set; }
		
		/// <summary>
		/// Website : 
		/// </summary>
		System.String  Website  { get; set; }
		
		/// <summary>
		/// Worries : 
		/// </summary>
		System.String  Worries  { get; set; }
		
		/// <summary>
		/// WDay8-11 : 
		/// </summary>
		System.Int32?  Wday811  { get; set; }
		
		/// <summary>
		/// WDay11-2 : 
		/// </summary>
		System.Int32?  Wday112  { get; set; }
		
		/// <summary>
		/// WDay2-5 : 
		/// </summary>
		System.Int32?  Wday25  { get; set; }
		
		/// <summary>
		/// WDay5-8 : 
		/// </summary>
		System.Int32?  Wday58  { get; set; }
		
		/// <summary>
		/// Sat8-11 : 
		/// </summary>
		System.Int32?  Sat811  { get; set; }
		
		/// <summary>
		/// Sat11-2 : 
		/// </summary>
		System.Int32?  Sat112  { get; set; }
		
		/// <summary>
		/// Sat2-5 : 
		/// </summary>
		System.Int32?  Sat25  { get; set; }
		
		/// <summary>
		/// Sat5-8 : 
		/// </summary>
		System.Int32?  Sat58  { get; set; }
		
		/// <summary>
		/// Sun8-11 : 
		/// </summary>
		System.Int32?  Sun811  { get; set; }
		
		/// <summary>
		/// Sun11-2 : 
		/// </summary>
		System.Int32?  Sun112  { get; set; }
		
		/// <summary>
		/// Sun2-5 : 
		/// </summary>
		System.Int32?  Sun25  { get; set; }
		
		/// <summary>
		/// Sun5-8 : 
		/// </summary>
		System.Int32?  Sun58  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


