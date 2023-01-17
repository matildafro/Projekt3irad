using System;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        //lista över varje ruta på brädet
        static int[] board = new int[9];

        //spelares startvärde
        static int usersTurn = -1;
        static int compTurn = -1;


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            bool gameOn = true;
            while (gameOn)
            {

                //tilldelar alla rutor utom 2 värdet 0, 1 och 2 betyder att spelare 1 har den rutar och 2 att spelare 2 har den rutan
                for (int i = 0; i < 9; i++)
                {
                    board[i] = 0;
                }
                //skapar random nummer
                Random rand = new Random();
                Console.WriteLine("Välkommen till 3 i rad. Du är Spelare 1. Datorn är Spelare 2. ");

                
                    while (checkWinner() == 0)
                    {
                        //gör att valda rutor inte kan väljas av spelare 1 (människan)
                        while (usersTurn == -1 || board[usersTurn] != 0)
                        {

                            Console.WriteLine("Ange ett nummer mellan 1 och 9");

                           //kontrollerar att inmatning är siffra
                            if (int.TryParse(Console.ReadLine(), out usersTurn))
                            {
                            //kontrollerar att inmatning är mellan 1-9
                            if (Enumerable.Range(1, 9).Contains(usersTurn))
                            {

                                Console.Clear();
                                Console.WriteLine("Du angav " + usersTurn);

                                //då arrayen över spelbordet börjat på noll kör jag -1 då det blir mer logiskt för spelare att skriva 1 på första rutan ist för 0
                                usersTurn = usersTurn - 1;
                            } else
                            {
                                Console.WriteLine("Siffran du angett är för stor eller för liten. Vänligen försök igen, 1-9.");
                                usersTurn = -1;
                            }
                            }
                            else
                            {
                                Console.WriteLine("Felaktig inmatning, ange siffra mellan 1 - 9.");
                                usersTurn = -1;
                            }
                        }

                        board[usersTurn] = 1;
                    
                    
                    //kontrollerar att resultat inte är oavgjort
                    if (checkTie() == 0)
                    {
                        //Gör att datorn inte kan välja ett inkorrekt nummer
                        while (compTurn == -1 || board[compTurn] != 0)
                        {

                            compTurn = rand.Next(8);

                            var compReadOut = compTurn + 1;

                            Console.WriteLine("Datorn valde " + compReadOut);
                        }

                        board[compTurn] = 2;

                        printBoard();

                    } else if(checkWinner() == 0)
                    { //om ingen vinner på sista siffran blir det oavgjort
                        printBoard();
                        Console.WriteLine("Matchen blev oavgjord.");
                        Console.ReadLine();

                        Console.WriteLine("Tryck valfri knapp för att avsluta.");
                        Console.ReadLine();
                        Environment.Exit(0);
                    } //slut på else if
                    }//slut på checkwinner
                    
                    Console.WriteLine("\nSpelare " + checkWinner() + " vann spelet, grattis!");
                    Console.ReadLine();
                    Console.WriteLine("Vill du spela igen? Tryck X för att avsluta eller valfri knapp för omstart");
                    // Spara svar av användare
                    string input = Console.ReadLine();

                    //om spelare väljer x avslutas spelet
                    if (input == "X" || input == "x")
                    {
                        gameOn = false;
                    }
                    else
                    {
                        Console.Clear();
                        //nollställ variabler för att inte ha nummer utskrivna
                        usersTurn = -1;
                        compTurn = -1;
                        gameOn = true;

                    }

              
                
            }
        }
       

        private static int checkWinner()
        {
            //returnerna 0 om ingen vinner. returnera spelar-nummer om den vinner
            //rad 1
            if (board[0] == board[1] && board[1] == board[2])
            {
                return board[0];
            }


            //rad 2
            if (board[3] == board[4] && board[4] == board[5])
            {
                return board[3];
            }


            //rad 3
            if (board[6] == board[7] && board[7] == board[8])
            {
                return board[6];
            }


            //kolumn 1
            if (board[0] == board[3] && board[3] == board[6])
            {
                return board[0];
            }

            //kolumn 2
            if (board[1] == board[4] && board[4] == board[7])
            {
                return board[1];
            }

            //kolumn 3
            if (board[2] == board[5] && board[5] == board[8])
            {
                return board[2];
            }


            //diagonalen vänster övre hörn till högre nedre hörn
            if (board[0] == board[4] && board[4] == board[8])
            {
                return board[0];
            }


            //diagonalen vänster nedre hörn till högre övre hörn
            if (board[2] == board[4] && board[4] == board[6])
            {
                return board[2];
            }

            return 0;
        }

        private static int checkTie()
        {
            //oavgjort
            //om alla rutor har blivit tilldeade utan vinnare är spelet oavgjort
            if (board[0] != 0 && board[1] != 0 && board[2] != 0 && board[3] != 0 && board[4] != 0 && board[5] != 0 && board[6] != 0 && board[7] != 0 && board[8] != 0)
            {
                return -1;
            } else
            {
                return 0;
            }
        }

        private static void printBoard()
        {
            {
           

                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
                Console.WriteLine("     |     |      ");

             
            }
        }
    }
}