using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie4
{
    public static class ClassCouncil
    {
        

        public static void SchoolMeans(string pathIn, string pathOut)
        {
            int readLen;
            string[] readin;
            Dictionary<string, List<float>> Moyennes = new Dictionary<string, List<float>>();
            float note;
            List<float> cur_mat;

            if (!File.Exists(pathIn))
            {
                CreateFileEntry(pathIn);
            }
            
            
            //Lecture du fichier en entrée 
            using(FileStream fs = File.OpenRead(pathIn))
            {
                byte[] b = new byte[1024];
                UTF8Encoding tempB = new UTF8Encoding(true);
                while ((readLen = fs.Read(b, 0, b.Length)) > 0)
                {
                    readin = tempB.GetString(b, 0, readLen).Split(';', '\n');
                    for (int cpt = 0; cpt < readin.Length-2; cpt += 3)
                    {
                        float.TryParse(readin[cpt+2], out note);
                        Console.WriteLine(note);
                        if (!Moyennes.ContainsKey(readin[cpt+1]))
                        {
                           Moyennes.Add(readin[cpt+1], new List<float> { note });
                        }
                        else 
                        {
                            cur_mat = Moyennes[readin[cpt + 1]];
                            cur_mat.Add(note);
                        }
                    }
                    
                }
            }

            using (FileStream fs = File.Open
              (pathOut,FileMode.OpenOrCreate))
            {
                foreach(string mat in Moyennes.Keys)
                {
                    AddText(fs, mat +" "+Moyennes[mat].Average()+" \n");
                }
            }
        }


        private static void CreateFileEntry(string pathIn)
        {
            using (FileStream fs = File.Create(pathIn))
            {
                AddText(fs, "Jesse  ;Histoire  ;2,0\n");
                AddText(fs, "Clément;Physique  ;12,0\n");
                AddText(fs, "Jesse  ;Physique  ;14,0\n");
                AddText(fs, "Zidane ;Physique  ;11,0\n");
                AddText(fs, "Clément;Histoire  ;14,0\n");
                AddText(fs, "Jesse  ;Maths     ;19,0\n");
            }

        }

        //Récup de la doc c#
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

    }
}
