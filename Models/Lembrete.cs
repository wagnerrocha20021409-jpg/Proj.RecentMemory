using System;
using System.Collections.Generic;

namespace RecentMemory.Models;

public partial class Lembrete
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Lembrete1 { get; set; }

    public int? UsuarioId { get; set; }

    public virtual ICollection<ContatosLembrete> ContatosLembretes { get; set; } = new List<ContatosLembrete>();

    public virtual ICollection<LugaresLembrete> LugaresLembretes { get; set; } = new List<LugaresLembrete>();

    public virtual Usuario? Usuario { get; set; }
}
