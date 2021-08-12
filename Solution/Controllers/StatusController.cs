using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Service;
using CC.Core;
using Domain.Core.CoreData;
using Domain.Core.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Solution.Models;

namespace Solution.Controllers
{
    
   
    public class StatusController : Controller
    {
        private readonly IServiceApp _service;
        private readonly IMapper _mapper;


        public StatusController(IMapper mapper, IServiceApp service)
        {
            _mapper = mapper;
            _service = service;

        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<StatusDto>>(_service.GetAllStatus()));
            
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int id)
        {

            if (id == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }

            var status = _service.GetStatus(id);

            if (status == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }

            return View(_mapper.Map<StatusDto>(status));
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gateway/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StatusDto statusDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.AddStatus(_mapper.Map<Status>(statusDto));
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception m)
                {
                    ViewBag.ErrorMessage = m.Message;
                    return View();
                }

            }
            else
            {
                return View();
            }
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }

            var statusDto = _mapper.Map<StatusDto>(_service.GetStatus(id));
            if (statusDto == null)
            {
                return NotFound();
            }
            return View(statusDto);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StatusDto statusDto)
        {
            if (id != statusDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateStatus(_mapper.Map<Status>(statusDto));
                }
                catch (Exception m)
                {

                    ViewBag.ErrorMessage = m.Message;
                    return View();
                }

            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.ObjectNull));
            }
            var statusDto = _service.GetStatus(id);
            if (statusDto == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }
            _service.RemoveStatus(statusDto);
            return RedirectToAction(nameof(Index));
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusDto = _service.GetStatus(id);
            _service.RemoveStatus(_mapper.Map<Status>(statusDto));
            return RedirectToAction(nameof(Index));
        }

    }
}
