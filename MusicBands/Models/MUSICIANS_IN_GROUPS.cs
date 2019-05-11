using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBands.Models
{
    public class Musicians_in_groups
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("MUSICIAN")]
        [Display(Name = "№ Musician")]
        public int MS_ID { get; set; }
        [ForeignKey("GROUP")]
        [Display(Name = "№ Band")]
        public int GR_ID { get; set; }
        public Nullable<int> MUC_YEAR { get; set; }
        public string MUS_LYEAR { get; set; }

        public virtual Group GROUP { get; set; }
        public virtual Musician MUSICIAN { get; set; }
    }
}
