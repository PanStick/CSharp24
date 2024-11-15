using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace C_Course.zad03
{
    //3.4, 3.6
    class Complex<T> : IComparable, IFormattable, IAdditionOperators<Complex<T>, Complex<T>, Complex<T>>, IMultiplyOperators<Complex<T>, Complex<T>, Complex<T>>
            where T : INumber<T>//, IComparable, IFormattable, IAdditionOperators<T, T, T>, IMultiplyOperators<T, T, T>, ISubtractionOperators<T, T, T>
    {
        T _real;
        T _imaginary;

        public Complex(T Real, T Imaginary)
        {
            _real = Real;
            _imaginary = Imaginary;
        }

        public T GetReal() => _real;
        public T GetImaginary() => _imaginary;

        public static Complex<T> operator +(Complex<T> a, Complex<T> b)
        {
            return new Complex<T>(a.GetReal() + b.GetReal(), a.GetImaginary() + b.GetImaginary());
        }

        public static Complex<T> operator *(Complex<T> a, Complex<T> b)
        {
            return new Complex<T>(a.GetReal() * b.GetReal() - a.GetImaginary() * b.GetImaginary(),
                                  a.GetReal() * b.GetImaginary() + a.GetImaginary() * b.GetReal());
        }

        public int CompareTo(object? obj)
        {
            return _real.CompareTo(obj);
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return _real.ToString(format, formatProvider) + " + " + _imaginary.ToString(format, formatProvider) + "i";
        }
        public override string ToString()
        {
            return _real.ToString() + " + " + _imaginary.ToString() + "i";
        }
    }
}
