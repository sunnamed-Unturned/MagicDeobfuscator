﻿using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public sealed class TypesRenamerDeobfuscator : DeobfuscatorBase
    {
        public TypesRenamerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            foreach (TypeDef type in base.ModuleDefModel.Result.GetTypes())
            {
                string typeDefName = type.Name.String;
                string[] splittedTypeDefName = typeDefName.Split('.');
                type.Name = splittedTypeDefName[splittedTypeDefName.Length - 1];
            }
        }
    }
}
