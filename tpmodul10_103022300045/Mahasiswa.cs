using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace tpmodul10_103022300045.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        public static readonly List<Mahasiswa> mahasiswa = new ()
        {
            new Mahasiswa("Muhammad Zaky Amarullah", "103022300045"),
            new Mahasiswa("Ahmad Dillan", "103022300037"),
            new Mahasiswa("Muhamad Thoriq Marcello", "103022300031"),
            new Mahasiswa("Muhammad Reza Ferdinal", "103022300135"),
            new Mahasiswa("Rafa Mufid 'Aqila", "103022300061")

        };
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAllMahasiswa()
        {
            return Ok(mahasiswa);
        }
        [HttpGet("{id}")]
        public ActionResult<Mahasiswa>GetMahasiswaByIndex(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan" });
            }
            return Ok(mahasiswa[id]);
        }
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mhsBaru)
        {
            if(string.IsNullOrWhiteSpace(mhsBaru.Nama) || string.IsNullOrWhiteSpace(mhsBaru.Nim))
            {
                return BadRequest(new { message = "Nama dan NIM harus diisi" });
            }
            mahasiswa.Add(mhsBaru);
            return Ok(new { message = "Mahasiswa telah ditambahkan", id = mahasiswa.Count - 1 });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMahasiswa(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound(new { message =  "Mahasiswa tidak ditemukan" });
            }
            mahasiswa.RemoveAt(id);
            return Ok(new { message = "Mahasiswa berhasi dihapus" });
        }
    }
}
