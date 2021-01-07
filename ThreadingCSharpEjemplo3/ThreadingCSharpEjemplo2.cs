using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadingCSharpEjemplo3
{
    class Circulo
    {
        private double _radio;
        private double _diametro;

        public double Diametro
        {
            get
            {
                return _diametro;
            }
        }

        public double Radio
        {
            get 
            {
                return _radio;
            }
            set 
            {
                _radio = value;
            }
        }

            public void calcularDiametro()
            {
                _diametro = Math.PI * Math.Pow(_radio,2);
            }
     }
}
