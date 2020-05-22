using System.ComponentModel.DataAnnotations.Schema;
using AutoLotDAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace AutoLotDAL.Models
{
    public partial class CreditRisk : EntityBase
    {
        [StringLength(50)]
        [Index("IDX_CreditRisk_Name", IsUnique = true, Order = 2)]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Index("IDX_CreditRisk_Name", IsUnique = true, Order = 1)]    
        public string LastName { get; set; }
    }
}
