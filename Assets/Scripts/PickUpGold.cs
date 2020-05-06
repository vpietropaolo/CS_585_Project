using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGold : MonoBehaviour
{
    public Transform player;
    public Transform lHand;
    public Transform rHand;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        lHand = GameObject.FindWithTag("PlayerHand").transform;
        rHand = GameObject.FindWithTag("SecondaryPlayerHand").transform;
        transform.parent = null;
    }

    // Activate these by broadcasting the desired function name to all gold pieces. Only pieces close to the player or input goblin will be picked up.

    IEnumerator PlayerPickUpCoin()
    {
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(transform.position, lHand.transform.position) < 1.5f && Vector3.Distance(transform.position, rHand.transform.position) < 1.5f)
        {
            transform.parent = lHand;
            transform.localPosition = Vector3.Lerp(transform.position, new Vector3(-0.5f, 0, 1.2f), 1);
            transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-120, -30, 130), 1);
            player.gameObject.SendMessage("Holding");
        }
    }

    void PlayerDropCoin()
    {
        transform.parent = null;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0.92f, transform.position.z), 1);
        Quaternion look = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(90, look.eulerAngles.y, look.eulerAngles.z), 1);
    }

    IEnumerator GoblinPickUpCoin(Transform goblin)
    {
        Transform gob_lHand = goblin.Find("Root").Find("BN_Spine").Find("BN_Spine1").Find("BN_LeftShoulder").Find("BN_LeftArm").Find("BN_LeftForearm").Find("BN_LeftHand");
        Transform gob_rHand = goblin.Find("Root").Find("BN_Spine").Find("BN_Spine1").Find("BN_RightShoulder").Find("BN_RightArm").Find("BN_RightForearm").Find("BN_RightHand");
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(transform.position, gob_lHand.transform.position) < 1.5f && Vector3.Distance(transform.position, gob_rHand.transform.position) < 1.5f)
        {
            transform.parent = gob_lHand;
            transform.localPosition = Vector3.Lerp(transform.position, new Vector3(-0.1f, -0.15f, 0.1f), 1);
            transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(30, 0, 70), 1);
        }
    }

    void GoblinDropCoin(Transform goblin)
    {
        Transform gob_lHand = goblin.Find("Root").Find("BN_Spine").Find("BN_Spine1").Find("BN_LeftShoulder").Find("BN_LeftArm").Find("BN_LeftForearm").Find("BN_LeftHand");
        if (transform.parent == gob_lHand)
        {
            transform.parent = null;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0.92f, transform.position.z), 1);
            Quaternion look = Quaternion.LookRotation(goblin.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(90, look.eulerAngles.y, look.eulerAngles.z), 1);
        }
    }
}
