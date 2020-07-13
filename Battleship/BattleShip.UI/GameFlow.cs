using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    class GameFlow
    {
        public void Run()
        {
            FireShotResponse fireShotResponse = new FireShotResponse();
            Board board = new Board();
            ConsoleIO.WelcomeScreen();
            Game game = new Game();
            Random random = new Random();
            var StartingPlayerNumber = random.Next(1, 3);
            Player startingPlayer;
            if (StartingPlayerNumber == 1)
            {
                startingPlayer = game.Player1;
            }
            else
            {
                startingPlayer = game.Player2;
            }
            ConsoleIO.DisplayMessage(message: "Starting player is: " + startingPlayer.Name);
            Player currentPlayer = startingPlayer;
            Player opposingPlayer;
            if (currentPlayer == game.Player1)
            {
                opposingPlayer = game.Player2;
            }
            else
            {
                opposingPlayer = game.Player1;
            }
            Console.Clear();

            while (true)
            {
                game.SetupBoard(currentPlayer.Board, currentPlayer);
                Console.Clear();
                game.SetupBoard(opposingPlayer.Board, opposingPlayer);
                Console.Clear();

                while (true)
                {
                    var isVictorious = game.TakeTurn(currentPlayer, opposingPlayer);
                    if (isVictorious)
                    {
                        break;
                    }
                    else
                    {
                        if (game.Player1 == currentPlayer)
                        {
                            currentPlayer = game.Player2;
                            opposingPlayer = game.Player1;
                        }
                        else
                        {
                            currentPlayer = game.Player1;
                            opposingPlayer = game.Player2;
                        }
                    }
                }
                var playAgain = ConsoleIO.PromptPlayAgain();
                if (playAgain)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }   

    }
}
