//using ReliSource.Models.EntityModel.POCO; // Northwind Sample
using DevTrends.MvcDonutCaching;
using ReliSource.Models.EntityModel;
using System.Linq;
using System.Web.Mvc;

namespace ReliSource.Controllers {
    [OutputCache(CacheProfile = "YearNoParam")]
    //public class PartialsController : GenericController<Inherit it with your db context> {
    public class PartialsController : GenericController<NorthwindEntities> {


        #region Constructors

        public PartialsController()
            : base(true) {

        }

        #endregion

        #region Nortwind test
        //#region EmployeesController : DropDowns to paste into the partial

        //// [DonutOutputCache(CacheProfile = "YearNoParam")]
        //public JsonResult GetReportsTo() {
        //    var data = db.Employees.Select(n => new { id = n.EmployeeID, display = n.LastName }).ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //#endregion

        //#region ProductOrdersController : DropDowns to paste into the partial
        //public JsonResult GetEmployeeID() {
        //    var data = db.Employees.Select(n => new { id = n.EmployeeID, display = n.LastName + " (" + n.EmployeeID + ")" }).ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        //// [DonutOutputCache(CacheProfile = "YearNoParam")]
        //public JsonResult GetCustomerID() {
        //    var data = db.Customers.Select(n => new { id = n.CustomerID, display = n.CompanyName }).ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //[OutputCache(CacheProfile = "Year")]
        //public JsonResult GetShipVia(int id) {
        //    var data = db.Shippers.Where(n=> n.ShipperID == id).Select(n => new { id = n.ShipperID, display = n.CompanyName }).ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //#endregion 
        #endregion

        #region EmployeesController : DropDowns to paste into the partial

        // [DonutOutputCache(CacheProfile = "YearNoParam")]
        public JsonResult GetReportsTo() {
            var data = db.Employees.Select(n => new { id = n.EmployeeID, display = n.LastName }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region ProductOrdersController : DropDowns to paste into the partial

        // [DonutOutputCache(CacheProfile = "YearNoParam")]
        public JsonResult GetCustomerID() {
            var data = db.Customers.Select(n => new { id = n.CustomerID, display = n.CompanyName }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // [DonutOutputCache(CacheProfile = "YearNoParam")]
        public JsonResult GetEmployeeID() {
            var data = db.Employees.Select(n => new { id = n.EmployeeID, display = n.LastName }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // [DonutOutputCache(CacheProfile = "YearNoParam")]
        public JsonResult GetShipVia(int id) {
            var data = db.Shippers.Where(n=> n.ShipperID == id).Select(n => new { id = n.ShipperID, display = n.CompanyName }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }

}
