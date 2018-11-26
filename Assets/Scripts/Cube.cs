using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    [SerializeField] private Transform terrainVisualParent;
    [SerializeField] private GameObject highlightGO;

    public int xCoordinate;
    public int yCoordinate;
    public int zCoordinate;

    private TerrainType terrainType = TerrainType.Grass;
    private Dictionary<CubeNeighbourDirection, Cube> neighbours;

    public void SetTerrain(TerrainType terrainType) {
        if (this.terrainType != terrainType) {
            this.terrainType = terrainType;
            List<GameObject> choices = MapGenerator.instance.GetTerrainVisualChoices(terrainType);
            Utilities.DestroyChildren(terrainVisualParent);
            if (choices.Count > 0) {
                GameObject newVisualGO = GameObject.Instantiate(choices[Random.Range(0, choices.Count)], terrainVisualParent);
                newVisualGO.transform.localPosition = Vector3.zero;
            }
        }
    }

    public void FindNeighbours(Cube[,,] map) {
        neighbours = new Dictionary<CubeNeighbourDirection, Cube>();
        Point thisPoint = new Point(xCoordinate, yCoordinate, zCoordinate);
        foreach (KeyValuePair<CubeNeighbourDirection, Point> kvp in possibleExits) {
            CubeNeighbourDirection currDir = kvp.Key;
            Point exit = kvp.Value;
            Point result = exit.Compute(thisPoint);
            if (Utilities.IsInRange(result.x, 0, MapGenerator.instance.mapX) && 
                Utilities.IsInRange(result.y, 0, MapGenerator.instance.mapY) &&
                Utilities.IsInRange(result.z, 0, MapGenerator.instance.mapZ)) {
                neighbours.Add(currDir, MapGenerator.instance.map[result.x, result.y, result.z]);
            }
        }
    }
    public void SetHighlightState(bool state) {
        highlightGO.SetActive(state);
    }

    private void SetNeighboursHiglightState(bool state) {
        foreach (KeyValuePair<CubeNeighbourDirection, Cube> kvp in neighbours) {
            kvp.Value.SetHighlightState(state);
        }
    }

    #region Monobehaviours
    private void OnMouseOver() {
        SetHighlightState(true);
        SetNeighboursHiglightState(true);
        if (Input.GetMouseButtonDown(0))
            LeftClick();
        if (Input.GetMouseButtonDown(1))
            RightClick();
    }
    private void OnMouseExit() {
        SetHighlightState(false);
        SetNeighboursHiglightState(false);
    }
    #endregion

    #region Mouse Behaviour
    private void LeftClick() {
        //Debug.Log("Left Click " + this.name);
    }
    private void RightClick() {
        TerrainType[] types = Utilities.GetEnumValues<TerrainType>();
        int maxTypeIndex = types.Length - 1;

        //Debug.Log("Right Click " + this.name);
        int currentTerrain = (int)terrainType;
        int nextTerrain = currentTerrain + 1;

        if (nextTerrain > maxTypeIndex) {
            nextTerrain = 0;
        }
        SetTerrain((TerrainType)nextTerrain);
    }
    #endregion

    public Dictionary<CubeNeighbourDirection, Point> possibleExits {
        get {
            return new Dictionary<CubeNeighbourDirection, Point>() {
                {CubeNeighbourDirection.Back, new Point(0,0,1) }, //back
                {CubeNeighbourDirection.Up, new Point(0,1,0) }, //up
                {CubeNeighbourDirection.Right, new Point(1,0,0) }, //right
                {CubeNeighbourDirection.Down, new Point(0,-1,0) }, //down
                {CubeNeighbourDirection.Left, new Point(-1,0,0) }, //left
                {CubeNeighbourDirection.Front, new Point(0,0,-1) }, //front
            };
        }
    }
}

public struct Point {
    public int x;
    public int y;
    public int z;

    public Point(int x, int y, int z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Point Compute(Point otherPoint) {
        return new Point(otherPoint.x + x, otherPoint.y + y, otherPoint.z + z);
    }
}
