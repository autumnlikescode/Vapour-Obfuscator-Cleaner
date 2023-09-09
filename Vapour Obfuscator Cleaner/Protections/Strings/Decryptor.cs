using dnlib.DotNet.Emit;
using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;

namespace Vapour_Obfuscator_Cleaner.Protections.Strings
{
    internal class Decryptor
    {
        public static int decryptedStringCount = 0;

        public static void DecryptBase64(ModuleDefMD module)
        {
            // Iterate through all types in the module
            foreach (var type in module.GetTypes())
            {
                // Iterate through all methods in the current type
                foreach (var method in type.Methods)
                {
                    // Check if the method has a method body
                    if (!method.HasBody)
                        continue; // Skip methods without bodies

                    // Create a list of instructions from the method's body
                    var instructions = new List<Instruction>(method.Body.Instructions);

                    // Iterate through instructions in reverse order
                    for (var i = instructions.Count - 1; i >= 0; i--)
                    {
                        // Check if the current instruction is a method call that contains "Base64"
                        if (instructions[i].OpCode.Code == Code.Call &&
                            instructions[i].Operand.ToString().Contains("Base64"))
                        {
                            // Extract the Base64-encoded string
                            string encoded = (string)instructions[i - 1].Operand;

                            // Decode the Base64 string to a byte array
                            byte[] data = Convert.FromBase64String(encoded);

                            // Convert the byte array to a decoded string using UTF-8 encoding
                            string decoded = Encoding.UTF8.GetString(data);

                            // Log the decoding result
                            ConsoleLogger.LogSuccess($"{encoded} -> {decoded}");

                            // Remove the Base64 decode call by replacing it with a Nop (no operation)
                            instructions[i].OpCode = OpCodes.Nop;
                            instructions[i].Operand = null;

                            // Set the new string value in place of the original Base64 string
                            instructions[i - 1].OpCode = OpCodes.Ldstr;
                            instructions[i - 1].Operand = decoded;

                            // Remove the UTF8 Call
                            instructions[i - 2].OpCode = OpCodes.Nop;
                            instructions[i - 2].Operand = null;

                            // Remove the GetString Call
                            instructions[i + 1].OpCode = OpCodes.Nop;
                            instructions[i + 1].Operand = null;

                            // Increment the count of decrypted strings
                            decryptedStringCount++;
                        }
                    }
                }
            }
        }
    }

}
