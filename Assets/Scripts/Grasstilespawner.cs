using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Grasstilespawner : MonoBehaviour
{
    public static Grasstilespawner Instance;
    [Header("Spawnable prefabs")]
    [SerializeField] GameObject levelPrefab;
    [SerializeField] GameObject tree;
    [SerializeField] GameObject House;

    public static Grid roadGrid;
    [SerializeField] int roadHeight;
    [SerializeField] int roadWidth;
    [SerializeField] float roadSizeX;
    [SerializeField] float roadSizeY;
    [SerializeField] Vector3 roadStartPosition;
    //[SerializeField] float roadSizeZ;

    //Spawnable object list
    List<GameObject> GroundtileList = new();
    //List<GameObject> treeList= new();
    //List<GameObject> houseList = new();

    [SerializeField] Transform TileParent;
    [SerializeField] Transform TreeParent;
    [SerializeField] Transform HouseParent;

    Transform GroundTile;
    List<Vector3> tilePos = new();
    bool isAvailable;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        roadGrid = new Grid(roadHeight, roadWidth, roadSizeX, roadSizeY, roadStartPosition);
    }
    private void Start()
    {
        List<GameObject> tileList = new List<GameObject>();
        GetTiles();
    }


    void GetTiles()
    {
        for (int i = 1; i <= roadHeight; i++)
        {
            for (int j = 1; j <= roadWidth; j++)
            {
                GroundTile = Instantiate(levelPrefab, roadGrid.GetWorldPosition(j, i), Quaternion.identity).transform;
                GroundTile.gameObject.isStatic = true;
                GroundtileList.Add(GroundTile.gameObject);
                GroundTile.SetParent(TileParent);
                tilePos.Add(GroundTile.transform.position);
            }
        }
        spawnTree();
    }
    void spawnTree()
    {
        for (int i = 0; i < GroundtileList.Count; i++)
        {
            GameObject temp = Instantiate(tree, GroundtileList[i].transform.position + new Vector3(Random.Range(0, 8f), tree.transform.localScale.y, Random.Range(0, 8f)), Quaternion.identity);
            temp.isStatic = true;
            //treeList.Add(temp);
            temp.transform.SetParent(TreeParent);
        }
        spawnHouse();
    }
    void spawnHouse()
    {
        for (int i = 0; i < GroundtileList.Count; i++)
        {
            GameObject temp = Instantiate(House, GroundtileList[i].transform.position + new Vector3(Random.Range(0, 7f), 1, Random.Range(0, 7f)), Quaternion.identity);
            temp.isStatic = true;
            //houseList.Add(temp);
            temp.transform.SetParent(HouseParent);
        }
    }
    public void AddTiles(Vector3 newTilePos,Vector3 dir)
    {
        //isAvailable = false;
        //for (int i = 0;i<tilePos.Count;i++)
        //{
        //    if (newTilePos == tilePos[i]) isAvailable = true;
        //}
        //if (!tilePos.Contains(newTilePos))//)!isAvailable)
        //{
        //    GameObject temp = Instantiate(levelPrefab,newTilePos,Quaternion.identity);
        //    temp.isStatic = true;
        //    temp.transform.SetParent(TileParent);
        //    GroundtileList.Add(temp);
        //    tilePos.Add(newTilePos);
        //    Debug.Log("Added new tile");
        //    SpawnTreeSingleTile(newTilePos);
        //    AddSideTiles(addedInz,newTilePos);      
        //}

        for (int i = -3;i<= 3; i++)
        {
            Vector3 pos = newTilePos + (dir * 10 * i);
            if (!tilePos.Exists(npos=>npos.x == pos.x && npos.z==pos.z))//)!isAvailable)
            {
                GameObject temp = Instantiate(levelPrefab, pos, Quaternion.identity);
                temp.isStatic = true;
                temp.transform.SetParent(TileParent);
                GroundtileList.Add(temp);
                tilePos.Add(pos);
                SpawnTreeSingleTile(pos);
            }
        }   
    }
    void SpawnTreeSingleTile(Vector3 newTilePos)
    {
        GameObject temptree = Instantiate(tree, newTilePos + new Vector3(Random.Range(-7f, 8f), tree.transform.localScale.y, Random.Range(-7f, 8f)), Quaternion.identity);
        temptree.isStatic = true;
        //treeList.Add(temptree);
        temptree.transform.SetParent(TreeParent);
        SpawnHouseSingleTile(newTilePos);
    }
    void SpawnHouseSingleTile(Vector3 newTilePos)
    {
        GameObject tempHouse = Instantiate(House, newTilePos + new Vector3(Random.Range(-7f, 8f), 1, Random.Range(-7f, 8f)), Quaternion.identity);
        tempHouse.isStatic = true;
        tempHouse.transform.SetParent(HouseParent);
    }
    void AddSideTiles(bool addedInz,Vector3 addedTilePos)
    {
        if(addedInz)
        {
            
            GameObject temp1 = Instantiate(levelPrefab, addedTilePos+new Vector3(10,0,0), Quaternion.identity);
            temp1.isStatic = true;
            temp1.transform.SetParent(TileParent);
            GroundtileList.Add(temp1);
            tilePos.Add(temp1.transform.position);
            SpawnTreeSingleTile(temp1.transform.position);

            GameObject temp2 = Instantiate(levelPrefab, addedTilePos+new Vector3(20,0,0), Quaternion.identity);
            temp2.isStatic = true;
            temp2.transform.SetParent(TileParent);
            GroundtileList.Add(temp2);
            tilePos.Add(temp2.transform.position);
            SpawnTreeSingleTile(temp2.transform.position);

            GameObject temp3 = Instantiate(levelPrefab, addedTilePos+new Vector3(-10,0,0), Quaternion.identity);
            temp3.isStatic = true;
            temp3.transform.SetParent(TileParent);
            GroundtileList.Add(temp3);
            tilePos.Add(temp3.transform.position);
            SpawnTreeSingleTile(temp3.transform.position);

            GameObject temp4 = Instantiate(levelPrefab, addedTilePos+new Vector3(-20,0,0), Quaternion.identity);
            temp4.isStatic = true;
            temp4.transform.SetParent(TileParent);
            GroundtileList.Add(temp4);
            tilePos.Add(temp4.transform.position);
            SpawnTreeSingleTile(temp4.transform.position);

            GameObject temp5 = Instantiate(levelPrefab, addedTilePos + new Vector3(30, 0, 0), Quaternion.identity);
            temp5.isStatic = true;
            temp5.transform.SetParent(TileParent);
            GroundtileList.Add(temp5);
            tilePos.Add(temp5.transform.position);
            SpawnTreeSingleTile(temp5.transform.position);

            GameObject temp6 = Instantiate(levelPrefab, addedTilePos + new Vector3(-30, 0, 0), Quaternion.identity);
            temp6.isStatic = true;
            temp6.transform.SetParent(TileParent);
            GroundtileList.Add(temp6);
            tilePos.Add(temp6.transform.position);
            SpawnTreeSingleTile(temp6.transform.position);
        }
        else
        {
            GameObject temp1 = Instantiate(levelPrefab, addedTilePos + new Vector3(0, 0, 10), Quaternion.identity);
            temp1.isStatic = true;
            temp1.transform.SetParent(TileParent);
            GroundtileList.Add(temp1);
            tilePos.Add(temp1.transform.position);
            SpawnTreeSingleTile(temp1.transform.position);

            GameObject temp2 = Instantiate(levelPrefab, addedTilePos + new Vector3(0, 0, 20), Quaternion.identity);
            temp2.isStatic = true;
            temp2.transform.SetParent(TileParent);
            GroundtileList.Add(temp2);
            tilePos.Add(temp2.transform.position);
            SpawnTreeSingleTile(temp2.transform.position);

            GameObject temp3 = Instantiate(levelPrefab, addedTilePos + new Vector3(0, 0, -10), Quaternion.identity);
            temp3.isStatic = true;
            temp3.transform.SetParent(TileParent);
            GroundtileList.Add(temp3);
            tilePos.Add(temp3.transform.position);
            SpawnTreeSingleTile(temp3.transform.position);

            GameObject temp4 = Instantiate(levelPrefab, addedTilePos + new Vector3(0, 0, -20), Quaternion.identity);
            temp4.isStatic = true;
            temp4.transform.SetParent(TileParent);
            GroundtileList.Add(temp4);
            tilePos.Add(temp4.transform.position);
            SpawnTreeSingleTile(temp4.transform.position);

            GameObject temp5 = Instantiate(levelPrefab, addedTilePos + new Vector3(0, 0, -30), Quaternion.identity);
            temp5.isStatic = true;
            temp5.transform.SetParent(TileParent);
            GroundtileList.Add(temp5);
            tilePos.Add(temp5.transform.position);
            SpawnTreeSingleTile(temp5.transform.position);

            GameObject temp6 = Instantiate(levelPrefab, addedTilePos + new Vector3(0, 0, 30), Quaternion.identity);
            temp6.isStatic = true;
            temp6.transform.SetParent(TileParent);
            GroundtileList.Add(temp6);
            tilePos.Add(temp6.transform.position);
            SpawnTreeSingleTile(temp6.transform.position);
        }
    }
    
}
