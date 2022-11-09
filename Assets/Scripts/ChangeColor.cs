using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeColor : MonoBehaviour
{
    public Bins outBin;

    public string colorPropertyName = "_Color";
    public Color currentColor;
    Renderer colorRenderer;
    MaterialPropertyBlock colorPropertyBlock;

    Renderer GetRenderer
    {
        get
        {
            if (colorRenderer == null)
                colorRenderer = GetComponent<Renderer>();
            return colorRenderer;
        }
    }

    MaterialPropertyBlock GetPropertyBlock
    {
        get
        {
            if (colorPropertyBlock == null)
                colorPropertyBlock = new MaterialPropertyBlock();
            return colorPropertyBlock;
        }
    }

    public void SetToGreen()
    {
        currentColor = new Color(0f, 1f, 0f, 1f);
    }

    public void SetToYellow()
    {
        currentColor = new Color(1f, 0.92f, 0.016f, 1f);
    }

    public void SetToRed()
    {
        currentColor = new Color(1f, 0f, 0f, 1f);
    }



    // Start is called before the first frame update
    void Start()
    {
        if (Application.isPlaying == false)
            return;
    }

    void FixedUpdate()
    {
        if ((outBin.num >= outBin.maxCap - 10) && (outBin.num < outBin.maxCap))
        {
            SetToYellow();
        }
        else if (outBin.num == outBin.maxCap)
        {
            SetToRed();
        }
        else
        {
            SetToGreen();
        }

        GetRenderer.GetPropertyBlock(GetPropertyBlock);

        GetPropertyBlock.SetColor(colorPropertyName, currentColor);

        GetRenderer.SetPropertyBlock(GetPropertyBlock);
    }

}
