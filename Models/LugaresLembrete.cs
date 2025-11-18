using System;
using System.Collections.Generic;

namespace RecentMemory.Models;

public partial class LugaresLembrete
{
    public int Id { get; set; }

    public int? LugaresId { get; set; }

    public int? LembretesId { get; set; }

    public virtual Lembrete? Lembretes { get; set; }

    public virtual Lugare? Lugares { get; set; }
}
