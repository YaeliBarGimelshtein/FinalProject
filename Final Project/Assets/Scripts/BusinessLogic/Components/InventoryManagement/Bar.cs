using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private Slider slider;
    public Gradient gradient;
    public Image fill;
    
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxBar(int max)
    {
        slider.maxValue = max;
        slider.value = max;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetMinBar(int min)
    {
        slider.minValue = min;
        slider.value = min;
        fill.color = gradient.Evaluate(0f);
    }

    public void SetCurrentBar(int current)
    {
        slider.value = current;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
