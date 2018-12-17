//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testlogin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Evento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evento()
        {
            this.Usuario1 = new HashSet<Usuario>();
        }
    
        public int Id { get; set; }
        public int TipoEvento { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> Fecha_Evento { get; set; }
        public string Visibilidad { get; set; }
        public int Creador { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual TipoEvento TipoEvento1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario1 { get; set; }
    }
}