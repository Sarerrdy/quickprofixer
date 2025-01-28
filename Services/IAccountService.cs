using QuickProFixer.DTOs;
using QuickProFixer.Models;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
    /// <summary>
    /// Defines methods for account-related operations.
    /// </summary>
    public interface IAccountService
    {
        Task<ApplicationUser> RegisterUserAsync(RegisterUserDto registerUserDto, string password);
        /// <summary>
        /// Registers a new Fixer.
        /// </summary>
        /// <param name="fixerDto">The Fixer data transfer object.</param>
        /// <param name="password">The password for the Fixer.</param>
        /// <returns>The registered Fixer.</returns>
        Task<Fixer> RegisterFixerAsync(FixerDto fixerDto, string password);

        /// <summary>
        /// Registers a new Client.
        /// </summary>
        /// <param name="clientDto">The Client data transfer object.</param>
        /// <param name="password">The password for the Client.</param>
        /// <returns>The registered Client.</returns>
        Task<Client> RegisterClientAsync(ClientDto clientDto, string password);

        /// <summary>
        /// Uploads a verification document for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="documentPath">The path to the verification document.</param>
        /// <param name="isFixer">Indicates if the user is a Fixer.</param>
        /// <returns>A boolean indicating whether the upload was successful.</returns>
        Task<bool> UploadVerificationDocumentAsync(int userId, string documentPath, bool isFixer);

        /// <summary>
        /// Checks the registration status of a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="isFixer">Indicates if the user is a Fixer.</param>
        /// <returns>A boolean indicating whether the user is verified.</returns>
        Task<bool> CheckRegistrationStatusAsync(int userId, bool isFixer);
    }
}