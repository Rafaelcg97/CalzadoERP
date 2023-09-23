using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("sku")]
public partial class Sku
{
    [Key]
    [Column("idSku")]
    public int IdSku { get; set; }

    [Column("nombreSku")]
    [StringLength(50)]
    public string NombreSku { get; set; } = null!;

    [Column("colorSku")]
    [StringLength(50)]
    public string ColorSku { get; set; } = null!;

    [Column("idProveedor")]
    public int IdProveedor { get; set; }

    [Column("precioUnitarioSku", TypeName = "money")]
    public decimal PrecioUnitarioSku { get; set; }

    [Column("unidadSku")]
    [StringLength(50)]
    public string UnidadSku { get; set; } = null!;

    [Column("comentariosSku", TypeName = "text")]
    public string? ComentariosSku { get; set; }

    [InverseProperty("IdSkuNavigation")]
    public virtual ICollection<DetalleEstilo> DetalleEstilos { get; set; } = new List<DetalleEstilo>();

    [ForeignKey("IdProveedor")]
    [InverseProperty("Skus")]
    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
