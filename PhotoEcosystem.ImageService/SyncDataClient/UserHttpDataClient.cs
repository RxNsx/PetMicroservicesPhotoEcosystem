using AutoMapper;
using Newtonsoft.Json;
using PhotoEcosystem.ImageService.Models;
using PhotoEcosystem.ImageService.SyncDataClient.Models;

namespace PhotoEcosystem.ImageService.SyncDataClient
{
    /// <summary>
    /// HttpClient для связи с сервисом фотографий синхронно
    /// </summary>
    public class UserHttpDataClient : IUserHttpDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration; //TODO: Адрес из конфигурации
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserHttpDataClient(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            this._httpClient = httpClient;
            this._configuration = configuration;
            this._mapper = mapper;
            _httpClient.BaseAddress = new Uri(_configuration["UserServiceAddress"]);
        } 

        public async Task<List<User>> GetAllUsersAsync()
        {
            var result = await _httpClient.GetAsync("/api/user");
            var usersJson = await result.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<HttpUser>>(usersJson);
            return _mapper.Map<List<User>>(users);
        }
    }
}
