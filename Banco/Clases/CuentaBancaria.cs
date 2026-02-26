using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Clases
{

    /// <summary>
    ///  EPGR 26.02.2026
    ///  Clase que representa una cuenta bancaria.
    ///  muestra la información de la cuenta, permite realizar depósitos y es la clase base para otros tipos de cuentas.
    /// </summary>
    public class CuentaBancaria
    {
       
            public string NumeroCuenta { get; set; }
            public string Titular { get; set; }
            public double Saldo { get; set; }

            public CuentaBancaria(string numeroCuenta, string titular)
            {
                Titular = titular;
                NumeroCuenta = numeroCuenta;
                Saldo = 0;
            }

            public void MostrarInformacion()
            {
                Console.WriteLine($"Número de Cuenta: {NumeroCuenta}");
                Console.WriteLine($"Titular: {Titular}");
                Console.WriteLine($"Saldo: ${Saldo}");
            }

            public void Depositar(double monto)
            {
                if (monto > 0)
                {
                    Saldo += monto;
                    Console.WriteLine($"Depósito de {monto} realizado. Nuevo saldo: {Saldo}");
                }
                else
                {
                    Console.WriteLine("El monto a depositar debe ser positivo.");
                }
            }
    }
}

