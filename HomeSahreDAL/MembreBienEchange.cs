using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    class MembreBienEchange
    {
        #region Field

        private int _idMembre;
        private int _idBien;
        private DateTime _DateDebEchange;
        private DateTime _DateFinEchange;
        private bool _Assurance;
        private bool _Valide;

        #endregion

        #region Properties

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

        public DateTime DateDebEchange
        {
            get { return _DateDebEchange; }
            set { _DateDebEchange = value; }
        }

        public DateTime DateFinEchange
        {
            get { return _DateFinEchange; }
            set { _DateFinEchange = value; }
        }

        public bool Assurance
        {
            get { return _Assurance; }
            set { _Assurance = value; }
        }

        public bool Valide
        {
            get { return _Valide; }
            set { _Valide = value; }
        }

        #endregion

        #region Static


        #endregion
    }
}
