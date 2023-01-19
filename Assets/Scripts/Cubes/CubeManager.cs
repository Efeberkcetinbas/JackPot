using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public List<GameObject> cubes=new List<GameObject>();

    public int index;

    private void Start()
    {
        cubes[0].GetComponent<MovementCube>().Move();
    }

    public void StartMove()
    {
        if(index<cubes.Count-1)
        {
            index++;
            cubes[index].GetComponent<MovementCube>().Move();
        }
        
    }
}
