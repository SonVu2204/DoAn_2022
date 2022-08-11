using ModelAuto.Models;
using Services.ResponseModel.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ScheduleServices
{
    public interface ISchedule
    {
        #region Lịch thi , lịch PV
        List<RcEvent> getSchedule(int requestId, int candidateId);
        bool InsertSchedule(RcEvent T);
        bool ModifySchedule(RcEvent T);
        bool DeleteSchedule(List<int> listID);

        bool CheckTime(RcEvent T);
        #endregion

        List<ScheduleRes> GettoAddStep3Interview(int candidate, int request);
        List<ScheduleRes> GettoAddStep3Test(int candidate, int request);
    }
}
