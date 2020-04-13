﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class LiquidacionModeradoraContributiva : LiquidacionModeradora
    {
        private int variable;

        public LiquidacionModeradoraContributiva(int variable)
        {
            this.variable = variable;
        }

        public LiquidacionModeradoraContributiva(int numerodeLiquidacion, string identificacion, decimal salariodePaciente, decimal valordeServicio)
        {
            NumerodeLiquidacion = numerodeLiquidacion;
            Identificacion = identificacion;
            SalariodePaciente = salariodePaciente;
            ValordeServicio = valordeServicio;
        }

        public LiquidacionModeradoraContributiva(int numerodeLiquidacion, string identificacion, string tipodeAfilicion, decimal salariodePaciente, decimal valordeServicio) : base(numerodeLiquidacion, identificacion,"contributiva", salariodePaciente, valordeServicio)
        {
        }

        public override void AsignarTarifayTopeMaximo()
        {
            if (SalariodePaciente < SalarioMinimo * 2)
            {
                Tarifa = (decimal)0.15;
                TopeMaximo = 250000;
            }
            else if (SalariodePaciente > SalarioMinimo * 5)
            {
                Tarifa = (decimal)0.25;
                TopeMaximo = 1500000;
            }
            else
            {
                Tarifa = (decimal)0.20;
                TopeMaximo = 900000;
            }
        }
    }
}
