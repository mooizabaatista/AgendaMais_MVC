using AgendaMais.Application.Interfaces;
using AgendaMais.Util;
using AgendaMais.WorkFlow;
using Microsoft.Extensions.DependencyInjection;

var host = CreateHost.CreateBuilder(args).Build();

var _consultaService = host.Services.GetService<IConsultaService>();

var consultas = _consultaService.GetAllAsync().Result.Where(x => x.Start.AddHours(-1) < DateTime.Now && x.Finished == false)/*.Where(x => x.Notified == false)*/.ToList();



string subject = "Senhor(a) [title], Lembrança de consulta!";
string body = "";
body += $"Prezado(a), [title]<br><br>";
body += $"Estamos passando por aqui, para lembrá-lo da sua consulta.<br>";
body += $"É um prazer tê-lo como nosso estimado cliente!<br><br>";
body += $"Atencsiosamente, à direção.";




foreach (var item in consultas)
{
    //var consultaOld = _consultaService.GetByIdAsync(item.Id).Result;
    //consultaOld.Notified = true;
    //_consultaService.UpdateAsync(consultaOld);
    body = body.Replace("[title]", item.Title);
    SendMail.Send(subject.Replace("[title]", item.Title), body, item.Email);
}