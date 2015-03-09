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
        private int _Pays;
        private string _Telephone;
        private string _Login;
        private string _Password;
        private List<BienEchange> _lstBiens;
        //private List<Pays> _lstPays;

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

        public int Pays
        {
            get { return  _Pays; }
            set { _Pays = value; }
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

        public List<BienEchange> lstBiens
        {
            get { return _lstBiens = _lstBiens ?? getLstBiens(this.idMembre); }
        }

        //public List<Pays> lstPays
        //{
        //    get { return _lstPays = _lstPays ?? getPaysMbre(this.idMembre); }
        //}

        #endregion

        #region Static

        public static Membre getOneMembre(int idMembre)
        {
            List<Dictionary<string, object>> unMbre = GestionConnexion.Instance.getData("SELECT * FROM Membre WHERE idAuteur =" + idMembre);
            Membre mbre = new Membre();
            mbre.getChampsMbre(unMbre[0]);
            return mbre;
        }

        public static List<Membre> getAllMembres()
        {
            List<Dictionary<string, object>> desMembres = GestionConnexion.Instance.getData("SELECT * FROM Membre");
            List<Membre> lstMbre = new List<Membre>();
            foreach (Dictionary<string, object> item in desMembres)
            {
                Membre mbre = new Membre();
                mbre.getChampsMbre(item);
                lstMbre.Add(mbre);
            }
            return lstMbre;
        }

        public static Membre getLoginPass(string login, string password)
        {
            List<Dictionary<string, object>> lp = GestionConnexion.Instance.getData("SELECT * from Membre WHERE Login='" + login + "' and Password='" + password + "'");
            if (lp.Count > 0)
            {
                Membre mbre = new Membre();
                mbre.getChampsMbre(lp[0]);
                return mbre;
            }
            return null;
        }

        //public static BienEchange getChampsBiens(Dictionary<string, object> item)
        //{
        //    BienEchange bien = new BienEchange();
        //    bien. = (int)item["idBien"];
        //    bien.idAuteur = item["titre"].ToString();
        //    bien.NewsPicture = item["NewsPicture"].ToString();
        //    bien.NewsDate = (DateTime)item["NewsDate"];
        //    bien.NewsTitre = item["NewsTitre"].ToString();
        //    bien.NewsTxt = item["NewsTxt"].ToString();
        //    bien.NewsResume = item["NewsResume"].ToString();
        //    return bien;
        //}

        #endregion

        #region Function

        public void getChampsMbre(Dictionary<string, object> item)
        {
            this.idMembre = (int)item["idMembre"];
            this.Nom = item["Nom"].ToString();
            this.Prenom = item["Prenom"].ToString();
            this.Email = item["Email"].ToString();
            this.Pays = (int)item["Pays"];
            this.Telephone = item["Telephone"].ToString();
            this.Login = item["Login"].ToString();
            this.Password = item["Password"].ToString();
        }

        //public List<BienEchange> getLstBiens()
        //{
        //    List<Dictionary<string, object>> desBiens = GestionConnexion.Instance.getData("SELECT * FROM BienEchange WHERE idMembre = " + this.idMembre);
        //    List<BienEchange> lstBiens = new List<BienEchange>();
        //    foreach (Dictionary<string, object> item in desBiens)
        //    {
        //        BienEchange bien = new BienEchange();
        //        bien
        //    }
        //    return lstBiens;
        //}

        #endregion

    }
}
