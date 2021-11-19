using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Exam
    {
        // Attributs

        /// <summary>
        /// Professeur donnant l'examen
        /// </summary>
        [DataMember]
        private String teacher;

        /// <summary>
        /// Date de l'examen
        /// </summary>
        [DataMember]
        private DateTime dateExam = DateTime.Now;

        /// <summary>
        /// Coefficient de l'examen
        /// </summary>
        [DataMember]
        private float coef = 1;

        /// <summary>
        /// Indique si l'élève a été absent lors de l'examen
        /// </summary>
        [DataMember]
        private Boolean isAbsent = false;

        /// <summary>
        /// Note de l'élève
        /// </summary>
        [DataMember]
        private float score = 0;

        /// <summary>
        /// Module correspondant à l'examen
        /// </summary>
        [DataMember]
        private Module module = new Module();


        // Propriétés

        /// <summary>
        /// Propriété correspondant à l'attribut coef
        /// </summary>
        public float Coef
        {
            get
            {
                return this.coef;
            }

            set
            {
                // Lève une exception si le coef est inférieur ou égal à 0
                if (!(value > 0)) throw new Exception("The coef must be > 0");
                this.coef = value;
            }
        }

        /// <summary>
        /// Propriété correspondant à l'attribut module
        /// </summary>
        public Module Module
        {
            get
            {
                return this.module;
            }
            set
            {
                this.module = value;
            }
        }

        /// <summary>
        /// Propriété correspondant à l'attribut teacher
        /// </summary>
        public String Teacher
        {
            get
            {
                return this.teacher;
            }

            set
            {
                //Lève une exception si le nom du professeur est une chaîne vide
                if (value.Length == 0) throw new Exception("The name's length must be > 0");
                this.teacher = value;
            }
        }

        /// <summary>
        /// Propriété correspondant à l'attribut dateExam
        /// </summary>
        public DateTime DateExam
        {
            get
            {
                return this.dateExam;
            }
            set
            {
                this.dateExam = value;
            }
        }

        /// <summary>
        /// Propriété correspondant à l'attribut isAbsent
        /// </summary>
        public Boolean IsAbsent
        {
            get
            {
                return this.isAbsent;
            }

            set
            {
                this.isAbsent = value;
            }
        }

        /// <summary>
        /// Propriété correspondant à l'attribut score
        /// </summary>
        public float Score
        {
            get
            {
                return this.score;
            }

            set
            {
                // Lève une exception si le score est inférieur ou égal à 0
                if (value < 0 || value > 20) throw new Exception("The score must be >= 0 and <= 20");
                this.score = value;
            }
        }

        // Méthodes

        /// <summary>
        /// Teste si deux examens sont égaux
        /// </summary>
        /// <param name="obj">objet</param>
        /// <returns>booléen</returns>
        public override bool Equals(object obj)
        {
            return obj is Exam exam &&
                   teacher == exam.teacher &&
                   dateExam.Second == exam.dateExam.Second &&
                   coef == exam.coef &&
                   isAbsent == exam.isAbsent &&
                   score == exam.score &&
                   this.module.Equals(exam.module) &&
                   Coef == exam.Coef &&
                   this.Module.Equals(exam.Module) &&
                   Teacher == exam.Teacher &&
                   DateExam.Second == exam.DateExam.Second &&
                   IsAbsent == exam.IsAbsent &&
                   Score == exam.Score;
        }

    }
}