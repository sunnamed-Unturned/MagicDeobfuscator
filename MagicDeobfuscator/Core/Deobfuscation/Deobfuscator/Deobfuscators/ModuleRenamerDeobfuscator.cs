﻿using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;
using System;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public sealed class ModuleRenamerDeobfuscator : DeobfuscatorBase
    {
        public ModuleRenamerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            foreach (TypeDef type in base.ModuleDefModel.Result.GetTypes())
            {
                if (type.Name.Contains("Module"))
                {
                    type.Name = type.Name.String.Replace("<", string.Empty).Replace(">", string.Empty);
                    type.BaseType = new Importer(base.ModuleDefModel.Result).Import(typeof(Object));
                }
            }
        }
    }
}
