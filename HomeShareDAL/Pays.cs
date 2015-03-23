using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class Pays
    {
        /// <summary>
        /// Classe liée à la table Pays dans HomeShareDB
        /// </summary>

        #region Fields

        private int _idPays;
        private string _Libelle;

        #endregion

        #region Properties

        public int idPays
        {
            get { return _idPays; }
            set { _idPays = value; }
        }

        public string Libelle
        {
            get { return _Libelle; }
            set { _Libelle = value; }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Propriété permettant de récupérer la liste des biens liée au pays
        /// </summary>
        public List<BienEchange> LstBiens
        {
            get { return BienEchange.getBiensByidPays(this.idPays); }
        }

        #endregion

        #region Static

        /// <summary>
        /// Permet d'obtenir les champs de la table Pays
        /// </summary>
        public static Pays getChampsPays(Dictionary<string, object> item)
        {
            Pays pays = new Pays();
            pays.idPays = (int)item["idPays"];
            pays.Libelle = item["Libelle"].ToString();
            return pays;
        }

        /// <summary>
        /// Permet d'obtenir le liste de tous les pays
        /// </summary>
        public static List<Pays> getAllPays()
        {
            List<Dictionary<string, object>> mesPays = GestionConnexion.Instance.getData("SELECT * FROM Pays");
            List<Pays> lstPays = new List<Pays>();
            foreach (Dictionary<string, object> item in mesPays)
            {
                Pays pays = getChampsPays(item);
                lstPays.Add(pays);
            }
            return lstPays;
        }

        /// <summary>
        /// Permet d'obtenir un seul pays
        /// </summary>
        /// <param name="idPays">identifiant du pays</param>
        /// <returns>Le pays dont l'identifiant est passé en paramètre</returns>
        public static Pays getOnePays(int idPays)
        {
            List<Dictionary<string, object>> mesPays = GestionConnexion.Instance.getData("SELECT * FROM Pays WHERE idPays = " + idPays);
            Pays pays = getChampsPays(mesPays[0]);
            return pays;
        }

        /// <summary>
        /// Permet d'obtenir le pays lié au bien
        /// </summary>
        /// <param name="idP">identifiant du pays</param>
        /// <returns>Le pays du bien dont l'identifiant est passé en paramètre</returns>
        public static Pays getPaysByBiens(int idP)
        {
            string strRequest = @"SELECT Pays.* FROM BienEchange INNER JOIN Pays ON Pays.idPays = BienEchange.Pays WHERE BienEchange.Pays = " + idP;
            List<Dictionary<string, object>> paysDatas = GestionConnexion.Instance.getData(strRequest);
            if (paysDatas.Count < 1) return null;

            Pays pays = getChampsPays(paysDatas[0]);
            return pays;
        }

        #endregion
    }
}
