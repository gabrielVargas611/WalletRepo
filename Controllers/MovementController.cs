using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletAPI.Contract;
using WalletAPI.Models;
using WalletAPI.Services;
using WalletAPI.Settings;   

namespace WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase 
    {
        private readonly IMovementService _movementService;
        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        // GET: api/Movement
        [HttpGet]
        public ActionResult<List<Movement>> Get() => _movementService.Get();

        // GET: api/Movement/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Movement> Get(int id)
        {
            var movement = _movementService.Get(id);
            if(movement == null)
            {
                return NotFound();
            }
            return movement;
        }

        // POST: api/Movement
        [HttpPost]
        public ActionResult<Movement> Create([FromBody] Movement movement)
        {
            var list = new List<Movement>();
            var strings = new List<string>();

            _movementService.Create(movement);

            return CreatedAtRoute("GetMovement", new { id = movement.Id.ToString() }, movement);
        }

        // PUT: api/Movement/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Movement movementp)
        {
            var movement = _movementService.Get(id);
            if (movement == null)
                return NotFound();

            _movementService.Upgrade(id, movementp);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movement = _movementService.Get(id);
            if (movement == null)
                return NotFound();

            _movementService.Remove(movement.Id);

            return NoContent();
        }
    }
    public class Test<T>
    {
        public Test()
        {

        }
    }

    public interface IVehicle
    {
        public Vehicle GetVehicle();
    }

    public class Vehicle : AutoMotor
    {
        protected override string StartEngine()
        {
            var result = base.StartEngine();
            return "Vehicule" + result;
        }
    }

    public class Moto : AutoMotor
    {
        protected override string StartEngine()
        {
            var result = base.StartEngine();
            return "Moto" + result;
        }
    }

    internal class Chasis : Vehicle 
    {
        protected override string StartEngine()
        {
            return base.StartEngine();
        }
    }

    public class AutoMotor
    {
        protected virtual string StartEngine()
        {
            return "Started";
        }
    }

    public class VehicleService : IVehicle
    {
        public Vehicle GetVehicle()
        {
            return new Vehicle();
        }
    }

    public class VehiculeRest
    {
        private readonly IVehicle _vehicleService;
        public VehiculeRest(IVehicle vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public object Get()
        {
            return _vehicleService.GetVehicle();
        }
    }
}
