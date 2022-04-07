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
            foreach (TypeDef type in base.ModuleDefModel.Result.GetTypes())
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (method.IsConstructor == false)
                    {
                        string methodName = method.Name.String;
                        string[] splittedMethodName = methodName.Split('.');

                        method.Name = splittedMethodName[splittedMethodName.Length - 1];
                    }
                }
            }
        }
    }
}
