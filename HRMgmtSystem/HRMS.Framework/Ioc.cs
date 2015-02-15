using HRMS.Core.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Framework
{
    public static class Ioc
    {
        private static TinyIoC.TinyIoCContainer ioc = TinyIoC.TinyIoCContainer.Current;
        public static T Get<T>() where T: class
        {
            return ioc.Resolve<T>();
        }
    }
}
