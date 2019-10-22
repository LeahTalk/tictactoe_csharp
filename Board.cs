using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Board
    {
        private string[,] board;
        private bool gameEnd;
        public Board() {
            board = new string[3,3];
            gameEnd = false;
        }

        public bool gameOver {
            get {
                return gameEnd;
            }
        }

        public bool checkWin(string curPlayer) {
            if(checkRows(curPlayer) || checkCols(curPlayer) || checkDiagonals(curPlayer)) {
                gameEnd = true;
                return true;
            }
            return false;
        }

        public void displayBoard() {
            for(int row = 0; row < 3; row++) {
                Console.Write($"{board[row, 0]} ");
                for(int col = 1; col < 3; col++) {
                    Console.Write(" | ");
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
                if(row != 2) {
                    Console.WriteLine("---------");
                }
            }
        }

        public bool placePiece(string curPlayer, int rowNum, int colNum) {
            if(board[rowNum,colNum] == null) {
                board[rowNum, colNum] = curPlayer;
                return true;
            }
            return false;
        }

        public bool checkRows(string curPlayer) {
            for(int row = 0; row < 3; row++) {
                bool fullRow = true;
                for(int col = 0; col < 3; col++) {
                    if(board[row, col] != curPlayer) {
                        fullRow = false;
                    }
                }
                if(fullRow) {
                    return true;
                }
            }
            return false;
        }

        public bool checkCols(string curPlayer) {
            for(int col = 0; col < 3; col++) {
                bool fullCol = true;
                for(int row = 0; row < 3; row++) {
                    if(board[row, col] != curPlayer) {
                        fullCol = false;
                    }
                }
                if(fullCol) {
                    return true;
                }
            }
            return false;
        }

        public bool checkDiagonals(string curPlayer) {
            bool diagOne = true;
            bool diagTwo = true;
            for(int i = 0; i < 3; i++) {
                if(board[i, i] != curPlayer) {
                    diagOne = false;
                }
                if(board[i, 2 - i] != curPlayer) {
                    diagTwo = false;
                }
            }
            return diagOne || diagTwo;
        }
    }
}
