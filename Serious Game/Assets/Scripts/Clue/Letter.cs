using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Letter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _letter;

    public void SetData(string letter)
    {
        _letter.text = letter;
    }
}
