using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject GroundCube;
    public GameObject WallCube;
    public GameObject MainCamera;
    public GameObject DollarSign;

    private List<string> map = new List<string>();
    private float Multiplier = 8;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera.transform.position = new Vector3(
                       -5, 440, -20);

        BuildDungeon();
    }

    void BuildDungeon()
    {
        var mapTemplate = DungeonGenerator.Dungeons.Create(33, 3, 8, false, 50, 40);

        map = DungeonGenerator.ItemzGenerator.FillMapWithItemz(mapTemplate);

        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j].Equals('.'))
                {
                    Instantiate(GroundCube, new Vector3(j * Multiplier, -1, i * Multiplier), Quaternion.identity).SetActive(true);
                }
                else if (map[i][j].Equals('#'))
                {
                    Instantiate(WallCube, new Vector3(j * Multiplier, 3.50f, i * Multiplier), Quaternion.identity).SetActive(true);
                }
                else if (map[i][j].Equals('@'))
                {
                    var clone = Instantiate(GroundCube, new Vector3(j * Multiplier, -1, i * Multiplier), Quaternion.identity);

                    clone.SetActive(true);

                    //...
                }
                else if (map[i][j].Equals('>'))
                {
                    Instantiate(GroundCube, new Vector3(j * Multiplier, -1, i * Multiplier), Quaternion.identity).SetActive(true);

                    //...
                }
                else if (map[i][j].Equals('$'))
                {
                    Instantiate(GroundCube, new Vector3(j * Multiplier, -1, i * Multiplier), Quaternion.identity).SetActive(true);

                    Instantiate(DollarSign, new Vector3(j * Multiplier, 0, i * Multiplier), Quaternion.identity).SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
