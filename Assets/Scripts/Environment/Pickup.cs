using UnityEngine;
using System.Collections;

public enum mItemType
{
    coin = 0
}

public class Pickup : MonoBehaviour {

    public mItemType mType;
    public int mAmount;

	void Start ()
    {
	    
	}
	

	void Update ()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if(mType == mItemType.coin)
            {
                GameManager.sInstance.AddCoins(mAmount);
            }

            Destroy(this.gameObject);
        }
    }
}
