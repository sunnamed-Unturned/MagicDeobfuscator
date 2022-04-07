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
            foreach (TypeDef type in base.ModuleDefModel.Result.GetTypes())
            {
                if (type.HasFields)
                {
                    foreach (FieldDef field in type.Fields)
                    {
                        string fieldDefName = field.Name.String;
                        string[] splittedDefName = fieldDefName.Split('.');

                        field.Name = splittedDefName[splittedDefName.Length - 1];
                    }
                }
            }
        }
    }
}
