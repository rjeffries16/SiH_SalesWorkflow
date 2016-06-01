#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using SalesWorkflow.Entities;
using SalesWorkflow.Data;
using SalesWorkflow.Data.Bases;

#endregion

namespace SalesWorkflow.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("SalesWorkflow.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.12.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
					// use default ConnectionStrings if _section has already been discovered
					if ( _config == null && _section != null )
					{
						return WebConfigurationManager.ConnectionStrings;
					}
					
					return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region ZohoLeadsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ZohoLeads"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ZohoLeadsProviderBase ZohoLeadsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ZohoLeadsProvider;
			}
		}
		
		#endregion
		
		#region LeadContactedProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LeadContacted"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LeadContactedProviderBase LeadContactedProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LeadContactedProvider;
			}
		}
		
		#endregion
		
		#region ZohoCallsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ZohoCalls"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ZohoCallsProviderBase ZohoCallsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ZohoCallsProvider;
			}
		}
		
		#endregion
		
		#region ZohoUsersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ZohoUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ZohoUsersProviderBase ZohoUsersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ZohoUsersProvider;
			}
		}
		
		#endregion
		
		#region LeadHoldAndCallProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LeadHoldAndCall"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LeadHoldAndCallProviderBase LeadHoldAndCallProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LeadHoldAndCallProvider;
			}
		}
		
		#endregion
		
		
		#region VwAllLeadsWithCallsAndPeriodsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwAllLeadsWithCallsAndPeriods"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwAllLeadsWithCallsAndPeriodsProviderBase VwAllLeadsWithCallsAndPeriodsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwAllLeadsWithCallsAndPeriodsProvider;
			}
		}
		
		#endregion
		
		#region VwBaseLeadContactInFutureProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwBaseLeadContactInFuture"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwBaseLeadContactInFutureProviderBase VwBaseLeadContactInFutureProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwBaseLeadContactInFutureProvider;
			}
		}
		
		#endregion
		
		#region VwBaseLeadGetLessThanThreeCallsInPeriodProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwBaseLeadGetLessThanThreeCallsInPeriod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwBaseLeadGetLessThanThreeCallsInPeriodProviderBase VwBaseLeadGetLessThanThreeCallsInPeriodProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwBaseLeadGetLessThanThreeCallsInPeriodProvider;
			}
		}
		
		#endregion
		
		#region VwBaseLeadGetLessThanTwoCallsInPeriodProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwBaseLeadGetLessThanTwoCallsInPeriod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwBaseLeadGetLessThanTwoCallsInPeriodProviderBase VwBaseLeadGetLessThanTwoCallsInPeriodProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwBaseLeadGetLessThanTwoCallsInPeriodProvider;
			}
		}
		
		#endregion
		
		#region VwBaseLeadGetWithNoActivityIn60DaysProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwBaseLeadGetWithNoActivityIn60Days"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwBaseLeadGetWithNoActivityIn60DaysProviderBase VwBaseLeadGetWithNoActivityIn60DaysProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwBaseLeadGetWithNoActivityIn60DaysProvider;
			}
		}
		
		#endregion
		
		#region VwBaseLeadGetWithNoActivityInNdaysProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwBaseLeadGetWithNoActivityInNdays"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwBaseLeadGetWithNoActivityInNdaysProviderBase VwBaseLeadGetWithNoActivityInNdaysProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwBaseLeadGetWithNoActivityInNdaysProvider;
			}
		}
		
		#endregion
		
		#region VwBaseLeadGetZeroCallsInPeriodProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwBaseLeadGetZeroCallsInPeriod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwBaseLeadGetZeroCallsInPeriodProviderBase VwBaseLeadGetZeroCallsInPeriodProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwBaseLeadGetZeroCallsInPeriodProvider;
			}
		}
		
		#endregion
		
		#region VwCallableLeadsWithCallsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwCallableLeadsWithCalls"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwCallableLeadsWithCallsProviderBase VwCallableLeadsWithCallsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwCallableLeadsWithCallsProvider;
			}
		}
		
		#endregion
		
		#region VwCallableLeadsWithCallsAndHourAdjProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwCallableLeadsWithCallsAndHourAdj"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwCallableLeadsWithCallsAndHourAdjProviderBase VwCallableLeadsWithCallsAndHourAdjProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwCallableLeadsWithCallsAndHourAdjProvider;
			}
		}
		
		#endregion
		
		#region VwCallableLeadsWithCallsAndPeriodProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwCallableLeadsWithCallsAndPeriod"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwCallableLeadsWithCallsAndPeriodProviderBase VwCallableLeadsWithCallsAndPeriodProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwCallableLeadsWithCallsAndPeriodProvider;
			}
		}
		
		#endregion
		
		#region VwCallableLeadsWithCallsAndPeriodsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwCallableLeadsWithCallsAndPeriods"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwCallableLeadsWithCallsAndPeriodsProviderBase VwCallableLeadsWithCallsAndPeriodsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwCallableLeadsWithCallsAndPeriodsProvider;
			}
		}
		
		#endregion
		
		#region VwCallsByUserProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwCallsByUser"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwCallsByUserProviderBase VwCallsByUserProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwCallsByUserProvider;
			}
		}
		
		#endregion
		
		#region VwDeferedLeadsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwDeferedLeads"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwDeferedLeadsProviderBase VwDeferedLeadsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwDeferedLeadsProvider;
			}
		}
		
		#endregion
		
		#region VwHoldAndCallWithLeadInfoProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwHoldAndCallWithLeadInfo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwHoldAndCallWithLeadInfoProviderBase VwHoldAndCallWithLeadInfoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwHoldAndCallWithLeadInfoProvider;
			}
		}
		
		#endregion
		
		#region VwLastCallCreatedProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLastCallCreated"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLastCallCreatedProviderBase VwLastCallCreatedProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLastCallCreatedProvider;
			}
		}
		
		#endregion
		
		#region VwLastEmailCreatedProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLastEmailCreated"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLastEmailCreatedProviderBase VwLastEmailCreatedProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLastEmailCreatedProvider;
			}
		}
		
		#endregion
		
		#region VwLeadCallCountsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadCallCounts"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadCallCountsProviderBase VwLeadCallCountsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadCallCountsProvider;
			}
		}
		
		#endregion
		
		#region VwLeadContactToolProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadContactTool"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadContactToolProviderBase VwLeadContactToolProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadContactToolProvider;
			}
		}
		
		#endregion
		
		#region VwLeadContactToolCompleteProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadContactToolComplete"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadContactToolCompleteProviderBase VwLeadContactToolCompleteProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadContactToolCompleteProvider;
			}
		}
		
		#endregion
		
		#region VwLeadGetProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadGet"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadGetProviderBase VwLeadGetProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadGetProvider;
			}
		}
		
		#endregion
		
		#region VwLeadGetAlexProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadGetAlex"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadGetAlexProviderBase VwLeadGetAlexProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadGetAlexProvider;
			}
		}
		
		#endregion
		
		#region VwLeadGetCraigProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadGetCraig"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadGetCraigProviderBase VwLeadGetCraigProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadGetCraigProvider;
			}
		}
		
		#endregion
		
		#region VwLeadGetJennProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadGetJenn"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadGetJennProviderBase VwLeadGetJennProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadGetJennProvider;
			}
		}
		
		#endregion
		
		#region VwLeadGetJoEllenProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadGetJoEllen"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadGetJoEllenProviderBase VwLeadGetJoEllenProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadGetJoEllenProvider;
			}
		}
		
		#endregion
		
		#region VwLeadGetNextProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadGetNext"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadGetNextProviderBase VwLeadGetNextProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadGetNextProvider;
			}
		}
		
		#endregion
		
		#region VwLeadGetRichardProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadGetRichard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadGetRichardProviderBase VwLeadGetRichardProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadGetRichardProvider;
			}
		}
		
		#endregion
		
		#region VwLeadHoldAndCallProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadHoldAndCall"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadHoldAndCallProviderBase VwLeadHoldAndCallProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadHoldAndCallProvider;
			}
		}
		
		#endregion
		
		#region VwLeadsAndCallsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadsAndCalls"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadsAndCallsProviderBase VwLeadsAndCallsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadsAndCallsProvider;
			}
		}
		
		#endregion
		
		#region VwLeadsWithAllStatusProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadsWithAllStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadsWithAllStatusProviderBase VwLeadsWithAllStatusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadsWithAllStatusProvider;
			}
		}
		
		#endregion
		
		#region VwLeadsWithCallableStatusProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwLeadsWithCallableStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwLeadsWithCallableStatusProviderBase VwLeadsWithCallableStatusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwLeadsWithCallableStatusProvider;
			}
		}
		
		#endregion
		
		#region VwManualReturnsListProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwManualReturnsList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwManualReturnsListProviderBase VwManualReturnsListProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwManualReturnsListProvider;
			}
		}
		
		#endregion
		
		#region VwManualSalesListProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwManualSalesList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwManualSalesListProviderBase VwManualSalesListProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwManualSalesListProvider;
			}
		}
		
		#endregion
		
		#region VwMaxLeadHoldAndCallProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwMaxLeadHoldAndCall"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwMaxLeadHoldAndCallProviderBase VwMaxLeadHoldAndCallProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwMaxLeadHoldAndCallProvider;
			}
		}
		
		#endregion
		
		#region VwReportingLeadsAndSalesBoardProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwReportingLeadsAndSalesBoard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwReportingLeadsAndSalesBoardProviderBase VwReportingLeadsAndSalesBoardProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwReportingLeadsAndSalesBoardProvider;
			}
		}
		
		#endregion
		
		#region VwReportingSalesInfoProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwReportingSalesInfo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwReportingSalesInfoProviderBase VwReportingSalesInfoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwReportingSalesInfoProvider;
			}
		}
		
		#endregion
		
		#region VwReportingZohoCallsConnectedAfterDateProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwReportingZohoCallsConnectedAfterDate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwReportingZohoCallsConnectedAfterDateProviderBase VwReportingZohoCallsConnectedAfterDateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwReportingZohoCallsConnectedAfterDateProvider;
			}
		}
		
		#endregion
		
		#region VwSalesStatsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwSalesStats"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwSalesStatsProviderBase VwSalesStatsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwSalesStatsProvider;
			}
		}
		
		#endregion
		
		#region VwZohoCallsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwZohoCalls"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwZohoCallsProviderBase VwZohoCallsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwZohoCallsProvider;
			}
		}
		
		#endregion
		
		#region VwZohoLeadsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwZohoLeads"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwZohoLeadsProviderBase VwZohoLeadsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwZohoLeadsProvider;
			}
		}
		
		#endregion
		
		#region VwZohoLeadsNeedingActionTodayProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwZohoLeadsNeedingActionToday"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwZohoLeadsNeedingActionTodayProviderBase VwZohoLeadsNeedingActionTodayProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwZohoLeadsNeedingActionTodayProvider;
			}
		}
		
		#endregion
		
		#region VwZohoLeadsWithLocalTimeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwZohoLeadsWithLocalTime"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwZohoLeadsWithLocalTimeProviderBase VwZohoLeadsWithLocalTimeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwZohoLeadsWithLocalTimeProvider;
			}
		}
		
		#endregion
		
		#region VwZohoLeadsWithLocalTimeNoActionTodayProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwZohoLeadsWithLocalTimeNoActionToday"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwZohoLeadsWithLocalTimeNoActionTodayProviderBase VwZohoLeadsWithLocalTimeNoActionTodayProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwZohoLeadsWithLocalTimeNoActionTodayProvider;
			}
		}
		
		#endregion
		
		#region VwZohoLeadsWithLocalTimeNoActionTodayCallableProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VwZohoLeadsWithLocalTimeNoActionTodayCallableProviderBase VwZohoLeadsWithLocalTimeNoActionTodayCallableProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VwZohoLeadsWithLocalTimeNoActionTodayCallableProvider;
			}
		}
		
		#endregion
		
		#endregion
	}
	
	#region Query/Filters
		
	#region ZohoLeadsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoLeadsFilters : ZohoLeadsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsFilters class.
		/// </summary>
		public ZohoLeadsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoLeadsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoLeadsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoLeadsFilters
	
	#region ZohoLeadsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ZohoLeadsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoLeadsQuery : ZohoLeadsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsQuery class.
		/// </summary>
		public ZohoLeadsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoLeadsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoLeadsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoLeadsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoLeadsQuery
		
	#region LeadContactedFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadContacted"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadContactedFilters : LeadContactedFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadContactedFilters class.
		/// </summary>
		public LeadContactedFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadContactedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadContactedFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadContactedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadContactedFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadContactedFilters
	
	#region LeadContactedQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LeadContactedParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LeadContacted"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadContactedQuery : LeadContactedParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadContactedQuery class.
		/// </summary>
		public LeadContactedQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadContactedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadContactedQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadContactedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadContactedQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadContactedQuery
		
	#region ZohoCallsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoCallsFilters : ZohoCallsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoCallsFilters class.
		/// </summary>
		public ZohoCallsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoCallsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoCallsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoCallsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoCallsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoCallsFilters
	
	#region ZohoCallsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ZohoCallsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoCallsQuery : ZohoCallsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoCallsQuery class.
		/// </summary>
		public ZohoCallsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoCallsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoCallsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoCallsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoCallsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoCallsQuery
		
	#region ZohoUsersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ZohoUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoUsersFilters : ZohoUsersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoUsersFilters class.
		/// </summary>
		public ZohoUsersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoUsersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoUsersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoUsersFilters
	
	#region ZohoUsersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ZohoUsersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ZohoUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ZohoUsersQuery : ZohoUsersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ZohoUsersQuery class.
		/// </summary>
		public ZohoUsersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ZohoUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ZohoUsersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ZohoUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ZohoUsersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ZohoUsersQuery
		
	#region LeadHoldAndCallFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadHoldAndCallFilters : LeadHoldAndCallFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallFilters class.
		/// </summary>
		public LeadHoldAndCallFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadHoldAndCallFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadHoldAndCallFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadHoldAndCallFilters
	
	#region LeadHoldAndCallQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LeadHoldAndCallParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LeadHoldAndCallQuery : LeadHoldAndCallParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallQuery class.
		/// </summary>
		public LeadHoldAndCallQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LeadHoldAndCallQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LeadHoldAndCallQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LeadHoldAndCallQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LeadHoldAndCallQuery
		
	#region VwAllLeadsWithCallsAndPeriodsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwAllLeadsWithCallsAndPeriods"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwAllLeadsWithCallsAndPeriodsFilters : VwAllLeadsWithCallsAndPeriodsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwAllLeadsWithCallsAndPeriodsFilters class.
		/// </summary>
		public VwAllLeadsWithCallsAndPeriodsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwAllLeadsWithCallsAndPeriodsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwAllLeadsWithCallsAndPeriodsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwAllLeadsWithCallsAndPeriodsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwAllLeadsWithCallsAndPeriodsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwAllLeadsWithCallsAndPeriodsFilters
	
	#region VwAllLeadsWithCallsAndPeriodsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwAllLeadsWithCallsAndPeriodsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwAllLeadsWithCallsAndPeriods"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwAllLeadsWithCallsAndPeriodsQuery : VwAllLeadsWithCallsAndPeriodsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwAllLeadsWithCallsAndPeriodsQuery class.
		/// </summary>
		public VwAllLeadsWithCallsAndPeriodsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwAllLeadsWithCallsAndPeriodsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwAllLeadsWithCallsAndPeriodsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwAllLeadsWithCallsAndPeriodsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwAllLeadsWithCallsAndPeriodsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwAllLeadsWithCallsAndPeriodsQuery
		
	#region VwBaseLeadContactInFutureFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadContactInFuture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadContactInFutureFilters : VwBaseLeadContactInFutureFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadContactInFutureFilters class.
		/// </summary>
		public VwBaseLeadContactInFutureFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadContactInFutureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadContactInFutureFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadContactInFutureFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadContactInFutureFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadContactInFutureFilters
	
	#region VwBaseLeadContactInFutureQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwBaseLeadContactInFutureParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadContactInFuture"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadContactInFutureQuery : VwBaseLeadContactInFutureParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadContactInFutureQuery class.
		/// </summary>
		public VwBaseLeadContactInFutureQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadContactInFutureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadContactInFutureQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadContactInFutureQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadContactInFutureQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadContactInFutureQuery
		
	#region VwBaseLeadGetLessThanThreeCallsInPeriodFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetLessThanThreeCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetLessThanThreeCallsInPeriodFilters : VwBaseLeadGetLessThanThreeCallsInPeriodFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanThreeCallsInPeriodFilters class.
		/// </summary>
		public VwBaseLeadGetLessThanThreeCallsInPeriodFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanThreeCallsInPeriodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadGetLessThanThreeCallsInPeriodFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanThreeCallsInPeriodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadGetLessThanThreeCallsInPeriodFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadGetLessThanThreeCallsInPeriodFilters
	
	#region VwBaseLeadGetLessThanThreeCallsInPeriodQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwBaseLeadGetLessThanThreeCallsInPeriodParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetLessThanThreeCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetLessThanThreeCallsInPeriodQuery : VwBaseLeadGetLessThanThreeCallsInPeriodParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanThreeCallsInPeriodQuery class.
		/// </summary>
		public VwBaseLeadGetLessThanThreeCallsInPeriodQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanThreeCallsInPeriodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadGetLessThanThreeCallsInPeriodQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanThreeCallsInPeriodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadGetLessThanThreeCallsInPeriodQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadGetLessThanThreeCallsInPeriodQuery
		
	#region VwBaseLeadGetLessThanTwoCallsInPeriodFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetLessThanTwoCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetLessThanTwoCallsInPeriodFilters : VwBaseLeadGetLessThanTwoCallsInPeriodFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanTwoCallsInPeriodFilters class.
		/// </summary>
		public VwBaseLeadGetLessThanTwoCallsInPeriodFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanTwoCallsInPeriodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadGetLessThanTwoCallsInPeriodFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanTwoCallsInPeriodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadGetLessThanTwoCallsInPeriodFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadGetLessThanTwoCallsInPeriodFilters
	
	#region VwBaseLeadGetLessThanTwoCallsInPeriodQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwBaseLeadGetLessThanTwoCallsInPeriodParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetLessThanTwoCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetLessThanTwoCallsInPeriodQuery : VwBaseLeadGetLessThanTwoCallsInPeriodParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanTwoCallsInPeriodQuery class.
		/// </summary>
		public VwBaseLeadGetLessThanTwoCallsInPeriodQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanTwoCallsInPeriodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadGetLessThanTwoCallsInPeriodQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetLessThanTwoCallsInPeriodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadGetLessThanTwoCallsInPeriodQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadGetLessThanTwoCallsInPeriodQuery
		
	#region VwBaseLeadGetWithNoActivityIn60DaysFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetWithNoActivityIn60Days"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetWithNoActivityIn60DaysFilters : VwBaseLeadGetWithNoActivityIn60DaysFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityIn60DaysFilters class.
		/// </summary>
		public VwBaseLeadGetWithNoActivityIn60DaysFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityIn60DaysFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadGetWithNoActivityIn60DaysFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityIn60DaysFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadGetWithNoActivityIn60DaysFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadGetWithNoActivityIn60DaysFilters
	
	#region VwBaseLeadGetWithNoActivityIn60DaysQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwBaseLeadGetWithNoActivityIn60DaysParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetWithNoActivityIn60Days"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetWithNoActivityIn60DaysQuery : VwBaseLeadGetWithNoActivityIn60DaysParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityIn60DaysQuery class.
		/// </summary>
		public VwBaseLeadGetWithNoActivityIn60DaysQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityIn60DaysQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadGetWithNoActivityIn60DaysQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityIn60DaysQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadGetWithNoActivityIn60DaysQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadGetWithNoActivityIn60DaysQuery
		
	#region VwBaseLeadGetWithNoActivityInNdaysFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetWithNoActivityInNdays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetWithNoActivityInNdaysFilters : VwBaseLeadGetWithNoActivityInNdaysFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityInNdaysFilters class.
		/// </summary>
		public VwBaseLeadGetWithNoActivityInNdaysFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityInNdaysFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadGetWithNoActivityInNdaysFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityInNdaysFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadGetWithNoActivityInNdaysFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadGetWithNoActivityInNdaysFilters
	
	#region VwBaseLeadGetWithNoActivityInNdaysQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwBaseLeadGetWithNoActivityInNdaysParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetWithNoActivityInNdays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetWithNoActivityInNdaysQuery : VwBaseLeadGetWithNoActivityInNdaysParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityInNdaysQuery class.
		/// </summary>
		public VwBaseLeadGetWithNoActivityInNdaysQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityInNdaysQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadGetWithNoActivityInNdaysQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetWithNoActivityInNdaysQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadGetWithNoActivityInNdaysQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadGetWithNoActivityInNdaysQuery
		
	#region VwBaseLeadGetZeroCallsInPeriodFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetZeroCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetZeroCallsInPeriodFilters : VwBaseLeadGetZeroCallsInPeriodFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetZeroCallsInPeriodFilters class.
		/// </summary>
		public VwBaseLeadGetZeroCallsInPeriodFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetZeroCallsInPeriodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadGetZeroCallsInPeriodFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetZeroCallsInPeriodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadGetZeroCallsInPeriodFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadGetZeroCallsInPeriodFilters
	
	#region VwBaseLeadGetZeroCallsInPeriodQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwBaseLeadGetZeroCallsInPeriodParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwBaseLeadGetZeroCallsInPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwBaseLeadGetZeroCallsInPeriodQuery : VwBaseLeadGetZeroCallsInPeriodParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetZeroCallsInPeriodQuery class.
		/// </summary>
		public VwBaseLeadGetZeroCallsInPeriodQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetZeroCallsInPeriodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwBaseLeadGetZeroCallsInPeriodQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwBaseLeadGetZeroCallsInPeriodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwBaseLeadGetZeroCallsInPeriodQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwBaseLeadGetZeroCallsInPeriodQuery
		
	#region VwCallableLeadsWithCallsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsFilters : VwCallableLeadsWithCallsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsFilters class.
		/// </summary>
		public VwCallableLeadsWithCallsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsFilters
	
	#region VwCallableLeadsWithCallsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwCallableLeadsWithCallsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsQuery : VwCallableLeadsWithCallsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsQuery class.
		/// </summary>
		public VwCallableLeadsWithCallsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsQuery
		
	#region VwCallableLeadsWithCallsAndHourAdjFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndHourAdjFilters : VwCallableLeadsWithCallsAndHourAdjFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjFilters class.
		/// </summary>
		public VwCallableLeadsWithCallsAndHourAdjFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndHourAdjFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndHourAdjFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndHourAdjFilters
	
	#region VwCallableLeadsWithCallsAndHourAdjQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwCallableLeadsWithCallsAndHourAdjParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndHourAdj"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndHourAdjQuery : VwCallableLeadsWithCallsAndHourAdjParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjQuery class.
		/// </summary>
		public VwCallableLeadsWithCallsAndHourAdjQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndHourAdjQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndHourAdjQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndHourAdjQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndHourAdjQuery
		
	#region VwCallableLeadsWithCallsAndPeriodFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodFilters : VwCallableLeadsWithCallsAndPeriodFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodFilters class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndPeriodFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndPeriodFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndPeriodFilters
	
	#region VwCallableLeadsWithCallsAndPeriodQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwCallableLeadsWithCallsAndPeriodParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriod"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodQuery : VwCallableLeadsWithCallsAndPeriodParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodQuery class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndPeriodQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndPeriodQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndPeriodQuery
		
	#region VwCallableLeadsWithCallsAndPeriodsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriods"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodsFilters : VwCallableLeadsWithCallsAndPeriodsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsFilters class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndPeriodsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndPeriodsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndPeriodsFilters
	
	#region VwCallableLeadsWithCallsAndPeriodsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwCallableLeadsWithCallsAndPeriodsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwCallableLeadsWithCallsAndPeriods"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallableLeadsWithCallsAndPeriodsQuery : VwCallableLeadsWithCallsAndPeriodsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsQuery class.
		/// </summary>
		public VwCallableLeadsWithCallsAndPeriodsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallableLeadsWithCallsAndPeriodsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallableLeadsWithCallsAndPeriodsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallableLeadsWithCallsAndPeriodsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallableLeadsWithCallsAndPeriodsQuery
		
	#region VwCallsByUserFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwCallsByUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallsByUserFilters : VwCallsByUserFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserFilters class.
		/// </summary>
		public VwCallsByUserFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallsByUserFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallsByUserFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallsByUserFilters
	
	#region VwCallsByUserQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwCallsByUserParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwCallsByUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwCallsByUserQuery : VwCallsByUserParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserQuery class.
		/// </summary>
		public VwCallsByUserQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwCallsByUserQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwCallsByUserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwCallsByUserQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwCallsByUserQuery
		
	#region VwDeferedLeadsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwDeferedLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwDeferedLeadsFilters : VwDeferedLeadsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsFilters class.
		/// </summary>
		public VwDeferedLeadsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwDeferedLeadsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwDeferedLeadsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwDeferedLeadsFilters
	
	#region VwDeferedLeadsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwDeferedLeadsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwDeferedLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwDeferedLeadsQuery : VwDeferedLeadsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsQuery class.
		/// </summary>
		public VwDeferedLeadsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwDeferedLeadsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwDeferedLeadsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwDeferedLeadsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwDeferedLeadsQuery
		
	#region VwHoldAndCallWithLeadInfoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwHoldAndCallWithLeadInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwHoldAndCallWithLeadInfoFilters : VwHoldAndCallWithLeadInfoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoFilters class.
		/// </summary>
		public VwHoldAndCallWithLeadInfoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwHoldAndCallWithLeadInfoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwHoldAndCallWithLeadInfoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwHoldAndCallWithLeadInfoFilters
	
	#region VwHoldAndCallWithLeadInfoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwHoldAndCallWithLeadInfoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwHoldAndCallWithLeadInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwHoldAndCallWithLeadInfoQuery : VwHoldAndCallWithLeadInfoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoQuery class.
		/// </summary>
		public VwHoldAndCallWithLeadInfoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwHoldAndCallWithLeadInfoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwHoldAndCallWithLeadInfoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwHoldAndCallWithLeadInfoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwHoldAndCallWithLeadInfoQuery
		
	#region VwLastCallCreatedFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastCallCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastCallCreatedFilters : VwLastCallCreatedFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedFilters class.
		/// </summary>
		public VwLastCallCreatedFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLastCallCreatedFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLastCallCreatedFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLastCallCreatedFilters
	
	#region VwLastCallCreatedQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLastCallCreatedParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLastCallCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastCallCreatedQuery : VwLastCallCreatedParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedQuery class.
		/// </summary>
		public VwLastCallCreatedQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLastCallCreatedQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLastCallCreatedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLastCallCreatedQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLastCallCreatedQuery
		
	#region VwLastEmailCreatedFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLastEmailCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastEmailCreatedFilters : VwLastEmailCreatedFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedFilters class.
		/// </summary>
		public VwLastEmailCreatedFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLastEmailCreatedFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLastEmailCreatedFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLastEmailCreatedFilters
	
	#region VwLastEmailCreatedQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLastEmailCreatedParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLastEmailCreated"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLastEmailCreatedQuery : VwLastEmailCreatedParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedQuery class.
		/// </summary>
		public VwLastEmailCreatedQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLastEmailCreatedQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLastEmailCreatedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLastEmailCreatedQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLastEmailCreatedQuery
		
	#region VwLeadCallCountsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadCallCounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadCallCountsFilters : VwLeadCallCountsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsFilters class.
		/// </summary>
		public VwLeadCallCountsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadCallCountsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadCallCountsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadCallCountsFilters
	
	#region VwLeadCallCountsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadCallCountsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadCallCounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadCallCountsQuery : VwLeadCallCountsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsQuery class.
		/// </summary>
		public VwLeadCallCountsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadCallCountsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadCallCountsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadCallCountsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadCallCountsQuery
		
	#region VwLeadContactToolFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactTool"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolFilters : VwLeadContactToolFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolFilters class.
		/// </summary>
		public VwLeadContactToolFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadContactToolFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadContactToolFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadContactToolFilters
	
	#region VwLeadContactToolQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadContactToolParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadContactTool"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolQuery : VwLeadContactToolParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolQuery class.
		/// </summary>
		public VwLeadContactToolQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadContactToolQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadContactToolQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadContactToolQuery
		
	#region VwLeadContactToolCompleteFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadContactToolComplete"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolCompleteFilters : VwLeadContactToolCompleteFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteFilters class.
		/// </summary>
		public VwLeadContactToolCompleteFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadContactToolCompleteFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadContactToolCompleteFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadContactToolCompleteFilters
	
	#region VwLeadContactToolCompleteQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadContactToolCompleteParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadContactToolComplete"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadContactToolCompleteQuery : VwLeadContactToolCompleteParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteQuery class.
		/// </summary>
		public VwLeadContactToolCompleteQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadContactToolCompleteQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadContactToolCompleteQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadContactToolCompleteQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadContactToolCompleteQuery
		
	#region VwLeadGetFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetFilters : VwLeadGetFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetFilters class.
		/// </summary>
		public VwLeadGetFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetFilters
	
	#region VwLeadGetQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadGetParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadGet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetQuery : VwLeadGetParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetQuery class.
		/// </summary>
		public VwLeadGetQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetQuery
		
	#region VwLeadGetAlexFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetAlex"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetAlexFilters : VwLeadGetAlexFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetAlexFilters class.
		/// </summary>
		public VwLeadGetAlexFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetAlexFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetAlexFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetAlexFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetAlexFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetAlexFilters
	
	#region VwLeadGetAlexQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadGetAlexParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadGetAlex"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetAlexQuery : VwLeadGetAlexParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetAlexQuery class.
		/// </summary>
		public VwLeadGetAlexQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetAlexQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetAlexQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetAlexQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetAlexQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetAlexQuery
		
	#region VwLeadGetCraigFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetCraig"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetCraigFilters : VwLeadGetCraigFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetCraigFilters class.
		/// </summary>
		public VwLeadGetCraigFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetCraigFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetCraigFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetCraigFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetCraigFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetCraigFilters
	
	#region VwLeadGetCraigQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadGetCraigParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadGetCraig"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetCraigQuery : VwLeadGetCraigParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetCraigQuery class.
		/// </summary>
		public VwLeadGetCraigQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetCraigQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetCraigQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetCraigQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetCraigQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetCraigQuery
		
	#region VwLeadGetJennFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetJenn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetJennFilters : VwLeadGetJennFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJennFilters class.
		/// </summary>
		public VwLeadGetJennFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJennFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetJennFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJennFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetJennFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetJennFilters
	
	#region VwLeadGetJennQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadGetJennParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadGetJenn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetJennQuery : VwLeadGetJennParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJennQuery class.
		/// </summary>
		public VwLeadGetJennQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJennQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetJennQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJennQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetJennQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetJennQuery
		
	#region VwLeadGetJoEllenFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetJoEllen"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetJoEllenFilters : VwLeadGetJoEllenFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJoEllenFilters class.
		/// </summary>
		public VwLeadGetJoEllenFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJoEllenFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetJoEllenFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJoEllenFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetJoEllenFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetJoEllenFilters
	
	#region VwLeadGetJoEllenQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadGetJoEllenParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadGetJoEllen"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetJoEllenQuery : VwLeadGetJoEllenParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJoEllenQuery class.
		/// </summary>
		public VwLeadGetJoEllenQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJoEllenQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetJoEllenQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetJoEllenQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetJoEllenQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetJoEllenQuery
		
	#region VwLeadGetNextFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetNext"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetNextFilters : VwLeadGetNextFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextFilters class.
		/// </summary>
		public VwLeadGetNextFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetNextFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetNextFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetNextFilters
	
	#region VwLeadGetNextQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadGetNextParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadGetNext"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetNextQuery : VwLeadGetNextParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextQuery class.
		/// </summary>
		public VwLeadGetNextQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetNextQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetNextQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetNextQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetNextQuery
		
	#region VwLeadGetRichardFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadGetRichard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetRichardFilters : VwLeadGetRichardFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetRichardFilters class.
		/// </summary>
		public VwLeadGetRichardFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetRichardFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetRichardFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetRichardFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetRichardFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetRichardFilters
	
	#region VwLeadGetRichardQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadGetRichardParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadGetRichard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadGetRichardQuery : VwLeadGetRichardParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadGetRichardQuery class.
		/// </summary>
		public VwLeadGetRichardQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetRichardQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadGetRichardQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadGetRichardQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadGetRichardQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadGetRichardQuery
		
	#region VwLeadHoldAndCallFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadHoldAndCallFilters : VwLeadHoldAndCallFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallFilters class.
		/// </summary>
		public VwLeadHoldAndCallFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadHoldAndCallFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadHoldAndCallFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadHoldAndCallFilters
	
	#region VwLeadHoldAndCallQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadHoldAndCallParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadHoldAndCallQuery : VwLeadHoldAndCallParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallQuery class.
		/// </summary>
		public VwLeadHoldAndCallQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadHoldAndCallQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadHoldAndCallQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadHoldAndCallQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadHoldAndCallQuery
		
	#region VwLeadsAndCallsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsAndCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsAndCallsFilters : VwLeadsAndCallsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsFilters class.
		/// </summary>
		public VwLeadsAndCallsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadsAndCallsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadsAndCallsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadsAndCallsFilters
	
	#region VwLeadsAndCallsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadsAndCallsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadsAndCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsAndCallsQuery : VwLeadsAndCallsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsQuery class.
		/// </summary>
		public VwLeadsAndCallsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadsAndCallsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsAndCallsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadsAndCallsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadsAndCallsQuery
		
	#region VwLeadsWithAllStatusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithAllStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsWithAllStatusFilters : VwLeadsWithAllStatusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusFilters class.
		/// </summary>
		public VwLeadsWithAllStatusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadsWithAllStatusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadsWithAllStatusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadsWithAllStatusFilters
	
	#region VwLeadsWithAllStatusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadsWithAllStatusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithAllStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsWithAllStatusQuery : VwLeadsWithAllStatusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusQuery class.
		/// </summary>
		public VwLeadsWithAllStatusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadsWithAllStatusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithAllStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadsWithAllStatusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadsWithAllStatusQuery
		
	#region VwLeadsWithCallableStatusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithCallableStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsWithCallableStatusFilters : VwLeadsWithCallableStatusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithCallableStatusFilters class.
		/// </summary>
		public VwLeadsWithCallableStatusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithCallableStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadsWithCallableStatusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithCallableStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadsWithCallableStatusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadsWithCallableStatusFilters
	
	#region VwLeadsWithCallableStatusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwLeadsWithCallableStatusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwLeadsWithCallableStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwLeadsWithCallableStatusQuery : VwLeadsWithCallableStatusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithCallableStatusQuery class.
		/// </summary>
		public VwLeadsWithCallableStatusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithCallableStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwLeadsWithCallableStatusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwLeadsWithCallableStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwLeadsWithCallableStatusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwLeadsWithCallableStatusQuery
		
	#region VwManualReturnsListFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwManualReturnsList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwManualReturnsListFilters : VwManualReturnsListFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualReturnsListFilters class.
		/// </summary>
		public VwManualReturnsListFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwManualReturnsListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwManualReturnsListFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwManualReturnsListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwManualReturnsListFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwManualReturnsListFilters
	
	#region VwManualReturnsListQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwManualReturnsListParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwManualReturnsList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwManualReturnsListQuery : VwManualReturnsListParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualReturnsListQuery class.
		/// </summary>
		public VwManualReturnsListQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwManualReturnsListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwManualReturnsListQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwManualReturnsListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwManualReturnsListQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwManualReturnsListQuery
		
	#region VwManualSalesListFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwManualSalesList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwManualSalesListFilters : VwManualSalesListFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListFilters class.
		/// </summary>
		public VwManualSalesListFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwManualSalesListFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwManualSalesListFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwManualSalesListFilters
	
	#region VwManualSalesListQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwManualSalesListParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwManualSalesList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwManualSalesListQuery : VwManualSalesListParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListQuery class.
		/// </summary>
		public VwManualSalesListQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwManualSalesListQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwManualSalesListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwManualSalesListQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwManualSalesListQuery
		
	#region VwMaxLeadHoldAndCallFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwMaxLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwMaxLeadHoldAndCallFilters : VwMaxLeadHoldAndCallFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallFilters class.
		/// </summary>
		public VwMaxLeadHoldAndCallFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwMaxLeadHoldAndCallFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwMaxLeadHoldAndCallFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwMaxLeadHoldAndCallFilters
	
	#region VwMaxLeadHoldAndCallQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwMaxLeadHoldAndCallParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwMaxLeadHoldAndCall"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwMaxLeadHoldAndCallQuery : VwMaxLeadHoldAndCallParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallQuery class.
		/// </summary>
		public VwMaxLeadHoldAndCallQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwMaxLeadHoldAndCallQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwMaxLeadHoldAndCallQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwMaxLeadHoldAndCallQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwMaxLeadHoldAndCallQuery
		
	#region VwReportingLeadsAndSalesBoardFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingLeadsAndSalesBoard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingLeadsAndSalesBoardFilters : VwReportingLeadsAndSalesBoardFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardFilters class.
		/// </summary>
		public VwReportingLeadsAndSalesBoardFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingLeadsAndSalesBoardFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingLeadsAndSalesBoardFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingLeadsAndSalesBoardFilters
	
	#region VwReportingLeadsAndSalesBoardQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwReportingLeadsAndSalesBoardParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwReportingLeadsAndSalesBoard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingLeadsAndSalesBoardQuery : VwReportingLeadsAndSalesBoardParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardQuery class.
		/// </summary>
		public VwReportingLeadsAndSalesBoardQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingLeadsAndSalesBoardQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingLeadsAndSalesBoardQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingLeadsAndSalesBoardQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingLeadsAndSalesBoardQuery
		
	#region VwReportingSalesInfoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingSalesInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingSalesInfoFilters : VwReportingSalesInfoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoFilters class.
		/// </summary>
		public VwReportingSalesInfoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingSalesInfoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingSalesInfoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingSalesInfoFilters
	
	#region VwReportingSalesInfoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwReportingSalesInfoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwReportingSalesInfo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingSalesInfoQuery : VwReportingSalesInfoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoQuery class.
		/// </summary>
		public VwReportingSalesInfoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingSalesInfoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingSalesInfoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingSalesInfoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingSalesInfoQuery
		
	#region VwReportingZohoCallsConnectedAfterDateFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwReportingZohoCallsConnectedAfterDate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingZohoCallsConnectedAfterDateFilters : VwReportingZohoCallsConnectedAfterDateFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateFilters class.
		/// </summary>
		public VwReportingZohoCallsConnectedAfterDateFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingZohoCallsConnectedAfterDateFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingZohoCallsConnectedAfterDateFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingZohoCallsConnectedAfterDateFilters
	
	#region VwReportingZohoCallsConnectedAfterDateQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwReportingZohoCallsConnectedAfterDateParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwReportingZohoCallsConnectedAfterDate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwReportingZohoCallsConnectedAfterDateQuery : VwReportingZohoCallsConnectedAfterDateParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateQuery class.
		/// </summary>
		public VwReportingZohoCallsConnectedAfterDateQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwReportingZohoCallsConnectedAfterDateQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwReportingZohoCallsConnectedAfterDateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwReportingZohoCallsConnectedAfterDateQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwReportingZohoCallsConnectedAfterDateQuery
		
	#region VwSalesStatsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwSalesStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwSalesStatsFilters : VwSalesStatsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsFilters class.
		/// </summary>
		public VwSalesStatsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwSalesStatsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwSalesStatsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwSalesStatsFilters
	
	#region VwSalesStatsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwSalesStatsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwSalesStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwSalesStatsQuery : VwSalesStatsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsQuery class.
		/// </summary>
		public VwSalesStatsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwSalesStatsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwSalesStatsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwSalesStatsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwSalesStatsQuery
		
	#region VwZohoCallsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoCallsFilters : VwZohoCallsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsFilters class.
		/// </summary>
		public VwZohoCallsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoCallsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoCallsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoCallsFilters
	
	#region VwZohoCallsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwZohoCallsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwZohoCalls"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoCallsQuery : VwZohoCallsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsQuery class.
		/// </summary>
		public VwZohoCallsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoCallsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoCallsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoCallsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoCallsQuery
		
	#region VwZohoLeadsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsFilters : VwZohoLeadsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsFilters class.
		/// </summary>
		public VwZohoLeadsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsFilters
	
	#region VwZohoLeadsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwZohoLeadsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwZohoLeads"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsQuery : VwZohoLeadsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsQuery class.
		/// </summary>
		public VwZohoLeadsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsQuery
		
	#region VwZohoLeadsNeedingActionTodayFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsNeedingActionToday"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsNeedingActionTodayFilters : VwZohoLeadsNeedingActionTodayFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsNeedingActionTodayFilters class.
		/// </summary>
		public VwZohoLeadsNeedingActionTodayFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsNeedingActionTodayFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsNeedingActionTodayFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsNeedingActionTodayFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsNeedingActionTodayFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsNeedingActionTodayFilters
	
	#region VwZohoLeadsNeedingActionTodayQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwZohoLeadsNeedingActionTodayParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsNeedingActionToday"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsNeedingActionTodayQuery : VwZohoLeadsNeedingActionTodayParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsNeedingActionTodayQuery class.
		/// </summary>
		public VwZohoLeadsNeedingActionTodayQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsNeedingActionTodayQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsNeedingActionTodayQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsNeedingActionTodayQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsNeedingActionTodayQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsNeedingActionTodayQuery
		
	#region VwZohoLeadsWithLocalTimeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeFilters : VwZohoLeadsWithLocalTimeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeFilters class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsWithLocalTimeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsWithLocalTimeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsWithLocalTimeFilters
	
	#region VwZohoLeadsWithLocalTimeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwZohoLeadsWithLocalTimeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeQuery : VwZohoLeadsWithLocalTimeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeQuery class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsWithLocalTimeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsWithLocalTimeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsWithLocalTimeQuery
		
	#region VwZohoLeadsWithLocalTimeNoActionTodayFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionToday"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeNoActionTodayFilters : VwZohoLeadsWithLocalTimeNoActionTodayFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayFilters class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeNoActionTodayFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsWithLocalTimeNoActionTodayFilters
	
	#region VwZohoLeadsWithLocalTimeNoActionTodayQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwZohoLeadsWithLocalTimeNoActionTodayParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionToday"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeNoActionTodayQuery : VwZohoLeadsWithLocalTimeNoActionTodayParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayQuery class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeNoActionTodayQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsWithLocalTimeNoActionTodayQuery
		
	#region VwZohoLeadsWithLocalTimeNoActionTodayCallableFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeNoActionTodayCallableFilters : VwZohoLeadsWithLocalTimeNoActionTodayCallableFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableFilters class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsWithLocalTimeNoActionTodayCallableFilters
	
	#region VwZohoLeadsWithLocalTimeNoActionTodayCallableQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VwZohoLeadsWithLocalTimeNoActionTodayCallable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VwZohoLeadsWithLocalTimeNoActionTodayCallableQuery : VwZohoLeadsWithLocalTimeNoActionTodayCallableParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableQuery class.
		/// </summary>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VwZohoLeadsWithLocalTimeNoActionTodayCallableQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VwZohoLeadsWithLocalTimeNoActionTodayCallableQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VwZohoLeadsWithLocalTimeNoActionTodayCallableQuery
	#endregion

	
}
