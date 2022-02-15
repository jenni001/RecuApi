using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Models
{
    public class TicketDeCompra
    {
        //Clave Principal NO AUTONUMERICA
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TicketId { get; set; }
        public string Cliente { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
         public List<Pedido> Pedido { get; } = new List<Pedido>();

        // A implementar
        // public override string ToString() => "A Implementar";Pre
        public override string ToString() => $"#{TicketId} {Cliente}";
    }
    public class Prendas
    {
        //Clave Principal NO AUTONUMERICA
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrendaId { get; set; }
        public string Prenda { get; set; }
        public int Precio { get; set; }


        //Escribe las propiedades de navegación a otras Entidades

        [System.Text.Json.Serialization.JsonIgnore]

        public List<Pedido> Pedido { get; } = new List<Pedido>();

        // A implementar
        //public override string ToString() => $"A implementar";
        public override string ToString() => $"{PrendaId} Prenda={Prenda} Precio={Precio}€";
    }
    public class Pedido
    {        
        //Clave Principal NO AUTONUMERICA
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PedidoId { get; set; }
        
        //Escribe las propiedades de relación 1:N 
        
        public int TicketId { get; set; }
        public int PrendaId { get; set; }

        //
        public int Cantidad { get; set; }

        //Escribe las propiedades de navegación a otras Entidades
        public Prendas Prendas { get; set; }
        public TicketDeCompra TiketDeCompra { get; set; }

        // A implementar
        //public override string ToString() => $"A implementar";
       public override string ToString() => $"{TicketId}x{PrendaId}";
    }

}