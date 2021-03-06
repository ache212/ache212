using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
	public string _WebsiteURL = "http://ache212.azurewebsites.net/tables/product/product?api_key=product?zumo-api-version=2.0.0";

    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Trello[] trellos = JsonReader.Deserialize<Trello[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL

		int i = 0;

        //----------------------

        //We can now loop through the array of objects and access each object individually
        foreach (Trello trello in trellos)
        {
            //Example of how to use the object
			Debug.Log(trello.Title);
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE

			/* ache212 */ 
			int totalCubes = 25;
			float totalDistance = 2.9f;

			float perc = i / (float)totalCubes;

			float sin = Mathf.Sin(perc * Mathf.PI / 2);

			float x = 1.8f + sin * totalDistance;
			float y = 10.0f;
			float z = 0.0f;
			var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity); //Quaternion is default identity;
			newCube.GetComponent<CubeCode>().SetSize(0.7f);
			newCube.GetComponent<CubeCode>().rotateSpeed = .2f + perc;
			newCube.GetComponentInChildren<TextMesh>().text = trello.Title;

			i++;
			/* ache212 */

            //----------------------
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
