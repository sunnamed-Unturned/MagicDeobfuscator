using MagicDeobfuscator.Core.Deobfuscation.Models.Cor20Header;
using MagicDeobfuscator.Core.Deobfuscation.Models.Metadata;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Module.Builder
{
    public interface IModuleBuilder
    {
        IModuleBuilder SetMetadataFlags(MetadataFlagsModel flags);

        IModuleBuilder SetNoThrowInstance();

        IModuleBuilder SetThrowModuleWriterExceptionOnErrorInstance();

        IModuleBuilder SetOwnWriterOptions(ModuleWriterOptionsModel model);

        IModuleBuilder SetCor20HeaderOptionsFlag(Cor20HeaderOptionsFlag model);

        ModuleWriterOptionsModel Build();

        void Build(string savePath);
    }
}
