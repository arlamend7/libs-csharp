using System;

namespace Libs.NPOI.Extensions.Entities
{
    public class ExecutationException : Exception
    {
        public int? Linha { get; set; }
        public ExecutationException(string mensagem) : base(mensagem)
        {
        }
        public ExecutationException(int linha, string mensagem) : base($"Line {linha} : {mensagem}")
        {
            Linha = linha;
        }
        public ExecutationException(int linha, Exception ex) : base($"Line {linha} : {ex.Message}", ex)
        {
            Linha = linha;
        }
        public ExecutationException(int linha, string mensagem, Exception ex) : base($"Line {linha} : {mensagem}", ex)
        {
            Linha = linha;
        }
    }
    public class ExecutationException<T> : ExecutationException
    {
        public T Entidade { get; set; }
        public ExecutationException(int linha, string mensagem) : base(linha, mensagem) { }
        public ExecutationException(int linha, Exception ex) : base(linha, ex) { }
        public ExecutationException(T entidade, string mensagem) :   base(mensagem)
        {
            Entidade = entidade;
        }
        public ExecutationException(T entidade, int linha, Exception ex) : base(linha,ex)
        {
            Entidade = entidade;
        }
        public ExecutationException(T entidade, int linha,string messagem, Exception ex) : base(linha,messagem, ex)
        {
            Linha = linha;
            Entidade = entidade;
        }
    }
}
