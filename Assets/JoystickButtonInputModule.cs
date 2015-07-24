/*
 * This is based on Cardboard's GazeInputModule
 */
using UnityEngine;
using UnityEngine.EventSystems;

// An implementation of the BaseInputModule that uses the player's gaze and a joystick button
// as a raycast generator.  To use, attach to the scene's EventSystem object.  Set the Canvas
// object's Render Mode to World Space, and set its Event Camera to a (mono) camera that is
// controlled by a CardboardHead.  If you'd like gaze to work with 3D scene objects, add a
// PhysicsRaycaster to the gazing camera, and add a component that implements one of the Event
// interfaces (EventTrigger will work nicely).  The objects must have colliders too.
//
// The button used in the one defined as Trigger in the InputManager (Edit>Project Settings>Input).
//
public class JoystickButtonInputModule : BaseInputModule {
  [Tooltip("Whether gaze input is active in VR Mode only (true), or all the time (false).")]
  public bool vrModeOnly = false;

  [Tooltip("Optional object to place at raycast intersections as a 3D cursor. " +
           "Be sure it is on a layer that raycasts will ignore.")]
  public GameObject cursor;

  // Time in seconds between the pointer down and up events sent by a magnet click.
  // Allows time for the UI elements to make their state transitions.
  [HideInInspector]
  public float clickTime = 0.1f;  // Based on default time for a button to animate to Pressed.

  // The pixel through which to cast rays, in viewport coordinates.  Generally, the center
  // pixel is best, assuming a monoscopic camera is selected as the Canvas' event camera.
  [HideInInspector]
  public Vector2 hotspot = new Vector2(0.5f, 0.5f);

  private PointerEventData pointerData;

  public override bool ShouldActivateModule() {
    if (!base.ShouldActivateModule()) {
      return false;
    }
    return Cardboard.SDK.VRModeEnabled || !vrModeOnly;
  }

  public override void DeactivateModule() {
    base.DeactivateModule();
    if (pointerData != null) {
      HandleButtonUp();
      //HandlePointerExitAndEnter(pointerData, null);
      pointerData = null;
    }
    eventSystem.SetSelectedGameObject(null, GetBaseEventData());
    if (cursor != null) {
      cursor.SetActive(false);
    }
  }

  public override bool IsPointerOverGameObject(int pointerId) {
    return pointerData != null && pointerData.pointerEnter != null;
  }

  public override void Process() {
    //CastRayFromGaze();
    //UpdateCurrentObject();
    //PlaceCursor();
    HandleButtonDown();
    HandleButtonUp();
  }

  private void CastRayFromGaze() {
    if (pointerData == null) {
      pointerData = new PointerEventData(eventSystem);
    }
    pointerData.Reset();
    pointerData.position = new Vector2(hotspot.x * Screen.width, hotspot.y * Screen.height);
    eventSystem.RaycastAll(pointerData, m_RaycastResultCache);
    pointerData.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
    m_RaycastResultCache.Clear();
  }

  private void UpdateCurrentObject() {
    // Send enter events and update the highlight.
    var go = pointerData.pointerCurrentRaycast.gameObject;
    HandlePointerExitAndEnter(pointerData, go);
    // Update the current selection, or clear if it is no longer the current object.
    var selected = ExecuteEvents.GetEventHandler<ISelectHandler>(go);
    if (selected == eventSystem.currentSelectedGameObject) {
      ExecuteEvents.Execute(eventSystem.currentSelectedGameObject, GetBaseEventData(),
                            ExecuteEvents.updateSelectedHandler);
    }
    else {
      eventSystem.SetSelectedGameObject(null, pointerData);
    }
  }

  private void PlaceCursor() {
    if (cursor == null)
      return;
    var go = pointerData.pointerCurrentRaycast.gameObject;
    cursor.SetActive(go != null);
    if (cursor.activeInHierarchy) {
      Camera cam = pointerData.enterEventCamera;
      // Note: rays through screen start at near clipping plane.
      float dist = pointerData.pointerCurrentRaycast.distance + cam.nearClipPlane;
      cursor.transform.position = cam.transform.position + cam.transform.forward * dist;
    }
  }

	private void HandleButtonUp() {
		if(Input.GetButtonUp("Trigger")) {
	//		Cardboard.SDK.Triggered = false;

			/*
		    // Send pointer up and click events.
		    ExecuteEvents.Execute(pointerData.pointerPress, pointerData, ExecuteEvents.pointerUpHandler);
		    ExecuteEvents.Execute(pointerData.pointerPress, pointerData, ExecuteEvents.pointerClickHandler);

		    // Clear the click state.
		    pointerData.pointerPress = null;
		    pointerData.rawPointerPress = null;
		    pointerData.eligibleForClick = false;
		    pointerData.clickCount = 0;
		    */
		}
	}

	private void HandleButtonDown() {
	    if (Input.GetButtonDown("Trigger")) {
//			Cardboard.SDK.Triggered = true;
/*
		    var go = pointerData.pointerCurrentRaycast.gameObject;

		    // Send pointer down event.
		    pointerData.pressPosition = pointerData.position;
		    pointerData.pointerPressRaycast = pointerData.pointerCurrentRaycast;
		    pointerData.pointerPress =
		        ExecuteEvents.ExecuteHierarchy(go, pointerData, ExecuteEvents.pointerDownHandler)
		        ?? ExecuteEvents.GetEventHandler<IPointerClickHandler>(go);

		    // Save the pending click state.
		    pointerData.rawPointerPress = go;
		    pointerData.eligibleForClick = true;
		    pointerData.clickCount = 1;
		    pointerData.clickTime = Time.unscaledTime;
*/		  
		}

	}
}
