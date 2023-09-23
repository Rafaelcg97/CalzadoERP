using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("estilo")]
public partial class Estilo
{
    [Key]
    [Column("idEstilo")]
    public int IdEstilo { get; set; }

    [Column("nombreEstilo")]
    [StringLength(50)]
    public string NombreEstilo { get; set; } = null!;

    [Column("colorEstilo")]
    [StringLength(50)]
    public string ColorEstilo { get; set; } = null!;

    [Column("generoEstilo")]
    [StringLength(9)]
    public string GeneroEstilo { get; set; } = null!;

    [Column("precioEstilo", TypeName = "money")]
    public decimal PrecioEstilo { get; set; }

    [Column("comentariosEstilo", TypeName = "text")]
    public string? ComentariosEstilo { get; set; }

    [InverseProperty("IdDetalleEstiloNavigation")]
    public virtual DetalleEstilo? DetalleEstilo { get; set; }

    [InverseProperty("IdEstiloNavigation")]
    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}
