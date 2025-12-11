using System;
using System.Collections.Generic;

namespace RecentMemory.Models;

public partial class Lembrete
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public int? UsuarioId { get; set; }

    public string? Descricao { get; set; }

    public DateTime? DataLembrete { get; set; }

    public int? Prioridade { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ContatoLembrete> ContatoLembretes { get; set; } = new List<ContatoLembrete>();

    public virtual ICollection<LugaresLembrete> LugaresLembretes { get; set; } = new List<LugaresLembrete>();

    public virtual Usuario? Usuario { get; set; }
}
