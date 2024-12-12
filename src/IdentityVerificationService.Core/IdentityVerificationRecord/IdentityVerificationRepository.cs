using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;
using IdentityVerificationService.IdentityVerificationRecord.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Abp.UI;
using System.Linq.Dynamic.Core.Tokenizer;
using Newtonsoft.Json.Linq;

namespace IdentityVerificationService.IdentityVerificationRecord
{
    public class IdentityVerificationRepository : DomainService, IIdentityVerificationRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public IdentityVerificationRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<string> VerifyBvnAsync(string bvn)
        {
            try
            {
                string baseUrl = _configuration["YouVerify:BaseUrl"];
                string endpoint = _configuration["YouVerify:BVNEndpoint"];
                string apiToken = _configuration["YouVerify:ApiToken"];

                if (string.IsNullOrWhiteSpace(apiToken))
                {
                    throw new Exception("API token is missing or empty in configuration.");
                }

                string url = $"{baseUrl}{endpoint}";

                var request = new IdentityVerificationRequest
                {
                    id = bvn,
                    isSubjectConsent = true,
                    premiumBVN = false,
                    metadata = new Metadata { requestId = Guid.NewGuid().ToString() }
                };

                Logger.Debug($"Sending BVN verification request to: {url}");

                // Serialize the request
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Create an HttpRequestMessage
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                // Add the API token to the headers
                // httpRequestMessage.Headers.Authorization =
                //     new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken);

                _httpClient.DefaultRequestHeaders.Add("token", apiToken);

                Logger.Debug($"HTTP request headers configured with Authorization token.");

                // Send the HTTP request
                var response = await _httpClient.SendAsync(httpRequestMessage);

                Logger.Debug($"Received HTTP response.");

                // Log response details
                Logger.Info($"Received response with status code: {response.StatusCode}");

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Logger.Info($"BVN verification successful: {jsonResponse}");
                    return jsonResponse;
                }

