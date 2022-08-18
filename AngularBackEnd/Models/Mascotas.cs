using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularBackEnd.Models
{
    public class Mascotas
    {
        public int idMascota { get; set; }
        public string nombre { get; set; }

        public int edad { get; set; }

        public string  descripcion { get; set; }

        public Mascotas()
        {

        }

        public Mascotas(int id, string Nombre, int Edad,string Desc)
        {
            idMascota = id;
            nombre = Nombre;
            edad = Edad;
            descripcion = Desc;


        }

        public Mascotas( string Nombre, int Edad, string Desc)
        {

            nombre = Nombre;
            edad = Edad;
            descripcion = Desc;


        }



    }
}