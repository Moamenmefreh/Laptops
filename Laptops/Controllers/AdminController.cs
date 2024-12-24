using AutoMapper;
using Laptops.Data;
using Laptops.DTo;
using Laptops.Model;
using Laptops.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laptops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICrud<Laptop> _Icrud;
        private readonly ICrud<Ram> _Icrud2;
        private readonly ICrud<Processor> _Icrud3;
        private readonly IMapper _Mapper;
        private readonly IRepository repository;
        public AdminController(ICrud<Laptop> icrud, ICrud<Ram> _Icrud2, ICrud<Processor> _Icrud3, IRepository _repository, IMapper Mapper)
        {
            _Icrud = icrud;
            this._Icrud3 = _Icrud3;
            repository = _repository;
            _Mapper = Mapper;
           this._Icrud2 = _Icrud2;
        }

        [HttpGet("All")]
        public async Task<IActionResult> AllLaptops() {

            //LaptopDTO dto = new LaptopDTO()
            //{
            //    laptopName = la.laptopName,
            //    Color = la.Color,
            //    Price = la.Price,
            //    Processor = la.Processor.Name,
            //    Ram = la.Ram.Capacity,
            //    Storage = la.Storage.Capacity
            //};

            var all = repository.allLaptops();

            var laptopDto=_Mapper.Map<IEnumerable<allLaptopDto>>(all);
        return Ok(laptopDto);
        }
        [HttpPost("addLaptop")]
        public async Task<IActionResult> AddLaptop([FromBody]LaptopDTO lapdto)
        {
            var item = _Icrud.Find(lapdto.Id);
            if (item == null)
            {
                var item1 = _Mapper.Map<Laptop>(lapdto);
                _Icrud.Add(item1);
                _Icrud.savechanges();
                return Ok("succefully");
            }
            else
            {
                return BadRequest("Sorry Yhis 'ID' Already Exited");
            }
        }
        [HttpPost("addStorage")]
        public async Task<IActionResult> AddStorage([FromForm]StorageDTO dto)
        {
            
            var item = _Icrud.Find(dto.storageId);
            if (item == null)
            {
              repository.Add(dto);
                return Ok("succefully");
            }
            else
            {
                return BadRequest("Sorry Yhis 'ID' Already Exited");
            }
        }
        [HttpPost("addRam")]
        public async Task<IActionResult> addRam([FromBody]ramDTO dto)
        {
            if (ModelState.IsValid)
            {
                var item = _Icrud2.Find(dto.Id);
                var item2 = _Mapper.Map<Ram>(dto);
                if (item == null)
                {
                  
                    _Icrud2.Add(item2);
                    _Icrud2.savechanges();
                    return Ok("Succefully");
                }
                else
                {
                    return BadRequest("Sorry this ID Is Already Exist");
                }
            }
            else
            {
                return BadRequest("Please Enter Model");
            }
        }
        [HttpPost("addProcessor")]
        public async Task<IActionResult> addProcessor([FromBody] processorDTO dto)
        {
            if (ModelState.IsValid)
            {
                var item = _Icrud2.Find(dto.processorId);
                var item2 = _Mapper.Map<Processor>(dto);
                if (item == null)
                {

                    _Icrud3.Add(item2);
                    _Icrud3.savechanges();
                    return Ok("Succefully");
                }
                else
                {
                    return BadRequest("Sorry this ID Is Already Exist");
                }
            }
            else { return BadRequest("Please Enter Model"); }
        }
        [HttpGet("Search By UserId")]
        public async Task<IActionResult> searchbyuseId(int id)
        {
            var mm = repository.SearchbyuserId(id);
            if (mm != null)
            {
                var item2 = _Mapper.Map<userDTO>(mm);
                return Ok(item2);
            }
            else return BadRequest("This User is Not Found");
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> update(int id,[FromBody] LaptopDTO hhh)
        {
            var item = _Icrud.Find(id);
            if (item != null)
            {
                if (ModelState.IsValid)
                {
                    item.laptopName = hhh.laptopName;
                    item.Price = hhh.Price;
                    item.Color = hhh.Color;
                    _Icrud.Update(item);
                    _Icrud.savechanges();
                    return Ok("succefully");
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest("Sorry This Product Not Found");

            }
        }
    }
}
