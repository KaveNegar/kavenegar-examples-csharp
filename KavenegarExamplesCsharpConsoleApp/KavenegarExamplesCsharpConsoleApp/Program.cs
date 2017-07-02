using System;
using System.Collections.Generic;
using Kavenegar;
using Kavenegar.Exceptions;
using Kavenegar.Models;

namespace KavenegarExamplesCsharpConsoleApp
{
    internal class Program
    {
        public static KavenegarApi Api;
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Api = new KavenegarApi("your apikey");

            CallMakeTTS();

            //VerifyLookup();

            //Send();

            //Send_2();

            //SendArray();

            //SendArray_2();

            //Status();

            //Status(new List<String> { "56571749", "56567804" });

            //StatusLocalMessageId();

            //StatusLocalMessageId(new List<string> { "5959", "5957" });

            //Select();

            //Select(new List<String> { "56571749", "56567804" });

            //CountInbox();

            //CountOutbox();

            //SelectOutbox();

            //LatestOutbox();

            //Receive();

            //CountPostalCode();

            //AccountInfo();

            //AccountConfig();

            //Console.ReadKey();

        }




        static void VerifyLookup()
        {
            try
            {
                const string receptor = "";
                const string token = "";
                const string token2 = "";
                const string token3 = "";
                const string template = "";
                var result = Api.VerifyLookup(receptor, token, token2, token3, template);
                if (result != null)
                {
                    Console.WriteLine(result.Cost + "\n");
                    Console.WriteLine(result.Date + "\n");
                    Console.WriteLine(result.Message + "\n");
                    Console.WriteLine(result.Receptor + "\n");
                    Console.WriteLine(result.Sender + "\n");
                    Console.WriteLine(result.Status + "\n");
                    Console.WriteLine(result.StatusText + "\n");
                }
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
        }



        static void AccountConfig()
        {
            try
            {
                var apilogs = "enabled";
                var dailyreport = "enabled";
                var debugmode = "enabled";
                var defaultsender = "30006703323323";
                int? mincreditalarm = 1000;
                var resendfailed = "enabled";
                var result = Api.AccountConfig(apilogs, dailyreport, debugmode, defaultsender, mincreditalarm, resendfailed);
                Console.WriteLine(result.ApiLogs + "\n");
                Console.WriteLine(result.DailyReport + "\n");
                Console.WriteLine(result.DebugMode + "\n");
                Console.WriteLine(result.DefaultSender + "\n");
                Console.WriteLine(result.MinCreditAlarm + "\n");
                Console.WriteLine(result.ResendFailed + "\n");
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
        }


        static void Send()
        {
            try
            {
                var sender = "30006703323323";
                var receptor = "09361234567";
                var message = "Test CSharp SDK : Send";
                var localid = "94751643";
                var result = Api.Send(sender, receptor, message, localid);
                Console.Write("Messageid : " + result.Messageid + "\r\n");
                Console.Write("Message : " + result.Message + "\r\n");
                Console.Write("Status : " + result.Status + "\r\n");
                Console.Write("Statustext : " + result.StatusText + "\r\n");
                Console.Write("Receptor : " + result.Receptor + "\r\n");
                Console.Write("Sender : " + result.Sender + "\r\n");
                Console.Write("Date : " + result.Date + "\r\n");
                Console.Write("Cost : " + result.Cost + "\r\n");
                Console.Write("\r\n");
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
        }

        static void Send_2()
        {
            try
            {
                var sender = "30006703323323";
                var receptors = new List<String>() { "09362985956", "09362985956" };
                const string message = "Test CSharp SDK : Send";
                const string localid = "94751643";
                var results = Api.Send(sender, receptors, message, localid);
                foreach (var result in results)
                {
                    Console.Write("Messageid : " + result.Messageid + "\r\n");
                    Console.Write("Message : " + result.Message + "\r\n");
                    Console.Write("Status : " + result.Status + "\r\n");
                    Console.Write("Statustext : " + result.StatusText + "\r\n");
                    Console.Write("Receptor : " + result.Receptor + "\r\n");
                    Console.Write("Sender : " + result.Sender + "\r\n");
                    Console.Write("Date : " + result.Date + "\r\n");
                    Console.Write("Cost : " + result.Cost + "\r\n");
                    Console.Write("\r\n");
                }
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
        }

        static void SendArray()
        {
            try
            {
                var senders = new List<string>() { "10008284" };
                var receptors = new List<string>() { "09125089676" };
                var messages = new List<string>() { "خدمات پیام کوتاه کاوه نگار" };
                var results = Api.SendArray(senders, receptors, messages);
                foreach (SendResult result in results)
                {
                    var messageids = new List<String>() { result.Messageid.ToString() };
                    Status(messageids);
                }
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
        }

        static void SendArray_2()
        {
            try
            {
                var senders = new List<string> { "10008284" };
                var receptors = new List<string> { "09125089676" };
                var messages = new List<string> { "خدمات پیام کوتاه کاوه نگار" };
                string localmessageids = "94761458";
                var results = Api.SendArray(senders, receptors, messages, localmessageids);
                foreach (var result in results)
                {
                    var messageids = new List<String>() { result.Messageid.ToString() };
                    Status(messageids);
                }
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
        }


        static void Status()
        {
            try
            {
                const string messageid = "56571749";
                var result = Api.Status(messageid);
                Console.Write("Messageid : " + result.Messageid + "\r\n");
                Console.Write("Status : " + result.Status + "\r\n");
                Console.Write("Statustext : " + result.Statustext + "\r\n");
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
        }
        static void Status(List<String> messageids)
        {
            try
            {
                var results = Api.Status(messageids);
                foreach (StatusResult result in results)
                {
                    Console.Write("Messageid : " + result.Messageid + "\r\n");
                    Console.Write("Status : " + result.Status + "\r\n");
                    Console.Write("Statustext : " + result.Statustext + "\r\n");
                    Console.Write("\r\n");
                }
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
        }


        static void StatusLocalMessageId()
        {
            try
            {
                var localid = "5956";
                var result = Api.StatusLocalMessageId(localid);
                Console.Write("Messageid : " + result.Messageid + "\r\n");
                Console.Write("Status : " + result.Status + "\r\n");
                Console.Write("Statustext : " + result.Statustext + "\r\n");
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
        }
        static void StatusLocalMessageId(List<String> localids)
        {
            try
            {
                var results = Api.StatusLocalMessageId(localids);
                foreach (var result in results)
                {
                    Console.Write("Messageid : " + result.Messageid + "\r\n");
                    Console.Write("Status : " + result.Status + "\r\n");
                    Console.Write("Statustext : " + result.Statustext + "\r\n");
                    Console.Write("\r\n");

                }
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
        }


        static void Select()
        {
            try
            {
                string messageid = "56571749";
                var result = Api.Select(messageid);
                Console.Write("Messageid : " + result.Messageid + "\r\n");
                Console.Write("Message : " + result.Message + "\r\n");
                Console.Write("Status : " + result.Status + "\r\n");
                Console.Write("Statustext : " + result.StatusText + "\r\n");
                Console.Write("Receptor : " + result.Receptor + "\r\n");
                Console.Write("Sender : " + result.Sender + "\r\n");
                Console.Write("Date : " + result.Date + "\r\n");
                Console.Write("Cost : " + result.Cost + "\r\n");
                Console.Write("\r\n");
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
        }


        static void Select(List<String> messageids)
        {
            try
            {

                var results = Api.Select(messageids);
                foreach (var result in results)
                {
                    Console.Write("Messageid : " + result.Messageid + "\r\n");
                    Console.Write("Message : " + result.Message + "\r\n");
                    Console.Write("Status : " + result.Status + "\r\n");
                    Console.Write("Statustext : " + result.StatusText + "\r\n");
                    Console.Write("Receptor : " + result.Receptor + "\r\n");
                    Console.Write("Sender : " + result.Sender + "\r\n");
                    Console.Write("Date : " + result.Date + "\r\n");
                    Console.Write("Cost : " + result.Cost + "\r\n");
                    Console.Write("\r\n");
                }
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
        }


        static void SelectOutbox()
        {
            try
            {
                var stardate = new DateTime(2015, 09, 21, 10, 11, 12);
                var enddate = DateTime.Now;
                string sender = "30006703323323";
                var results = Api.SelectOutbox(stardate, enddate, sender);
                foreach (SendResult result in results)
                {
                    Console.Write("Messageid : " + result.Messageid + "\r\n");
                    Console.Write("Message : " + result.Message + "\r\n");
                    Console.Write("Status : " + result.Status + "\r\n");
                    Console.Write("Statustext : " + result.StatusText + "\r\n");
                    Console.Write("Receptor : " + result.Receptor + "\r\n");
                    Console.Write("Sender : " + result.Sender + "\r\n");
                    Console.Write("Date : " + result.Date + "\r\n");
                    Console.Write("Cost : " + result.Cost + "\r\n");
                    Console.Write("\r\n");
                }
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
        }


        static void LatestOutbox()
        {
            try
            {
                long pagesize = 50;
                string sender = "30006703323323";
                var results = Api.LatestOutbox(pagesize, sender);
                foreach (SendResult result in results)
                {
                    Console.Write("Messageid : " + result.Messageid + "\r\n");
                    Console.Write("Message : " + result.Message + "\r\n");
                    Console.Write("Status : " + result.Status + "\r\n");
                    Console.Write("Statustext : " + result.StatusText + "\r\n");
                    Console.Write("Receptor : " + result.Receptor + "\r\n");
                    Console.Write("Sender : " + result.Sender + "\r\n");
                    Console.Write("Date : " + result.Date + "\r\n");
                    Console.Write("Cost : " + result.Cost + "\r\n");
                    Console.Write("\r\n");
                }
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
        }


        static void CountOutbox()
        {
            try
            {
                var stardate = new DateTime(2015, 09, 21, 10, 11, 12);
                var enddate = DateTime.Now;
                int status = 10;
                var re = Api.CountOutbox(stardate, enddate, status);

                Console.Write("StartDate : " + re.StartDate);
                Console.Write("EndDate : " + re.EndDate);
                Console.Write("SumPart : " + re.SumPart);
                Console.Write("SumCount : " + re.SumCount);
                Console.Write("Cost : " + re.Cost);
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
        }


        static void Cancel()
        {
            try
            {
                string messageid = "5956";
                StatusResult result = Api.Cancel(messageid);
                Console.Write("Messageid : " + result.Messageid);
                Console.Write("Status : " + result.Status);
                Console.Write("Statustext : " + result.Statustext);
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
        }
        static void Cancel(List<string> messageids)
        {
            try
            {
                List<StatusResult> results = Api.Cancel(messageids);
                foreach (StatusResult result in results)
                {
                    Console.Write("Messageid : " + result.Messageid);
                    Console.Write("Status : " + result.Status);
                    Console.Write("Statustext : " + result.Statustext);
                }
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
        }


        static void Receive()
        {
            try
            {
                string linenumber = "30006703323323";
                int isread = 1;
                List<ReceiveResult> res = Api.Receive(linenumber, isread);
                foreach (ReceiveResult re in res)
                {
                    Console.Write("Messageid : " + re.MessageId);
                    Console.Write("message : " + re.Message);
                    Console.Write("sender : " + re.Sender);
                    Console.Write("receptor : " + re.Receptor);
                    Console.Write("date : " + re.Date);
                }
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
        }


        static void CountInbox()
        {
            try
            {
                DateTime stardate = new DateTime(2015, 09, 21, 10, 11, 12);
                DateTime enddate = DateTime.Now;
                string linenumber = "30006703323323";
                int isread = 10;
                var result = Api.CountInbox(stardate, enddate, linenumber, isread);
                Console.Write("StartDate : " + result.StartDate);
                Console.Write("EndDate : " + result.EndDate);
                Console.Write("SumCount : " + result.SumCount);

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
        }



        static void CountPostalCode()
        {
            try
            {
                long postalcode = 441585;
                var results = Api.CountPostalCode(postalcode);
                foreach (var result in results)
                {
                    Console.Write("StartDate : " + result.Section + "\r\n");
                    Console.Write("EndDate : " + result.Value + "\r\n");
                }
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
        }

        static void AccountInfo()
        {
            try
            {
                var result = Api.AccountInfo();
                Console.Write("RemainCredit : " + result.RemainCredit + "\r\n");
                Console.Write("Expiredate : " + result.Expiredate + "\r\n");
                Console.Write("Type : " + result.Type + "\r\n");
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
        }

        static void CallMakeTTS()
        {
            try
            {

                var receptors = new List<string>{ "", "" };
                var message = "test CallMakeTTS";
                var results = Api.CallMakeTTS(message, receptors); 
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
            Console.ReadKey();
        }



    }

}
