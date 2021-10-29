﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public class FloatLiteral : NumericLiteral
    {
        private float value;

        public float Value
        {
            get
            {
                return value;
            }
        }

        public FloatLiteral(float value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        public override byte AsByte()
        {
            return (byte) value;
        }

        public override short AsShort()
        {
            return (short) value;
        }

        public override int AsInt()
        {
            return (int) value;
        }

        public override long AsLong()
        {
            return (long) value;
        }

        public override float AsFloat()
        {
            return value;
        }

        public override double AsDouble()
        {
            return value;
        }
    }
}
