using AutoLotDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models
{
    public partial class Order : EntityBase
    {
        public int Customerld { get; set; }
        public int CarId { get; set; }
        [ForeignKey(nameof(Customerld))]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(CarId))]
        public virtual Inventory Car { get; set; }
    }
}
