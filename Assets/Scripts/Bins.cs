using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bins : MonoBehaviour
{
	public TMP_Text numberText; //refrence to the text above each bin
	public int num = 0; //how many parts are currently in the bin
    public int maxCap; //what is the maximum number of parts each bin can hold
    public int partsPerCar; //how many parts from the bin will be used each time a car passes through the stage

    

    public void UpdateNumber(int newNum) //updates the text box above each bin
    {
		numberText.text = this.name + ": \n" + newNum.ToString(); //changes the text to "<Bin Name>: <newNum>"
        num = newNum; //updates the variable which stores how many parts are currently in the bin
	}

    void Start()
    {
        numberText.text = this.name + ": " + num.ToString();
    }

}