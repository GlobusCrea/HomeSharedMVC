using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    class AvisMembreBien
    {
        #region Field

        private int _idAvis;
        private int _note;
        private string _message;
        private int _idMembre;
        private int _idBien;
        private DateTime _DateAvis;
        private bool _Approuve;

        #endregion

        #region Properties

        public int idAvis
        {
            get { return _idAvis; }
            set { _idAvis = value; }
        }

        public int note
        {
            get { return _note; }
            set { _note = value; }
        }

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        public int idMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }

        public int idBien
        {
            get { return _idBien; }
            set { _idBien = value; }
        }

        public DateTime DateAvis
        {
            get { return _DateAvis; }
            set { _DateAvis = value; }
        }

        public bool Approuve
        {
            get { return _Approuve; }
            set { _Approuve = value; }
        }

        #endregion

        #region Static

        /// <summary>
        /// Permet d'obtenir les champs de la table AvisMembreBien
        /// </summary>
        public static AvisMembreBien getChampsAvis(Dictionary<string, object> item)
        {
            AvisMembreBien avis = new AvisMembreBien();
            avis.idAvis = (int)item["idAvis"];
            avis.note = (int)item["note"];
            avis.message = item["message"].ToString();
            avis.idMembre = (int)item["idMembre"];
            avis.idBien = (int)item["idBien"];
            avis.DateAvis = DateTime.Parse(item["DateAvis"].ToString());
            avis.Approuve = (bool)item["Approuve"];
            return avis;
        }

        /// <summary>
        /// Permet d'obtenir les avis liés au bien
        /// </summary>
        /// <param name="idBien">identifiant du bien</param>
        /// <returns>La liste des avis du bien dont l'identifiant est passé en paramètre</returns>
        public static List<AvisMembreBien> getAvisByBiens(int idBien)
        {
            string strRequest = @"SELECT * FROM AvisMembreBien WHERE idBien = " + idBien;
            List<Dictionary<string, object>> avisDatas = GestionConnexion.Instance.getData(strRequest);
            List<AvisMembreBien> lstavisMbres = new List<AvisMembreBien>();
            if (avisDatas.Count < 1) return null;

            foreach(Dictionary<string, object> item in avisDatas)
            {
                AvisMembreBien avis = getChampsAvis(item);
                lstavisMbres.Add(avis);
            }
            return lstavisMbres;
            
        }

        #endregion
    }
}
