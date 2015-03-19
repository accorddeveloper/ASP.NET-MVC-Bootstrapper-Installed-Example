using System;
using System.Web.Mvc;
using ReliSource.Models.Context;
using ReliSource.Modules.Extensions.Context;
using ReliSource.Modules.UserError;

namespace ReliSource.Controllers {

    public abstract class GenericController<TContext> : Controller where TContext : DevDbContext, new() {
        internal ErrorCollector ErrorCollector;
        internal readonly TContext db;

        protected GenericController() {
        }

        protected GenericController(bool applicationDbContextRequried) {
            if (applicationDbContextRequried) {
                db = new TContext();
            }
        }

        protected GenericController(bool applicationDbContextRequried, bool errorCollectorRequried) {
            if (errorCollectorRequried) {
                ErrorCollector = new ErrorCollector();
            }
            if (applicationDbContextRequried) {
                db = new TContext();
            }
        }

        protected override void Dispose(bool disposing) {
            if (db != null) {
                db.Dispose();
            }
            if (ErrorCollector != null) {
                ErrorCollector.Dispose();
            }
            base.Dispose(disposing);
            GC.Collect();
        }
    }
}