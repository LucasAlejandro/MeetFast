using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeetFastGit.Models;

namespace MeetFastGit.Models
{
    public class UsuarioModelo
    {
        private long ID;
        private string email;
        private string contraseña;
        private string nombre;
        private DateTime fechaDeNacimiento;
        private string fotoUI;
        private string telefono;
        private string localidad;
        private List<InteresModelo> listaDeIntereses;
        private List<HistoriaModelo> historias;
        private List<UsuarioModelo> amigos;

        public UsuarioModelo(string email, string contraseña, string nombre, DateTime fecha, string foto, string telefono, string localidad)
        {
            this.email = email;
            this.contraseña = contraseña;
            this.nombre = nombre;
            this.fechaDeNacimiento = fecha;
            this.fotoUI = foto;
            this.telefono = telefono;
            this.localidad = localidad;
        }

        public UsuarioModelo() { }

        public long getID()
        {
            return this.ID;
        }

        public string getContraseña()
        {
            return this.contraseña;
        }

        public void setID(long ID)
        {
            this.ID = ID;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public DateTime getFechaDeNacimiento()
        {
            return this.fechaDeNacimiento;
        }

        public string getFotoUI()
        {
            return this.fotoUI;
        }

        public string getTelefono()
        {
            return this.telefono;
        }

        public string getLocalidad()
        {
            return this.localidad;
        }

        public List<InteresModelo> getListaDeIntereses()
        {
            return this.listaDeIntereses;
        }

        public List<HistoriaModelo> getHistorias()
        {
            return this.historias;
        }

        public List<UsuarioModelo> getAmigos()
        {
            return this.amigos;
        }

        public void setEmail(string emailNuevo)
        {
            this.email = emailNuevo;
        }

        public void setNombre(string nombreNuevo)
        {
            this.nombre = nombreNuevo;
        }

        public void setContraseña(string contraseñaNueva)
        {
            this.contraseña = contraseñaNueva;
        }

        public void setFotoUI(string fotoUINuevo)
        {
            this.fotoUI = fotoUINuevo;
        }

        public void setTelefono(string telefonoNuevo)
        {
            this.telefono = telefonoNuevo;
        }

        public void setLocalidad(string localidadNueva)
        {
            this.localidad = localidadNueva;
        }

        public void setListaDeIntereses(List<InteresModelo> listaNueva)
        {
            this.listaDeIntereses = listaNueva;
        }

        public void añadirNuevoInteres(InteresModelo interes)
        {
            this.listaDeIntereses.Add(interes);
        }

        public void setHistoias(List<HistoriaModelo> historias)
        {
            this.historias = historias;
        }

        public void añadirHistoria(HistoriaModelo historia)
        {
            this.historias.Add(historia);
        }

        public void setAmigos(List<UsuarioModelo> amigos)
        {
            this.amigos = amigos;
        }
        
        public void añadirAmigos(UsuarioModelo amigo)
        {
            this.amigos.Add(amigo);
        }

    }
}