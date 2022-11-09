using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stages : MonoBehaviour
{
    public bool isWorking = false; //used to keep track of if the stage is currently going through one cycle of its procedure
    public TMP_Text title; //refrence to the text above each stage
    private string nameOfStage; //storing what to name the stage while it is not working
    private float timer = 0f;
    private float timerMax;
    public Bins outBin; //refrence to the output bin for each stage
    public int seconds; //how many seconds this stage takes to complete one cycle
	public Bins[] inputs; //used to dynamically set the inputs for each stage since each stage may have 0, 1, or more inputs

    public bool CheckPartsQuantity() //check if we have enough parts in stock to complete one cycle of the stage
    {
        for (int i = 0; i < inputs.Length; i++) //for each of the inputs to this stage
        {
            Bins bin = inputs[i];
            if (bin.num < bin.partsPerCar) //if the number of parts currently in the bin is less than the number of parts needed to complete one cycle then return false
            {
                return false;
            }
        }
        return true;
    }

    public void PullFromInputs() //pull from each input bin
    {
        for (int z = 0; z < inputs.Length; z++) //for each of the inputs to this stage
        {
            Bins bin = inputs[z];
            bin.UpdateNumber(bin.num - bin.partsPerCar);
        }
    }

    public bool CheckOutBinCapacity() //check if this stage's output bin is at its maximum capacity
    {
        if (outBin.num < outBin.maxCap) //less than maximum
        {
            return true;
        }
        else //equals maximum
        {
            return false;
        }
    }

    public void PushToOutBin() //add one to the output bin's current capacity
    {
        outBin.UpdateNumber(outBin.num + 1);
    }

    public void FullStageProcedure() //step by step procedure to complete one cycle of the stage
    {
        StartCoroutine(FSP()); //storing all the code for this function in a IEnumerator coroutine so we can use the WaitForSeconds function
    }

    IEnumerator FSP() //
    {
        if (CheckPartsQuantity() == true && CheckOutBinCapacity() == true) //if there are enough parts in stock and if the output bin is not at maximum capacity
        {
            isWorking = true;
            PullFromInputs(); //next we can pull the parts out of the input bins
            yield return new WaitForSeconds(seconds);
            PushToOutBin(); //lastly, we can push one completed part to this stage's output bin
            isWorking = false;
            title.text = nameOfStage;
            timer = 0f;
        }
    }

    void FixedUpdate() //FixedUpdate runs 50 times every second so I'm using that as a timer to keep track of stage progress %
    {
        if (isWorking == true)
        {
            timer++;
            float percent = Mathf.Round((timer / timerMax) * 100);
            title.text = percent.ToString() + "%";
        }
    }

    void Start()
    {
        nameOfStage = title.text;
        timerMax = seconds * 50f;
    }

    void Update()
    {
        //a new update method will be called each frame so we need to first check if the stage is already working through its procedure
        //otherwise, we can have one stage which will be executing multiple cycles of its procedure at the same time
        if (isWorking == false)
        {
            FullStageProcedure();
        }
    }
}