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

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditExamWindow.xaml
    /// </summary>
    public partial class EditExamWindow : Window
    {
        // Attributs

        /// <summary>
        /// Examen lié à la fenêtre
        /// </summary>
        private Exam examen;

        /// <summary>
        /// Notebook lié à la fenêtre
        /// </summary>
        private Logic.Notebook notebook;

        /// <summary>
        /// Storage lié à la fenêtre
        /// </summary>
        private Storage.JsonStorage storage = new Storage.JsonStorage("data.txt");


        // Méthodes

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="nb"></param>
        public EditExamWindow(Logic.Notebook nb)
        {
            // Initialisation des attributs et de la fenêtre
            InitializeComponent();

            this.examen = new Exam();
            this.notebook = nb;
            DrawModules(nb.ListModules());
        }


        /// <summary>
        /// Ajoute les modules à la checkbox correspondante
        /// </summary>
        /// <param name="m"></param>
        private void DrawModules(Module[] m)
        {
            this.modules.Items.Clear();

            foreach(Module module in m)
            {
                this.modules.Items.Add(module);
            }
        }

        /// <summary>
        /// Ferme la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Valide un Examen et l'enregistre dans le Notebook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate(object sender, RoutedEventArgs e)
        {
            // On englobe les modifications de l'objet Exam dans un try catch pour gérer les exceptions
            try
            {
                // On modifie l'objet
                this.examen.Module = (Module)this.modules.SelectedItem;
                this.examen.Teacher = this.teacher.Text;
                this.examen.DateExam = this.date.SelectedDate.Value;
                this.examen.IsAbsent = this.absentCheckbox.IsChecked.Value;

                // Si l'éléève est absent il a 0
                if (this.absentCheckbox.IsChecked.Value)
                {
                    this.examen.Score = 0;
                }
                else
                {
                    this.examen.Score = float.Parse(this.score.Text);
                }

                // On ajoute l'examen au notebook
                this.notebook.AddExam(this.examen);
                this.storage.Save(this.notebook);

                // On finit par fermer la fenêtre
                this.Close();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Gère l'accès aux contrôles lors du clic sur la checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxClick(object sender, RoutedEventArgs e)
        {
            if (this.absentCheckbox.IsChecked.Value)
            {
                this.score.IsEnabled = false;
                this.score.Text = "0";
            }
            else
            {
                this.score.IsEnabled = true;
            }
        }
    }
}
