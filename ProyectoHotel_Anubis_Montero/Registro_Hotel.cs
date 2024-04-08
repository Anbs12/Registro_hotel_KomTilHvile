using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHotel_Anubis_Montero
{
    class Registro_Hotel
    {
        private String nombres;
        private String apellidos;
        private String rut;
        private String telefono;
        private String correo;
        private String direccion;
        private String tipoHabitacion;
        private int nHabitacion;
        private int diasHospedaje;
        private int valorHabitacion;

        public Registro_Hotel()
        {
        }

        public Registro_Hotel(string nombres, string apellidos, string rut, string telefono, string correo, string direccion, string tipoHabitacion, int nHabitacion, int diasHospedaje, int valorHabitacion)
        {
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Rut = rut;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Direccion = direccion;
            this.TipoHabitacion = tipoHabitacion;
            this.NHabitacion = nHabitacion;
            this.DiasHospedaje = diasHospedaje;
            this.valorHabitacion = valorHabitacion;
        }

        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Rut { get => rut; set => rut = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string TipoHabitacion { get => tipoHabitacion; set => tipoHabitacion = value; }
        public int NHabitacion { get => nHabitacion; set => nHabitacion = value; }
        public int DiasHospedaje { get => diasHospedaje; set => diasHospedaje = value; }
        public int ValorHabitacion { get => valorHabitacion; set => valorHabitacion = value;}



    }
}
