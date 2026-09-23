using System;
using System.Collections.Generic;

namespace BatailleNavale
{
    internal class Plateau
    {
        public Position[,] PlateauJeu { get; set; }

        public List<Bateau> Bateaux { get; set; }

        public Plateau(int taille)
        {
            PlateauJeu = new Position[taille, taille];
            Bateaux = new List<Bateau>()
            {
               new Bateau("A", 5, new List<Position>()),
               new Bateau("B", 4, new List<Position>()),
               new Bateau("C", 3, new List<Position>()),
               new Bateau("D", 3, new List<Position>()),
               new Bateau("E", 2, new List<Position>())
            };
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    PlateauJeu[i, j] = new Position(i, j);
                }
            }
        }

        public void CreationPlateau()
        {

            for (int i = 0; i < PlateauJeu.GetLength(0); i++)
            {
                for (int j = 0; j < PlateauJeu.GetLength(1); j++)
                {
                    //Init des cases du plateau
                    PlateauJeu[i, j] = new Position(i, j);
                }
            }
            //Generateur de coords 
            var Rand = new Random();


            int x, y;
            int estVertical;
            foreach (Bateau B in Bateaux)
            {
                do
                {
                    // [0;9]
                    x = Rand.Next() % 10;
                    y = Rand.Next() % 10;

                    // [0;1] 
                    // 0 faux 1 vrai
                    estVertical = Rand.Next() % 2;


                } while (!PlacerBateau(x, y, B.Taille, estVertical == 0 ? false : true));

                for (int i = 0; i < B.Taille; i++)
                {
                    if (estVertical == 1)
                    {
                        B.Positions.Add(PlateauJeu[x + i, y]);
                    }
                    else
                    {
                        B.Positions.Add(PlateauJeu[x, y + i]);
                    }

                }
            }
        }

        public void LancementPartie()
        {
            int cpt = 0;
            int x_in = -1, y_in = -1;
            bool x_ok = false, y_ok = false;

            string val;
            string[] position;

            CreationPlateau();
            while (!FindePartie())
            {
                Console.Clear();
                AfficherPlateau();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Quelle case visez-vous : (format: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("ligne");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(",");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("colonne");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(")");
                Console.WriteLine();

                // Boucle récupération entrée utilisateur 
                do
                {
                    val = Console.ReadLine();
                    position = val.Split(',', '.');
                    if (position.Length == 2)
                    {
                        x_ok = int.TryParse(position[0], out x_in);
                        y_ok = int.TryParse(position[1], out y_in);
                    }

                } while (!x_ok || !y_ok || x_in <= 0 || x_in >= 11 || y_in <= 0 || y_in >= 11);
                //Tir
                Viser(x_in - 1, y_in - 1);
                cpt++;

            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            AfficherPlateau();
            Console.WriteLine($"GG {cpt} coups effectués !");
            Console.WriteLine("Appuyez sur une touche pour terminer.");
            Console.ReadKey();
        }

        /// <summary>
        /// Peut-on placer le navire sur la grille sans qu'il dépasse les bords et qu'il ne touche les autres bateaux ? 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="taille"></param>
        /// <param name="estVertical"></param>
        /// <returns></returns>
        private bool PlacerBateau(int x, int y, int taille, bool estVertical)
        {
            // Clair
            bool placement_ok = true;

            if (estVertical)
            {
                //Dépasse t on ? 
                if (x + taille < 10)
                {
                    //Prise en charge du rectangle autour du bateau
                    for (int offset = -1; offset <= taille; offset++)
                    {
                        //Parcours de tous les autres bateaux
                        foreach (Bateau b in Bateaux)
                        {
                            //Le bateau EST placé, on le prend en compte
                            if (!(b.Positions.Count == 0))
                            {
                                foreach (Position p in b.Positions)
                                {
                                    //Prise en charge des lignes du bateau ainsi que les lignes de débordement - 1 + 1 
                                    if (p.X == x + offset)
                                    {
                                        // Est t on sur ou à proximité d'un bateau ?
                                        if (p.Y == y || p.Y - 1 == y || p.Y + 1 == y)
                                        {
                                            placement_ok = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    placement_ok = false;
                }
            }
            else
            {
                if (y + taille < 10)
                {
                    for (int offset = -1; offset <= taille; offset++)
                    {

                        foreach (Bateau b in Bateaux)
                        {
                            if (!(b.Positions.Count == 0))
                            {
                                foreach (Position p in b.Positions)
                                {
                                    if (p.Y == y + offset)
                                    {
                                        if (p.X == x || p.X - 1 == x || p.X + 1 == x)
                                        {
                                            placement_ok = false;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    placement_ok = false;
                }
            }

            return placement_ok;
        }

        /// <summary>
        /// Choix de la case (x , y) 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Viser(int x, int y)
        {
            // Parcours de tous les bateaux et test de la case
            foreach (Bateau b in Bateaux)
            {
                b.Touché(x, y);
            }
            // Si pas de modif 
            if (PlateauJeu[x, y].Statut == Position.Etat.Caché)
            {
                PlateauJeu[x, y].Plouf();
            }
        }

        /// <summary>
        /// Affichage de l'état de la grille et de la situation de la partie
        /// </summary>
        public void AfficherPlateau()
        {
            List<Position> list = new List<Position>();
            foreach (Bateau b in Bateaux)
            {
                list.AddRange(b.Positions);
                Console.WriteLine($"{b.Nom}: {b.Taille} de long, coulé: {b.EstCoulé()}");
            }

            foreach (Position p in list)
            {
                PlateauJeu.SetValue(p, p.X, p.Y);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");
            int cpt = 0, tmp = 0;
            foreach (Position p in PlateauJeu)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (p.X != tmp || cpt == 0)
                {
                    if (cpt > 0)
                    {
                        Console.WriteLine();
                    }
                    Console.Write(string.Format("{0,-3}", ++cpt));
                }

                ConsoleColor foreground;
                switch (p.Statut)
                {
                    case Position.Etat.Plouf:
                        foreground = ConsoleColor.Blue;
                        break;
                    case Position.Etat.Touché:
                        foreground = ConsoleColor.Red;
                        break;
                    case Position.Etat.Coulé:
                        foreground = ConsoleColor.Green;
                        break;
                    default:
                        foreground = ConsoleColor.White;
                        break;
                }
                Console.ForegroundColor = foreground;
                Console.Write((char)p.Statut + " ");

                tmp = p.X;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        /// <summary>
        /// La partie est-elle finie ? 
        /// </summary>
        /// <returns></returns>
        internal bool FindePartie()
        {
            foreach (Bateau b in Bateaux)
            {
                if (!b.EstCoulé())
                {
                    return false;
                }
            }
            return true;
        }
    }
}