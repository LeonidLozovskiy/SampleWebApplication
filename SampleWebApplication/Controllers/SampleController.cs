using Microsoft.AspNetCore.Mvc;
using Sample.Services.Contract.Abstractions;
using Sample.Services.Contract.Entities;
using SampleWebApplication.Contract.Requests;
using SampleWebApplication.Contract.Responses;
using System;
using System.Threading.Tasks;

namespace SampleWebApplication.Controllers
{
    [Route("{controller}")]
    public class SampleController: BaseApiController
    {
        private readonly ISampleService SampleService;

        public SampleController(
            ISampleService sampleService)
        {
            SampleService = sampleService;
        }

        [HttpGet]
        [Route("SampleEntity/{sampleEntityId}")]
        public Task<IActionResult> GetSampleEntityById(int sampleEntityId)
        {
            return ExecuteWithErrorHandlingAsync(async () =>
            {
                var sampleEntity = await SampleService.GetSampleEntityById(sampleEntityId);
                return Ok(sampleEntity);
            });
        }

        [HttpPost]
        [Route("SampleEntity/Create")]
        public Task<IActionResult> CreateSampleEntityById(CreateSampleEntityApiRequest request)
        {
            return ExecuteWithErrorHandlingAsync(async () =>
            {
                await SampleService.CreateSampleEntity(ToSampleEntity(request));
                return Ok();
            });
        }

        private SampleEntity ToSampleEntity(CreateSampleEntityApiRequest request)
        {
            return new SampleEntity
            {
                Id = request.Id,
            };
        }

        private GetSampleEntityApiResponse ToGetSampleEntityApiResponse(SampleEntity sampleEntity)
        {
            return new GetSampleEntityApiResponse
            {
                Id = sampleEntity.Id,
            };
        }
    }
}
