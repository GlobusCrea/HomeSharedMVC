using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class OptionsBien
    {
        #region Field

        private BienEchange _idBien;
        private Options _idOption;
        private string _Valeur;

        #endregion

        #region Properties

        public BienEchange idBien
        {
            get { return _idBien; }
            set { _idBien = value; }
        }

        public Options idOption
        {
            get { return _idOption; }
            set { _idOption = value; }
        }

        public string Valeur
        {
            get { return _Valeur; }
            set { _Valeur = value; }
        }

        #endregion

        #region Static

        public static OptionsBien getOptionsByBien(int idBien)
        {
            string strRequest = @"SELECT * FROM OptionBien WHERE idBien = " + idBien;
            List<Dictionary<string, object>> OptionDatas = GestionConnexion.Instance.getData(strRequest);
            OptionsBien op = new OptionsBien();
            foreach(Dictionary<string, object> item in OptionDatas)
            {
                op.idBien = BienEchange.getOneBien((int)item["idBien"]);
                op.idOption = Options.getOneOption((int)item["idOption"]);
                op.Valeur = item["Valeur"].ToString();
            }
            return op;
        }

        #endregion
    }
}
