using Environment.Tasks;
using System;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        public ComputerInput CPInput;
        [SerializeField]
        private Task testTask = null; // Put your stack/queue here :)

        public void OnInteract() {
            CPInput.Open();
            testTask.Execute();
        }
    }
}
