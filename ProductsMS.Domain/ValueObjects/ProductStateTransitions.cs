using System.Collections.Generic;
using ProductMS.Domain.Entities;

namespace ProductMS.Domain.ValueObjects
{
    public static class ProductStateTransitions
    {
        private static readonly Dictionary<ProductState, List<ProductState>> ValidTransitions = new()
        {
            { ProductState.Draft, new List<ProductState> { ProductState.Ready, ProductState.Deleted } },
            { ProductState.Ready, new List<ProductState> { ProductState.InAuction, ProductState.Deleted } },
            { ProductState.InAuction, new List<ProductState> { ProductState.Sold, ProductState.Ready } },
            { ProductState.Sold, new List<ProductState>() },
            { ProductState.Deleted, new List<ProductState>() }
        };

        public static bool IsValidTransition(ProductState currentState, ProductState newState)
        {
            // No se permite cambiar al mismo estado
            if (currentState == newState)
                return false;

            // Verificar si la transición es válida
            return ValidTransitions.ContainsKey(currentState) && ValidTransitions[currentState].Contains(newState);
        }

        public static bool IsImmutable(ProductState state)
        {
            // Los productos en subasta o vendidos no se pueden modificar
            return state == ProductState.InAuction || state == ProductState.Sold;
        }
    }
}
