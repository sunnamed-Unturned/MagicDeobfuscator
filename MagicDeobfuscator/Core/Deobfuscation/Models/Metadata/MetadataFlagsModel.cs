using dnlib.DotNet.Writer;

namespace MagicDeobfuscator.Core.Deobfuscation.Models.Metadata
{
    public struct MetadataFlagsModel
    {
        public readonly MetadataFlags Result;



        public MetadataFlagsModel(MetadataFlags result)
        {
            Result = result;
        }
    }
}
