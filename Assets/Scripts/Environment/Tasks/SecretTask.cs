using Environment.Tasks;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SecretTask", menuName = "SecretTask Task")]

public class SecretTask : Task {

    public List<int> IntList = new List<int> { 8, 2, 1, 3, 9 };
    public int CompareIndex = 0;
    public override string Name {
        get {
            return "secrettask";
        }
    }

    public override string[] Execute() {
        Debug.Log(CompareIndex);
        var returnString = new string[1];
        var intList = PrintIntList();
        Debug.Log(intList);
        if(CompareIndex >= IntList.Count - 1) {
            Debug.LogWarning("Tried to compare Secret List, but index was too high.");
            CompareIndex = 0;
            return returnString;
        }

        CompareInts(IntList, CompareIndex);

        returnString[0] = PrintIntList();
        Debug.Log(returnString[0]);
        CompareIndex++;
        return returnString;
    }

    private string PrintIntList() {
        string printString = "";
        for(int i = 0; i < IntList.Count; i++) {

            printString += IntList[i];
            printString += " ";
        }
        
        return printString;

    }

    private void CompareInts(List<int> list, int index) {
        var firstInt = list[index];
        var secondInt = list[index + 1];

        if(secondInt < firstInt) {
            Debug.Log(secondInt + " is less than " + firstInt + " - switching places!");
            list[index] = secondInt;
            list[index + 1] = firstInt;
        }
    }
}
