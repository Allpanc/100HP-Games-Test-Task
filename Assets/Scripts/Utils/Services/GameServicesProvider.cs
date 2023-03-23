namespace TestTask100HPGames.Utils.Services
{
    public class GameServicesProvider : ServiceLocator<IService>
    {
        public static GameServicesProvider Instance { get; } = new GameServicesProvider(); 
    }
}
