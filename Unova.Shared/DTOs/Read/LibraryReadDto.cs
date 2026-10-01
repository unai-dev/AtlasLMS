using System;
using System.Collections.Generic;
using System.Text;

using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

public class LibraryReadDto : BaseDto
{
    #region Properties 
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string NIF { get; set; } 
    #endregion
}
