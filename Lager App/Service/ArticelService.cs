using Lager_App.DBContext;
using Lager_App.Model;
using Microsoft.EntityFrameworkCore;

namespace Lager_App.Service
{
    public class ArticelService : IArticelService
    {
        private readonly ArticelDBContext _dBContext;
        private readonly ILogger<ArticelService> _logger;

        public ArticelService(ArticelDBContext dBContext, ILogger<ArticelService> logger)
        {
            _dBContext = dBContext;
            _logger = logger;
        }


        /// <summary>
        /// Create new Articel DB Entry 
        /// </summary>
        /// <param name="articel"></param>
        /// <returns>New ArticelNumber</returns>
        /// <exception cref="Exception">If Articelnumer already exists</exception>
        public async Task<int> CreateArticel(Articel articel)
        {
            if (await _dBContext.Articels!.FirstOrDefaultAsync(a => a.ArticelNumber == articel.ArticelNumber) is not null)
            {
                _logger.LogError("{Articel} with this {Articelnumber} already exists", articel, articel.ArticelNumber);
                throw new Exception("DB Entry already exists");
            }

            var result = await _dBContext.Articels!.AddAsync(articel);
            await _dBContext.SaveChangesAsync();

        

            return result.Entity.ArticelNumber;

        }

        /// <summary>
        /// Return all Articel as String
        /// </summary>
        /// <returns></returns>
        public async Task<List<Articel>> GetArticels()
        {
            return await _dBContext.Articels!.ToListAsync();
        }


        /// <summary>
        /// Get Articel via Articelnumber 
        /// </summary>
        /// <param name="Articelnumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Articel> GetArticel(int Articelnumber)
        {
            var Articel = await _dBContext.Articels!.FirstOrDefaultAsync(a => a.ArticelNumber == Articelnumber);

            if (Articel is null)
            {
                throw new Exception("DB Entry not found");
            }

            return Articel;
        }


        /// <summary>
        /// Book Out desired Units if Stock is bigger than and if found
        /// </summary>
        /// <param name="Articelnumber"></param>
        /// <param name="DesiredUnits"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task BookOutArticel(int Articelnumber, int DesiredUnits)
        {
            var Articel = await _dBContext.Articels!.FirstOrDefaultAsync(a => a.ArticelNumber == Articelnumber);

            if (Articel is null)
            {
                throw new Exception("DB Entry not found");
            }

            if (DesiredUnits > Articel.Count)
            {
                throw new Exception($"Count: {Articel.Count} is less than desired: {DesiredUnits}");
            }

            Articel.Count = Articel.Count - DesiredUnits;

            await _dBContext.SaveChangesAsync();
        }


        /// <summary>
        /// Adds Units to Stock
        /// </summary>
        /// <param name="Articelnumber"></param>
        /// <param name="Units"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task BookInArticel(int Articelnumber, int Units)
        {
            var Articel = await _dBContext.Articels!.FirstOrDefaultAsync(a => a.ArticelNumber == Articelnumber);

            if (Articel is null)
            {
                throw new Exception("DB Entry not found");
            }



            Articel.Count = Articel.Count + Units;

            await _dBContext.SaveChangesAsync();
        }


        /// <summary>
        /// Delete Articel if exists
        /// </summary>
        /// <param name="Articelnumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteArticel(int Articelnumber)
        {
            var Articel = await _dBContext.Articels!.FirstOrDefaultAsync(a => a.ArticelNumber == Articelnumber);

            if (Articel is null)
            {
                return;
            }

            _dBContext.Articels!.Remove(Articel);



            await _dBContext.SaveChangesAsync();
        }


        /// <summary>
        /// Change existing Articel based on Articelnumber
        /// </summary>
        /// <param name="Articelnumber"></param>
        /// <param name="Name"></param>
        /// <param name="Price"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ChangeArticel(int Articelnumber, string Name, float Price)
        {
            var Articel = await _dBContext.Articels!.FirstOrDefaultAsync(a => a.ArticelNumber == Articelnumber);

            if (Articel is null)
            {
                throw new Exception("DB Entry not found");
            }

            Articel.Name = Name;
            Articel.Price = Price;

            await _dBContext.SaveChangesAsync();
        }

    }
}
