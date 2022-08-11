using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class OtherList
    {
        public OtherList()
        {
            EmployeeCvDanTocNavigations = new HashSet<EmployeeCv>();
            EmployeeCvGenderNavigations = new HashSet<EmployeeCv>();
            EmployeeEduInforMaticsLevel1Navigations = new HashSet<EmployeeEdu>();
            EmployeeEduInforMaticsLevel2Navigations = new HashSet<EmployeeEdu>();
            EmployeeEduInforMaticsLevel3Navigations = new HashSet<EmployeeEdu>();
            EmployeeEduLanguage1Navigations = new HashSet<EmployeeEdu>();
            EmployeeEduLanguage2Navigations = new HashSet<EmployeeEdu>();
            EmployeeEduLanguage3Navigations = new HashSet<EmployeeEdu>();
            EmployeeEduLearningLevelNavigations = new HashSet<EmployeeEdu>();
            EmployeeFamilies = new HashSet<EmployeeFamily>();
            Employees = new HashSet<Employee>();
            PositionFormWorkingNavigations = new HashSet<Position>();
            PositionInformationLevelNavigations = new HashSet<Position>();
            PositionLanguageLevelNavigations = new HashSet<Position>();
            PositionLanguageNavigations = new HashSet<Position>();
            PositionLearningLevelNavigations = new HashSet<Position>();
            PositionMajorGroupNavigations = new HashSet<Position>();
            RcCandidateEduDeeGree1Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduDeeGree2Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduDeeGree3Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduInforMaticsLevel1Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduInforMaticsLevel2Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduInforMaticsLevel3Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduLanguage1Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduLanguage2Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduLanguage3Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduLearningLevelNavigations = new HashSet<RcCandidateEdu>();
            RcCandidateExps = new HashSet<RcCandidateExp>();
            RcCandidateFamilies = new HashSet<RcCandidateFamily>();
            RcCandidateSkillLevelNavigations = new HashSet<RcCandidateSkill>();
            RcCandidateSkillTypeNavigations = new HashSet<RcCandidateSkill>();
            RcRequestLevelNavigations = new HashSet<RcRequest>();
            RcRequestOtherSkillNavigations = new HashSet<RcRequest>();
            RcRequestProjectNavigations = new HashSet<RcRequest>();
            RcRequestRequestLevelNavigations = new HashSet<RcRequest>();
            RcRequestResultStatusContactNavigations = new HashSet<RcRequestResult>();
            RcRequestResultStatusRequestNavigations = new HashSet<RcRequestResult>();
            RcRequestScheduHinhThucNavigations = new HashSet<RcRequestSchedu>();
            RcRequestScheduStatusContactNavigations = new HashSet<RcRequestSchedu>();
            RcRequestTypeNavigations = new HashSet<RcRequest>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string Atribute1 { get; set; }
        public string Atribute2 { get; set; }
        public string Atribute3 { get; set; }
        public int? TypeId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual OtherListType Type { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvDanTocNavigations { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvGenderNavigations { get; set; }
        public virtual ICollection<EmployeeEdu> EmployeeEduInforMaticsLevel1Navigations { get; set; }
        public virtual ICollection<EmployeeEdu> EmployeeEduInforMaticsLevel2Navigations { get; set; }
        public virtual ICollection<EmployeeEdu> EmployeeEduInforMaticsLevel3Navigations { get; set; }
        public virtual ICollection<EmployeeEdu> EmployeeEduLanguage1Navigations { get; set; }
        public virtual ICollection<EmployeeEdu> EmployeeEduLanguage2Navigations { get; set; }
        public virtual ICollection<EmployeeEdu> EmployeeEduLanguage3Navigations { get; set; }
        public virtual ICollection<EmployeeEdu> EmployeeEduLearningLevelNavigations { get; set; }
        public virtual ICollection<EmployeeFamily> EmployeeFamilies { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Position> PositionFormWorkingNavigations { get; set; }
        public virtual ICollection<Position> PositionInformationLevelNavigations { get; set; }
        public virtual ICollection<Position> PositionLanguageLevelNavigations { get; set; }
        public virtual ICollection<Position> PositionLanguageNavigations { get; set; }
        public virtual ICollection<Position> PositionLearningLevelNavigations { get; set; }
        public virtual ICollection<Position> PositionMajorGroupNavigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduDeeGree1Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduDeeGree2Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduDeeGree3Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduInforMaticsLevel1Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduInforMaticsLevel2Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduInforMaticsLevel3Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduLanguage1Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduLanguage2Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduLanguage3Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduLearningLevelNavigations { get; set; }
        public virtual ICollection<RcCandidateExp> RcCandidateExps { get; set; }
        public virtual ICollection<RcCandidateFamily> RcCandidateFamilies { get; set; }
        public virtual ICollection<RcCandidateSkill> RcCandidateSkillLevelNavigations { get; set; }
        public virtual ICollection<RcCandidateSkill> RcCandidateSkillTypeNavigations { get; set; }
        public virtual ICollection<RcRequest> RcRequestLevelNavigations { get; set; }
        public virtual ICollection<RcRequest> RcRequestOtherSkillNavigations { get; set; }
        public virtual ICollection<RcRequest> RcRequestProjectNavigations { get; set; }
        public virtual ICollection<RcRequest> RcRequestRequestLevelNavigations { get; set; }
        public virtual ICollection<RcRequestResult> RcRequestResultStatusContactNavigations { get; set; }
        public virtual ICollection<RcRequestResult> RcRequestResultStatusRequestNavigations { get; set; }
        public virtual ICollection<RcRequestSchedu> RcRequestScheduHinhThucNavigations { get; set; }
        public virtual ICollection<RcRequestSchedu> RcRequestScheduStatusContactNavigations { get; set; }
        public virtual ICollection<RcRequest> RcRequestTypeNavigations { get; set; }
    }
}
