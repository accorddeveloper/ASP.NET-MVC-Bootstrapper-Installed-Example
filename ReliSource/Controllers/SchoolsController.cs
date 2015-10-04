﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevTrends.MvcDonutCaching;
using ReliSource.Controllers;

using ReliSource.Models.EntityModel;

namespace ReliSource.Controllers
{
    public class SchoolsController : GenericController<SchoolEntities> {

		#region Developer Comments - Alim Ul karim
        /*
         *  Generated by Alim Ul Karim on behalf of Developers Organism.
         *  Find us developers-organism.com
         *  https://fb.com/DevelopersOrganism
         *  mailto:alim@developers-organism.com	
         *  Google 'https://www.google.com.bd/search?q=Alim-ul-karim'
         *  First Written : 23 March 2014
         *  Modified      : 03 March 2015
         * * */
		#endregion

		#region Constants and variables

		const string DeletedError = "Sorry for the inconvenience, last record is not removed. Please be in touch with admin.";
		const string DeletedSaved = "Removed successfully.";
		const string EditedSaved = "Modified successfully.";
		const string EditedError = "Sorry for the inconvenience, transaction is failed to save into the database. Please be in touch with admin.";
		const string CreatedError = "Sorry for the inconvenience, couldn't create the last transaction record.";
		const string CreatedSaved = "Transaction is successfully added to the database.";
		const string ControllerName = "Schools";
		///Constant value for where the controller is actually visible.
		const string ControllerVisibleUrl = "/Schools/";
        const string CurrentControllerRemoveOutputCacheUrl = "/Partials/GetSchoolID";
        const string DynamicLoadPartialController = "/Partials/";
        bool DropDownDynamic = true;
		#endregion

		#region Enums

		internal enum ViewStates {
            Index,
            Create,
            CreatePostBefore,
            CreatePostAfter,
            Edit,
            EditPostBefore,
            EditPostAfter,
            Details,
            Delete,
            DeletePost
        }

		#endregion

		#region Constructors
		
		public SchoolsController(): base(true){
			ViewBag.controller = ControllerName;
            ViewBag.visibleUrl = ControllerVisibleUrl;
            ViewBag.dropDownDynamic = DropDownDynamic;
            ViewBag.dynamicLoadPartialController = DynamicLoadPartialController;
		} 

		#endregion
		
		#region View tapping
		/// <summary>
        /// Always tap once before going into the view.
        /// </summary>
        /// <param name="view">Say the view state, where it is calling from.</param>
        /// <param name="school">Gives the model if it is a editing state or creating posting state or when deleting.</param>
        /// <returns>If successfully saved returns true or else false.</returns>
		bool ViewTapping(ViewStates view, School school = null, bool entityValidState = true){
			switch (view){
				case ViewStates.Index:
					break;
				case ViewStates.Create:
					break;
				case ViewStates.CreatePostBefore: // before saving it
					break;
                case ViewStates.CreatePostAfter: // after saving
					break;
				case ViewStates.Edit:
					break;
				case ViewStates.Details:
					break;
				case ViewStates.EditPostBefore: // before saving it
					break;
                case ViewStates.EditPostAfter: // after saving
					break;
				case ViewStates.Delete:
					break;
			}
			return true;
		}
		#endregion

		#region Save database common method

		/// <summary>
        /// Better approach to save things into database(than db.SaveChanges()) for this controller.
        /// </summary>
        /// <param name="view">Say the view state, where it is calling from.</param>
        /// <param name="school">Your model information to send in email to developer when failed to save.</param>
        /// <returns>If successfully saved returns true or else false.</returns>
		bool SaveDatabase(ViewStates view, School school = null){
			// working those at HttpPost time.
			switch (view){
				case ViewStates.Create:
					break;
				case ViewStates.Edit:
					break;
				case ViewStates.Delete:
					break;
			}

			try	{                
				var changes = db.SaveChanges(school);
				if(changes > 0){
                    RemoveOutputCacheOnIndex();
                    RemoveOutputCache(CurrentControllerRemoveOutputCacheUrl);
					return true;
				}
			} catch (Exception ex){
				 throw new Exception("Message : " + ex.Message.ToString() + " Inner Message : " + ex.InnerException.Message.ToString());
			}
			return false;
		}
		#endregion

		#region DropDowns Generate

        #region SchoolsController : DropDowns to paste into the partial
            
        #endregion

		public void GetDropDowns(School school = null){
			
		}

