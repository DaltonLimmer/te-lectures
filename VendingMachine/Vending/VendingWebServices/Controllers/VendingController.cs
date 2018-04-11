using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VendingService.Interfaces;
using VendingService.Mock;
using VendingService.Models;

namespace VendingWebServices.Controllers
{
    public class VendingController : ApiController
    {

        IVendingService dal;

        public VendingController()
        {
            dal = new MockVendingDBService();
        }

        public VendingController(IVendingService dal)
        {
            this.dal = dal;
        }



        /// <summary>
        /// Gets a product item from the Vending Service
        /// </summary>
        /// <param name="id">The ID of the product item</param>
        /// <returns>The product item</returns>
        [HttpGet]
        [Route("vending/product/{id}")]
        public HttpResponseMessage GetProduct(int id)
        {

            try
            {
                var item = dal.GetProductItem(id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }

        }


    }
}
