using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour
{

	public float moveSpeed = 3f;
	public float rotationSpeed = 3f;
	public Transform pathParent;
	Transform targetPoint;
	int index;

	void OnDrawGizmos()
	{
		Vector3 from;
		Vector3 to;
		for (int a = 0; a < pathParent.childCount; a++)
		{
			from = pathParent.GetChild(a).position;
			to = pathParent.GetChild((a + 1) % pathParent.childCount).position;
			Gizmos.color = new Color(1, 0, 0);
			Gizmos.DrawLine(from, to);
		}
	}
	void Start()
	{
		index = 0;
		targetPoint = pathParent.GetChild(index);
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

		Vector3 dir = targetPoint.position - transform.position;
		Quaternion rot = Quaternion.LookRotation(dir);

		transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
		{
			index++;
			index %= pathParent.childCount;
			targetPoint = pathParent.GetChild(index);
		}
	}
}