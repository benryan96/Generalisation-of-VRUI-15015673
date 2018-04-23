using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour {

    public float red, green, blue;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RedSlider(float value)
    {
        this.red = value;
        SetColour();
    }
    public void GreenSlider(float value)
    {
        this.green = value;
        SetColour();
    }
    public void BlueSlider(float value)
    {
        this.blue = value;
        SetColour();
    }

    public void SetColour()
    {
        GetComponent<Renderer>().sharedMaterial.color = new Color(red, green, blue);
    }
}
