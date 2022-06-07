using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kolokwium2.Models;
using kolokwium2.Models.DTO;
namespace kolokwium2.Service
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<object>> GetMusician(int IdMusician)
        {
            return await _dbContext.Musicians
            .Where(e => e.IdMusician == IdMusician)
            .Select(e => new SomeMusicians
            {
                FirstName = e.Firstname,
                LastName = e.LastName,
                Nickname = e.Nickname,
                Tracks = e.MusicianTracks
                    .Select(e => new SomeMusicianTracks
                    {
                        TrackName = e.Track.TrackName,
                        Duration = e.Track.Duration
                    }).OrderBy(e => e.Duration)
                    .ToList()
            }).ToListAsync();
        }

        public async Task<bool> RemoveMusician(int IdMusician)
        {
            if(_dbContext.Musicians.Any(e => e.IdMusician == IdMusician))
            {
                // var list = await _dbContext.MusicianTracks
                // .Where(e => e.IdMusician == IdMusician)
                // .Select(e => e.Idtrack).ToListAsync();

                // for(var track : list)
                // {
                    
                // }
                // var check = _dbContext.Tracks.Where(e => e.IdMusicAlbum != null)
                // .
                var musician = new Musician() { IdMusician = IdMusician };
                _dbContext.Attach(musician);
                _dbContext.Remove(musician);
                await _dbContext.SaveChangesAsync();
                return true;
            } else return false;
        }
    }
}