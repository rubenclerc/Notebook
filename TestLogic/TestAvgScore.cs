using System;
using Xunit;
using Logic;

namespace TestLogic
{
    /// <summary>
    /// Classe regroupant les tests pour la classe AvgScore
    /// </summary>
    public class TestAvgScore
    {

        /// <summary>
        /// Teste le constructeur de la classe et ses propriétés
        /// </summary>
        [Fact]
        public void TestConstruct()
        {
            Module m = new Module();
            m.Name = "Prog objet";

            AvgScore avg = new AvgScore(12, m);

            Assert.Equal(12, avg.Average);
            Assert.Equal(m.Name, avg.ElementName);
        }

        /// <summary>
        /// Teste la méthode ToString() de la classe
        /// </summary>
        [Fact]
        public void TestToString()
        {
            String str = "Prog objet: 12";
            Module m = new Module();
            m.Name = "Prog objet";
            AvgScore avg = new AvgScore(12, m);

            Assert.Equal(str, avg.ToString());
        }
    }
}
