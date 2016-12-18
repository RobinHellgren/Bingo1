using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo {
    class Program {
        static int träffar = 0;
        static void Main(string[] args) {
            Random rng = new Random();
            //Ge intruktioner
            Console.WriteLine("Det här programmet är ett bingo spel, det kommer snart fråga dig om 10 hel tal mellan 1 och 25. Tänkt på att inte skriva in två lika nummer.");
            Console.WriteLine();
            //Skapa ny instans av BingoBricka
            BingoBricka nyBricka = new BingoBricka();
            //Hämta siffror från användaren
            for (int x = 0; x < nyBricka.checkLenght(); x++) {
                Console.WriteLine("Skriv in ett nummer. " + (nyBricka.checkLenght() - x) + " nummer kvar");
                try { int userNr = Convert.ToInt32(Console.ReadLine());
                    nyBricka.setInt(x, userNr);
                    if (userNr < 1 || userNr > 25) {
                        Console.WriteLine("Din siffra var antingen mer än 25 eller mindre än 1. Skriv in en ny");
                        nyBricka.setInt(x, 78);
                        x--;
                        }
                    if (nyBricka.checkForDupe()) {
                        Console.WriteLine("Samma siffra som redan skrivits in tidigare hittat skriv in ny siffra!");
                        nyBricka.setInt(x, 99);
                        x--;
                        }
                     }                   
                catch { Console.WriteLine("Inte en giltlig siffra!");nyBricka.setInt(x, 0); x--; }
                }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            //Generera resultat
            ResultatBricka nyReslutat = new ResultatBricka(4, rng);
            Console.Clear();
            //Visa alla siffror
            Console.WriteLine("==========================================================");
            Console.Write("Dina siffror: ");
            for (int x = 0; x < nyBricka.checkLenght(); x++) {
                Console.Write(nyBricka.getInt(x) + " ");
                }
            Console.WriteLine();
            Console.WriteLine("==========================================================");

            Console.Write("Slumpade siffror: ");
            for (int x = 0; x < nyReslutat.checkLenght(); x++) {
                Console.Write(nyReslutat.getInt(x) + " ");
                }
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            //Jämnför resultat med användarens siffror
            for(int x = 0; x < nyBricka.checkLenght(); x++) {
                for (int y = 0; y < nyReslutat.checkLenght(); y++) {
                    if(nyBricka.getInt(x) == nyReslutat.getInt(y)) {
                        träffar++;
                        }
                }
            }
            //Visa hur många rätt användaren fick
            Console.WriteLine("Du fick " + träffar + " rätt!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            }
 
        }
    class BingoBricka {
        //Variabler
        private int[] bricka;
        private bool dupe;
        //Constructor
        public BingoBricka() {
            this.bricka = new int[10];
            }
        //Getter
        public int getInt(int location) {
            return bricka[location];
            }
        //Setter
        public void setInt(int location, int value) {
            this.bricka[location] = value;
            }
        //Funktion för att komma åt länged på array
        public int checkLenght() {
            return bricka.Length;
            }
        //Kollar om arrayet har dubbleter !!BUG HÄR!!
        public bool checkForDupe() {
            dupe = false;
            for (int x = 0; x < bricka.Length; x++) {
                for (int y = 0; x < bricka.Length; x++) {
                    if (bricka[y] != 0 || bricka[x] != 0) {
                        if (y != x) {
                            if (bricka[y] == bricka[x]) {
                                dupe = true;
                                }
                            }
                        }
                    }
                }
            return dupe;
            }

        }
    class ResultatBricka {
        //Variabler
        private int[] bricka;
        private bool dupe;
        //Skapa och generara resultat mellan 1 och 25 och constructor
        public ResultatBricka(int seize, Random rng) {
            this.bricka = new int[seize];
            for(int x = 0; x < bricka.Length; x++) {
                do {

                    bricka[x] = rng.Next(1, 26);

                    } while (checkForDupe());
                }
            }
        //Funktion för att komma åt länged på array
        public int checkLenght() {
            return bricka.Length;
            }
        //Getter
        public int getInt(int location) {
            return bricka[location];
            }
        //Kollar om arrayet har dubbleter !!BUG HÄR!!
        public bool checkForDupe() {
            dupe = false;
            for (int x = 0; x < bricka.Length; x++) {
                for (int y = 0; x < bricka.Length; x++) {
                    if (bricka[y] != 0 || bricka[x] != 0) {
                        if (y != x) {
                            if (bricka[y] == bricka[x]) {
                                dupe = true;
                                }
                            }
                        }
                    }
                }
            return dupe;
            }
        }
        
    }
