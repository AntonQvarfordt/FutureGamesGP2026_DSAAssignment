using UnityEngine;
using Environment;
using Environment.Tasks;
using System;
using NUnit.Framework;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GetEmployeeLastEntry", menuName = "GetEmployeeLastEntry Task")]
public class GetEmployeeLastEntry : Task {
    public Employees employees;
    public TextAsset DataFilePath;

    public Employee LastEntry;

    public override string Name {
        get {
            return "getlastentry";
        }
    }

    public override string[] Execute() {
        
        employees = JsonUtility.FromJson<Employees>(DataFilePath.text);

        foreach(var employee in employees.employees) {
            var lastEntrance = DateTime.Parse(employee.lastEntranceInEngineRoom);
            var lastExit = DateTime.Parse(employee.lastExitFromEngineRoom);

            employee.lastEntranceInEngineRoomDateTime = lastEntrance;
            employee.lastExitFromEngineRoomDateTime = lastExit;

            Debug.Log(employee.lastEntranceInEngineRoom + " | " + employee.lastExitFromEngineRoom);
        }

        var compareLastEntry = new List<Employee>();


        for(int i = 1; i < employees.employees.Length; i++) {
            Employee employee = employees.employees[i];
            if(employee.hasEngineRoomClearance)
                compareLastEntry.Add(employee);
        }

        LastEntry = compareLastEntry[0];
        DateTime lastEntranceTime = compareLastEntry[0].lastEntranceInEngineRoomDateTime;


        for(int i = 1; i < compareLastEntry.Count; i++) {
            Employee employee = compareLastEntry[i];
            if (employee.lastEntranceInEngineRoomDateTime > lastEntranceTime) {
                LastEntry = employee;
                lastEntranceTime = employee.lastEntranceInEngineRoomDateTime;
            }
        }

        //var test = Utils.SortByEarliestEntry(employees.employees);

        var returnStrings = new List<string>();
        returnStrings.Add(LastEntry.name + " was last to enter the Engine Room, at: ");
        returnStrings.Add(LastEntry.lastEntranceInEngineRoomDateTime.Hour.ToString() + ":" + LastEntry.lastEntranceInEngineRoomDateTime.Minute + ":" + LastEntry.lastEntranceInEngineRoomDateTime.Second);
        return returnStrings.ToArray();
    }
}
