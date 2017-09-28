using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{

	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;
	private RaycastHit hit;

	void Update()
	{

#if UNITY_EDITOR
		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
		{

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();



			Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);


			if (Physics.Raycast(ray, out hit, touchInputMask))
			{
				GameObject recipient = hit.transform.gameObject;
				if (Input.GetMouseButtonDown(0))
				{
					recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButtonDown(0))
				{
					recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButton(0))
				{
					recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}

			}

			foreach (GameObject g in touchesOld)
			{
				if (!touchList.Contains(g))
				{
					g.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}

#endif

		if (Input.touchCount > 0)
		{

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

			foreach (Touch touch in Input.touches)
			{

				Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);


				if (Physics.Raycast(ray, out hit, touchInputMask))
				{
					GameObject recipient = hit.transform.gameObject;
					if (touch.phase == TouchPhase.Began)
					{
						recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Ended)
					{
						recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Stationary)
					{
						recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
					}

					if (touch.phase == TouchPhase.Canceled)
					{
						recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
					}



				}
			}
			foreach (GameObject g in touchesOld)
			{
				if (!touchList.Contains(g))
				{
					g.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}



