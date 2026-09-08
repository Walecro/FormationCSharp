using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public class QCM
    {

        public string Question;
        public string[] Reponses;
        public int Solution;
        public int Ponderation;


        public QCM()
        {
            Question = "Pourquoi la vie? ";
            Reponses = new string[] { "La réunion entre les peuples et le partage (Ou pas trop . . . ) ",
                    "Un dernier concert de Johnny",
                    "La lapidation publique de Alexandre" };

            Ponderation = 1;

            Solution = 2;
        }

        public QCM(string Q, string[] R, int S, int P)
        {
            Question = Q;

            Reponses = R;

            Ponderation = P;

            Solution = S;
        }

        public bool QCMValidity(QCM qcm)
        {
            bool OK = true;

            if (Ponderation < 0 || Reponses.Length == 0)
            {
                OK = !OK;
            }


            return OK;
        }

        public int AskQuestion(QCM q)
        {
            int rep;
            int PtsRet = 0;
            Console.WriteLine(q.Question);
            for(int i = 0; i < q.Reponses.Length; i++)
            {
                Console.Write($"{ i + 1}. {q.Reponses[i]} ");
            }
            Console.Write("Réponse : ");
            do
            {
                int.TryParse(Console.ReadLine(), out rep );

            } while (rep < 0 || rep > q.Reponses.Length);

            if (rep == q.Solution)
            {
                PtsRet = q.Ponderation;
            }

            return PtsRet;

        }

        public static int AskQuestions(QCM[] q)
        {
            int CumPts = 0;
            foreach(QCM Question in q)
            {
                CumPts += Question.AskQuestion(Question);
            }
            

            return CumPts;

        }

    }
}
