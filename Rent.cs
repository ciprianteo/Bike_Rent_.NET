using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaXIS
{
    public class Tarif
    {
        public int ora { get; set; }
        public int zi { get; set; }
    }
    public class Bike
    {
        public int cod { get; set; }
        public string tip { get; set; }
        public Tarif tarif { get; set; }
    }

    public class Persoana
    {
        public string CNP { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string telefon { get; set; }
    }
    public class Rent
    {

        public Bike bike { get; set; }
        public Persoana persoana { get; set; }
        
        public DateTime data_ora_start { get; set; }
        public DateTime data_ora_final { get; set; }
    }

    public class Bike_Rent
    {
        public List<Rent> Rents { get; set; }
    }
}
