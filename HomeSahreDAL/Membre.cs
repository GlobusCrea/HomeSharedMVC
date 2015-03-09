using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class Membre
    {
        #region Fields

        private int _idMembre;
        private string _Nom;
        private string _Prenom;
        private string _Email;
        private List<Pays> _Pays;
        private string _Telephone;
        private string _Login;
        private string _Password;

        #endregion

        #region Properties

        public int idMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        public string Prenom
        {
            get { return _Prenom; }
            set { _Prenom = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public List<Pays> Pays
        {
            get { return _Pays = _Pays ?? getPaysMbre(this.idMembre); }
        }

        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }

        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }


        #endregion

        #region Static



        #endregion

        #region Function



        #endregion

    }
}
