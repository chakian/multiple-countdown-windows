﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Business
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MultipleCountdown")]
	public partial class MCDbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertMC_Countdown(MC_Countdown instance);
    partial void UpdateMC_Countdown(MC_Countdown instance);
    partial void DeleteMC_Countdown(MC_Countdown instance);
    partial void InsertMC_User(MC_User instance);
    partial void UpdateMC_User(MC_User instance);
    partial void DeleteMC_User(MC_User instance);
    #endregion
		
		public MCDbDataContext() : 
				base(global::Business.Properties.Settings.Default.MultipleCountdownConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MCDbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MCDbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MCDbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MCDbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<MC_Countdown> MC_Countdowns
		{
			get
			{
				return this.GetTable<MC_Countdown>();
			}
		}
		
		public System.Data.Linq.Table<MC_User> MC_Users
		{
			get
			{
				return this.GetTable<MC_User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MC_Countdown")]
	public partial class MC_Countdown : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private int _UserID;
		
		private string _Title;
		
		private System.DateTime _EndTime;
		
		private System.DateTime _CreateTime;
		
		private System.DateTime _UpdateTime;
		
		private bool _IsInProgress;
		
		private bool _IsDeleted;
		
		private EntityRef<MC_User> _MC_User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnEndTimeChanging(System.DateTime value);
    partial void OnEndTimeChanged();
    partial void OnCreateTimeChanging(System.DateTime value);
    partial void OnCreateTimeChanged();
    partial void OnUpdateTimeChanging(System.DateTime value);
    partial void OnUpdateTimeChanged();
    partial void OnIsInProgressChanging(bool value);
    partial void OnIsInProgressChanged();
    partial void OnIsDeletedChanging(bool value);
    partial void OnIsDeletedChanged();
    #endregion
		
		public MC_Countdown()
		{
			this._MC_User = default(EntityRef<MC_User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL")]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					if (this._MC_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(150)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndTime", DbType="DateTime NOT NULL")]
		public System.DateTime EndTime
		{
			get
			{
				return this._EndTime;
			}
			set
			{
				if ((this._EndTime != value))
				{
					this.OnEndTimeChanging(value);
					this.SendPropertyChanging();
					this._EndTime = value;
					this.SendPropertyChanged("EndTime");
					this.OnEndTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateTime", DbType="DateTime NOT NULL")]
		public System.DateTime CreateTime
		{
			get
			{
				return this._CreateTime;
			}
			set
			{
				if ((this._CreateTime != value))
				{
					this.OnCreateTimeChanging(value);
					this.SendPropertyChanging();
					this._CreateTime = value;
					this.SendPropertyChanged("CreateTime");
					this.OnCreateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UpdateTime", DbType="DateTime NOT NULL")]
		public System.DateTime UpdateTime
		{
			get
			{
				return this._UpdateTime;
			}
			set
			{
				if ((this._UpdateTime != value))
				{
					this.OnUpdateTimeChanging(value);
					this.SendPropertyChanging();
					this._UpdateTime = value;
					this.SendPropertyChanged("UpdateTime");
					this.OnUpdateTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsInProgress", DbType="Bit NOT NULL")]
		public bool IsInProgress
		{
			get
			{
				return this._IsInProgress;
			}
			set
			{
				if ((this._IsInProgress != value))
				{
					this.OnIsInProgressChanging(value);
					this.SendPropertyChanging();
					this._IsInProgress = value;
					this.SendPropertyChanged("IsInProgress");
					this.OnIsInProgressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDeleted", DbType="Bit NOT NULL")]
		public bool IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				if ((this._IsDeleted != value))
				{
					this.OnIsDeletedChanging(value);
					this.SendPropertyChanging();
					this._IsDeleted = value;
					this.SendPropertyChanged("IsDeleted");
					this.OnIsDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="MC_User_MC_Countdown", Storage="_MC_User", ThisKey="UserID", OtherKey="ID", IsForeignKey=true)]
		public MC_User MC_User
		{
			get
			{
				return this._MC_User.Entity;
			}
			set
			{
				MC_User previousValue = this._MC_User.Entity;
				if (((previousValue != value) 
							|| (this._MC_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._MC_User.Entity = null;
						previousValue.MC_Countdowns.Remove(this);
					}
					this._MC_User.Entity = value;
					if ((value != null))
					{
						value.MC_Countdowns.Add(this);
						this._UserID = value.ID;
					}
					else
					{
						this._UserID = default(int);
					}
					this.SendPropertyChanged("MC_User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MC_User")]
	public partial class MC_User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Username;
		
		private string _Password;
		
		private string _Email;
		
		private EntitySet<MC_Countdown> _MC_Countdowns;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public MC_User()
		{
			this._MC_Countdowns = new EntitySet<MC_Countdown>(new Action<MC_Countdown>(this.attach_MC_Countdowns), new Action<MC_Countdown>(this.detach_MC_Countdowns));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="MC_User_MC_Countdown", Storage="_MC_Countdowns", ThisKey="ID", OtherKey="UserID")]
		public EntitySet<MC_Countdown> MC_Countdowns
		{
			get
			{
				return this._MC_Countdowns;
			}
			set
			{
				this._MC_Countdowns.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_MC_Countdowns(MC_Countdown entity)
		{
			this.SendPropertyChanging();
			entity.MC_User = this;
		}
		
		private void detach_MC_Countdowns(MC_Countdown entity)
		{
			this.SendPropertyChanging();
			entity.MC_User = null;
		}
	}
}
#pragma warning restore 1591
