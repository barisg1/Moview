using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moview.Models
{
    public class Users
    {

        [Key]
        public int UserID { get; set; }


            
            public string Username { get; set; }

            public string FirstName { get; set; }
            public string LastName { get; set; }
        
            public string Email { get; set; }
         
            public string Password { get; set; }
           


      
        }
    }

