using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Popup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI message;
    [SerializeField] Button okay;


    public void Init(Transform canvas, string popupMessage, Action action) {
        message.text = popupMessage;

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;

        okay.onClick.AddListener(() =>
        {
            GameObject.Destroy(this.gameObject);
        });
    }
}
