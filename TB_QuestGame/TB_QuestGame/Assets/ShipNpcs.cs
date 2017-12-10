using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class ShipObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
             new Civilian
            {
                Id = 1,
                Name = "Sandy Berg",
                LocationID = 1,
                Description = "Small second class woman standing in the commoners area looking out the window.",
                Messages = new List<string>
                {
                    "Looks like it might be a Butiful day today.",
                    "My Donny always said some people don't believe in hero's," +
                    "\n"+
                    "But those people haven't met me! "
                }
            },

              new Civilian
            {
                Id = 2,
                Name = "Jack",
                LocationID = 2,
                Description = "Young man with a puzzled look upon his face.",
                Messages = new List<string>
                {
                    "Word on the deck is if you have a meal card you have full access to the kitchen!",
                    "Rose? Who's Rose?"
                }
            },

            new Civilian
            {
                Id = 3,
                Name = "Kitchen Chef",
                LocationID = 3,
                Description = "A tall man with dark hair dark eyes and a chef suit.",
                Messages = new List<string>
                {
                    "You want me to give you access to the Grand Dining Room?" +
                    $"Hahaha What makes you think I can do that?",
                    "Alright I'll make you a deal. You bring me a bag of gold" +
                    "and I will get you into the Grand Dining Room",
                    "You got the gold?"
                }
            },

            new Civilian
            {
                Id = 4,
                Name = "Rose Mathews",
                LocationID = 4,
                Description = "A high class woman wearing a floor length navy blue dress.",
                Messages = new List<string>
                {
                    "Excuse me sir, have you seen my silver satphire necklace?",
                    "Sure I can get you the Captains Office if you find my necklace. ",
                }
            },

            new Civilian
            {
                Id = 5,
                Name = "Captain John Burkley",
                LocationID = 5,
                Description = "A high class shipsman in charge of directing the Titanic.",
                Messages = new List<string>
                {
                    "HAHAHAHA this ship is not going to sink!",
                    "You've lost your mind. I think I would know if there was an ice berg in our way.",
                    
                }
            },
            new Civilian
            {
                Id = 6,
                Name = "Marcel",
                LocationID = 2,
                Description = "A small monkey sitting atop a small bench.",
                Messages = new List<string>
                {
                    "The Captian seems to be missing.",
                    "Tell no one of this conversation. ",
                }
            },
        };
    }
}
