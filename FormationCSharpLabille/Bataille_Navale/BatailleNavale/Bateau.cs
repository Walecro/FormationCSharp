using System.Collections.Generic;

namespace BatailleNavale
{
    internal class Bateau
    {
        public string Nom { get; private set; }
        public int Taille { get; private set; }
        public List<Position> Positions { get; private set; }

        public Bateau(string nom, int taille, List<Position> position)
        {
            Nom = nom;
            Taille = taille;
            Positions = position;
        }

        /// <summary>
        /// Case à l'état touché si elle appartient au bateau
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Touché(int x, int y)
        {
            int Kum_touche = 0;

            foreach (Position p in Positions)
            {
                if (p.X == x && p.Y == y)
                {
                    p.Touché();

                    // Pour éviter le contrôle pour chaque Position du tableau, tu pourrais faire la mise à jour Coulé en dehors de la première boucle

                    // A t on touché la dernière case d'un bateau ? 
                    foreach (Position p2 in Positions)
                    {
                        if (p2.Statut == Position.Etat.Touché)
                        {
                            Kum_touche++;
                        }
                    }

                    //Si oui on met à jour l'état des cases du bateau
                    if (Kum_touche == Positions.Count)
                    {
                        foreach (Position p2 in Positions)
                        {
                            p2.Coulé();
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Le bateau est-il coulé ? 
        /// </summary>
        public bool EstCoulé()
        {
            int Kum_touche = 0;

            foreach (Position p in Positions)
            {
                if (p.Statut == Position.Etat.Coulé)
                {
                    Kum_touche++;
                }
            }
            // Cohérent avec l'implémentation de Touché() 
            return Kum_touche == Positions.Count;
        }
    }
}