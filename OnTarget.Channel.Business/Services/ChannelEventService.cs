using AutoMapper;
using OnTarget.Channel.Business.Data;
using OnTarget.Channel.DataAccess;
using OnTarget.Channel.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.Business.Services
{
    public class ChannelEventService : IChannelEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChannelEventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ChannelEventData data)
        {
            ChannelEvent item = Mapper.Map<ChannelEvent>(data);
            item.CreatedDate = DateTime.UtcNow;

            _unitOfWork.ChannelEvent.Add(item);
            _unitOfWork.Complete();
        }

        public bool Delete(int id)
        {
            var item = _unitOfWork.ChannelEvent.GetById(id);
            if (null == item) return false;

            _unitOfWork.ChannelEvent.Remove(item);
            _unitOfWork.Complete();
            return true;
        }

        public ChannelEventData GetById(int id)
        {
            return Mapper.Map<ChannelEventData>(_unitOfWork.ChannelEvent.GetById(id));
        }

        public IEnumerable<ChannelEventData> GetChannelEvents()
        {
            return Mapper.Map<IEnumerable<ChannelEventData>>(_unitOfWork.ChannelEvent.GetAll());
        }

        public void Update(ChannelEventData channelEvent)
        {
            var item = _unitOfWork.ChannelEvent.GetById(channelEvent.ChannelEventId);

            item.Title = channelEvent.Title;
            item.EmbedUrl = channelEvent.EmbedUrl;
            item.DirectUrl = channelEvent.DirectUrl;

            _unitOfWork.Complete();
        }
    }
}
