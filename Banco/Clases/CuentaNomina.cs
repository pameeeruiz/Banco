using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Clases
{
    /// <summary>
    ///  EPGR 26.02.2026
    ///  clase que representa una cuenta de nómina.
    ///  Permite calcular intereses y realizar retiros con una nomina de una empresa.
    /// </summary>

    public class CuentaNomina : CuentaBancaria
    {
        public string Empresa { get; set; }

        public CuentaNomina(string numeroCuenta, string titular, string empresa)
            : base(numeroCuenta, titular)
        {
            Empresa = empresa;
        }
        public double CalcularIntereses(double monto)
        {
            double interes = Saldo * 0.01;
            Console.WriteLine($"El interes que generaste con la  {Empresa} fue:{interes}");
            return interes;
        }
        public void Retirar(double monto)
        {
            Console.WriteLine("Cual es la cantidad a retirar?");
            monto = Convert.ToDouble(Console.ReadLine());
            if (monto > 0 && monto <= Saldo)
            {
                Saldo -= monto;
                Console.WriteLine($"Retiro de {monto} realizado con la  {Empresa}. Nuevo saldo: {Saldo}");
            }
            else
            {
                Console.WriteLine("El monto a retirar debe ser positivo y no puede exceder el saldo disponible.");
            }
        }
    }
}
