using System.Collections.Generic;

namespace EFCoreWebApi_CRUD.Models{
    public static class Repository{
        public static List<Actor> Actors()
        {
            List<Actor> actors= new List<Actor>();
            actors.Add(new Actor{Actor_ID=1,First_Name="PENELOPE",Last_Name="GUINESS"});
            actors.Add(new Actor{Actor_ID=2,First_Name="NICK",Last_Name="WAHLBERG"});
            actors.Add(new Actor{Actor_ID=3,First_Name="ED",Last_Name="CHASE"});
            actors.Add(new Actor{Actor_ID=4,First_Name="JENNIFER",Last_Name="DAVIS"});

            return actors;

        }
    }
}