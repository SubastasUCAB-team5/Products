using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Domain.Entities;
using ProductMS.Domain.Exceptions;
using ProductMS.Domain.ValueObjects;

namespace ProductMS.Domain.Entities
{
    public enum ProductState
    {
        Draft,
        Ready,
        InAuction,
        Sold,
        Deleted
    }

    public class Product : Base
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string BasePrice { get; set; } = default!;
        public string Category { get; set; } = default!;
        public List<string> Images { get; set; } = new List<string>();
        public ProductState State { get; set; } = ProductState.Draft;
        public Guid UserId { get; set; } = default!;
        
        protected Product() { }

        public Product(string name, string description, string basePrice, string category, List<string> images, Guid userId, ProductState state = ProductState.Draft)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            BasePrice = basePrice;
            Category = category;
            Images = images ?? new List<string>();
            State = state;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string name, string description, string basePrice, string category, List<string> images, Guid userId)
        {
            if (ProductStateTransitions.IsImmutable(State))
            {
                throw new InvalidOperationException($"No se puede modificar un producto en estado {State}");
            }

            UserId = userId;
            Name = name;
            Description = description;
            BasePrice = basePrice;
            Category = category;
            
            if (images != null && images.Any())
            {
                Images = images;
            }
            
            UpdatedAt = DateTime.UtcNow; 
        }

        public void ChangeState(ProductState newState)
        {
            if (State == newState)
                return;

            if (!ProductStateTransitions.IsValidTransition(State, newState))
            {
                throw new InvalidProductStateTransitionException(State, newState);
            }

            State = newState;
            UpdatedAt = DateTime.UtcNow; 
        }

        public bool CanTransitionTo(ProductState newState)
        {
            return ProductStateTransitions.IsValidTransition(State, newState);
        }

        public bool IsImmutable()
        {
            return ProductStateTransitions.IsImmutable(State);
        }
    }
}
