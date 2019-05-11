using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBands.Models
{
    public class ALBUMS
    {
        public ALBUMS()
        {
            this.SONGS = new HashSet<Song>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name="Album Name")]
        public string AL_NAME { get; set; }
        [Display(Name = "Album Year")]
        public string AL_YEAR { get; set; }
        [Display(Name = "Songs")]
        public virtual ICollection<Song> SONGS { get; set; }
    }
}
