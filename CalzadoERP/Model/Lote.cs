using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("lote")]
public partial class Lote
{
    [Key]
    [Column("idLote")]
    [DisplayName("No. de Lote")]
    public int IdLote { get; set; }

    [Column("idOrden")]
    [DisplayName("No. de Orden")]
    public int IdOrden { get; set; }

    [Column("idEstilo")]
    [DisplayName("No. de Estilo")]
    public int IdEstilo { get; set; }

    [Column("idZapatero")]
    [DisplayName("No. de Zapatero")]
    public int IdZapatero { get; set; }

    [Column("cantidadLote")]
    [DisplayName("Cantidad de Lotes")]
    public int CantidadLote { get; set; }

    [Column("piezasTerminadasLote")]
    [DisplayName("Lotes terminados")]
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
