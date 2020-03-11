using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converter
{
    public interface IParse<O, D>
    {
        D Parse(O origin);
        IList<D> ParseList(IList<O> origin);
    }
}
