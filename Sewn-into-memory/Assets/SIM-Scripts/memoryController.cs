using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class memoryController : MonoBehaviour
{
    public GameObject[] memories;
    public Dictionary<int, int> PatchToMemory = new Dictionary<int, int>();
    public TextMeshProUGUI text;

    public void AssignPatch(int patchIndex,int memoryIndex)
    {
        if (PatchToMemory.ContainsKey(patchIndex))
        {
            // if the patch is assgiend already, then update the memory to the new assignded memory
            PatchToMemory[patchIndex] = memoryIndex;
        }
        else
        {
            // if the patch is never assigend, then create it
            PatchToMemory.Add(patchIndex, memoryIndex);
        }
        Debug.Log("Memory "+memoryIndex + " has been assigned to Patch " + patchIndex);
        text.text = "Memory " + memoryIndex + " with name " + memories[memoryIndex].name + " has been assigned to Patch " + patchIndex;
    }

}
