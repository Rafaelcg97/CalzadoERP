using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("orden")]
public partial class Orden
{
    [Key]
    [Column("idOrden")]
    [DisplayName("Codigo")]
    public int IdOrden { get; set; }

    [Column("idCliente")]
    public int IdCliente { get; set; }

    [Column("fechaCreacionOrden", TypeName = "date")]
    [DisplayName("Orden creado el día")]
    public DateTime FechaCreacionOrden { get; set; }

    [Column("fechaEntregaOrden", TypeName = "date")]
    [DisplayName("Fecha de Entrega")]
    public DateTime? FechaEntregaOrden { get; set; }

    [Column("statusOrden")]
    [StringLength(10)]
    [DisplayName("Estado")]
    public string StatusOrden { get; set; } = null!;

    [Column("fechaCierreOrden", TypeName = "date")]
    [DisplayName("Vencimiento de Orden")]
    public DateTime? FechaCierreOrden { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("Ordens")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [InverseProperty("IdOrdenNavigation")]
    [DisplayName("lotes")]
    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}
