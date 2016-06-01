#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Data;
using SiH_SalesWorkflow.Data.Bases;

#endregion

namespace SiH_SalesWorkflow.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : SiH_SalesWorkflow.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "ZohoLeadsProvider"
			
		private SqlZohoLeadsProvider innerSqlZohoLeadsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ZohoLeads"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ZohoLeadsProviderBase ZohoLeadsProvider
		{
			get
			{
				if (innerSqlZohoLeadsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlZohoLeadsProvider == null)
						{
							this.innerSqlZohoLeadsProvider = new SqlZohoLeadsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlZohoLeadsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlZohoLeadsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlZohoLeadsProvider SqlZohoLeadsProvider
		{
			get {return ZohoLeadsProvider as SqlZohoLeadsProvider;}
		}
		
		#endregion
		
		
		#region "LeadContactedProvider"
			
		private SqlLeadContactedProvider innerSqlLeadContactedProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LeadContacted"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LeadContactedProviderBase LeadContactedProvider
		{
			get
			{
				if (innerSqlLeadContactedProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLeadContactedProvider == null)
						{
							this.innerSqlLeadContactedProvider = new SqlLeadContactedProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLeadContactedProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlLeadContactedProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLeadContactedProvider SqlLeadContactedProvider
		{
			get {return LeadContactedProvider as SqlLeadContactedProvider;}
		}
		
		#endregion
		
		
		#region "ZohoCallsProvider"
			
		private SqlZohoCallsProvider innerSqlZohoCallsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ZohoCalls"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ZohoCallsProviderBase ZohoCallsProvider
		{
			get
			{
				if (innerSqlZohoCallsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlZohoCallsProvider == null)
						{
							this.innerSqlZohoCallsProvider = new SqlZohoCallsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlZohoCallsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlZohoCallsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlZohoCallsProvider SqlZohoCallsProvider
		{
			get {return ZohoCallsProvider as SqlZohoCallsProvider;}
		}
		
		#endregion
		
		
		#region "ZohoUsersProvider"
			
		private SqlZohoUsersProvider innerSqlZohoUsersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ZohoUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ZohoUsersProviderBase ZohoUsersProvider
		{
			get
			{
				if (innerSqlZohoUsersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlZohoUsersProvider == null)
						{
							this.innerSqlZohoUsersProvider = new SqlZohoUsersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlZohoUsersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlZohoUsersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlZohoUsersProvider SqlZohoUsersProvider
		{
			get {return ZohoUsersProvider as SqlZohoUsersProvider;}
		}
		
		#endregion
		
		
		#region "LeadHoldAndCallProvider"
			
		private SqlLeadHoldAndCallProvider innerSqlLeadHoldAndCallProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LeadHoldAndCall"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LeadHoldAndCallProviderBase LeadHoldAndCallProvider
		{
			get
			{
				if (innerSqlLeadHoldAndCallProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLeadHoldAndCallProvider == null)
						{
							this.innerSqlLeadHoldAndCallProvider = new SqlLeadHoldAndCallProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLeadHoldAndCallProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlLeadHoldAndCallProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLeadHoldAndCallProvider SqlLeadHoldAndCallProvider
		{
			get {return LeadHoldAndCallProvider as SqlLeadHoldAndCallProvider;}
		}
		
		#endregion
		
		
		
		#region "VwAllLeadsWithCallsAndPeriodsProvider"
		
		private SqlVwAllLeadsWithCallsAndPeriodsProvider innerSqlVwAllLeadsWithCallsAndPeriodsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwAllLeadsWithCallsAndPeriods"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwAllLeadsWithCallsAndPeriodsProviderBase VwAllLeadsWithCallsAndPeriodsProvider
		{
			get
			{
				if (innerSqlVwAllLeadsWithCallsAndPeriodsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwAllLeadsWithCallsAndPeriodsProvider == null)
						{
							this.innerSqlVwAllLeadsWithCallsAndPeriodsProvider = new SqlVwAllLeadsWithCallsAndPeriodsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwAllLeadsWithCallsAndPeriodsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwAllLeadsWithCallsAndPeriodsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwAllLeadsWithCallsAndPeriodsProvider SqlVwAllLeadsWithCallsAndPeriodsProvider
		{
			get {return VwAllLeadsWithCallsAndPeriodsProvider as SqlVwAllLeadsWithCallsAndPeriodsProvider;}
		}
		
		#endregion
		
		
		#region "VwBaseLeadContactInFutureProvider"
		
		private SqlVwBaseLeadContactInFutureProvider innerSqlVwBaseLeadContactInFutureProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwBaseLeadContactInFuture"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwBaseLeadContactInFutureProviderBase VwBaseLeadContactInFutureProvider
		{
			get
			{
				if (innerSqlVwBaseLeadContactInFutureProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwBaseLeadContactInFutureProvider == null)
						{
							this.innerSqlVwBaseLeadContactInFutureProvider = new SqlVwBaseLeadContactInFutureProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwBaseLeadContactInFutureProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwBaseLeadContactInFutureProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwBaseLeadContactInFutureProvider SqlVwBaseLeadContactInFutureProvider
		{
			get {return VwBaseLeadContactInFutureProvider as SqlVwBaseLeadContactInFutureProvider;}
		}
		
		#endregion
		
		
		#region "VwBaseLeadGetLessThanThreeCallsInPeriodProvider"
		
		private SqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider innerSqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwBaseLeadGetLessThanThreeCallsInPeriod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwBaseLeadGetLessThanThreeCallsInPeriodProviderBase VwBaseLeadGetLessThanThreeCallsInPeriodProvider
		{
			get
			{
				if (innerSqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider == null)
						{
							this.innerSqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider = new SqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider SqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider
		{
			get {return VwBaseLeadGetLessThanThreeCallsInPeriodProvider as SqlVwBaseLeadGetLessThanThreeCallsInPeriodProvider;}
		}
		
		#endregion
		
		
		#region "VwBaseLeadGetLessThanTwoCallsInPeriodProvider"
		
		private SqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider innerSqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwBaseLeadGetLessThanTwoCallsInPeriod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwBaseLeadGetLessThanTwoCallsInPeriodProviderBase VwBaseLeadGetLessThanTwoCallsInPeriodProvider
		{
			get
			{
				if (innerSqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider == null)
						{
							this.innerSqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider = new SqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider SqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider
		{
			get {return VwBaseLeadGetLessThanTwoCallsInPeriodProvider as SqlVwBaseLeadGetLessThanTwoCallsInPeriodProvider;}
		}
		
		#endregion
		
		
		#region "VwBaseLeadGetWithNoActivityIn60DaysProvider"
		
		private SqlVwBaseLeadGetWithNoActivityIn60DaysProvider innerSqlVwBaseLeadGetWithNoActivityIn60DaysProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwBaseLeadGetWithNoActivityIn60Days"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwBaseLeadGetWithNoActivityIn60DaysProviderBase VwBaseLeadGetWithNoActivityIn60DaysProvider
		{
			get
			{
				if (innerSqlVwBaseLeadGetWithNoActivityIn60DaysProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwBaseLeadGetWithNoActivityIn60DaysProvider == null)
						{
							this.innerSqlVwBaseLeadGetWithNoActivityIn60DaysProvider = new SqlVwBaseLeadGetWithNoActivityIn60DaysProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwBaseLeadGetWithNoActivityIn60DaysProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwBaseLeadGetWithNoActivityIn60DaysProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwBaseLeadGetWithNoActivityIn60DaysProvider SqlVwBaseLeadGetWithNoActivityIn60DaysProvider
		{
			get {return VwBaseLeadGetWithNoActivityIn60DaysProvider as SqlVwBaseLeadGetWithNoActivityIn60DaysProvider;}
		}
		
		#endregion
		
		
		#region "VwBaseLeadGetWithNoActivityInNdaysProvider"
		
		private SqlVwBaseLeadGetWithNoActivityInNdaysProvider innerSqlVwBaseLeadGetWithNoActivityInNdaysProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwBaseLeadGetWithNoActivityInNdays"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwBaseLeadGetWithNoActivityInNdaysProviderBase VwBaseLeadGetWithNoActivityInNdaysProvider
		{
			get
			{
				if (innerSqlVwBaseLeadGetWithNoActivityInNdaysProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwBaseLeadGetWithNoActivityInNdaysProvider == null)
						{
							this.innerSqlVwBaseLeadGetWithNoActivityInNdaysProvider = new SqlVwBaseLeadGetWithNoActivityInNdaysProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwBaseLeadGetWithNoActivityInNdaysProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwBaseLeadGetWithNoActivityInNdaysProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwBaseLeadGetWithNoActivityInNdaysProvider SqlVwBaseLeadGetWithNoActivityInNdaysProvider
		{
			get {return VwBaseLeadGetWithNoActivityInNdaysProvider as SqlVwBaseLeadGetWithNoActivityInNdaysProvider;}
		}
		
		#endregion
		
		
		#region "VwBaseLeadGetZeroCallsInPeriodProvider"
		
		private SqlVwBaseLeadGetZeroCallsInPeriodProvider innerSqlVwBaseLeadGetZeroCallsInPeriodProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwBaseLeadGetZeroCallsInPeriod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwBaseLeadGetZeroCallsInPeriodProviderBase VwBaseLeadGetZeroCallsInPeriodProvider
		{
			get
			{
				if (innerSqlVwBaseLeadGetZeroCallsInPeriodProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwBaseLeadGetZeroCallsInPeriodProvider == null)
						{
							this.innerSqlVwBaseLeadGetZeroCallsInPeriodProvider = new SqlVwBaseLeadGetZeroCallsInPeriodProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwBaseLeadGetZeroCallsInPeriodProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwBaseLeadGetZeroCallsInPeriodProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwBaseLeadGetZeroCallsInPeriodProvider SqlVwBaseLeadGetZeroCallsInPeriodProvider
		{
			get {return VwBaseLeadGetZeroCallsInPeriodProvider as SqlVwBaseLeadGetZeroCallsInPeriodProvider;}
		}
		
		#endregion
		
		
		#region "VwCallableLeadsWithCallsProvider"
		
		private SqlVwCallableLeadsWithCallsProvider innerSqlVwCallableLeadsWithCallsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwCallableLeadsWithCalls"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwCallableLeadsWithCallsProviderBase VwCallableLeadsWithCallsProvider
		{
			get
			{
				if (innerSqlVwCallableLeadsWithCallsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwCallableLeadsWithCallsProvider == null)
						{
							this.innerSqlVwCallableLeadsWithCallsProvider = new SqlVwCallableLeadsWithCallsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwCallableLeadsWithCallsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwCallableLeadsWithCallsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwCallableLeadsWithCallsProvider SqlVwCallableLeadsWithCallsProvider
		{
			get {return VwCallableLeadsWithCallsProvider as SqlVwCallableLeadsWithCallsProvider;}
		}
		
		#endregion
		
		
		#region "VwCallableLeadsWithCallsAndHourAdjProvider"
		
		private SqlVwCallableLeadsWithCallsAndHourAdjProvider innerSqlVwCallableLeadsWithCallsAndHourAdjProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwCallableLeadsWithCallsAndHourAdj"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwCallableLeadsWithCallsAndHourAdjProviderBase VwCallableLeadsWithCallsAndHourAdjProvider
		{
			get
			{
				if (innerSqlVwCallableLeadsWithCallsAndHourAdjProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwCallableLeadsWithCallsAndHourAdjProvider == null)
						{
							this.innerSqlVwCallableLeadsWithCallsAndHourAdjProvider = new SqlVwCallableLeadsWithCallsAndHourAdjProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwCallableLeadsWithCallsAndHourAdjProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwCallableLeadsWithCallsAndHourAdjProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwCallableLeadsWithCallsAndHourAdjProvider SqlVwCallableLeadsWithCallsAndHourAdjProvider
		{
			get {return VwCallableLeadsWithCallsAndHourAdjProvider as SqlVwCallableLeadsWithCallsAndHourAdjProvider;}
		}
		
		#endregion
		
		
		#region "VwCallableLeadsWithCallsAndPeriodProvider"
		
		private SqlVwCallableLeadsWithCallsAndPeriodProvider innerSqlVwCallableLeadsWithCallsAndPeriodProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwCallableLeadsWithCallsAndPeriod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwCallableLeadsWithCallsAndPeriodProviderBase VwCallableLeadsWithCallsAndPeriodProvider
		{
			get
			{
				if (innerSqlVwCallableLeadsWithCallsAndPeriodProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwCallableLeadsWithCallsAndPeriodProvider == null)
						{
							this.innerSqlVwCallableLeadsWithCallsAndPeriodProvider = new SqlVwCallableLeadsWithCallsAndPeriodProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwCallableLeadsWithCallsAndPeriodProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwCallableLeadsWithCallsAndPeriodProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwCallableLeadsWithCallsAndPeriodProvider SqlVwCallableLeadsWithCallsAndPeriodProvider
		{
			get {return VwCallableLeadsWithCallsAndPeriodProvider as SqlVwCallableLeadsWithCallsAndPeriodProvider;}
		}
		
		#endregion
		
		
		#region "VwCallableLeadsWithCallsAndPeriodsProvider"
		
		private SqlVwCallableLeadsWithCallsAndPeriodsProvider innerSqlVwCallableLeadsWithCallsAndPeriodsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwCallableLeadsWithCallsAndPeriods"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwCallableLeadsWithCallsAndPeriodsProviderBase VwCallableLeadsWithCallsAndPeriodsProvider
		{
			get
			{
				if (innerSqlVwCallableLeadsWithCallsAndPeriodsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwCallableLeadsWithCallsAndPeriodsProvider == null)
						{
							this.innerSqlVwCallableLeadsWithCallsAndPeriodsProvider = new SqlVwCallableLeadsWithCallsAndPeriodsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwCallableLeadsWithCallsAndPeriodsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwCallableLeadsWithCallsAndPeriodsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwCallableLeadsWithCallsAndPeriodsProvider SqlVwCallableLeadsWithCallsAndPeriodsProvider
		{
			get {return VwCallableLeadsWithCallsAndPeriodsProvider as SqlVwCallableLeadsWithCallsAndPeriodsProvider;}
		}
		
		#endregion
		
		
		#region "VwCallsByUserProvider"
		
		private SqlVwCallsByUserProvider innerSqlVwCallsByUserProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwCallsByUser"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwCallsByUserProviderBase VwCallsByUserProvider
		{
			get
			{
				if (innerSqlVwCallsByUserProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwCallsByUserProvider == null)
						{
							this.innerSqlVwCallsByUserProvider = new SqlVwCallsByUserProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwCallsByUserProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwCallsByUserProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwCallsByUserProvider SqlVwCallsByUserProvider
		{
			get {return VwCallsByUserProvider as SqlVwCallsByUserProvider;}
		}
		
		#endregion
		
		
		#region "VwDeferedLeadsProvider"
		
		private SqlVwDeferedLeadsProvider innerSqlVwDeferedLeadsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwDeferedLeads"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwDeferedLeadsProviderBase VwDeferedLeadsProvider
		{
			get
			{
				if (innerSqlVwDeferedLeadsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwDeferedLeadsProvider == null)
						{
							this.innerSqlVwDeferedLeadsProvider = new SqlVwDeferedLeadsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwDeferedLeadsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwDeferedLeadsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwDeferedLeadsProvider SqlVwDeferedLeadsProvider
		{
			get {return VwDeferedLeadsProvider as SqlVwDeferedLeadsProvider;}
		}
		
		#endregion
		
		
		#region "VwHoldAndCallWithLeadInfoProvider"
		
		private SqlVwHoldAndCallWithLeadInfoProvider innerSqlVwHoldAndCallWithLeadInfoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwHoldAndCallWithLeadInfo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwHoldAndCallWithLeadInfoProviderBase VwHoldAndCallWithLeadInfoProvider
		{
			get
			{
				if (innerSqlVwHoldAndCallWithLeadInfoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwHoldAndCallWithLeadInfoProvider == null)
						{
							this.innerSqlVwHoldAndCallWithLeadInfoProvider = new SqlVwHoldAndCallWithLeadInfoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwHoldAndCallWithLeadInfoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwHoldAndCallWithLeadInfoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwHoldAndCallWithLeadInfoProvider SqlVwHoldAndCallWithLeadInfoProvider
		{
			get {return VwHoldAndCallWithLeadInfoProvider as SqlVwHoldAndCallWithLeadInfoProvider;}
		}
		
		#endregion
		
		
		#region "VwLastCallCreatedProvider"
		
		private SqlVwLastCallCreatedProvider innerSqlVwLastCallCreatedProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLastCallCreated"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLastCallCreatedProviderBase VwLastCallCreatedProvider
		{
			get
			{
				if (innerSqlVwLastCallCreatedProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLastCallCreatedProvider == null)
						{
							this.innerSqlVwLastCallCreatedProvider = new SqlVwLastCallCreatedProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLastCallCreatedProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLastCallCreatedProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLastCallCreatedProvider SqlVwLastCallCreatedProvider
		{
			get {return VwLastCallCreatedProvider as SqlVwLastCallCreatedProvider;}
		}
		
		#endregion
		
		
		#region "VwLastEmailCreatedProvider"
		
		private SqlVwLastEmailCreatedProvider innerSqlVwLastEmailCreatedProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLastEmailCreated"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLastEmailCreatedProviderBase VwLastEmailCreatedProvider
		{
			get
			{
				if (innerSqlVwLastEmailCreatedProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLastEmailCreatedProvider == null)
						{
							this.innerSqlVwLastEmailCreatedProvider = new SqlVwLastEmailCreatedProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLastEmailCreatedProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLastEmailCreatedProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLastEmailCreatedProvider SqlVwLastEmailCreatedProvider
		{
			get {return VwLastEmailCreatedProvider as SqlVwLastEmailCreatedProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadCallCountsProvider"
		
		private SqlVwLeadCallCountsProvider innerSqlVwLeadCallCountsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadCallCounts"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadCallCountsProviderBase VwLeadCallCountsProvider
		{
			get
			{
				if (innerSqlVwLeadCallCountsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadCallCountsProvider == null)
						{
							this.innerSqlVwLeadCallCountsProvider = new SqlVwLeadCallCountsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadCallCountsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadCallCountsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadCallCountsProvider SqlVwLeadCallCountsProvider
		{
			get {return VwLeadCallCountsProvider as SqlVwLeadCallCountsProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadContactToolProvider"
		
		private SqlVwLeadContactToolProvider innerSqlVwLeadContactToolProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadContactTool"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadContactToolProviderBase VwLeadContactToolProvider
		{
			get
			{
				if (innerSqlVwLeadContactToolProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadContactToolProvider == null)
						{
							this.innerSqlVwLeadContactToolProvider = new SqlVwLeadContactToolProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadContactToolProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadContactToolProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadContactToolProvider SqlVwLeadContactToolProvider
		{
			get {return VwLeadContactToolProvider as SqlVwLeadContactToolProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadContactToolCompleteProvider"
		
		private SqlVwLeadContactToolCompleteProvider innerSqlVwLeadContactToolCompleteProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadContactToolComplete"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadContactToolCompleteProviderBase VwLeadContactToolCompleteProvider
		{
			get
			{
				if (innerSqlVwLeadContactToolCompleteProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadContactToolCompleteProvider == null)
						{
							this.innerSqlVwLeadContactToolCompleteProvider = new SqlVwLeadContactToolCompleteProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadContactToolCompleteProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadContactToolCompleteProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadContactToolCompleteProvider SqlVwLeadContactToolCompleteProvider
		{
			get {return VwLeadContactToolCompleteProvider as SqlVwLeadContactToolCompleteProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadGetProvider"
		
		private SqlVwLeadGetProvider innerSqlVwLeadGetProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadGet"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadGetProviderBase VwLeadGetProvider
		{
			get
			{
				if (innerSqlVwLeadGetProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadGetProvider == null)
						{
							this.innerSqlVwLeadGetProvider = new SqlVwLeadGetProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadGetProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadGetProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadGetProvider SqlVwLeadGetProvider
		{
			get {return VwLeadGetProvider as SqlVwLeadGetProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadGetAlexProvider"
		
		private SqlVwLeadGetAlexProvider innerSqlVwLeadGetAlexProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadGetAlex"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadGetAlexProviderBase VwLeadGetAlexProvider
		{
			get
			{
				if (innerSqlVwLeadGetAlexProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadGetAlexProvider == null)
						{
							this.innerSqlVwLeadGetAlexProvider = new SqlVwLeadGetAlexProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadGetAlexProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadGetAlexProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadGetAlexProvider SqlVwLeadGetAlexProvider
		{
			get {return VwLeadGetAlexProvider as SqlVwLeadGetAlexProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadGetCraigProvider"
		
		private SqlVwLeadGetCraigProvider innerSqlVwLeadGetCraigProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadGetCraig"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadGetCraigProviderBase VwLeadGetCraigProvider
		{
			get
			{
				if (innerSqlVwLeadGetCraigProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadGetCraigProvider == null)
						{
							this.innerSqlVwLeadGetCraigProvider = new SqlVwLeadGetCraigProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadGetCraigProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadGetCraigProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadGetCraigProvider SqlVwLeadGetCraigProvider
		{
			get {return VwLeadGetCraigProvider as SqlVwLeadGetCraigProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadGetJennProvider"
		
		private SqlVwLeadGetJennProvider innerSqlVwLeadGetJennProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadGetJenn"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadGetJennProviderBase VwLeadGetJennProvider
		{
			get
			{
				if (innerSqlVwLeadGetJennProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadGetJennProvider == null)
						{
							this.innerSqlVwLeadGetJennProvider = new SqlVwLeadGetJennProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadGetJennProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadGetJennProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadGetJennProvider SqlVwLeadGetJennProvider
		{
			get {return VwLeadGetJennProvider as SqlVwLeadGetJennProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadGetJoEllenProvider"
		
		private SqlVwLeadGetJoEllenProvider innerSqlVwLeadGetJoEllenProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadGetJoEllen"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadGetJoEllenProviderBase VwLeadGetJoEllenProvider
		{
			get
			{
				if (innerSqlVwLeadGetJoEllenProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadGetJoEllenProvider == null)
						{
							this.innerSqlVwLeadGetJoEllenProvider = new SqlVwLeadGetJoEllenProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadGetJoEllenProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadGetJoEllenProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadGetJoEllenProvider SqlVwLeadGetJoEllenProvider
		{
			get {return VwLeadGetJoEllenProvider as SqlVwLeadGetJoEllenProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadGetNextProvider"
		
		private SqlVwLeadGetNextProvider innerSqlVwLeadGetNextProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadGetNext"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadGetNextProviderBase VwLeadGetNextProvider
		{
			get
			{
				if (innerSqlVwLeadGetNextProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadGetNextProvider == null)
						{
							this.innerSqlVwLeadGetNextProvider = new SqlVwLeadGetNextProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadGetNextProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadGetNextProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadGetNextProvider SqlVwLeadGetNextProvider
		{
			get {return VwLeadGetNextProvider as SqlVwLeadGetNextProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadGetRichardProvider"
		
		private SqlVwLeadGetRichardProvider innerSqlVwLeadGetRichardProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadGetRichard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadGetRichardProviderBase VwLeadGetRichardProvider
		{
			get
			{
				if (innerSqlVwLeadGetRichardProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadGetRichardProvider == null)
						{
							this.innerSqlVwLeadGetRichardProvider = new SqlVwLeadGetRichardProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadGetRichardProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadGetRichardProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadGetRichardProvider SqlVwLeadGetRichardProvider
		{
			get {return VwLeadGetRichardProvider as SqlVwLeadGetRichardProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadHoldAndCallProvider"
		
		private SqlVwLeadHoldAndCallProvider innerSqlVwLeadHoldAndCallProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadHoldAndCall"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadHoldAndCallProviderBase VwLeadHoldAndCallProvider
		{
			get
			{
				if (innerSqlVwLeadHoldAndCallProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadHoldAndCallProvider == null)
						{
							this.innerSqlVwLeadHoldAndCallProvider = new SqlVwLeadHoldAndCallProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadHoldAndCallProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadHoldAndCallProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadHoldAndCallProvider SqlVwLeadHoldAndCallProvider
		{
			get {return VwLeadHoldAndCallProvider as SqlVwLeadHoldAndCallProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadsAndCallsProvider"
		
		private SqlVwLeadsAndCallsProvider innerSqlVwLeadsAndCallsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadsAndCalls"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadsAndCallsProviderBase VwLeadsAndCallsProvider
		{
			get
			{
				if (innerSqlVwLeadsAndCallsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadsAndCallsProvider == null)
						{
							this.innerSqlVwLeadsAndCallsProvider = new SqlVwLeadsAndCallsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadsAndCallsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadsAndCallsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadsAndCallsProvider SqlVwLeadsAndCallsProvider
		{
			get {return VwLeadsAndCallsProvider as SqlVwLeadsAndCallsProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadsWithAllStatusProvider"
		
		private SqlVwLeadsWithAllStatusProvider innerSqlVwLeadsWithAllStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadsWithAllStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadsWithAllStatusProviderBase VwLeadsWithAllStatusProvider
		{
			get
			{
				if (innerSqlVwLeadsWithAllStatusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadsWithAllStatusProvider == null)
						{
							this.innerSqlVwLeadsWithAllStatusProvider = new SqlVwLeadsWithAllStatusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadsWithAllStatusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadsWithAllStatusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadsWithAllStatusProvider SqlVwLeadsWithAllStatusProvider
		{
			get {return VwLeadsWithAllStatusProvider as SqlVwLeadsWithAllStatusProvider;}
		}
		
		#endregion
		
		
		#region "VwLeadsWithCallableStatusProvider"
		
		private SqlVwLeadsWithCallableStatusProvider innerSqlVwLeadsWithCallableStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwLeadsWithCallableStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwLeadsWithCallableStatusProviderBase VwLeadsWithCallableStatusProvider
		{
			get
			{
				if (innerSqlVwLeadsWithCallableStatusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwLeadsWithCallableStatusProvider == null)
						{
							this.innerSqlVwLeadsWithCallableStatusProvider = new SqlVwLeadsWithCallableStatusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwLeadsWithCallableStatusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwLeadsWithCallableStatusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwLeadsWithCallableStatusProvider SqlVwLeadsWithCallableStatusProvider
		{
			get {return VwLeadsWithCallableStatusProvider as SqlVwLeadsWithCallableStatusProvider;}
		}
		
		#endregion
		
		
		#region "VwManualReturnsListProvider"
		
		private SqlVwManualReturnsListProvider innerSqlVwManualReturnsListProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwManualReturnsList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwManualReturnsListProviderBase VwManualReturnsListProvider
		{
			get
			{
				if (innerSqlVwManualReturnsListProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwManualReturnsListProvider == null)
						{
							this.innerSqlVwManualReturnsListProvider = new SqlVwManualReturnsListProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwManualReturnsListProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwManualReturnsListProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwManualReturnsListProvider SqlVwManualReturnsListProvider
		{
			get {return VwManualReturnsListProvider as SqlVwManualReturnsListProvider;}
		}
		
		#endregion
		
		
		#region "VwManualSalesListProvider"
		
		private SqlVwManualSalesListProvider innerSqlVwManualSalesListProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwManualSalesList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwManualSalesListProviderBase VwManualSalesListProvider
		{
			get
			{
				if (innerSqlVwManualSalesListProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwManualSalesListProvider == null)
						{
							this.innerSqlVwManualSalesListProvider = new SqlVwManualSalesListProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwManualSalesListProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwManualSalesListProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwManualSalesListProvider SqlVwManualSalesListProvider
		{
			get {return VwManualSalesListProvider as SqlVwManualSalesListProvider;}
		}
		
		#endregion
		
		
		#region "VwMaxLeadHoldAndCallProvider"
		
		private SqlVwMaxLeadHoldAndCallProvider innerSqlVwMaxLeadHoldAndCallProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwMaxLeadHoldAndCall"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwMaxLeadHoldAndCallProviderBase VwMaxLeadHoldAndCallProvider
		{
			get
			{
				if (innerSqlVwMaxLeadHoldAndCallProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwMaxLeadHoldAndCallProvider == null)
						{
							this.innerSqlVwMaxLeadHoldAndCallProvider = new SqlVwMaxLeadHoldAndCallProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwMaxLeadHoldAndCallProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwMaxLeadHoldAndCallProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwMaxLeadHoldAndCallProvider SqlVwMaxLeadHoldAndCallProvider
		{
			get {return VwMaxLeadHoldAndCallProvider as SqlVwMaxLeadHoldAndCallProvider;}
		}
		
		#endregion
		
		
		#region "VwReportingLeadsAndSalesBoardProvider"
		
		private SqlVwReportingLeadsAndSalesBoardProvider innerSqlVwReportingLeadsAndSalesBoardProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwReportingLeadsAndSalesBoard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwReportingLeadsAndSalesBoardProviderBase VwReportingLeadsAndSalesBoardProvider
		{
			get
			{
				if (innerSqlVwReportingLeadsAndSalesBoardProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwReportingLeadsAndSalesBoardProvider == null)
						{
							this.innerSqlVwReportingLeadsAndSalesBoardProvider = new SqlVwReportingLeadsAndSalesBoardProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwReportingLeadsAndSalesBoardProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwReportingLeadsAndSalesBoardProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwReportingLeadsAndSalesBoardProvider SqlVwReportingLeadsAndSalesBoardProvider
		{
			get {return VwReportingLeadsAndSalesBoardProvider as SqlVwReportingLeadsAndSalesBoardProvider;}
		}
		
		#endregion
		
		
		#region "VwReportingSalesInfoProvider"
		
		private SqlVwReportingSalesInfoProvider innerSqlVwReportingSalesInfoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwReportingSalesInfo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwReportingSalesInfoProviderBase VwReportingSalesInfoProvider
		{
			get
			{
				if (innerSqlVwReportingSalesInfoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwReportingSalesInfoProvider == null)
						{
							this.innerSqlVwReportingSalesInfoProvider = new SqlVwReportingSalesInfoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwReportingSalesInfoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwReportingSalesInfoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwReportingSalesInfoProvider SqlVwReportingSalesInfoProvider
		{
			get {return VwReportingSalesInfoProvider as SqlVwReportingSalesInfoProvider;}
		}
		
		#endregion
		
		
		#region "VwReportingZohoCallsConnectedAfterDateProvider"
		
		private SqlVwReportingZohoCallsConnectedAfterDateProvider innerSqlVwReportingZohoCallsConnectedAfterDateProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwReportingZohoCallsConnectedAfterDate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwReportingZohoCallsConnectedAfterDateProviderBase VwReportingZohoCallsConnectedAfterDateProvider
		{
			get
			{
				if (innerSqlVwReportingZohoCallsConnectedAfterDateProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwReportingZohoCallsConnectedAfterDateProvider == null)
						{
							this.innerSqlVwReportingZohoCallsConnectedAfterDateProvider = new SqlVwReportingZohoCallsConnectedAfterDateProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwReportingZohoCallsConnectedAfterDateProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwReportingZohoCallsConnectedAfterDateProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwReportingZohoCallsConnectedAfterDateProvider SqlVwReportingZohoCallsConnectedAfterDateProvider
		{
			get {return VwReportingZohoCallsConnectedAfterDateProvider as SqlVwReportingZohoCallsConnectedAfterDateProvider;}
		}
		
		#endregion
		
		
		#region "VwSalesStatsProvider"
		
		private SqlVwSalesStatsProvider innerSqlVwSalesStatsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwSalesStats"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwSalesStatsProviderBase VwSalesStatsProvider
		{
			get
			{
				if (innerSqlVwSalesStatsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwSalesStatsProvider == null)
						{
							this.innerSqlVwSalesStatsProvider = new SqlVwSalesStatsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwSalesStatsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwSalesStatsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwSalesStatsProvider SqlVwSalesStatsProvider
		{
			get {return VwSalesStatsProvider as SqlVwSalesStatsProvider;}
		}
		
		#endregion
		
		
		#region "VwZohoCallsProvider"
		
		private SqlVwZohoCallsProvider innerSqlVwZohoCallsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwZohoCalls"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwZohoCallsProviderBase VwZohoCallsProvider
		{
			get
			{
				if (innerSqlVwZohoCallsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwZohoCallsProvider == null)
						{
							this.innerSqlVwZohoCallsProvider = new SqlVwZohoCallsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwZohoCallsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwZohoCallsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwZohoCallsProvider SqlVwZohoCallsProvider
		{
			get {return VwZohoCallsProvider as SqlVwZohoCallsProvider;}
		}
		
		#endregion
		
		
		#region "VwZohoLeadsProvider"
		
		private SqlVwZohoLeadsProvider innerSqlVwZohoLeadsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwZohoLeads"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwZohoLeadsProviderBase VwZohoLeadsProvider
		{
			get
			{
				if (innerSqlVwZohoLeadsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwZohoLeadsProvider == null)
						{
							this.innerSqlVwZohoLeadsProvider = new SqlVwZohoLeadsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwZohoLeadsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwZohoLeadsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwZohoLeadsProvider SqlVwZohoLeadsProvider
		{
			get {return VwZohoLeadsProvider as SqlVwZohoLeadsProvider;}
		}
		
		#endregion
		
		
		#region "VwZohoLeadsNeedingActionTodayProvider"
		
		private SqlVwZohoLeadsNeedingActionTodayProvider innerSqlVwZohoLeadsNeedingActionTodayProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwZohoLeadsNeedingActionToday"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwZohoLeadsNeedingActionTodayProviderBase VwZohoLeadsNeedingActionTodayProvider
		{
			get
			{
				if (innerSqlVwZohoLeadsNeedingActionTodayProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwZohoLeadsNeedingActionTodayProvider == null)
						{
							this.innerSqlVwZohoLeadsNeedingActionTodayProvider = new SqlVwZohoLeadsNeedingActionTodayProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwZohoLeadsNeedingActionTodayProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwZohoLeadsNeedingActionTodayProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwZohoLeadsNeedingActionTodayProvider SqlVwZohoLeadsNeedingActionTodayProvider
		{
			get {return VwZohoLeadsNeedingActionTodayProvider as SqlVwZohoLeadsNeedingActionTodayProvider;}
		}
		
		#endregion
		
		
		#region "VwZohoLeadsWithLocalTimeProvider"
		
		private SqlVwZohoLeadsWithLocalTimeProvider innerSqlVwZohoLeadsWithLocalTimeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwZohoLeadsWithLocalTime"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwZohoLeadsWithLocalTimeProviderBase VwZohoLeadsWithLocalTimeProvider
		{
			get
			{
				if (innerSqlVwZohoLeadsWithLocalTimeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwZohoLeadsWithLocalTimeProvider == null)
						{
							this.innerSqlVwZohoLeadsWithLocalTimeProvider = new SqlVwZohoLeadsWithLocalTimeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwZohoLeadsWithLocalTimeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwZohoLeadsWithLocalTimeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwZohoLeadsWithLocalTimeProvider SqlVwZohoLeadsWithLocalTimeProvider
		{
			get {return VwZohoLeadsWithLocalTimeProvider as SqlVwZohoLeadsWithLocalTimeProvider;}
		}
		
		#endregion
		
		
		#region "VwZohoLeadsWithLocalTimeNoActionTodayProvider"
		
		private SqlVwZohoLeadsWithLocalTimeNoActionTodayProvider innerSqlVwZohoLeadsWithLocalTimeNoActionTodayProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwZohoLeadsWithLocalTimeNoActionToday"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwZohoLeadsWithLocalTimeNoActionTodayProviderBase VwZohoLeadsWithLocalTimeNoActionTodayProvider
		{
			get
			{
				if (innerSqlVwZohoLeadsWithLocalTimeNoActionTodayProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwZohoLeadsWithLocalTimeNoActionTodayProvider == null)
						{
							this.innerSqlVwZohoLeadsWithLocalTimeNoActionTodayProvider = new SqlVwZohoLeadsWithLocalTimeNoActionTodayProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwZohoLeadsWithLocalTimeNoActionTodayProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwZohoLeadsWithLocalTimeNoActionTodayProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwZohoLeadsWithLocalTimeNoActionTodayProvider SqlVwZohoLeadsWithLocalTimeNoActionTodayProvider
		{
			get {return VwZohoLeadsWithLocalTimeNoActionTodayProvider as SqlVwZohoLeadsWithLocalTimeNoActionTodayProvider;}
		}
		
		#endregion
		
		
		#region "VwZohoLeadsWithLocalTimeNoActionTodayCallableProvider"
		
		private SqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider innerSqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VwZohoLeadsWithLocalTimeNoActionTodayCallableProviderBase VwZohoLeadsWithLocalTimeNoActionTodayCallableProvider
		{
			get
			{
				if (innerSqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider == null)
						{
							this.innerSqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider = new SqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider SqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider
		{
			get {return VwZohoLeadsWithLocalTimeNoActionTodayCallableProvider as SqlVwZohoLeadsWithLocalTimeNoActionTodayCallableProvider;}
		}
		
		#endregion
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
