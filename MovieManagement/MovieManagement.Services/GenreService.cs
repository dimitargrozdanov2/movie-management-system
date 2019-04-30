using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Services.Contracts;

namespace MovieManagement.Services
{
    public class GenreService : IGenreService
    {
        private readonly MovieManagementContext context;

        public GenreService(MovieManagementContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<Genre>> GetAllGenres()
        {
            return await this.context.Genres.ToListAsync();
        }
    }
}
