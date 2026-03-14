public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // 1. Create a new array of doubles with a size equal to 'length'.
        // 2. Create a loop that runs from 0 up to 'length' (exclusive).
        // 3. In each iteration, calculate the multiple by multiplying 'number' by (index + 1).
        // 4. Store that calculated value into the current index of the array.
        // 5. Return the completed array.

        double[] results = new double[length];

        for (int i = 0; i < length; i++)
        {
            results[i] = number * (i + 1);
        }

        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// Because a list is dynamic, this function will modify the existing data list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // 1. Determine the split point: the number of elements to pull from the end is 'amount'.
        // 2. Use GetRange to grab the segment of the list starting from (data.Count - amount).
        // 3. Store this segment in a temporary list.
        // 4. Remove that same segment from the end of the original 'data' list using RemoveRange.
        // 5. Insert the temporary list at the very beginning (index 0) of the 'data' list using InsertRange.

        // Get the values that are being moved from the back to the front
        int startingIndex = data.Count - amount;
        List<int> movedSegment = data.GetRange(startingIndex, amount);

        // Remove them from their original position
        data.RemoveRange(startingIndex, amount);

        // Put them at the front
        data.InsertRange(0, movedSegment);
    }
}
