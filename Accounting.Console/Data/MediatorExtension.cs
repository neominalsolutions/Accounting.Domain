using Accounting.Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Console.Data
{
  public static class MediatorExtension
  {
    // db context change tracker özelliği sayesinde entity state değerini added, modified,deleted,attached,detached olduğu yakalayıp IAggregateRoot interfacesinden türeyen tüm nesnelerin domainEventlerini linq ile buluyoruz. 
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx)
    {
      var domainEntities = ctx.ChangeTracker
                              .Entries<IAggregateRoot>()
                              .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

      var domainEvents = domainEntities
          .SelectMany(x => x.Entity.DomainEvents)
          .ToList();

      // artık domainEntities üzerindeki eventleri bulduktan sonra tüm eventleri temizliyoruz.
      domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

      foreach (var domainEvent in domainEvents)
      {
        await mediator.Publish(domainEvent);
      }
        
      
        

    


      // yakaladığımız domain eventleri mediaTr publish methodu ile notify ediyoruz.
      // bu kod sonrasında Domain event handlerlar tetikleniyor.

    }
  }

}
