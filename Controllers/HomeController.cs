using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u19078308HW05.Models;

namespace u19078308HW05.Controllers
{
    public class HomeController : Controller
    {
        private SqlConnection myConnection = new SqlConnection(Global.connectionString);
        public ActionResult Books()
        {
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT books.bookId, books.name, books.authorId, authors.surname, books.typeId, types.name books.pagecount, books.point FROM ((books INNER JOIN authors ON books.authorId = authors.authorId) INNER JOIN types ON books.typeId = types.typeId)", myConnection);
                SqlDataReader myData = myCommand.ExecuteReader();
                Global.bookslist.Clear();
                while (myData.Read())
                {
                    Books book = new Books();
                    book.bookId = (int)myData["bookId"];
                    book.name = myData["name"].ToString();
                    book.Author.authorId = (int)myData["authorId"];
                    book.Author.surname = myData["surname"].ToString();
                    book.Type.typeId = (int)myData["typeId"];
                    book.Type.name = myData["name"].ToString();
                    book.pagecount = (int)myData["pagecount"];
                    book.point = (int)myData["point"];
                    Global.bookslist.Add(book);
                    ViewBag.SearchStatus = 1;
                    ViewBag.Status = 1;
                }
            }
            catch(Exception err)
            {
                ViewBag.Status = 0;
            }
            finally
            {
                myConnection.Close();
            }
            return View(Global.bookslist);
        }

        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult Student()
        {
            return View();
        }


    }
}