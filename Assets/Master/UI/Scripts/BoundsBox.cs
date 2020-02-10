using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class BoundsBox : MonoBehaviour
{
    [SerializeField]
    BoundsSelector _selector;
    [SerializeField]
    Image _image;
    RectTransform _rTrans;

    public Color boxColor;

    private void Start()
    {
        if (!_image)
            _image = GetComponent<Image>();
        if (!_rTrans)
            _rTrans = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (_selector.bounds.size != null && _selector.isSelecting)
        {
            _rTrans.anchoredPosition = _selector.initialPoint;
            _image.rectTransform.sizeDelta = _selector.bounds.size * 1000;
           _image.color = boxColor;
        }
        else
        {
            _image.rectTransform.sizeDelta = Vector2.zero;
            _image.color = Color.clear;
        }

    }
}
