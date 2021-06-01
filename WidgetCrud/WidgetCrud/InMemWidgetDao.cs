using System;
using System.Collections.Generic;

namespace WidgetCrud
{
    public class InMemWidgetDao
    {
        List<Widget> _allWidgets = new List<Widget>();

        public InMemWidgetDao()
        {
        }


        public int AddWidget( Widget toAdd)
        {
            throw new NotImplementedException();
        }

        public void RemoveWidgetById( int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateWidget( Widget updated)
        {
            throw new NotImplementedException();
        }

        public Widget GetWidgetById( )
    }
}
