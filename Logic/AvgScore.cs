using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AvgScore
    {
        // Attributs

        /// <summary>
        /// Moyenne d'un élément pédagogique
        /// </summary>
        private float average;

        /// <summary>
        /// Element pédagogique à calculer
        /// </summary>
        private PedagogicalElement element;


        // Propriétés

        /// <summary>
        /// Propriété reliée à la moyenne
        /// </summary>
        public float Average
        {
            get
            {
                return this.average;
            }

            set
            {
                this.average = value;
            }
        }

        /// <summary>
        /// Propriété du nom de l'élément calculée depuis l'élément pédagogique en attribut
        /// </summary>
        public String ElementName
        {
            get
            {
                return this.element.Name;
            }

            set
            {
                this.element.Name = value;
            }
        }


        // Méthodes

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="average"></param>
        /// <param name="pe"></param>
        public AvgScore(float average, PedagogicalElement pe)
        {
            this.average = average;
            this.element = pe;
        }

        /// <summary>
        /// Retourne le nom de l'élément et sa moyenne
        /// </summary>
        /// <returns>String</returns>
        public override String ToString()
        {
            return this.ElementName + ": " + this.average;
        }
    }
}
