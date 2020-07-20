using CopaApp.Application.Service;
using CopaApp.Domain.Repository;
using CopaApp.Domain.Seletores;
using CopaApp.Domain.Service;
using CopaApp.Presentation.UI.Controllers;
using CopaApp.Test.Fake;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace CopaApp.Test.Copa
{
    public class CopaControllerTest
    {
        private readonly CopaController _controller;
        private readonly ICopaService _copaService;
        private readonly IEquipeService _equipeService;
        private readonly IEquipeRepository _equipeRepository;

        public CopaControllerTest()
        {
            _equipeRepository = new EquipeRepositotyFake();
            _equipeService = new EquipeService(_equipeRepository);
            _copaService = new CopaService(_equipeService);
            _controller = new CopaController(_copaService);
        }

        [Fact]
        public void Post_processar()
        {
            var list = _equipeRepository.GetList(new EquipeSeletor()).Take(8);
            var okResult = _controller.Processar(list);
           
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
