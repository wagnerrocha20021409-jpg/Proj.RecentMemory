using System;
using System.Collections.Generic;

namespace RecentMemory.Models;

public partial class ContatoLembrete
{
    public int Id { get; set; }

    public int? LembretesId { get; set; }

    public int? ContatosId { get; set; }

    public virtual Contato? Contatos { get; set; }

    public virtual Lembrete? Lembretes { get; set; }
}
