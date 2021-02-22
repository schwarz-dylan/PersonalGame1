using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary;

namespace PersonalGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The Battles Beyond The Misty Mountain";
            Console.WriteLine("Welcome to the battle of the Misty Mountains");
            string ascii = @"
                .                  .-.    .  _   *     _   .
           *          /   \     ((       _/ \       *    .
         _    .   .--'\/\_ \     `      /    \  *    ___
     *  / \_    _/ ^      \/\'__        /\/\  /\  __/   \ *
       /    \  /    .'   _/  /  \  *' /    \/  \/ .`'\_/\   .
  .   /\/\  /\/ :' __  ^/  ^/    `--./.'  ^  `-.\ _    _:\ _
     /    \/  \  _/  \-' __/.' ^ _   \_   .'\   _/ \ .  __/ \
   /\  .-   `. \/     \ / -.   _/ \ -. `_/   \ /    `._/  ^  \
  /  `-.__ ^   / .-'.--'    . /    `--./ .-'  `-.  `-. `.  -  `.
@/        `.  / /      `-.   /  .-'   / .   .'   \    \  \  .-  \%
@&8jgs@@%% @)&@&(88&@.-_=_-=_-=_-=_-=_.8@% &@&&8(8%@%8)(8@%8 8%@)%
@88:::&(&8&&8:::::%&`.~-_~~-~~_~-~_~-~~=.'@(&%::::%@8&8)::&#@8::::
`::::::8%@@%:::::@%&8:`.=~~-.~~-.~~=..~'8::::::::&@8:::::&8:::::'
 `::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::.'

                            ";
            Console.WriteLine(ascii);
            Console.WriteLine("The all seeing Eye has spotted you, ");
            

            int score = 0;

            Console.WriteLine("Do you choose to fight as:\n" +
                "S)trider\n" +
                "H)alfling\n" +
                "R)adagast\n" +
                "T)hranduil");
            Player player1 = new Player();
            ConsoleKey userInput = Console.ReadKey().Key;
            switch (userInput)
            {
                case ConsoleKey.S:
                player1 = new Player("Strider", 40, 40, 70, 25, Race.Human, new Weapon("Sword of Gondor", 20, 40, 1, true));
                    break;

                case ConsoleKey.H:
                    player1 = new Player("Halfling", 25, 35, 20, 15, Race.Hobbit, new Weapon("Sting", 12, 26, 2, false));
                    break;

                case ConsoleKey.R:
                    player1 = new Player("Radagast: The Brown", 45, 45, 73, 35, Race.Wizard, new Weapon("Upturned Sapling Staff", 18, 38, 1, true));
                    break;

                case ConsoleKey.T:
                    player1 = new Player("Thranduil: The Elvin King", 45, 45, 73, 35, Race.Wizard, new Weapon("Upturned Sapling Staff", 18, 38, 1, true));
                    break;

                default:
                    player1 = new Player("Strider", 40, 40, 70, 25, Race.Human, new Weapon("Sword of Gondor", 20, 40, 1, true));
                    break;
            }

            Console.Clear();
            Console.WriteLine($"You are playing as {player1.Name}");

            bool exit = false;

            do
            {
                Monster orc = new Monster("an Orc", 5, 5, 5, 5, 1, 1,
                    "Orc scum rushes you with a rusty dagger.");

                Monster goblinKing = new Monster("the Goblin King", 10, 10, 15, 5, 1, 4,
                    "The Goblin Kind confidently draws his axe with desire to take off your head.");

                Monster caveTroll = new Monster("a Cave Troll", 13, 13, 15, 10, 1, 4,
                    "It towers over you with his drool dripping like syrup on your head.");

                Monster golum = new Monster("Golum", 35, 30, 20, 10, 1, 4,
                   "The gangly creature who smells of fish scales and his own filth lunges at you when you least expected it and has your back!");

                Monster smeagul = new Monster("Smeagul", 10, 10, 15, 5, 1, 4,
                   "The halfling type creature that has helped navigate you has betrayed you and is ready to strangle you with his bare hands.");

                Dragon smaug = new Dragon("Smaug the all Powerful", 35, 35, 70, 10, 2, 8,
                    "This ancient dragon turns most mens underwear into diapers after they see the size of him!", true);

                Monster[] monsters =
                {
                    smaug, caveTroll, caveTroll, caveTroll, caveTroll, goblinKing, orc, orc, orc,orc, orc,orc,goblinKing,goblinKing
                };
                Monster monster = monsters[new Random().Next(monsters.Length)];


                Console.WriteLine(GetRoom());

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"In this room you see {monster.Name}!");
                Console.ResetColor();


                bool reloadRoom = false;


                do
                {
                    Console.Write("Choose an action:\n" +
                        "A)ttack\n" +
                        "F)lee\n" +
                        "H)ero States\n" +
                        "M)onster Stats\n" +
                        "Press Esc to exit game");

                    ConsoleKey userChoice = Console.ReadKey().Key;

                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Combat.DoBattle(player1, monster);
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"\nYou killed {monster.Name}!");
                                Console.ResetColor();
                                
                                reloadRoom = true;

                                score++;

                            }//end if monster is dead
                            break;

                        case ConsoleKey.F:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Run Away!");
                            Console.WriteLine($"{monster.Name} attacked you as you shamefully flee, just as your Father did 1000 years ago!");
                            Console.ResetColor();
                            Combat.DoAttack(monster, player1);
                            reloadRoom = true;
                            break;

                        case ConsoleKey.H:
                            Console.WriteLine(player1);
                            Console.WriteLine();
                            Console.WriteLine($"You have killed {score} Enemies");
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.Escape:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You have chosen to leave this Quest....Good Luck with the rest of your life .");
                            Console.ResetColor();
                            exit = true;
                            break;


                        default:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(userChoice + " was a poor choice. Choose again.");
                            Console.ResetColor();
                            break;
                    }//end switch
                    //Check if the Hero Is alive
                    if (player1.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("You have fallen my old friend.");
                        Console.ResetColor();
                        exit = true;
                    }

                } while (!reloadRoom && !exit);      //end small loop

            } while (!exit);                         //end big loop
            Console.WriteLine($"You killed");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score}");
            Console.ResetColor();
            Console.WriteLine("of the Enemy");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");
            Console.ResetColor();


        }//end main

        private static string GetRoom()
        {
           


             string[] rooms =
             {
                 "and A sick feeling in your stomach starts to grow as you approach a black, volcanic plain located near the great river Anduin called Mordor...This land was chosen by Sauron to be his realm because of the mountain ranges surrounding it on three sides, creating a natural fortress against his enemies...Good luck escaping alive.",

                "chills crawl up your spine as you find yourself in the dark tree line that seemed so far away just but a few moments ago...Suddenly you see tree limbs crashing and cracking to the east...This ruckus is headed straight for you...I hope you have your running armour on."



            };

            Random rand = new Random();
            int index = rand.Next(rooms.Length); // rooms.Length is the same thing as (0, 10)
            string room = rooms[index];
            return room;

            //This is the revised verion of the code above - return rooms[new Random().Next(rooms.Length)];

        }//end main2

    }//end class

}//end namespace
