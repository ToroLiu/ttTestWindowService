using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTWindowsServiceModel.Models
{
    public class TTResult
    {
        public bool Success { get; set; }
        public string Description { get; set; }

        public TTResult() {
            Success = false;
            Description = "failed";
        }

        public void Done() {
            Success = true;
            Description = "Success";
        }
        public void Failed(string description = "failed")
        {
            Success = false;
            Description = description;
        }
    }
}
