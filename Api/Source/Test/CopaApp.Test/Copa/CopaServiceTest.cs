using CopaApp.Application.Service;
using CopaApp.Domain;
using CopaApp.Domain.Repository;
using CopaApp.Domain.Seletores;
using CopaApp.Domain.Service;
using CopaApp.Test.Fake;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CopaApp.Test.Copa
{
    public class CopaServiceTest
    {
        private readonly ICopaService _copaService;
        private readonly IEquipeService _equipeService;
        private readonly IEquipeRepository _equipeRepository;

        public CopaServiceTest()
        {
            _equipeRepository = new EquipeRepositotyFake();
            _equipeService = new EquipeService(_equipeRepository);
            _copaService = new CopaService(_equipeService);
        }

        [Fact]
        public void Post_processar()
        {
            var list = _equipeRepository.GetList(new EquipeSeletor()).Take(8);
            var result = _copaService.ProcessarCopa(list);
            var resultOk = new List<string>() {"Equipe 2", "Equipe 13"};

            Assert.Equal(result.Select(x=> x.Nome), resultOk);
        }
    }
}
