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
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserHttpDataClient(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            this._httpClient = httpClient;
            this._mapper = mapper;
            _httpClient.BaseAddress = new Uri(configuration["UserServiceAddress"]);
        } 

        /// <summary>
        /// Получение всех пользователей из сервиса пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                using var client = new HttpClient();
                var result = await _httpClient.GetAsync("/api/users");
                var usersJson = await result.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<HttpUser>>(usersJson);
                return _mapper.Map<List<User>>(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
