using Microsoft.EntityFrameworkCore;
using QuickProFixer.Data;
using QuickProFixer.DTOs;
using QuickProFixer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	/// <summary>
	/// Service for managing services.
	/// </summary>
	public class ServiceService : IServiceService
	{
		private readonly ApplicationDbContext _context;

		public ServiceService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
		{
			return await _context.Services
				.Select(s => new ServiceDto
				{
					Id = s.Id,
					Name = s.Name
				})
				.ToListAsync();
		}

		public async Task<ServiceDto?> GetServiceByIdAsync(int id)
		{
			var service = await _context.Services.FindAsync(id);
			if (service == null)
			{
				return null;
			}

			return new ServiceDto
			{
				Id = service.Id,
				Name = service.Name
			};
		}

		public async Task<ServiceDto> CreateServiceAsync(ServiceDto serviceDto)
		{
			var service = new Service
			{
				Name = serviceDto.Name
			};

			_context.Services.Add(service);
			await _context.SaveChangesAsync();

			serviceDto.Id = service.Id;
			return serviceDto;
		}

		public async Task<ServiceDto?> UpdateServiceAsync(ServiceDto serviceDto)
		{
			var service = await _context.Services.FindAsync(serviceDto.Id);
			if (service == null)
			{
				return null;
			}

			service.Name = serviceDto.Name;
			_context.Services.Update(service);
			await _context.SaveChangesAsync();

			return serviceDto;
		}

		public async Task<bool> DeleteServiceAsync(int id)
		{
			var service = await _context.Services.FindAsync(id);
			if (service == null)
			{
				return false;
			}

			_context.Services.Remove(service);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}