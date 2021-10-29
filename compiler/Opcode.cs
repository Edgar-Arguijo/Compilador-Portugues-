﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public enum Opcode
    {
		NOP,
		LC8,
		LC16,
		LC32,
		LC64,
		LIP,
		LSP,
		LBP,
		SIP,
		SSP,
		SBP,
		LS,
		LS64,
		SS,
		SS64,
		ADD,
		ADD64,
		SUB,
		SUB64,
		MUL,
		MUL64,
		DIV,
		DIV64,
		MOD,
		MOD64,
		NEG,
		NEG64,
		FADD,
		FADD64,
		FSUB,
		FSUB64,
		FMUL,
		FMUL64,
		FDIV,
		FDIV64,
		FNEG,
		FNEG64,
		I32I64,
		I64I32,
		I32F32,
		I32F64,
		I64F64,
		F32F64,
		F32I32,
		F32I64,
		F64I64,
		F64F32,
		AND,
		AND64,
		OR,
		OR64,
		XOR,
		XOR64,
		NOT,
		NOT64,
		SHL,
		SHL64,
		SHR,
		SHR64,
		USHR,
		USHR64,
		CMPE,
		CMPNE,
		CMPG,
		CMPGE,
		CMPL,
		CMPLE,
		CMPE64,
		CMPNE64,
		CMPG64,
		CMPGE64,
		CMPL64,
		CMPLE64,
		FCMPE,
		FCMPNE,
		FCMPG,
		FCMPGE,
		FCMPL,
		FCMPLE,
		FCMPE64,
		FCMPNE64,
		FCMPG64,
		FCMPGE64,
		FCMPL64,
		FCMPLE64,
		JMP,
		JT,
		JF,
		POP,
		POP2,
		POPN,
		DUP,
		DUP64,
		DUPN,
		DUP64N,
		CALL,
		RET,
		SCAN,
		SCAN64,
		FSCAN,
		FSCAN64,
		PRINT,
		PRINT64,
		FPRINT,
		FPRINT64,
		HALT
	}
}
