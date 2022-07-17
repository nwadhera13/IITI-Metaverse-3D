using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOutfit : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject player;
    public GameObject outfitText;
    public GameObject canvas;
    public Material skaterOutfit;
    public Material cyborgOutfit;
    public Material oldOutfit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.OverlapSphere(transform.position, 2f, playerLayer).Length == 1)
        {
            outfitText.SetActive(true);
        }
        else
        {
            outfitText.SetActive(false);
        }
        if (outfitText.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canvas.SetActive(true);
            }
        }
    }
    public void OutfitToSkate()
    {
        player.GetComponent<SkinnedMeshRenderer>().material = skaterOutfit;
        canvas.SetActive(false);
    }
    public void OutfitToOld()
    {
        player.GetComponent<SkinnedMeshRenderer>().material = oldOutfit;
        canvas.SetActive(false);
    }
    public void OutfitToCyborg()
    {
        player.GetComponent<SkinnedMeshRenderer>().material = cyborgOutfit;
        canvas.SetActive(false);
    }
}
