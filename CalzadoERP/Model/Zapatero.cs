using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    [DisplayName("Zapatero")]
    public string NombreZapatero { get; set; } = null!;

    [Column("direccionZapatero", TypeName = "text")]
    [DisplayName("Dirección")]
    public string DireccionZapatero { get; set; } = null!;

    [Column("identificacionZapatero")]
    [StringLength(10)]
    [DisplayName("Codigo")]
    public string IdentificacionZapatero { get; set; } = null!;

    [Column("estadoZapatero")]
    [DisplayName("Estado")]
    public bool EstadoZapatero { get; set; }

    [Column("fechaAsociacionZapatero", TypeName = "date")]
    [DisplayName("Inicio de Contratado")]
    public DateTime FechaAsociacionZapatero { get; set; }

    [Column("fechaTerminacionZapatero", TypeName = "date")]
    [DisplayName("Fin de Contrato")]
    public DateTime? FechaTerminacionZapatero { get; set; }

    [InverseProperty("IdZapateroNavigation")]
    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}
