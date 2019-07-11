using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ammoCountText;
    public Text healthText;
    charcterController charController;
    private void Start()
    {
        charController = GetComponent<charcterController>();
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        if (charController.GetGunSelect()== 1)
        {
            ammoCountText.text = "10/" + charController.shotGun.ammoCount + "";
        }
        else if (charController.GetGunSelect() == 3)
        {
            ammoCountText.text = "5/" + charController.rocketLauncher.ammoCapacity + "";
        }
        healthText.text = "" + charController.health + "";
    }
}
