using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalzadoERP.Model;

[Table("zapatero")]
public partial class Zapatero
{
    [Key]
    [Column("idZapatero")]
    public int IdZapatero { get; set; }

    [Column("nombreZapatero")]
    [StringLength(50)]
    public string NombreZapatero { get; set; } = null!;

    [Column("direccionZapatero", TypeName = "text")]
    public string DireccionZapatero { get; set; } = null!;

    [Column("identificacionZapatero")]
    [StringLength(10)]
    public string IdentificacionZapatero { get; set; } = null!;

    [Column("estadoZapatero")]
    public bool EstadoZapatero { get; set; }

    [Column("fechaAsociacionZapatero", TypeName = "date")]
    public DateTime FechaAsociacionZapatero { get; set; }

    [Column("fechaTerminacionZapatero", TypeName = "date")]
    public DateTime? FechaTerminacionZapatero { get; set; }

    [InverseProperty("IdZapateroNavigation")]
    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}
