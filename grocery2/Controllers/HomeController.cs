using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace grocery2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderList()
        {

          
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["adoConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select OI.ProductId as 'ProductID', P.Name as 'ProductName', SUM(OI.Quantity) AS Quantiy_sold from Products P, OderItems OI where P.id = OI.ProductId group by OI.ProductId, P.Name order by SUM(OI.Quantity)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }

            return View(ds);
           
        }

        public ActionResult Query1()
        {


            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["adoConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select OI.ProductId as 'ProductID', P.Name as 'ProductName', SUM(OI.Quantity) AS Quantiy_sold from Products P, OderItems OI where P.id = OI.ProductId group by OI.ProductId, P.Name order by SUM(OI.Quantity)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }

            return View(ds);

        }
        public ActionResult Query2()
        {


            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["adoConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select OI.ProductId as 'ProductID', P.Name as 'ProductName', SUM(OI.Quantity) AS Quantiy_sold from Products P, OderItems OI where P.id = OI.ProductId group by OI.ProductId, P.Name order by SUM(OI.Quantity)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }

            return View(ds);

        }
        public ActionResult Query3()
        {


            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["adoConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select OI.ProductId as 'ProductID', P.Name as 'ProductName', SUM(OI.Quantity) AS Quantiy_sold from Products P, OderItems OI where P.id = OI.ProductId group by OI.ProductId, P.Name order by SUM(OI.Quantity)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }

            return View(ds);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}