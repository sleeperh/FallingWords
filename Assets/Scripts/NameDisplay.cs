using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    public Text nameText;
    public static string currentName;

    private void Update()
    {
        currentName = NameInput.currentName;
        nameText.text = currentName;
    }
}
