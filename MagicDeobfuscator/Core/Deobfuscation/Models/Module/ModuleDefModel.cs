using dnlib.DotNet;

namespace MagicDeobfuscator.Core.Deobfuscation.Models.Module
{
    public struct ModuleDefModel
    {
        public readonly ModuleDef Result;



        public ModuleDefModel(ModuleDef result)
        {
            Result = result;
        }
    }
}
