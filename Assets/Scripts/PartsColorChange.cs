using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsColorChange : MonoBehaviour
{
    public Bins parts;

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
        if ((parts.num <= (parts.partsPerCar + parts.partsPerCar)) && (parts.num > parts.partsPerCar))
        {
            SetToYellow();
        }
        else if ((parts.num < parts.partsPerCar) || (parts.num == 0))
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
