using Microsoft.AspNetCore.Mvc;
using API01.Models;
using System.Globalization;
using API01.Filters;

namespace API01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ILogger _logger;
        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }
        private static List<Car> cars = new List<Car>()
        {
            new Car(){Id = 1, Model = "240i", Name ="BMW", productionDate = DateTime.Parse("2010-04-10")},
            new Car(){Id = 3, Model = "IX35", Name ="Hyundai", productionDate = DateTime.Parse("2015-12-13")},
            new Car(){Id = 4, Model = "Cerato", Name ="KIA", productionDate = DateTime.Parse("2020-05-07")},
            new Car(){Id = 2, Model = "740i", Name ="BMW", productionDate = DateTime.Parse("2014-05-02")},
            new Car(){Id = 5, Model = "Super", Name ="SCODA", productionDate = DateTime.Parse("2012-04-06")}
        };
        [HttpGet]
        [Route("getall")]
        public ActionResult GetAll()
        {
            _logger.LogInformation("All cars retrieved Successfully!");
            return Ok(cars);
        }
            

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetById(int id)
        {
            Car selectedCar = cars.FirstOrDefault(car => car.Id == id);
            if (selectedCar == null)
                return NotFound();
            return Ok(selectedCar);
        }
           

        [HttpPost]
        public ActionResult Add_v1(Car car)
        {
            car.Id = cars.Count() +1;
            car.Type = "Gas";
            cars.Add(car);

            return CreatedAtAction(actionName: nameof(GetById),
                routeValues: new { car.Id },
                new GeneralResponse { Message = "A new Car created successfully!" });
        }

        [HttpPost]
        [Route("v2")]
        [ValidateTypeOfCar]
        public ActionResult Add_v2(Car car)
        {
            car.Id = cars.Count() + 1;
            cars.Add(car);

            return CreatedAtAction(actionName: nameof(GetById),
                routeValues: new { car.Id },
                new GeneralResponse { Message = "A new Car created successfully!" });
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public void Update(Car car, int id)
        {
            Car editedCar = cars.FirstOrDefault(car => car.Id == id);
            if(editedCar != null)
            {
                editedCar.Model = car.Model;
                editedCar.Name = car.Name;
                editedCar.productionDate = car.productionDate;
            }
        }
        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            Car deletedCar = cars.FirstOrDefault(car => car.Id == id);
            if(deletedCar != null)
            {
                cars.Remove(deletedCar);
                return NoContent();
            }

            return NotFound();
        }
    }
}
