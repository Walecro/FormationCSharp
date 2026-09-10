using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie3
{
    public class Morse
    {
        public const string Taah = "===";
        public const string Ti = "=";
        public const string Point = ".";
        public const string PointLetter = "...";
        public const string PointWord = ".....";

        private readonly Dictionary<string, char> _alphabet;

        public Morse()
        {
            _alphabet = new Dictionary<string, char>()
            {
                {$"{Ti}.{Taah}", 'A'},
                {$"{Taah}.{Ti}.{Ti}.{Ti}", 'B'},
                {$"{Taah}.{Ti}.{Taah}.{Ti}", 'C'},
                {$"{Taah}.{Ti}.{Ti}", 'D'},
                {$"{Ti}", 'E'},
                {$"{Ti}.{Ti}.{Taah}.{Ti}", 'F'},
                {$"{Taah}.{Taah}.{Ti}", 'G'},
                {$"{Ti}.{Ti}.{Ti}.{Ti}", 'H'},
                {$"{Ti}.{Ti}", 'I'},
                {$"{Ti}.{Taah}.{Taah}.{Taah}", 'J'},
                {$"{Taah}.{Ti}.{Taah}", 'K'},
                {$"{Ti}.{Taah}.{Ti}.{Ti}", 'L'},
                {$"{Taah}.{Taah}", 'M'},
                {$"{Taah}.{Ti}", 'N'},
                {$"{Taah}.{Taah}.{Taah}", 'O'},
                {$"{Ti}.{Taah}.{Taah}.{Ti}", 'P'},
                {$"{Taah}.{Taah}.{Ti}.{Taah}", 'Q'},
                {$"{Ti}.{Taah}.{Ti}", 'R'},
                {$"{Ti}.{Ti}.{Ti}", 'S'},
                {$"{Taah}", 'T'},
                {$"{Ti}.{Ti}.{Taah}", 'U'},
                {$"{Ti}.{Ti}.{Ti}.{Taah}", 'V'},
                {$"{Ti}.{Taah}.{Taah}", 'W'},
                {$"{Taah}.{Ti}.{Ti}.{Taah}", 'X'},
                {$"{Taah}.{Ti}.{Taah}.{Taah}", 'Y'},
                {$"{Taah}.{Taah}.{Ti}.{Ti}", 'Z'},
            };
        }

        public int LettersCount(string code)
        {
            return code.Split(new string[] { PointLetter }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public int WordsCount(string code)
        {
            return code.Split(new string[] { PointWord }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Fonction de traduction du Morse vers l'alphabet latin
        /// </summary>
        public string MorseTranslation(string code)
        {
            string[] words = code.Split(new string[] { PointWord  }, WordsCount(code),  StringSplitOptions.RemoveEmptyEntries) ;
            string[] letters;
            StringBuilder ret = new StringBuilder();
            foreach (string word in words)
            {
                letters = word.Split(new string[] { PointLetter }, LettersCount(word), StringSplitOptions.RemoveEmptyEntries);

                foreach( var letter in letters)
                {
                    try
                    {
                        ret.Append(_alphabet[letter]);
                    }
                    catch (KeyNotFoundException e)
                    {
                        ret.Append("+");
                    }

                }
                ret.Append("\n");
            }
            return ret.ToString();
        }

        /// <summary>
        /// Fonction de nettoyage avant envoi dans MorseTranslation
        /// </summary>
        public string EfficientMorseTranslation(string code)
        {
            string code_clean = code;
            // Nettoyage à droite et à gauche des points inutiles
            code_clean = code.Trim('.');
            code_clean = code_clean.Replace("=....=", "=...=");
            code_clean = code_clean.Replace("=..=", "=.=");

            int cpt_p = 0;
            int start_index = 0;

            // Clean up des chaines de + de 5 .
            for (int i = 0; i < code_clean.Length; i++)
            {
                if (code_clean[i] == '.')
                {
                    if (cpt_p == 0)
                    {
                        start_index = i;
                    }
                    cpt_p++;
                }
                else
                {
                    if (cpt_p > 5)
                    {
                        code_clean = code_clean.Remove(start_index + 5, cpt_p-5);
                    }
                    cpt_p = 0;

                }
            }
            
            return MorseTranslation(code_clean);
        }

        public string MorseEncryption(string sentence) 
        {
            Dictionary<char,string> Dico_Reverse = _alphabet.ToDictionary(x => x.Value, x => x.Key);
            StringBuilder Retstrb = new StringBuilder();

            foreach( char letter in sentence)
            {
                if(Char.IsLetter(letter))
                {
                    Retstrb.Append(Dico_Reverse[letter] + PointLetter );
                    
                }
                else if (letter == ' ')
                {
                    Retstrb.Append(PointWord);
                }
                else
                {
                    throw new ArgumentException();
                }
            }


            string Retstr = Retstrb.ToString();
            //On retire les derniers ... ajouté 
            return Retstr.Trim('.');
        }
    }
}
