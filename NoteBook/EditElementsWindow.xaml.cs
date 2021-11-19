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
    /// Logique d'interaction pour EditElementsWindow.xaml
    /// </summary>
    public partial class EditElementsWindow : Window
    {
        // Attributs

        /// <summary>
        /// Lien vers la couche Logique
        /// </summary>
        PedagogicalElement pedagogicalElement;


        // Méthodes

        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="elt"></param>
        public EditElementsWindow(PedagogicalElement elt)
        {
            InitializeComponent();
            this.pedagogicalElement = elt;

            name.Text = pedagogicalElement.Name;
            coef.Text = pedagogicalElement.Coef.ToString();
        }

        /// <summary>
        /// Confirme et enregistre les informations rentrées dans les TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                this.pedagogicalElement.Name = name.Text;
                this.pedagogicalElement.Coef = (float)Convert.ToDouble(coef.Text);
                DialogResult = true;
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
