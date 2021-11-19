using System;
using Xunit;
using Logic;

namespace TestLogic
{
    /// <summary>
    /// Classe regroupant les tests pour la classe PedagogicalElement
    /// </summary>
    public class TestPedagogicalElement
    {
        /// <summary>
        /// Teste les propriétés Name et Coef
        /// </summary>
        [Fact]
        public void TestInit()
        {
            // Test avec une instance valide
            PedagogicalElement p0 = new PedagogicalElement();
            p0.Name = "Test";
            p0.Coef = (float) 2.5;
            Assert.Equal("Test", p0.Name);
            Assert.Equal((float)2.5, p0.Coef);

            // Test avec une chaîne de caractères vide
            Assert.Throws<Exception> (()=> { p0.Name = ""; } );

            // Test avec un coef égal à 0
            Assert.Throws<Exception>(() => { p0.Coef = (float) 0.0; });

            // Test avec un coef inférieur à 0
            Assert.Throws<Exception>(() => { p0.Coef = (float)-1.3; });

        }

        /// <summary>
        /// Teste la méthode Equals()
        /// </summary>
        [Fact]
        public void TestEquals()
        {
            Unit u = new Unit();
            u.Name = "UE1";
            u.Coef = 2;

            Unit u1 = new Unit();
            u1.Name = "UE1";
            u1.Coef = 2;

            Assert.True(u.Equals(u1));
        }
    }
}
