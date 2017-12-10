using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame.Assets
{
     public static partial class ShipObjectsLocations
    {  
            public static List<Location> Locations = new List<Location>()
            {

                new Location
                {
                    CommonName = "Common Passener Rooms",
                    LocationID = 1,
                    UniversalDate = 4151915,
                    ShipLocation = "P-3, SS-278, G-2976, LS-3976",
                    Description = " Small rooms near the bottom of the ship, where the common passengers reside. ",
                    GeneralContents = "The room is small, and cold" +
                        " There are two small beds, a large desk, and two small lockers that make up the room.\n",
                    Accessable = true,
                    ExperiencePoints = 10
                },

                new Location
                {
                    CommonName = "Upper Deck",
                    LocationID = 2,
                    UniversalDate = 4151915,
                    ShipLocation = "P-2, SS-85, G-2976, LS-3976",
                    Description = "Top of the Ship where there are many different places to hang out and enjoy entertainment.",
                    GeneralContents = "A large deck where there are families enjoying daytime activies.",
                    Accessable = true,
                    ExperiencePoints = 10
                },

                new Location
                {
                    CommonName = "Kitchen",
                    LocationID = 3,
                    UniversalDate = 4151915,
                    ShipLocation = "P-6, SS-3978, G-2976, LS-3976",
                    Description = " The kitchen is large and well lit. " +
                                  "Where the cooks prepare for all meals for passengers and staff aboard the ship. ",
                    GeneralContents = "There are two large ovens, two sinks full of dishes, and being filled with the next meal." +
                    " There are many cooks running around, and one that seems to be making eye contact with you.",
                    Accessable = false,
                    ExperiencePoints = 30
                },

                  new Location
                  {
                    CommonName = "Grand Dining Room",
                    LocationID = 4,
                    UniversalDate = 4151915,
                    ShipLocation = "P-6, SS-3978, G-2976, LS-3976",
                    Description = "The Grand Dinning Room is where all passengers come to eat their next meal.",
                    GeneralContents =  " The grand dining room is lined with large tables. Set up for passengers" +
                                  " to eat their next meal.",
                    Accessable = false,
                    ExperiencePoints = 50
                  },

                  new Location
                  {
                        CommonName = "Captians Corridors",
                        LocationID = 5,
                        UniversalDate = 4151915,
                        ShipLocation = "P-6, SS-3978, G-2976, LS-3976",
                        Description = " A large room that is dimly lit and has a slightly fear filled atmosphere." +
                                            "Where the captains of the ship spend all of their time controlling the ship.",
                        GeneralContents = " With many control pannels keeping the ship up and running, " +
                                      "and both of the lead captians.",
                        Accessable = false,
                        ExperiencePoints = 70
                  }
            };
        }

    }

