using UnityEngine;
using System.Collections;

namespace VRSwapper
{

  public class VRAvatar : MonoBehaviour
  {
    public HandManager handPrefab;
    public Transform NoVrRight;
    public Transform NoVrLeft;

    HandManager handL;
    HandManager handR;

    public void SetNoVRHands(Transform right, Transform left)
    {
      NoVrRight = right;
      NoVrLeft = left;

      if (!VRRoot.VREnabled)
      {
        if (handR != null)
        {
          handR.transform.parent = NoVrRight;
          handR.transform.localPosition = Vector3.zero;
          handR.transform.localRotation = Quaternion.identity;
          handR.handedness = handCursor.Handedness.right;
        }

        if (handL != null)
        {
          handL.transform.parent = NoVrLeft;
          handL.transform.localPosition = Vector3.zero;
          handL.transform.localRotation = Quaternion.identity;
          handL.handedness = handCursor.Handedness.left;
        }
      }
    }

    // Use this for initialization
    void Start()
    {
      if (handPrefab != null)
      {
        handR = GameObject.Instantiate<HandManager>(handPrefab);
        if (handR != null)
        {
          handR.gameObject.transform.parent = transform;
          handR.handedness = handCursor.Handedness.right;
          handR.SetController(VRRoot.Instance.controllerR);
          if (!VRRoot.VREnabled)
          {
            handR.transform.parent = NoVrRight;
            handR.transform.localPosition = Vector3.zero;
            handR.transform.localRotation = Quaternion.identity;
          }
        }

        handL = GameObject.Instantiate<HandManager>(handPrefab);
        if (handL != null)
        {
          handL.transform.parent = transform;
          handL.handedness = handCursor.Handedness.left;
          handL.SetController(VRRoot.Instance.controllerL);
          if (!VRRoot.VREnabled)
          {
            handL.transform.parent = NoVrLeft;
            handL.transform.localPosition = Vector3.zero;
            handL.transform.localRotation = Quaternion.identity;
          }
        }
      }
    }

    // Update is called once per frame
    void Update()
    {

    }

  }

}
