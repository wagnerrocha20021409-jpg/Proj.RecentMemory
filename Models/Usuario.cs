using System;
using System.Collections.Generic;

namespace RecentMemory.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();

    public virtual ICollection<Lembrete> Lembretes { get; set; } = new List<Lembrete>();

    public virtual ICollection<UsuarioLugare> UsuarioLugares { get; set; } = new List<UsuarioLugare>();
}
