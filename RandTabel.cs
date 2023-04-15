using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaXIS
{
    class RandTabel
    {
        public int Cod { get; set; }
        public string Tip { get; set; }
        public int Tarif_ora { get; set; }
        public int Tarif_zi { get; set; }
        public string CNP { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public DateTime Data_ora_start { get; set; }
        public DateTime Data_ora_final { get; set; }
    }
}