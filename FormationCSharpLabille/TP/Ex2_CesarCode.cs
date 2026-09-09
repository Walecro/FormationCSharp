using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie3
{
    public class Cesar
    {
        private readonly char[,] _cesarTable;

        public Cesar()
        {
            _cesarTable = new char[,]
            {
                { 'A', 'D' },
                { 'B', 'E' },
                { 'C', 'F' },
                { 'D', 'G' },
                { 'E', 'H' },
                { 'F', 'I' },
                { 'G', 'J' },
                { 'H', 'K' },
                { 'I', 'L' },
                { 'J', 'M' },
                { 'K', 'N' },
                { 'L', 'O' },
                { 'M', 'P' },
                { 'N', 'Q' },
                { 'O', 'R' },
                { 'P', 'S' },
                { 'Q', 'T' },
                { 'R', 'U' },
                { 'S', 'V' },
                { 'T', 'W' },
                { 'U', 'X' },
                { 'V', 'Y' },
                { 'W', 'Z' },
                { 'X', 'A' },
                { 'Y', 'B' },
                { 'Z', 'C' }
            };
        }

        
        public string CesarCode(string line) 
        {
            char tmp;
            StringBuilder ret = new StringBuilder();
            // Itération sur le string line et remplacement avec décalage via code ascii 
            for (int i = 0; i < line.Length; i++)
            {
                tmp = line[i];
                if (Char.IsLetter(tmp)) {
                    //  65 = "A" 
                    tmp = _cesarTable[Char.ToUpper(line[i]) - 65, 1];
                }
                ret.Append(tmp);
            }
            return ret.ToString();
        }

        public string DecryptCesarCode(string line)
        {
            StringBuilder ret = new StringBuilder();
            // e est utile pour les cas où il faut faire un "tour" de la table 
            double e;
            char tmp;
            for (int i = 0; i < line.Length; i++)
            {
                tmp = line[i];
                if (Char.IsLetter(tmp))
                {
                    //Conversion 65 = "A" 
                    e = (Char.ToUpper(line[i]) - 65 - 3);
                    //Recalage 
                    e = e - 26 * Math.Floor(e / 26);
                    tmp = _cesarTable[((int)e), 0];

                }
                ret.Append(tmp);
            }
                return ret.ToString();
        }

        public string GeneralCesarCode(string line, int x)
        {
            StringBuilder ret = new StringBuilder();
            char tmp;
            // e est utile pour les cas où il faut faire un "tour" de la table, permet l'appel facilité de Decrypt
            double e = x - 26.0 * Math.Floor(x / 26.0);
            Console.WriteLine(e);
            for (int i = 0; i < line.Length; i++)
            {
                tmp = line[i];
                if(Char.IsLetter(tmp)){
                    //  65 = "A" 
                    tmp = (char)(((Char.ToUpper(line[i])) - 65 + e) % 26 + 65);

                }
         
                ret.Append( tmp);

            }
            return ret.ToString();
        }

        public string GeneralDecryptCesarCode(string line, int x)
        {
            return GeneralCesarCode(line,-x);
        }
    }
}
