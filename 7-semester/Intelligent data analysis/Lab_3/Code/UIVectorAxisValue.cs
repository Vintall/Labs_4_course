using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIVectorAxisValue : MonoBehaviour
{
    int axis_index;
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] TMP_InputField input_field;
    public TMP_InputField InputField => input_field;
    public void InitializeField(int axis_index)
    {
        this.axis_index = axis_index;
        label.text = $"Axis: \"{axis_index}\"";
    }
}
