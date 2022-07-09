using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public BinocularControl bionculars;
    public GameObject birds;

    float tapTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zoomFactor = 1.0f;
        if(bionculars.binocularsOn)
        {
            zoomFactor = zoomFactor / bionculars.binocularZoom;
        }

        if(Input.GetMouseButtonDown(0))
        {
            tapTime = 0.0f;
        }

        if(Input.GetMouseButton(0))
        {
            Camera.main.transform.Translate(-Input.GetAxis("Mouse X") * zoomFactor,
                -Input.GetAxis("Mouse Y") * zoomFactor, 0);

            tapTime += Time.deltaTime;
        }

        if(Input.GetMouseButtonUp(0))
        {
            // check if short tap
            if(tapTime < 0.2f)
            {
                // go through birds and see if watched
                foreach(Transform child in birds.transform)
                {
                    // check that bird is visible
                    if(child.GetComponent<Renderer>().isVisible)
                    {
                        // do watch logic
                        child.GetComponent<BirdControl>().CheckIfWatched();
                    }
                }
            }
        }
    }
}
