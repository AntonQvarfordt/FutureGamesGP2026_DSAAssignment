
using Environment;
using Environment.Tasks;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "GetEmployees", menuName = "GetEmployees Task")]
public class GetEmployees : Task {
    public Employees employees;
    public TextAsset DataFilePath;

    public override string Name {
        get {
            return "getemployees";
        }
    }

    public override string[] Execute() {

        employees = JsonUtility.FromJson<Employees>(DataFilePath.text);
        var returnString = new string[employees.employees.Length];

        for(int i = 0; i < employees.employees.Length; i++) {
            Employee employee = employees.employees[i];
            returnString[i] = employee.name;
        }
        return returnString;
    }
}
