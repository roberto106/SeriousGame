using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportadorTexto : MonoBehaviour {

    public TextAsset textFile;
    public string[] textLine;
	// Use this for initialization
	void Start () {
        if (textFile != null)
        {
            textLine = (textFile.text.Split('\n'));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
