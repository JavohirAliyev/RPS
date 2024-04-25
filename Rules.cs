using System.Globalization;

namespace Itransition3{
    public class Rules{
        int numberOfMoves;

        //creating a constructor to get the number of possible moves
        public Rules(int NumberOfMoves)
        {
            numberOfMoves = NumberOfMoves;
        }

        //function to figure out which move is the winner
        public Result identifyWinner(int movePlayer, int moveComputer){
            if (movePlayer == moveComputer){
                return Result.Draw;
            } else if((movePlayer < moveComputer && moveComputer - movePlayer <= numberOfMoves /2) || (moveComputer < movePlayer && movePlayer - moveComputer > numberOfMoves / 2)) {
                return Result.Win;
                } else {
                return Result.Lose;
            }
        }
    }
}