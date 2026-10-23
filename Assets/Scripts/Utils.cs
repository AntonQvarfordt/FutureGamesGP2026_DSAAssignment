using System;
using UnityEngine;

public static class Utils 
{
    public static int[] SortList(int[] array) {
        //int[] arrayToSort = new int[array.Length];
        Debug.Log(array.Length);
        for(int i = 0; i < array.Length - 1; i++) {
            int currentSmallestIndex = i;
            Debug.Log(array[i]);
            for(int j = i; j < array.Length; j++) {
                if(array[j] > array[currentSmallestIndex]) {
                    currentSmallestIndex = j;
                    Debug.Log("IDX: " + currentSmallestIndex);
                }
            }
            int temp = array[i];
            array[i] = array[currentSmallestIndex];
            array[currentSmallestIndex] = temp;
        }
        return array;
    }


}
