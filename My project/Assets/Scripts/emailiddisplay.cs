using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class emailiddisplay : MonoBehaviour
{
    public TextMesh pname;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        pname.text = PlayFabManager.emaut;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(go.transform.position.x, go.transform.position.y + 4.25f, go.transform.position.z);
        gameObject.transform.position = pos;
    }
}
