using ReliSource.Models.EntityModel;
using System.Linq;
using System.Web.Mvc;

namespace ReliSource.Controllers {
    [OutputCache(CacheProfile = "YearNoParam")]
    //public class PartialsController : GenericController<Inherit it with your db context> {
    public class PartialsController : GenericController<SchoolEntities> {


        #region Constructors

        public PartialsController()
            : base(true) {

        }

        #endregion

        #region SchoolClassesController : DropDowns to paste into the partial

        // [DonutOutputCache(CacheProfile = "YearNoParam")]
        public JsonResult GetSchoolID() {
            var data = db.Schools.Select(n => new { id = n.SchoolID, display = n.SchoolName }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region SubjectsController : DropDowns to paste into the partial

        // [DonutOutputCache(CacheProfile = "YearNoParam")]
        public JsonResult GetSchoolClassID() {
            var data = db.SchoolClasses.Select(n => new {
                id = n.SchoolClassID, display = n.SchoolClassName }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }

}
