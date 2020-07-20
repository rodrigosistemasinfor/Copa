using CopaApp.Domain;
using CopaApp.Domain.Service;
using CopaApp.Presentation.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaApp.Presentation.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopaController : ControllerBase
    {
        private readonly ICopaService _service;

        public CopaController(ICopaService service)
        {
            _service = service;
        }


        [HttpPost("Processar")]
        [ProducesResponseType(typeof(IEnumerable<EquipeDomain>), 200)]
        public ActionResult Processar([FromBody] IEnumerable<EquipeDomain> equipes)
        {
            try
            {
                var result = _service.ProcessarCopa(equipes);

                return Ok(new ResponseViewModel
                {
                    Data = result,
                    Count = result.Count()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
