using QuickProFixer.DTOs;
using QuickProFixer.Data;
using QuickProFixer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	/// <summary>
	/// Service for managing addresses.
	/// </summary>
	public class AddressService : IAddressService
	{
		private readonly ApplicationDbContext _context;

		public AddressService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<AddressDto>> GetAllAddressesAsync()
		{
			return await _context.Addresses
				.Select(a => new AddressDto
				{
					Id = a.Id,
					AddressLine = a.AddressLine,
					Landmark = a.Landmark,
					Town = a.Town,
					LGA = a.LGA,
					State = a.State,
					ZipCode = a.ZipCode,
					Country = a.Country
				})
				.ToListAsync();
		}

		public async Task<AddressDto?> GetAddressByIdAsync(int id)
		{
			var address = await _context.Addresses.FindAsync(id);
			if (address == null)
			{
				return null;
			}

			return new AddressDto
			{
				Id = address.Id,
				AddressLine = address.AddressLine,
				Landmark = address.Landmark,
				Town = address.Town,
				LGA = address.LGA,
				State = address.State,
				ZipCode = address.ZipCode,
				Country = address.Country
			};
		}

		public async Task<AddressDto> CreateAddressAsync(AddressDto addressDto)
		{
			var address = new Address
			{
				AddressLine = addressDto.AddressLine,
				Landmark = addressDto.Landmark,
				Town = addressDto.Town,
				LGA = addressDto.LGA,
				State = addressDto.State,
				ZipCode = addressDto.ZipCode,
				Country = addressDto.Country
			};

			_context.Addresses.Add(address);
			await _context.SaveChangesAsync();

			addressDto.Id = address.Id;
			return addressDto;
		}

		public async Task<AddressDto?> UpdateAddressAsync(AddressDto addressDto)
		{
			var address = await _context.Addresses.FindAsync(addressDto.Id);
			if (address == null)
			{
				return null;
			}

			address.AddressLine = addressDto.AddressLine;
			address.Landmark = addressDto.Landmark;
			address.Town = addressDto.Town;
			address.LGA = addressDto.LGA;
			address.State = addressDto.State;
			address.ZipCode = addressDto.ZipCode;
			address.Country = addressDto.Country;

			_context.Addresses.Update(address);
			await _context.SaveChangesAsync();

			return addressDto;
		}

		public async Task<bool> DeleteAddressAsync(int id)
		{
			var address = await _context.Addresses.FindAsync(id);
			if (address == null)
			{
				return false;
			}

			_context.Addresses.Remove(address);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}