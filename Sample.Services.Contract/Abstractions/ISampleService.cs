using Sample.Services.Contract.Entities;
using System.Threading.Tasks;

namespace Sample.Services.Contract.Abstractions
{
    public interface ISampleService
    {
        Task<SampleEntity> GetSampleEntityById(int id);

        Task CreateSampleEntity(SampleEntity entity);
    }
}
