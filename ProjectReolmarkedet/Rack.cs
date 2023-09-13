using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReolmarkedet
{
    public class Rack
    {
		// Properties
		private int _rackNumber;

		public int RackNumber
		{
			get { return _rackNumber; }
			set { _rackNumber = value; }
		}

		// Constructor
		public Rack(int rackNumber)
		{
			_rackNumber = rackNumber;
		}

	}
}
