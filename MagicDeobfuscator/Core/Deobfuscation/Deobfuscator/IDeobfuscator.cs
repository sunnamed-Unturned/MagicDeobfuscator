using MagicDeobfuscator.Core.Deobfuscation.Models.Module;
using System;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator
{
    public interface IDeobfuscator
    {
        ModuleDefModel ModuleDefModel { get; }

        void Deobfuscate();
    }
}
