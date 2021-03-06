﻿/*
	File generated by NetTiers templates [www.nettiers.net]
	Generated on : Thursday, May 12, 2016
	Important: Do not modify this file. Edit the file VwManualReturnsList.cs instead.
*/
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;
#endregion

namespace SiH_SalesWorkflow.Entities
{
	///<summary>
	/// An object representation of the 'vw_MANUAL_ReturnsList' view. [No description found in the database]	
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("VwManualReturnsListBase")]
	public abstract partial class VwManualReturnsListBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{
		
		#region Variable Declarations
		
		/// <summary>
		/// LEADID : 
		/// </summary>
		private System.String		  _leadid = null;
		
		/// <summary>
		/// First Name : 
		/// </summary>
		private System.String		  _firstName = null;
		
		/// <summary>
		/// Last Name : 
		/// </summary>
		private System.String		  _lastName = null;
		
		/// <summary>
		/// Lead Status : 
		/// </summary>
		private System.String		  _leadStatus = null;
		
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
		/// Creates a new <see cref="VwManualReturnsListBase"/> instance.
		///</summary>
		public VwManualReturnsListBase()
		{
		}		
		
		///<summary>
		/// Creates a new <see cref="VwManualReturnsListBase"/> instance.
		///</summary>
		///<param name="_leadid"></param>
		///<param name="_firstName"></param>
		///<param name="_lastName"></param>
		///<param name="_leadStatus"></param>
		public VwManualReturnsListBase(System.String _leadid, System.String _firstName, System.String _lastName, System.String _leadStatus)
		{
			this._leadid = _leadid;
			this._firstName = _firstName;
			this._lastName = _lastName;
			this._leadStatus = _leadStatus;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="VwManualReturnsList"/> instance.
		///</summary>
		///<param name="_leadid"></param>
		///<param name="_firstName"></param>
		///<param name="_lastName"></param>
		///<param name="_leadStatus"></param>
		public static VwManualReturnsList CreateVwManualReturnsList(System.String _leadid, System.String _firstName, System.String _lastName, System.String _leadStatus)
		{
			VwManualReturnsList newVwManualReturnsList = new VwManualReturnsList();
			newVwManualReturnsList.Leadid = _leadid;
			newVwManualReturnsList.FirstName = _firstName;
			newVwManualReturnsList.LastName = _lastName;
			newVwManualReturnsList.LeadStatus = _leadStatus;
			return newVwManualReturnsList;
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
			get { return "vw_MANUAL_ReturnsList"; }
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
		///  Returns a Typed VwManualReturnsListBase Entity 
		///</summary>
		public virtual VwManualReturnsListBase Copy()
		{
			//shallow copy entity
			VwManualReturnsList copy = new VwManualReturnsList();
				copy.Leadid = this.Leadid;
				copy.FirstName = this.FirstName;
				copy.LastName = this.LastName;
				copy.LeadStatus = this.LeadStatus;
			copy.AcceptChanges();
			return (VwManualReturnsList)copy;
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
		///<returns>true if toObject is a <see cref="VwManualReturnsListBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(VwManualReturnsListBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="VwManualReturnsListBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="VwManualReturnsListBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="VwManualReturnsListBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(VwManualReturnsListBase Object1, VwManualReturnsListBase Object2)
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
			if (Object1.FirstName != null && Object2.FirstName != null )
			{
				if (Object1.FirstName != Object2.FirstName)
					equal = false;
			}
			else if (Object1.FirstName == null ^ Object1.FirstName == null )
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
			if (Object1.LeadStatus != null && Object2.LeadStatus != null )
			{
				if (Object1.LeadStatus != Object2.LeadStatus)
					equal = false;
			}
			else if (Object1.LeadStatus == null ^ Object1.LeadStatus == null )
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
		public static object GetPropertyValueByName(VwManualReturnsList entity, string propertyName)
		{
			switch (propertyName)
			{
				case "Leadid":
					return entity.Leadid;
				case "FirstName":
					return entity.FirstName;
				case "LastName":
					return entity.LastName;
				case "LeadStatus":
					return entity.LeadStatus;
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
			return GetPropertyValueByName(this as VwManualReturnsList, propertyName);
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{5}{4}- Leadid: {0}{4}- FirstName: {1}{4}- LastName: {2}{4}- LeadStatus: {3}{4}", 
				(this.Leadid == null) ? string.Empty : this.Leadid.ToString(),
			     
				(this.FirstName == null) ? string.Empty : this.FirstName.ToString(),
			     
				(this.LastName == null) ? string.Empty : this.LastName.ToString(),
			     
				(this.LeadStatus == null) ? string.Empty : this.LeadStatus.ToString(),
			     
				System.Environment.NewLine, 
				this.GetType());
		}
	
	}//End Class
	
	
	/// <summary>
	/// Enumerate the VwManualReturnsList columns.
	/// </summary>
	[Serializable]
	public enum VwManualReturnsListColumn
	{
		/// <summary>
		/// LEADID : 
		/// </summary>
		[EnumTextValue("LEADID")]
		[ColumnEnum("LEADID", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		Leadid,
		/// <summary>
		/// First Name : 
		/// </summary>
		[EnumTextValue("First Name")]
		[ColumnEnum("First Name", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		FirstName,
		/// <summary>
		/// Last Name : 
		/// </summary>
		[EnumTextValue("Last Name")]
		[ColumnEnum("Last Name", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		LastName,
		/// <summary>
		/// Lead Status : 
		/// </summary>
		[EnumTextValue("Lead Status")]
		[ColumnEnum("Lead Status", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		LeadStatus
	}//End enum

} // end namespace
