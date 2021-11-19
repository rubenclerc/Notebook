using System;
using Xunit;
using Logic;

namespace TestLogic
{
    /// <summary>
    /// Classe regroupant les tests pour la classe Logic.Notebook
    /// </summary>
    public class TestNotebook
    {
        /// <summary>
        /// Teste la méthode ListUnit()
        /// </summary>
        [Fact]
        public void TestListUnits()
        {
            Logic.Notebook n = new Logic.Notebook();

            // Teste si le tableau est non null et vide
            Assert.NotNull(n.ListUnits());
            Assert.Empty(n.ListUnits());
        }

        /// <summary>
        /// Teste la méthode AddUnit()
        /// </summary>
        [Fact]
        public void TestAddUnit()
        {
            Logic.Notebook n = new Logic.Notebook();
            
            Unit unit = new Unit();
            unit.Name = "unité";
            unit.Coef = 2;
            n.AddUnit(unit);
            Unit[] tabUnit = n.ListUnits();

            // Teste si le tableau tabUnit ne contient qu'un seul élément
            Assert.Single(tabUnit);

            // Teste si le tableau contient bien l'unité précédemment créée
            Assert.Equal(unit, tabUnit[0]);

        }

        /// <summary>
        /// Teste la méthode RemoveUnit()
        /// </summary>
        [Fact]
        public void TestRemoveUnit()
        {
            Logic.Notebook n = new Logic.Notebook();
            Unit unit = new Unit();
            unit.Name = "unité";
            unit.Coef = 2;

            // On ajoute une unité puis on la supprime (pas besoin de tester l'ajout car on sait qu'il fonctionne grâce au test précédent)
            n.AddUnit(unit);
            n.RemoveUnit(unit);

            // Teste si le tableau est non null et vide
            Assert.NotNull(n.ListUnits());
            Assert.Empty(n.ListUnits());
        }

        /// <summary>
        /// Teste la méthode ListModules()
        /// </summary>
        [Fact]
        public void TestListModules()
        {
            Logic.Notebook n = new Logic.Notebook();

            Unit unit0 = new Unit();
            Module module0 = new Module();

            n.AddUnit(unit0);
            unit0.AddModule(module0);
            Module[] listModules = n.ListModules();

            // Teste si le tableau listModules ne contient qu'un seul élément
            Assert.Single(listModules);

            // Teste si le tableau contient bien les modules précédemment créés
            Assert.Equal(module0, listModules[0]);

        }

        /// <summary>
        /// Test la méthode ListExam()
        /// </summary>
        [Fact]
        public void TestListExam()
        {
            Logic.Notebook n = new Logic.Notebook();

            // Teste si le tableau est non null et vide
            Assert.NotNull(n.ListExam());
            Assert.Empty(n.ListExam());
        }

        /// <summary>
        /// Teste la méthode AddExam()
        /// </summary>
        [Fact]
        public void TestAddExam()
        {
            Logic.Notebook n = new Logic.Notebook();

            Exam exam = new Exam();
            n.AddExam(exam);
            Exam[] tabExam = n.ListExam();

            // Teste si le tableau tabExam ne contient qu'un seul élément
            Assert.Single(tabExam);

            // Teste si le tableau contient bien l'examen précédemment créé
            Assert.Equal(exam, tabExam[0]);

        }

        /// <summary>
        /// Teste la méthode ComputeScores()
        /// </summary>
        [Fact]
        public void TestComputeScores()
        {
            Logic.Notebook Nb = new Logic.Notebook();
            Unit unit = new Unit();
            Unit unit2 = new Unit();

            unit.Name = "UE1";
            unit.Name = "UE2";
            unit.Coef = 5;
            unit2.Coef = 5;

            Nb.AddUnit(unit);
            Nb.AddUnit(unit2);

            Module mod0 = new Module();
            mod0.Coef = 3;
            mod0.Name = "Prog Objet";
            unit.AddModule(mod0);

            Module mod1 = new Module();
            mod1.Coef = 3;
            mod1.Name = "Analyse";
            unit.AddModule(mod1);

            Module mod2 = new Module();
            mod2.Coef = 3;
            mod2.Name = "Arithmétique";
            unit2.AddModule(mod2);

            Module mod3 = new Module();
            mod3.Coef = 3;
            mod3.Name = "Structures de données";
            unit2.AddModule(mod3);

            Exam exam1 = new Exam();
            exam1.Score = 20;
            exam1.Module = mod0;

            Exam exam2 = new Exam();
            exam2.Score = 0;
            exam2.Module = mod0;

            Exam exam3 = new Exam();
            exam3.Score = 20;
            exam3.Module = mod1;

            Exam exam4 = new Exam();
            exam4.Score = 0;
            exam4.Module = mod1;

            Exam exam5 = new Exam();
            exam5.Score = 20;
            exam5.Module = mod2;

            Exam exam6 = new Exam();
            exam6.Score = 0;
            exam6.Module = mod2;

            Exam exam7 = new Exam();
            exam7.Score = 20;
            exam7.Module = mod3;

            Exam exam8 = new Exam();
            exam8.Score = 0;
            exam8.Module = mod3;

            Nb.AddExam(exam1);
            Nb.AddExam(exam2);
            Nb.AddExam(exam3);
            Nb.AddExam(exam4);
            Nb.AddExam(exam5);
            Nb.AddExam(exam6);
            Nb.AddExam(exam7);
            Nb.AddExam(exam8);

            AvgScore[] avg = Nb.ComputeScores();
            int cpt = 0;

            foreach (AvgScore a in avg)
            {
                Assert.Equal(10, avg[cpt].Average);
                cpt++;
            }
        }
    }
}