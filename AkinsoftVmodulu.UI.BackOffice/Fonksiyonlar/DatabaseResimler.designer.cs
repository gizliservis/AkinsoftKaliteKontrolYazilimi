﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AkinsoftVmodulu.UI.BackOffice.Fonksiyonlar
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="WOLVOX8_DOSYA")]
	public partial class DatabaseResimlerDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDOSYA(DOSYA instance);
    partial void UpdateDOSYA(DOSYA instance);
    partial void DeleteDOSYA(DOSYA instance);
    #endregion
		
		public DatabaseResimlerDataContext() : 
				base(global::AkinsoftVmodulu.UI.BackOffice.Properties.Settings.Default.D__AKINSOFT_WOLVOX8_DOSYAConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseResimlerDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseResimlerDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseResimlerDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseResimlerDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DOSYA> DOSYA
		{
			get
			{
				return this.GetTable<DOSYA>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DOSYA")]
	public partial class DOSYA : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _BLKODU;
		
		private string _BAGKODU;
		
		private string _DOSYAADI;
		
		private string _ACIKLAMA;
		
		private System.Data.Linq.Binary _FILEDATA;
		
		private string _OZELKODU;
		
		private System.Nullable<short> _WEBDE_GORUNSUN;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBLKODUChanging(long value);
    partial void OnBLKODUChanged();
    partial void OnBAGKODUChanging(string value);
    partial void OnBAGKODUChanged();
    partial void OnDOSYAADIChanging(string value);
    partial void OnDOSYAADIChanged();
    partial void OnACIKLAMAChanging(string value);
    partial void OnACIKLAMAChanged();
    partial void OnFILEDATAChanging(System.Data.Linq.Binary value);
    partial void OnFILEDATAChanged();
    partial void OnOZELKODUChanging(string value);
    partial void OnOZELKODUChanged();
    partial void OnWEBDE_GORUNSUNChanging(System.Nullable<short> value);
    partial void OnWEBDE_GORUNSUNChanged();
    #endregion
		
		public DOSYA()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BLKODU", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long BLKODU
		{
			get
			{
				return this._BLKODU;
			}
			set
			{
				if ((this._BLKODU != value))
				{
					this.OnBLKODUChanging(value);
					this.SendPropertyChanging();
					this._BLKODU = value;
					this.SendPropertyChanged("BLKODU");
					this.OnBLKODUChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BAGKODU", DbType="VarChar(30)")]
		public string BAGKODU
		{
			get
			{
				return this._BAGKODU;
			}
			set
			{
				if ((this._BAGKODU != value))
				{
					this.OnBAGKODUChanging(value);
					this.SendPropertyChanging();
					this._BAGKODU = value;
					this.SendPropertyChanged("BAGKODU");
					this.OnBAGKODUChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DOSYAADI", DbType="VarChar(75)")]
		public string DOSYAADI
		{
			get
			{
				return this._DOSYAADI;
			}
			set
			{
				if ((this._DOSYAADI != value))
				{
					this.OnDOSYAADIChanging(value);
					this.SendPropertyChanging();
					this._DOSYAADI = value;
					this.SendPropertyChanged("DOSYAADI");
					this.OnDOSYAADIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ACIKLAMA", DbType="VarChar(100)")]
		public string ACIKLAMA
		{
			get
			{
				return this._ACIKLAMA;
			}
			set
			{
				if ((this._ACIKLAMA != value))
				{
					this.OnACIKLAMAChanging(value);
					this.SendPropertyChanging();
					this._ACIKLAMA = value;
					this.SendPropertyChanged("ACIKLAMA");
					this.OnACIKLAMAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FILEDATA", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary FILEDATA
		{
			get
			{
				return this._FILEDATA;
			}
			set
			{
				if ((this._FILEDATA != value))
				{
					this.OnFILEDATAChanging(value);
					this.SendPropertyChanging();
					this._FILEDATA = value;
					this.SendPropertyChanged("FILEDATA");
					this.OnFILEDATAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OZELKODU", DbType="VarChar(30)")]
		public string OZELKODU
		{
			get
			{
				return this._OZELKODU;
			}
			set
			{
				if ((this._OZELKODU != value))
				{
					this.OnOZELKODUChanging(value);
					this.SendPropertyChanging();
					this._OZELKODU = value;
					this.SendPropertyChanged("OZELKODU");
					this.OnOZELKODUChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WEBDE_GORUNSUN", DbType="SmallInt")]
		public System.Nullable<short> WEBDE_GORUNSUN
		{
			get
			{
				return this._WEBDE_GORUNSUN;
			}
			set
			{
				if ((this._WEBDE_GORUNSUN != value))
				{
					this.OnWEBDE_GORUNSUNChanging(value);
					this.SendPropertyChanging();
					this._WEBDE_GORUNSUN = value;
					this.SendPropertyChanged("WEBDE_GORUNSUN");
					this.OnWEBDE_GORUNSUNChanged();
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
}
#pragma warning restore 1591