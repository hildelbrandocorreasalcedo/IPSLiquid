using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class LiquidacionModeradoraSubsidiada : LiquidacionModeradora
    {
        private int variable;

        public LiquidacionModeradoraSubsidiada(int variable)
        {
            this.variable = variable;
        }

        public LiquidacionModeradoraSubsidiada(int numerodeLiquidacion, string identificacion, decimal valordeServicio)
        {
            NumerodeLiquidacion = numerodeLiquidacion;
            Identificacion = identificacion;
            ValordeServicio = valordeServicio;
        }

        public LiquidacionModeradoraSubsidiada(int numerodeLiquidacion, string identificacion, string tipodeAfilicion, decimal salariodePaciente, decimal valordeServicio) : base(numerodeLiquidacion, identificacion, "subsidiada", salariodePaciente, valordeServicio)
        {
        }

        public override void AsignarTarifayTopeMaximo()
        {
             Tarifa = (decimal)0.05;
            TopeMaximo = 200000;
        }
    }
}

