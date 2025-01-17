﻿using System;
using System.Collections.Generic;

namespace compiler.types
{
    public class PointerType : AbstractType
    {
        public static readonly PointerType NULL = new();
        public static readonly PointerType STRING = new(PrimitiveType.CHAR);

        private AbstractType type;

        public AbstractType Type => type;

        public bool IsArray
        {
            get;
        }

        public bool IsString => type == null || PrimitiveType.IsPrimitiveChar(type);

        internal PointerType(AbstractType type = null, bool isArray = false)
        {
            this.type = type;
            IsArray = isArray;
    }

        public override bool Equals(object obj) => ReferenceEquals(this, obj) || obj != null && obj is PointerType ptr && type == ptr.type;

        public override string ToString() => type == null ? "nulo" : IsArray ? type + "[]" : "*" + type;

        protected override int GetSize() => IntPtr.Size;

        public override bool CoerceWith(AbstractType other, bool isExplicit)
        {
            switch (other)
            {
                case PrimitiveType p:
                    switch (p.Primitive)
                    {
                        case Primitive.VOID:
                        case Primitive.BOOL:
                            return false;

                        case Primitive.BYTE:
                            return isExplicit;

                        case Primitive.CHAR:
                            return false;

                        case Primitive.SHORT:
                            return isExplicit;

                        case Primitive.INT:
                            return isExplicit;

                        case Primitive.LONG:
                            return isExplicit;

                        case Primitive.FLOAT:
                            return isExplicit;

                        case Primitive.DOUBLE:
                            return isExplicit;
                    }

                    break;

                case PointerType ptr:
                {
                    if (type == null)
                        return true;

                    AbstractType otherType = ptr.Type;
                    return isExplicit || PrimitiveType.IsPrimitiveVoid(otherType) || type == otherType;
                }

                case StringType:
                    return type != null && PrimitiveType.IsPrimitiveChar(type);
            }

            return false;
        }

        public override int GetHashCode() => 34944597 + EqualityComparer<AbstractType>.Default.GetHashCode(type);

        public static bool operator ==(PointerType t1, PointerType t2) => ReferenceEquals(t1, t2) || t1 is not null && t2 is not null && t1.Equals(t2);

        public static bool operator !=(PointerType t1, PointerType t2) => !(t1 == t2);

        public override bool IsUnresolved() => type.IsUnresolved();

        protected override void UncheckedResolve()
        {
            if (type == null)
                return;

            if (type is UnresolvedType u)
            {
                if (u.ReferencedType == null)
                    throw new CompilerException(u.Interval, "Tipo não declarado '" + u.Name + "'.");

                type = u.ReferencedType;
            }
            else
                Resolve(ref type);
        }
    }
}
