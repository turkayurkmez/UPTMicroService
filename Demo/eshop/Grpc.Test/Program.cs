using eshop.Catalog.API.Proto;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress(new Uri("https://localhost:5001"));
var client = new CatalogService.CatalogServiceClient(channel);
var response = client.GetProducts(new EmptyParameter());

Console.WriteLine($"Gelen yanıt:{response.Name} {response.Price} ");
Console.ReadLine();