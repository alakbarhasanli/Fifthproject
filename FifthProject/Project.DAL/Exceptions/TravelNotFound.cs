using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Exceptions
{
	public class TravelNotFound : Exception
	{

		public TravelNotFound(string message) : base(message)
		{
		}
		public TravelNotFound() : base()
		{
		}
	}
}

