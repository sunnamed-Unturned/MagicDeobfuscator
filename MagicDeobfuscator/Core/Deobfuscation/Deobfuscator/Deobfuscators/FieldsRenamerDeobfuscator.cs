using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public sealed class FieldsRenamerDeobfuscator : DeobfuscatorBase
    {
        public FieldsRenamerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            foreach (TypeDef typeDef in base.ModuleDefModel.Result.GetTypes())
            {
                if (typeDef.HasFields)
                {
                    foreach (FieldDef fieldDef in typeDef.Fields)
                    {
                        string fieldDefName = fieldDef.Name.String;
                        string[] splittedDefName = fieldDefName.Split('.');

                        fieldDef.Name = splittedDefName[splittedDefName.Length - 1];
                    }
                }
            }
        }
    }
}
