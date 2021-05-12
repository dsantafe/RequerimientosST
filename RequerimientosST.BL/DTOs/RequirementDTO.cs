namespace RequerimientosST.BL.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class RequirementDTO
    {
        public int ID { get; set; }

        [Display(Name = "Area")]
        public Nullable<int> AreaID { get; set; }

        [Display(Name = "Applicative")]
        public Nullable<int> ApplicativeID { get; set; }

        [Required]
        [Display(Name = "Scope Requirement")]
        public string ScopeRequirement { get; set; }

        [Display(Name = "Application Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public Nullable<System.DateTime> ApplicationDate { get; set; }

        [Display(Name = "Priority")]
        public Nullable<int> PriorityID { get; set; }

        [Display(Name = "Development Engineer")]
        public Nullable<int> DevelopmentEngineerID { get; set; }

        [Required]
        [Display(Name = "Development Days")]
        public Nullable<int> DevelopmentDays { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "Development Date")]
        public Nullable<System.DateTime> DevelopmentDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "Test Date")]
        public DateTime TestDate
        {
            get
            {
                return DevelopmentDate.Value.AddDays(DevelopmentDays.Value + (DevelopmentDays.Value * 0.5));
            }
        }

        public virtual ApplicativeDTO Applicative { get; set; }
        public virtual AreaDTO Area { get; set; }
        public virtual DevelopmentEngineerDTO DevelopmentEngineer { get; set; }
        public virtual PriorityDTO Priority { get; set; }
    }
}
