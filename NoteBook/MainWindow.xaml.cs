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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Storage;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Attributs

        /// <summary>
        /// Lien vers la couche Logique
        /// </summary>
        private Logic.Notebook notebook;

        /// <summary>
        /// Lien vers la couche de stockage
        /// </summary>
        private JsonStorage storage;


        // Méthodes

        /// <summary>
        /// Constructeur de la fenête principale
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.storage = new JsonStorage("data.txt");
            this.notebook = storage.Load();
        }

        /// <summary>
        /// Affiche le menu d'édition des unités si l'on clique sur le bouton "Saisir les matières"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            EditUnitsWindow second = new EditUnitsWindow(this.notebook);
            second.Show();
            this.storage.Save(this.notebook);
        }

        /// <summary>
        /// Affiche le menu d'ajout d'examen si l'on clique sur le bouton "Ajouter un examen"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateExam(object sender, RoutedEventArgs e)
        {
            EditExamWindow second = new EditExamWindow(this.notebook);
            second.Show();
            this.storage.Save(this.notebook);
        }

        /// <summary>
        /// Affiche le menu de listage des examens si l'on clique sur le bouton "Afficher les moyennes"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListEx(object sender, RoutedEventArgs e)
        {
            ListExamsWindow second = new ListExamsWindow(this.notebook);
            second.Show();
        }
    }
}
