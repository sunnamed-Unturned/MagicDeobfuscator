using dnlib.DotNet.MD;

namespace MagicDeobfuscator.Core.Deobfuscation.Models.Cor20Header
{
    public struct Cor20HeaderOptionsFlag
    {
        public readonly ComImageFlags Result;



        public Cor20HeaderOptionsFlag(ComImageFlags result)
        {
            Result = result;
        }
    }
}
