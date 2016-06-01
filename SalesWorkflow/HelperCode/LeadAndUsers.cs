using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiH_SalesWorkflow.Entities;
using SiH_SalesWorkflow.Data;

namespace SalesWorkflow.HelperCode
{
    public class LeadContactedHelper
    {
        public int TodaysCallCount(String UserId)
        {
            TList<LeadContacted> lc = DataRepository.LeadContactedProvider.GetAll();
            return lc.Count;
        }
    }
    public class LeadAndUsers
    {
        public int TodaysCallCount(String UserId)
        {

            String whereClause = String.Format("User_Id = '{0}' and DateAdd(HH, -8,[LeadActionDts]) > '{1}' AND [LeadCalled]=1", UserId, DateTime.UtcNow.AddHours(-8).Date);
            String orderByClause = "[LeadHoldDts] Desc, [LeadActionDts] Desc";
            VList<VwLeadHoldAndCall> vlhc = DataRepository.VwLeadHoldAndCallProvider.Get(whereClause, orderByClause);
            return vlhc.Count;

        }
        public int TodaysDeferCount(String UserId)
        {

            String whereClause = String.Format("User_Id = '{0}' and DateAdd(HH, -8,[LeadActionDts]) > '{1}' AND [LeadDefered]=1", UserId, DateTime.UtcNow.AddHours(-8).Date);
            String orderByClause = "[LeadHoldDts] Desc, [LeadActionDts] Desc";
            VList<VwLeadHoldAndCall> vlhc = DataRepository.VwLeadHoldAndCallProvider.Get(whereClause, orderByClause);
            return vlhc.Count;

        }


        public VList<VwHoldAndCallWithLeadInfo> TodaysCalls(String UserId)
        {

            String whereClause = String.Format("User_Id = '{0}' and DateAdd(HH, -8,[LeadActionDts]) > '{1}' AND [LeadCalled]=1", UserId, DateTime.UtcNow.AddHours(-8).Date);
            String orderByClause = "[LeadActionDts] Desc";
            VList<VwHoldAndCallWithLeadInfo> vhcli = DataRepository.VwHoldAndCallWithLeadInfoProvider.Get(whereClause, orderByClause);
            
            return vhcli;

        }
        public VList<VwHoldAndCallWithLeadInfo> TodaysDefers(String UserId)
        {

            String whereClause = String.Format("User_Id = '{0}' and DateAdd(HH, -8,[LeadActionDts]) > '{1}' AND [LeadDefered]=1", UserId, DateTime.UtcNow.AddHours(-8).Date);
            String orderByClause = " [LeadActionDts] Desc";
            VList<VwHoldAndCallWithLeadInfo> vhcli = DataRepository.VwHoldAndCallWithLeadInfoProvider.Get(whereClause, orderByClause);

            return vhcli;

        }


        public SiH_SalesWorkflow.Entities.LeadHoldAndCall LastLeadHoldAndCall(String UserId, String LeadId)
        {
            
            String whereClause = String.Format("User_Id = '{0}' and LeadId = '{1}'",UserId,LeadId);
            String orderByCaluse = "[LeadHoldDts] Desc, [LeadActionDts] Desc";
            VList<VwLeadHoldAndCall> vlhc = DataRepository.VwLeadHoldAndCallProvider.Get(whereClause,orderByCaluse);
            if (vlhc.Count > 0)
                return DataRepository.LeadHoldAndCallProvider.GetByLeadHoldAndCallPk(vlhc[0].LeadHoldAndCallPk);
            else
                return null;

        }
        public SiH_SalesWorkflow.Entities.LeadHoldAndCall LastLeadHoldAndNullCall(String UserId, String LeadId)
        {

            String whereClause = String.Format("User_Id = '{0}' and LeadId = '{1}'  [LeadActionDts] is null", UserId, LeadId);
            String orderByCaluse = "[LeadHoldDts] Desc, [LeadActionDts] Desc";
            VList<VwLeadHoldAndCall> vlhc = DataRepository.VwLeadHoldAndCallProvider.Get(whereClause, orderByCaluse);
            if (vlhc.Count > 0)
                return DataRepository.LeadHoldAndCallProvider.GetByLeadHoldAndCallPk(vlhc[0].LeadHoldAndCallPk);
            else
                return null;

        }
        public DateTime HoldLead(String UserId, String LeadId)
        {
            SiH_SalesWorkflow.Entities.LeadHoldAndCall LeadHoldAndCall = LastLeadHoldAndCall(UserId, LeadId);
            if(LeadHoldAndCall!=null)
            {
                LeadHoldAndCall.LeadHoldDts = DateTime.UtcNow.AddMinutes(30);
                DataRepository.LeadHoldAndCallProvider.Save(LeadHoldAndCall);
            }
            else
            {
                LeadHoldAndCall = new LeadHoldAndCall();
                LeadHoldAndCall.UserId = UserId;
                LeadHoldAndCall.Leadid = LeadId;
                LeadHoldAndCall.LeadHoldDts = DateTime.UtcNow.AddMinutes(30);
                DataRepository.LeadHoldAndCallProvider.Save(LeadHoldAndCall);
            }
            return Convert.ToDateTime(LeadHoldAndCall.LeadHoldDts);
        }
        public void MarkLeadCalled(String UserId, String LeadId)
        {
            SiH_SalesWorkflow.Entities.LeadHoldAndCall LeadHoldAndCall = LastLeadHoldAndCall(UserId, LeadId);
            if (LeadHoldAndCall != null)
            {
                
                LeadHoldAndCall.LeadActionDts = DateTime.UtcNow.AddMinutes(0);
                LeadHoldAndCall.LeadCalled = true;
                LeadHoldAndCall.LeadDefered = false;
                DataRepository.LeadHoldAndCallProvider.Save(LeadHoldAndCall);
            }
            else
            {
                LeadHoldAndCall = new LeadHoldAndCall();
                LeadHoldAndCall.UserId = UserId;
                LeadHoldAndCall.Leadid = LeadId;
                LeadHoldAndCall.LeadHoldDts = DateTime.UtcNow.AddMinutes(0);
                LeadHoldAndCall.LeadCalled = true;
                LeadHoldAndCall.LeadDefered = false;
                LeadHoldAndCall.LeadActionDts = DateTime.UtcNow.AddMinutes(0);
                DataRepository.LeadHoldAndCallProvider.Save(LeadHoldAndCall);
            }
            
        }
        public void MarkLeadDefered(String UserId, String LeadId)
        {
            SiH_SalesWorkflow.Entities.LeadHoldAndCall LeadHoldAndCall = LastLeadHoldAndCall(UserId, LeadId);
            if (LeadHoldAndCall != null)
            {

                LeadHoldAndCall.LeadActionDts = DateTime.UtcNow.AddMinutes(0);
                LeadHoldAndCall.LeadCalled = false;
                LeadHoldAndCall.LeadDefered = true;
                DataRepository.LeadHoldAndCallProvider.Save(LeadHoldAndCall);
            }
            else
            {
                LeadHoldAndCall = new LeadHoldAndCall();
                LeadHoldAndCall.UserId = UserId;
                LeadHoldAndCall.Leadid = LeadId;
                LeadHoldAndCall.LeadHoldDts = DateTime.UtcNow.AddMinutes(0);
                LeadHoldAndCall.LeadCalled = false;
                LeadHoldAndCall.LeadDefered = true;
                LeadHoldAndCall.LeadActionDts = DateTime.UtcNow.AddMinutes(0);
                DataRepository.LeadHoldAndCallProvider.Save(LeadHoldAndCall);
            }

        }
    }
}