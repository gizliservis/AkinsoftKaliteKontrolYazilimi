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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="WOLVOX8_SIRKET")]
	public partial class DatabaseKullaniciDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPERSONEL(PERSONEL instance);
    partial void UpdatePERSONEL(PERSONEL instance);
    partial void DeletePERSONEL(PERSONEL instance);
    #endregion
		
		public DatabaseKullaniciDataContext() : 
				base(global::AkinsoftVmodulu.UI.BackOffice.Properties.Settings.Default.WOLVOX8_SIRKETConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseKullaniciDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseKullaniciDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseKullaniciDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseKullaniciDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<PERSONEL> PERSONEL
		{
			get
			{
				return this.GetTable<PERSONEL>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PERSONEL")]
	public partial class PERSONEL : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _BLKODU;
		
		private string _OZEL_KODU;
		
		private string _ADI;
		
		private string _SOYADI;
		
		private string _BABA_ADI;
		
		private string _DOGUM_YERI;
		
		private System.Nullable<System.DateTime> _DOGUM_TARIHI;
		
		private string _SICIL_NO;
		
		private string _TELEFONU;
		
		private string _CEP_TEL;
		
		private string _E_MAIL;
		
		private string _USERNAME;
		
		private string _USERPWD;
		
		private string _BANKA_ADI;
		
		private string _BANKA_NO;
		
		private string _ADRESI;
		
		private string _ACIKLAMA1;
		
		private string _ACIKLAMA2;
		
		private string _ACIKLAMA3;
		
		private System.Nullable<short> _AKTIF;
		
		private string _TERMINALLER;
		
		private string _DAHILI;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBLKODUChanging(long value);
    partial void OnBLKODUChanged();
    partial void OnOZEL_KODUChanging(string value);
    partial void OnOZEL_KODUChanged();
    partial void OnADIChanging(string value);
    partial void OnADIChanged();
    partial void OnSOYADIChanging(string value);
    partial void OnSOYADIChanged();
    partial void OnBABA_ADIChanging(string value);
    partial void OnBABA_ADIChanged();
    partial void OnDOGUM_YERIChanging(string value);
    partial void OnDOGUM_YERIChanged();
    partial void OnDOGUM_TARIHIChanging(System.Nullable<System.DateTime> value);
    partial void OnDOGUM_TARIHIChanged();
    partial void OnSICIL_NOChanging(string value);
    partial void OnSICIL_NOChanged();
    partial void OnTELEFONUChanging(string value);
    partial void OnTELEFONUChanged();
    partial void OnCEP_TELChanging(string value);
    partial void OnCEP_TELChanged();
    partial void OnE_MAILChanging(string value);
    partial void OnE_MAILChanged();
    partial void OnUSERNAMEChanging(string value);
    partial void OnUSERNAMEChanged();
    partial void OnUSERPWDChanging(string value);
    partial void OnUSERPWDChanged();
    partial void OnBANKA_ADIChanging(string value);
    partial void OnBANKA_ADIChanged();
    partial void OnBANKA_NOChanging(string value);
    partial void OnBANKA_NOChanged();
    partial void OnADRESIChanging(string value);
    partial void OnADRESIChanged();
    partial void OnACIKLAMA1Changing(string value);
    partial void OnACIKLAMA1Changed();
    partial void OnACIKLAMA2Changing(string value);
    partial void OnACIKLAMA2Changed();
    partial void OnACIKLAMA3Changing(string value);
    partial void OnACIKLAMA3Changed();
    partial void OnAKTIFChanging(System.Nullable<short> value);
    partial void OnAKTIFChanged();
    partial void OnTERMINALLERChanging(string value);
    partial void OnTERMINALLERChanged();
    partial void OnDAHILIChanging(string value);
    partial void OnDAHILIChanged();
    #endregion
		
		public PERSONEL()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OZEL_KODU", DbType="VarChar(20)")]
		public string OZEL_KODU
		{
			get
			{
				return this._OZEL_KODU;
			}
			set
			{
				if ((this._OZEL_KODU != value))
				{
					this.OnOZEL_KODUChanging(value);
					this.SendPropertyChanging();
					this._OZEL_KODU = value;
					this.SendPropertyChanged("OZEL_KODU");
					this.OnOZEL_KODUChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADI", DbType="VarChar(50)")]
		public string ADI
		{
			get
			{
				return this._ADI;
			}
			set
			{
				if ((this._ADI != value))
				{
					this.OnADIChanging(value);
					this.SendPropertyChanging();
					this._ADI = value;
					this.SendPropertyChanged("ADI");
					this.OnADIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SOYADI", DbType="VarChar(50)")]
		public string SOYADI
		{
			get
			{
				return this._SOYADI;
			}
			set
			{
				if ((this._SOYADI != value))
				{
					this.OnSOYADIChanging(value);
					this.SendPropertyChanging();
					this._SOYADI = value;
					this.SendPropertyChanged("SOYADI");
					this.OnSOYADIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BABA_ADI", DbType="VarChar(20)")]
		public string BABA_ADI
		{
			get
			{
				return this._BABA_ADI;
			}
			set
			{
				if ((this._BABA_ADI != value))
				{
					this.OnBABA_ADIChanging(value);
					this.SendPropertyChanging();
					this._BABA_ADI = value;
					this.SendPropertyChanged("BABA_ADI");
					this.OnBABA_ADIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DOGUM_YERI", DbType="VarChar(20)")]
		public string DOGUM_YERI
		{
			get
			{
				return this._DOGUM_YERI;
			}
			set
			{
				if ((this._DOGUM_YERI != value))
				{
					this.OnDOGUM_YERIChanging(value);
					this.SendPropertyChanging();
					this._DOGUM_YERI = value;
					this.SendPropertyChanged("DOGUM_YERI");
					this.OnDOGUM_YERIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DOGUM_TARIHI", DbType="DateTime")]
		public System.Nullable<System.DateTime> DOGUM_TARIHI
		{
			get
			{
				return this._DOGUM_TARIHI;
			}
			set
			{
				if ((this._DOGUM_TARIHI != value))
				{
					this.OnDOGUM_TARIHIChanging(value);
					this.SendPropertyChanging();
					this._DOGUM_TARIHI = value;
					this.SendPropertyChanged("DOGUM_TARIHI");
					this.OnDOGUM_TARIHIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SICIL_NO", DbType="VarChar(20)")]
		public string SICIL_NO
		{
			get
			{
				return this._SICIL_NO;
			}
			set
			{
				if ((this._SICIL_NO != value))
				{
					this.OnSICIL_NOChanging(value);
					this.SendPropertyChanging();
					this._SICIL_NO = value;
					this.SendPropertyChanged("SICIL_NO");
					this.OnSICIL_NOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TELEFONU", DbType="VarChar(20)")]
		public string TELEFONU
		{
			get
			{
				return this._TELEFONU;
			}
			set
			{
				if ((this._TELEFONU != value))
				{
					this.OnTELEFONUChanging(value);
					this.SendPropertyChanging();
					this._TELEFONU = value;
					this.SendPropertyChanged("TELEFONU");
					this.OnTELEFONUChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CEP_TEL", DbType="VarChar(20)")]
		public string CEP_TEL
		{
			get
			{
				return this._CEP_TEL;
			}
			set
			{
				if ((this._CEP_TEL != value))
				{
					this.OnCEP_TELChanging(value);
					this.SendPropertyChanging();
					this._CEP_TEL = value;
					this.SendPropertyChanged("CEP_TEL");
					this.OnCEP_TELChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_E_MAIL", DbType="VarChar(60)")]
		public string E_MAIL
		{
			get
			{
				return this._E_MAIL;
			}
			set
			{
				if ((this._E_MAIL != value))
				{
					this.OnE_MAILChanging(value);
					this.SendPropertyChanging();
					this._E_MAIL = value;
					this.SendPropertyChanged("E_MAIL");
					this.OnE_MAILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USERNAME", DbType="VarChar(20)")]
		public string USERNAME
		{
			get
			{
				return this._USERNAME;
			}
			set
			{
				if ((this._USERNAME != value))
				{
					this.OnUSERNAMEChanging(value);
					this.SendPropertyChanging();
					this._USERNAME = value;
					this.SendPropertyChanged("USERNAME");
					this.OnUSERNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USERPWD", DbType="VarChar(32)")]
		public string USERPWD
		{
			get
			{
				return this._USERPWD;
			}
			set
			{
				if ((this._USERPWD != value))
				{
					this.OnUSERPWDChanging(value);
					this.SendPropertyChanging();
					this._USERPWD = value;
					this.SendPropertyChanged("USERPWD");
					this.OnUSERPWDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BANKA_ADI", DbType="VarChar(40)")]
		public string BANKA_ADI
		{
			get
			{
				return this._BANKA_ADI;
			}
			set
			{
				if ((this._BANKA_ADI != value))
				{
					this.OnBANKA_ADIChanging(value);
					this.SendPropertyChanging();
					this._BANKA_ADI = value;
					this.SendPropertyChanged("BANKA_ADI");
					this.OnBANKA_ADIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BANKA_NO", DbType="VarChar(20)")]
		public string BANKA_NO
		{
			get
			{
				return this._BANKA_NO;
			}
			set
			{
				if ((this._BANKA_NO != value))
				{
					this.OnBANKA_NOChanging(value);
					this.SendPropertyChanging();
					this._BANKA_NO = value;
					this.SendPropertyChanged("BANKA_NO");
					this.OnBANKA_NOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ADRESI", DbType="VarChar(120)")]
		public string ADRESI
		{
			get
			{
				return this._ADRESI;
			}
			set
			{
				if ((this._ADRESI != value))
				{
					this.OnADRESIChanging(value);
					this.SendPropertyChanging();
					this._ADRESI = value;
					this.SendPropertyChanged("ADRESI");
					this.OnADRESIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ACIKLAMA1", DbType="VarChar(60)")]
		public string ACIKLAMA1
		{
			get
			{
				return this._ACIKLAMA1;
			}
			set
			{
				if ((this._ACIKLAMA1 != value))
				{
					this.OnACIKLAMA1Changing(value);
					this.SendPropertyChanging();
					this._ACIKLAMA1 = value;
					this.SendPropertyChanged("ACIKLAMA1");
					this.OnACIKLAMA1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ACIKLAMA2", DbType="VarChar(60)")]
		public string ACIKLAMA2
		{
			get
			{
				return this._ACIKLAMA2;
			}
			set
			{
				if ((this._ACIKLAMA2 != value))
				{
					this.OnACIKLAMA2Changing(value);
					this.SendPropertyChanging();
					this._ACIKLAMA2 = value;
					this.SendPropertyChanged("ACIKLAMA2");
					this.OnACIKLAMA2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ACIKLAMA3", DbType="VarChar(60)")]
		public string ACIKLAMA3
		{
			get
			{
				return this._ACIKLAMA3;
			}
			set
			{
				if ((this._ACIKLAMA3 != value))
				{
					this.OnACIKLAMA3Changing(value);
					this.SendPropertyChanging();
					this._ACIKLAMA3 = value;
					this.SendPropertyChanged("ACIKLAMA3");
					this.OnACIKLAMA3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AKTIF", DbType="SmallInt")]
		public System.Nullable<short> AKTIF
		{
			get
			{
				return this._AKTIF;
			}
			set
			{
				if ((this._AKTIF != value))
				{
					this.OnAKTIFChanging(value);
					this.SendPropertyChanging();
					this._AKTIF = value;
					this.SendPropertyChanged("AKTIF");
					this.OnAKTIFChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TERMINALLER", DbType="VarChar(MAX)")]
		public string TERMINALLER
		{
			get
			{
				return this._TERMINALLER;
			}
			set
			{
				if ((this._TERMINALLER != value))
				{
					this.OnTERMINALLERChanging(value);
					this.SendPropertyChanging();
					this._TERMINALLER = value;
					this.SendPropertyChanged("TERMINALLER");
					this.OnTERMINALLERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DAHILI", DbType="VarChar(10)")]
		public string DAHILI
		{
			get
			{
				return this._DAHILI;
			}
			set
			{
				if ((this._DAHILI != value))
				{
					this.OnDAHILIChanging(value);
					this.SendPropertyChanging();
					this._DAHILI = value;
					this.SendPropertyChanged("DAHILI");
					this.OnDAHILIChanged();
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
