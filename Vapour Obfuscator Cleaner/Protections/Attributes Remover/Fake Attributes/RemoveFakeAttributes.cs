using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vapour_Obfuscator_Cleaner.Protections.Attributes_Remover.Fake_Attributes
{
    internal class RemoveFakeAttributes
    {
        // List of known fake obfuscator attribute names to be removed
        private static readonly List<string> FakeAttributes = new List<string>()
        {
            "AssemblyInfoAttribute",
            "BabelAttribute",
            "BabelObfuscatorAttribute",
            "CryptoObfuscator.ProtectedWithCryptoObfuscatorAttribute",
            "DotfuscatorAttribute",
            "DotNetPatcherObfuscatorAttribute",
            "DotNetPatcherPackerAttribute",
            "dotNetProtector",
            "NetGuard",
            "NineRays.Obfuscator.Evaluation",
            "ObfuscatedByGoliath",
            "PoweredByAttribute",
            "Xenocode.Client.Attributes.AssemblyAttributes.ProcessedByXenocode",
            "YanoAttribute",
        };

        // Method to clean and remove types with fake obfuscator attributes
        public static void CleanAttributes(ModuleDefMD module)
        {
            // Iterate through all types in the module using ToList() to avoid modification during iteration
            foreach (TypeDef type in module.Types.ToList().Where(t => FakeAttributes.Contains(t.Name)))
            {
                // Remove the identified type from the module
                module.Types.Remove(type);

                // Log a success message indicating the removal of the fake obfuscator type
                ConsoleLogger.LogSuccess($"Removed the fake obfuscator type: {type.Name}");
            }
        }
    }
}
