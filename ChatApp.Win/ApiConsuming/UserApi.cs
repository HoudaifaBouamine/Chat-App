using ChatApp.Models.Dtos.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Win.ApiConsuming
{
    internal class UserApi
    {

        private static readonly HttpClient client = new HttpClient();
        private static readonly string uriBase = "https://localhost:3000";
        public static async Task< UserReadDto? > Login(string userName,string pinCode)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uriBase + $"/chat/User/{userName}/{pinCode}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            string responseString = await responseMessage.Content.ReadAsStringAsync();

            UserReadDto? user = JsonConvert.DeserializeObject<UserReadDto>(responseString);

            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public static async Task<IEnumerable<UserReadProfileDto>?> UserContacts(UserReadDto user)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uriBase + $"/chat/User/{user.UserName}/Contacts");
            string responseString = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<UserReadProfileDto>? users = JsonConvert.DeserializeObject<IEnumerable<UserReadProfileDto>>(responseString);

            return users;
        }

    }
}
