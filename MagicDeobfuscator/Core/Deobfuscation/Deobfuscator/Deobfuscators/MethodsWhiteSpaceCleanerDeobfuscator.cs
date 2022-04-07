using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public class MethodsWhiteSpaceCleanerDeobfuscator : DeobfuscatorBase
    {
        public MethodsWhiteSpaceCleanerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            foreach (TypeDef type in base.ModuleDefModel.Result.GetTypes())
            {
                foreach (MethodDef method in type.Methods)
                {
                    method.Name = method.Name.Trim();
                }
            }
        }
    }
}
