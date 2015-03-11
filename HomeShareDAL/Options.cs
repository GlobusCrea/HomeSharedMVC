using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class Options
    {
        /// <summary>
        /// Classe liée à la table Options dans HomeShareDB
        /// </summary>

        #region Field

        private int _idOption;
        private string _Libelle;

        #endregion

        #region Properties

        public int idOption
        {
            get { return _idOption; }
            set { _idOption = value; }
        }

        public string Libelle
        {
            get { return _Libelle; }
            set { _Libelle = value; }
        }

        #endregion

        #region Static

        /// <summary>
        /// Permet d'obtenir les champs de la table Options
        /// </summary>
        public static Options getChampsOptions(Dictionary<string, object> item)
        {
            Options option = new Options();
            option.idOption = (int)item["idOption"];
            option.Libelle = item["Libelle"].ToString();
            return option;
        }

        /// <summary>
        /// Permet d'obtenir une seule option
        /// </summary>
        /// <param name="idOption">identifiant de l'option</param>
        /// <returns>L'option dont l'identifiant est passé en paramètre</returns>
        public static Options getOneOption(int idOption)
        {
            string strRequest = @"SELECT * FROM Options WHERE idOption = " + idOption;
            List<Dictionary<string, object>> OptionDatas = GestionConnexion.Instance.getData(strRequest);
            Options option = getChampsOptions(OptionDatas[0]);
            return option;
        }

        #endregion
    }
}
