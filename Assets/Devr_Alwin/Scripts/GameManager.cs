using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] CanvasGroup introLogo;
    [SerializeField] float waitTime, fadeTime;
    public LayerMask environmentHitMask;
    public UnityEvent OnClickEnvironment;
    public Transform walkPointer;

    public RaycastHit hit;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIFader.instance.FadeUIGroup(introLogo, waitTime, fadeTime);
    }

    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, environmentHitMask))
        {
            
            walkPointer.position = hit.point + Vector3.up * 0.01f;
            
            if (!walkPointer.gameObject.activeSelf) walkPointer.gameObject.SetActive(true);

            if (Input.GetAxis("Fire1") > 0)
            {
                OnClickEnvironment.Invoke();
            }
        }
        else
        {
            walkPointer.gameObject.SetActive(false);
        }
        /*
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
        */
    }

}
