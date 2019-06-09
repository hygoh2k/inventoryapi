using InventoryWebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryWebapi.Controllers
{
    public class AssetController : ApiController
    {
        private AssetRepo _repo;

        public AssetController()
        {
            
        }
        // GET: api/Asset
        public IHttpActionResult Get()
        {

            return Ok(new { ResultCount=_repo.Asset.Count(), Result=_repo.Asset });
        }

        // GET: api/Asset/5
        public IHttpActionResult Get(int id)
        {
            var found = _repo.Asset.FirstOrDefault(x => x.Id == id);

            if (found == null)
                return NotFound();

            return Ok(found);
        }

        // POST: api/Asset
        public IHttpActionResult Post([FromBody]Asset value)
        {
            if(_repo.Asset.Any(x=>x.AssetCode.Equals(value.AssetCode)))
            {
                return BadRequest("Duplicate Record");
            }

            var newAsset = _repo.CreateAndAdd(value);

            return Ok(newAsset);
        }

        // PUT: api/Asset/5
        public void Put(int id, [FromBody]string AssetOwner)
        {
        }

        // DELETE: api/Asset/5
        public void Delete(int id)
        {
        }
    }
}
