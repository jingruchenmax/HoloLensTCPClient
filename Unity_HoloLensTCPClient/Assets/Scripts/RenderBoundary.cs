using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities;

public class RenderBoundary : MonoBehaviour
{
    // boundary vertex numbering: 
    //   0 --- 1
    //   |     |
    //   3 --- 2
    List<SimpleLineDataProvider> simpleLineDataProvider;
    public List<GameObject> lineTarget;
    // Start is called before the first frame update
    void Start()
    {
        simpleLineDataProvider = new List<SimpleLineDataProvider>();
        UpdateBoundary();
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLastLocation();
        UpdateBoundary();
    }

    void UpdateLastLocation()
    {
        lineTarget[lineTarget.Count - 1].transform.position = lineTarget[0].transform.position;
        lineTarget[lineTarget.Count - 1].transform.position += (lineTarget[2].transform.position - lineTarget[1].transform.position);

    }
    void UpdateBoundary()
    {
        for (int i = 0; i < lineTarget.Count; i++)
        {
            SimpleLineDataProvider temp = lineTarget[i].GetComponentInChildren<SimpleLineDataProvider>();
            if (i != 0)
                temp.EndPoint = new MixedRealityPose(-lineTarget[i].transform.position + lineTarget[i - 1].transform.position);
            else
                temp.EndPoint = new MixedRealityPose(-lineTarget[0].transform.position + lineTarget[lineTarget.Count - 1].transform.position);
            simpleLineDataProvider.Add(temp);
        }
    }
}
