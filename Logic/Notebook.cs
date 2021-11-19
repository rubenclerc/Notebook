using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Notebook
    {
        // Attributs

        
        /// <summary>
        /// Liste des différentes unité du notebook
        /// </summary>
        [DataMember]
        private List<Unit> units = new List<Unit>();

        /// <summary>
        /// Liste des différents examens du notebook
        /// </summary>
        [DataMember]
        private List<Exam> exams = new List<Exam>();


        // Méthodes

        /// <summary>
        /// Retourne un tableau des unites existantes
        /// </summary>
        /// <returns>Tableau d'unités</returns>
        public Unit[] ListUnits()
        {
            return this.units.ToArray();
        }

        /// <summary>
        /// Ajoute une unité
        /// </summary>
        /// <param name="unit"></param>
        public void AddUnit(Unit unit)
        {
            this.units.Add(unit);
        }

        /// <summary>
        /// Supprime une unité
        /// </summary>
        /// <param name="unit"></param>
        public void RemoveUnit(Unit unit)
        {
            this.units.Remove(unit);
        }

        /// <summary>
        /// Liste tous les modules de chaque unité
        /// </summary>
        /// <returns>Tableau de modules</returns>
        public Module[] ListModules()
        {
            List<Module> res = new List<Module>();

            // Parcourt les différentes modules de chaque unité
            foreach(Unit unit in this.units.ToArray())
            {
                foreach(Module m in unit.ListModules())
                {
                    res.Add(m);
                }
            }

            return res.ToArray();
        }

        /// <summary>
        /// Liste les examens du notebook
        /// </summary>
        /// <returns>Tableau d'examens</returns>
        public Exam[] ListExams()
        {
            return this.exams.ToArray();
        }

        /// <summary>
        /// Ajoute un examen à la liste d'examens
        /// </summary>
        /// <param name="exam"></param>
        public void AddExam(Exam exam)
        {
            this.exams.Add(exam);
        }

        /// <summary>
        /// Liste les examens
        /// </summary>
        public Exam[] ListExam()
        {
            return this.exams.ToArray();
        }

        /// <summary>
        /// Calcule la moyenne de chaque unit et l'ajoute à un tableau
        /// </summary>
        /// <returns>Tableau d'AvgScore</returns>
        public AvgScore[] ComputeScores()
        {
            // Initialisation
            List<AvgScore> avgList = new List<AvgScore>();
            Exam[] tabtExam = this.ListExam();
            AvgScore[] tabAvgUnit;

            PedagogicalElement moyenneG = new PedagogicalElement();
            moyenneG.Name = "Overall average";

            float sum = 0;
            int count = 0;
            float avg = 0;

            // Parcourt les unités et calcule leur moyenne
            foreach(Unit u in this.ListUnits())
            {
                tabAvgUnit= u.ComputeAverages(tabtExam);
                
                // Calcule de la somme
                for(int i=0; i<tabAvgUnit.Length; i++)
                {
                    sum += tabAvgUnit[i].Average;
                    count++;
                }

                avg = sum / count;

                // Ajout de la moyenne de l'unité à la liste
                avgList.Add(new AvgScore(avg, u));
            }

            // Reinitialisation
            count = 0;
            sum = 0;
            avg = 0;

            // Calcule la moyenne générale
            for(int i=0; i<avgList.Count; i++)
            {
                // Parcourt toutes les unités et teste si l'item correspond à la bonne unité, puis calcule en fonction de son coef
                foreach(Unit unit in this.ListUnits())
                {
                    if(unit.Name == avgList.ToArray()[i].ElementName)
                    {
                        // Calcule en fonction du coef
                        for(int j=0; j < unit.Coef; j++)
                        {
                            sum += avgList.ToArray()[i].Average;
                            count++;
                        }

                    }
                }
            }

            avg = sum / count;

            // Ajout de la moyenne générale
            avgList.Add(new AvgScore(avg, moyenneG));

            return avgList.ToArray();
        }
    }
}
