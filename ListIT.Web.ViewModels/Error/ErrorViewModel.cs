using System;
using System.Collections.Generic;
using System.Text;

namespace ListIT.Web.ViewModels.Error
{
    public class ErrorViewModel
    {

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
