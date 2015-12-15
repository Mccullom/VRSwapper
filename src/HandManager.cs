using UnityEngine;
using System.Collections;
using Valve.VR;


namespace VRSwapper
{

  public class HandManager : MonoBehaviour
  {

    public SteamVR_TrackedObject controller;
    public handCursor handCursorPrefab;
    handCursor.Handedness mHandedness;
    public handCursor.Handedness handedness
    {
      get
      {
        if (mHand != null)
        {
          return mHand.handedness;
        }
        return mHandedness;
      }
      set
      {
        mHandedness = value;
        if (mHand != null)
        {
          mHand.handedness = mHandedness;
        }
      }
    }

    public KeyCode rightSwitch;
    public KeyCode leftSwitch;

    int mWeaponIndex;
    GameObject mObj;

    handCursor mHand;

    public void SetController(SteamVR_TrackedObject Controller)
    {
      controller = Controller;
      if (controller != null)
      {
        transform.parent = controller.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
      }
      else
      {
        transform.parent = null;
      }
    }

    void SwitchWeapon()
    {
      if (mObj != null)
      {
        GameObject.DestroyImmediate(mObj);
        mObj = null;
        //mWeapon = null;
      }

      ++mWeaponIndex;
      //if (mWeaponIndex >= gameRoot.Instance.WeaponPrefabs.Count)
      //{
      //  mWeaponIndex = 0;
      //}

      //mObj = GameObject.Instantiate(gameRoot.Instance.WeaponPrefabs[mWeaponIndex]);
      //if (mObj != null)
      //{
      //  mObj.transform.parent = transform;
      //  mObj.transform.localPosition = Vector3.zero;
      //  mObj.transform.localRotation = Quaternion.identity;
      //  mWeapon = mObj.GetComponent<Weapon>();
      //}
    }

    void UpdateHand()
    {
      //if (mWeapon != null)
      //{
      //  bool firing = false;

      //  switch (mWeapon.FireType)
      //  {
      //    case Weapon.fireType.singleShot:
      //      if (gameRoot.Instance.VREnabled)
      //      {
      //        firing = SteamVR_Controller.Input((int)controller.index).GetPressDown(SteamVR_Controller.ButtonMask.Trigger);
      //      }
      //      else
      //      {
      //        if (handedness == handCursor.Handedness.right)
      //        {
      //          firing = Input.GetMouseButtonDown(1);
      //        }
      //        else if (handedness == handCursor.Handedness.left)
      //        {
      //          firing = Input.GetMouseButtonDown(0);
      //        }
      //      }

      //      break;
      //    case Weapon.fireType.fullAuto:
      //      if (gameRoot.Instance.VREnabled)
      //      {
      //        firing = SteamVR_Controller.Input((int)controller.index).GetPress(SteamVR_Controller.ButtonMask.Trigger);
      //      }
      //      else
      //      {
      //        if (handedness == handCursor.Handedness.right)
      //        {
      //          firing = Input.GetMouseButton(1);
      //        }
      //        else if (handedness == handCursor.Handedness.left)
      //        {
      //          firing = Input.GetMouseButton(0);
      //        }
      //      }
      //      break;
      //    default:
      //      break;
      //  }

      //  if (firing)
      //  {
      //    if (mWeapon.Fire())
      //    {
      //      SteamVR_Controller.Input((int)controller.index).TriggerHapticPulse(mWeapon.hapticPulseStrength);
      //    }
      //  }
      //}

      bool switchWeapon = false; //SteamVR_Controller.Input((int)controller.index).GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)

      if (switchWeapon)
      {
        SwitchWeapon();
      }
      else
      {
        if (handedness == handCursor.Handedness.right && Input.GetKeyDown(rightSwitch))
        {
          SwitchWeapon();
        }
        else if (handedness == handCursor.Handedness.left && Input.GetKeyDown(leftSwitch))
        {
          SwitchWeapon();
        }
      }
    }

    // Use this for initialization
    void Start()
    {
      mWeaponIndex = -1;

      if (handCursorPrefab != null)
      {
        mHand = GameObject.Instantiate<handCursor>(handCursorPrefab);
        mHand.handedness = handedness;
        mHand.transform.parent = transform;
        mHand.transform.localPosition = Vector3.zero;
        mHand.transform.localRotation = Quaternion.identity;
        mHand.Fixup();
      }
    }

    void UpdateFixed()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //if(gameRoot.Instance.VREnabled && controller != null)
      //{
      //  var vr = SteamVR.instance;

      //  var state = new VRControllerState_t();

      //  if (vr.hmd.GetControllerState((uint)controller.index, ref state))
      //  {
      UpdateHand();

      /*
          Vector2 dir = SteamVR_Controller.Input((int)controller.index).GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
          if (!dir.Equals(Vector2.zero))
          {
            Debug.Log("Touchpad Pos: " + dir.x + "," + dir.y);
          }
      */

      //  }
      //}
    }

  }

}