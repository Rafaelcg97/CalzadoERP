using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("lote")]
public partial class Lote
{
    [Key]
    [Column("idLote")]
    public int IdLote { get; set; }

    [Column("idOrden")]
    public int IdOrden { get; set; }

    [Column("idEstilo")]
    public int IdEstilo { get; set; }

    [Column("idZapatero")]
    public int IdZapatero { get; set; }

    [Column("cantidadLote")]
    public int CantidadLote { get; set; }

    [Column("piezasTerminadasLote")]
    public int PiezasTerminadasLote { get; set; }

    [ForeignKey("IdEstilo")]
    [InverseProperty("Lotes")]
    public virtual Estilo IdEstiloNavigation { get; set; } = null!;

    [ForeignKey("IdOrden")]
    [InverseProperty("Lotes")]
    public virtual Orden IdOrdenNavigation { get; set; } = null!;

    [ForeignKey("IdZapatero")]
    [InverseProperty("Lotes")]
    public virtual Zapatero IdZapateroNavigation { get; set; } = null!;
}
