using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;


namespace BLL
{
    public class LiquidacionModeradoraService
    {
        private LiquidacionModeradoraRepository liquidacionesRepository;
        public LiquidacionModeradoraService()
        {
            liquidacionesRepository = new LiquidacionModeradoraRepository();
        }
        public string Guardar(LiquidacionModeradora liquidacioncuotamoderadora)
        {
            try
            {
                if (liquidacionesRepository.Buscar(liquidacioncuotamoderadora.NumerodeLiquidacion) == null)
                {
                    liquidacionesRepository.Guardar(liquidacioncuotamoderadora);
                    return $"Los datos de la cuenta numero {liquidacioncuotamoderadora.NumerodeLiquidacion} han sido guardados correctamente";
                }
                return $"!! No es posible registrar la cuenta con numero {liquidacioncuotamoderadora.NumerodeLiquidacion}, porque ya se encuentra registrada!!";
            }
            catch (Exception E)
            {
                return "Error de lectura o escritura de archivos" + E.Message;
            }
        }
        public string Eliminar(int numerodeliquidacion)
        {
            try
            {
                LiquidacionModeradora liquidacioncuotamoderadora = liquidacionesRepository.Buscar(numerodeliquidacion);
                if (liquidacioncuotamoderadora != null)
                {
                    liquidacionesRepository.Eliminar(numerodeliquidacion);
                    Console.WriteLine();
                    Console.WriteLine($"!!Los datos de la cuenta numero {numerodeliquidacion} han sido eliminados correctamente!!");
                    return null;
                }
                Console.WriteLine();
                Console.WriteLine($"!!No es posible eliminar la cuenta con numero {numerodeliquidacion}, porque no se encuentra registrada!!");
                return null;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
                return null;
            }
        }
        public void Modificar(LiquidacionModeradora liquidacioncuotamoderadora)
        {
            try
            {
                liquidacionesRepository.Modificar(liquidacioncuotamoderadora);
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
            }
            
        }
        public List<LiquidacionModeradora> Consultar()
        {
            try
            {
                List<LiquidacionModeradora> liquidacionescuotasmoderadoras = liquidacionesRepository.Consultar();
                if (liquidacionescuotasmoderadoras == null)
                {
                    Console.WriteLine("!!No existen cuentas registradas!!");
                }
                return liquidacionescuotasmoderadoras;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
                return null;
            }
        }
       
        public LiquidacionModeradora Buscar(int numerodeliquidacion)
        {
            try
            {
                LiquidacionModeradora liquidacioncuotamoderadora = liquidacionesRepository.Buscar(numerodeliquidacion);
                if (liquidacioncuotamoderadora == null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"!!La cuenta numero {numerodeliquidacion} no se encuentra registrada!!");
                }
                return liquidacioncuotamoderadora;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
                return null;
            }

        }

        public void ImprimirDatos(List<LiquidacionModeradora> liquidacionesCuotasModeradoras)
        {
            
        }
    }
}


