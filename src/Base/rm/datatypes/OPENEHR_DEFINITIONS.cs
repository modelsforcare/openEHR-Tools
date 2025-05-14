using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.rm.datatypes
{
    public class OPENEHR_DEFINITIONS
    {

		private string _local_terminology_id = "local";

		public string Local_terminology_id
        {
			get { return _local_terminology_id; }
			set { _local_terminology_id = value; }
		}
	}
}
