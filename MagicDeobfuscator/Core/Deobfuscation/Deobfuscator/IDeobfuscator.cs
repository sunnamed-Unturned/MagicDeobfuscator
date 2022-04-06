using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator
{
    public interface IDeobfuscator
    {
        ModuleDefModel ModuleDefModel { get; }

        void Deobfuscate();
    }
}
