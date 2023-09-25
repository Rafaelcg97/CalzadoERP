using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("cliente")]
public partial class Cliente
{
    [Key]
    [Column("idCliente")]
    [DisplayName("Codigo")]
    public int IdCliente { get; set; }

    [Column("nombreCliente")]
    [StringLength(50)]
    [DisplayName("Nombre del Cliente")]
    public string NombreCliente { get; set; } = null!;

    [Column("direccionCliente", TypeName = "text")]
    [DisplayName("Direccion del Cliente")]
    public string DireccionCliente { get; set; } = null!;

    [Column("telefonoCliente1")]
    [StringLength(9)]
    [DisplayName("Teléfono")]
    public string TelefonoCliente1 { get; set; } = null!;

    [Column("telefonoCliente2")]
    [StringLength(9)]
    [DisplayName("Celular")]
    public string? TelefonoCliente2 { get; set; }

    [Column("fechaCreacionCliente", TypeName = "date")]
    [DisplayName("Ingresado día")]
    public DateTime FechaCreacionCliente { get; set; }

    [Column("comentariosCliente", TypeName = "text")]
    [DisplayName("Comentarios")]
    public string? ComentariosCliente { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
