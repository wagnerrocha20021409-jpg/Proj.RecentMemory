using System;
using System.Collections.Generic;

namespace RecentMemory.Models;

public partial class Contato
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Telefone { get; set; }

    public int? UsuarioId { get; set; }

    public virtual ICollection<ContatoLembrete> ContatoLembretes { get; set; } = new List<ContatoLembrete>();

    public virtual Usuario? Usuario { get; set; }
}
