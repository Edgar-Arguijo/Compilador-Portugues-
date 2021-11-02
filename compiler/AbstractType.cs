﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public abstract class AbstractType
    {
        public abstract int Size();

        public abstract bool CoerceWith(AbstractType other, bool isExplicit);

        public override bool Equals(object other)
        {
            throw new Exception("Método não implementado");
        }

        public override int GetHashCode()
        {
            throw new Exception("Método não implementado");
        }

        public static bool operator ==(AbstractType t1, AbstractType t2)
        {
            if (ReferenceEquals(t1, t2))
                return true;

            if (((object) t1) == null || ((object) t2) == null)
                return false;

            return t1.Equals(t2);
        }

        public static bool operator !=(AbstractType t1, AbstractType t2)
        {
            return !(t1 == t2);
        }
    }
}
