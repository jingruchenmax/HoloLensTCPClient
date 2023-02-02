using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class readData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //constantly ping the wizard of oz
        var patch = 0;
        if (patch == 0)
        {

        }
        else if (patch == 1)
        {
            //maybe gompei
            SceneManager.LoadScene("GompeiScene");
        }
        else if (patch == 2)
        {
            //maybe video
            SceneManager.LoadScene("VideoScene");
        }
        else if (patch == 3)
        {
            //maybe song
            SceneManager.LoadScene("RascalsScene");
        }
    }
}
