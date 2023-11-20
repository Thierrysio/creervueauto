using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creervueauto.Modeles
{
    internal class Typologie
    {
        #region Attributs

        public static List<Typologie> CollClasse = new List<Typologie>();
        private string _nom;

        #endregion

        #region Constructeurs

        public Typologie(string nom)
        {
            Typologie.CollClasse.Add(this);
            _nom = nom;
        }


        #endregion

        #region Getters/Setters
        public string Nom { get => _nom; set => _nom = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
