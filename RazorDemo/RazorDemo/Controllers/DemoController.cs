using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RazorDemo.Models;
using RazorDemo.Services;

namespace RazorDemo.Controllers
{
    //because this is DemoController
    //all the views should live under Views/Demo
    public class DemoController : Controller        //Base Controller class
    {                                               //is configured for providing
        public DemoController()                     //razor views (different than the api controller)
        {
        }

        FakeService _service = new FakeService();

        //we'll return the ActionResult interface here
        //for Razor, mostly we're be returning View()
        //which calls the rendering engine for the associated view
        //and sends the generated html to the browser
        //public IActionResult FirstView()
        //{
        //    return View();
        //}

        //now we're recieving the id from the url (as specified in Startup.cs)
        [HttpGet]   //this action should only respond to get requests
        public IActionResult FirstView( int? id )
        {
            //we'll use the id as part of our viewmodel
            //normally we'd go ask the service for data/to perform an op
            //but for now we'll just display it

            //FirstViewViewModel vm = new FirstViewViewModel { Id = id };
            //return View(vm);


            //now we'll try grabbing a FakeModel from our service and using that
            //we'll need to change the @model declaration in our view
            //since the type of the model is changing

            if( id != null )
            {
                FakeModel model = _service.GetById(id.Value);
                return View(model);
            }


            return this.BadRequest();
            

        }

        [HttpPost]
        public IActionResult FirstView( FakeModel updatedModel)
        {
            _service.EditModel(updatedModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            IEnumerable<FakeModel> toDisplay = _service.GetAll();

            return View(toDisplay);
        }
    }
}
