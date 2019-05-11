using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MusicBands.Models
{
    public class Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group()
        {
            this.MUSICIANS_IN_GROUPS = new HashSet<Musicians_in_groups>();
            this.SONGS = new HashSet<Song>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  ID { get; set; }
        [Display(Name = "Band Name")]
        public string GR_NAME { get; set; }
        [ForeignKey("PRODUCER")]
        [Display(Name = "№ Producer")]
        public Nullable<int> PR_ID { get; set; }

        public virtual Producer PRODUCER { get; set; }
        [NotMapped]
        [Display(Name = "Musians in groups")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musicians_in_groups> MUSICIANS_IN_GROUPS { get; set; }

        [NotMapped]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Song> SONGS { get; set; }
    }
}
