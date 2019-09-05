using System.Threading.Tasks;
using jabbR.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace jabbR.Hubs
{
    //[AuthorizeClaim(JabbRClaimTypes.Identifier)]
    public class ChatHub : Hub
    {
        private readonly IJabbrRepository _repository;
        private readonly IChatService _service;
        private readonly IRecentMessageCache _recentMessageCache;
        private readonly IMemoryCache _cache;
        private readonly ContentProviderProcessor _resourceProcessor;
        private readonly ILogger<ChatHub> _logger;
        private readonly ApplicationSettings _settings;

        public ChatHub(ContentProviderProcessor resourceProcessor,
                    IChatService service,
                    IRecentMessageCache recentMessageCache,
                    IJabbrRepository repository,
                    IMemoryCache cache,
                    ILogger<ChatHub> logger,
                    ApplicationSettings settings)
        {
            _resourceProcessor = resourceProcessor;
            _service = service;
            _recentMessageCache = recentMessageCache;
            _repository = repository;
            _cache = cache;
            _logger = logger;
            _settings = settings;
        }

        private string UserAgent
        {
            get
            {
                var httpContext = Context.GetHttpContext();
                if (httpContext?.Request.Headers != null)
                {
                    return httpContext.Request.Headers[HeaderNames.UserAgent];
                }
                return null;
            }
        }

        public override Task OnConnectedAsync()
        {
            _logger.LogDebug("OnConnected({user})", Context.UserIdentifier);

            //CheckStatus();

            return base.OnConnectedAsync();
        }
    }
}
