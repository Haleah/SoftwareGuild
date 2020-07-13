using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Responses;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Game
    {
        public Player Player1;
        public Player Player2;
        public Game()
        {
            Player1 = ConsoleIO.PromptPlayerName();
            Player2 = ConsoleIO.PromptPlayerName();
        }
        public bool TakeTurn(Player currentPlayer, Player opposingPlayer)
        {
            var isVictorious = false;
            ConsoleIO.DisplayMessage(message: "Press any key to continue to player turn.");
            ConsoleIO.PromptUserString();
            ConsoleIO.ClearDisplay();
            ConsoleIO.DisplayBoard(opposingPlayer.Board);
            Coordinate shotRequest = ConsoleIO.PromptPlayerForCoordinate(message: "Please Enter Shot coordinate " + currentPlayer.Name);
            FireShotResponse shotResponse = opposingPlayer.Board.FireShot(shotRequest);
            switch (shotResponse.ShotStatus)
            {
                case ShotStatus.Invalid:
                    ConsoleIO.DisplayMessage(message: "Invalid, try again.");
                    isVictorious = TakeTurn(currentPlayer, opposingPlayer);
                    break;
                case ShotStatus.Duplicate:
                    ConsoleIO.DisplayMessage(message: "Duplicate, try again.");
                    isVictorious = TakeTurn(currentPlayer, opposingPlayer);
                    break;
                case ShotStatus.Miss:
                    ConsoleIO.DisplayMessage(message: "Miss");
                    break;
                case ShotStatus.Hit:
                    ConsoleIO.DisplayMessage(message: "Hit");
                    break;
                case ShotStatus.HitAndSunk:
                    ConsoleIO.DisplayMessage(message: "Hit and Sunk" + shotResponse.ShipImpacted);
                    break;
                case ShotStatus.Victory:
                    ConsoleIO.DisplayMessage(message: "You are the winner!!!");
                    isVictorious = true;
                    break;
            }

            return isVictorious;
        }
        public Board SetupBoard(Board board, Player currentPlayer)
        {
            ConsoleIO.DisplayMessage(message: "Please set up your board " + currentPlayer.Name);
            foreach (ShipType shipType in Enum.GetValues(typeof(ShipType)))
            {
                while(true)
                {
                    string currentShip = Enum.GetName(typeof(ShipType), shipType);
                    PlaceShipRequest shipRequest = new PlaceShipRequest();
                    shipRequest.ShipType = shipType;
                    shipRequest.Coordinate = ConsoleIO.PromptPlayerForCoordinate(message: "Please enter coordinate for "+ shipType);
                    shipRequest.Direction = ConsoleIO.PromptPlayerForShipDirection();
                    ShipPlacement result = board.PlaceShip(shipRequest);
                    if (result == ShipPlacement.NotEnoughSpace)
                    {
                        ConsoleIO.DisplayMessage(message: "Not enough space.");
                    }
                    else if (result == ShipPlacement.Overlap)
                    {
                        ConsoleIO.DisplayMessage(message: "Ships are overlapping");
                    }
                    else if (result == ShipPlacement.Ok)
                    {
                        break;
                    }
                }
            }
            return board;
        }
    }
}