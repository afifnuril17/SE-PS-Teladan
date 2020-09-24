using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class getDataJson : MonoBehaviour
{
    public attributeList attributeList = new attributeList();
    // Start is called before the first frame update
    IEnumerator login()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (
            UnityWebRequest www = UnityWebRequest.Post("http://game.psikologicare.com/api/login?name=maverick&password=BinaKarir2020!", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {

                attributeList = JsonUtility.FromJson<attributeList>(www.downloadHandler.text);

                Debug.Log(www.downloadHandler.text);

                foreach ( attributes attribute in attributeList.attributes)
                {
                    print(attribute.label);
                    print(attribute.type);
                }
            }
        }
    }

    void  Start()
    {
       StartCoroutine( login());
        Debug.Log("fak");
    }
}
