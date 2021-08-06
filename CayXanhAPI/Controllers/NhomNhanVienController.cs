using CayXanhAPI.BAL.Interfaces;
using CayXanhAPI.BAL.Repositories;
using CayXanhAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CayXanhAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomNhanVienController : ControllerBase
    {
        private INhomNhanVienRepository repository;
        public NhomNhanVienController()
        {
            repository = new NhomNhanVienRepository();
        }
    
        [HttpGet]
        [Route("/Api/NhomNhanVien")]
        // GET: api/<NhomNhanVienController>
        [HttpGet]
        public async Task<IEnumerable<QLCX_NhomNhanVien>> Gets()
        {
           var data = await repository.GetAllNhomNhanVien();
            return data;
        }

        //// GET api/<NhomNhanVienController>/5
        //[HttpGet("{id}")]
        //[Route("/Api/NhomNhanVien/{id}")]
        //public async Task<QLCX_NhomNhanVien> Get(int ID)
        //{
        //    var data = await repository.Get(ID);
        //    return data;
        //}
        // GET api/<NhomNhanVienController>/5
        [HttpGet("{id}")]
        public async Task< QLCX_NhomNhanVien> Get(int id)
        {
            var data = await repository.Get(id);
               return  data;
        }


       // POST api/<NhomNhanVienController>
        [HttpPost]
        [Route("/Api/NhomNhanVien")]
        public async Task<QLCX_NhomNhanVien> Post([FromBody] QLCX_NhomNhanVien nhom)
        {
            await repository.Insert(nhom);
            var lst = await repository.GetAllNhomNhanVien();
            var re = lst.OrderByDescending(i => i.ID).FirstOrDefault();
            return re;
        }
        [HttpPut]
        public async Task<QLCX_NhomNhanVien> Edit([FromBody] QLCX_NhomNhanVien nhom)
        {
            await repository.Edit(nhom);
            return await repository.Get(nhom.ID);
        }
        // DELETE api/<NhomNhanVienController>/5
        [HttpDelete("{id}")]
        //[Route("/Api/NhomNhanVien/{id}")]
        public async Task<string> Delete(int id)
        {
           return await repository.Delete(id);
            
        }

        [HttpGet]
        [Route("gettiep/{id}/{name}")]
        public string dkmdkm(string id, string name)
        {
            return $"{id}: {name}";
        }

        [HttpGet]
        [Route("getchovui")]
        public async Task<IActionResult> getget()
        {
            var lstResult = await repository.GetAllNhanVien();
            return Ok(new JsonResult(lstResult));
        }
    }
}
