using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    internal class PropertiesWhiteSpaceCleanerDeobfuscator : DeobfuscatorBase
    {
        public PropertiesWhiteSpaceCleanerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
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
                        property.Name = property.Name.String.Trim();
                    }
                }
            }
        }
    }
}
