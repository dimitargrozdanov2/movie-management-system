using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;

namespace MovieManagement.Services
{
    public class GenreService : IGenreService
    {
        private readonly MovieManagementContext context;
        private readonly IMappingProvider mappingProvider;

        public GenreService(MovieManagementContext context, IMappingProvider mappingProvider)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mappingProvider = mappingProvider ?? throw new ArgumentNullException(nameof(mappingProvider));
        }

        public async Task<ICollection<Genre>> GetAllGenres()
        {
            return await this.context.Genres.ToListAsync();
        }

        public async Task<GenreViewModel> CreateGenreAsync(string name)
        {
            if (await this.context.Genres.AnyAsync(m => m.Name == name))
            {
                throw new ArgumentException($"Genre with '{name}' name already exist!");
            }

            var genre = new Genre() { Name = name, CreatedOn = DateTime.Now };

            await this.context.Genres.AddAsync(genre);
            await this.context.SaveChangesAsync();

            var returnGenre = this.mappingProvider.MapTo<GenreViewModel>(genre);

            return returnGenre;
        }
    }
}
