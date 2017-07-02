using System;
using System.Web.Mvc;
using  Kavenegar;
using Kavenegar.Exceptions;

namespace KavenegarExamplesCsharpWebApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            try
            {
                var api = new KavenegarApi("Your Api Key");
                var result = api.Send("", "09361234567", "خدمات پیام کوتاه کاوه نگار");
                return View(result);
            }
            catch (ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                Console.Write("Message : " + ex.Message);
            }
            catch (HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                Console.Write("Message : " + ex.Message);
            }
            return View();
        }
    }
}

