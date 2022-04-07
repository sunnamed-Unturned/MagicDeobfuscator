using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public class FieldsWhiteSpaceCleanerDeobfuscator : DeobfuscatorBase
    {
        public FieldsWhiteSpaceCleanerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
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
                        field.Name = field.Name.String.Trim();
                    }
                }
            }
        }
    }
}
