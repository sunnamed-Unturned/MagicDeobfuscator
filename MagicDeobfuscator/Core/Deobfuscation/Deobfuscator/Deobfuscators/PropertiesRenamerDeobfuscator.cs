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
            foreach (TypeDef typeDef in base.ModuleDefModel.Result.GetTypes())
            {
                if (typeDef.HasProperties)
                {
                    foreach (PropertyDef propertyDef in typeDef.Properties)
                    {
                        string propertyDefName = propertyDef.Name.String;
                        string[] splittedDefName = propertyDefName.Split('.');

                        propertyDef.Name = splittedDefName[splittedDefName.Length - 1];
                    }
                }
            }
        }
    }
}
