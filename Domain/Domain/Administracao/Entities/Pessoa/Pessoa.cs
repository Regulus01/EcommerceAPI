﻿using Domain.Administracao.Entities.Shared;
using Domain.Core.Entity;

namespace Domain.Administracao.Entities.Pessoa;

public class Pessoa : BaseEntity
{
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public string Telefone { get; private set; }
    public virtual Usuario Usuario { get; private set; }
}