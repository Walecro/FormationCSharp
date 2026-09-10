using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie4
{
    public static class Morpion
    {
        static readonly string line = "ABC";
        static readonly char[] sign_j = { 'X', 'O' };

        public static Dictionary<char,char[]> _grid = new Dictionary<char, char[]>();
        public static void MorpionGame()
        {
            int cur_player = 1;
            string coup;
            char ligne;
            int colonne;
            bool Digit;
            int winner = -1;
            //Init 


            for (int j = 0; j < 3; j++)
             {
                _grid.Add(line[j], new char[] {'_','_','_'});
             }

            DisplayMorpion(_grid);
            Console.WriteLine("Debut de la partie de Morpion");


            //Boucle Jeu 
            while (winner == -1 )
            {

                // Input 
                do
                {
                    Console.WriteLine("Coup du joueur " + cur_player + " : ");
                    coup = Console.ReadLine();
                    
                    /*
                    try
                    {*/
                        ligne = Char.ToUpper(coup[0]);
                        Digit = int.TryParse(coup[1] + " ", out colonne);
                    /*}
                    
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine("Format coup invalide");
                    }*/




                } while (!Digit || !Char.IsLetter(ligne) || coup.Length != 2 || ligne < 'A' || ligne > 'C' || colonne < 1 || colonne > 3 || ! (_grid[ligne][colonne-1] == '_') );

                // Ecriture dans la grille 
                _grid[ligne][colonne-1] = sign_j[cur_player-1];//cur_player-1];


                cur_player = cur_player == 1 ? 2 : 1;



                DisplayMorpion(_grid);
                winner = CheckMorpion(_grid);
            }

            //Affichage gagnant ou match nul
            switch (winner)
            {
                case 1:
                    Console.WriteLine("Joueur 1 a gagné!");
                    break;
                case 2:
                    Console.WriteLine("Joueur 2 a gagné!");
                    break;
                default:
                    Console.WriteLine("Match nul!");
                    break;
            }
        }

        public static void DisplayMorpion(Dictionary<char, char[]> _grid)
        {
            foreach(char k in _grid.Keys)
            {
                foreach(char cell in _grid[k])
                {
                    Console.Write(cell + " ");
                }
                Console.WriteLine("");
            }
           
            return;
        }

        public static int CheckMorpion(Dictionary<char, char[]> _grid)
        {
            

            if ((_grid[line[0]][0] == sign_j[0] && _grid[line[0]][1] == sign_j[0] && _grid[line[0]][2] == sign_j[0] ||
                _grid[line[1]][0] == sign_j[0] && _grid[line[1]][1] == sign_j[0] && _grid[line[1]][2] == sign_j[0] ||
                _grid[line[2]][0] == sign_j[0] && _grid[line[2]][1] == sign_j[0] && _grid[line[2]][2] == sign_j[0] ||
                _grid[line[0]][0] == sign_j[0] && _grid[line[1]][0] == sign_j[0] && _grid[line[2]][0] == sign_j[0] ||
                _grid[line[0]][1] == sign_j[0] && _grid[line[1]][0] == sign_j[0] && _grid[line[2]][1] == sign_j[0] ||
                _grid[line[0]][2] == sign_j[0] && _grid[line[1]][2] == sign_j[0] && _grid[line[2]][2] == sign_j[0] ||
                _grid[line[0]][0] == sign_j[0] && _grid[line[1]][1] == sign_j[0] && _grid[line[2]][2] == sign_j[0] ||
                _grid[line[0]][2] == sign_j[0] && _grid[line[1]][1] == sign_j[0] && _grid[line[2]][0] == sign_j[0]
                ))
            {
                return 1;
            }

            if ((_grid[line[0]][0] == sign_j[1] && _grid[line[0]][1] == sign_j[1] && _grid[line[0]][2] == sign_j[1] ||
                 _grid[line[1]][0] == sign_j[1] && _grid[line[1]][1] == sign_j[1] && _grid[line[1]][2] == sign_j[1] ||
                 _grid[line[2]][0] == sign_j[1] && _grid[line[2]][1] == sign_j[1] && _grid[line[2]][2] == sign_j[1] ||
                 _grid[line[0]][0] == sign_j[1] && _grid[line[1]][0] == sign_j[1] && _grid[line[2]][0] == sign_j[1] ||
                 _grid[line[0]][1] == sign_j[1] && _grid[line[1]][0] == sign_j[1] && _grid[line[2]][1] == sign_j[1] ||
                 _grid[line[0]][2] == sign_j[1] && _grid[line[1]][2] == sign_j[1] && _grid[line[2]][2] == sign_j[1] ||
                 _grid[line[0]][0] == sign_j[1] && _grid[line[1]][1] == sign_j[1] && _grid[line[2]][2] == sign_j[1] ||
                 _grid[line[0]][2] == sign_j[1] && _grid[line[1]][1] == sign_j[1] && _grid[line[2]][0] == sign_j[1]
                 ))
            {
                return 2;
            }
            // Cas match non fini 
            foreach (char line in _grid.Keys)
            {
                for (int j = 0; j < _grid[line].Length; j++)
                {
                    if (_grid[line][j] == '_')
                    {
                        return -1;

                    }

                }
            }

            return 0;

        }
    }
}
