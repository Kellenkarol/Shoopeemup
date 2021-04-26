using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandReciever : MonoBehaviour
{
    private InputMap inputActions;

    public GameObject menu;
    public GameObject credits;

    private void Awake()
    {
        inputActions = new InputMap();

        inputActions.Menu.ConfirmAction.performed += _ => GoBack();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void GoBack()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }
}
