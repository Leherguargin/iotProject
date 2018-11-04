using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenerowanieJsona.Controllers
{
    [Produces("application/json")]
    [Route("api/Measurements")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private static List<Models.Measurements> lista = new List<Models.Measurements>(new[]{
                new Models.Measurements(1,1,433.34,DateTime.Now),
                new Models.Measurements(2,2,54.7,DateTime.Now),
            });
        [HttpGet]
        public List<Models.Measurements> Get()
        {
            return lista;
        }
        [HttpGet("{SensorID}")]
        public Models.Measurements Get(int id)
        {
            return lista.SingleOrDefault(lista => lista.SensorID == id);
        }
    }
}