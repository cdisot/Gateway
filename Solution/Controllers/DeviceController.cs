using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Service;
using CC.Core;
using Domain.Core.CoreData;
using Domain.Core.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Solution.Models;

namespace Solution.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IServiceApp _service;
        private readonly IMapper _mapper;


        public DeviceController(IMapper mapper, IServiceApp service)
        {
            _mapper = mapper;
            _service = service;

        }

        // GET: Device
        public async Task<IActionResult> Index()
        {
           return View(_mapper.Map<IEnumerable<DeviceDto>>(_service.GetAllDevice()));

        }

        // GET: Device/Details/5
        public async Task<IActionResult> Details(int id)
        {

            if (id == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }

            var device = _service.GetDevice(id);

            if (device == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }
            device.Gateway = _service.GetGateway(device.GatewayId);
            device.Status = _service.GetStatus(device.StatusId);
            return View(_mapper.Map<DeviceDto>(device));
        }

        // GET: Device/Create
        
        public ActionResult Create()
        {
            var devices = _service.GetAllStatus().ToList();
            ViewBag.status = new SelectList(_mapper.Map<IEnumerable<StatusDto>>(devices), "Id", "Name");
            ViewBag.statusCount = devices.Count();


            var gateways = _service.GetAllGateway().ToList();
            ViewBag.gateways = new SelectList(_mapper.Map<IEnumerable<GatewayDto>>(gateways), "Id", "Name");
            ViewBag.gatewaysCount = gateways.Count();

            return View();
        }   

        // POST: Device/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UID, Vendor, DateCreate, GatewayId, StatusId")] DeviceDto deviceDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.AddDevice(_mapper.Map<Device>(deviceDto));
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

        // GET: Device/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }         
            
            var deviceDto = _mapper.Map<DeviceDto>(_service.GetDevice(id));
            if (deviceDto == null)
            {
                return NotFound();
            }
            var devices = _service.GetAllStatus().ToList();
            ViewBag.status = new SelectList(_mapper.Map<IEnumerable<StatusDto>>(devices), "Id", "Name");
            ViewBag.statusCount = devices.Count();


            var gateways = _service.GetAllGateway().ToList();
            ViewBag.gateways = new SelectList(_mapper.Map<IEnumerable<GatewayDto>>(gateways), "Id", "Name");
            ViewBag.gatewaysCount = gateways.Count();
            return View(deviceDto);
        }

        // POST: Device/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UID, Vendor, DateCreate, GatewayId, StatusId")] DeviceDto deviceDto)
        {
            if (id != deviceDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateDevice(_mapper.Map<Device>(deviceDto));
                }
                catch (Exception m)
                {

                    ViewBag.ErrorMessage = m.Message;
                    return View();
                }

            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Device/Delete/5
        public async Task<IActionResult> Delete(int id)
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
            _service.RemoveDevice   (deviceDto);
            return RedirectToAction(nameof(Index));
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceDto = _service.GetDevice(id);
            _service.RemoveDevice(_mapper.Map<Device>(deviceDto));
            return RedirectToAction(nameof(Index));
        }

    }
}