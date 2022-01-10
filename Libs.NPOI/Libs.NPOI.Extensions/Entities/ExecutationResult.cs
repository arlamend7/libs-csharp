﻿using System.Collections.Generic;
using System.Linq;

namespace Autoglass.Precificacao.DataTransfer.Utils
{
    public class ExecutationResult<TSucesso,TErro>
    {
        public bool Sucesso => !Erros.Any() && Sucessos.Any();
        public List<TSucesso> Sucessos { get; set; }
        public List<ExecutationException<TErro>> Erros { get; set; }
        public ExecutationResult()
        {
            Sucessos = new List<TSucesso>();
            Erros = new List<ExecutationException<TErro>>();
        }
    }
}
