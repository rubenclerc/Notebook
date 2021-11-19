using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class PedagogicalElement
    {
        // Attributs

        /// <summary>
        /// Nom de l'élément
        /// </summary>
        [DataMember]
        private String name;

        /// <summary>
        /// Coefficient de l'élément
        /// </summary>
        [DataMember]
        private float coef = 1;


        // Propriétés

        /// <summary>
        /// Propriété reliée à l'attribut name
        /// </summary>
        public String Name
        {
            get
            {
                return this.name;
            }

            set
            {
                //Lève une exception si le nom est une chaîne vide
                if (value.Length == 0) throw new Exception("The name's length must be > 0");
                this.name = value;
            }
        }

        /// <summary>
        /// Propriété reliée à l'attribut coef
        /// </summary>
        public float Coef
        {
            get
            {
                return this.coef;
            }

            set
            {
                //Lève une exception si le coef est inférieur ou égal à 0
                if (value <= 0) throw new Exception("The coef must be > 0");
                this.coef = value;
            }
        }


        // Méthodes

        /// <summary>
        /// Retourne une chaîne contenant le nom de l'élément puis son coef entre parenthèses
        /// </summary>
        /// <returns>chaîne de caractères</returns>
        public override String ToString()
        {
            return this.Name + " (" + this.Coef + ")";
        }

        /// <summary>
        /// Indique si deux Pedagogigal element sont égaux
        /// </summary>
        /// <param name="obj">Objet</param>
        /// <returns>booléen</returns>
        public override bool Equals(object obj)
        {
            return obj is PedagogicalElement element &&
                   name == element.name &&
                   coef == element.coef &&
                   Name == element.Name &&
                   Coef == element.Coef;
        }


    }
}
