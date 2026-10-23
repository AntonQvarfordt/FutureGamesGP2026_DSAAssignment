using UnityEngine;
using Environment.Tasks;

[CreateAssetMenu(fileName = "OpenComputerTask", menuName = "OpenComputerTask")]
public class OpenComputer : Task {
    public override string Name {
        get {
            return "opencomputer";
        }
    }

    public override string[] Execute() {
        var returnArray = new string[0];
        returnArray[0] = "Opening Computer...";
        return returnArray;
    }
}

