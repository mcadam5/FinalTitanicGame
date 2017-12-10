using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class ShipObjects
    {

        public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new TravelerObject
            {
                Id = 1,
                Name = "Bag of Gold",
                LocationId = 2,
                Description = "A small leather pouch filled with 9 gold coins.",
                Type = TravelerObjectType.BagOfGold,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 2,
                Name = "Silver Satphire Necklace",
                LocationId = 3,
                Description = "A large dark blue stone, encased in a silver chain .",
                Type = TravelerObjectType.Necklace,
                Value = 4500,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 3,
                Name = "Pneumonia Medicine",
                LocationId = 3,
                Description = "A wooden box containing a small vial filled with a clear liquid.",
                Type = TravelerObjectType.Medicine,
                Value = 45,
                CanInventory = false,
                IsConsumable = true,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 4,
                Name = "April-1915 Titanic Document",
                LocationId = 5,
                Description =
                    "Memo: End of the Titanic" + "/n" +
                    "Universal Date: 15-04-1915" + "/n" +
                    "/n" +
                    "In the early hours of April 15, 1915, the Titanic has completely sunk."+ "\n"+
                    "The cause for the ships sinking has been detemined damage to starbord compartments from impact with an ice berg",
                Type = TravelerObjectType.Document,
                Value = 10,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 5,
                Name = "Room Key ",
                LocationId = 1,
                Description ="Bronze Key.",
                Type = TravelerObjectType.Key,
                Value = 65,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 6,
                Name = "Travel Key",
                LocationId = 3,
                Description ="Silver Key.",
                Type = TravelerObjectType.Key,
                Value = 85,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 7,
                Name = "Time Key",
                LocationId = 4,
                Description ="Gold Key.",
                Type = TravelerObjectType.Key,
                Value = 105,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 8,
                Name = "Meal Card ",
                LocationId = 1,
                Description ="Standard issued card for the basic meal requirments.",
                Type = TravelerObjectType.MealCard,
                Value = 60,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new TravelerObject
            {
                Id = 9,
                Name = "Life Support Bar",
                LocationId = 1,
                Description = "Standard bar of essential life support.",
                Type = TravelerObjectType.Food,
                Value = 10,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            }

        };

    }
}
