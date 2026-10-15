
using Environment.Tasks;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "PrintEmployees", menuName = "PrintEmployees Task")]
public class GetEmployeesTask : Task {
    public Employees employees;
    public TextAsset DataFilePath;
    public override void Execute() {
        employees = JsonUtility.FromJson<Employees>(DataFilePath.text);

        foreach(var employee in employees.employees) {
            Debug.Log(employee.name);
        }
    }
}
