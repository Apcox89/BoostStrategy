using System;

//A. Cox SD725-HW7

/* This is a simple use of different boosts that a Player
 * can utilize in the Technoprolis action-RPG. This could be imported
 * as a potential module for the a simple part of an action-menu in the game. 
 * 
 * For the UI, let's say the player hits the 'Boost-Strategy' button assigned to B on a console controller.
 * They could access this list of options on a timed type of availability in a game battle.
 * 
 * (Metaphor of Language)
 * My interpretation of the 7.2 Strategy lecture-code example is the statement:
 * "There are different ways to cook food."
 * -- 'ways': is the class methods
 * -- 'cook': is the activity or event being handled
 * -- 'food': is the data type
 * 
 * The 'BoostStrategy' example if it was a simple statement:
 * "There are different ways to boost a player."
 * -- 'ways': is the class methods
 * -- 'boost': is the activity or event being handled
 * -- 'player': is the data type
 *
 */

namespace BoostStrategy
{
    class Program
    {
        static void Main()
        {
            //instance of class BoostingMethod
            BoostingMethod boostMethod = new BoostingMethod();

            //condition to keep menu open or return to game
            while (true)
            {
                Console.WriteLine("You enter a game-battle with an option to receive a temporary boost now or save it, how do you proceed? type: " +
                    "\n 'boost' to access boost menu ('saveit' to return right back to battle) ");
                string input = Console.ReadLine();
                if (input == "saveit")
                {
                    break;
                }

                boostMethod.SetBoost(input);

                Console.WriteLine("Do you want to temporarily boost your player's 'Health', 'Damage', or 'Shield'?");
                string player = Console.ReadLine();

                Type p = Type.GetType("BoostStrategy." + player);

                PlayerBoost pBoost = (PlayerBoost)Activator.CreateInstance(p);

                boostMethod.SetPlayerBoost(pBoost);
                boostMethod.Boost();

                Console.WriteLine(" = = = = = = = = ");
               
            } 
            
        }
    }

    abstract class PlayerBoost
    {
        public abstract void Boost(string player);
    }

    class Health : PlayerBoost
    {
        public override void Boost(string player)
        {
            Console.WriteLine("\n  " + player + " applied to re-generate health points.");
        }
    }

    class Damage : PlayerBoost
    {
        public override void Boost(string player)
        {
            Console.WriteLine("\n  " + player + " applied to deal a damage boost to all weapons for 1 minute.");
        }
    }

    class Shield : PlayerBoost
    {
        public override void Boost(string player)
        {
            Console.WriteLine("\n  " + player + " applied to temporarily enhance the player's shield for 1 minute.");
        }
    }

    class BoostingMethod
    {
        private string Player;
        private PlayerBoost _playerBoost;

        public void SetPlayerBoost(PlayerBoost elixerBoost)
        {
            this._playerBoost = elixerBoost;
        }

        public void SetBoost(string name)
        {
            Player = name;
        }

        public void Boost()
        {
            _playerBoost.Boost(Player);
            Console.WriteLine();
        }
    }

}
