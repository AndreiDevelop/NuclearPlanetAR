using UnityEngine;

public class PositionalManager
{
	public static void PlaceObjectOnPlanet (ref GameObject objectToReplace, GameObject planet) 
	 {
        Vector3 newPosition = CalculatePosionReplaceObjectOnPlanet(objectToReplace.transform, planet.transform);

        Transform objectToPlaceTransform = objectToReplace.transform;
		Quaternion newRotation = Quaternion.identity;

		objectToPlaceTransform.position = newPosition;
		objectToPlaceTransform.rotation = newRotation;

		objectToPlaceTransform.LookAt(planet.transform);
		objectToPlaceTransform.Rotate(-90, 0, 0);
     }


	private static Vector3 CalculatePosionReplaceObjectOnPlanet(Transform objectToPlaceTransform, Transform planetTransform)
	{
		return Random.onUnitSphere * ((planetTransform.localScale.x/2) + objectToPlaceTransform.localScale.y * 0.5f) + planetTransform.position;
	}

}
