// See https://aka.ms/new-console-template for more information
using DotNetBath14MTZO.BurmaProject.PhayarSar;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

PhayarSarHttpClientService phayarSarHttpClientService = new PhayarSarHttpClientService();
var list = await phayarSarHttpClientService.GetAll();

foreach (var item in list)

{
    Console.WriteLine(item.groupId);
    Console.WriteLine(item.title);

}

var phayarsar = await phayarSarHttpClientService.GetPhayarSar(1, 1);
Console.WriteLine("Get By Id " + phayarsar.id + phayarsar.title);


PhayarSarRestSharpService phayarSarRestSharpService = new PhayarSarRestSharpService();

var phayarLst = await phayarSarRestSharpService.GetPhayarSars();

foreach (var phayarItem in phayarLst)
{
    Console.WriteLine(phayarItem.groupId);
    Console.WriteLine(phayarItem.title);
}


var phayar = await phayarSarRestSharpService.GetPhayarSar(3, 2);
Console.WriteLine("Get By Id " + phayar.id + phayar.title);



PhayarSarRefitService phayarSarRefitService = new PhayarSarRefitService();

var phaYarList = await phayarSarRefitService.GetPhayarSars();
foreach (var p in phaYarList)
{
    Console.WriteLine(p.title);
}

var phaYarItem = await phayarSarRefitService.GetPhayarSar(2, 1);
Console.WriteLine("Get By Id" + phaYarItem.id + phaYarItem.title);

