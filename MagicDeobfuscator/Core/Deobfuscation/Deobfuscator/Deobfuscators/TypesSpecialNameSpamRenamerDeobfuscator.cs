using dnlib.DotNet;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators
{
    public class TypesSpecialNameSpamRenamerDeobfuscator : DeobfuscatorBase
    {
        public TypesSpecialNameSpamRenamerDeobfuscator(ModuleDefModel moduleDefModel) : base(moduleDefModel)
        {
        }



        public override void Deobfuscate()
        {
            foreach (TypeDef type in base.ModuleDefModel.Result.GetTypes())
            {
                string typeDefName = type.Name.String;
                string[] splittedTypeDefName = typeDefName.Split('(');
                if (splittedTypeDefName.Length != 0)
                {
                    type.Name = splittedTypeDefName[0];
                }
            }
        }
    }
}
