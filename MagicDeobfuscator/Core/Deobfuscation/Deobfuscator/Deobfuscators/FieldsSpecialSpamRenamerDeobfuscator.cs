using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;
using System.Text;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    internal class FieldsSpecialSpamRenamerDeobfuscator : DeobfuscatorBase
    {
        public FieldsSpecialSpamRenamerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            string newFieldName = "field";
            int previousFieldNameValue = 0;
            foreach (TypeDef type in base.ModuleDefModel.Result.GetTypes())
            {
                if (type.HasFields)
                {
                    foreach (FieldDef field in type.Fields)
                    {
                        if (field.Name.String.Contains("<") || field.Name.String.Contains(">") || field.Name.String.Contains("_"))
                        {
                            field.Name = new StringBuilder()
                                .Append(newFieldName)
                                .Append(previousFieldNameValue++.ToString())
                                .ToString();
                        }
                    }
                }
            }
        }
    }
}
