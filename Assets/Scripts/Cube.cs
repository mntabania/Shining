using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    private TerrainType terrainType = TerrainType.Grass;

    [SerializeField] private Transform terrainVisualParent;
    

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

    #region Monobehaviours
    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
            LeftClick();
        if (Input.GetMouseButtonDown(1))
            RightClick();
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
}
