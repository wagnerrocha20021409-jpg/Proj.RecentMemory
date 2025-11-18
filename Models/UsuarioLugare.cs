using System;
using System.Collections.Generic;

namespace RecentMemory.Models;

public partial class UsuarioLugare
{
    public int Id { get; set; }

    public int? LugaresId { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Lugare? Lugares { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
