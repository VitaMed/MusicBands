using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBands.Models
{
    public class Instruments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        //[ForeignKey("MUSICIAN")]
        [Display(Name = "№ Musician")]
        public int MS_ID { get; set; }
        //[ForeignKey("GROUP")]
        [Display(Name = "№ Instruments")]
        public int TYPE_ID { get; set; }
    
        public virtual Musician MUSICIAN { get; set; }
        public virtual Type_of_instruments Type_Of_Instruments { get; set; }
    }
}
