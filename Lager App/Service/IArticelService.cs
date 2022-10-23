using Lager_App.Model;

namespace Lager_App.Service
{
    public interface IArticelService
    {

        Task BookInArticel(int Articelnumber, int Units);
        Task BookOutArticel(int Articelnumber, int DesiredUnits);
        Task ChangeArticel(int Articelnumber, string Name, float Price);
        Task<int> CreateArticel(Articel articel);
        Task DeleteArticel(int Articelnumber);
        Task<Articel> GetArticel(int Articelnumber);
        Task<List<Articel>> GetArticels();
    }
}