﻿using dnlib.DotNet;
using dnlib.DotNet.Emit;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;
using System.Collections.Generic;
using System.Linq;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public sealed class NopCleanerDeobfuscator: DeobfuscatorBase
    {
        public NopCleanerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            foreach (TypeDef typeDef in base.ModuleDefModel.Result.GetTypes())
            {
                foreach (MethodDef method in typeDef.Methods)
                {
                    if (method.HasBody == false)
                    {
                        continue;
                    }

                    List<Instruction> instructions = method.Body.Instructions.ToList().FindAll(i => i.OpCode == OpCodes.Nop);
                    foreach (Instruction instruction in instructions)
                    {
                        method.Body.Instructions.Remove(instruction);
                    }
                }
            }
        }
    }
}
