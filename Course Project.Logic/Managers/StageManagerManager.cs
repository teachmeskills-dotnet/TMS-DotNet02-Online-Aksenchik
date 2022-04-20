using Course_Project.Data.Models;
using Course_Project.Logic.Exceptions;
using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using CourseProject.Web.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Logic.Managers
{
    /// <inheritdoc cref="IStageManagerManager"/>
    public class StageManagerManager : IStageManagerManager
    {
        private readonly IRepositoryManager<StageManager> _stageManagerRepository;

        public StageManagerManager(IRepositoryManager<StageManager> stageManagerRepository)
        {
            _stageManagerRepository = stageManagerRepository ?? throw new ArgumentNullException(nameof(stageManagerRepository));
        }

        public async Task CreateAsync(StageManagerDto stageManagerDto)
        {
            var stageManager = new StageManager()
            {
                StageManagers = stageManagerDto.StageManagers
            };

            await _stageManagerRepository.CreateAsync(stageManager);
            await _stageManagerRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<StageManagerDto>> GetAllAsync()
        {
            var stageManagerDtos = new List<StageManagerDto>();

            var stageManager = await _stageManagerRepository
                .GetAll()
                .Select(m => new StageManager
                {
                    Id = m.Id,
                    StageManagers = m.StageManagers
                }).ToListAsync();

            foreach (var item in stageManager)
            {
                stageManagerDtos.Add(new StageManagerDto
                {
                    Id = item.Id,
                    StageManagers = item.StageManagers
                });
            }
            return stageManagerDtos;
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _stageManagerRepository
               .GetAll()
               .SingleOrDefaultAsync(m => m.Id == id);

            if (actor is null)
            {
                throw new NotFoundException($"'{nameof(id)}' record not found.", nameof(id));
            }

            _stageManagerRepository.Delete(actor);
            await _stageManagerRepository.SaveChangesAsync();
        }

        public Task<FilmModelResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(StageManagerDto stageManagerDto)
        {
            throw new NotImplementedException();
        }
    }
}
