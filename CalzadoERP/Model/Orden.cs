using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("orden")]
public partial class Orden
{
    [Key]
    [Column("idOrden")]
    public int IdOrden { get; set; }

    [Column("idCliente")]
    public int IdCliente { get; set; }

    [Column("fechaCreacionOrden", TypeName = "date")]
    public DateTime FechaCreacionOrden { get; set; }

    [Column("fechaEntregaOrden", TypeName = "date")]
    public DateTime? FechaEntregaOrden { get; set; }

    [Column("statusOrden")]
    [StringLength(10)]
    public string StatusOrden { get; set; } = null!;

    [Column("fechaCierreOrden", TypeName = "date")]
    public DateTime? FechaCierreOrden { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("Ordens")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [InverseProperty("IdOrdenNavigation")]
    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}
