using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public GameObject ForwardTilePrefab;
    public GameObject ForwardDiagonalPrefab;
    public GameObject BackwardDiagonalPrefab;
    public GameObject CurrentTile;
    public GameObject Coin;
    public GameObject[] Tiles;
    public GameObject CoinPos;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            SpawnTile();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnTile()
    {
        int randomindexarr = Random.Range(0,3);
        int randomindexarr1 = Random.Range(0,6);
        int coinRand = Random.Range(0,10);
        CoinPos = CurrentTile;
        //Vector3
        //Vector3 cointemp = new Vector3();
        //cointemp = CoinPos.transform.GetChild(0).transform.GetChild(6).position;

        Vector3 temp = CurrentTile.transform.GetChild(0).transform.GetChild(randomindexarr1).position;

        
        CurrentTile =(GameObject)Instantiate(Tiles[randomindexarr],temp, Quaternion.identity);
        temp.y = temp.y + 2f;
        temp.x = temp.x + 1f;

      
        if(coinRand==1)
        Instantiate(Coin, temp, Quaternion.identity);
       




    }

    
    

           
    }








