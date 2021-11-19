using System;
using Xunit;
using Logic;

namespace TestLogic
{
    /// <summary>
    /// Classe regroupant les tests pour la classe Exam
    /// </summary>
    public class TestExam
    {
        /// <summary>
        /// Teste les propriétés de la classe
        /// </summary>
        [Fact]
        public void TestProperties()
        {
            // Test avec une instance valide
            Exam e0 = new Exam();
            e0.Teacher = "M. Bob";
            e0.Coef = 1;
            e0.Score = 3;

            Assert.Equal("M. Bob", e0.Teacher);
            Assert.Equal(1, e0.Coef);
            Assert.Equal(3, e0.Score);
            Assert.NotNull(e0.Module);

            // Test avec un score strictement inférieur à 0
            Assert.Throws<Exception> (()=> { e0.Score = -5; } );

            // Test avec un score strictement supérieur à 20
            Assert.Throws<Exception>(() => { e0.Score = 21; });

            // Test avec un coef égal à 0
            Assert.Throws<Exception>(() => { e0.Coef = 0; });

            // Test aec un coef strictement inférieur à 0
            Assert.Throws<Exception>(() => { e0.Coef = -2; });
        }

        [Fact]
        public void TestEquals()
        {
            Module m = new Module();
            m.Name = "SD";
            m.Coef = 2;

            Exam e = new Exam();
            e.Coef = 1;
            e.DateExam = DateTime.Now;
            e.Teacher = "M. Guidet";
            e.Score = 18;
            e.Module = m;

            Exam e1 = new Exam();
            e1.Coef = 1;
            e1.DateExam = DateTime.Now;
            e1.Teacher = "M. Guidet";
            e1.Score = 18;
            e1.Module = m;

            Assert.True(e.Equals(e1));
        }

    }
}
