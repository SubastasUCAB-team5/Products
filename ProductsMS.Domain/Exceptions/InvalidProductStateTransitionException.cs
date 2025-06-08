using System;
using ProductMS.Domain.Entities;

namespace ProductMS.Domain.Exceptions
{
    public class InvalidProductStateTransitionException : Exception
    {
        public ProductState CurrentState { get; }
        public ProductState NewState { get; }

        public InvalidProductStateTransitionException(ProductState currentState, ProductState newState)
            : base($"Transición de estado no válida: no se puede cambiar de {currentState} a {newState}")
        {
            CurrentState = currentState;
            NewState = newState;
        }
    }
}
