using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using InvokeApiAsync.DataObjects;
using InvokeApiAsync.Models;

namespace InvokeApiAsync.Controllers
{
    public class UserController : ApiController
    {

        public ApiServices Services { get; set; }
        public MobileServiceContext ctx = new MobileServiceContext(); /*Veritanabı modellenmiş hali*/

        // GET api/User
        //public string Get()
        //{
        //    //Services.Log.Info("Hello from custom controller!");
        //    //return "Hello";    


        //}
        public string PostUser(User EklenecekUser)
        {
            EklenecekUser.Id = Guid.NewGuid().ToString(); /*Hata aldığında gelen kullanıcın id'sini değiştirmek için'*/

            string nRet = string.Empty;
            //ctx.Users.Contains
            if(ctx.Users.Where(x => x.Username == EklenecekUser.Username).Count() > 0)
            {
                //Kullanıcı eklenmisse.
                nRet = EklenecekUser.Username + "Veritabanında zaten kayıtlı!";
            }
            else
            {
                //Kullanıcı Yoksa
                ctx.Users.Add(EklenecekUser); /*ctx = Context*/
                ctx.SaveChanges();
                //ctx.SaveChangesAsync; 
                nRet = EklenecekUser.Username + "Veritabanına Kayıt Edildi!";
            }

            return nRet;


        }
        public string GetUser(string uName)
        {
            return ctx.Users.First
                (x => x.Username == uName).Mail;
        }
        public string DeleteUser(string uName)
        {
            if (ctx.Users.Where(x => x.Username == uName).Count() > 0)
            {
                //Kayıt varsa
                ctx.Users.Remove(ctx.Users.First(ctx.Users.First(x => x.Username == uName)));
                ctx.SaveChanges();
                return uName + "kullanici silindi!";
            }
            else
            {
                //Kayıt yoksa
                return uName + "Kullanıcısı yok!";
            }

        }

    }


}

