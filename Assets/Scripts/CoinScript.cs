
using UnityEngine;

public class CoinScript : MonoBehaviour


{
    //The player calls this function on the coin whenever they bump into it
    //You can change its contents if you want something different to happen on collection
    //For example, what if the coin teleported to a new location instead of being destroyed?
    public void GetBumped()
    {
        transform.position = new Vector3(Random.Range(-0.70f,3), Random.Range(-0.70f,3));
        //This destroys the coin
        // Destroy(gameObject);
    }
}
