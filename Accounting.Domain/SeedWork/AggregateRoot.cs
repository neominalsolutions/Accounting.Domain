using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.SeedWork
{
  public abstract class AggregateRoot:Entity<string>,IAggregateRoot
  {
    
    private List<INotification> _domainEvents;
    public List<INotification> DomainEvents => _domainEvents;

    public void AddDomainEvent(INotification eventItem)
    {
      _domainEvents = _domainEvents ?? new List<INotification>();
      _domainEvents.Add(eventItem);
    }

    public void ClearDomainEvents()
    {
      this.DomainEvents.Clear();
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
      _domainEvents?.Remove(eventItem);
    }
    
  }
}
