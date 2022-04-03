using dnlib.DotNet;
using dnlib.DotNet.Writer;
using MagicDeobfuscator.Core.Deobfuscation.Models.Cor20Header;
using MagicDeobfuscator.Core.Deobfuscation.Models.Metadata;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;

namespace MagicDeobfuscator.Core.Deobfuscation.Module.Builder
{
    public sealed class ModuleBuilder: IModuleBuilder
    {
        private ModuleWriterOptionsModel OptionsModel;
        private ModuleDefModel ModuleDefModel;



        public ModuleBuilder(ModuleDefModel moduleDefModel)
        {
            ModuleDefModel = moduleDefModel;
            OptionsModel = new ModuleWriterOptionsModel(new ModuleWriterOptions(moduleDefModel.Result));
        }



        public IModuleBuilder SetMetadataFlags(MetadataFlagsModel flags)
        {
            OptionsModel.Result.MetadataOptions.Flags = flags.Result;
            return this;
        }

        public IModuleBuilder SetNoThrowInstance()
        {
            OptionsModel.Result.MetadataLogger = DummyLogger.NoThrowInstance;
            return this;
        }

        public IModuleBuilder SetThrowModuleWriterExceptionOnErrorInstance()
        {
            OptionsModel.Result.MetadataLogger = DummyLogger.ThrowModuleWriterExceptionOnErrorInstance;
            return this;
        }

        public IModuleBuilder SetOwnWriterOptions(ModuleWriterOptionsModel model)
        {
            OptionsModel = model;
            return this;
        }

        public IModuleBuilder SetCor20HeaderOptionsFlag(Cor20HeaderOptionsFlag model)
        {
            OptionsModel.Result.Cor20HeaderOptions.Flags = model.Result;
            return this;
        }

        public ModuleWriterOptionsModel Build()
        {
            return OptionsModel;
        }

        public void Build(string savePath)
        {
            ModuleDefModel.Result.Write(savePath, OptionsModel.Result);
        }
    }
}
