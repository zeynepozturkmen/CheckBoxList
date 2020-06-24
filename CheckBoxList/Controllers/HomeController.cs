using CheckBoxList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckBoxList.Controllers
{
    public class HomeController : Controller
    {
        CheckBoxListEntities db = new CheckBoxListEntities();
        public ActionResult Index()
        {
            var model = new List<PersonList>();

            var list = db.People.ToList();
            foreach (var item in list)
            {
                var md = new PersonList();
                md.Id = item.Id;
                md.FullName = item.FullName;
                md.Email = item.Email;
                md.Salary = item.Salary;

                model.Add(md);

            }
            return View(model);
        }

        public ActionResult UpdatePerson(IEnumerable<PersonList> PersonList)
        {
            foreach (var item in PersonList)
            {
                var person = db.People.Where(x => x.Id == item.Id).FirstOrDefault();
                if (person!=null)
                {
                    person.Salary = person.Salary*2;

                    db.SaveChanges();
                }
            }

            return Json(true, JsonRequestBehavior.AllowGet);

        }

    }
}