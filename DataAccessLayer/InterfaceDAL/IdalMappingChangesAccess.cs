using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.DataAccessLayer.InterfaceDAL
{
    public interface IdalMappingChangesAccess
    {
        List<MappingChangesAccessDetail> GetMappingChangesAccess(MappingChangeAccessSearch objsearch);
        List<Purpose> GetPurpose();
        Response InsertMappingChangeAccess(MappingChangesAccessDetail emp);
        Response InsertMappingChangeAccess_INST(MappingChangesAccessDetail emp);
        List<StageDetails> GetStage();
        List<MappingCriteria> GetMappingCriteria();
        Response CompleteTransactionActivity(ActivityCompleteDetails objAct);
        Response FinalSubmission(List<FinalSubmissionDetails> obj);

        Response FinalSubmissionINST(List<FinalSubmissionDetails> obj);
        Response UpdateSplitData(List<SplitMappingData> obj);
        Response MoveDatatoProduction(List<FinalSubmissionDetails> obj);
        Response Save_action(MappingChangesAccessDetail objModel);
    }
}