                Logger.Warn($"BVN verification failed with status: {response.StatusCode} and reason: {response.ReasonPhrase}");
                throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                // Log and rethrow or return an error
                Logger.Error($"An error occurred during BVN verification for ID: {bvn}, {ex.Message}, {ex.InnerException}, {ex.StackTrace}");
                throw new UserFriendlyException("An internal error occurred during BVN verification. Please try again later.", ex.Message);
            }
        }

        public async Task<string> VerifyNinAsync(string nin)
        {
            try
            {
                string baseUrl = _configuration["YouVerify:BaseUrl"];
                string endpoint = _configuration["YouVerify:NINEndpoint"];
                string apiToken = _configuration["YouVerify:ApiToken"];

                if (string.IsNullOrWhiteSpace(apiToken))
                {
                    throw new Exception("API token is missing or empty in configuration.");
                }

                string url = $"{baseUrl}{endpoint}";

                var request = new IdentityVerificationNinRequest
                {
                    id = nin, // Use the passed identityId parameter
                    isSubjectConsent = true,
                    premiumNin = false, // If this should be specific to NIN, ensure it is set appropriately
                };

                Logger.Debug($"Sending NIN verification request to: {url}");

                // Serialize the request
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Create an HttpRequestMessage
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                // Add the API token to the headers
                _httpClient.DefaultRequestHeaders.Clear(); // Ensure no previous headers
                _httpClient.DefaultRequestHeaders.Add("token", apiToken);

                Logger.Debug($"HTTP request headers configured with Authorization token.");

                // Send the HTTP request
                var response = await _httpClient.SendAsync(httpRequestMessage);

                Logger.Debug($"Received HTTP response.");

                // Log response details
                Logger.Info($"Received response with status code: {response.StatusCode}");

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Logger.Info($"NIN verification successful: {jsonResponse}");
                    return jsonResponse;
                }

                Logger.Warn($"NIN verification failed with status: {response.StatusCode} and reason: {response.ReasonPhrase}");
                throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                // Log and rethrow or return an error
                Logger.Error($"An error occurred during NIN verification for ID: {nin}, {ex.Message}, {ex.InnerException}, {ex.StackTrace}");
                throw new UserFriendlyException("An internal error occurred during NIN verification. Please try again later.", ex.Message);
            }
        }



        public async Task<string> VerifyDriverLicenseAsync(string driverLicenseNo)
        {
            try
            {
                string baseUrl = _configuration["YouVerify:BaseUrl"];
                string endpoint = _configuration["YouVerify:DriverLicenseEndpoint"];
                string apiToken = _configuration["YouVerify:ApiToken"];

                if (string.IsNullOrWhiteSpace(apiToken))
                {
                    throw new Exception("API token is missing or empty in configuration.");
                }

                string url = $"{baseUrl}{endpoint}";

                var request = new IdentityVerificationDriverLicenseRequest
                {
                    id = driverLicenseNo, // Use the passed identityId parameter
                    isSubjectConsent = true,
                    metadata = new Metadata { requestId = Guid.NewGuid().ToString() }
                };

                Logger.Debug($"Sending Driver's License verification request to: {url}");

                // Serialize the request
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Create an HttpRequestMessage
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                // Add the API token to the headers
                _httpClient.DefaultRequestHeaders.Clear(); // Ensure no previous headers
                _httpClient.DefaultRequestHeaders.Add("token", apiToken);

                Logger.Debug($"HTTP request headers configured with Authorization token.");

                // Send the HTTP request
                var response = await _httpClient.SendAsync(httpRequestMessage);

                Logger.Debug($"Received HTTP response.");

                // Log response details
                Logger.Info($"Received response with status code: {response.StatusCode}");

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Logger.Info($"Driver's License verification successful: {jsonResponse}");
                    return jsonResponse;
                }

                Logger.Warn($"Driver's License verification failed with status: {response.StatusCode} and reason: {response.ReasonPhrase}");
                throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                // Log and rethrow or return an error
                Logger.Error($"An error occurred during Driver's License verification for ID: {driverLicenseNo}, {ex.Message}, {ex.InnerException}, {ex.StackTrace}");
                throw new UserFriendlyException("An internal error occurred during Driver's License verification. Please try again later.", ex.Message);
            }
        }


        public async Task<string> VerifyPhoneNoAsync(string phoneNo)
        {
            try
            {
                // Build the full URL
                string baseUrl = _configuration["YouVerify:BaseUrl"];
                string endpoint = _configuration["YouVerify:PhoneNoEndpoint"];
                string apiToken = _configuration["YouVerify:ApiToken"];

                if (string.IsNullOrWhiteSpace(apiToken))
                {
                    throw new Exception("API token is missing or empty in configuration.");
                }

                string url = $"{baseUrl}{endpoint}";

                // Prepare the request payload
                var request = new IdentityVerificationPhone
                {
                    mobile = phoneNo, // Use the passed mobileNumber parameter
                    isSubjectConsent = true
                };

                Logger.Debug($"Sending phone number verification request to: {url}");

                // Serialize the request
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Create an HttpRequestMessage
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                // Add the API token to the headers
                _httpClient.DefaultRequestHeaders.Clear(); // Ensure no previous headers
                _httpClient.DefaultRequestHeaders.Add("token", apiToken);

                Logger.Debug($"HTTP request headers configured with Authorization token.");

                // Send the HTTP request
                var response = await _httpClient.SendAsync(httpRequestMessage);

                Logger.Debug($"Received HTTP response.");

                // Log response details
                Logger.Info($"Received response with status code: {response.StatusCode}");

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Logger.Info($"Phone number verification successful: {jsonResponse}");
                    return jsonResponse;
                }

                Logger.Warn($"Phone number verification failed with status: {response.StatusCode} and reason: {response.ReasonPhrase}");
                throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                // Log and rethrow or return an error
                Logger.Error($"An error occurred during phone number verification for number: {phoneNo}, {ex.Message}, {ex.InnerException}, {ex.StackTrace}");
                throw new UserFriendlyException("An internal error occurred during phone number verification. Please try again later.", ex.Message);
            }
        }

        public async Task<string> VerifyBusinessAsync(string registrationNumber)
        {
            try
            {
                // Build the full URL
                string baseUrl = _configuration["YouVerify:BaseUrl"];
                string endpoint = _configuration["YouVerify:BusinessEndpoint"];
                string url = $"{baseUrl}{endpoint}";

                // Prepare the request payload
                var request = new IdentityVerificationBusiness
                {
                    registrationNumber = "RC0000000",
                    countryCode = "NG",
                    isConsent = true
                };

                // Serialize the request
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                Logger.Info($"Sending business verification request to: {url}");

                // Make the HTTP POST request
                var response = await _httpClient.PostAsync(url, content);

                // Log response details
                Logger.Info($"Received response with status code: {response.StatusCode}");

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Logger.Info($"Business verification successful: {jsonResponse}");
                    return jsonResponse;
                }

                Logger.Warn($"Business verification failed with status: {response.StatusCode} and reason: {response.ReasonPhrase}");
                return $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                // Log and rethrow or return an error
                Logger.Error($"An error occurred during business verification for registration number: {registrationNumber}", ex);
                throw new UserFriendlyException("An internal error occurred during business verification. Please try again later.");
            }
        }

        public async Task<string> VerifyInternationalPassportAsync(string passportNo)
        {
            try
            {
                string baseUrl = _configuration["YouVerify:BaseUrl"];
                string endpoint = _configuration["YouVerify:InternationalPassportEndpoint"];
                string apiToken = _configuration["YouVerify:ApiToken"];

                if (string.IsNullOrWhiteSpace(apiToken))
                {
                    throw new Exception("API token is missing or empty in configuration.");
                }

                string url = $"{baseUrl}{endpoint}";

                var request = new IdentityVerificationInternationalPassport
                {
                    id = passportNo, // Use the passed identityId parameter
                    isSubjectConsent = true,
                    lastName = "Doe",
                    metadata = new Metadata { requestId = Guid.NewGuid().ToString() }
                };

                Logger.Debug($"Sending International passport verification request to: {url}");

                // Serialize the request
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Create an HttpRequestMessage
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                // Add the API token to the headers
                _httpClient.DefaultRequestHeaders.Clear(); // Ensure no previous headers
                _httpClient.DefaultRequestHeaders.Add("token", apiToken);

                Logger.Debug($"HTTP request headers configured with Authorization token.");

                // Send the HTTP request
                var response = await _httpClient.SendAsync(httpRequestMessage);

                Logger.Debug($"Received HTTP response.");

                // Log response details
                Logger.Info($"Received response with status code: {response.StatusCode}");

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Logger.Info($"International passport verification successful: {jsonResponse}");
                    return jsonResponse;
                }

                Logger.Warn($"International passport verification failed with status: {response.StatusCode} and reason: {response.ReasonPhrase}");
                throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                // Log and rethrow or return an error
                Logger.Error($"An error occurred during International passport verification for ID: {passportNo}, {ex.Message}, {ex.InnerException}, {ex.StackTrace}");
                throw new UserFriendlyException("An internal error occurred during International passporte verification. Please try again later.", ex.Message);
            }
        }

        public async Task<string> VerifyPvcAsync(string pvc)
        {
            try
            {
                string baseUrl = _configuration["YouVerify:BaseUrl"];
                string endpoint = _configuration["YouVerify:PVCEndpoint"];
                string apiToken = _configuration["YouVerify:ApiToken"];

                if (string.IsNullOrWhiteSpace(apiToken))
                {
                    throw new Exception("API token is missing or empty in configuration.");
                }

                string url = $"{baseUrl}{endpoint}";

                var request = new IdentityVerificationPvc
                {
                    id = pvc, // Use the passed identityId parameter
                    isSubjectConsent = true,
                    metadata = new Metadata { requestId = Guid.NewGuid().ToString() }
                };

                Logger.Debug($"Sending pvc verification request to: {url}");

                // Serialize the request
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Create an HttpRequestMessage
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                // Add the API token to the headers
                _httpClient.DefaultRequestHeaders.Clear(); // Ensure no previous headers
                _httpClient.DefaultRequestHeaders.Add("token", apiToken);

                Logger.Debug($"HTTP request headers configured with Authorization token.");

                // Send the HTTP request
                var response = await _httpClient.SendAsync(httpRequestMessage);

                Logger.Debug($"Received HTTP response.");

                // Log response details
                Logger.Info($"Received response with status code: {response.StatusCode}");

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Logger.Info($"pvc verification successful: {jsonResponse}");
                    return jsonResponse;
                }

                Logger.Warn($"pvc verification failed with status: {response.StatusCode} and reason: {response.ReasonPhrase}");
                throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                // Log and rethrow or return an error
                Logger.Error($"An error occurred during pvc verification for ID: {pvc}, {ex.Message}, {ex.InnerException}, {ex.StackTrace}");
                throw new UserFriendlyException("An internal error occurred during pvc verification. Please try again later.", ex.Message);
            }
        }

        public async Task<string> VerifyVninAsync(string Vnin)
        {
            try
            {
                string baseUrl = _configuration["YouVerify:BaseUrl"];
                string endpoint = _configuration["YouVerify:VninEndpoint"];
                string apiToken = _configuration["YouVerify:ApiToken"];

                if (string.IsNullOrWhiteSpace(apiToken))
                {
                    throw new Exception("API token is missing or empty in configuration.");
                }

                string url = $"{baseUrl}{endpoint}";

                var request = new IdentityVerificationVnin
                {
                    id = Vnin, // Use the passed identityId parameter
                    isSubjectConsent = true,
                  
                };

                Logger.Debug($"Sending vnin verification request to: {url}");

                // Serialize the request
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Create an HttpRequestMessage
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                // Add the API token to the headers
                _httpClient.DefaultRequestHeaders.Clear(); // Ensure no previous headers
                _httpClient.DefaultRequestHeaders.Add("token", apiToken);

                Logger.Debug($"HTTP request headers configured with Authorization token.");

                // Send the HTTP request
                var response = await _httpClient.SendAsync(httpRequestMessage);

                Logger.Debug($"Received HTTP response.");

                // Log response details
                Logger.Info($"Received response with status code: {response.StatusCode}");

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Logger.Info($"vnin verification successful: {jsonResponse}");
                    return jsonResponse;
                }

                Logger.Warn($"pvc verification failed with status: {response.StatusCode} and reason: {response.ReasonPhrase}");
                throw new Exception($"Error: {await response.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                // Log and rethrow or return an error
                Logger.Error($"An error occurred during vnin verification for ID: {Vnin}, {ex.Message}, {ex.InnerException}, {ex.StackTrace}");
                throw new UserFriendlyException("An internal error occurred during vnin verification. Please try again later.", ex.Message);
            }
        }
    }
}

