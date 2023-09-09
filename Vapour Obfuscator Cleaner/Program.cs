using dnlib.DotNet;
using dnlib.DotNet.Writer;
using Vapour_Obfuscator_Cleaner.Protections.Strings;
using Vapour_Obfuscator_Cleaner.Protections.Junk_Methods;
using Vapour_Obfuscator_Cleaner.Protections.Attributes_Remover.Fake_Attributes;

namespace Vapour_Obfuscator_Cleaner
{
    internal class Program
    {
        private static ModuleDefMD module;

        static void Main(string[] args)
        {
            module = ModuleDefMD.Load(args[0]); // Load the input assembly/module specified in the command line arguments

            JunkMethodRemover.CleanJunk(module); // Call a method to remove junk methods from the loaded module
            RemoveFakeAttributes.CleanAttributes(module); // Call a method to remove fake obfuscator attributes from the loaded module
            Decryptor.DecryptBase64(module); // Call a method to decrypt Base64-encoded strings in the loaded module

            var outputPath = Path.GetFileNameWithoutExtension(args[0]) + "_cleaned.exe"; // Specify the output path for the cleaned module (remove ".exe" extension, if present)
            module.Write(outputPath, new ModuleWriterOptions(module) // Write the cleaned module to the specified output path
            {
                Logger = DummyLogger.NoThrowInstance  // Use a dummy logger that doesn't throw exceptions for any logging during the writing process
            });
            ConsoleLogger.LogInfo($"Module saved - {outputPath}"); // Log an information message indicating the successful saving of the cleaned module

            Console.ReadKey(); 

        }
    }
}