using Voyon.DotNet.Interview.Logic.BL;
using System.Web.Mvc;
using Voyon.DotNet.Interview.Logic.Models;

namespace Voyon.DotNet.Interview.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskLogic _taskLogic;

        public TaskController(ITaskLogic taskLogic)
        {
            _taskLogic = taskLogic;
        }

        public ActionResult Index()
        {
            return View(_taskLogic.Get());
        }

        public ActionResult Task()
        {
            return View(_taskLogic.Get());
        }

        public JsonResult GetTaskJson(string taskId)
        {
            return Json(_taskLogic.Get(taskId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult EditTask(string id, TaskViewModel task)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { result = _taskLogic.Edit(id, task) }
            };
           // return Json(_taskLogic.Edit(id, task), JsonRequestBehavior.AllowGet);
        }        
    }
}