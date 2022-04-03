using dnlib.DotNet.Writer;

namespace MagicDeobfuscator.Core.Deobfuscation.Models.Module
{
    public struct ModuleWriterOptionsModel
    {
        public readonly ModuleWriterOptions Result;



        public ModuleWriterOptionsModel(ModuleWriterOptions result)
        {
            Result = result;
        }
    }
}
