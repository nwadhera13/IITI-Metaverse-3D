using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOutfit : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject player;
    public GameObject canvas;
    public Material skaterOutfit;
    public Material cyborgOutfit;
    public Material oldOutfit;
    
    public bool check=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.OverlapSphere(transform.position, 2f, playerLayer).Length == 1)
        {
            check=true;
        }
        else
        {
            check=false;
        }
        if (check == true)
        {
          canvas.SetActive(true);
        }
    }
    public void OutfitToSkate()
    {
        player.GetComponent<SkinnedMeshRenderer>().material = skaterOutfit;
        check=false;
        canvas.SetActive(false);
        transform.position=new Vector3(12.75f,0.63f,20.52f);
    }
    public void OutfitToOld()
    {
        player.GetComponent<SkinnedMeshRenderer>().material = oldOutfit;
        check=false;
        canvas.SetActive(false);
        transform.position=new Vector3(12.75f,0.63f,20.52f);
    }
    public void OutfitToCyborg()
    {
        player.GetComponent<SkinnedMeshRenderer>().material = cyborgOutfit;
        check=false;
        canvas.SetActive(false);
        transform.position=new Vector3(12.75f,0.63f,20.52f);
    }
}
