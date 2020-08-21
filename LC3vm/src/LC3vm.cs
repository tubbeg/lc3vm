using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace LC3vm.src
{
    class LC3
    {
        private ushort[] memory;
        private static readonly ushort PC_START = 0x3000;
        private List<Register> registers;
        private Register R_PC { get; set; }
        private Register R_COND { get; set;  }
        private Register R_COUNT { get; set;  }

        private bool IsRunning { get; set; }

        public LC3()
        {
            memory = new ushort[ushort.MaxValue];
            IsRunning = true;
            R_PC.value = 0;
            R_COND.value = 0;
            R_COUNT.value = 0;
            foreach (var register in registers)
            {
                register.value = 0;
            }
        }

        private ushort GetOpCode(ushort instruction)
        {
            return (ushort)(instruction >> 12);
        }

        public void Run()
        {
            memory[R_PC.value] = PC_START;
            var instruction = memory[R_PC.value];
            var op = instruction >> 12;
            while (IsRunning)
            {
                instruction = memory[R_PC.value]++;
                op = instruction >> 12;
                //shift 12 bits to get op code 
                //Example: "ADD R0, R0, 3" translates to
                //"0b0001 000 000 00011
                // the 4 most significant bits contain
                //the op code
                switch (op)
                {
                    case (ushort)Opcodes.OP_ADD:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_AND:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_NOT:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_BR:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_JMP:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_JSR:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_LD:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_LDI:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_LDR:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_LEA:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_ST:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_STI:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_STR:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_TRAP:
                        throw new NotYetImplementedException();
                        break;
                    case (ushort)Opcodes.OP_RES:
                    case (ushort)Opcodes.OP_RTI:
                    default:
                        throw new Exception("Invalid op code");
                }

            }
        }

        private enum Opcodes : ushort
        {
            OP_BR = 0, /* branch */
            OP_ADD,    /* add  */
            OP_LD,     /* load */
            OP_ST,     /* store */
            OP_JSR,    /* jump register */
            OP_AND,    /* bitwise and */
            OP_LDR,    /* load register */
            OP_STR,    /* store register */
            OP_RTI,    /* unused */
            OP_NOT,    /* bitwise not */
            OP_LDI,    /* load indirect */
            OP_STI,    /* store indirect */
            OP_JMP,    /* jump */
            OP_RES,    /* reserved (unused) */
            OP_LEA,    /* load effective address */
            OP_TRAP    /* execute trap */
        }

        private enum ConditionFlags
        {
            FL_POS = 1 << 0, /* P */
            FL_ZRO = 1 << 1, /* Z */
            FL_NEG = 1 << 2, /* N */
        }

        public class NotYetImplementedException : Exception
        {

        }

    }
}
