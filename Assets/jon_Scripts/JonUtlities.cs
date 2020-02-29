using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonUtilities : MonoBehaviour
{
	// Returns a list with a count specified by the third parameter between lower
	// bound and upper bound (inclusive)
	public static List<int> RandomNoRepeat(int lowerBound, int upperBound, int number)
	{
		List<int> list = new List<int>();
		int n = number;

		Mathf.Min(upperBound - lowerBound + 1, number);

		while (list.Count < n)
		{

			int candidate = Random.Range(lowerBound, upperBound + 1);
			if (list.Contains(candidate)) { 
				continue; 
			} else
			{
				list.Add(candidate);
			}
		}
		return list;
	}
}
