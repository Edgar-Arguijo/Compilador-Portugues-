﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public abstract class Expression
    {
    }

    public enum UnaryOperation
    {
        NEGATION, // -a
        BITWISE_NOT, // ~a
        LOGICAL_NOT, // !a
        POINTER_DEFERENCE, // *a
        PRE_INCREMENT, // ++a
        PRE_DECREMENT, // --a
        POST_INCREMENT, // a++
        POST_DECREMENT // a--
    }

    public class UnaryExpression : Expression
    {
        private UnaryOperation operation;
        private Expression operand;

        public UnaryOperation Operation
        {
            get
            {
                return operation;
            }
        }

        public Expression Operand
        {
            get
            {
                return operand;
            }
        }

        public UnaryExpression(UnaryOperation operation, Expression operand)
        {
            this.operation = operation;
            this.operand = operand;
        }
    }

    public enum BinaryOperation
    {
        STORE, // a = b
        STORE_OR, // a |= b
        STORE_XOR, // a ^= b
        STORE_AND, // a &= b
        STORE_SHIFT_LEFT, // a <<= b
        STORE_SHIFT_RIGHT, // a >>= b
        STORE_UNSIGNED_SHIFT_RIGHT, // a >>>= b
        STORE_ADD, // a += b
        STORE_SUB, // a -= b
        STORE_MUL, // a *= b
        STORE_DIV, // a /= b
        STORE_MOD, // a %= b
        LOGICAL_OR, // a || b
        LOGICAL_XOR, // a ^^ b
        LOGICAL_AND, // a && b
        SHIFT_LEFT, // a << b
        SHIFT_RIGHT, // a >> b
        UNSIGNED_SHIFT_RIGHT, // a >>> b
        EQUALS, // a == b
        NOT_EQUALS, // a != b
        GREATER, // a > b
        GREATER_OR_EQUALS, // a >= b
        LESS, // a < b
        LESS_OR_EQUALS, // a <= b
        BITWISE_OR, // a | b
        BITWISE_XOR, // a ^ b
        BITWISE_AND, // a & b
        ADD, // a + b
        SUB, // a - b
        MUL, // a * b
        DIV, // a / b
        MOD // a % b
    }

    public class BinaryExpression : Expression
    {
        private BinaryOperation operation;
        private Expression leftOperand;
        private Expression rightOperand;

        public BinaryOperation Operation
        {
            get
            {
                return operation;
            }
        }

        public Expression LeftOperand
        {
            get
            {
                return leftOperand;
            }
        }

        public Expression RightOperand
        {
            get
            {
                return rightOperand;
            }
        }

        public BinaryExpression(BinaryOperation operation, Expression leftOperand, Expression rightOperand)
        {
            this.operation = operation;
            this.leftOperand = leftOperand;
            this.rightOperand = rightOperand;
        }
    }

    public class FieldAcessorExpression : Expression
    {
        private Expression operand;
        private string field;

        public Expression Operand
        {
            get
            {
                return operand;
            }
        }

        public string Field
        {
            get
            {
                return field;
            }
        }

        public FieldAcessorExpression(Expression operand, string field)
        {
            this.operand = operand;
            this.field = field;
        }
    }

    public class ArrayAccessorExpression : Expression
    {
        private Expression operand;
        private List<Expression> indexers;

        public Expression Operand
        {
            get
            {
                return operand;
            }
        }

        public int IndexerCount
        {
            get
            {
                return indexers.Count;
            }
        }

        public Expression this[int index]
        {
            get
            {
                return indexers[index];
            }
        }

        public ArrayAccessorExpression(Expression operand)
        {
            this.operand = operand;

            indexers = new List<Expression>();
        }

        public void AddIndexer(Expression indexer)
        {
            indexers.Add(indexer);
        }
    }

    public class CallExpression : Expression
    {
        private Expression operand;
        private List<Expression> parameters;

        public Expression Operand
        {
            get
            {
                return operand;
            }
        }

        public int ParameterCount
        {
            get
            {
                return parameters.Count;
            }
        }

        public Expression this[int index]
        {
            get
            {
                return parameters[index];
            }
        }

        public CallExpression(Expression operand)
        {
            this.operand = operand;

            parameters = new List<Expression>();
        }

        public void AddParameter(Expression parameter)
        {
            parameters.Add(parameter);
        }
    }

    public class CastExpression : Expression
    {
        private AbstractType type;
        private Expression operand;

        public AbstractType Type
        {
            get
            {
                return type;
            }
        }

        public Expression Operand
        {
            get
            {
                return operand;
            }
        }

        public CastExpression(AbstractType type, Expression operand)
        {
            this.type = type;
            this.operand = operand;
        }
    }

    public enum PrimaryType
    {
        BOOL_LITERAL, // verdadeiro, falso
        BYTE_LITERAL, // 1B
        CHAR_LITERAL, // 'a'
        SHORT_LITERAL, // 1S
        INT_LITERAL, // 1
        LONG_LITERAL, // 1L
        FLOAT_LITERAL, // 1F
        DOUBLE_LITERAL, // 1.0
        STRING_LITERAL, // "abc"
        NULL_LITERAL, // null
        IDENTIFIER, // x
    }

    public abstract class PrimaryExpression : Expression
    {
        private PrimaryType primaryType;

        public PrimaryType PrimaryType => primaryType;

        public AbstractType Type => GetType();
        protected PrimaryExpression(PrimaryType primaryType)
        {
            this.primaryType = primaryType;
        }

#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
        protected abstract AbstractType GetType();
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
    }

    public class BoolLiteralExpression : PrimaryExpression
    {
        private bool value;

        public bool Value
        {
            get
            {
                return value;
            }
        }

        public BoolLiteralExpression(bool value) : base(PrimaryType.BOOL_LITERAL)
        {
            this.value = value;
        }

        protected override AbstractType GetType()
        {
            return PrimitiveType.BOOL;
        }
    }

    public class ByteLiteralExpression : PrimaryExpression
    {
        private byte value;

        public byte Value
        {
            get
            {
                return value;
            }
        }

        public ByteLiteralExpression(byte value) : base(PrimaryType.BYTE_LITERAL)
        {
            this.value = value;
        }

        protected override AbstractType GetType()
        {
            return PrimitiveType.BYTE;
        }
    }

    public class CharLiteralExpression : PrimaryExpression
    {
        private char value;

        public char Value
        {
            get
            {
                return value;
            }
        }

        public CharLiteralExpression(char value) : base(PrimaryType.CHAR_LITERAL)
        {
            this.value = value;
        }

        protected override AbstractType GetType()
        {
            return PrimitiveType.CHAR;
        }
    }

    public class ShortLiteralExpression : PrimaryExpression
    {
        private short value;

        public short Value
        {
            get
            {
                return value;
            }
        }

        public ShortLiteralExpression(short value) : base(PrimaryType.SHORT_LITERAL)
        {
            this.value = value;
        }

        protected override AbstractType GetType()
        {
            return PrimitiveType.SHORT;
        }
    }

    public class IntLiteralExpression : PrimaryExpression
    {
        private int value;

        public int Value
        {
            get
            {
                return value;
            }
        }

        public IntLiteralExpression(int value) : base(PrimaryType.INT_LITERAL)
        {
            this.value = value;
        }

        protected override AbstractType GetType()
        {
            return PrimitiveType.INT;
        }
    }

    public class LongLiteralExpression : PrimaryExpression
    {
        private long value;

        public long Value
        {
            get
            {
                return value;
            }
        }

        public LongLiteralExpression(long value) : base(PrimaryType.LONG_LITERAL)
        {
            this.value = value;
        }

        protected override AbstractType GetType()
        {
            return PrimitiveType.LONG;
        }
    }

    public class FloatLiteralExpression : PrimaryExpression
    {
        private float value;

        public float Value
        {
            get
            {
                return value;
            }
        }

        public FloatLiteralExpression(float value) : base(PrimaryType.FLOAT_LITERAL)
        {
            this.value = value;
        }

        protected override AbstractType GetType()
        {
            return PrimitiveType.FLOAT;
        }
    }

    public class DoubleLiteralExpression : PrimaryExpression
    {
        private double value;

        public double Value
        {
            get
            {
                return value;
            }
        }

        public DoubleLiteralExpression(double value) : base(PrimaryType.DOUBLE_LITERAL)
        {
            this.value = value;
        }

        protected override AbstractType GetType()
        {
            return PrimitiveType.DOUBLE;
        }
    }

    public class StringLiteralExpression : PrimaryExpression
    {
        private string value;

        public string Value
        {
            get
            {
                return value;
            }
        }

        public StringLiteralExpression(string value) : base(PrimaryType.STRING_LITERAL)
        {
            this.value = value;
        }

        protected override AbstractType GetType()
        {
            return new PointerType(PrimitiveType.CHAR);
        }
    }

    public class NullLiteralExpression : PrimaryExpression
    {
        public NullLiteralExpression() : base(PrimaryType.NULL_LITERAL)
        {
        }

        protected override AbstractType GetType()
        {
            return new PointerType();
        }
    }

    public class IdentifierExpression : PrimaryExpression
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public IdentifierExpression(string name) : base(PrimaryType.IDENTIFIER)
        {
            this.name = name;
        }

        protected override AbstractType GetType()
        {
            throw new InvalidOperationException("Tipo desconhecido do identififcador '" + name + "'.");
        }
    }
}
