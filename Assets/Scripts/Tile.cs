using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public int xCoordinate { get; private set; }
    public int yCoordinate { get; private set; }

    [SerializeField] private SpriteRenderer tileVisual;


    public void SetCoordinates(int x, int y) {
        xCoordinate = x;
        yCoordinate = y;
    }

    public void SetTileSprite(Sprite sprite) {
        tileVisual.sprite = sprite;
    }

    public override string ToString() {
        return xCoordinate + "," + yCoordinate;
    }
}
