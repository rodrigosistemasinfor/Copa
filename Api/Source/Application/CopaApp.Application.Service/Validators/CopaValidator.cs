using CopaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaApp.Application.Service.Validators
{
    public static class CopaValidator
    {
       public static bool CompeticaoIsValid(IEnumerable<EquipeDomain> equipesSelecionadas)
       {
            int qtdTimes = 8;

            if (equipesSelecionadas == null)
                 throw new Exception("A competição não pode ser realizada sem equipes");
            if(equipesSelecionadas.Count() != qtdTimes)
                throw new Exception($"A competição precisa de {qtdTimes} para ser realizada");
            if (equipesSelecionadas.GroupBy(x=> x.Nome.ToUpper()).Select(g => g.Count()).Any(x=> x > 1))
                throw new Exception($"Não é permitido duas ou mais equipes com o mesmo nome");
            //mais validações...

            return true;
       }
    }
}
