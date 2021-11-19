using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logic;
using Storage;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        // Attributs

        /// <summary>
        /// Lien avec la partie logique
        /// </summary>
        private Logic.Notebook notebook;

        /// <summary>
        /// Lien avec la partie storage
        /// </summary>
        private JsonStorage storage = new JsonStorage("data.txt");

        // Méthodes

        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="notebook"></param>
        public EditUnitsWindow(Logic.Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;

            DrawUnits();
        }

        /// <summary>
        /// Liste et affiche les unités dans la Listbox correspondante
        /// </summary>
        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            unitListBox.Items.Clear();

            foreach(var item in list)
            {
                unitListBox.Items.Add(item);
            }
        }

        /// <summary>
        /// Liste et affiche les modules dans la Listbox correspondante
        /// </summary>
        private void DrawModules()
        {
            if(this.unitListBox.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();
                this.moduleListBox.Items.Clear();

                foreach(Module m in list)
                {
                    this.moduleListBox.Items.Add(m);
                }
            }
        }

        /// <summary>
        /// Permet d'éditer une unité sélectionnée si l'on double-clique dessus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUnit(object sender, MouseButtonEventArgs e)
        {
            if(unitListBox.SelectedItem is Unit u)
            {
                EditElementsWindow third = new EditElementsWindow(u);

                if(third.ShowDialog() == true)
                {
                    DrawUnits();
                    this.storage.Save(this.notebook);
                }
            }
        }

        /// <summary>
        /// Permet d'ajouter une unité si l'on clique sur le bouton "Add" côté unités
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementsWindow third = new EditElementsWindow(newUnit);

                if(third.ShowDialog() == true)
                {
                    this.notebook.AddUnit(newUnit);
                    this.storage.Save(this.notebook);
                    DrawUnits();

                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Permet de supprimer une unité sélectionnée si l'on clique sur le bouton "Remove" côtés unités
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                if(this.unitListBox.SelectedItem is Unit unit)
                {
                    notebook.RemoveUnit(unit);
                    this.storage.Save(this.notebook);
                    DrawUnits();

                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Affiche les modules correspondants à l'unité sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }

        /// <summary>
        /// Permet d'éditer un module sélectionné si l'on double-clique dessus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditModule(object sender, MouseButtonEventArgs e)
        {
            if (moduleListBox.SelectedItem is Module m)
            {
                EditElementsWindow third = new EditElementsWindow(m);

                if (third.ShowDialog() == true)
                {
                    DrawModules();
                    this.storage.Save(this.notebook);
                }
            }
        }

        /// <summary>
        /// Permet d'ajouter un module à l'unité correspondante si l'on clique sur le bouton "Add" côté module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateModule(object sender, RoutedEventArgs e)
        {
            try
            {
                Module newModule = new Module();
                EditElementsWindow third = new EditElementsWindow(newModule);

                if (third.ShowDialog() == true)
                {
                    // Ajoute le module à l'unité sélectionnée
                    if (this.unitListBox.SelectedItem is Unit unit)
                    {
                        unit.AddModule(newModule);
                        this.moduleListBox.Items.Add(newModule);
                        this.storage.Save(this.notebook);
                        DrawModules();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Supprime le module sélectionné à l'unité correspondante si l'on clique sur le bouton "Remove" côté module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            try
            {
               if(this.unitListBox.SelectedItem is Unit unit)
                {
                    if(this.moduleListBox.SelectedItem is Module module)
                    {
                        unit.RemoveModule(module);
                        this.storage.Save(this.notebook);
                        DrawModules();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
