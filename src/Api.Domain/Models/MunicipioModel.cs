using System;

namespace Api.Domain.Models
{
    public class MunicipioModel : BaseModel
    {
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private int _codIBGE;
        public int CodIBGE
        {
            get { return _codIBGE; }
            set { _codIBGE = value; }
        }
        private Guid _ufID;
        public Guid UFID
        {
            get { return _ufID; }
            set { _ufID = value; }
        }
    }
}
