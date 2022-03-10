using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWO.Models;
using Xamarin.Forms;

[assembly:Dependency(typeof(LoggedInUserModel))]
namespace TestWO.Models
{
    public class LoggedInUserModel : ILoggedInUserModel
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
