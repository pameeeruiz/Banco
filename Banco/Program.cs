using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Clases;

namespace Banco
{
    internal class Program
    {
        /// <summary>
        /// EPGR 26.02.2026
        /// Programa principal para gestionar cuentas bancarias.
        /// </summary>
        /// <param name="args"></param>


        static void Main(string[] args)
        {
            // se crean instancias de cada tipo de cuenta y se realizan operaciones de depósito, retiro e interés.

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
    }
}
