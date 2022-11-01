using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game2048 : MonoBehaviour{
    [SerializeField] private int width = 4;
    [SerializeField] private int height = 4;
    [SerializeField] private Node2048 nodePrefab;
    [SerializeField] private Block2048 blockPrefab;
    [SerializeField] private SpriteRenderer boardPrefab;
    [SerializeField] private List<BlockType> types;

    private List<Node2048> nodes;
    private List<Block2048> blocks;

    private BlockType GetBlockTypeByValue(int value) => types.First(t => t.Value == value);

    void Start(){
        MakeGrid();
    }

    void MakeGrid(){
        nodes = new List<Node2048>();
        blocks = new List<Block2048>();

        for(int i = 1; i <= width; i++){
            for(int j = 1; j <= height; j++){
                var node = Instantiate(nodePrefab, new Vector2(i, j), Quaternion.identity);
                nodes.Add(node);
            }
        }

        var center = new Vector2((float) width/2 + 0.5f, (float) height/2 + 0.5f);
        var board = Instantiate(boardPrefab, center, Quaternion.identity);
        board.size = new Vector2(width, height);

        Camera.main.transform.position = new Vector3(center.x, center.y, -10);

        SpawnBlocks(2);
    }

    void SpawnBlocks(int amount){

        var freeNodes = nodes.Where(n => n.OccupiedBlock == null).OrderBy(k => Random.value).ToList();

        foreach(var node in freeNodes.Take(amount)){
            var block = Instantiate(blockPrefab, node.Pos, Quaternion.identity);
            block.Init(GetBlockTypeByValue(2));
        }

        if(freeNodes.Count == 1){

            return;
        }
    }

}


[Serializable]
public struct BlockType{
    public int Value;
    public Color Color;
}