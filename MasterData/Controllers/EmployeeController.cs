using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterData.Repository;
using Newtonsoft;
using MasterData.Models;

namespace MasterData.Controllers
{
    public class EmployeeController : Controller
    {
        private UnitOFWork _unitOfWork = null;
        public EmployeeController()
        {
            _unitOfWork = new UnitOFWork();
        }
        public JsonResult AllEmployee()
        {
            return Json(_unitOfWork.EmployeeRepository.GetEmployees(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmployeeByID(int id)
        {
            return Json(_unitOfWork.EmployeeRepository.GetEmployeeByID(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Save(employee);
            _unitOfWork.Save();
            return Json(_unitOfWork.EmployeeRepository.GetEmployees(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.RemoveEmployee(employee);
            _unitOfWork.Save();
            return Json(_unitOfWork.EmployeeRepository.GetEmployees(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.UpdateEmployee(employee);
            _unitOfWork.Save();
            return Json(_unitOfWork.EmployeeRepository.GetEmployees(), JsonRequestBehavior.AllowGet);
        }
    }
}