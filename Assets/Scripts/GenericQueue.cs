using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GenericQueue<T>  {
    private List<T> queue;

    public GenericQueue() {
        queue = new List<T>();
    }

    public int Count () {
        return queue.Count;
    }

    public bool QueueIsEmpty () {
        return queue.Count == 0;
    }

    public void Enqueue(T InNewElement) {
        queue.Add(InNewElement);
    }

    public T Peek() {
        if(queue.Count == 0) {
            throw new Exception("queue is empty, cannot peek");
        }

        return queue[0];
    }

    public T Dequeue () {
        if(queue.Count == 0) {
            throw new Exception("queue is empty, cannot peek");
        }

        T topOfQueue = queue[0];
        queue.RemoveAt(index: 0);
        return topOfQueue;
    }

    public void ClearQueue () {
        queue.Clear();
    }

}
