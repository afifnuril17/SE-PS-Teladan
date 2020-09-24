using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoPlayer : MonoBehaviour, IDragHandler, IPointerDownHandler
{

    [SerializeField]
    private VideoPlayer videoPlayerPro;
    private Image progress;

    private void Awake()
    {
        progress = GetComponent<Image>();
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(videoPlayerPro.frameCount > 0)
        {
            progress.fillAmount = (float)videoPlayerPro.frame / (float)videoPlayerPro.frameCount;

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    private void TrySkip(PointerEventData eventData)
    {
        Vector2 localPoint;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(progress.rectTransform, eventData.position, null, out localPoint))
        {
            float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
            SkipToPercent(pct);
        }

    }
    private void SkipToPercent( float pct)
    {
        var frame = videoPlayerPro.frameCount * pct;
        videoPlayerPro.frame = (long)frame;
    }
}
