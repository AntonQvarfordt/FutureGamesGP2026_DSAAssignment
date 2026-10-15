using Environment.Tasks;

using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Employee {
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public string name;
    public int employeeId;
    public bool hasEngineRoomClearence;
    public string lastEntranceInEngineRoom;
    public string lastExitFromEngineRoom;
}
[System.Serializable]
public class Employees {
    public Employee[] employees;
}

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        public ComputerInput CPInput;
        [SerializeField]
        private Task testTask = null; // Put your stack/queue here :)

        public GenericQueue<Task> tasks = new GenericQueue<Task>();

        public List<Task> TasksToRun = new List<Task>();

        public Task CurrentTask;

        private void Awake() {
            foreach(var task in TasksToRun) {
                tasks.Enqueue(task);
            }

            if(tasks.QueueIsEmpty()) {
                Debug.LogWarning("Queue is empty!");
                return;
            }
            CurrentTask = tasks.Peek();
        }

        public void OnInteract() {
            if(tasks.QueueIsEmpty()) {
                Debug.LogWarning("Queue is empty!");
                return;
            }
            CurrentTask = tasks.Peek();

            CurrentTask.Execute();

            tasks.Dequeue();
        }
    }
}
