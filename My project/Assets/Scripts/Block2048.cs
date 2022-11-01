using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block2048 : MonoBehaviour
{
    public int Value;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private TextMeshPro _text;

    public void Init(BlockType type){
        Value = type.Value;
        renderer.color = type.Color;
        _text.text = type.Value.ToString();
    }
}
