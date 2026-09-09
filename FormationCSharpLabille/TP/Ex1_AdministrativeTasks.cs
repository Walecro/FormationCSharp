using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie3
{
    public static class AdministrativeTasks
    {
        public static string EliminateSeditiousThoughts(string text, string[] prohibitedTerms)
        {
            string replacing;
            foreach (string s in prohibitedTerms)
            {
                replacing = "";
                //Alim de replacing avec le bon nb de X 
                for(int i = 0; i< s.Length; i++)
                {
                    replacing += "X";
                }
                text = text.Replace(s, replacing);
            }
            return text;
        }

        public static bool ControlFormat(string line)
        {
            // Split ? 
            string sCiv = line.Substring(0, 4);
            string sNom = line.Substring(5, 12);
            string sPre = line.Substring(18, 12);
            string sAge = line.Substring(31, 2);


            if (line.Length != 33 )
            {

                return false;
            }
            // Enum ? 
            if (sCiv.CompareTo("M.  ") != 0 && sCiv.CompareTo("Mme ") != 0 && sCiv.CompareTo("Mlle") != 0)
            {

                return false;
            }

            if (!Char.IsLetter(sNom[0]) || !Char.IsLetter(sPre[0]))
            {

                return false;
            }

            if(!Char.IsDigit(sAge[0]) || !Char.IsDigit(sAge[1]))
            {
                return false;
            }

            return true;
        }
       
        public static string ChangeDate(string report)
        {
            int index = 0;
            while(index < report.Length)
            {   
                //Tombe t on sur une date ? 

                // Si oui 
                if (Char.IsDigit(report[index]))
                {
                    report = report.Replace(report.Substring(index,10), $"{report.Substring(index+8, 2)}.{report.Substring(index+5, 2)}.{report.Substring(index+2, 2)}");

                    //Décalage de de la taille d'une nouvelle date JJ.MM.AA
                    index += 8;
                }
                else
                {
                    //Sinon on avance
                    index++;

                }

            }
            return report;
        }
    }
}
