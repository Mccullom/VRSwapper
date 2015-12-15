using UnityEngine;
using System.Collections;
using Valve.VR;

public class VRRoot : MonoBehaviour
{

  static VRRoot sInstance;
  static public VRRoot Instance
  {
    get { return sInstance; }
  }

  static bool sVREnabled;
  static public bool VREnabled
  {
    get { return sVREnabled; }
  }

  #region public Vars

  public GameObject VrCameraRig;
  public GameObject noVrCameraRig;
  public VRAvatar AvatarPrefab;

  public SteamVR_TrackedObject controllerR;
  public SteamVR_TrackedObject controllerL;

  #endregion

  #region private vars

  VRAvatar mAvatar;


  #endregion

  void SetupVRState()
  {

    VrCameraRig.SetActive(VREnabled);
    noVrCameraRig.SetActive(!VREnabled);
    
    if(!VREnabled)
    {
      Camera cam = noVrCameraRig.GetComponentInChildren<Camera>();
      mAvatar.transform.parent = cam.transform;
      mAvatar.transform.localPosition = Vector3.zero;
      mAvatar.transform.localRotation = Quaternion.identity;
    }

  }


	// Use this for initialization
	void Start ()
  {
    sInstance = this;
    sVREnabled = OpenVR.IsHmdPresent();



    mAvatar = GameObject.Instantiate<VRAvatar>(AvatarPrefab);



    SetupVRState();
  }
	
	// Update is called once per frame
	void Update ()
  {
	
	}

}
