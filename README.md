# Vapour Obfuscator Cleaner

## Introduction
The following repository is a cleaner/deobfuscator for an insanely simple, Vapour Obfuscator. It is open source and made for learning purposes.

## Features
- Junk Method Cleaner
- Fake Attributes Cleaner
- String Decryption

## Preview
![image](https://github.com/autumnlikescode/Vapour-Obfuscator-Cleaner/assets/102363146/2a661717-6aa5-4f8a-9cc4-8c82a83d61f7)

## Junk Method & Fake Attributes Explained
The following cleaner will loop through every method in the assembly, for junk methods if the method names contains the 'sleep' common string it will remove them. As for the Fake Attributes cleaning it takes a LIST of analyzed fake attributes, loops through all methods, and then removes them.

## String Decryption Explained
The strings had been encrypted using Base64 which means where strings where there is 3 steps:
1. UTF8 Call
2. Get String Call
3. Base64 Call

The string decryption works by taking the operand of the ldstr OpCode which is the base64 encoded string, it then decodes the string in the cleaner and places it back into place, it then nops and nulls the opcodes and operands for the UTF8 Call, GetString Call and Base64 Call.

The Console will output the removed junk methods, removed fake attributes, and the base64 encoded -> decoded string.


## Comments
There are comments inside the source relating to what the obfuscator is calling and doing in hopes of teaching someone to understand how to develop cleaners themselves in the future. Again this is a very basic example.

## Special Thanks
- [dnlib](https://github.com/0xd4d/dnlib)
