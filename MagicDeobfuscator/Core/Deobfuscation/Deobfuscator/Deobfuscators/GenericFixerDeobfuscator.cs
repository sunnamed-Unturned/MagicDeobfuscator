using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public sealed class GenericFixerDeobfuscator : DeobfuscatorBase
    {
        public GenericFixerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            foreach (TypeDef typeDef in base.ModuleDefModel.Result.GetTypes())
            {
                foreach (GenericParam generic in typeDef.GenericParameters)
                {
                    generic.Name = generic.Name.Replace('-', 'T');
                }

                foreach (MethodDef method in typeDef.Methods)
                {
                    foreach (GenericParam generic in method.GenericParameters)
                    {
                        generic.Name = generic.Name.Replace('-', 'T');
                    }
                }
            }
        }
    }
}
