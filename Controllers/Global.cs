using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using u19078308HW05.Models;

namespace u19078308HW05.Controllers
{
    public static class Global
    {
        public static string connectionString = "Data Source=.;Initial Catalog=Library;Integrated Security=True";
        public static List<Books> bookslist = new List<Books>();

    }
}