using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class AsyncDataSource
    {
        public AsyncDataSource()
        {

        }

        private string fastProp;

        public string FastProp
        {
            get { return fastProp; }
            set { fastProp = value; }
        }

        private string slowerProp;

        public string SlowerProp
        {
            get { Thread.Sleep(3000);  return slowerProp; }
            set { slowerProp = value; }
        }


        private string slowestProp;

        public string SlowestProp
        {
            get { Thread.Sleep(5000);  return slowestProp; }
            set { slowestProp = value; }
        }


    }
}
