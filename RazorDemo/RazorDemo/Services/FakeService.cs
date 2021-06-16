using System;
using System.Collections.Generic;
using System.Linq;
using RazorDemo.Models;

namespace RazorDemo.Services
{
    public class FakeService
    {
        //since this service isn't real, we're skipping making a dao
        //for now.  we'll just use this list in the meantime
        static List<FakeModel> _allModels = new List<FakeModel>
        {
            new FakeModel{ Id = 1, Name = "A" },
            new FakeModel{ Id = 2, Name = "B" },
            new FakeModel{ Id = 3, Name = "C" },
            new FakeModel{ Id = 4, Name = "D" },
            new FakeModel{ Id = 5, Name = "E" },

        };

        public FakeModel GetById( int id)
        {
            return _allModels.Single(m => m.Id == id);
        }

        internal void EditModel(FakeModel edited )
        {
            _allModels = _allModels.Select(m => m.Id == edited.Id ? edited : m).ToList();
        }

        internal IEnumerable<FakeModel> GetAll()
        {
            return _allModels;
        }
    }
}
