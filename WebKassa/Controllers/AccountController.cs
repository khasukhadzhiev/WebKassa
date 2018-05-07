using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebKassa.Models;
namespace WebKassa.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        FbConnection fb;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                FbConnectionStringBuilder fb_con = new FbConnectionStringBuilder
                {
                    Charset = "WIN1251", //используемая кодировка
                    UserID = model.UserName, //логин
                    Password = model.Password, //пароль
                    Database = "ENERGO_GR",
                    Port = 3050,
                    DataSource = "127.0.0.1"
                };
            
                //создаем подключение
                fb = new FbConnection(fb_con.ToString()); //передаем нашу строку подключения объекту класса FbConnection

                //открываем БД
                var a = fb.State;
                try
                {
                    fb.Open();
                    FbCommand status = new FbCommand("select u.access from username u where u.namemag = current_user", fb);
                    FbTransaction fbt = fb.BeginTransaction(); //стартуем транзакцию; стартовать транзакцию можно только для открытой базы (т.е. мутод Open() уже был вызван ранее, иначе ошибка)
                    status.Transaction = fbt;
                    FbDataReader reader = status.ExecuteReader();
                    int select_result = 0;
                    while (reader.Read()) //пока не прочли все данные выполняем...
                    {
                        select_result = reader.GetInt32(0);
                    }

                    fbt.Commit();

                    if (fb.State== System.Data.ConnectionState.Open && select_result==1)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                        return RedirectToAction("Index", "Admin");
                    }                    
                    ModelState.AddModelError("", "Пользователь заблокирован");
                }
                catch
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
                finally
                {
                    fb.Close();
                    fb.Dispose();
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}