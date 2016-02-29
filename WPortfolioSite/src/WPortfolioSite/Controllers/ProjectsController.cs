using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WPortfolioSite.Models;
using Microsoft.Data.Entity;
using System.Net;
using Microsoft.AspNet.Mvc.ModelBinding.Validation;

namespace WPortfolioSite.Controllers
{
    public class ProjectsController : Controller
    {
        [FromServices]
        public ProjectDBContext ProjectDBContext { get; set; }
        private ProjectDBContext db = new ProjectDBContext();
        private String DevEnv = "false";

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Message"] = "Christopher's Projects";
            ViewData["Dev"] = DevEnv;

            return View(db.Projects.Include(prop => prop.ProjectFiles));
        }

        // GET: /<controller>/Featured/
        public IActionResult Featured()
        {
            return View();
        }

        // GET: /<controller>/Create/
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Message"] = "Submit a new project";

            return View();
        }


        // POST: /<controller>/Create/
        [HttpPost(Name = "filenamesArr")]
        public async Task<IActionResult> Create(Project project, string[] filenamesArr)
        {
            ViewData["Message"] = "Submit a new project";

            foreach (var fn in filenamesArr)
            {
                if (fn.Length > 50)
                {
                    ViewData["ValidationMsg"] = "Error: One of your filenames is too large (must be less than 50 characters)";
                    return View();
                }
                ProjectFile projectFile = new ProjectFile();
                projectFile.Filename = fn;
                project.ProjectFiles.Add(projectFile);
            }

            if (!ModelState.IsValid)
            {
                return View(project);
            }

            var db = new ProjectDBContext();

            db.Projects.Add(project);

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (DevEnv == "true")
            {
                // Dev mode is turned on, everyone is allowed to delete projects
                if (id == null)
                {
                    return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);

                }

                Project projectToDelete = null;
                foreach (var project in db.Projects.Include(prop => prop.ProjectFiles))
                {
                    if (project.ID == id)
                    {
                        projectToDelete = project;
                    }
                }

                if (projectToDelete == null)
                {
                    return HttpNotFound();
                }
                return View(projectToDelete);
            } else
            {
                // Dev mode is turned off, nobody is allowed to delete projects
                return RedirectToAction("Index");
            }
            
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (DevEnv == "true")
            {
                // Dev mode is turned on, everyone is allowed to delete projects
                Project projectToDelete = null;
                foreach (var project in db.Projects.Include(prop => prop.ProjectFiles))
                {
                    if (project.ID == id)
                    {
                        projectToDelete = project;
                    }
                }

                if (projectToDelete != null)
                {
                    foreach (var file in projectToDelete.ProjectFiles)
                    {
                        db.Files.Remove(file);
                    }

                    db.Projects.Remove(projectToDelete);
                    await db.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            } else
            {
                // Dev mode is not turned on, nobody is allowed to delete projects
                return RedirectToAction("Index");
            }
        }
    }
}
