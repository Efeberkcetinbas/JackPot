using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Ending")]
    public GameObject successPanel;
    public GameObject failPanel;
    public bool isGameEnd=false;

    public Transform Player;

    private CubeManager cubeManager;

    public List<GameObject> knives=new List<GameObject>();

    [Header("Level Properties")]
    public int AmounOfCube;
    public int HitTarget;
    public float y;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    
    public void UpdateCubeManager()
    {
        cubeManager=FindObjectOfType<CubeManager>();
    }

    public IEnumerator CallCubeManager()
    {
        yield return null;
        cubeManager.StartMove();
    }

    public void UpdateHitAmountCube()
    {
        AmounOfCube=FindObjectOfType<LevelCubeAmount>().AmountOfCubeToHit;
    }

    public void ResetPlayerPosition()
    {
        y=0;
        Player.transform.position=new Vector3(0,0,-9);
    }
    
    public void DeActiveKnives()
    {
        for (int i = 0; i < knives.Count; i++)
        {
            knives[i].SetActive(false);
        }

        HitTarget=0;
    }

    public void ResetTheLevel()
    {
        successPanel.SetActive(false);
        failPanel.SetActive(false);
    }


    public void OpenClose(GameObject[] gameObjects,bool canOpen)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if(canOpen)
                gameObjects[i].SetActive(true);
            else
                gameObjects[i].SetActive(false);
        }
    }

}
