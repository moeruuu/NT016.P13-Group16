using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using MongoDB.Bson;
using System.Windows.Documents;
using System.Windows.Forms;
using UITFLIX.Models;
using System.Windows.Media.Media3D;

namespace UITFLIX.Services
{
    public class MailService
    {
        private readonly string _accessToken;

        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(60)
        };

        public MailService(string accessToken)
        {
            _accessToken = accessToken;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
        }

        public async Task<string> SendEmailAsync(dynamic EmailModel)
        {
            try
            {
                var json = JsonConvert.SerializeObject(EmailModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/Email/Contact", content);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else
                    return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task SaveEmailPasswordAsync(string emailPassword)
        {
            var payload = new
            {
                EmailPassword = emailPassword,
                Name = "",
                Email = "",
                Subject = "",
                Body = "",
                AttachmentPath = ""
            };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/Email/SaveEmailPassword", content);
            response.EnsureSuccessStatusCode();
        }
        public async Task<string?> GetEmailPasswordAsync(bool includeHashedPassword = false)
        {
            try
            {
                var response = await httpClient.GetAsync($"/api/Email/GetEmailPassword?includeHashedPassword={includeHashedPassword}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to retrieve email password: {response.ReasonPhrase}");
                }
                var responseContent = await response.Content.ReadAsStringAsync();

                return !string.IsNullOrWhiteSpace(responseContent) ? responseContent : null;
            }
            //    if (response.IsSuccessStatusCode)
            //    {
            //        return await response.Content.ReadAsStringAsync();
            //    }
            //    return null;
            //}
            catch (Exception ex)
            {
                throw new Exception($"Failed to get email password: {ex.Message}");
            }
        }
        public async Task<JArray?> GetEmails()
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var response = await httpClient.GetAsync($"/api/Email/GetEmails");
                if (response.IsSuccessStatusCode)
                {
                    var emails = await response.Content.ReadAsStringAsync();
                    JArray jarray = JArray.Parse(emails);
                    return jarray;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
