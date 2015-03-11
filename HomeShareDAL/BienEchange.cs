using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class BienEchange
    {
        /// <summary>
        /// Classe liée à la table BienEchange dans HomeShareDB
        /// </summary>
        
        #region Field

        private int _idBien;
        private string _titre;
        private string _DescCourte;
        private string _DescLong;
        private int _NbrePerson;
        private int _idPays;
        private string _Ville;
        private string _Rue;
        private string _Numero;
        private string _CP;
        private string _Photo;
        private bool _Assurance;
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

        public int idPays
        {
            get { return _idPays; }
            set { _idPays = value; }
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

        public bool Assurance
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

        #region navigation Properties

        /// <summary>
        /// Propriété permettant de récupérer le pays d'un bien
        /// </summary>
        public Pays pays
        {
            get { return Pays.getPaysByBiens(this.idPays); }
        }

        /// <summary>
        /// Propriété permettant de récupérer le membre lié au bien
        /// </summary>
        public Membre mbre
        {
            get { return Membre.getMbreByBiens(this.idMembre); }
        }

        /// <summary>
        /// Propriété permettant de récupérer les options liées au bien
        /// </summary>
        public OptionsBien OptionsParBiens
        {
            get { return OptionsBien.getOptionsByBien(this.idBien); }
        }


        public List<AvisMembreBien> avisMbre
        {
            get { return AvisMembreBien.getAvisByBiens(this.idBien); }
        }

        #endregion

        #region static

        public static BienEchange getChampsBiens(Dictionary<string,object> item)
        {
            BienEchange bien = new BienEchange();
            bien.idBien = (int)item["idBien"];
            bien.titre = item["titre"].ToString();
            bien.DescCourte = item["DescCourte"].ToString();
            bien.DescLong = item["DescLong"].ToString();
            bien.NbrePerson = (int)item["NombrePerson"];
            bien.idPays = (int)item["Pays"];
            bien.Ville = item["Ville"].ToString();
            bien.Rue = item["Rue"].ToString();
            bien.Numero = item["Numero"].ToString();
            bien.CP = item["CodePostal"].ToString();
            bien.Photo = item["Photo"].ToString();
            bien.Assurance = (bool)item["AssuranceObligatoire"];
            bien.isEnabled = (bool)item["isEnabled"];
            //bien.DisabledDate = DateTime.Parse(item["DisabledDate"].ToString());
            bien.Latitude = item["Latitude"].ToString();
            bien.Longitude = item["Longitude"].ToString();
            bien.idMembre = (int)item["idMembre"];
            bien.DateCreation = DateTime.Parse(item["DateCreation"].ToString());
            return bien;
        }

        /// <summary>
        /// Permet d'obtenir la lsite de tous les biens
        /// </summary>
        public static List<BienEchange> getAllBiens()
        {
            string strRequest = @"SELECT * FROM BienEchange";
            List<Dictionary<string, object>> biensDatas = GestionConnexion.Instance.getData(strRequest);
            List<BienEchange> lstBiens = new List<BienEchange>();
            if (biensDatas.Count < 1) return null;

            foreach (Dictionary<string, object> item in biensDatas)
            {
                BienEchange biens = getChampsBiens(item);
                lstBiens.Add(biens);
            }
            return lstBiens;
        }

        /// <summary>
        /// Permet d'obtenir un seul bien
        /// </summary>
        /// <param name="idBien">identifiant du bien</param>
        /// <returns>Le bien dont l'identifiant est passé en paramètre</returns>
        public static BienEchange getOneBien(int idBien)
        {
            string strRequest = @"SELECT * FROM BienEchange WHERE idBien = " + idBien;
            List<Dictionary<string, object>> biensDatas = GestionConnexion.Instance.getData(strRequest);
            BienEchange bien = getChampsBiens(biensDatas[0]);
            return bien;
        }

        /// <summary>
        /// Permet d'obtenir la liste des biens liée au pays
        /// </summary>
        /// <param name="idP">identifiant du pays</param>
        /// <returns>La liste des biens dont l'identifiant est passé en paramètre</returns>
        public static List<BienEchange> getBiensByPays(int idP)
        {
            string strRequest = @"SELECT * FROM BienEchange WHERE Pays = " + idP;
            List<Dictionary<string, object>> biensDatas = GestionConnexion.Instance.getData(strRequest);
            List<BienEchange> lstBiens = new List<BienEchange>();
            if (biensDatas.Count < 1) return null;

            foreach(Dictionary<string,object> item in biensDatas)
            {
                BienEchange biens = getChampsBiens(item);
                lstBiens.Add(biens);
            }
            return lstBiens;
        }

        /// <summary>
        /// Permet d'obtenir la liste des biens liée au membre
        /// </summary>
        /// <param name="idM">identifiant du membre</param>
        /// <returns>La liste des biens dont l'identifiant est passé en paramètre</returns>
        public static List<BienEchange> getBiensByMbre(int idM)
        {
            string strRequest = @"SELECT * FROM BienEchange WHERE idMembre = " + idM;
            List<Dictionary<string, object>> biensDatas = GestionConnexion.Instance.getData(strRequest);
            List<BienEchange> lstBiens = new List<BienEchange>();
            if (biensDatas.Count < 1) return null;

            foreach (Dictionary<string, object> item in biensDatas)
            {
                BienEchange biens = getChampsBiens(item);
                lstBiens.Add(biens);
            }
            return lstBiens;
        }

        /// <summary>
        /// Permet d'obtenir la liste des biens qui ont reçu les meilleurs avis
        /// </summary>
        public static List<BienEchange> getMeilleursAvis()
        {
            string strRequest = @"SELECT * FROM Vue_MeilleursAvis";
            List<Dictionary<string, object>> biensDatas = GestionConnexion.Instance.getData(strRequest);
            List<BienEchange> lstBiens = new List<BienEchange>();
            if (biensDatas.Count < 1) return null;

            foreach (Dictionary<string, object> item in biensDatas)
            {
                BienEchange biens = getChampsBiens(item);
                lstBiens.Add(biens);
            }
            return lstBiens;
        }

        /// <summary>
        /// Permet d'obtenir le dernier bien en échange
        /// </summary>
        public static List<BienEchange> getDernierBien()
        {
            string strRequest = @"SELECT * FROM Vue_DernierBien";
            List<Dictionary<string, object>> biensDatas = GestionConnexion.Instance.getData(strRequest);
            List<BienEchange> lstBiens = new List<BienEchange>();
            if (biensDatas.Count < 1) return null;

            BienEchange biens = getChampsBiens(biensDatas[0]);
            lstBiens.Add(biens);
            
            return lstBiens;
        }

        #endregion
    }
}
