using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvokeApiAsync.DataObjects
{
    
    //Server ve Client arasında bu data modelini kllanarak iletişim sağlayacağız.
    //Mobile Services'ın bu data modelini bir Sql objesi olark görebilmesi için bu classı EntityData Class'ından inherith ettim.
    public class User:EntityData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}