using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using System.Collections.Generic;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Container
{
    public interface IDeobfuscatorContainer
    {
        IEnumerable<DeobfuscatorBase> Deobfuscators { get; }



        void Add(DeobfuscatorBase deobfuscator);

        void Add(IEnumerable<DeobfuscatorBase> items);

        void Remove(DeobfuscatorBase item);

        void Remove(IEnumerable<DeobfuscatorBase> items);
    }
}
