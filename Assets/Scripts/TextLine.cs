using TMPro;
using UnityEngine;

public class TextLine : MonoBehaviour
{
    public string Line;
    public TextMeshProUGUI TMPComponent;
    private void Awake() {
        TMPComponent = GetComponent<TextMeshProUGUI>();
    }
}
