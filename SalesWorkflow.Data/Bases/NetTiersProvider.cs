#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using SalesWorkflow.Entities;

#endregion

namespace SalesWorkflow.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current ZohoLeadsProviderBase instance.
		///</summary>
		public virtual ZohoLeadsProviderBase ZohoLeadsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LeadContactedProviderBase instance.
		///</summary>
		public virtual LeadContactedProviderBase LeadContactedProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ZohoCallsProviderBase instance.
		///</summary>
		public virtual ZohoCallsProviderBase ZohoCallsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ZohoUsersProviderBase instance.
		///</summary>
		public virtual ZohoUsersProviderBase ZohoUsersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LeadHoldAndCallProviderBase instance.
		///</summary>
		public virtual LeadHoldAndCallProviderBase LeadHoldAndCallProvider{get {throw new NotImplementedException();}}
		
		
		///<summary>
		/// Current VwAllLeadsWithCallsAndPeriodsProviderBase instance.
		///</summary>
		public virtual VwAllLeadsWithCallsAndPeriodsProviderBase VwAllLeadsWithCallsAndPeriodsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwBaseLeadContactInFutureProviderBase instance.
		///</summary>
		public virtual VwBaseLeadContactInFutureProviderBase VwBaseLeadContactInFutureProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwBaseLeadGetLessThanThreeCallsInPeriodProviderBase instance.
		///</summary>
		public virtual VwBaseLeadGetLessThanThreeCallsInPeriodProviderBase VwBaseLeadGetLessThanThreeCallsInPeriodProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwBaseLeadGetLessThanTwoCallsInPeriodProviderBase instance.
		///</summary>
		public virtual VwBaseLeadGetLessThanTwoCallsInPeriodProviderBase VwBaseLeadGetLessThanTwoCallsInPeriodProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwBaseLeadGetWithNoActivityIn60DaysProviderBase instance.
		///</summary>
		public virtual VwBaseLeadGetWithNoActivityIn60DaysProviderBase VwBaseLeadGetWithNoActivityIn60DaysProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwBaseLeadGetWithNoActivityInNdaysProviderBase instance.
		///</summary>
		public virtual VwBaseLeadGetWithNoActivityInNdaysProviderBase VwBaseLeadGetWithNoActivityInNdaysProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwBaseLeadGetZeroCallsInPeriodProviderBase instance.
		///</summary>
		public virtual VwBaseLeadGetZeroCallsInPeriodProviderBase VwBaseLeadGetZeroCallsInPeriodProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwCallableLeadsWithCallsProviderBase instance.
		///</summary>
		public virtual VwCallableLeadsWithCallsProviderBase VwCallableLeadsWithCallsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwCallableLeadsWithCallsAndHourAdjProviderBase instance.
		///</summary>
		public virtual VwCallableLeadsWithCallsAndHourAdjProviderBase VwCallableLeadsWithCallsAndHourAdjProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwCallableLeadsWithCallsAndPeriodProviderBase instance.
		///</summary>
		public virtual VwCallableLeadsWithCallsAndPeriodProviderBase VwCallableLeadsWithCallsAndPeriodProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwCallableLeadsWithCallsAndPeriodsProviderBase instance.
		///</summary>
		public virtual VwCallableLeadsWithCallsAndPeriodsProviderBase VwCallableLeadsWithCallsAndPeriodsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwCallsByUserProviderBase instance.
		///</summary>
		public virtual VwCallsByUserProviderBase VwCallsByUserProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwDeferedLeadsProviderBase instance.
		///</summary>
		public virtual VwDeferedLeadsProviderBase VwDeferedLeadsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwHoldAndCallWithLeadInfoProviderBase instance.
		///</summary>
		public virtual VwHoldAndCallWithLeadInfoProviderBase VwHoldAndCallWithLeadInfoProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLastCallCreatedProviderBase instance.
		///</summary>
		public virtual VwLastCallCreatedProviderBase VwLastCallCreatedProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLastEmailCreatedProviderBase instance.
		///</summary>
		public virtual VwLastEmailCreatedProviderBase VwLastEmailCreatedProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadCallCountsProviderBase instance.
		///</summary>
		public virtual VwLeadCallCountsProviderBase VwLeadCallCountsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadContactToolProviderBase instance.
		///</summary>
		public virtual VwLeadContactToolProviderBase VwLeadContactToolProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadContactToolCompleteProviderBase instance.
		///</summary>
		public virtual VwLeadContactToolCompleteProviderBase VwLeadContactToolCompleteProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadGetProviderBase instance.
		///</summary>
		public virtual VwLeadGetProviderBase VwLeadGetProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadGetAlexProviderBase instance.
		///</summary>
		public virtual VwLeadGetAlexProviderBase VwLeadGetAlexProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadGetCraigProviderBase instance.
		///</summary>
		public virtual VwLeadGetCraigProviderBase VwLeadGetCraigProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadGetJennProviderBase instance.
		///</summary>
		public virtual VwLeadGetJennProviderBase VwLeadGetJennProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadGetJoEllenProviderBase instance.
		///</summary>
		public virtual VwLeadGetJoEllenProviderBase VwLeadGetJoEllenProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadGetNextProviderBase instance.
		///</summary>
		public virtual VwLeadGetNextProviderBase VwLeadGetNextProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadGetRichardProviderBase instance.
		///</summary>
		public virtual VwLeadGetRichardProviderBase VwLeadGetRichardProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadHoldAndCallProviderBase instance.
		///</summary>
		public virtual VwLeadHoldAndCallProviderBase VwLeadHoldAndCallProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadsAndCallsProviderBase instance.
		///</summary>
		public virtual VwLeadsAndCallsProviderBase VwLeadsAndCallsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadsWithAllStatusProviderBase instance.
		///</summary>
		public virtual VwLeadsWithAllStatusProviderBase VwLeadsWithAllStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwLeadsWithCallableStatusProviderBase instance.
		///</summary>
		public virtual VwLeadsWithCallableStatusProviderBase VwLeadsWithCallableStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwManualReturnsListProviderBase instance.
		///</summary>
		public virtual VwManualReturnsListProviderBase VwManualReturnsListProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwManualSalesListProviderBase instance.
		///</summary>
		public virtual VwManualSalesListProviderBase VwManualSalesListProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwMaxLeadHoldAndCallProviderBase instance.
		///</summary>
		public virtual VwMaxLeadHoldAndCallProviderBase VwMaxLeadHoldAndCallProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwReportingLeadsAndSalesBoardProviderBase instance.
		///</summary>
		public virtual VwReportingLeadsAndSalesBoardProviderBase VwReportingLeadsAndSalesBoardProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwReportingSalesInfoProviderBase instance.
		///</summary>
		public virtual VwReportingSalesInfoProviderBase VwReportingSalesInfoProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwReportingZohoCallsConnectedAfterDateProviderBase instance.
		///</summary>
		public virtual VwReportingZohoCallsConnectedAfterDateProviderBase VwReportingZohoCallsConnectedAfterDateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwSalesStatsProviderBase instance.
		///</summary>
		public virtual VwSalesStatsProviderBase VwSalesStatsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwZohoCallsProviderBase instance.
		///</summary>
		public virtual VwZohoCallsProviderBase VwZohoCallsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwZohoLeadsProviderBase instance.
		///</summary>
		public virtual VwZohoLeadsProviderBase VwZohoLeadsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwZohoLeadsNeedingActionTodayProviderBase instance.
		///</summary>
		public virtual VwZohoLeadsNeedingActionTodayProviderBase VwZohoLeadsNeedingActionTodayProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwZohoLeadsWithLocalTimeProviderBase instance.
		///</summary>
		public virtual VwZohoLeadsWithLocalTimeProviderBase VwZohoLeadsWithLocalTimeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwZohoLeadsWithLocalTimeNoActionTodayProviderBase instance.
		///</summary>
		public virtual VwZohoLeadsWithLocalTimeNoActionTodayProviderBase VwZohoLeadsWithLocalTimeNoActionTodayProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VwZohoLeadsWithLocalTimeNoActionTodayCallableProviderBase instance.
		///</summary>
		public virtual VwZohoLeadsWithLocalTimeNoActionTodayCallableProviderBase VwZohoLeadsWithLocalTimeNoActionTodayCallableProvider{get {throw new NotImplementedException();}}
		
	}
}
