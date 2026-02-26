using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Clases
{
    public class CuentaCorriente : CuentaBancaria
    {
        /// <summary>
        /// EPGR 26-02-2026
        ///calcula interes(0), permite sobregiros hasta un límite establecido y  retirar, aplicar una comisión por cada sobregiro.
        /// </summary>
        public double Comision { get; set; }
        public double limiteSobregiro { get; set; }

        public CuentaCorriente(string numeroCuenta, string titular, double comision, double limiteSobregiro)
            : base(numeroCuenta, titular)
        {
            Comision = comision;
            this.limiteSobregiro = limiteSobregiro;
        }

        public double CalcularInteres()
        {
            return 0;
        }

        public void Retirar(double monto)
        {
            Console.WriteLine("Cual es la cantidad a retirar?");
            monto = Convert.ToDouble(Console.ReadLine());
            if (monto > 0 && monto <= Saldo + limiteSobregiro)
            {
                Saldo -= monto;

                if (Saldo < 0)
                {
                    Saldo -= 20;
                    Console.WriteLine($"Se ha aplicado una comisión de {20} por sobregiro. Nuevo saldo: {Saldo}");
                }
                Console.WriteLine($"Retiro de {monto} realizado. Nuevo saldo: {Saldo}");
            }
            else
            {
                Console.WriteLine("Excede el límite de sobregiro.");
            }
        }
    }
}
