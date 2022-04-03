using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;
using System;

namespace MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Callbackable
{
    public class CallbackableDeobfuscator: DeobfuscatorBase
    {
        private readonly Action<ModuleDefModel> OnDeobfuscate;



        public CallbackableDeobfuscator(ModuleDefModel moduleDefModel, Action<ModuleDefModel> onDeobfuscate) : base(moduleDefModel)
        {
            OnDeobfuscate = onDeobfuscate;
        }



        public override void Deobfuscate() => OnDeobfuscate?.Invoke(base.ModuleDefModel);
    }
}
