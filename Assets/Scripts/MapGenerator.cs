using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public static MapGenerator instance = null;

    [Header("Map Settings")]
    [SerializeField] private int mapX;
    [SerializeField] private int mapY;
    [SerializeField] private int mapZ;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform centerObj;

    [Space(10)]
    [Header("Terrain Visuals")]
    [SerializeField] private TerrainVisualsDictionary terrainVisuals;


    #region Monobehaviours
    private void Awake() {
        instance = this;
        GenerateMap();
    }
    #endregion

    public void GenerateMap() {
        for (int x = 0; x <= mapX; x++) { //x-axis
            for (int y = 0; y <= mapY; y++) { //y-axis
                for (int z = 0; z <= mapZ; z++) { //z-axis
                    GameObject tileGO = GameObject.Instantiate(cubePrefab, new Vector3(x, y, z), Quaternion.identity, this.transform);
                    tileGO.name = x + "," + y + "," + z;
                    Cube cube = tileGO.GetComponent<Cube>();
                    if (mapX/2 == x && mapY/2 == y && mapZ/2 == z) {
                        centerObj.position = tileGO.transform.position;
                    }
                    if (y > 0) {
                        cube.SetTerrain(TerrainType.Blank);
                    }
                }
            }
        }
    }

    #region Tile Visuals
    public List<GameObject> GetTerrainVisualChoices(TerrainType type) {
        return terrainVisuals[type];
    }
    #endregion

}
