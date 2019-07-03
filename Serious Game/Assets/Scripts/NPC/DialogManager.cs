using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _npcName; 
    [SerializeField] private TextMeshProUGUI _npcSpeech; 
    // Start is called before the first frame update
    public void SetData(string npcName,string text)
    {
        _npcName.text = npcName;
        _npcSpeech.text = text;
    }
}
