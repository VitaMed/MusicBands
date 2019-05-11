using System;
using System.Collections.Generic;
using System.Linq;
using MusicBands.Models;
using System.Threading.Tasks;

namespace MusicBands.Data
{
    public class DbInitializer
    {

        public static void Initialize(BandsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (!context.MUSICIANS.Any())
            {
                var musicians = new Musician[]
                {
                    new Musician { MS_NAME = "Tyler",MS_YEAR = 1990, MS_BIRTH_DATE = DateTime.Parse("1988-09-01"), MS_SEX = "f" },
                    new Musician { MS_NAME = "Norman", MS_SEX = "m", MS_YEAR = 1990, MS_BIRTH_DATE = DateTime.Parse("1977-11-15") },
                    new Musician { MS_NAME = "Cristoph", MS_SEX = "m", MS_YEAR = 1995, MS_BIRTH_DATE = DateTime.Parse("1981-04-22") },
                    new Musician { MS_NAME = "Tobby", MS_SEX = "m", MS_YEAR = 2003, MS_BIRTH_DATE = DateTime.Parse("1991-09-26") },
                    new Musician { MS_NAME = "Daniela", MS_SEX = "f", MS_YEAR = 1986, MS_BIRTH_DATE = DateTime.Parse("1969-02-28") },
                    new Musician { MS_NAME = "Rob", MS_SEX = "m", MS_YEAR = 2016, MS_BIRTH_DATE = DateTime.Parse("2000-12-01") },
                    new Musician { MS_NAME = "Matthew", MS_SEX = "m", MS_YEAR = 2008, MS_BIRTH_DATE = DateTime.Parse("1994-08-09") },
                    new Musician { MS_NAME = "Ross", MS_SEX = "m", MS_YEAR = 2000, MS_BIRTH_DATE = DateTime.Parse("1971-06-05") },
                    new Musician { MS_NAME = "Joey", MS_SEX = "f", MS_YEAR = 1999, MS_BIRTH_DATE = DateTime.Parse("1985-01-30") },
                    new Musician { MS_NAME = "Chendler", MS_SEX = "m", MS_YEAR = 2002, MS_BIRTH_DATE = DateTime.Parse("1989-09-27") },

                };
                foreach (Musician m in musicians)
                {
                    context.MUSICIANS.Add(m);
                }
                context.SaveChanges();

            }


            if (!context.ALBUMS.Any())
            {
                var albums = new ALBUMS[]
                {
                    new ALBUMS{AL_NAME = "LZ4", AL_YEAR = "1971"},
                    new ALBUMS{AL_NAME = "The Razor's Edge", AL_YEAR = "1990"},
                    new ALBUMS{AL_NAME = "Paranoid", AL_YEAR = "1970"},
                    new ALBUMS{AL_NAME = "Nevermind", AL_YEAR = "1991"},
                    new ALBUMS{AL_NAME = "Beggars Banquet", AL_YEAR = "1968"},
                    new ALBUMS{AL_NAME = "A Night at the Opera", AL_YEAR = "1975"},
                    new ALBUMS{AL_NAME = "The Wall", AL_YEAR = "1979"},
                    new ALBUMS{AL_NAME = "Metallica", AL_YEAR = "1991"},
                    new ALBUMS{AL_NAME = "Abbey Road", AL_YEAR = "1969"},
                    new ALBUMS{AL_NAME = "Machine Had", AL_YEAR = "1972"},
                };
                foreach (ALBUMS a in albums)
                {
                    context.ALBUMS.Add(a);
                }
                context.SaveChanges();
            }


            if (!context.PRODUCERS.Any())
            {
                var producers = new Producer[]
                {
                    new Producer{PR_NAME = "Max"},
                    new Producer{PR_NAME = "Allen"},
                    new Producer{PR_NAME = "Barry"},
                    new Producer{PR_NAME = "Sherlock"},
                    new Producer{PR_NAME = "Watson"},
                    new Producer{PR_NAME = "Max"},
                };
                foreach (Producer p in producers)
                {
                    context.PRODUCERS.Add(p);
                }
                context.SaveChanges();
            }

            if (!context.TYPE_OF_INSTRUMENTS.Any())
            {
                var type_instruments = new Type_of_instruments[]
                {
                    new Type_of_instruments{IN_NAME="drums"},
                    new Type_of_instruments{IN_NAME="solo-guitar"},
                    new Type_of_instruments{IN_NAME="lead-guitar"},
                    new Type_of_instruments{IN_NAME="bass"},
                    new Type_of_instruments{IN_NAME="violin"},
                    new Type_of_instruments{IN_NAME="accordion"},
                    new Type_of_instruments{IN_NAME="keys"},
                    new Type_of_instruments{IN_NAME="flute"},
                    new Type_of_instruments{IN_NAME="uculele"},
                    new Type_of_instruments{IN_NAME="double bass"},
                };
                foreach (Type_of_instruments t in type_instruments)
                {
                    context.TYPE_OF_INSTRUMENTS.Add(t);
                }
                context.SaveChanges();
            }


            if (!context.GROUPS.Any())
            {
                var groups = new Group[]
                {
                    new Group{GR_NAME = "Led Zeppelin", PR_ID=1},
                    new Group{GR_NAME = "AC/DC", PR_ID=2},
                    new Group{GR_NAME = "Black Sabbath", PR_ID=3},
                    new Group{GR_NAME = "Nirvana", PR_ID=4},
                    new Group{GR_NAME = "The Rolling Stones", PR_ID=5},
                    new Group{GR_NAME = "Queen", PR_ID=6},
                    new Group{GR_NAME = "Pink Floyd", PR_ID=7},
                    new Group{GR_NAME = "Metallica", PR_ID=8},
                    new Group{GR_NAME = "The Beatles", PR_ID=3},
                    new Group{GR_NAME = "Deep Purple", PR_ID=1},
                };
                foreach (Group g in groups)
                {
                    context.GROUPS.Add(g);
                }
                context.SaveChanges();
            }

            if (!context.SONGS.Any())
            {
                var songs = new Song[]
                 {
                    new Song{SN_NAME = "Stairway to Heaven", AL_ID=1,GR_ID=1,SN_YEAR=1971},
                    new Song{SN_NAME = "Thunderstruck", AL_ID=2,GR_ID=2,SN_YEAR=1990},
                    new Song{SN_NAME = "Iron Man", AL_ID=3,GR_ID=3,SN_YEAR=1970},
                    new Song{SN_NAME = "Smells Like Teen Spirit", AL_ID=4,GR_ID=4,SN_YEAR=1991},
                    new Song{SN_NAME = "Sympathy for the Devil", AL_ID=5,GR_ID=5,SN_YEAR=1968},
                    new Song{SN_NAME = "Bohemian Rhapsody", AL_ID=6,GR_ID=6,SN_YEAR=1975},
                    new Song{SN_NAME = "Comfortably Numb", AL_ID=7,GR_ID=7,SN_YEAR=1979},
                    new Song{SN_NAME = "Unforgiven", AL_ID=8,GR_ID=8,SN_YEAR=1991},
                    new Song{SN_NAME = "Come Together", AL_ID=9,GR_ID=9,SN_YEAR=1969},
                    new Song{SN_NAME = "Highway Star", AL_ID=10,GR_ID=10,SN_YEAR=1972},
                 };
                foreach (Song s in songs)
                {
                    context.SONGS.Add(s);
                }
                context.SaveChanges();
            }


            if (!context.MUSICIANS_IN_GROUPS.Any())
            {
                var mus_in = new Musicians_in_groups[]
                 {
                    new Musicians_in_groups{MS_ID=1,GR_ID=1},
                    new Musicians_in_groups{MS_ID=2,GR_ID=2},
                    new Musicians_in_groups{MS_ID=3,GR_ID=3},
                    new Musicians_in_groups{MS_ID=4,GR_ID=4},
                    new Musicians_in_groups{MS_ID=5,GR_ID=5},
                    new Musicians_in_groups{MS_ID=6,GR_ID=6},
                    new Musicians_in_groups{MS_ID=7,GR_ID=7},
                    new Musicians_in_groups{MS_ID=8,GR_ID=8},
                    new Musicians_in_groups{MS_ID=9,GR_ID=9},
                    new Musicians_in_groups{MS_ID=10,GR_ID=10},
                 };
                foreach (Musicians_in_groups ms in mus_in)
                {
                    context.MUSICIANS_IN_GROUPS.Add(ms);
                }
                context.SaveChanges();
            }

            if (!context.Instruments.Any())
            {
                var instr_in = new Instruments[]
                {
                    new Instruments{MS_ID=1,TYPE_ID=1},
                    new Instruments{MS_ID=2,TYPE_ID=2},
                    new Instruments{MS_ID=3,TYPE_ID=3},
                    new Instruments{MS_ID=4,TYPE_ID=4},
                    new Instruments{MS_ID=5,TYPE_ID=5},
                    new Instruments{MS_ID=6,TYPE_ID=6},
                    new Instruments{MS_ID=7,TYPE_ID=7},
                    new Instruments{MS_ID=8,TYPE_ID=8},
                    new Instruments{MS_ID=9,TYPE_ID=9},
                    new Instruments{MS_ID=10,TYPE_ID=10},
                };
                foreach (Instruments ms in instr_in)
                {
                    context.Instruments.Add(ms);
                }
                context.SaveChanges();
            }
        }
    }
}