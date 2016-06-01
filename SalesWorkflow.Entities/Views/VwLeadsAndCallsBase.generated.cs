﻿/*
	File generated by NetTiers templates [www.nettiers.net]
	Generated on : Thursday, May 12, 2016
	Important: Do not modify this file. Edit the file VwLeadsAndCalls.cs instead.
*/
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;
#endregion

namespace SalesWorkflow.Entities
{
	///<summary>
	/// An object representation of the 'vw_LeadsAndCalls' view. [No description found in the database]	
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("VwLeadsAndCallsBase")]
	public abstract partial class VwLeadsAndCallsBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{
		
		#region Variable Declarations
		
		/// <summary>
		/// LEADID : 
		/// </summary>
		private System.String		  _leadid = null;
		
		/// <summary>
		/// Last Name : 
		/// </summary>
		private System.String		  _lastName = null;
		
		/// <summary>
		/// First Name : 
		/// </summary>
		private System.String		  _firstName = null;
		
		/// <summary>
		/// Created Time : 
		/// </summary>
		private System.DateTime?		  _createdTime = null;
		
		/// <summary>
		/// Last Activity Time : 
		/// </summary>
		private System.DateTime?		  _lastActivityTime = null;
		
		/// <summary>
		/// Last Visited Time : 
		/// </summary>
		private System.String		  _lastVisitedTime = null;
		
		/// <summary>
		/// Lead Owner : 
		/// </summary>
		private System.String		  _leadOwner = null;
		
		/// <summary>
		/// Lead Source : 
		/// </summary>
		private System.String		  _leadSource = null;
		
		/// <summary>
		/// Rating : 
		/// </summary>
		private System.String		  _rating = null;
		
		/// <summary>
		/// Lead Status : 
		/// </summary>
		private System.String		  _leadStatus = null;
		
		/// <summary>
		/// Time Zone : 
		/// </summary>
		private System.String		  _timeZone = null;
		
		/// <summary>
		/// Call Duration (in minutes) : 
		/// </summary>
		private System.Double?		  _safeNameCallDurationInMinutes = null;
		
		/// <summary>
		/// Call Purpose : 
		/// </summary>
		private System.String		  _callPurpose = null;
		
		/// <summary>
		/// Call Result : 
		/// </summary>
		private System.String		  _callResult = null;
		
		/// <summary>
		/// Call Start Time : 
		/// </summary>
		private System.DateTime?		  _callStartTime = null;
		
		/// <summary>
		/// CreatedBy : 
		/// </summary>
		private System.String		  _createdBy = null;
		
		/// <summary>
		/// Subject : 
		/// </summary>
		private System.String		  _subject = null;
		
		/// <summary>
		/// Object that contains data to associate with this object
		/// </summary>
		private object _tag;
		
		/// <summary>
		/// Suppresses Entity Events from Firing, 
		/// useful when loading the entities from the database.
		/// </summary>
	    [NonSerialized] 
		private bool suppressEntityEvents = false;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="VwLeadsAndCallsBase"/> instance.
		///</summary>
		public VwLeadsAndCallsBase()
		{
		}		
		
		///<summary>
		/// Creates a new <see cref="VwLeadsAndCallsBase"/> instance.
		///</summary>
		///<param name="_leadid"></param>
		///<param name="_lastName"></param>
		///<param name="_firstName"></param>
		///<param name="_createdTime"></param>
		///<param name="_lastActivityTime"></param>
		///<param name="_lastVisitedTime"></param>
		///<param name="_leadOwner"></param>
		///<param name="_leadSource"></param>
		///<param name="_rating"></param>
		///<param name="_leadStatus"></param>
		///<param name="_timeZone"></param>
		///<param name="_safeNameCallDurationInMinutes"></param>
		///<param name="_callPurpose"></param>
		///<param name="_callResult"></param>
		///<param name="_callStartTime"></param>
		///<param name="_createdBy"></param>
		///<param name="_subject"></param>
		public VwLeadsAndCallsBase(System.String _leadid, System.String _lastName, System.String _firstName, System.DateTime? _createdTime, System.DateTime? _lastActivityTime, System.String _lastVisitedTime, System.String _leadOwner, System.String _leadSource, System.String _rating, System.String _leadStatus, System.String _timeZone, System.Double? _safeNameCallDurationInMinutes, System.String _callPurpose, System.String _callResult, System.DateTime? _callStartTime, System.String _createdBy, System.String _subject)
		{
			this._leadid = _leadid;
			this._lastName = _lastName;
			this._firstName = _firstName;
			this._createdTime = _createdTime;
			this._lastActivityTime = _lastActivityTime;
			this._lastVisitedTime = _lastVisitedTime;
			this._leadOwner = _leadOwner;
			this._leadSource = _leadSource;
			this._rating = _rating;
			this._leadStatus = _leadStatus;
			this._timeZone = _timeZone;
			this._safeNameCallDurationInMinutes = _safeNameCallDurationInMinutes;
			this._callPurpose = _callPurpose;
			this._callResult = _callResult;
			this._callStartTime = _callStartTime;
			this._createdBy = _createdBy;
			this._subject = _subject;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="VwLeadsAndCalls"/> instance.
		///</summary>
		///<param name="_leadid"></param>
		///<param name="_lastName"></param>
		///<param name="_firstName"></param>
		///<param name="_createdTime"></param>
		///<param name="_lastActivityTime"></param>
		///<param name="_lastVisitedTime"></param>
		///<param name="_leadOwner"></param>
		///<param name="_leadSource"></param>
		///<param name="_rating"></param>
		///<param name="_leadStatus"></param>
		///<param name="_timeZone"></param>
		///<param name="_safeNameCallDurationInMinutes"></param>
		///<param name="_callPurpose"></param>
		///<param name="_callResult"></param>
		///<param name="_callStartTime"></param>
		///<param name="_createdBy"></param>
		///<param name="_subject"></param>
		public static VwLeadsAndCalls CreateVwLeadsAndCalls(System.String _leadid, System.String _lastName, System.String _firstName, System.DateTime? _createdTime, System.DateTime? _lastActivityTime, System.String _lastVisitedTime, System.String _leadOwner, System.String _leadSource, System.String _rating, System.String _leadStatus, System.String _timeZone, System.Double? _safeNameCallDurationInMinutes, System.String _callPurpose, System.String _callResult, System.DateTime? _callStartTime, System.String _createdBy, System.String _subject)
		{
			VwLeadsAndCalls newVwLeadsAndCalls = new VwLeadsAndCalls();
			newVwLeadsAndCalls.Leadid = _leadid;
			newVwLeadsAndCalls.LastName = _lastName;
			newVwLeadsAndCalls.FirstName = _firstName;
			newVwLeadsAndCalls.CreatedTime = _createdTime;
			newVwLeadsAndCalls.LastActivityTime = _lastActivityTime;
			newVwLeadsAndCalls.LastVisitedTime = _lastVisitedTime;
			newVwLeadsAndCalls.LeadOwner = _leadOwner;
			newVwLeadsAndCalls.LeadSource = _leadSource;
			newVwLeadsAndCalls.Rating = _rating;
			newVwLeadsAndCalls.LeadStatus = _leadStatus;
			newVwLeadsAndCalls.TimeZone = _timeZone;
			newVwLeadsAndCalls.SafeNameCallDurationInMinutes = _safeNameCallDurationInMinutes;
			newVwLeadsAndCalls.CallPurpose = _callPurpose;
			newVwLeadsAndCalls.CallResult = _callResult;
			newVwLeadsAndCalls.CallStartTime = _callStartTime;
			newVwLeadsAndCalls.CreatedBy = _createdBy;
			newVwLeadsAndCalls.Subject = _subject;
			return newVwLeadsAndCalls;
		}
				
		#endregion Constructors
		
		#region Properties	
		/// <summary>
		/// 	Gets or Sets the LEADID property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Leadid
		{
			get
			{
				return this._leadid; 
			}
			set
			{
				if (_leadid == value)
					return;
					
				this._leadid = value;
				this._isDirty = true;
				
				OnPropertyChanged("Leadid");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Last Name property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String LastName
		{
			get
			{
				return this._lastName; 
			}
			set
			{
				if (_lastName == value)
					return;
					
				this._lastName = value;
				this._isDirty = true;
				
				OnPropertyChanged("LastName");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the First Name property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String FirstName
		{
			get
			{
				return this._firstName; 
			}
			set
			{
				if (_firstName == value)
					return;
					
				this._firstName = value;
				this._isDirty = true;
				
				OnPropertyChanged("FirstName");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Created Time property. 
		///		
		/// </summary>
		/// <value>This type is datetime</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return DateTime.MinValue. It is up to the developer
		/// to check the value of IsCreatedTimeNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime? CreatedTime
		{
			get
			{
				return this._createdTime; 
			}
			set
			{
				if (_createdTime == value && CreatedTime != null )
					return;
					
				this._createdTime = value;
				this._isDirty = true;
				
				OnPropertyChanged("CreatedTime");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Last Activity Time property. 
		///		
		/// </summary>
		/// <value>This type is datetime</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return DateTime.MinValue. It is up to the developer
		/// to check the value of IsLastActivityTimeNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime? LastActivityTime
		{
			get
			{
				return this._lastActivityTime; 
			}
			set
			{
				if (_lastActivityTime == value && LastActivityTime != null )
					return;
					
				this._lastActivityTime = value;
				this._isDirty = true;
				
				OnPropertyChanged("LastActivityTime");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Last Visited Time property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String LastVisitedTime
		{
			get
			{
				return this._lastVisitedTime; 
			}
			set
			{
				if (_lastVisitedTime == value)
					return;
					
				this._lastVisitedTime = value;
				this._isDirty = true;
				
				OnPropertyChanged("LastVisitedTime");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Lead Owner property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String LeadOwner
		{
			get
			{
				return this._leadOwner; 
			}
			set
			{
				if (_leadOwner == value)
					return;
					
				this._leadOwner = value;
				this._isDirty = true;
				
				OnPropertyChanged("LeadOwner");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Lead Source property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String LeadSource
		{
			get
			{
				return this._leadSource; 
			}
			set
			{
				if (_leadSource == value)
					return;
					
				this._leadSource = value;
				this._isDirty = true;
				
				OnPropertyChanged("LeadSource");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Rating property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Rating
		{
			get
			{
				return this._rating; 
			}
			set
			{
				if (_rating == value)
					return;
					
				this._rating = value;
				this._isDirty = true;
				
				OnPropertyChanged("Rating");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Lead Status property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String LeadStatus
		{
			get
			{
				return this._leadStatus; 
			}
			set
			{
				if (_leadStatus == value)
					return;
					
				this._leadStatus = value;
				this._isDirty = true;
				
				OnPropertyChanged("LeadStatus");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Time Zone property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String TimeZone
		{
			get
			{
				return this._timeZone; 
			}
			set
			{
				if (_timeZone == value)
					return;
					
				this._timeZone = value;
				this._isDirty = true;
				
				OnPropertyChanged("TimeZone");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Call Duration (in minutes) property. 
		///		
		/// </summary>
		/// <value>This type is float</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return 0.0f. It is up to the developer
		/// to check the value of IsSafeNameCallDurationInMinutesNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Double? SafeNameCallDurationInMinutes
		{
			get
			{
				return this._safeNameCallDurationInMinutes; 
			}
			set
			{
				if (_safeNameCallDurationInMinutes == value && SafeNameCallDurationInMinutes != null )
					return;
					
				this._safeNameCallDurationInMinutes = value;
				this._isDirty = true;
				
				OnPropertyChanged("SafeNameCallDurationInMinutes");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Call Purpose property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String CallPurpose
		{
			get
			{
				return this._callPurpose; 
			}
			set
			{
				if (_callPurpose == value)
					return;
					
				this._callPurpose = value;
				this._isDirty = true;
				
				OnPropertyChanged("CallPurpose");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Call Result property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String CallResult
		{
			get
			{
				return this._callResult; 
			}
			set
			{
				if (_callResult == value)
					return;
					
				this._callResult = value;
				this._isDirty = true;
				
				OnPropertyChanged("CallResult");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Call Start Time property. 
		///		
		/// </summary>
		/// <value>This type is datetime</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return DateTime.MinValue. It is up to the developer
		/// to check the value of IsCallStartTimeNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime? CallStartTime
		{
			get
			{
				return this._callStartTime; 
			}
			set
			{
				if (_callStartTime == value && CallStartTime != null )
					return;
					
				this._callStartTime = value;
				this._isDirty = true;
				
				OnPropertyChanged("CallStartTime");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the CreatedBy property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String CreatedBy
		{
			get
			{
				return this._createdBy; 
			}
			set
			{
				if (_createdBy == value)
					return;
					
				this._createdBy = value;
				this._isDirty = true;
				
				OnPropertyChanged("CreatedBy");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Subject property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Subject
		{
			get
			{
				return this._subject; 
			}
			set
			{
				if (_subject == value)
					return;
					
				this._subject = value;
				this._isDirty = true;
				
				OnPropertyChanged("Subject");
			}
		}
		
		
		/// <summary>
		///     Gets or sets the object that contains supplemental data about this object.
		/// </summary>
		/// <value>Object</value>
		[System.ComponentModel.Bindable(false)]
		[LocalizableAttribute(false)]
		[DescriptionAttribute("Object containing data to be associated with this object")]
		public virtual object Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				if (this._tag == value)
					return;
		
				this._tag = value;
			}
		}
	
		/// <summary>
		/// Determines whether this entity is to suppress events while set to true.
		/// </summary>
		[System.ComponentModel.Bindable(false)]
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool SuppressEntityEvents
		{	
			get
			{
				return suppressEntityEvents;
			}
			set
			{
				suppressEntityEvents = value;
			}	
		}

		private bool _isDeleted = false;
		/// <summary>
		/// Gets a value indicating if object has been <see cref="MarkToDelete"/>. ReadOnly.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDeleted
		{
			get { return this._isDeleted; }
		}


		private bool _isDirty = false;
		/// <summary>
		///	Gets a value indicating  if the object has been modified from its original state.
		/// </summary>
		///<value>True if object has been modified from its original state; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDirty
		{
			get { return this._isDirty; }
		}
		

		private bool _isNew = true;
		/// <summary>
		///	Gets a value indicating if the object is new.
		/// </summary>
		///<value>True if objectis new; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsNew
		{
			get { return this._isNew; }
			set { this._isNew = value; }
		}

		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public string ViewName
		{
			get { return "vw_LeadsAndCalls"; }
		}

		
		#endregion
		
		#region Methods	
		
		/// <summary>
		/// Accepts the changes made to this object by setting each flags to false.
		/// </summary>
		public virtual void AcceptChanges()
		{
			this._isDeleted = false;
			this._isDirty = false;
			this._isNew = false;
			OnPropertyChanged(string.Empty);
		}
		
		
		///<summary>
		///  Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		/// <exception cref="NotSupportedException">This method is not currently supported and always throws this exception.</exception>
		public virtual void CancelChanges()
		{
			throw new NotSupportedException("Method currently not Supported.");
		}
		
		///<summary>
		///   Marks entity to be deleted.
		///</summary>
		public virtual void MarkToDelete()
		{
			this._isDeleted = true;
		}
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed VwLeadsAndCallsBase Entity 
		///</summary>
		public virtual VwLeadsAndCallsBase Copy()
		{
			//shallow copy entity
			VwLeadsAndCalls copy = new VwLeadsAndCalls();
				copy.Leadid = this.Leadid;
				copy.LastName = this.LastName;
				copy.FirstName = this.FirstName;
				copy.CreatedTime = this.CreatedTime;
				copy.LastActivityTime = this.LastActivityTime;
				copy.LastVisitedTime = this.LastVisitedTime;
				copy.LeadOwner = this.LeadOwner;
				copy.LeadSource = this.LeadSource;
				copy.Rating = this.Rating;
				copy.LeadStatus = this.LeadStatus;
				copy.TimeZone = this.TimeZone;
				copy.SafeNameCallDurationInMinutes = this.SafeNameCallDurationInMinutes;
				copy.CallPurpose = this.CallPurpose;
				copy.CallResult = this.CallResult;
				copy.CallStartTime = this.CallStartTime;
				copy.CreatedBy = this.CreatedBy;
				copy.Subject = this.Subject;
			copy.AcceptChanges();
			return (VwLeadsAndCalls)copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Deep Copy of this entity.
		///</summary>
		public object Clone(){
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		#endregion
		
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="VwLeadsAndCallsBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(VwLeadsAndCallsBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="VwLeadsAndCallsBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="VwLeadsAndCallsBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="VwLeadsAndCallsBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(VwLeadsAndCallsBase Object1, VwLeadsAndCallsBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.Leadid != null && Object2.Leadid != null )
			{
				if (Object1.Leadid != Object2.Leadid)
					equal = false;
			}
			else if (Object1.Leadid == null ^ Object1.Leadid == null )
			{
				equal = false;
			}
			if (Object1.LastName != null && Object2.LastName != null )
			{
				if (Object1.LastName != Object2.LastName)
					equal = false;
			}
			else if (Object1.LastName == null ^ Object1.LastName == null )
			{
				equal = false;
			}
			if (Object1.FirstName != null && Object2.FirstName != null )
			{
				if (Object1.FirstName != Object2.FirstName)
					equal = false;
			}
			else if (Object1.FirstName == null ^ Object1.FirstName == null )
			{
				equal = false;
			}
			if (Object1.CreatedTime != null && Object2.CreatedTime != null )
			{
				if (Object1.CreatedTime != Object2.CreatedTime)
					equal = false;
			}
			else if (Object1.CreatedTime == null ^ Object1.CreatedTime == null )
			{
				equal = false;
			}
			if (Object1.LastActivityTime != null && Object2.LastActivityTime != null )
			{
				if (Object1.LastActivityTime != Object2.LastActivityTime)
					equal = false;
			}
			else if (Object1.LastActivityTime == null ^ Object1.LastActivityTime == null )
			{
				equal = false;
			}
			if (Object1.LastVisitedTime != null && Object2.LastVisitedTime != null )
			{
				if (Object1.LastVisitedTime != Object2.LastVisitedTime)
					equal = false;
			}
			else if (Object1.LastVisitedTime == null ^ Object1.LastVisitedTime == null )
			{
				equal = false;
			}
			if (Object1.LeadOwner != null && Object2.LeadOwner != null )
			{
				if (Object1.LeadOwner != Object2.LeadOwner)
					equal = false;
			}
			else if (Object1.LeadOwner == null ^ Object1.LeadOwner == null )
			{
				equal = false;
			}
			if (Object1.LeadSource != null && Object2.LeadSource != null )
			{
				if (Object1.LeadSource != Object2.LeadSource)
					equal = false;
			}
			else if (Object1.LeadSource == null ^ Object1.LeadSource == null )
			{
				equal = false;
			}
			if (Object1.Rating != null && Object2.Rating != null )
			{
				if (Object1.Rating != Object2.Rating)
					equal = false;
			}
			else if (Object1.Rating == null ^ Object1.Rating == null )
			{
				equal = false;
			}
			if (Object1.LeadStatus != null && Object2.LeadStatus != null )
			{
				if (Object1.LeadStatus != Object2.LeadStatus)
					equal = false;
			}
			else if (Object1.LeadStatus == null ^ Object1.LeadStatus == null )
			{
				equal = false;
			}
			if (Object1.TimeZone != null && Object2.TimeZone != null )
			{
				if (Object1.TimeZone != Object2.TimeZone)
					equal = false;
			}
			else if (Object1.TimeZone == null ^ Object1.TimeZone == null )
			{
				equal = false;
			}
			if (Object1.SafeNameCallDurationInMinutes != null && Object2.SafeNameCallDurationInMinutes != null )
			{
				if (Object1.SafeNameCallDurationInMinutes != Object2.SafeNameCallDurationInMinutes)
					equal = false;
			}
			else if (Object1.SafeNameCallDurationInMinutes == null ^ Object1.SafeNameCallDurationInMinutes == null )
			{
				equal = false;
			}
			if (Object1.CallPurpose != null && Object2.CallPurpose != null )
			{
				if (Object1.CallPurpose != Object2.CallPurpose)
					equal = false;
			}
			else if (Object1.CallPurpose == null ^ Object1.CallPurpose == null )
			{
				equal = false;
			}
			if (Object1.CallResult != null && Object2.CallResult != null )
			{
				if (Object1.CallResult != Object2.CallResult)
					equal = false;
			}
			else if (Object1.CallResult == null ^ Object1.CallResult == null )
			{
				equal = false;
			}
			if (Object1.CallStartTime != null && Object2.CallStartTime != null )
			{
				if (Object1.CallStartTime != Object2.CallStartTime)
					equal = false;
			}
			else if (Object1.CallStartTime == null ^ Object1.CallStartTime == null )
			{
				equal = false;
			}
			if (Object1.CreatedBy != null && Object2.CreatedBy != null )
			{
				if (Object1.CreatedBy != Object2.CreatedBy)
					equal = false;
			}
			else if (Object1.CreatedBy == null ^ Object1.CreatedBy == null )
			{
				equal = false;
			}
			if (Object1.Subject != null && Object2.Subject != null )
			{
				if (Object1.Subject != Object2.Subject)
					equal = false;
			}
			else if (Object1.Subject == null ^ Object1.Subject == null )
			{
				equal = false;
			}
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}
	
		#endregion
		
		#region INotifyPropertyChanged Members
		
		/// <summary>
      /// Event to indicate that a property has changed.
      /// </summary>
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="propertyName">The name of the property that has changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{ 
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="e">PropertyChangedEventArgs</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (!SuppressEntityEvents)
			{
				if (null != PropertyChanged)
				{
					PropertyChanged(this, e);
				}
			}
		}
		
		#endregion
				
		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static object GetPropertyValueByName(VwLeadsAndCalls entity, string propertyName)
		{
			switch (propertyName)
			{
				case "Leadid":
					return entity.Leadid;
				case "LastName":
					return entity.LastName;
				case "FirstName":
					return entity.FirstName;
				case "CreatedTime":
					return entity.CreatedTime;
				case "LastActivityTime":
					return entity.LastActivityTime;
				case "LastVisitedTime":
					return entity.LastVisitedTime;
				case "LeadOwner":
					return entity.LeadOwner;
				case "LeadSource":
					return entity.LeadSource;
				case "Rating":
					return entity.Rating;
				case "LeadStatus":
					return entity.LeadStatus;
				case "TimeZone":
					return entity.TimeZone;
				case "SafeNameCallDurationInMinutes":
					return entity.SafeNameCallDurationInMinutes;
				case "CallPurpose":
					return entity.CallPurpose;
				case "CallResult":
					return entity.CallResult;
				case "CallStartTime":
					return entity.CallStartTime;
				case "CreatedBy":
					return entity.CreatedBy;
				case "Subject":
					return entity.Subject;
			}
			return null;
		}
				
		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public object GetPropertyValueByName(string propertyName)
		{			
			return GetPropertyValueByName(this as VwLeadsAndCalls, propertyName);
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{18}{17}- Leadid: {0}{17}- LastName: {1}{17}- FirstName: {2}{17}- CreatedTime: {3}{17}- LastActivityTime: {4}{17}- LastVisitedTime: {5}{17}- LeadOwner: {6}{17}- LeadSource: {7}{17}- Rating: {8}{17}- LeadStatus: {9}{17}- TimeZone: {10}{17}- SafeNameCallDurationInMinutes: {11}{17}- CallPurpose: {12}{17}- CallResult: {13}{17}- CallStartTime: {14}{17}- CreatedBy: {15}{17}- Subject: {16}{17}", 
				(this.Leadid == null) ? string.Empty : this.Leadid.ToString(),
			     
				(this.LastName == null) ? string.Empty : this.LastName.ToString(),
			     
				(this.FirstName == null) ? string.Empty : this.FirstName.ToString(),
			     
				(this.CreatedTime == null) ? string.Empty : this.CreatedTime.ToString(),
			     
				(this.LastActivityTime == null) ? string.Empty : this.LastActivityTime.ToString(),
			     
				(this.LastVisitedTime == null) ? string.Empty : this.LastVisitedTime.ToString(),
			     
				(this.LeadOwner == null) ? string.Empty : this.LeadOwner.ToString(),
			     
				(this.LeadSource == null) ? string.Empty : this.LeadSource.ToString(),
			     
				(this.Rating == null) ? string.Empty : this.Rating.ToString(),
			     
				(this.LeadStatus == null) ? string.Empty : this.LeadStatus.ToString(),
			     
				(this.TimeZone == null) ? string.Empty : this.TimeZone.ToString(),
			     
				(this.SafeNameCallDurationInMinutes == null) ? string.Empty : this.SafeNameCallDurationInMinutes.ToString(),
			     
				(this.CallPurpose == null) ? string.Empty : this.CallPurpose.ToString(),
			     
				(this.CallResult == null) ? string.Empty : this.CallResult.ToString(),
			     
				(this.CallStartTime == null) ? string.Empty : this.CallStartTime.ToString(),
			     
				(this.CreatedBy == null) ? string.Empty : this.CreatedBy.ToString(),
			     
				(this.Subject == null) ? string.Empty : this.Subject.ToString(),
			     
				System.Environment.NewLine, 
				this.GetType());
		}
	
	}//End Class
	
	
	/// <summary>
	/// Enumerate the VwLeadsAndCalls columns.
	/// </summary>
	[Serializable]
	public enum VwLeadsAndCallsColumn
	{
		/// <summary>
		/// LEADID : 
		/// </summary>
		[EnumTextValue("LEADID")]
		[ColumnEnum("LEADID", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		Leadid,
		/// <summary>
		/// Last Name : 
		/// </summary>
		[EnumTextValue("Last Name")]
		[ColumnEnum("Last Name", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		LastName,
		/// <summary>
		/// First Name : 
		/// </summary>
		[EnumTextValue("First Name")]
		[ColumnEnum("First Name", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		FirstName,
		/// <summary>
		/// Created Time : 
		/// </summary>
		[EnumTextValue("Created Time")]
		[ColumnEnum("Created Time", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, true)]
		CreatedTime,
		/// <summary>
		/// Last Activity Time : 
		/// </summary>
		[EnumTextValue("Last Activity Time")]
		[ColumnEnum("Last Activity Time", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, true)]
		LastActivityTime,
		/// <summary>
		/// Last Visited Time : 
		/// </summary>
		[EnumTextValue("Last Visited Time")]
		[ColumnEnum("Last Visited Time", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		LastVisitedTime,
		/// <summary>
		/// Lead Owner : 
		/// </summary>
		[EnumTextValue("Lead Owner")]
		[ColumnEnum("Lead Owner", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		LeadOwner,
		/// <summary>
		/// Lead Source : 
		/// </summary>
		[EnumTextValue("Lead Source")]
		[ColumnEnum("Lead Source", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		LeadSource,
		/// <summary>
		/// Rating : 
		/// </summary>
		[EnumTextValue("Rating")]
		[ColumnEnum("Rating", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		Rating,
		/// <summary>
		/// Lead Status : 
		/// </summary>
		[EnumTextValue("Lead Status")]
		[ColumnEnum("Lead Status", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		LeadStatus,
		/// <summary>
		/// Time Zone : 
		/// </summary>
		[EnumTextValue("Time Zone")]
		[ColumnEnum("Time Zone", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		TimeZone,
		/// <summary>
		/// Call Duration (in minutes) : 
		/// </summary>
		[EnumTextValue("Call Duration (in minutes)")]
		[ColumnEnum("Call Duration (in minutes)", typeof(System.Double), System.Data.DbType.Double, false, false, true)]
		SafeNameCallDurationInMinutes,
		/// <summary>
		/// Call Purpose : 
		/// </summary>
		[EnumTextValue("Call Purpose")]
		[ColumnEnum("Call Purpose", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		CallPurpose,
		/// <summary>
		/// Call Result : 
		/// </summary>
		[EnumTextValue("Call Result")]
		[ColumnEnum("Call Result", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		CallResult,
		/// <summary>
		/// Call Start Time : 
		/// </summary>
		[EnumTextValue("Call Start Time")]
		[ColumnEnum("Call Start Time", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, true)]
		CallStartTime,
		/// <summary>
		/// CreatedBy : 
		/// </summary>
		[EnumTextValue("CreatedBy")]
		[ColumnEnum("CreatedBy", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		CreatedBy,
		/// <summary>
		/// Subject : 
		/// </summary>
		[EnumTextValue("Subject")]
		[ColumnEnum("Subject", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		Subject
	}//End enum

} // end namespace
