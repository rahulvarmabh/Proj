using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proj.Models; 

namespace Proj.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        public ActionResult Index()
        {
            return View(new Salary()) ;
        }
        [HttpPost]
        public ActionResult Index(Salary s)
        {
            if (s.basicpay > 60000)
            {
                s.da = s.basicpay * 5 / 100;
                s.hra = s.basicpay * 35 / 100;
                s.pf = s.basicpay * 5 / 100;
                s.tax = s.basicpay * 10 / 100;
            }
            else if (s.basicpay > 30000)
            {
                s.da = s.basicpay * 5 / 100;
                s.hra = s.basicpay * 25 / 100;
                s.pf = s.basicpay * 5 / 100;
                s.tax = s.basicpay * 10 / 100;
            }
            else
            {
                s.da = s.basicpay * 5 / 100;
                s.hra = s.basicpay * 15 / 100;
                s.pf = s.basicpay * 2.5 / 100;
                s.tax = s.basicpay * 0 / 100;
            }

            s.netsalary = s.basicpay + s.da + s.hra - s.pf - s.tax;

            //List<Salary> _salary = new List<Salary>();
            //_salary.Add(new Salary { basicpay = s.basicpay, da = s.da, hra = s.hra, pf = s.pf, tax = s.tax, netsalary = s.netsalary });

            //SalaryModel _salaryModel = new SalaryModel();
            //_salaryModel.SalaryList = _salary;
            return View(s); 
        }

        public ActionResult Grid(Salary s)
        {
            List<Salary> _salary = new List<Salary>
            {
                new Salary { basicpay = s.basicpay, da = s.da, hra = s.hra, pf = s.pf, tax = s.tax, netsalary = s.netsalary }
            };

            SalaryModel _salaryModel = new SalaryModel
            {
                SalaryList = _salary
            };
            return View();
        }
        
    }
}