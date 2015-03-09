using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    class BienEchange
    {
        #region Field

        private int _idBien;
        private string _titre;
        private string _DescCourte;
        private string _DescLong;
        private int _NbrePerson;
        private int _Pays;
        private string _Ville;
        private string _Rue;
        private string _Numero;
        private string _CP;
        private string _Photo;
        private string _Assurance;
        private bool _isEnabled;
        private DateTime _DisabledDate;
        private string _Latitude;
        private string _Longitude;
        private int _idMembre;
        private DateTime _DateCreation;

        #endregion

        #region Properties

        public int idBien
        {
            get { return _idBien; }
            set { _idBien = value; }
        }

        public string titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        public string DescCourte
        {
            get { return _DescCourte; }
            set { _DescCourte = value; }
        }

        public string DescLong
        {
            get { return _DescLong; }
            set { _DescLong = value; }
        }

        public int NbrePerson
        {
            get { return _NbrePerson; }
            set { _NbrePerson = value; }
        }

        public int Pays
        {
            get { return _Pays; }
            set { _Pays = value; }
        }

        public string Ville
        {
            get { return _Ville; }
            set { _Ville = value; }
        }

        public string Rue
        {
            get { return _Rue; }
            set { _Rue = value; }
        }

        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        public string CP
        {
            get { return _CP; }
            set { _CP = value; }
        }

        public string Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }

        public string Assurance
        {
            get { return _Assurance; }
            set { _Assurance = value; }
        }

        public bool isEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }

        public DateTime DisabledDate
        {
            get { return _DisabledDate; }
            set { _DisabledDate = value; }
        }

        public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        public int idMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }

        public DateTime DateCreation
        {
            get { return _DateCreation; }
            set { _DateCreation = value; }
        }

        #endregion
    }
}
