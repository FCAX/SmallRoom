using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    private GameObject lastobj;

    void Start ()
    {
        offset = transform.position - player.transform.position;
	}
	
	void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
        RaycastHit hit;
        if (Physics.Linecast(transform.position, player.transform.position, out hit))
        {
            GameObject obj = hit.collider.gameObject;
            Debug.Log(obj.tag);
            if (obj.tag == "Building")
            {
                Color color = obj.GetComponent<Renderer>().material.color;
                color.a = 0.5f;
                obj.GetComponent<Renderer>().material.SetColor("_Color", color);

                lastobj = obj;
            }
            else
            {
                if (lastobj != null)
                {
                    Color color = lastobj.GetComponent<Renderer>().material.color;
                    color.a = 1f;
                    lastobj.GetComponent<Renderer>().material.SetColor("_Color", color);
                }
            }

        }

    }
}
