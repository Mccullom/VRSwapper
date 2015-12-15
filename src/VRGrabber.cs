using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VRGrabber : MonoBehaviour
{

  public Material matDefault;
  public Material matHighlight;
  
  void SetMaterial(Material mat)
  {
    Renderer rend = gameObject.GetComponent<Renderer>();
    if(rend != null)
    {
      rend.material = mat;
    }
  }


  // Use this for initialization
  void Start ()
  {
    mColliders = new List<GameObject>();
    SetMaterial(matDefault);
  }
	
	// Update is called once per frame
	void Update ()
  {
	
	}

  List<GameObject> mColliders;

  public void OnInteractEnter(Grabable item)
  {
    //Debug.Log("Target collided with object " + col.gameObject.name + ", tag: " + col.gameObject.tag);
    if (!mColliders.Contains(item.gameObject))
    {
      mColliders.Add(item.gameObject);
      if(mColliders.Count > 0)
      {
        SetMaterial(matHighlight);
      }
    }
  }

  public void OnInteractExit(Grabable item)
  {
    mColliders.Remove(item.gameObject);
    if(mColliders.Count == 0)
    {
      SetMaterial(matDefault);
    }
  }
  
}
