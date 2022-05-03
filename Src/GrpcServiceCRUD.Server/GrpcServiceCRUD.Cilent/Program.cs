// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using GrpcServiceCRUD;
using GrpcServiceCRUD.Protos;

var channel = GrpcChannel.ForAddress("http://localhost:5258");
var client = new Greeter.GreeterClient(channel);

var helloReply =client.SayHello(new HelloRequest()
{
    Name = "Mobe Wu"
});


var client2 = new Algorithmer.AlgorithmerClient(channel);

var sum = await client2.AlgorithmAdditionAsync(new AddTwoValue { Addend = 10 , Augend = 10 });

Console.WriteLine("Hello, World!");
Console.WriteLine(helloReply.Message);
Console.WriteLine(sum.Sum);
Console.ReadLine();
