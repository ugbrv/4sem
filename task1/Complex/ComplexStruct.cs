namespace ComplexStruct
{
    public struct Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public double Abs
        {
            get => Math.Sqrt(Re*Re + Im*Im);
        }
        public Complex(double re, double im) : this()
        {
            Re = re;
            Im = im;
        }
        public override string ToString()
        {
            if ((Re == 0)&&(Im == 0)) return "0";
            if (Re == 0) return $"{Im}i";
            if (Im == 0) return $"{Re}";
            if (Im == 1) return $"{Re} + i";
            if (Im == -1) return $"{Re} - i";
            if (Im > 0) return $"{Re} + {Im}i";
            else return $"{Re} - {Math.Abs(Im)}i";
        }
        public override bool Equals(object obj)
        {
            if (obj is Complex)
                return ((Re == ((Complex)obj).Re)&&((Im == ((Complex)obj).Im)));
            throw new ArgumentException("Объект для сравнения не является комплексным числом");
        }
        public override int GetHashCode() => Abs.GetHashCode();
        public static bool operator ==(Complex x, Complex y) => x.Equals(y);
        public static bool operator !=(Complex x, Complex y) => !x.Equals(y);
        public static Complex operator +(Complex x, Complex y) =>
        new Complex(x.Re + y.Re, x.Im + y.Im);
        public static Complex operator -(Complex x, Complex y) =>
        new Complex(x.Re - y.Re, x.Im - y.Im);

    }
}