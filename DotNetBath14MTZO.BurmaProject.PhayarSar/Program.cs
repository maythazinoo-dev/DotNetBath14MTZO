// See https://aka.ms/new-console-template for more information
using DotNetBath14MTZO.BurmaProject.PhayarSar;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

//PhayarSarHttpClientService phayarSarHttpClientService = new PhayarSarHttpClientService();



//var list = await phayarSarHttpClientService.GetPhayarSar();
//foreach (var item in list)

//{
//    Console.WriteLine(item.title);

//}
//var phayarsar = await phayarSarHttpClientService.GetPhayarSar(2, 3);
//Console.WriteLine(phayarsar);


PhayarSarRestSharpService phayarSarRestSharpService = new PhayarSarRestSharpService();

var phayarLst = await phayarSarRestSharpService.GetPhayarSars();

foreach (var phayarsarItem in phayarLst)
{
    Console.WriteLine(phayarsarItem.title);
}


var phayar = phayarSarRestSharpService.GetPhayarSar(3,5);
Console.WriteLine(phayar);



PhayarSarRefitService phayarSarRefitService = new PhayarSarRefitService();

var phaYarList = await phayarSarRefitService.GetPhayarSars();
foreach(var p in phaYarList)
{
    Console.WriteLine(p.title);
}

var phaYarItem = await phayarSarRefitService.GetPhayarSar(5,5);
Console.WriteLine(phaYarItem);

