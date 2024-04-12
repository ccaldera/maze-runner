using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ValantDemoApi.Application.Entities;
using ValantDemoApi.Models;

namespace ValantDemoApi.Tests
{
    [TestFixture]
    public class ValantDemoApiTests
    {
        private HttpClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            var factory = new APIWebApplicationFactory();
            this.client = factory.CreateClient();
        }

        [Test]
        public async Task ShouldReturnListOfGames()
        {
            var result = await this.client.GetAsync("/Maze");
            result.EnsureSuccessStatusCode();
            var content = JsonConvert.DeserializeObject<IEnumerable<Maze>>(await result.Content.ReadAsStringAsync());
            
            var body = new CreateMazeRequest()
            {
                Maze = "SOXXXXXXXX\r\nOOOXXXXXXX\r\nOXOOOXOOOO\r\nXXXXOXOXXO\r\nOOOOOOOXXO\r\nOXXOXXXXXO\r\nOOOOXXXXXE"
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            result = await this.client.PostAsync("/Maze", stringContent);
            result.Should().NotBeNull();
            result.EnsureSuccessStatusCode();

            result = await this.client.GetAsync("/Maze");
            result.EnsureSuccessStatusCode();
            content = JsonConvert.DeserializeObject<IEnumerable<Maze>>(await result.Content.ReadAsStringAsync());
            content.Should().NotBeEmpty();
        }

        [Test]
        public async Task ShouldCreateGames()
        {
            var body = new CreateMazeRequest()
            {
                Maze = "SOXXXXXXXX\r\nOOOXXXXXXX\r\nOXOOOXOOOO\r\nXXXXOXOXXO\r\nOOOOOOOXXO\r\nOXXOXXXXXO\r\nOOOOXXXXXE"
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var result = await this.client.PostAsync("/Maze", stringContent);
            result.EnsureSuccessStatusCode();
            var content = JsonConvert.DeserializeObject<Maze>(await result.Content.ReadAsStringAsync());
            content.Should().NotBeNull();
            content.Start.Should().NotBeNull();
            content.End.Should().NotBeNull();
        }

        [Test]
        public async Task ShouldReturnValidMovesGames()
        {
            var body = new CreateMazeRequest()
            {
                Maze = "SOXXXXXXXX\r\nOOOXXXXXXX\r\nOXOOOXOOOO\r\nXXXXOXOXXO\r\nOOOOOOOXXO\r\nOXXOXXXXXO\r\nOOOOXXXXXE"
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var result = await this.client.PostAsync("/Maze", stringContent);
            result.EnsureSuccessStatusCode();

            var content = JsonConvert.DeserializeObject<Maze>(await result.Content.ReadAsStringAsync());
            
            var id = content.Id;

            var movesRequest = new GetNextAvailableMovesRequest()
            {
                Column = 0,
                Row = 0
            };

            stringContent = new StringContent(JsonConvert.SerializeObject(movesRequest), Encoding.UTF8, "application/json");
            result = await this.client.PostAsync($"/Maze/{id}/moves", stringContent);

            var movesResponse = JsonConvert.DeserializeObject<GetNextAvailableMovesResponse>(await result.Content.ReadAsStringAsync());

            movesResponse.Should().NotBeNull();
            movesResponse.Moves.Should().Contain("Down");
            movesResponse.Moves.Should().Contain("Right");
        }

        [Test]
        public async Task ShouldGetByIdGames()
        {
            var body = new CreateMazeRequest()
            {
                Maze = "SOXXXXXXXX\r\nOOOXXXXXXX\r\nOXOOOXOOOO\r\nXXXXOXOXXO\r\nOOOOOOOXXO\r\nOXXOXXXXXO\r\nOOOOXXXXXE"
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var result = await this.client.PostAsync("/Maze", stringContent);
            result.EnsureSuccessStatusCode();

            var content = JsonConvert.DeserializeObject<Maze>(await result.Content.ReadAsStringAsync());

            var id = content.Id;

            result = await this.client.GetAsync($"/Maze/{id}");

            var movesResponse = JsonConvert.DeserializeObject<Maze>(await result.Content.ReadAsStringAsync());

            movesResponse.Should().NotBeNull();
            movesResponse.Id.Should().NotBeEmpty();
            movesResponse.Start.Should().NotBeNull();
            movesResponse.End.Should().NotBeNull();
        }

        [Test]
        public async Task ShouldWinTheGame()
        {
            var body = new CreateMazeRequest()
            {
                Maze = "SOXXXXXXXX\r\nOOOXXXXXXX\r\nOXOOOXOOOO\r\nXXXXOXOXXO\r\nOOOOOOOXXO\r\nOXXOXXXXXO\r\nOOOOXXXXXE"
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var result = await this.client.PostAsync("/Maze", stringContent);
            result.EnsureSuccessStatusCode();

            var content = JsonConvert.DeserializeObject<Maze>(await result.Content.ReadAsStringAsync());

            var id = content.Id;

            var movesRequest = new GetNextAvailableMovesRequest()
            {
                Column = 9,
                Row = 6
            };

            stringContent = new StringContent(JsonConvert.SerializeObject(movesRequest), Encoding.UTF8, "application/json");
            result = await this.client.PostAsync($"/Maze/{id}/moves", stringContent);

            var movesResponse = JsonConvert.DeserializeObject<GetNextAvailableMovesResponse>(await result.Content.ReadAsStringAsync());

            movesResponse.Should().NotBeNull();
            movesResponse.GameEnded.Should().BeTrue();
        }
    }
}
