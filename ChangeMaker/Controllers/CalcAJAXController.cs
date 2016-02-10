using ChangeMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChangeMaker.Controllers;


namespace ChangeMaker.Controllers
{
    public class CalcAJAXController : Controller
    {

     




        //
        // POST: calc
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Calc(Transaction transaction)
        {
            

            if (ModelState.IsValid)
            {
                
                transaction.setNumericValues();

                transaction.calcChange();
                Response.StatusCode = 202;


               // transactions.Add(transaction);
                return Json(transaction);

            }
            else
            {
                Response.StatusCode = 400;

                // transactions.Add(transaction);
                
                
                return Json(transaction);


            }

        }
        
    }
}

