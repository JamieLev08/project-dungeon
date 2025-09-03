using UnityEngine;
using Unity.Cinemachine;

public class Camera_Manager : MonoBehaviour
{
    [SerializeField]
    private CinemachineCamera cineCam;

    void Awake()
    {
        
    }

    public void SwitchCamera(Collider2D collision)
    {
        cineCam.GetComponent<CinemachineConfiner2D>().BoundingShape2D = collision;
    }
}
