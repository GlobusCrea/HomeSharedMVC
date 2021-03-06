﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class Membre
    {
        /// <summary>
        /// Classe liée à la table Membre dans HomeShareDB
        /// </summary>
        
        #region Fields

        private int _idMembre;
        private string _Nom;
        private string _Prenom;
        private string _Email;
        private int _Pays;
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

        #endregion

        #region Navigation properties

        /// <summary>
        /// Propriété permettant de récupérer la liste des biens liée au membre
        /// </summary>
        public List<BienEchange> bien
        {
            get { return BienEchange.getBiensByMbre(this.idMembre); }
        }

        #endregion

        #region Static

        /// <summary>
        /// Permet d'obtenir un seul membre
        /// </summary>
        /// <param name="idMembre">identifiant du membre</param>
        /// <returns>Le membre dont l'identifiant est passé en paramètre</returns>
        public static Membre getOneMembre(int idMembre)
        {
            List<Dictionary<string, object>> unMbre = GestionConnexion.Instance.getData("SELECT * FROM Membre WHERE idMembre =" + idMembre);
            Membre mbre = new Membre();
            mbre.getChampsMbre(unMbre[0]);
            return mbre;
        }

        /// <summary>
        /// Permet d'obtenir le liste de tous les membres
        /// </summary>
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

        /// <summary>
        /// Permet d'obtenir le login et le password du membre
        /// </summary>
        /// <param name="login">login du membre</param>
        /// <param name="password">password du membre</param>
        /// <returns>Le membre dont le login et le password sont passés en paramètre</returns>
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

        /// <summary>
        /// Permet d'obtenir le membre lié au bien
        /// </summary>
        /// <param name="idM">identifiant du membre</param>
        /// <returns>Le pays du bien dont l'identifiant est passé en paramètre</returns>
        public static Membre getMbreByBiens(int idM)
        {
            string strRequest = @"SELECT Membre.* FROM BienEchange INNER JOIN Membre ON Membre.idMembre = BienEchange.idMembre WHERE BienEchange.idMembre = " + idM;
            List<Dictionary<string, object>> mbreDatas = GestionConnexion.Instance.getData(strRequest);
            if (mbreDatas.Count < 1) return null;

            Membre mbre = new Membre();
            mbre.getChampsMbre(mbreDatas[0]);
            return mbre;
        }

        #endregion

        #region Function

        /// <summary>
        /// Permet d'obtenir les champs de la table Membre
        /// </summary>
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

        /// <summary>
        /// Ajouter ou modifier un membre
        /// </summary>
        /// <returns></returns>
        public bool saveMembre()
        {
            string strRequest = "";

            if (this.idMembre == 0)
            {
                strRequest = "INSERT INTO Membre (Nom,Prenom,Email,Pays,Telephone,Login,Password) VALUES (@Nom, @Prenom, @Email, @Pays, @Telephone, @Login, @Password)";
            }
            else
            {
                strRequest = "UPDATE Membre SET Nom = @Nom,Prenom = @Prenom,Email = @Email,Pays = @pays,Telephone = @Telephone,Login = @Login,Password = @Password WHERE idAuteur = " + this.idMembre;
            }

            Dictionary<string, object> ValueToSave = new Dictionary<string, object>();
            ValueToSave["Nom"] = this.Nom;
            ValueToSave["Prenom"] = this.Prenom;
            ValueToSave["Email"] = this.Email;
            ValueToSave["Pays"] = this.Pays;
            ValueToSave["Telephone"] = this.Telephone;
            ValueToSave["Login"] = this.Login;
            ValueToSave["Password"] = this.Password;

            if (GestionConnexion.Instance.saveData(strRequest, GenerateKey.DB, ValueToSave))
            {
                if (this.idMembre == 0) GestionConnexion.Instance.getLastGenerateId();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Supprimer un auteur
        /// </summary>
        /// <returns></returns>
        public bool deleteMembre()
        {
            string strRequest = "DELETE FROM Membre WHERE idMembre = @idMembre";
            Dictionary<string, object> ValueToDelete = new Dictionary<string, object>();
            ValueToDelete["idMembre"] = this.idMembre;
            return GestionConnexion.Instance.saveData(strRequest, GenerateKey.APP, ValueToDelete);
        }

        #endregion
    }
}
