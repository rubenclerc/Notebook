using System;
using Xunit;
using Storage;
using Logic;

namespace TestStorage
{
    /// <summary>
    /// Classe de tests pour la classe JsonStorage
    /// </summary>
    public class TestJsonStorage
    {
        /// <summary>
        /// Méthode de tests pour la classe de stockage
        /// </summary>
        [Fact]
        public void TestStorage()
        {
            Logic.Notebook nb0 = new Logic.Notebook();
            Logic.Notebook nb1;
            Logic.Module m0 = new Logic.Module();
            Logic.Module m1 = new Logic.Module();
            Logic.Unit u0 = new Logic.Unit();
            Logic.Unit u1 = new Logic.Unit();

            Storage.JsonStorage i = new Storage.JsonStorage("file");

            u0.Name = "UE1";
            u1.Name = "UE2";
            u0.Coef = 5;
            u1.Coef = 5;
            nb0.AddUnit(u0);
            nb0.AddUnit(u1);

            m0.Coef = 3;
            m0.Name = "POO";
            u0.AddModule(m0);

            m1.Coef = 3;
            m1.Name = "Maths";
            u0.AddModule(m1);

            Logic.Exam exam1 = new Logic.Exam();
            exam1.Score = 20;
            exam1.Module = m0;

            Logic.Exam exam2 = new Logic.Exam();
            exam2.Score = 0;
            exam2.Module = m0;

            Logic.Exam exam3 = new Logic.Exam();
            exam3.Score = 20;
            exam3.Module = m1;

            Logic.Exam exam4 = new Logic.Exam();
            exam4.Score = 0;
            exam4.Module = m1;
            nb0.AddExam(exam1);
            nb0.AddExam(exam2);
            nb0.AddExam(exam3);
            nb0.AddExam(exam4);


            i.Save(nb0);
            nb1 = i.Load();

            nb0.Equals(nb1);
        }
    }
}
