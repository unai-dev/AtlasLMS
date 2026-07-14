using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AtlasLMS.API.Entities.Common;

namespace AtlasLMS.API.Entities;

public class Location : BaseEntity
{
    [Required]
    [StringLength(55)]
    public string Aisle { get; set; } = string.Empty;

    [Required]
    [StringLength(55)]
    public string Shelf { get; set; } = string.Empty;

    [Required]
    [StringLength(55)]
    public string Column { get; set; } = string.Empty;
}