
using Environment;
using Environment.Tasks;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "SortSomeInts", menuName = "SortSomeInts Task")]
public class SortInts : Task {

    public int[] IntsToSort;

    public override string Name {
        get {
            return "sortsomeints";
        }
    }

    public override string[] Execute() {

        Debug.Log("Activated SortingInts");
        var returnList = new List<string>();

        returnList.Add("I took these ints: ");
        foreach(int sortInt in IntsToSort) {
            returnList.Add(sortInt.ToString());
        }
        returnList.Add("and sorted them from highest to lowest, like so: ");

        var sortedInts = Utils.SortList(IntsToSort);

        foreach(int sortInt in sortedInts) {
            returnList.Add(sortInt.ToString());
        }

        returnList.Add("Pretty scary huh that computers can do crazy shit like that? AI is takin' over babyyy!");

        return returnList.ToArray();
    }
}

