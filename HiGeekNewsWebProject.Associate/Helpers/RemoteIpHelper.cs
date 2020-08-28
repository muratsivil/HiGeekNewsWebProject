using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HiGeekNewsWebProject.Associate.Helpers
{
    public class RemoteIpHelper
    {
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "Local IP adress not found..!";
        }

        public static string IpAddress { get { return GetIpAddress(); } }

    }
}
