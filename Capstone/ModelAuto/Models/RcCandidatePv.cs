using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcCandidatePv
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

        public virtual RcCandidate Candidate { get; set; }
        public virtual RcRequest Request { get; set; }
    }
}
