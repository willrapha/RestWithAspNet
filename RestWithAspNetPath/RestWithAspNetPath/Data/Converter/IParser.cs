using System.Collections.Generic;

namespace RestWithAspNetPath.Data.Converter
{
    // Interface para converção de um objeto Origem 'O' para um Destino 'D'
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}