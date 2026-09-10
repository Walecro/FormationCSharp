using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {
            return _open[i,j];
        }

        private bool IsFull(int i, int j)
        {
            return _full[i, j];
        }

        public bool Percolate()
        {
            for(int i = 0; i < _size ; i++)
            {
                if(_full[_size-1,i] == true)
                {
                    return true;
                }
            }
            return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> Neighbours = new List<KeyValuePair<int,int>>();


            // Vérification des cas de bord 
            if( i > 0)
            {
                Neighbours.Add(new KeyValuePair<int, int>(i-1, j));
            }
            if (j > 0)
            {
                Neighbours.Add(new KeyValuePair<int, int>(i , j-1));
            }
            if (i < _size - 1)
            {
                Neighbours.Add(new KeyValuePair<int, int>(i + 1, j));
            }
            if (j < _size - 1)
            {
                Neighbours.Add(new KeyValuePair<int, int>(i , j+1));
            }


            return Neighbours;
        }

        public void Open(int i, int j)
        {
            bool[,] LoopTreated = new bool[_size, _size];
            init_loop(LoopTreated);
            _open[i, j] = true;

            List<KeyValuePair<int, int>> neighbours = CloseNeighbors(i, j);

            //Check si un des voisins est rempli 
            foreach (KeyValuePair<int,int> Coords in neighbours)
            {
                if (_full[Coords.Key, Coords.Value])
                {
                    _full[i, j] = true;
                    LoopTreated[i, j] = true;
                    break;
                }
            }

            //Si on a rempli i , j , si voisins ouverts => rempli 
            if (_full[i, j])
            {
                foreach (KeyValuePair<int, int> Coords in neighbours)
                {
                    LoopTreated[Coords.Key, Coords.Value] = true;

                    if (_open[Coords.Key, Coords.Value])
                    {
                        _full[Coords.Key, Coords.Value] = true;
                    }
                }
            }

            

            //


            //

        }

        public void init_loop(bool[,] LoopTreated)
        {
            for(int i = 0; i < LoopTreated.GetLength(0); i ++)
            {
                for (int j =0; j < LoopTreated.GetLength(1); j++)
                {
                    LoopTreated[i, j] = false;
                }
            }
        }
    }
}
