using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using System.Collections.Generic;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Container
{
    public sealed class DeobfuscatorsContainer : IDeobfuscatorContainer
    {
        private IList<DeobfuscatorBase> deobfuscators;



        public DeobfuscatorsContainer(IEnumerable<DeobfuscatorBase> items) : this()
        {
            Add(items);
        }

        public DeobfuscatorsContainer()
        {
            deobfuscators = new List<DeobfuscatorBase>();
        }



        public IEnumerable<DeobfuscatorBase> Deobfuscators => deobfuscators;



        public void Add(DeobfuscatorBase deobfuscator)
        {
            deobfuscators.Add(deobfuscator);
        }

        public void Add(IEnumerable<DeobfuscatorBase> items)
        {
            foreach (DeobfuscatorBase deobfuscator in items)
                Add(deobfuscator);
        }

        public void Remove(DeobfuscatorBase item)
        {
            if (deobfuscators.Contains(item))
                deobfuscators.Remove(item);
        }

        public void Remove(IEnumerable<DeobfuscatorBase> items)
        {
            foreach (DeobfuscatorBase item in items)
            {
                deobfuscators.Remove(item);
            }
        }
    }
}
