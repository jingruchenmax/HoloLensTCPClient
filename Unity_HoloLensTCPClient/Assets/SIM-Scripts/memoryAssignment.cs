using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoryAssignment : MonoBehaviour
{
    memoryController _memoryController;
    // if a patch button is selected, selectedPatchIndex become that number
    // -1 is the default state
    // patchindex starts counting from 0
    public int selectedPatchIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        //find the memory controller attached to the main game controller in manager scene
        _memoryController = GameObject.Find("GameController").GetComponent<memoryController>();
    }

    // Update is called once per frame
    public void AssignMemoryToPatch(int memoryIndex)
    {
        if (selectedPatchIndex == -1)
        {
            Debug.Log("No Patch is Selected!");
        }

        else
        {
            _memoryController.AssignPatch(selectedPatchIndex, memoryIndex);
        }
    }

    public void SelectPatch(int patchIndex)
    {
        selectedPatchIndex = patchIndex; 
    }
}
