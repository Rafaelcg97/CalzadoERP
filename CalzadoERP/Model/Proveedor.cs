using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("proveedor")]
public partial class Proveedor
{
    [Key]
    [Column("idProveedor")]
    public int IdProveedor { get; set; }

    [Column("nombreProveedor")]
    [StringLength(50)]
    public string NombreProveedor { get; set; } = null!;

    [Column("direccionProveedor")]
    [StringLength(200)]
    public string DireccionProveedor { get; set; } = null!;

    [Column("telefonoProveedor1")]
    [StringLength(9)]
    public string TelefonoProveedor1 { get; set; } = null!;

    [Column("telefonoProveedor2")]
    [StringLength(9)]
    public string? TelefonoProveedor2 { get; set; }

    [InverseProperty("IdProveedorNavigation")]
    public virtual ICollection<Sku> Skus { get; set; } = new List<Sku>();
}
