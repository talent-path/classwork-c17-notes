using System;
using System.Linq;
using System.Collections.Generic;

namespace WidgetSales
{
    public class InMemInventoryDao : IInventoryDao
    {
        List<WidgetInventory> _allInventories = new List<WidgetInventory>();

        public InMemInventoryDao()
        {
        }

        public int Add(WidgetInventory toAdd)
        {
            toAdd.Id = _allInventories.Count + 1;
            _allInventories.Add(toAdd);

            return toAdd.Id;
        }

        public WidgetInventory GetByName(string name)
        {
            return _allInventories.Single(w => w.Name == name);
        }
    }
}
