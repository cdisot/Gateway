using Domain.Core.CoreData;
using Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Service
{
   public interface IServiceApp
    {
        #region Gateway

        void AddGateway(IGateway gateway);
        bool ExistGateway(int id);
        void UpdateGateway(IGateway newGateway);
        void RemoveGateway(IGateway gateway);
        IGateway GetGateway(int id);
        IEnumerable<IGateway> GetAllGateway();
bool GatewayIsOcupation(int id);
        #endregion


        #region  Devices
        void RemoveDeviceFromGateway(int id);
       
        void AddDevice(IDevice device);
        bool ExistDevice(int id);
        void UpdateDevice(IDevice newDevice);
        void RemoveDevice(IDevice device);
        IDevice GetDevice(int id);
        IEnumerable<IDevice> GetAllDevice();
        #endregion

      
        
        #region Status   

        void AddStatus(IStatus Status);
        bool ExistStatus(int id);
        void UpdateStatus(IStatus newStatus);
        void RemoveStatus(IStatus Status);       
        IEnumerable<IStatus> GetAllStatus();
        IStatus GetStatus(int id);
        #endregion 


    }
}
