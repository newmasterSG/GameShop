using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingData.Deserializers
{
    public interface IDeserializer<T, G>
    {
        Task<T> Deserialize(G obj);
    }
}
