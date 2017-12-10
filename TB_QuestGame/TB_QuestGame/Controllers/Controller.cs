using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Traveler _gameTraveler;
        private Ship _gameShip;
        private bool _playingGame;
        private Location _currentLocation;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameTraveler = new Traveler();
            _gameShip = new Ship();
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameShip);
            TravelerObject travelerObject;
            _playingGame = true;

            foreach (GameObject gameObject in _gameShip.GameObjects)
            {
                if (gameObject is TravelerObject)
                {
                    travelerObject = gameObject as TravelerObject;
                    travelerObject.ObjectAddedToInventory += HandleObjectAddedToInventory;
                }
            }
            
            //add items to travelers invy
            //
            _gameTraveler.Inventory.Add(_gameShip.GetGameObjectById(8) as TravelerObject);
            _gameTraveler.Inventory.Add(_gameShip.GetGameObjectById(9) as TravelerObject);


            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");
            _currentLocation = _gameShip.GetLocationByID(_gameTraveler.LocationID);

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                //process flags, events, stats
                //
                UpdateGameStatus();

                //
                // get next game action from player
                //

                travelerActionChoice = GetNextTravelerAction();

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case TravelerAction.None:
                        break;

                    case TravelerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();

                        break;

                    case TravelerAction.Travel:

                        //
                        // new location choice and update current location
                        //
                        _gameTraveler.LocationID = _gameConsoleView.DisplayGetNextLocation();
                        _currentLocation = _gameShip.GetLocationByID(_gameTraveler.LocationID);

                        //
                        // set screen to current location format 
                        //
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

                        break;

                    case TravelerAction.TravelerMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.TravelerMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Traveler Menu", "Select an Opertation from the Menu.", ActionMenu.TravelerMenu, "");

                        break;

                    case TravelerAction.TravelerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;

                    case TravelerAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    case TravelerAction.TravelerLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;

                    case TravelerAction.ObjectMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Object Menu", "Select an Opertation from the Menu.", ActionMenu.ObjectMenu, "");

                        break;

                    case TravelerAction.LookAt:
                        LookAtAction();
                        break;

                    case TravelerAction.PickUp:
                        PickUpAction();
                        break;

                    case TravelerAction.PutDown:
                        PutDownAction();
                        break;

                    case TravelerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an Opertation from the menu.", ActionMenu.AdminMenu, "");

                        break;

                    case TravelerAction.ListLocations:
                        _gameConsoleView.DisplayListOfLocations();
                        break;

                    case TravelerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case TravelerAction.ListNonPlayerCharacters:
                        _gameConsoleView.DisplayListOfAllNpcObjects();
                        break;

                    case TravelerAction.NonplayerCharacterMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Non-Player Character Menu", "Select an Opertation from the menu.", ActionMenu.NpcMenu, "");
                        break;

                    case TravelerAction.TalkTo:
                        TalkToAction();
                        break;

                    case TravelerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case TravelerAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Traveler traveler = _gameConsoleView.GetInitialTravelerInfo();

            _gameTraveler.Name = traveler.Name;
            _gameTraveler.Age = traveler.Age;
            _gameTraveler.Ethnicity = traveler.Ethnicity;
            _gameTraveler.HomeLocation = traveler.HomeLocation;
            _gameTraveler.LocationID = 1;

            _gameTraveler.Experiencepoints = 0;
            _gameTraveler.Health = 100;
            _gameTraveler.Lives = 3;
        }

        private void UpdateGameStatus()
        {
            if (!_gameTraveler.HasVisited(_currentLocation.LocationID))
            {
                //
                // new location to list of visited if first visit
                //
                _gameTraveler.LocationsVisited.Add(_currentLocation.LocationID);

                //
                //update Experience Points
                //
                _gameTraveler.Experiencepoints += _currentLocation.ExperiencePoints;
            }

            if (_gameTraveler.LocationID == 2)
            {
                _gameTraveler.Health += 50;
            }

            if (_gameTraveler.Health <= 0)
            {
                _gameTraveler.Lives -= 1;
            }

            if (_gameTraveler.Health > 100)
            {
                _gameTraveler.Lives += 1;
                _gameTraveler.Health = 100;
            }
            //if (_gameTraveler.Inventory = _gameShip.GameObjects.Contains())
            //{

            //}
        }

        public void LookAtAction()
        {
            //
            //display list of  traveler objects space-time location -- get a player choice
            //

            int gameObjetToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            //game object info
            //

            if (gameObjetToLookAtId != 0)
            {
                //
                //get object form universe
                //
                
                GameObject gameObject = _gameShip.GetGameObjectById(gameObjetToLookAtId);

                //
                //display information for object
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }

        private void PickUpAction()
        {
            //
            //Display list of traveler objects in location
            //
            int travelerObjectToPickUpId = _gameConsoleView.DisplayGetTravlerObjectToPickUp();

            //
            //add to inventory
            //
            if (travelerObjectToPickUpId != 0)
            {
                //
                //get game object from universe
                //
                TravelerObject travelerObject = _gameShip.GetGameObjectById(travelerObjectToPickUpId) as TravelerObject;

                //
                //set object location to 0
                //
                _gameTraveler.Inventory.Add(travelerObject);
                travelerObject.LocationId = 0;

                //
                //confirm
                //
                _gameConsoleView.DisplayConfirmTravelerObjectAddedToInventory(travelerObject);

            }
        }

        private void PutDownAction()
        {
            //
            //display list of objects in inventory 
            //
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            //get object from universe
            //
            TravelerObject travelerObject = _gameShip.GetGameObjectById(inventoryObjectToPutDownId) as TravelerObject;

            //
            //remove from inventory
            //
            _gameTraveler.Inventory.Remove(travelerObject);
            travelerObject.LocationId = _gameTraveler.LocationID;

            //
            //confirmation
            //
            _gameConsoleView.DisplayConfirmTravelerObjectAddedToInventory(travelerObject);
        }

        private TravelerAction GetNextTravelerAction()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;

                case ActionMenu.CurrentMenu.TravelerMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.TravelerMenu);
                    break;

                case ActionMenu.CurrentMenu.ObjectMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ObjectMenu);
                    break;

                case ActionMenu.CurrentMenu.NpcMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;

                case ActionMenu.CurrentMenu.AdminMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;

                default:
                    break;
            }

            return travelerActionChoice;
        }

        private void HandleObjectAddedToInventory(object gameObject, EventArgs e)
        {
            if (gameObject.GetType() == typeof(TravelerObject))
            {
                TravelerObject travelerObject = gameObject as TravelerObject;
                switch (travelerObject.Type)
                {
                    case TravelerObjectType.Food:
                        _gameTraveler.Health += travelerObject.Value;

                        //
                        //adds life if > than 100
                        //
                        if (_gameTraveler.Health >= 100)
                        {
                            _gameTraveler.Health = 100;
                            _gameTraveler.Lives -= 1;
                        }
                        if (travelerObject.IsConsumable)
                        {
                            travelerObject.LocationId = -1;
                        }

                        break;

                    case TravelerObjectType.MealCard:
                        if (true)
                        {
                            _gameShip.GetLocationByID(3).Accessable = true;
                        }

                        break;

                    case TravelerObjectType.Medicine:
                        _gameTraveler.Health += travelerObject.Value;

                        //
                        //adds life if > than 100
                        //
                        if (_gameTraveler.Health >=100)
                        {
                            _gameTraveler.Health = 100;
                            _gameTraveler.Lives += 1;
                        }
                        if (travelerObject.IsConsumable)
                        {
                            travelerObject.LocationId = -1;
                        }

                        break;

                    case TravelerObjectType.BagOfGold:

                        break;

                    case TravelerObjectType.Necklace:

                        if (true)
                        {
                            _gameShip.GetLocationByID(3).Accessable = true;
                            _gameShip.GetLocationByID(1).Accessable = false;
                        }

                        break;

                    case TravelerObjectType.Document:

                        //wins game

                        if (true)
                        {

                        }
                        break;

                    case TravelerObjectType.Key:
                        //
                        //all three keys unlocks Captains office
                        //

                        //if (_gameTraveler.Inventory.Contains(TravelerObjectType.Key = 3))
                        //{
                        //    _gameShip.GetLocationByID(5).Accessable = true;
                        //}
                        break;
                    default:
                        break;
                }
            }
        }

        private void TalkToAction()
        {
            //
            // display list NPCs in location and get player choice
            //
            int npcToTalkToId = _gameConsoleView.DisplayGetNpcToTalkTo();

            //
            // display NPC's message
            //
            if (npcToTalkToId != 0)
            {
                //
                // get the NPC from the ship
                //
                Npc npc = _gameShip.GetNpcById(npcToTalkToId);

                //
                // display information for the chosen
                //
                _gameConsoleView.DisplayTalkTo(npc);
            }
        }
        #endregion
    }
}
