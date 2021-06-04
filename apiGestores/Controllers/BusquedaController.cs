using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiGestores.Context;
using apiGestores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiGestores.Controllers
{
    [Route("api/[controller]")]
    public class BusquedaController : Controller
    {
        private readonly AppDbContext context;
        public BusquedaController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.registros_bd.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="GetBusqueda")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.registros_bd.FirstOrDefault(g => g.id == id);
                return Ok(gestor);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Busqueda_Bd busqueda)
        {
            try
            {
                context.registros_bd.Add(busqueda);
                context.SaveChanges();
                return CreatedAtRoute("GetBusqueda", new { id = busqueda.id }, busqueda);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }  
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Busqueda_Bd busqueda)
        {
            try
            {
                if (busqueda.id == id)
                {
                    context.Entry(busqueda).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = busqueda .id }, busqueda);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.registros_bd.FirstOrDefault(g => g.id == id);
                if (gestor != null)
                {
                    context.registros_bd.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
