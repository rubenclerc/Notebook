using System;
using System.Collections.Generic;
using Xunit;
using Logic;

namespace TestLogic
{
    /// <summary>
    /// Classe regroupant les tests de la classe Module
    /// </summary>
    public class TestModule
    {
        /// <summary>
        /// Teste la méthode ComputeAverage()
        /// </summary>
        [Fact]
        public void TestComputeAverage()
        {
            Module m0 = new Module();

            List<Exam> listExams = new List<Exam>();
            Exam e0 = new Exam();
            Exam e1 = new Exam();
            e0.Score = 20;
            e1.Score = 10;

            listExams.Add(e0);
            listExams.Add(e1);

            Assert.Equal(15, m0.ComputeAverage(listExams.ToArray()).Average);
        }

    }
}
