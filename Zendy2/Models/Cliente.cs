using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Zendy2.Models
{
    public class Cliente
    {
        [PrimaryKey]
        public int IdCliente { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string ApellidoPaterno { get; set; }

        [MaxLength(50)]
        public string ApellidoMaterno { get; set; }

        [MaxLength(9)]
        public int Num_Celular { get; set; }

        [MaxLength(50)]
        public string Direccion { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(12)]
        public string Contrasena { get; set; }

        public override string ToString()
        {
            return this.Nombre + " " + this.ApellidoPaterno + " " + this.ApellidoMaterno + " " + this.Num_Celular
                + "\n" + this.Direccion + " " + this.Username + " " + this.Contrasena;
        }

    }
}
