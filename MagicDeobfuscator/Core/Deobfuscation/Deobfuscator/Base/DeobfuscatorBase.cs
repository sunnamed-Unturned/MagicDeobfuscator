using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base
{
    public abstract class DeobfuscatorBase : IDeobfuscator
    {
        public ModuleDefModel ModuleDefModel { get; }



        protected DeobfuscatorBase(ModuleDefModel moduleDefModel)
        {
            ModuleDefModel = moduleDefModel;
        }



        public abstract void Deobfuscate();
    }
}
