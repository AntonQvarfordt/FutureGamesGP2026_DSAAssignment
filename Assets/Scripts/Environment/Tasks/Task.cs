using UnityEngine;

namespace Environment.Tasks {
    [System.Serializable]
    public abstract class Task : ScriptableObject {
       public abstract void Execute();
    }
}
