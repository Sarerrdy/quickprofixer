using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ServiceController : ControllerBase
	{
		private readonly IServiceService _serviceService;
		private readonly ILogger<ServiceController> _logger;

		public ServiceController(IServiceService serviceService, ILogger<ServiceController> logger)
		{
			_serviceService = serviceService;
			_logger = logger;
		}

		/// <summary>
		/// Gets all services.
		/// </summary>
		/// <returns>A list of all services.</returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllServices()
		{
			_logger.LogInformation("Getting all services");
			var services = await _serviceService.GetAllServicesAsync();
			if (services == null)
			{
				_logger.LogWarning("No services found");
				return NotFound("No services found.");
			}
			return Ok(services);
		}

		/// <summary>
		/// Gets the details of a specific service by ID.
		/// </summary>
		/// <param name="id">The ID of the service.</param>
		/// <returns>The details of the service.</returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceDto>> GetServiceById(int id)
		{
			_logger.LogInformation("Getting service details for ID: {Id}", id);
			var service = await _serviceService.GetServiceByIdAsync(id);
			if (service == null)
			{
				_logger.LogWarning("Service not found for ID: {Id}", id);
				return NotFound("Service not found.");
			}
			return Ok(service);
		}

		/// <summary>
		/// Creates a new service.
		/// </summary>
		/// <param name="serviceDto">The service data transfer object.</param>
		/// <returns>The created service.</returns>
		[HttpPost]
		public async Task<ActionResult<ServiceDto>> CreateService(ServiceDto serviceDto)
		{
			_logger.LogInformation("Creating a new service");
			var createdService = await _serviceService.CreateServiceAsync(serviceDto);
			return CreatedAtAction(nameof(GetServiceById), new { id = createdService.Id }, createdService);
		}

		/// <summary>
		/// Updates an existing service.
		/// </summary>
		/// <param name="id">The ID of the service to update.</param>
		/// <param name="serviceDto">The updated service data transfer object.</param>
		/// <returns>The updated service.</returns>
		[HttpPut("{id}")]
		public async Task<ActionResult<ServiceDto>> UpdateService(int id, ServiceDto serviceDto)
		{
			if (id != serviceDto.Id)
			{
				return BadRequest("Service ID mismatch");
			}

			_logger.LogInformation("Updating service with ID: {Id}", id);
			var updatedService = await _serviceService.UpdateServiceAsync(serviceDto);
			if (updatedService == null)
			{
				_logger.LogWarning("Service not found for ID: {Id}", id);
				return NotFound("Service not found.");
			}
			return Ok(updatedService);
		}

		/// <summary>
		/// Deletes a service by ID.
		/// </summary>
		/// <param name="id">The ID of the service to delete.</param>
		/// <returns>A boolean indicating whether the deletion was successful.</returns>
		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> DeleteService(int id)
		{
			_logger.LogInformation("Deleting service with ID: {Id}", id);
			var result = await _serviceService.DeleteServiceAsync(id);
			if (!result)
			{
				_logger.LogWarning("Service not found for ID: {Id}", id);
				return NotFound("Service not found.");
			}
			return Ok(result);
		}
	}
}