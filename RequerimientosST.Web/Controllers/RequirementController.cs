using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using RequerimientosST.BL.DTOs;
using RequerimientosST.BL.Models;
using RequerimientosST.BL.Repositories.Implements;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RequerimientosST.Web.Controllers
{
    public class RequirementController : Controller
    {
        #region Properties
        private DBContext _context;
        private IMapper mapper;
        public DBContext Context
        {
            get
            {
                return _context ?? HttpContext.GetOwinContext().Get<DBContext>();
            }
            private set
            {
                _context = value;
            }
        }
        public RequirementController()
        {
            this.mapper = MvcApplication.MapperConfiguration.CreateMapper();
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var requirementRepository = new RequirementRepository(Context);
            var requirements = (await requirementRepository.GetAll()).Select(x => mapper.Map<RequirementDTO>(x)).ToList();
            return View(requirements);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            await LoadDropdownList();
            var requirementRepository = new RequirementRepository(Context);
            var requirement = mapper.Map<RequirementDTO>(await requirementRepository.GetById(id));
            return View(requirement);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RequirementDTO requirementDTO)
        {
            await LoadDropdownList();

            if (ModelState.IsValid)
            {
                var requirementRepository = new RequirementRepository(Context);
                var requirement = mapper.Map<Requirement>(requirementDTO);
                await requirementRepository.Update(requirement);
                return RedirectToAction("Index");
            }

            return View(requirementDTO);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var requirementRepository = new RequirementRepository(Context);
            var requirement = mapper.Map<RequirementDTO>(await requirementRepository.GetById(id));
            return View(requirement);
        }

        [HttpGet]
        public async Task<ActionResult> DeleteConfirm(int id)
        {
            var requirementRepository = new RequirementRepository(Context);
            await requirementRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            await LoadDropdownList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RequirementDTO requirementDTO)
        {
            await LoadDropdownList();

            if (ModelState.IsValid)
            {
                var requirementRepository = new RequirementRepository(Context);
                var requirement = mapper.Map<Requirement>(requirementDTO);
                requirement.ApplicationDate = DateTime.Now;
                await requirementRepository.Insert(requirement);
                return RedirectToAction("Index");
            }

            return View(requirementDTO);
        }

        private async Task LoadDropdownList()
        {
            var areaRepository = new AreaRepository(Context);
            var applicativeRepository = new ApplicativeRepository(Context);
            var priorityRepository = new PriorityRepository(Context);
            var developmentEngineerRepository = new DevelopmentEngineerRepository(Context);

            var areas = (await areaRepository.GetAll()).Select(x => mapper.Map<AreaDTO>(x)).ToList();
            var applicatives = (await applicativeRepository.GetAll()).Select(x => mapper.Map<ApplicativeDTO>(x));
            var priorities = (await priorityRepository.GetAll()).Select(x => mapper.Map<PriorityDTO>(x));
            var developmentEngineers = (await developmentEngineerRepository.GetAll()).Select(x => mapper.Map<DevelopmentEngineerDTO>(x));

            ViewData["areas"] = new SelectList(areas, "ID", "Description");
            ViewData["applicatives"] = new SelectList(applicatives, "ID", "Description");
            ViewData["priorities"] = new SelectList(priorities, "ID", "Description");
            ViewData["developmentEngineers"] = new SelectList(developmentEngineers, "ID", "FullName");
        }
    }
}