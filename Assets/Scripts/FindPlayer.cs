using Cinemachine;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    private void Awake()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
}
