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
    /// Logique d'interaction pour ListExamsWindow.xaml
    /// </summary>
    public partial class ListExamsWindow : Window
    {
        // Attributs

        /// <summary>
        /// Notebook associé à la fenêtre
        /// </summary>
        private Logic.Notebook nb;


        // Méthodes

        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="nb"></param>
        public ListExamsWindow(Logic.Notebook nb)
        {
            InitializeComponent();
            this.nb = nb;
            DrawExams();
        }

        /// <summary>
        /// Liste les examens du notebook dans la listbox
        /// </summary>
        private void DrawExams()
        {
            this.exams.Items.Clear();
            this.averages.Items.Clear();

            foreach(Logic.Exam e in this.nb.ListExam())
            {
                this.exams.Items.Add(e);
            }

            foreach(AvgScore avg in this.nb.ComputeScores())
            {
                this.averages.Items.Add(avg);
            }
            
        }

        /// <summary>
        /// Ferme la fenête au clic du bouton close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
