using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Storage
{
    /// <summary>
    /// Classe de sérialisation des données implémantant l'interfance IStorage
    /// </summary>
    public class JsonStorage : IStorage
    {
        // Attributs

        /// <summary>
        /// Nom du fichier
        /// </summary>
        private string filename;

        /// <summary>
        /// Serialiser
        /// </summary>
        private DataContractJsonSerializer ser;

        // Méthodes

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="filename">nom du fichier</param>
        public JsonStorage(string filename)
        {
            this.ser = new DataContractJsonSerializer(typeof(Notebook));
            this.filename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + filename;
        }

        /// <summary>
        /// Charge les données du serializer
        /// </summary>
        /// <returns>Notebook chargé</returns>
        public Notebook Load()
        {
            Notebook nb;

            try
            {
                using(FileStream flux = new FileStream(this.filename, FileMode.Open))
                {
                    nb = this.ser.ReadObject(flux) as Notebook;
                    flux.Close();
                }
            }
            catch
            {
                nb = new Logic.Notebook();
            }

            return nb;
        }

        /// <summary>
        /// Enregistre les données dans le fichier
        /// </summary>
        /// <param name="nb">Notebook à enregistrer</param>
        public void Save(Notebook nb)
        {
            FileStream flux = new FileStream(this.filename, FileMode.Create);
            this.ser.WriteObject(flux, nb);
            flux.Close();
        }
    }
}
