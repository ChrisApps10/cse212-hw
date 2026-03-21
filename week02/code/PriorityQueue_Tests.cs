using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add A(1), B(5), C(3). High priority (B) should be returned.
    // Expected Result: B
    // Defect(s) Found: The original loop skipped the last item in the list.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("B", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Add A(5), B(5), C(1). Both A and B are high priority. A should be returned first (FIFO).
    // Expected Result: A
    // Defect(s) Found: Comparison (>=) picked the last high-priority item instead of the first.
    public void TestPriorityQueue_FIFO_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with "The queue is empty."
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e) {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
