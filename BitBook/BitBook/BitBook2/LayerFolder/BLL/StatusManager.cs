using BitBook2.LayerFolder.DAL;
using BitBook2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitBook2.LayerFolder.BLL
{
    public class StatusManager
    {
        StatusGateway statusGateway = new StatusGateway();
        public List<AllStatus> GetAllStatus()
        {
            return statusGateway.GetAllStatus();
        }

    }
}