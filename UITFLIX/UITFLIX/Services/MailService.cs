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
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(60)
        };
        private readonly string _accessToken;

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
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"Lỗi: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
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
