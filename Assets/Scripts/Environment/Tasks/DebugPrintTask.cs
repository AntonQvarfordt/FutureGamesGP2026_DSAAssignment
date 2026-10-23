using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "DebugPrint Task", menuName = "DebugPrint Task")]
    public class DebugPrintTask : Task {
        public override string Name {
            get {
                return "debugprinttask";
            }
        }

        [SerializeField]
        private string textToPrint = "Hi, I'm a test task!";

        public override string[] Execute() {
            var returnString = new string[1];
            returnString[0] = textToPrint;
            return returnString;
        }
    }
}
