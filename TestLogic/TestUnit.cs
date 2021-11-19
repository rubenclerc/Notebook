using System;
using System.Collections.Generic;
using Xunit;
using Logic;

namespace TestLogic
{
    /// <summary>
    /// Classe regroupant les tests pour la classe Unit
    /// </summary>
    public class TestUnit
    {
        /// <summary>
        /// Teste la méthode ListModules()
        /// </summary>
        [Fact]
        public void TestListModules()
        {
            Unit unit = new Unit();

            // Teste si le tableau est non null et vide
            Assert.NotNull(unit.ListModules());
            Assert.Empty(unit.ListModules());
        }

        /// <summary>
        /// Teste la méthode AddModules()
        /// </summary>
        [Fact]
        public void TestAddModule()
        {
            Unit unit = new Unit();
            unit.Name = "unité";
            unit.Coef = 2;

            Module module = new Module();
            module.Name = "module";
            module.Coef = 1;

            unit.AddModule(module);
            Module[] tabModule = unit.ListModules();

            // Teste si le tableau tabUnit ne contient qu'un seul élément
            Assert.Single(tabModule);

            // Teste si le tableau contient bien le module précédemment créé
            Assert.Equal(module, tabModule[0]);
        }

        /// <summary>
        /// Teste la méthode RemoveModule()
        /// </summary>
        [Fact]
        public void TestRemoveModule()
        {
            Unit unit = new Unit();
            unit.Name = "unit";
            unit.Coef = 1;

            Module module = new Module();
            module.Name = "module";
            module.Coef = 2;

            // On ajoute un module puis on le supprime (pas besoin de tester l'ajout car on sait qu'il fonctionne grâce au test précédent)
            unit.AddModule(module);
            unit.RemoveModule(module);

            // Teste si le tableau est non null et vide
            Assert.NotNull(unit.ListModules());
            Assert.Empty(unit.ListModules());

        }

        /// <summary>
        /// Teste la méthode ComputeAverages()
        /// </summary>
        [Fact]
        public void TestComputeAverages()
        {
            Unit unit = new Unit();

            Module mod0 = new Module();
            mod0.Coef = 3;
            mod0.Name = "POO";
            unit.AddModule(mod0);

            Module mod1 = new Module();
            mod1.Coef = 3;
            mod1.Name = "Maths";
            unit.AddModule(mod1);

            Exam exam1 = new Exam();
            exam1.Score = 20;
            exam1.Module = mod0;

            Exam exam2 = new Exam();
            exam2.Score = 0;
            exam2.Module = mod0;

            Exam exam3 = new Exam();
            exam3.Score = 0;
            exam3.Module = mod1;

            Exam exam4 = new Exam();
            exam4.Score = 20;
            exam4.Module = mod1;

            List<Exam> exams = new List<Exam>();
            exams.Add(exam1);
            exams.Add(exam2);
            exams.Add(exam3);
            exams.Add(exam4);
            Exam[] exam = exams.ToArray();
            AvgScore[] avg = unit.ComputeAverages(exam);
            exam = exams.ToArray();
            avg = unit.ComputeAverages(exam);
            int i = 0;
            foreach (AvgScore a in avg)
            {
                Assert.Equal(10, avg[i].Average);
                i++;
            }
        }
    }
}
