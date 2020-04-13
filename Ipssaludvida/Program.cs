using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;
using System.IO;

namespace Ipssaludvida
{
    class Program
    {
        public static LiquidacionModeradoraService liquidacionCuotaModeradoraService = new LiquidacionModeradoraService();
        static string mensaje;
        

        static void Main(string[] args)
        {
            DesplegarMenuPrincipal();
        }

        public static void DesplegarMenuPrincipal()
        {
            int opcion = 5;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("*************LA IPS MAS SALUD Y VIDA***************");
                Console.WriteLine();
                Console.WriteLine("MENU DE LA IPS: ");
                Console.WriteLine();
                Console.WriteLine("1. Registrar Liquidación");
                Console.WriteLine("2. Eliminar Liquidación");
                Console.WriteLine("3. Ver si la Liquidación Exite");
                Console.WriteLine("4. Modificar valor del servicio de una liquidacion");
                Console.WriteLine("5. Salir de la aplicacion\n");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Digite su opcion: ");
                Console.WriteLine();
                opcion = ValidarLimitesNumericos("!!Error!!, debe digitar del 1 al 5 ", 0, 5);
                EjecutarOpcion(opcion);
            } while (opcion != 5);
        }
        public static void EjecutarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    RegistrarLiquidacion();
                    break;
                case 2:
                    EliminarLiquidacion();
                    break;
                case 3:
                    BuscarLiquidacion();
                    break;
                case 4:
                    ModificarServicio();
                    break;
                case 5:
                    break;
            }
        }
        public static void RegistrarLiquidacion()
        {
            string respuesta;
            do
            {
                Console.Clear();
                Console.WriteLine();
                LiquidacionModeradora liquidacionCuotaModeradora = PedirDatos();
                liquidacionCuotaModeradora.AsignarTarifayTopeMaximo();
                liquidacionCuotaModeradora.CalcularCuota();
                mensaje = liquidacionCuotaModeradoraService.Guardar(liquidacionCuotaModeradora);
                Console.WriteLine($"{mensaje}");
                Console.WriteLine();
                Console.WriteLine("El valor de la cuota moderadora es: {0}", liquidacionCuotaModeradora.CuotaModeradora);
                Console.WriteLine("¿Desea registrar otra liquidación? S/N");
                respuesta = ValidarLimitesAlfabeticos("!!Error!!, debe ingresar S o N", "S", "N");
                Console.WriteLine();
            } while (respuesta == "S");
        }
        public static LiquidacionModeradora PedirDatos()
        {
            LiquidacionModeradora liquidacionModeradora;
            Console.WriteLine("*************LA IPS MAS SALUD Y VIDA***************");
            Console.WriteLine();
            Console.WriteLine("Escoja la afilicion  ");
            Console.WriteLine("Regimen Contributivo (C) o Regimen Subsidiado (S): ");
            string TipodeAfiliacion = ValidarLimitesAlfabeticos("!!Error!!,Debe digitar C o S", "C", "S");
            Console.WriteLine();
            Console.WriteLine("Digite el numero de liquidación:");
            int NumerodeLiquidacion = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Digite el numero de identificacion del paciente:");
            string Identificacion = Console.ReadLine();
            decimal SalariodePaciente;
            Console.WriteLine();
            Console.WriteLine("Digite el valor del servicio de hospitalización:");
            decimal ValordeServicio = decimal.Parse(Console.ReadLine());
            if (TipodeAfiliacion == "C")
            {
                Console.WriteLine();
                Console.WriteLine("Digite el valor del salario devengado por el paciente:");
                SalariodePaciente = decimal.Parse(Console.ReadLine());
                liquidacionModeradora =  new LiquidacionModeradoraContributiva(NumerodeLiquidacion, Identificacion, SalariodePaciente, ValordeServicio);
            }
            else
            {
                liquidacionModeradora = new LiquidacionModeradoraSubsidiada (NumerodeLiquidacion, Identificacion, ValordeServicio);
            }
            return liquidacionModeradora;
        }
        public static void EliminarLiquidacion()
        {
            string respuesta;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("*************LA IPS MAS SALUD Y VIDA***************");
                Console.WriteLine();
                Console.WriteLine("Digite el numero de la liquidación a ELIMINAR:");
                int NumerodeLiquidacion = int.Parse(Console.ReadLine());
                mensaje = liquidacionCuotaModeradoraService.Eliminar(NumerodeLiquidacion);
                Console.WriteLine($"{mensaje}");
                Console.WriteLine("¿Desea eliminar otra liquidación? S/N");
                respuesta = ValidarLimitesAlfabeticos("!!Error!!, debe ingresar S o N", "S", "N");
                Console.WriteLine();
            } while (respuesta == "S");
        }
        public static void BuscarLiquidacion()
        {
            string respuesta;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("*************LA IPS MAS SALUD Y VIDA***************");
                Console.WriteLine();
                List<LiquidacionModeradora> liquidacionesCuotasModeradoras = new List<LiquidacionModeradora>();
                Console.WriteLine("Ingrese el numero de la liquidación a buscar:");
                int NumerodeLiquidacion = int.Parse(Console.ReadLine());
                LiquidacionModeradora liquidacionCuotaModeradora = liquidacionCuotaModeradoraService.Buscar(NumerodeLiquidacion);
                if (liquidacionCuotaModeradora != null)
                {
                    Console.WriteLine("Liquidación Existente\n\n");
                    Console.WriteLine();
                }
               
                Console.WriteLine("¿Desea buscar otra liquidación? S/N");
                respuesta = ValidarLimitesAlfabeticos("!!Error!!, debe digitar S o N", "S", "N");
                Console.WriteLine();
            } while (respuesta == "S");
        }
        public static void ModificarServicio()
        {
            string respuesta;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("*************LA IPS MAS SALUD Y VIDA***************");
                Console.WriteLine();
                Console.WriteLine("Digitar el numero de la liquidacion a MODIFICAR:");
                int NumerodeLiquidacion = int.Parse(Console.ReadLine());
                LiquidacionModeradora liquidacioncuotamoderadora = liquidacionCuotaModeradoraService.Buscar(NumerodeLiquidacion);
                if (liquidacioncuotamoderadora != null)
                {
                    Console.WriteLine("Digitar el nuevo valor del servicio de hospitalizacion:");
                    liquidacioncuotamoderadora.ValordeServicio = decimal.Parse(Console.ReadLine());
                    liquidacioncuotamoderadora.CalcularCuota();

                    Console.WriteLine();
                    Console.WriteLine($"{mensaje}");
                    Console.WriteLine("El nuevo valor de la cuota moderadora es: {0}", liquidacioncuotamoderadora.CuotaModeradora);
                }
                Console.WriteLine("¿Desea modificar otra liquidación? S/N");
                respuesta = ValidarLimitesAlfabeticos("!!Error!!, debe digitar S o N", "S", "N");
                Console.WriteLine();
            } while (respuesta == "S");
        }
       
        public static int ValidarLimitesNumericos(string mensaje, int limiteInferior, int limiteSuperior)
        {
            int opcion;
            do
            {
                opcion = int.Parse(Console.ReadLine());
                if (opcion < limiteInferior || opcion > limiteSuperior)
                {
                    Console.WriteLine(mensaje);
                    Console.ReadKey();
                }
            } while (opcion < limiteInferior && opcion > limiteSuperior);
            return opcion;
        }
        public static string ValidarLimitesAlfabeticos(string mensaje, string Letra1, string Letra2)
        {
            string opcion;
            do
            {
                opcion = Console.ReadLine().ToUpper();
                if (opcion != Letra1 && opcion != Letra2)
                {
                    Console.WriteLine(mensaje + "\n");
                    Console.ReadKey();
                }
            } while (opcion == Letra1 && opcion == Letra2);
            return opcion;
        }
    }
}
