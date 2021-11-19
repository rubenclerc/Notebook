using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Module: PedagogicalElement
    {
        // Méthodes

        /// <summary>
        /// Calcule la moyenne d'un module
        /// </summary>
        /// <param name="exams"></param>
        /// <returns>Objet AvgScore</returns>
        public AvgScore ComputeAverage(Exam[] exams)
        {
            float sum = 0;
            int count = 0;
            float avg = 0;
            AvgScore avgRes;
            
            // Somme des notes
            foreach(Exam exam in exams)
            {
                // Somme en fonction du coefficient
                for(int i=0; i<exam.Coef; i++)
                {
                    sum += exam.Score;
                    count++;
                }                
            }

            // Moyenne
            avg = sum / count;

            avgRes = new AvgScore(avg, this);
            return avgRes;
        }
    }
}
