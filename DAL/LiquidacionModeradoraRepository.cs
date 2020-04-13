using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using System.IO;

namespace DAL
{
    public class LiquidacionModeradoraRepository
    {
       
        List<LiquidacionModeradora> liquidacionesCuotasModeradoras = new List<LiquidacionModeradora>();
        public List<LiquidacionModeradora> LiquidacionCuotaModeradoras { get; set; }

        public void Guardar(LiquidacionModeradora liquidacioncuotamoderadora)

        {
            FileStream fileStream = new FileStream(@"C:\Users\Brayan\Documents\Visual Studio 2015\Projects\IPSLiquidacion\Ipssaludvida\bin\Debug\LiquidacionesModeradoras.txt", FileMode.Append);
            StreamWriter stream = new StreamWriter(fileStream);
            stream.WriteLine(liquidacioncuotamoderadora.ToString());
            stream.Close();
            fileStream.Close();

        }

        public List <LiquidacionModeradora>  Consultar()
        {
            liquidacionesCuotasModeradoras.Clear();
            FileStream filestream = new FileStream(@"C:\Users\Brayan\Documents\Visual Studio 2015\Projects\IPSLiquidacion\Ipssaludvida\bin\Debug\LiquidacionesModeradoras.txt", FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(filestream);
            string linea = string.Empty;

            while ((linea = reader.ReadLine())!= null)
            {

                LiquidacionModeradora liquidacioncuotamoderadora = MapearLiquidacionCuotaModeradora(linea);
                liquidacionesCuotasModeradoras.Add(liquidacioncuotamoderadora);
}
            filestream.Close();
            reader.Close();
            return liquidacionesCuotasModeradoras;



        }

        public LiquidacionModeradora MapearLiquidacionCuotaModeradora(string linea)
        {
            string[] datos = linea.Split(';');
            if (datos[1] == "contributiva")  
            {
                LiquidacionModeradora liquidacioncuotamoderadoracontributiva = new LiquidacionModeradoraContributiva(0);

                liquidacioncuotamoderadoracontributiva.NumerodeLiquidacion = int.Parse(datos[0]);
                liquidacioncuotamoderadoracontributiva.TipodeAfiliacion = datos[1];
                liquidacioncuotamoderadoracontributiva.Identificacion = datos[2];
                liquidacioncuotamoderadoracontributiva.SalariodePaciente = Decimal.Parse(datos[3]);
                liquidacioncuotamoderadoracontributiva.ValordeServicio = decimal.Parse(datos[4]);
                liquidacioncuotamoderadoracontributiva.CuotaModeradora = decimal.Parse(datos[5]);
                return liquidacioncuotamoderadoracontributiva;
            }
    
         else{
                LiquidacionModeradora liquidacioncuotamoderadorasubsidiada = new LiquidacionModeradoraSubsidiada(0);
                liquidacioncuotamoderadorasubsidiada.NumerodeLiquidacion = int.Parse(datos[0]);
                liquidacioncuotamoderadorasubsidiada.TipodeAfiliacion = datos[1];
                liquidacioncuotamoderadorasubsidiada.Identificacion = datos[2];
                liquidacioncuotamoderadorasubsidiada.ValordeServicio = decimal.Parse(datos[3]);
                liquidacioncuotamoderadorasubsidiada.CuotaModeradora = decimal.Parse(datos[4]);
                return liquidacioncuotamoderadorasubsidiada;

            }

        }
        public void Eliminar(int Numerodeliquidacion)
        {
            liquidacionesCuotasModeradoras.Clear();
            liquidacionesCuotasModeradoras = Consultar();
            FileStream fileStream = new FileStream(@"C:\Users\Brayan\Documents\Visual Studio 2015\Projects\IPSLiquidacion\Ipssaludvida\bin\Debug\LiquidacionesModeradoras.txt", FileMode.Create);
            fileStream.Close();
            foreach (var item in liquidacionesCuotasModeradoras)
            {
                if (item.NumerodeLiquidacion != Numerodeliquidacion)
                {
                    Guardar(item);
                }
            }

        }

        public LiquidacionModeradora Buscar(int numerodeliquidacion)
        {
            liquidacionesCuotasModeradoras.Clear();
            liquidacionesCuotasModeradoras = Consultar();
            
            foreach (var item in liquidacionesCuotasModeradoras)
            {
                if (item.NumerodeLiquidacion.Equals(numerodeliquidacion))
                {
                    return item;
                }
            }
            return null;
        }

        public void Modificar(LiquidacionModeradora liquidacioncuotamoderadora)
        {
           liquidacionesCuotasModeradoras.Clear();
           liquidacionesCuotasModeradoras = Consultar();
            FileStream fileStream = new FileStream(@"C:\Users\Brayan\Documents\Visual Studio 2015\Projects\IPSLiquidacion\Ipssaludvida\bin\Debug\LiquidacionesModeradoras.txt", FileMode.Create);
            fileStream.Close();
            foreach (var item in liquidacionesCuotasModeradoras)
            {
                if (item.NumerodeLiquidacion!= liquidacioncuotamoderadora.NumerodeLiquidacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(liquidacioncuotamoderadora);
                }
            }

        }

    }
}
