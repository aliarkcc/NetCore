using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        IMessage2Service _message2Service;

        public WriterMessageNotification(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }

        public IViewComponentResult Invoke()
        {
            int id = 1;
             var values = _message2Service.GetInboxListByWriter(id).Data;
            return View(values);
        }
    }
}
