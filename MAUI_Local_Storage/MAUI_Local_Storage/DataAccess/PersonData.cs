
using MAUI_Local_Storage.Models;
using Newtonsoft.Json;

namespace MAUI_Local_Storage.DataAccess
{
    public class PersonData
    {
        public async Task<List<Person>> GetPeopleAsync()
        {
            HttpClient client;

            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation
                    ("Accept", "application/json");
                List<Person> people = new List<Person>();

                var response = await client.GetAsync("http://localhost:5147/api/Person");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(content))
                    {
                        people = JsonConvert.DeserializeObject<List<Person>>(content);
                    }
                }
                return people;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                                   
        public async Task<int> SavePersonAsync(Person person)
        {
            HttpClient client;

            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation
                    ("Accept", "application/json");

                var Content = JsonConvert.SerializeObject(person);

                var buff = System.Text.Encoding.UTF8.GetBytes(Content);

                var byteContent = new ByteArrayContent(buff);

                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                HttpResponseMessage response =
                    await client.PostAsync("http://localhost:5147/api/Person", byteContent);
                return response.IsSuccessStatusCode ? 1 : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
       
