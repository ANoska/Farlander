using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPather : MonoBehaviour
{
    public Animation penguinAnimation;

    private Vector3 startPoint;
    public Vector3 endPoint;

    public float speed = 1f;

    private const string ANIMATION_NAME_IDLE = "idle";
    private const string ANIMATION_NAME_RUN = "run";
    private const string ANIMATION_NAME_WALK = "walk";

    // Start is called before the first frame update
    void Start()
    {
        startPoint = this.transform.position;
        StartCoroutine(PenguinIdlingAtStart());
    }

    private IEnumerator PenguinPathingToEnd()
    {
        penguinAnimation.Play(ANIMATION_NAME_RUN);

        while(this.transform.position != endPoint)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, endPoint, speed * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(PenguinIdlingAtEnd());

        yield return null;
    }

    private IEnumerator PenguinIdlingAtEnd()
    {
        penguinAnimation.Play(ANIMATION_NAME_IDLE);

        Vector3 distance = startPoint - this.transform.position;
        float rot_y = Mathf.Atan2(distance.x, distance.z) * Mathf.Rad2Deg;
        Quaternion target = Quaternion.AngleAxis(rot_y + 90f, Vector3.up);

        while (this.transform.rotation != target)
        {
            transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * 1.0f);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(PenguinPathingToStart());
    }

    private IEnumerator PenguinPathingToStart()
    {
        penguinAnimation.Play(ANIMATION_NAME_RUN);

        while (this.transform.position != startPoint)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, startPoint, speed * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(PenguinIdlingAtStart());

        yield return null;
    }

    private IEnumerator PenguinIdlingAtStart()
    {
        penguinAnimation.Play(ANIMATION_NAME_IDLE);

        Vector3 distance = endPoint - this.transform.position;
        float rot_y = Mathf.Atan2(distance.x, distance.z) * Mathf.Rad2Deg;
        Quaternion target = Quaternion.AngleAxis(rot_y + 90f, Vector3.up);

        while (this.transform.rotation != target)
        {
            transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * 1.0f);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(PenguinPathingToEnd());
    }
}
