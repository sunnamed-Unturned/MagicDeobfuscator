using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public sealed class MethodsRenamerDeobfuscator : DeobfuscatorBase
    {
        public MethodsRenamerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            foreach (TypeDef typeDef in base.ModuleDefModel.Result.GetTypes())
            {
                foreach (MethodDef methodDef in typeDef.Methods)
                {
                    if (methodDef.IsConstructor)
                    {
                        continue;
                    }

                    string methodName = methodDef.Name.String;
                    string[] splittedMethodName = methodName.Split('.');

                    methodDef.Name = splittedMethodName[splittedMethodName.Length - 1];
                }
            }
        }
    }
}
