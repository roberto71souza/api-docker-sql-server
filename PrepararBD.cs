using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using DockerCores.Models;

namespace DockerCores
{
    public static class PrepararBD
    {
        public static void Preparar(IApplicationBuilder app)
        {
            using (var servicoscopo = app.ApplicationServices.CreateScope())
            {
                PopularBD(servicoscopo.ServiceProvider.GetService<CoresContext>());
            }
        }
        public static void PopularBD(CoresContext contexto)
        {
            System.Console.WriteLine("Aplicando migracao.... ");
            contexto.Database.Migrate();

            if (!contexto.Cores.Any())
            {
                System.Console.WriteLine("Adicionado dados ...");
                contexto.Cores.AddRange(
                    new Cores() { Nome = "Azul" },
                    new Cores() { Nome = "Verde" },
                    new Cores() { Nome = "Rosa" },
                    new Cores() { Nome = "Vermelho" },
                    new Cores() { Nome = "Amarelo" },
                    new Cores() { Nome = "Lilas" }
                );
                contexto.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Banco de dados ja populado!");
            }
        }

    }
}