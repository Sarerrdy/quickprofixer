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
	public class AddressController : ControllerBase
	{
		private readonly IAddressService _addressService;
		private readonly ILogger<AddressController> _logger;

		public AddressController(IAddressService addressService, ILogger<AddressController> logger)
		{
			_addressService = addressService;
			_logger = logger;
		}

		/// <summary>
		/// Gets all addresses.
		/// </summary>
		/// <returns>A list of all addresses.</returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AddressDto>>> GetAllAddresses()
		{
			_logger.LogInformation("Getting all addresses");
			var addresses = await _addressService.GetAllAddressesAsync();
			if (addresses == null)
			{
				_logger.LogWarning("No addresses found");
				return NotFound("No addresses found.");
			}
			return Ok(addresses);
		}

		/// <summary>
		/// Gets the details of a specific address by ID.
		/// </summary>
		/// <param name="id">The ID of the address.</param>
		/// <returns>The details of the address.</returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<AddressDto>> GetAddressById(int id)
		{
			_logger.LogInformation("Getting address details for ID: {Id}", id);
			var address = await _addressService.GetAddressByIdAsync(id);
			if (address == null)
			{
				_logger.LogWarning("Address not found for ID: {Id}", id);
				return NotFound("Address not found.");
			}
			return Ok(address);
		}

		/// <summary>
		/// Creates a new address.
		/// </summary>
		/// <param name="addressDto">The address data transfer object.</param>
		/// <returns>The created address.</returns>
		[HttpPost]
		public async Task<ActionResult<AddressDto>> CreateAddress(AddressDto addressDto)
		{
			_logger.LogInformation("Creating a new address");
			var createdAddress = await _addressService.CreateAddressAsync(addressDto);
			return CreatedAtAction(nameof(GetAddressById), new { id = createdAddress.Id }, createdAddress);
		}

		/// <summary>
		/// Updates an existing address.
		/// </summary>
		/// <param name="id">The ID of the address to update.</param>
		/// <param name="addressDto">The updated address data transfer object.</param>
		/// <returns>The updated address.</returns>
		[HttpPut("{id}")]
		public async Task<ActionResult<AddressDto>> UpdateAddress(int id, AddressDto addressDto)
		{
			if (id != addressDto.Id)
			{
				return BadRequest("Address ID mismatch");
			}

			_logger.LogInformation("Updating address with ID: {Id}", id);
			var updatedAddress = await _addressService.UpdateAddressAsync(addressDto);
			if (updatedAddress == null)
			{
				_logger.LogWarning("Address not found for ID: {Id}", id);
				return NotFound("Address not found.");
			}
			return Ok(updatedAddress);
		}

		/// <summary>
		/// Deletes an address by ID.
		/// </summary>
		/// <param name="id">The ID of the address to delete.</param>
		/// <returns>A boolean indicating whether the deletion was successful.</returns>
		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> DeleteAddress(int id)
		{
			_logger.LogInformation("Deleting address with ID: {Id}", id);
			var result = await _addressService.DeleteAddressAsync(id);
			if (!result)
			{
				_logger.LogWarning("Address not found for ID: {Id}", id);
				return NotFound("Address not found.");
			}
			return Ok(result);
		}
	}
}