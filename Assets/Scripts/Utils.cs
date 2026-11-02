using System;
using UnityEngine;

public static class Utils {
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

    public static Employee[] SortByEarliestEntry(Employee[] employees) {

       
        Employee[] returnArray = new Employee[employees.Length];
        for(int i = 0; i < employees.Length; i++) {
            //var employee = employees[i];
            int currentSmallestIndex = i;
            Debug.Log(employees[i].name);
            for(int j = i; j < employees.Length; j++) {
                if(employees[j].lastEntranceInEngineRoomDateTime < employees[currentSmallestIndex].lastEntranceInEngineRoomDateTime) {
                    currentSmallestIndex = j;
                }
            }
            
            returnArray[i] = employees[currentSmallestIndex];
            Debug.Log(returnArray[i].name);

        }

        for(int i = 0; i < returnArray.Length; i++) {

            Employee employ = returnArray[i];
          //  Debug.Log(employ.name);
           // if(employ.hasEngineRoomClearance)
              //  Debug.Log(employ.lastEntranceInEngineRoom);
        }

        return returnArray;
    }
}
