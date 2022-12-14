using UnityEngine;
using System.Collections;
using TMPro;

public class ActivateChest : MonoBehaviour {

	public Transform lid, lidOpen, lidClose;	// Lid, Lid open rotation, Lid close rotation
	public float openSpeed = 5F;				// Opening speed
	public bool canClose;                       // Can the chest be closed
    public Sword sword;
    public TextMeshProUGUI chestInstrucationsText;
    public GameObject playersLook;

    [HideInInspector]
	public bool _open;							// Is the chest opened

	void Update () {
		if(_open){
			ChestClicked(lidOpen.rotation);
            HandleLookAtChest(false);
        }
		else{
			ChestClicked(lidClose.rotation);
            HandleLookAtChest(true);
        }
	}
	
	// Rotate the lid to the requested rotation
	void ChestClicked(Quaternion toRot){
		if(lid.rotation != toRot){
			lid.rotation = Quaternion.Lerp(lid.rotation, toRot, Time.deltaTime * openSpeed);
		}
	}
	
	void OnMouseDown(){
		if(canClose) _open = !_open; else _open = true;
        if (_open)
        {
            sword.ShowSword(true);
        }
        else
        {
            sword.ShowSword(false);
        }
	}

    private void HandleLookAtChest(bool chestClosed)
    {
        if (Physics.Raycast(playersLook.transform.position, playersLook.transform.forward, out RaycastHit hit))
        {
            if (hit.collider.gameObject == gameObject && chestClosed) // looking at the chest
            {
                chestInstrucationsText.text = "Click to open chest";
            }
            else if (hit.collider.gameObject == gameObject && !chestClosed)
            {
                chestInstrucationsText.text = "Click to close chest";
            }
            else
            {
                chestInstrucationsText.text = "";
            }
        }
    }
}
