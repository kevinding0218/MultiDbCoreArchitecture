using Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ArchitectMain
{
    public class DrugProperties : IAuditableEntity
    {
        public int NDCID { get; set; }
        public string NDC { get; set; }
        public string NDCDesc { get; set; }
        public string DrugClass { get; set; }
        public string Units { get; set; }
        public string Equivalency { get; set; }
        public int? IsBrand { get; set; }
        public int? IsOrphan { get; set; }
        public int? IsNotDrug { get; set; }
        public int? Is340BEligible { get; set; }
        public DateTime? Is340BEligibleDate { get; set; }
        public int? IsPrivateLabel { get; set; }
        public double? BUPP { get; set; }
        public DateTime? Effective { get; set; }
        public DateTime DateAdded { get; set; }
        public int AddedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }

        public string FullDescription => $"{NDC} - {DrugClass} - {NDCDesc}";
    }
}
