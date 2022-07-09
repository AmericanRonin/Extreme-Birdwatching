using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    public UnityEngine.UI.Image watchMeter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(watchMeter.fillAmount > 0)
        {
            watchMeter.fillAmount -= Time.deltaTime * 0.1f;
        }
    }

    public void CheckIfWatched()
    {
        watchMeter.fillAmount += 0.1f;
    }
}
