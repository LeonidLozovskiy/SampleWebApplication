using Sample.Repository.Abstractions;
using Sample.Repository.Contract.Entities.Models;
using Sample.Repository.Contract.Entities.Projections;
using Sample.Services.Contract.Abstractions;
using Sample.Services.Contract.Entities;
using System;
using System.Threading.Tasks;

namespace SampleServices.Abstractions
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository SampleRepository;

        public SampleService(
            ISampleRepository sampleRepository)
        {
            SampleRepository = sampleRepository;
        }

        public async Task CreateSampleEntity(SampleEntity entity)
        {
            // some bl, validation and etc

            await SampleRepository.CreateSampleEntity(ToCreateSampleEntityModel(entity));
        }

        public async Task<SampleEntity> GetSampleEntityById(int id)
        {
            return ToSampleEntity(await SampleRepository.GetSampleEntityById(id));
        }

        private SampleEntity ToSampleEntity(SampleEntityProjection projection)
        {
            // convert code in service to avoid super huge convert class
            // if service small enought there is not issue
            return new SampleEntity
            {
                Id = projection.Id,
            };
        }

        private CreateSampleEntityModel ToCreateSampleEntityModel(SampleEntity entity)
        {
            return new CreateSampleEntityModel
            {
                Id = entity.Id,
            };
        }
    }
}
