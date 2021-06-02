using System;
namespace WidgetCrud
{
    public class Widget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Widget()
        {

        }

        public Widget( Widget that)
        {
            this.Id = that.Id;
            this.Name = that.Name;
            this.Category = that.Category;
            this.Price = that.Price;
        }

    }
}
