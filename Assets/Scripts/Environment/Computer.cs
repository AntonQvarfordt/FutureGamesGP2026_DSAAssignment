using Environment.Tasks;

using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;

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
        public InputAction OffKey;
        public static Computer Instance;
        public ComputerInput CPInput;
        public Employees employees;
        [SerializeField]
        public GenericQueue<Task> tasks = new GenericQueue<Task>();
        public List<Task> TasksToRun = new List<Task>();

        public Task CurrentTask;

        private void OnEnable() {
            OffKey.Enable();
        }
        private void OnDisable() {
            OffKey.Disable();
        }

        private void Awake() {
            Instance = this;

            OffKey.performed += HitOffKey;

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

            PCOn();



            //CurrentTask = tasks.Dequeue();

            //CurrentTask.Execute();
        }

        public void PCOff () {
            CPInput.Close();
        }

        public void PCOn() {
            CPInput.Open();
        }

        private void HitOffKey(InputAction.CallbackContext context) {
            PCOff();
        }
    }
}
