using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Interface dédiée à la persistance des données
    /// </summary>
    public interface IStorage
    {
        Notebook Load();
        void Save(Notebook nb);
    }
}
