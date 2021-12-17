using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExamenPM02.Models
{
    public class Data
{

        [PrimaryKey, AutoIncrement]
        public int Id_pago { get; set; }
        [MaxLength(255)]
        public string Descripcion { get; set; }
        [MaxLength(255)]
        public double Monto { get; set; }
        [MaxLength(255)]
        public DateTime Fecha { get; set; }
        public string Imagen { get; set; }


    }
}
