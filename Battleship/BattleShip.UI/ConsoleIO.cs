using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.UI;

namespace BattleShip.UI
{
    class ConsoleIO
    {
        public enum RowId
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5,
            F = 6,
            G = 7,
            H = 8,
            I = 9,
            J = 10
        }
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static void WelcomeScreen()
        {
            ConsoleIO.DisplayMessage(message: "Welcome to Battle Ship!");
            ConsoleIO.DisplayMessage(message: "Press any key to continue.");
            Console.ReadKey();
        }

        internal static void ClearDisplay()
        {
            Console.Clear();
        }

        public static void DisplayBoard(Board board)
        {
            Console.WriteLine("    1  2  3  4  5  6  7  8  9 10");
            Console.WriteLine("  +--+--+--+--+--+--+--+--+--+--+");
            for (int row = 1; row < 11; row++)
            {
                string rowID = (((RowId)row).ToString());
                Console.Write($"{rowID} |");
                for (int col = 1; col < 11; col++)
                {
                    Console.Write(" ");
                    var coordinate = new Coordinate(row, col);
                    ShotHistory pastShot = board.CheckCoordinate(coordinate);
                    switch (pastShot)
                    {
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("M");
                            Console.ResetColor();
                            break;

                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("H");
                            Console.ResetColor();
                            break;

                        case ShotHistory.Unknown:
                            Console.Write(" ");
                            break;

                        default:
                            break;
                    }
                    Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine("  +--+--+--+--+--+--+--+--+--+--+");
            }
        }
        public static ShipDirection PromptPlayerForShipDirection()
        {
            while (true)
            {
                ConsoleIO.DisplayMessage(message:" Please enter a  direction.");
                string input = Console.ReadLine().ToUpper();
                if (input == "UP")
                {
                    return ShipDirection.Up;
                }
                if (input == "DOWN")
                {
                    return ShipDirection.Down;
                }
                if (input == "RIGHT")
                {
                    return ShipDirection.Right;
                }
                if (input == "LEFT")
                {
                    return ShipDirection.Left;
                }
            }
        }
        public static Coordinate PromptPlayerForCoordinate(string message)
        {
            while(true)
            {
                ConsoleIO.DisplayMessage(message);
                string coordEntry = ConsoleIO.PromptUserString();
                string xCoordinate = coordEntry.Substring(0, 1).ToUpper();
                int yLength = Math.Min(2, coordEntry.Length - 1);
                string yCoordinate = coordEntry.Substring(1, Math.Min(2, yLength));
                if (yLength == 0)
                {
                    ConsoleIO.DisplayMessage(message: "Your entry is invalid.");
                }
                bool parsedX = Enum.TryParse(xCoordinate, out RowId axisX);
                if (parsedX == false)
                {
                    continue;
                }
                bool parsedY = Int32.TryParse(yCoordinate, out int axisY);
                if (parsedY == false)
                {
                    continue;
                }
                if (axisX == 0 || axisY == 0)
                {
                    ConsoleIO.DisplayMessage(message: "Your entry is invalid.");
                    continue;
                }
                else if (axisY < 1 || axisY > 10)
                {
                    ConsoleIO.DisplayMessage(message: "Your entry is invalid.");
                    continue;
                }
                int intAxisX = (int)axisX;
                Coordinate cord = new Coordinate(intAxisX, axisY);
                return cord;
            }
        }
        public static Player PromptPlayerName()
        {
            ConsoleIO.DisplayMessage(message: "Please enter your name");
            var name = ConsoleIO.PromptUserString();
            return new Player(name: name);
        }
        public static String PromptUserString()
        {
            return Console.ReadLine();
        }
        public static bool PromptPlayAgain()
        {
            ConsoleIO.DisplayMessage(message: "Would you like to play again?");
            Console.Write("Y/N ");
             string answer = ConsoleIO.PromptUserString();
            return (answer == "Y");
        }
    }
}
