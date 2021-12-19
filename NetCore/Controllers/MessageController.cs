using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        IMessage2Service _message2Service;

        public MessageController(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }

        public IActionResult InBox()
        {
            int id = 1;
            var values = _message2Service.GetInboxListByWriter(id).Data;
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var values = _message2Service.GetById(id);
            return View(values.Data);
        }
    }
}
