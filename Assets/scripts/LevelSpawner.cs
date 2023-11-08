using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] model;
    [HideInInspector] 
    public GameObject[] modelprefab = new GameObject[4];

    public GameObject WinPrefab;
    private GameObject temp1, temp2;
    public int level = 1, addOn = 7;
    private float i = 0;
    
    void Start()
    {
        if (level > 9)
            addOn = 0;
        modelselection();
        for ( i = 0; i >-level-addOn; i-=0.5f)
        {
            if (level <= 20)
                temp1 = Instantiate(modelprefab[Random.Range(0, 2)]);
            if (level > 20 && level <= 50)
                temp1 = Instantiate(modelprefab[Random.Range(1, 3)]);
            if (level > 50 && level <= 100)
                temp1 = Instantiate(modelprefab[Random.Range(2, 4)]);
            if (level > 100)
                temp1 = Instantiate(modelprefab[Random.Range(3, 4)]);

            temp1.transform.position = new Vector3(0, i - 0.01f, 0);
            temp1.transform.eulerAngles = new Vector3(0, i * 8, 0);
            
        }

        temp2 = Instantiate(WinPrefab);
        temp2.transform.position = new Vector3(0, i - 0.01f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void modelselection()
    {
        int randomModel = Random.Range(0, 5);

        switch (randomModel)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                    modelprefab[i] = model[i];
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                    modelprefab[i] = model[i+4];
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                    modelprefab[i] = model[i+8];
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                    modelprefab[i] = model[i+12];
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                    modelprefab[i] = model[i+16];
                break;
        }
    }
}
