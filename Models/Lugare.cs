using System;
using System.Collections.Generic;

namespace RecentMemory.Models;

public partial class Lugare
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<LugaresLembrete> LugaresLembretes { get; set; } = new List<LugaresLembrete>();

    public virtual ICollection<UsuarioLugare> UsuarioLugares { get; set; } = new List<UsuarioLugare>();
}
