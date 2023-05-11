using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSet : MonoBehaviour
{
    // Start is called before the first frame update
    public float setDistance = 4.5f;
    public float duration = 1;
    bool doorOpen;
    Vector2 startPosition;
    void Start()
    {
        // Sets the first position of the door as it's closed position.
        startPosition = transform.position;
    }
    public void MovetoSide()
    {
        StopAllCoroutines();
        if (!doorOpen)
        {
            Vector2 openPosition = startPosition + Vector2.right * setDistance;
            StartCoroutine(Move(openPosition));
        }
        else
        {
            StartCoroutine(Move(startPosition));
        }
        doorOpen = !doorOpen;
    }
    IEnumerator Move(Vector2 targetPosition)
    {
        float timeElapsed = 0;
        Vector2 startPosition = transform.position;
        while (timeElapsed < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
