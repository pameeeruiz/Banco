using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    internal class Program
    {
        static void Main(string[] args)
        {
          CuentaAhorros cuentaAhorros = new CuentaAhorros("123456789", "Juan Perez", 0.05);
            cuentaAhorros.Depositar(1000);
            Console.WriteLine("------CUENTA DE AHORROS------");
            cuentaAhorros.MostrarInformacion();
            cuentaAhorros.CalcularInteres();
            cuentaAhorros.Retirar(200);
            cuentaAhorros.MostrarInformacion();
            Console.WriteLine();
            Console.WriteLine("------CUENTA CORRIENTE------");
            CuentaCorriente cuentaCorriente = new CuentaCorriente("987654321", "Maria Lopez", 20, 500);
            cuentaCorriente.Depositar(500);
            cuentaCorriente.MostrarInformacion();
            cuentaCorriente.Retirar(600);
            cuentaCorriente.MostrarInformacion();
            Console.WriteLine();
            Console.WriteLine(" -------CUENTA NOMINA------- ");
            CuentaNomina cuentaNomina = new CuentaNomina("555555555", "Carlos Gomez", "Empresa XYZ");
            cuentaNomina.Depositar(2000);
            cuentaNomina.MostrarInformacion();
            cuentaNomina.CalcularIntereses(2000);
            cuentaNomina.Retirar(1500);
            cuentaNomina.MostrarInformacion();
            Console.ReadLine();
        }

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

        public class CuentaAhorros : CuentaBancaria
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
                if (monto > 0 )
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

        public class CuentaCorriente : CuentaBancaria
        {
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
                Console.WriteLine($"El interes que generaste fue:{interes}");
                return interes;
            }
            public void Retirar(double monto)
            {
                Console.WriteLine("Cual es la cantidad a retirar?");
                monto = Convert.ToDouble(Console.ReadLine());
                if (monto > 0 && monto <= Saldo)
                {
                    Saldo -= monto;
                    Console.WriteLine($"Retiro de {monto} realizado. Nuevo saldo: {Saldo}");
                }
                else
                {
                    Console.WriteLine("El monto a retirar debe ser positivo y no puede exceder el saldo disponible.");
                }
            }
        }
    }
}
