using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MenaDExamen3.Models
{
    [Table("Dispositivo")]
    class Dispositivo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(100)]
        public string NombreDispositivo { get; set; }
        [MaxLength(100)]
        public string MarcaDispositivo { get; set; }
        public bool GarantiaActiva { get; set; }
        public int VidaUtilMeses { get; set; }

    }
}
