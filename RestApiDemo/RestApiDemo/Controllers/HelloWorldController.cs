using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestApiDemo.Models;
using System.Linq;

namespace RestApiDemo.Controllers
{
    //early note:
    //class names for controller should end with Controller
    //these class names will get used "automagically" for routing

    
    [ApiController]     //this annotation is used to indicate
                        //a controller that will output data
                        //other annotations exist for "web" controllers
                        //which return the names of views


    [Route("/hello")]   //this annotation specifies the root url that all
                        //"actions" in this controller will start with

    public class HelloWorldController : ControllerBase  //ControllerBase isn't strictly
    {                                                   //needed BUT we get utility with it
        //quick and dirty collection for testing
        //dont actually do any of this here
        //this should come from the DAO
        List<Widget> _testWidgets = new List<Widget>
        {
            new Widget{ Id = 1, Name = "A" },
            new Widget{ Id = 2, Name = "B" },
            new Widget{ Id = 3, Name = "C" },
            new Widget{ Id = 4, Name = "D" },
            new Widget{ Id = 5, Name = "E" },
            new Widget{ Id = 6, Name     = "F" },
        };

        static Random _rng = new Random();

        //we'll create an "action"
        //this is a controller method with some routing

        //the alternative is supplying a route per action
        [HttpGet("random")]       //here we only respond to get requests to /hello/random
        public Widget GetRandoWidget()
        {
            return _testWidgets[_rng.Next(_testWidgets.Count)];
        }

        //with no route for the action
        //this handles all get requests to this controller
        [HttpGet] //this action will only respond to get requests
        public List<Widget> GetAllWidgets()
        {
            return _testWidgets;
        }

        //this will produce an error at runtime
        //because 1 url now matches 2 actions
        [HttpGet]
        public List<Widget> GetAllWidgetsAgain()
        {
            return _testWidgets;
        }


        [HttpGet("{id}")]
        public ActionResult GetSingle(string id)    //ActionResult is a wrapper
        {                                           //for one of many possible outputs
                                                    //data, error, page

            int parsed = -1;

            if( int.TryParse( id, out parsed))
            {
                var toReturn = _testWidgets.SingleOrDefault(w => w.Id == parsed);

                if( toReturn == null)
                {
                    //didn't find it, so we'll output a 404 error
                    return this.NotFound();
                }


                //since we're not using the generic ActionResult here
                //we have to call this function explicitly to wrap it
                return this.Accepted(toReturn);
            }
            else
            {
                //they sent an id that isn't even a number
                return this.BadRequest();
            }

        }

        [HttpGet("generic/action/result")]
        public ActionResult<Widget> GetAWidget()
        {
            //I'm allowed to do this here because the generic version of
            //ActionResult has an implict cast operator that wraps up
            //the object being returned.
            return new Widget
            {
                Id = -1,
                Name = "this widget was returned directly"
            };
        }

        [HttpGet("overloaded/{a}/between/{b}")]
        public ActionResult<int> GetANumber( int a, int b, int? c)  //a and b come from the route
        {                                                           //c is expected as a query param
            return _rng.Next(a, b + 1);                             //if it's not provided we get null
        }

      

        //typically a post request is going to come from a page
        //probably after they successfully post, we want to
        //redirect to some other GET that we support

        //typical pattern
        //1. user makes a get request to pull a page that can make post requests
        //2. user creates post request from that page
        //3. request is processed and user is either redirected OR shown results
        //      at the current url
        [HttpPost("add")]
        public ActionResult AddWidget( Widget toAdd )
        {
            //this method is fake
            //we don't have a DAO

            //for now, just redirect to the list of all widgets
            return this.LocalRedirect("/hello");
        }



    }
}
