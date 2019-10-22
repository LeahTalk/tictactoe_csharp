using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] characters = new string[] {"X", "O"};
            Board game = new Board();
            int playerIndex = 0;
            string curPlayer = characters[playerIndex];
            while(!game.gameOver) {
                Console.WriteLine($"It is player {characters[playerIndex]}'s turn!");
                bool validMove = false;
                while(!validMove) {
                    bool validRow = false;
                    bool validCol = false;
                    int rowNum = 0;
                    int colNum = 0;
                    while(!validRow) {
                        game.displayBoard();
                        Console.WriteLine("Please choose a row number: ");
                        rowNum = Int32.Parse(Console.ReadLine());
                        if(rowNum < 1 || rowNum > 3) {
                            Console.WriteLine("Please select a valid row number!");
                        }
                        else {
                            validRow = true;
                        }
                    }
                    while(!validCol) {
                        Console.WriteLine("Please choose a column number: ");
                        colNum = Int32.Parse(Console.ReadLine());
                        if(colNum < 1 || colNum > 3) {
                            Console.WriteLine("Please select a valid column number!");
                        }
                        else {
                            validCol = true;
                        }
                    }
                    if(game.placePiece(curPlayer, rowNum - 1, colNum - 1)) {
                        validMove = true;
                    }
                    else {
                        Console.WriteLine("That square is already taken! Please choose another space.");
                    }
                }
                if(!game.checkWin(curPlayer)) {
                    playerIndex = (playerIndex + 1) % 2;
                    curPlayer = characters[playerIndex];
                }
            }
            game.displayBoard();
            Console.WriteLine($"Player {curPlayer} won!!!");
        }
    }
}
