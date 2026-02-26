using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Clases
{
    /// <summary>
    ///  EPGR 26.02.2026
    ///  Clase que representa una cuenta de ahorros.
    ///  Permite calcular intereses y realizar retiros con el saldo mínimo de $500.
    /// </summary>

    public class CuentaAhorros: CuentaBancaria
    {
      
            public double TasaInteres { get; set; }

            public CuentaAhorros(string numeroCuenta, string titular, double tasaInteres)
                : base(numeroCuenta, titular)
            {
                TasaInteres = tasaInteres;
            }

            public double CalcularInteres()
            {
                double interes = Saldo * TasaInteres;
                Console.WriteLine($"El interes que generaste fue:{interes}");
                return interes;
            }

            public void Retirar(double monto)
            {
                if (monto > 0)
                {
                    if (Saldo - monto >= 500)
                    {
                        Saldo -= monto;
                        Console.WriteLine($"Retiro de {monto} realizado. Nuevo saldo: {Saldo}");
                    }
                    else
                    {
                        Console.WriteLine("No se puede retirar esa cantidad. El saldo mínimo debe ser de $500 después del retiro.");
                    }
                }
                else
                {
                    Console.WriteLine("El monto a retirar debe ser positivo y no puede exceder el saldo disponible.");
                }
            }
        }
    }

