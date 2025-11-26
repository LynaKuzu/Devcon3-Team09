using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//AI assisted
public class ChargeBar : MonoBehaviour
{
    
    [SerializeField] private Slider Bar;
    [SerializeField] private TMP_Text BarText;
        public StoneMove stonemove;

    // Start is called before the first frame update
    void Start()
    {
        Bar.maxValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Bar.value = stonemove.ChargeTime;
    }
}
