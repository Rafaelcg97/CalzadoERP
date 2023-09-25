using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    [DisplayName("SKU")]
    public string NombreSku { get; set; } = null!;

    [Column("colorSku")]
    [StringLength(50)]
    [DisplayName("Color")]
    public string ColorSku { get; set; } = null!;

    [Column("idProveedor")]
    public int IdProveedor { get; set; }

    [Column("precioUnitarioSku", TypeName = "money")]
    [DisplayName("Precio Unitario")]
    public decimal PrecioUnitarioSku { get; set; }

    [Column("unidadSku")]
    [StringLength(50)]
    [DisplayName("Unidades")]
    public string UnidadSku { get; set; } = null!;

    [Column("comentariosSku", TypeName = "text")]
    [DisplayName("Comentarios")]
    public string? ComentariosSku { get; set; }

    [InverseProperty("IdSkuNavigation")]
    public virtual ICollection<DetalleEstilo> DetalleEstilos { get; set; } = new List<DetalleEstilo>();

    [ForeignKey("IdProveedor")]
    [InverseProperty("Skus")]
    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
