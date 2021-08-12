using System;
using System.Collections.Generic;
using System.Linq;
using CC.Core;
using Domain.Core.CoreData;
using Domain.Core.Interface;
using Domain.Core.Repository;

namespace App.Service
{
    public class ServicesApp : IServiceApp
    {
        private readonly IGatewayRepository _gatewayRepo;
        private readonly IDeviceRepository _deviceRepo;
        private readonly IStatusRepository _statusRepo;

        public ServicesApp(IGatewayRepository gatewayRepo, IDeviceRepository deviceRepo, IStatusRepository statusRepo)
        {
            _gatewayRepo = gatewayRepo;
            _deviceRepo = deviceRepo;
            _statusRepo = statusRepo;
        }


        #region gateway

        /// <summary>
        /// Id Gateway
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GatewayIsOcupation(int id)
        {
            return GetGateway(id).DeviceAllowed();
        }

        public void AddGateway(IGateway gateway)
        {
            var firstGateway = GetAllGateway().FirstOrDefault(g => g.SerialNumber == gateway.SerialNumber);
            if (firstGateway == null)
            {
                if (gateway.IsValidIP())
                    _gatewayRepo.Add((Gateway)gateway);
                else
                    throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.IsNotValidIP));
            }
            else
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.ExistEntity));
            }
        }

        public IGateway GetGateway(int id)
        {
            var gateway = _gatewayRepo.GetById(id);
            if (gateway == null)
                return null;
            gateway.Devices = GetAllDevice().Where(d => d.GatewayId == gateway.Id).ToList();
            return gateway;
        }
        public bool ExistGateway(int id)
        {

            return _gatewayRepo.GetById(id) != null ? true : false;

        }

        public IEnumerable<IGateway> GetAllGateway()
        {
          
            List<Gateway> gateways = _gatewayRepo.GetAll().ToList();
            var devices = GetAllDevice().ToList();
            for (int i = 0; i < gateways.Count(); i++)
            {
                gateways[i]= (Gateway)GatewayListDevice(devices, gateways[i]);
                
            }       
            return gateways;
        }
        private IGateway GatewayListDevice(IEnumerable<IDevice> devices, IGateway gateway)
        { 
            gateway.Devices = devices.Where(d => d.GatewayId == gateway.Id).ToList();
            return gateway;
         }
        public void UpdateGateway(IGateway newGateway)
        {

            if (ExistGateway(newGateway.Id) == true)
            {
                if (newGateway.IsValidIP())
                    _gatewayRepo.Update((Gateway)newGateway);
                else
                    throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.IsNotValidIP));

            }
            else
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }
        }
        public void RemoveGateway(IGateway gateway)
        {
            _gatewayRepo.Remove((Gateway)gateway);

        }




        #endregion

        #region Device
        public IDevice GetDevice(int id)
        {
            return _deviceRepo.GetById(id); ;
        }




        public void AddDevice(IDevice device)
        {
            var firstDevice = GetAllDevice().FirstOrDefault(d => d.UID == device.UID);
            if (firstDevice == null)
            {
               
                var gateway = GetGateway(device.GatewayId);
                if (gateway != null)
                {
                    var devices = _deviceRepo.GetAll();
                    if (devices != null)
                    {
                        gateway = (Gateway)GatewayListDevice(devices, gateway);
                        if (gateway.Devices.Count() >= 10)
                        {
                            throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.GatewayOcupation));
                        }
                    }
                }
                else
                {
                    throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExistGateway));
                }
                if (device.StatusId == 0 || device.StatusId == null)
                    {
                    throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExistStatus));
                }
                    _deviceRepo.Add((Device)device);                           
               
            }
            else
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.ExistEntity));
            }
        }



        public bool ExistDevice(int id)
        {
            return _deviceRepo.GetById(id) != null ? true : false;
        }


        public IEnumerable<IDevice> GetAllDevice()
        {
            List<Device> devices= _deviceRepo.GetAll().ToList();
            var gateways = _gatewayRepo.GetAll().ToList(); 
            var status  = _statusRepo.GetAll().ToList();
            for (int i = 0; i < devices.Count(); i++)
            {
                devices[i].Gateway = gateways.First(g => g.Id == devices[i].GatewayId);
                devices[i].Status = status.First(g => g.Id == devices[i].StatusId);
            }
            return devices;
        }
        public void RemoveDevice(IDevice device)
        {
            _deviceRepo.Remove(device.Id);
        }

        public void UpdateDevice(IDevice newDevice)
        {
            var _device = GetDevice(newDevice.Id);
            if (_device != null)
            {
                if (newDevice.GatewayId != _device.GatewayId)
                {
                    var devicesAll = _deviceRepo.GetAll();
                    if (devicesAll != null && devicesAll.Count() > 0)
                    {
                        var gateway = GetGateway(newDevice.GatewayId);
                        gateway = (Gateway)GatewayListDevice(devicesAll, gateway);
                        if (gateway.Devices.Count() >= 10)
                        {
                            throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.GatewayOcupation));
                        }
                    }
                }                
              _deviceRepo.Update((Device)newDevice);
            }
            else
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));

            }
        }
        public void RemoveDeviceFromGateway(int id)
        {
            var _device = GetDevice(id);
            if (_device != null)
            {                
                _deviceRepo.Remove((Device)_device);
            }
            else
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));

            }
        }



        #endregion

        #region Status

        public void AddStatus(IStatus status)
        {
            var firstStatus = GetAllStatus().FirstOrDefault(d => d.Name == status.Name);
            if (firstStatus == null)
            {
                _statusRepo.Add((Status)status);
            }
            else
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));
            }
        }

        public bool ExistStatus(int id)
        {
            return _statusRepo.GetById(id) != null ? true : false;
        }

        public void UpdateStatus(IStatus newStatus)
        {
            var _device = GetStatus(newStatus.Id);
            if (_device != null)
            {
                _statusRepo.Update((Status)newStatus);
            }
            else
            {
                throw new Exception(ErrorCodesExtensions.GetDescription(ErrorCode.NotExitEntity));

            }
        }

        public void RemoveStatus(IStatus status)
        {
            _statusRepo.Remove(status.Id);
        }

        public IEnumerable<IStatus> GetAllStatus()
        {
            return _statusRepo.GetAll();
        }
        public IStatus GetStatus(int id)
        {
            return _statusRepo.GetById(id);
        }



        #endregion
    }
}
