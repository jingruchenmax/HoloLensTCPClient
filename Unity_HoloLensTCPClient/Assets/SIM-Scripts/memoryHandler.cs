using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoryHandler : MonoBehaviour
{
    memoryController _memoryController;
    TCPClientHololens tCPClientHololens;
    GameObject memory;
    
    //public int wozCommand=-1;
    void Start()
    {
        //find the memory controller attached to the main game controller in manager scene
        _memoryController = GameObject.Find("GameController").GetComponent<memoryController>();
        tCPClientHololens = GameObject.Find("GameController").GetComponent<TCPClientHololens>();
    }

    public void CreateMemoryInstance(int patchIndex)
    {
        if (tCPClientHololens.lastPacketToInt == patchIndex)
        {
            int memoryIndex = 0;
            _memoryController.PatchToMemory.TryGetValue(patchIndex, out memoryIndex);
            memory = GameObject.Instantiate(_memoryController.memories[memoryIndex], this.transform);
        }
    }

    public void DeleteMemoryInstance()
    {
        Destroy(memory);
    }
}
