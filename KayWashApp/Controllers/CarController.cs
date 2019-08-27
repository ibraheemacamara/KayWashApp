using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KayWashApp.DataBase.Repositories;
using KayWashApp.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KayWashApp.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {

        private readonly CarRepository _carRepository;

        public CarController(CarRepository repo)
        {
            _carRepository = repo;
        }

        [HttpGet("[action]")]
        public IEnumerable<CarDto> List()
        {
            return  _carRepository.GetAll();
        }
    }
}
