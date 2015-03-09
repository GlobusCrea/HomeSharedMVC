using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    class Pays
    {
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

        public List<BienEchange> LstBiens
        {
            get { return BienEchange.getBiensByPays(this.idPays); }
        }

        #endregion

        #region Static

        public static Pays getChampsPays(Dictionary<string, object> item)
        {
            Pays pays = new Pays();
            pays.idPays = (int)item[""];
            pays.Libelle = item[""].ToString();
            return pays;
        }

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

        public static Pays getOnePays(int idPays)
        {
            List<Dictionary<string, object>> mesPays = GestionConnexion.Instance.getData("SELECT * FROM Pays WHERE idPays = " + idPays);
            Pays pays = getChampsPays(mesPays[0]);
            return pays;
        }

        public static Pays getPaysByBiens(int idP)
        {
            string strRequest = @"SELECT Pays.* FROM BienEchange INNER JOIN Pays ON Pays.idPays = BienEchange.Pays WHERE BienEchange.Pays = " + idP;
            List<Dictionary<string, object>> paysDatas = GestionConnexion.Instance.getData(strRequest);
            if (paysDatas.Count < 1) return null;

            Pays p = getChampsPays(paysDatas[0]);
            return p;
        }

        #endregion
    }
}
