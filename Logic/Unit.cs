using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Unit: PedagogicalElement
    {
        // Attributs


        /// <summary>
        /// Liste des modules d'une unité
        /// </summary>
        [DataMember]
        private List<Module> modules = new List<Module>();


        // Méthodes

        /// <summary>
        /// Liste les différents modules de l'unité
        /// </summary>
        /// <returns>Tableau de modules</returns>
        public Module[] ListModules()
        {
            return this.modules.ToArray();
        }

        /// <summary>
        /// Ajoute un module m à l'unité
        /// </summary>
        /// <param name="m"></param>
        public void AddModule(Module m)
        {
            this.modules.Add(m);
        }

        /// <summary>
        /// Supprime un module m à l'unité
        /// </summary>
        /// <param name="m"></param>
        public void RemoveModule(Module m)
        {
            this.modules.Remove(m);
        }

        /// <summary>
        /// Calcule la moyenne de l'unité
        /// </summary>
        /// <param name="exams"></param>
        /// <returns>Tableau d'AvgScore</returns>
        public AvgScore[] ComputeAverages(Exam[] exams)
        {
            List<Exam> tabExam = new List<Exam>();
            List<AvgScore> avgTab = new List<AvgScore>();

            // Parcourt chaque Examen de chaque Module et ajoute la moyenne de ses examens au tableau de moyennes des modules
            foreach (Module m in this.ListModules())
            {
                // On clear la liste afin de pouvoir recommencer avec un nouveau module
                tabExam.Clear();

                foreach(Exam e in exams)
                {
                    // On ajoute l'examen au module s'il correspond bien au module souhaité
                    if(e.Module.Equals(m))
                    {
                        // On ajoute le module en fonction de son coef
                        for(int i=0; i < m.Coef; i++)
                        {
                            tabExam.Add(e);
                        }
                    }
                }

                // On ne calcule la moyenne que si le nombre d'examens est supérieur à 0 (afin d'avoir un tableau vide si aucun module n'a de moyenne)
                if(tabExam.Count > 0) 
                {
                    // On ajoute la moyenne du module à la liste des moyennes
                    avgTab.Add(m.ComputeAverage(tabExam.ToArray()));
                }

            }

            return avgTab.ToArray();
        }
    }
}
