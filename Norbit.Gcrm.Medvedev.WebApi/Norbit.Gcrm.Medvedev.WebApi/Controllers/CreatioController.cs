using Norbit.Gcrm.Medvedev.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Norbit.Gcrm.Medvedev.WebApi.Controllers
{
    public class CreatioController : ApiController
    {

        static readonly CreatioModel creatioModel = new CreatioModel();

        // GET: api/Creatio
        public IEnumerable<CreatioObject> Get()
        {
            return creatioModel.GetAllRecords();
        }

        // GET: api/Creatio/?index=5
        public CreatioObject Get(Guid id)
        {
            try
            {
                return creatioModel.GetRecord(id);
            }
            catch(ArgumentOutOfRangeException)
            {
                return null;
            }

        }

        // POST: api/Creatio
        public HttpStatusCode Post([FromBody]List<CreatioObject> creatioObjects)
        {
            try
            {
                creatioModel.AddRecords(creatioObjects);
                return HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return HttpStatusCode.BadRequest;
            }
        }


        // PUT: api/Creatio/?id=c7f4ebfd-0971-425d-8ca0-994c3d137b38
        public HttpStatusCode Put(Guid id, [FromBody]CreatioObject creatioObject)
        {
            try
            {

                creatioModel.UpdateRecord(id, creatioObject);
                return HttpStatusCode.OK;
            }
            catch(Exception)
            {
                return HttpStatusCode.BadRequest;
            }
        }

        // PATCH// PATCH api/Creatio/?id=c7f4ebfd-0971-425d-8ca0-994c3d137b38
        public HttpStatusCode Patch(Guid id , [FromBody] CreatioObject creatioObject)
        {
            try
            {
                creatioModel.UpdateRows(id, creatioObject);
                return HttpStatusCode.OK;
            }
            catch(Exception)
            {
                return HttpStatusCode.BadRequest;
            }
        }

        // DELETE: api/Creatio/5
        public HttpStatusCode Delete(int index)
        {
            try 
            {
                creatioModel.DeleteRecord(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                return HttpStatusCode.NotFound;
            }
            return HttpStatusCode.OK;
        }
    }
}
