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
    public class GatewayController : Controller
    {
        private readonly IServiceApp _service;
        private readonly IMapper _mapper;

        public GatewayController(IMapper mapper, IServiceApp service)
        {
            _mapper = mapper;
            _service= service;

        }

        // GET: Gateway
        public async Task<IActionResult> Index()
        {
            return  View(_mapper.Map<List<GatewayDto>>(_service.GetAllGateway()));
            // return View(await _context.GatewayDto.ToListAsync());
        }

       
        // GET: Gateway/Details/5
        public async Task<IActionResult> Details(int id)
        {
          
            if (id == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }

            var gateway = _service.GetGateway(id);
          
            if (gateway == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }

            return View(_mapper.Map<GatewayDto>(gateway));
        }

        // GET: Gateway/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gateway/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IPv4Address,SerialNumber")] GatewayDto gatewayDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.AddGateway(_mapper.Map<Gateway>(gatewayDto));
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

        // GET: Gateway/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }

            var gatewayDto = _mapper.Map<GatewayDto>(_service.GetGateway(id));
            if (gatewayDto == null)
            {
                return NotFound();
            }
            return View(gatewayDto);
        }

        // POST: Gateway/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IPv4Address,SerialNumber")] GatewayDto gatewayDto)
        {
            if (id != gatewayDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateGateway(_mapper.Map<Gateway>(gatewayDto));
                }
                catch (Exception m)
                {

                    ViewBag.ErrorMessage = m.Message;
                    return View();
                }

            }
            return RedirectToAction(nameof(Index));
           
        }

        // GET: Gateway/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.ObjectNull));
            }
            var gatewayDto = _service.GetGateway(id);
            if (gatewayDto == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }
            _service.RemoveGateway(gatewayDto);
            return RedirectToAction(nameof(Index));
        }

        // POST: Gateway/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gatewayDto = _service.GetGateway(id);
            _service.RemoveGateway(_mapper.Map<Gateway>(gatewayDto));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteDevice(int id)
        {
            if (id == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.ObjectNull));
            }
            var deviceDto = _service.GetDevice(id);
            if (deviceDto == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }
            _service.RemoveDevice(deviceDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
