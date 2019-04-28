using AutoMapper;
using OnTarget.Channel.Business.Data;
using OnTarget.Channel.Business.Services;
using OnTarget.Channel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTarget.Channel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChannelEventService _channelEventService;

        public HomeController(IChannelEventService channelEventService)
        {
            _channelEventService = channelEventService;
        }

        public ActionResult Index()
        {
            var ce = _channelEventService.GetChannelEvents();

            return View(ce);
        }

        public ActionResult Edit(int id)
        {
            var channelEvent = _channelEventService.GetById(id);

            if (null == channelEvent)
                return HttpNotFound();

            var viewModel = Mapper.Map<VideoViewModel>(channelEvent);

            return View("Edit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VideoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", viewModel);
            }

            var channelEvent = _channelEventService.GetById(viewModel.Id);

            if (channelEvent == null)
                return HttpNotFound();

            _channelEventService.Update(Mapper.Map<ChannelEventData>(viewModel));

            return RedirectToAction("Index", "Home");
        }
    }
}