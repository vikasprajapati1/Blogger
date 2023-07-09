using Core.BusinessObject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class OperationContext
    {
        /// <summary>
        /// Current employee logged in
        /// </summary>
        public BaseUser CurrentUser;
        /// <summary>
        /// holds the value of ip address of the system
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserAgent { get; set; }
        /// <summary>
        /// holds the value of the application section
        /// </summary>
        public ApplicationSection section { get; set; }
        /// <summary>
        /// holds the boolean value for the notification enabled
        /// </summary>
        public bool SendNotificaiton { get; set; }

        public string ActionName
        {
            get
            {
                return "";
            }
        }

        public OperationContext()
        {
        }

        public OperationContext(ApplicationSection applicationSection, bool sendNotificaiton)
        {
            section = applicationSection;
            SendNotificaiton = sendNotificaiton;
        }

        public OperationContext(ApplicationSection applicationSection, bool sendNotificaiton, BaseUser currentEmployee, HttpContext Context)
        {
            section = applicationSection;
            SendNotificaiton = sendNotificaiton;
            CurrentUser = currentEmployee;

            if (Context != null)
            {
                IPAddress = Context.Connection.RemoteIpAddress.ToString();

            }
        }

        public OperationContext(ApplicationSection applicationSection, bool sendNotificaiton, BaseUser currentEmployee, string ipAddress = "", string userAgent = "")
        {
            section = applicationSection;
            SendNotificaiton = sendNotificaiton;
            CurrentUser = currentEmployee;
            IPAddress = ipAddress;
            UserAgent = userAgent;
        }
    }

    /// <summary>
    /// ApplicationSection enum for sections
    /// </summary>
    public enum ApplicationSection
    {
        Main = 1,
        App = 1,
        Api = 2,
        Web = 3,
        Jobs = 4,
        Admin = 5,
        ControlPanel = 2,
        Processors = 6
    }
}
