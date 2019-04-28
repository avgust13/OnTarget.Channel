using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using log4net;
using OnTarget.Channel.Business.Helpers;
using OnTarget.Channel.DataAccess;
using OnTarget.Channel.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTarget.Channel.Business.Services
{
    public class YouTubeProcess : IYouTubeProcess
    {
        private readonly ILog _log;
        private readonly IUnitOfWork _unitOfWork;

        public YouTubeProcess(ILog log, IUnitOfWork unitOfWork)
        {
            _log = log;
            _unitOfWork = unitOfWork;
        }

        public void PopulateChannelEvents(string channelName, DateTime fromDate)
        {
            _log.InfoFormat("Database population on channel {0} from date {1}", channelName, fromDate);

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = Config.YouTubeApiKey,
                ApplicationName = "OnTarget.Channel"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = channelName; // Replace with your search term.
            searchListRequest.MaxResults = 50;

            var searchListResponse = searchListRequest.Execute();
            int i = 0;

            foreach (var searchResult in searchListResponse.Items
                .Where(e => e.Id.Kind.Equals("youtube#video")
                && e.Snippet.ChannelTitle.Equals(channelName)
                && (e.Snippet.PublishedAt.HasValue && e.Snippet.PublishedAt.Value > fromDate)
                ))
            {
                _log.InfoFormat("Adding event with Id - {0}", searchResult.Id.VideoId);
                _unitOfWork.ChannelEvent.Add(new ChannelEvent
                {
                    ChannelEventDate = searchResult.Snippet.PublishedAt.HasValue ? searchResult.Snippet.PublishedAt.Value : DateTime.MinValue,
                    DirectUrl = string.Concat("https://www.youtube.com/watch?v=", searchResult.Id.VideoId),
                    EmbedUrl = string.Format("<iframe id=\"ytplayer\" type=\"text/html\" width=\"640\" height=\"360\" src=\"https://www.youtube.com/embed/{0}\" frameborder=\"0\"></iframe>", searchResult.Id.VideoId),
                    Thumbnail = searchResult.Snippet.Thumbnails.Default__.Url,
                    Title = searchResult.Snippet.Title,
                    CreatedDate = DateTime.UtcNow
                });
                i++;

            }
            _unitOfWork.Complete();
            _log.InfoFormat("Added {0} events for channel {1}", i, channelName);
        }
    }
}