		public void GetDropDowns(System.Int32 id){			
		}
		#endregion

		#region Index
        [OutputCache(CacheProfile = "Year")]
        public ActionResult Index() { 
        
			bool viewOf = ViewTapping(ViewStates.Index);
            return View(db.Schools.ToList());
        }
		#endregion

		#region Index Find - Commented
		/*
        [OutputCache(CacheProfile = "Year")]
        public ActionResult Index(System.Int32 id) {
			bool viewOf = ViewTapping(ViewStates.Index);
            return View(db.Schools.Where(n=> n. == id).ToList());
        }
		*/
		#endregion

		#region Details
        public ActionResult Details(System.Int32 id) {
        
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
			bool viewOf = ViewTapping(ViewStates.Details, school);
            return View(school);
        }
		#endregion

		#region Create or Add
        public ActionResult Create() {        
			if(DropDownDynamic == false){
                GetDropDowns();
            }
			bool viewOf = ViewTapping(ViewStates.Create);
            return View();
        }

		/*
		public ActionResult Create(System.Int32 id) {        
			if(DropDownDynamic == false){
                GetDropDowns(id);// Generate hidden.
            }
			bool viewOf = ViewTapping(ViewStates.Create);
            return View();
        }
		*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School school) {
			bool viewOf = ViewTapping(ViewStates.CreatePostBefore, school);
			if(DropDownDynamic == false){
                GetDropDowns(school);
            }
            if (ModelState.IsValid) {            
                db.Schools.Add(school);
                bool state = SaveDatabase(ViewStates.Create, school);
				if (state) {			
					AppVar.SetSavedStatus(ViewBag, CreatedSaved); // Saved Successfully.
				} else {					
					AppVar.SetErrorStatus(ViewBag, CreatedError); // Failed to save
				}
				
                viewOf = ViewTapping(ViewStates.CreatePostAfter, school,state);
                return View(school);
            }
            viewOf = ViewTapping(ViewStates.CreatePostAfter, school, false);			
			AppVar.SetErrorStatus(ViewBag, CreatedError); // record is not valid for creation
            return View(school);
        }
		#endregion

        #region Edit or modify record
        public ActionResult Edit(System.Int32 id) {
        
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
			bool viewOf = ViewTapping(ViewStates.Edit, school);
			if(DropDownDynamic == false){
                GetDropDowns(school); // Generating drop downs
            }
            return View(school);
        }

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(School school) {
			bool viewOf = ViewTapping(ViewStates.EditPostBefore, school);
            if (ModelState.IsValid)
            {
                db.Entry(school).State = EntityState.Modified;
                bool state = SaveDatabase(ViewStates.Edit, school);
				if (state) {
                    AppVar.SetSavedStatus(ViewBag, EditedSaved); // Saved Successfully.
				} else {					
					AppVar.SetErrorStatus(ViewBag, EditedError); // Failed to Save
				}
				
                viewOf = ViewTapping(ViewStates.EditPostAfter, school , state);
                return RedirectToAction("Index");
            }
            viewOf = ViewTapping(ViewStates.EditPostAfter, school , false);
        	if(DropDownDynamic == false){
                GetDropDowns(school); // Generating drop downs
            }
            AppVar.SetErrorStatus(ViewBag, EditedError); // record not valid for save
            return View(school);
        }
		#endregion

		#region Delete or remove record

		
        public ActionResult Delete(int id) {
        
            var school = db.Schools.Find(id);
            bool viewOf = ViewTapping(ViewStates.Delete, school);
			return View(school);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]		
        public ActionResult DeleteConfirmed(int id) {
            var school = db.Schools.Find(id);
			bool viewOf = ViewTapping(ViewStates.DeletePost, school);
            db.Schools.Remove(school);
            bool state = SaveDatabase(ViewStates.Delete, school);
			if (!state) {			
				AppVar.SetErrorStatus(ViewBag, DeletedError); // Failed to Save				
                return View(school);
			}
			
            return RedirectToAction("Index");
        }
		#endregion

		#region Removing output cache
		public void RemoveOutputCache(string url) {
			HttpResponse.RemoveOutputCacheItem(url);
		}
        
        public void RemoveOutputCacheOnIndex() {
            var cacheManager = new OutputCacheManager();
            cacheManager.RemoveItems(ControllerName, "Index");
            cacheManager.RemoveItems(ControllerName, "List");
            cacheManager = null;
            GC.Collect();
        }
		#endregion
    }

	
}
