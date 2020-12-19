using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RGame {
    public interface Interactable {
        bool ActiveInRange { get; }
        void Interact();
    }
}