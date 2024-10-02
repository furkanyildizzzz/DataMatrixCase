using DataMatrixCase.Application.Interfaces;
using DataMatrixCase.Application.Interfaces.Repositories;
using DataMatrixCase.Persistence.Context;
using DataMatrixCase.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMatrixCase.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration?.GetConnectionString("SQLConnection")));
            
            serviceCollection.AddTransient<IDataMatrixInfoRepository, DataMatrixInfoRepository>();
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
