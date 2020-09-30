using Sample.Repository.Abstractions;
using Sample.Repository.Contract.Entities.Models;
using Sample.Repository.Contract.Entities.Projections;
using System;
using System.Threading.Tasks;

namespace Sample.Repository.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        public async Task CreateSampleEntity(CreateSampleEntityModel model)
        {
            //only CRUD work with base only CRUD no business logic
            await Task.Run(() => { return; });
        }

        public async Task<SampleEntityProjection> GetSampleEntityById(int id)
        {
            return await Task.Run(() => { return new SampleEntityProjection { Id = id }; });
        }
    }
}
