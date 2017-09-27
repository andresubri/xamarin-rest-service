using RestServicesTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestServicesTest.Helpers
{
    interface IRestService
    {
        Task<List<Post>> GetPostList();
    }
}
