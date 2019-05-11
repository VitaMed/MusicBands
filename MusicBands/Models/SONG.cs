using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBands.Models
{
    public class Song
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Song Name")]
        public string SN_NAME { get; set; }
        [Display(Name = "Year")]
        public Nullable<int> SN_YEAR { get; set; }
        [Display(Name = "№ Band")]
        public int GR_ID { get; set; }
        [Display(Name = "№ Album")]
        public int AL_ID { get; set; }
        [Display(Name = "Album")]
        public virtual ALBUMS ALBUM { get; set; }
        [Display(Name = "Group")]
        public virtual Group GROUP { get; set; }
    }
}
