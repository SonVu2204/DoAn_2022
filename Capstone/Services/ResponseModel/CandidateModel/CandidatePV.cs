using Services.ResponseModel.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.CandidateModel
{
    public class CandidatePV
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? RequestId { get; set; }
        public int? Step1 { get; set; }
        public string NoteStep1 { get; set; }
        public int? Step2InterView { get; set; }
        public string NoteStepInterView2 { get; set; }
        public int? Step2Test { get; set; }
        public string NoteStep2Test { get; set; }
        public decimal? ResultStep3Test { get; set; }
        public string NoteRstep3Test { get; set; }
        public int? ResultStep3InterView { get; set; }
        public string NoteRstep3InterView { get; set; }
        public decimal? CtyOffer { get; set; }
        public string NoteCtyOffer { get; set; }
        public decimal? Uvoffer { get; set; }
        public string NoteUvoffer { get; set; }
        public string NoteFinalOffer { get; set; }
        public decimal? FinalOffer { get; set; }
        public int? Step4Result { get; set; }
        public int? Step5Result { get; set; }
        public int? StepNow { get; set; }
        public int? Result { get; set; }
    }

    public class CandidatePV_infor
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public string Project { get; set; }
        public string Department { get; set; }
        public int? PositionId { get; set; }
        public string Position { get; set; }
        public int? StepNow { get; set; }
        public int? Result { get; set; }
        public int? OrgId { get; set; }
        public int? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string NoiSinh { get; set; }
        public int? NationOb { get; set; }
        public int? ProvinceOb { get; set; }
        public int? DistrictOb { get; set; }
        public int? WardOb { get; set; }
        public string CMND { get; set; }
        public string CMNDPlace { get; set; }

        public string NoiO { get; set; }
        public int? NationLive { get; set; }
        public int? ProvinceLive { get; set; }
        public int? DistrictLive { get; set; }
        public int? WardLive { get; set; }
        public decimal? Step3Test { get; set; }
        public decimal? Step3Score { get; set; }
        public string Step3TestNote { get; set; }
        public string Step3InterNote { get; set; }
        public string Offer { get; set; }
        public string NoteOffer { get; set; }
    }
    public class SetStep1
    {
        public int? CandidateId { get; set; }
        public int? RequestId { get; set; }
        public int? Step1 { get; set; }
        public string NoteStep1 { get; set; }
        // 
    }
  
    public class SetStep2
    {
        public int? CandidateId { get; set; }
        public int? RequestId { get; set; }
        public int? Step2InterView { get; set; }
        public string NoteStepInterView2 { get; set; }
        public int? Step2Test { get; set; }
        public string NoteStep2Test { get; set; }
    }
    public class SetStep3
    {
        public int? CandidateId { get; set; }
        public int? RequestId { get; set; }
        public decimal? ResultStep3Test { get; set; }
        public string NoteRstep3Test { get; set; }
        public int? ResultStep3InterView { get; set; }
        public string NoteRstep3InterView { get; set; }
    }
    public class SetStep4
    {
        public int? CandidateId { get; set; }
        public int? RequestId { get; set; }
   
        public string NoteFinalOffer { get; set; }
        public decimal? FinalOffer { get; set; }
        public int? Step4Result { get; set; }
    }

    public class SetStep5
    {
        public int? CandidateId { get; set; }
        public int? RequestId { get; set; }
        public int? Step5Result { get; set; }
    }
    public class InforCandidateEdit
    {
        // trong ban rccandidate
        public int ID { get; set; }
        public string FullName { get; set; }
        // trong bang rccandidatecv
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
        public string Phone { get; set; }
        public string Zalo { get; set; }
        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Skype { get; set; }
        public string Website { get; set; }
        public string Twiter { get; set; }
        public string NoiO { get; set; }
        public int? NationLive { get; set; }
        public int? PorvinceLive { get; set; }


        // trong bang rccandidate Edu
        public string Major { get; set; }
        public DateTime? Graduate { get; set; }
        public string School { get; set; }
        public Decimal? Gpa { get; set; }
        public string Awards { get; set; }


    }
    public class CandidateEdit
    {
        public int ID { get; set; }
        public string Phone { get; set; }
 
        public string Email { get; set; }
    }
    public class ResultStep3
    {
        public int? CandidateID { get; set; }
        public int? RequestID { get; set; }
        public string Name { get; set; }
        public List<ScheduleRes> InterView { get; set; }
        public List<ScheduleRes> Test { get; set; }

    }
    public class PassStep3
    {
        public int? CandidateID { get; set; }
        public int? RequestID { get; set; }
        public int? Result { get; set; }
    }

}
