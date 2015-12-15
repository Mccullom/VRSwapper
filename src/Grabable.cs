using UnityEngine;
using System.Collections;

public class Grabable : MonoBehaviour
{

	// Use this for initialization
	void Start ()
  {
	
	}
	
	// Update is called once per frame
	void Update ()
  {
	
	}

  void OnTriggerEnter(Collider col)
  {
    VRGrabber grabber = col.gameObject.GetComponent<VRGrabber>();
    if (grabber != null)
    {
      grabber.OnInteractEnter(this);
    }
  }

  void OnTriggerExit(Collider col)
  {
    VRGrabber grabber = col.gameObject.GetComponent<VRGrabber>();
    if (grabber != null)
    {
      grabber.OnInteractExit(this);
    }
  }

}
