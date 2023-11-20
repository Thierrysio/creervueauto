using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creervueauto.Modeles
{
    internal class Table
    {
        #region Attributs

        public static List<Table> CollClasse = new List<Table>();
        private string _nom;
        private List<Attributs> _lesAttributs;

        #endregion

        #region Constructeurs

        public Table(string nom)
        {
            Table.CollClasse.Add(this);
            _nom = nom;
            _lesAttributs = new List<Attributs>();
        }
        #endregion

        #region Getters/Setters
        public string Nom { get => _nom; set => _nom = value; }
        internal List<Attributs> LesAttributs { get => _lesAttributs; set => _lesAttributs = value; }

        #endregion

        #region Methodes

        #endregion
    }
}

