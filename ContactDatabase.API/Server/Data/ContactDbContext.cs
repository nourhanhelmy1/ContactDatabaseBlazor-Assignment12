using EdgeDB;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using ContactDatabase.API.Shared;

namespace ContactDatabase.API.Data
{
    public class ContactDbContext
    {
        private readonly EdgeDBClient _edgeDbClient;

        public ContactDbContext(EdgeDBClient edgeDbClient)
        {
            _edgeDbClient = edgeDbClient;
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            var result = await _edgeDbClient.QueryAsync<Contact>(
                "SELECT Contact {FirstName := .first_name, LastName := .last_name, Email := .email, Title := .title, Description := .description, DateOfBirth := .date_of_birth, MarriageStatus := .marriage_status }");
            return result.ToList();
        }

        public async Task InsertContactAsync(Contact NewContact)
        {
            var passwordHasher = new PasswordHasher<string>();
            NewContact.Password = passwordHasher.HashPassword(null, NewContact.Password);

            await _edgeDbClient.ExecuteAsync("INSERT Contact { first_name := <str>$first_name, last_name := <str>$last_name, email := <str>$email, title := <str>$title, description := <str>$description, date_of_birth := <datetime>date_of_birth, marriage_status := <bool>marriage_status, username := <str>$username, password := <str>$password, role := <str>$role }",
                new Dictionary<string, object>
                {
                    { "first_name", NewContact.FirstName },
                    { "last_name", NewContact.LastName },
                    { "email", NewContact.Email },
                    { "title", NewContact.Title },
                    { "description", NewContact.Description },
                    { "date_of_birth", NewContact.DateOfBirth },
                    { "marriage_status", NewContact.MarriageStatus },
                    { "username", NewContact.Username },
                    { "password", NewContact.Password },
                    { "role", NewContact.Role },
                });
        }

        public async Task UpdateContactAsync(JsonElement data)
        {
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var contact = JsonSerializer.Deserialize<Contact>(data.GetRawText(), serializerOptions);

            var query = "UPDATE Contact FILTER .username = <str>$Username SET { first_name := <str>$FirstName, last_name := <str>$LastName, email := <str>$Email, title := <str>$Title, description := <str>$Description, date_of_birth := <datetime>$DateOfBirth, marriage_status := <bool>$MarriageStatus, role := <str>$Role }";
            await _edgeDbClient.ExecuteAsync(query, new Dictionary<string, object?>
            {
                    { "first_name", contact.FirstName },
                    { "last_name", contact.LastName },
                    { "email", contact.Email },
                    { "title", contact.Title },
                    { "description", contact.Description },
                    { "date_of_birth", contact.DateOfBirth },
                    { "marriage_status", contact.MarriageStatus },
                    { "username", contact.Username },
                    { "role", contact.Role },
                });
        }
    }
}
