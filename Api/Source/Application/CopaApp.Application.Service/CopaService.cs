using CopaApp.Application.Service.Validators;
using CopaApp.Domain;
using CopaApp.Domain.Service;
using System.Collections.Generic;
using System.Linq;

namespace CopaApp.Application.Service
{
    public class CopaService : ICopaService
    {
        private readonly IEquipeService _serviceEquipe;

        public CopaService
        (IEquipeService serviceEquipe)
        {
            _serviceEquipe = serviceEquipe;
        }

        public IEnumerable<EquipeDomain> ProcessarCopa(IEnumerable<EquipeDomain> equipes)
        {
            CopaValidator.CompeticaoIsValid(equipes);

            var listaOrdenada = _serviceEquipe.Ordenar(equipes).ToList();
            var resultPrimeiraFase = ProcessarPrimeiraFase(listaOrdenada);
            var resultSemiFinal = ProcessarSemiFinal(resultPrimeiraFase);

            return ProcessarFinal(resultSemiFinal);
        }

        private List<EquipeDomain> ProcessarPrimeiraFase(List<EquipeDomain> equipes)
        {
            //calculo da quantidade de partidas;
            var qtdpartidar  = equipes.Count / 2;
            var ultimaPosicao = equipes.Count - 1;
            List<EquipeDomain> ganhadores = new List<EquipeDomain>();

            for (int i=0; i < qtdpartidar; i++)
            {
                //as partidas são formadas pelos extremos da tabela
                ganhadores.Add(GetGanhadorPartida(equipes[i], equipes[ultimaPosicao - i]));
            }

            return ganhadores;
        }

        private List<EquipeDomain> ProcessarSemiFinal(List<EquipeDomain> equipes)
        {
            //calculo da quantidade de partidas;
            var qtdpartidar = equipes.Count / 2;
            var posicaoAdiversario = 1;
            List<EquipeDomain> ganhadores = new List<EquipeDomain>();

            for (int i = 0; i <= qtdpartidar; i+=2)
            {
                ganhadores.Add(GetGanhadorPartida(equipes[i], equipes[i + posicaoAdiversario]));
            }

            return ganhadores;
        }

        //return primeiro e segundo colocado ordenado
        private List<EquipeDomain> ProcessarFinal(List<EquipeDomain> equipes)
        {
            var capeao = GetGanhadorPartida(equipes.First(), equipes.Last());

            return new List<EquipeDomain>() { capeao, equipes.Where(x => x.Nome != capeao.Nome ).First()};
        }

        private EquipeDomain GetGanhadorPartida(EquipeDomain primeiraEquipe, EquipeDomain SegundaEquipe)
        {
            if (primeiraEquipe.Gols > SegundaEquipe.Gols)
                return primeiraEquipe;
            else if (primeiraEquipe.Gols < SegundaEquipe.Gols)
                return SegundaEquipe;
            else
                return ResolverEmpate(new List<EquipeDomain>() { primeiraEquipe, SegundaEquipe });
        }
        
        private EquipeDomain ResolverEmpate(List<EquipeDomain> equipesPartida)
                => _serviceEquipe.Ordenar(equipesPartida).First();
    }
}
