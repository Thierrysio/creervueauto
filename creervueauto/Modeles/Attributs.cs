using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creervueauto.Modeles
{
    internal class Attributs
    {
         #region Attributs

        public static List<Attributs> CollClasse = new List<Attributs>();
        private string _nom;
        private bool _clePrimaire;
        private Typologie _laTypologie;
        #endregion

        #region Constructeurs

        public Attributs(string nom, bool clePrimaire, Typologie laTypologie)
        {
            Attributs.CollClasse.Add(this);
            _nom = nom;
            _clePrimaire = clePrimaire;
            _laTypologie = laTypologie;
        }

        #endregion

        #region Getters/Setters
        public string Nom { get => _nom; set => _nom = value; }
        public bool ClePrimaire { get => _clePrimaire; set => _clePrimaire = value; }
        internal Typologie LaTypologie { get => _laTypologie; set => _laTypologie = value; }
        #endregion

        #region Methodes

        #endregion
    }
}
