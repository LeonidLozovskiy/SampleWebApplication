using Sample.Repository.Contract.Entities.Models;
using Sample.Repository.Contract.Entities.Projections;
using System.Threading.Tasks;

namespace Sample.Repository.Abstractions
{
    public interface ISampleRepository
    {
        Task<SampleEntityProjection> GetSampleEntityById(int id);

        Task CreateSampleEntity(CreateSampleEntityModel model);
    }
}
