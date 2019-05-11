using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MusicBands.Models
{
    public class Musician
    {
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musician()
        {
            this.MUSICIANS_IN_GROUPS = new HashSet<Musicians_in_groups>();
            this.Instruments = new HashSet<Instruments>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Musician Name")]
        public string MS_NAME { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime MS_BIRTH_DATE { get; set; }
        [Display(Name = "Year in Band")]
        public int MS_YEAR { get; set; }
        [Display(Name = "Sex")]
        public string MS_SEX { get; set; }

        [NotMapped]
        [Display(Name = "Groups")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musicians_in_groups> MUSICIANS_IN_GROUPS { get; set; }
        [NotMapped]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Instruments> Instruments { get; set; }
    }
}
