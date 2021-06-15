using System;
namespace RestApiDemo.Models
{
    public class Widget
    {
        //generally going to be a good idea
        //to have setters in our models
        //BECAUSE later we'll see instances
        //where these models will have to be built
        //and populated automatically
        public int? Id { get; set; }        //ideally we want nullable primitives
                                            //so that we know when they aren't filled in
                                            //otherwise they'll get a default (non-null) value
        public string Name { get; set; }
    }
}
