using dnlib.DotNet;
using dnlib.DotNet.MD;
using dnlib.DotNet.Writer;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Base;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Callbackable;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Container;
using MagicDeobfuscator.Core.Deobfuscation.Deobfuscator.Deobfuscators;
using MagicDeobfuscator.Core.Deobfuscation.Models.Cor20Header;
using MagicDeobfuscator.Core.Deobfuscation.Models.Metadata;
using MagicDeobfuscator.Core.Deobfuscation.Models.Module;
using MagicDeobfuscator.Core.Deobfuscation.Module.Builder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MagicDeobfuscator
{
    public sealed class Program
    {
        private static void Main(string[] args)
        {
            AssemblyDef assmeblyDef = AssemblyDef.Load(args[0]);
            ModuleDef moduleDef = assmeblyDef.ManifestModule;
            ModuleDefModel moduleDefModel = new ModuleDefModel(moduleDef);

            DeobfuscatorsContainer container = new DeobfuscatorsContainer(new List<DeobfuscatorBase>
            {
                new CodeBrokerCleanerDeobfuscator(moduleDefModel),
                new ModuleRenamerDeobfuscator(moduleDefModel),
                new TypesRenamerDeobfuscator(moduleDefModel),
                new MethodsRenamerDeobfuscator(moduleDefModel),
                new GenericFixerDeobfuscator(moduleDefModel),
                new TypesWhiteSpaceCleanerDeobfuscator(moduleDefModel),
                new FieldsWhiteSpaceCleanerDeobfuscator(moduleDefModel),
                new PropertiesWhiteSpaceCleanerDeobfuscator(moduleDefModel),
                new FieldsRenamerDeobfuscator(moduleDefModel),
                new PropertiesRenamerDeobfuscator(moduleDefModel),
                new MethodsWhiteSpaceCleanerDeobfuscator(moduleDefModel),
                new FieldsSpecialSpamRenamerDeobfuscator(moduleDefModel),
                new TypesSpecialNameSpamRenamerDeobfuscator(moduleDefModel),
                //new NopCleanerDeobfuscator(moduleDefModel),
            });

            Console.WriteLine("Deobfuscating..!");
            foreach (DeobfuscatorBase deobfuscator in container.Deobfuscators)
            {
                Console.WriteLine("! Launching deobfuscator: " + deobfuscator.GetType().Name);
                deobfuscator.Deobfuscate();
            }
            Console.WriteLine("Cleaning completed..!");

            Console.WriteLine("Writing the file...");
            new ModuleBuilder(moduleDefModel)
                .SetMetadataFlags(new MetadataFlagsModel(MetadataFlags.PreserveAll))
                .SetNoThrowInstance()
                .SetCor20HeaderOptionsFlag(new Cor20HeaderOptionsFlag(ComImageFlags.ILOnly))
                .Build(new StringBuilder()
                    .Append(Path.GetFileNameWithoutExtension(args[0]))
                    .Append("_cleaned")
                    .Append(Path.GetExtension(args[0]))
                    .ToString());
            Console.WriteLine("Writed!...");

            Console.ReadLine();
        }
    }
}
