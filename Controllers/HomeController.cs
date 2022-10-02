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
        LibraryEntities dbE = new LibraryEntities();
        private SqlConnection myConnection = new SqlConnection(Global.connectionString);
        public ActionResult Books()
        {
            var items = dbE.books.ToList();
            if (items != null)
            {
                ViewBag.Data = items;

            }
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
                    book.authorId = (int)myData["authorId"];
                    book.typeId = (int)myData["typeId"];
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
            var Items = dbE.students.ToList();
            if (Items != null)
            {
                ViewBag.Data = Items;

            }
            return View();
           /* try
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand("Select student.studentId, student.name, student.surname student.point from students");
                SqlDataReader myReader = command.ExecuteReader();

                while(myReader.Read())
                {
                    Students student = new Students();
                    student.studentId = (int)myReader["studentId"];
                    student.name = myReader["name"].ToString();
                    student.surname = myReader["surname"].ToString();
                    student.point = (int)myReader["point"];
                   
                }

                return View();
            }
            catch(Exception)
            {
                ViewBag.Status = 0;
                
            }
            finally
            {
                myConnection.Close();
            } */
        }


    }
}