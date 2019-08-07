using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ammoCountText;
    public Text healthText;
    public GameObject endGamePanel;
    public Slider slider;
    public Text scoreText;
    public GameObject[] gunsImage;
    PlayerManager target;
    public Text playerNameText;
    private void Start()
    {
        
    }
    // Update is called once per frame

    void Update()
    {
        // Destroy itself if the target is null, It's a fail safe when Photon is destroying Instances of a Player over the network
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        if (!target.photonView.IsMine)
        {
            gameObject.SetActive(false);
        }

        // Reflect the Player Health
        if (slider != null)
        {
            slider.value = target.Health;
        }
        if (healthText!=null)
        {
            healthText.text = ((int)(target.Health*100)).ToString();
        }

        if (ammoCountText!=null)
        {
            if (target.selectGun==0)
            {
                ChangeGunImage(0);
                ammoCountText.text = target.guns[0].gameObject.GetComponent<ShotGun>().ammoCapacity.ToString() + "/" + target.guns[0].gameObject.GetComponent<ShotGun>().ammoCount.ToString();
            }
           else if (target.selectGun == 1)
            {
                ChangeGunImage(1);
                ammoCountText.text = target.guns[1].gameObject.GetComponent<Laser>().ammoCapacity.ToString()+"/"+ target.guns[1].gameObject.GetComponent<Laser>().ammoCount.ToString();
            }
          else  if (target.selectGun == 2)
            {
                ChangeGunImage(2);
                ammoCountText.text = target.guns[2].gameObject.GetComponent<RocketLauncher>().ammoCapacity.ToString() + "/" + target.guns[2].gameObject.GetComponent<RocketLauncher>().ammoCount.ToString();
            }

        }
    }
    public void SetTarget(PlayerManager _target)
    {

        if (_target == null)
        {
            Debug.LogError("<Color=Red><b>Missing</b></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
            return;
        }

        // Cache references for efficiency because we are going to reuse them.
        this.target = _target;


        CharacterController _characterController = this.target.GetComponent<CharacterController>();

        // Get data from the Player that won't change during the lifetime of this Component
        //if (_characterController != null)
        //{
        //    characterControllerHeight = _characterController.height;
        //}

        if (playerNameText != null)
        {
            playerNameText.text = this.target.photonView.Owner.NickName;
        }
    }
    public void ChangeGunImage(int num)
    {
        
        for (int i = 0; i < gunsImage.Length; i++)
        {
            if (i == num)
                gunsImage[i].gameObject.SetActive(true);
            else
                gunsImage[i].gameObject.SetActive(false);
        }
    }
}
