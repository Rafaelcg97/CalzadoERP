using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("cliente")]
public partial class Cliente
{
    [Key]
    [Column("idCliente")]
    public int IdCliente { get; set; }

    [Column("nombreCliente")]
    [StringLength(50)]
    public string NombreCliente { get; set; } = null!;

    [Column("direccionCliente", TypeName = "text")]
    public string DireccionCliente { get; set; } = null!;

    [Column("telefonoCliente1")]
    [StringLength(9)]
    public string TelefonoCliente1 { get; set; } = null!;

    [Column("telefonoCliente2")]
    [StringLength(9)]
    public string? TelefonoCliente2 { get; set; }

    [Column("fechaCreacionCliente", TypeName = "date")]
    public DateTime FechaCreacionCliente { get; set; }

    [Column("comentariosCliente", TypeName = "text")]
    public string? ComentariosCliente { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
