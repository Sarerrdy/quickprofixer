using Microsoft.EntityFrameworkCore;
using QuickProFixer.Data;
using QuickProFixer.DTOs;
using QuickProFixer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public class FixRequestService : IFixRequestService
	{
		private readonly ApplicationDbContext _context;

		public FixRequestService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<FixRequestDto> CreateFixRequestAsync(FixRequestDto fixRequestDto)
		{
			var fixRequest = new FixRequest
			{
				JobDescription = fixRequestDto.JobDescription,
				Location = fixRequestDto.Location,
				PreferredSchedule = fixRequestDto.PreferredSchedule,
				FixerIds = fixRequestDto.FixerIds,
				ClientId = fixRequestDto.ClientId,
				Status = "Pending",
				AddressId = fixRequestDto.AddressId, // Updated
				SpecializationId = fixRequestDto.SpecializationId, // Updated
				SupportingImage = fixRequestDto.SupportingImage != null ? new SupportingFile
				{
					FileName = fixRequestDto.SupportingImage.FileName,
					FileType = fixRequestDto.SupportingImage.FileType,
					FileUrl = fixRequestDto.SupportingImage.FileUrl
				} : null,
				SupportingDocument = fixRequestDto.SupportingDocument != null ? new SupportingFile
				{
					FileName = fixRequestDto.SupportingDocument.FileName,
					FileType = fixRequestDto.SupportingDocument.FileType,
					FileUrl = fixRequestDto.SupportingDocument.FileUrl
				} : null,
				SupportingFiles = fixRequestDto.SupportingFiles
			};

			_context.FixRequests.Add(fixRequest);
			await _context.SaveChangesAsync();

			fixRequestDto.Id = fixRequest.Id;
			return fixRequestDto;
		}

		public async Task<IEnumerable<FixRequestDto>> GetAllFixRequestsForClientAsync(string clientId)
		{
			return await _context.FixRequests
				.Where(fr => fr.ClientId == clientId)
				.Select(fr => new FixRequestDto
				{
					Id = fr.Id,
					JobDescription = fr.JobDescription,
					Location = fr.Location,
					PreferredSchedule = fr.PreferredSchedule,
					FixerIds = fr.FixerIds,
					ClientId = fr.ClientId,
					Status = fr.Status,
					AddressId = fr.AddressId,
					Address = new AddressDto
					{
						Id = fr.Address.Id,
						AddressLine = fr.Address.AddressLine,
						Landmark = fr.Address.Landmark,
						Town = fr.Address.Town,
						LGA = fr.Address.LGA,
						State = fr.Address.State,
						ZipCode = fr.Address.ZipCode,
						Country = fr.Address.Country
					},
					SpecializationId = fr.SpecializationId, // Updated
					Specialization = new ServiceDto
					{
						Id = fr.Specialization.Id,
						Name = fr.Specialization.Name
					},
					SupportingImage = fr.SupportingImage != null ? new SupportingFileDto
					{
						Id = fr.SupportingImage.Id,
						FileName = fr.SupportingImage.FileName,
						FileType = fr.SupportingImage.FileType,
						FileUrl = fr.SupportingImage.FileUrl
					} : null,
					SupportingDocument = fr.SupportingDocument != null ? new SupportingFileDto
					{
						Id = fr.SupportingDocument.Id,
						FileName = fr.SupportingDocument.FileName,
						FileType = fr.SupportingDocument.FileType,
						FileUrl = fr.SupportingDocument.FileUrl
					} : null,
					SupportingFiles = fr.SupportingFiles
				})
				.ToListAsync();
		}

		public async Task<FixRequestDto?> GetFixRequestByIdAsync(int id)
		{
			var fixRequest = await _context.FixRequests
				.Include(fr => fr.SupportingImage)
				.Include(fr => fr.SupportingDocument)
				.Include(fr => fr.Address) // Include Address
				.Include(fr => fr.Specialization) // Include Specialization
				.FirstOrDefaultAsync(fr => fr.Id == id);

			if (fixRequest == null)
			{
				return null;
			}

			return new FixRequestDto
			{
				Id = fixRequest.Id,
				JobDescription = fixRequest.JobDescription,
				Location = fixRequest.Location,
				PreferredSchedule = fixRequest.PreferredSchedule,
				FixerIds = fixRequest.FixerIds,
				ClientId = fixRequest.ClientId,
				Status = fixRequest.Status,
				AddressId = fixRequest.AddressId,
				Address = new AddressDto
				{
					Id = fixRequest.Address.Id,
					AddressLine = fixRequest.Address.AddressLine,
					Landmark = fixRequest.Address.Landmark,
					Town = fixRequest.Address.Town,
					LGA = fixRequest.Address.LGA,
					State = fixRequest.Address.State,
					ZipCode = fixRequest.Address.ZipCode,
					Country = fixRequest.Address.Country
				},
				SpecializationId = fixRequest.SpecializationId, // Updated
				Specialization = new ServiceDto
				{
					Id = fixRequest.Specialization.Id,
					Name = fixRequest.Specialization.Name
				},
				SupportingImage = fixRequest.SupportingImage != null ? new SupportingFileDto
				{
					Id = fixRequest.SupportingImage.Id,
					FileName = fixRequest.SupportingImage.FileName,
					FileType = fixRequest.SupportingImage.FileType,
					FileUrl = fixRequest.SupportingImage.FileUrl
				} : null,
				SupportingDocument = fixRequest.SupportingDocument != null ? new SupportingFileDto
				{
					Id = fixRequest.SupportingDocument.Id,
					FileName = fixRequest.SupportingDocument.FileName,
					FileType = fixRequest.SupportingDocument.FileType,
					FileUrl = fixRequest.SupportingDocument.FileUrl
				} : null,
				SupportingFiles = fixRequest.SupportingFiles
			};
		}

		public async Task<bool> AcceptFixRequestAsync(int requestId, string fixerId)
		{
			var fixRequest = await _context.FixRequests.FindAsync(requestId);
			if (fixRequest == null || !fixRequest.FixerIds.Contains(fixerId))
			{
				return false;
			}

			fixRequest.Status = "Accepted";
			_context.FixRequests.Update(fixRequest);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> RejectFixRequestAsync(int requestId, string fixerId)
		{
			var fixRequest = await _context.FixRequests.FindAsync(requestId);
			if (fixRequest == null || !fixRequest.FixerIds.Contains(fixerId))
			{
				return false;
			}

			fixRequest.Status = "Rejected";
			_context.FixRequests.Update(fixRequest);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}