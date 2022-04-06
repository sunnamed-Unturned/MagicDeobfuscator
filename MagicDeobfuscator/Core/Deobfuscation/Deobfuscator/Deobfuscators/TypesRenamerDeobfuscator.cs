using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;
using System;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public sealed class TypesRenamerDeobfuscator : DeobfuscatorBase
    {
        public TypesRenamerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            foreach (TypeDef typeDef in base.ModuleDefModel.Result.GetTypes())
            {
                string typeDefName = typeDef.Name.String;
                string[] splittedTypeDefName = typeDefName.Split('.');
                typeDef.Name = splittedTypeDefName[splittedTypeDefName.Length - 1];
            }
        }
    }
}
