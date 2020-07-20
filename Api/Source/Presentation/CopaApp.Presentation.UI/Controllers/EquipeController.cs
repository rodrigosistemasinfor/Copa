using CopaApp.Domain;
using CopaApp.Domain.Seletores;
using CopaApp.Domain.Service;
using CopaApp.Presentation.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CopaApp.Presentation.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeService _service;

        public EquipeController(IEquipeService service)
        {
            _service = service;
        }


        [HttpPost("list")]
        [ProducesResponseType(typeof(IEnumerable<EquipeDomain>), 200)]
        public ActionResult List([FromBody] EquipeSeletor seletor)
        {
            try
            {
                if (seletor == null)
                    throw new Exception("Filtro inválido");

                return Ok(new ResponseViewModel
                {
                    Data = _service.GetList(seletor),
                    Count = _service.Count(seletor)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
