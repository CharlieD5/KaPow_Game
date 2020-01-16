using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    public GameObject[] groundPrefabList;

    private float _SpawnLocation;
    private int _NumOfTilesOnScreen;
    private GameObject _Player;
   private float _LengthOfPlatform;
    private List<GameObject> _ActivePlatforms;
    private int _LastPrefabIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        _ActivePlatforms = new List<GameObject>();
        _NumOfTilesOnScreen = 4;
        _Player = GameObject.FindGameObjectWithTag ( "Player"  );
        _SpawnLocation = 10.0f;
        SpawnPlatforms();

        SpawnPlatforms();
        SpawnPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        float temp = _ActivePlatforms.Last().GetComponent<SpriteRenderer>().bounds.size.x;
        //Change 10 later;
        if (_Player.transform.position.x > (_SpawnLocation - _NumOfTilesOnScreen * 10.0f))
        {
            SpawnPlatforms();
            //DeleteTile();
        }
    

    }

    void SpawnPlatforms( int PrefabNumToSpawn =-1)
    {
        GameObject temp;
        int spawnNumber = selectRandomPlatform();
        _LengthOfPlatform = groundPrefabList[spawnNumber].GetComponent<SpriteRenderer>().bounds.size.x;
        
        temp = Instantiate(groundPrefabList[spawnNumber], new Vector3(_SpawnLocation, groundPrefabList[spawnNumber].transform.position.y, 0), Quaternion.identity) as GameObject;
        _SpawnLocation += _LengthOfPlatform;
        _ActivePlatforms.Add(temp);
      
    }

    void DeleteTile()
    {
        Destroy(_ActivePlatforms[0]);
        _ActivePlatforms.RemoveAt(0);
    }
    int selectRandomPlatform()
    {
        if(groundPrefabList.Length <=1)
        return 0;
        int randomIndex = _LastPrefabIndex;
        while (randomIndex == _LastPrefabIndex)
        {
            randomIndex = Random.Range(0,groundPrefabList.Length);
        }
        _LastPrefabIndex = randomIndex;


        return randomIndex;
    }
}
