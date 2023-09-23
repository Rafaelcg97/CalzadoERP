using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("detalleEstilo")]
public partial class DetalleEstilo
{
    [Key]
    [Column("idDetalleEstilo")]
    public int IdDetalleEstilo { get; set; }

    [Column("idEstilo")]
    public int? IdEstilo { get; set; }

    [Column("idSku")]
    public int IdSku { get; set; }

    [Column("cantidadSkuEstilo")]
    public double CantidadSkuEstilo { get; set; }

    [ForeignKey("IdDetalleEstilo")]
    [InverseProperty("DetalleEstilo")]
    public virtual Estilo IdDetalleEstiloNavigation { get; set; } = null!;

    [ForeignKey("IdSku")]
    [InverseProperty("DetalleEstilos")]
    public virtual Sku IdSkuNavigation { get; set; } = null!;
}
