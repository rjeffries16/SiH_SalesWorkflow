﻿/*
	File generated by NetTiers templates [www.nettiers.net]
	Generated on : Thursday, May 12, 2016
	Important: Do not modify this file. Edit the file VwZohoCalls.cs instead.
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
	/// An object representation of the 'vw_ZohoCalls' view. [No description found in the database]	
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("VwZohoCallsBase")]
	public abstract partial class VwZohoCallsBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{
		
		#region Variable Declarations
		
		/// <summary>
		/// TASKID : 
		/// </summary>
		private System.String		  _taskid = null;
		
		/// <summary>
		/// CallPK : 
		/// </summary>
		private System.Int64		  _callPk = (long)0;
		
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
		/// Creates a new <see cref="VwZohoCallsBase"/> instance.
		///</summary>
		public VwZohoCallsBase()
		{
		}		
		
		///<summary>
		/// Creates a new <see cref="VwZohoCallsBase"/> instance.
		///</summary>
		///<param name="_taskid"></param>
		///<param name="_callPk"></param>
		public VwZohoCallsBase(System.String _taskid, System.Int64 _callPk)
		{
			this._taskid = _taskid;
			this._callPk = _callPk;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="VwZohoCalls"/> instance.
		///</summary>
		///<param name="_taskid"></param>
		///<param name="_callPk"></param>
		public static VwZohoCalls CreateVwZohoCalls(System.String _taskid, System.Int64 _callPk)
		{
			VwZohoCalls newVwZohoCalls = new VwZohoCalls();
			newVwZohoCalls.Taskid = _taskid;
			newVwZohoCalls.CallPk = _callPk;
			return newVwZohoCalls;
		}
				
		#endregion Constructors
		
		#region Properties	
		/// <summary>
		/// 	Gets or Sets the TASKID property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Taskid
		{
			get
			{
				return this._taskid; 
			}
			set
			{
				if (_taskid == value)
					return;
					
				this._taskid = value;
				this._isDirty = true;
				
				OnPropertyChanged("Taskid");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the CallPK property. 
		///		
		/// </summary>
		/// <value>This type is bigint</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int64 CallPk
		{
			get
			{
				return this._callPk; 
			}
			set
			{
				if (_callPk == value)
					return;
					
				this._callPk = value;
				this._isDirty = true;
				
				OnPropertyChanged("CallPk");
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
			get { return "vw_ZohoCalls"; }
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
		///  Returns a Typed VwZohoCallsBase Entity 
		///</summary>
		public virtual VwZohoCallsBase Copy()
		{
			//shallow copy entity
			VwZohoCalls copy = new VwZohoCalls();
				copy.Taskid = this.Taskid;
				copy.CallPk = this.CallPk;
			copy.AcceptChanges();
			return (VwZohoCalls)copy;
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
		///<returns>true if toObject is a <see cref="VwZohoCallsBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(VwZohoCallsBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="VwZohoCallsBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="VwZohoCallsBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="VwZohoCallsBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(VwZohoCallsBase Object1, VwZohoCallsBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.Taskid != null && Object2.Taskid != null )
			{
				if (Object1.Taskid != Object2.Taskid)
					equal = false;
			}
			else if (Object1.Taskid == null ^ Object1.Taskid == null )
			{
				equal = false;
			}
			if (Object1.CallPk != Object2.CallPk)
				equal = false;
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
		public static object GetPropertyValueByName(VwZohoCalls entity, string propertyName)
		{
			switch (propertyName)
			{
				case "Taskid":
					return entity.Taskid;
				case "CallPk":
					return entity.CallPk;
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
			return GetPropertyValueByName(this as VwZohoCalls, propertyName);
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{3}{2}- Taskid: {0}{2}- CallPk: {1}{2}", 
				(this.Taskid == null) ? string.Empty : this.Taskid.ToString(),
			     
				this.CallPk,
				System.Environment.NewLine, 
				this.GetType());
		}
	
	}//End Class
	
	
	/// <summary>
	/// Enumerate the VwZohoCalls columns.
	/// </summary>
	[Serializable]
	public enum VwZohoCallsColumn
	{
		/// <summary>
		/// TASKID : 
		/// </summary>
		[EnumTextValue("TASKID")]
		[ColumnEnum("TASKID", typeof(System.String), System.Data.DbType.String, false, false, true, 255)]
		Taskid,
		/// <summary>
		/// CallPK : 
		/// </summary>
		[EnumTextValue("CallPK")]
		[ColumnEnum("CallPK", typeof(System.Int64), System.Data.DbType.Int64, false, false, false)]
		CallPk
	}//End enum

} // end namespace
