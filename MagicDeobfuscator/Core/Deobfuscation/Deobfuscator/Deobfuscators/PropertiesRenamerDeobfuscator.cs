using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public sealed class PropertiesRenamerDeobfuscator : DeobfuscatorBase
    {
        public PropertiesRenamerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            foreach (TypeDef type in base.ModuleDefModel.Result.GetTypes())
            {
                if (type.HasProperties)
                {
                    foreach (PropertyDef property in type.Properties)
                    {
                        string propertyDefName = property.Name.String;
                        string[] splittedDefName = propertyDefName.Split('.');

                        property.Name = splittedDefName[splittedDefName.Length - 1];
                    }
                }
            }
        }
    }
}
