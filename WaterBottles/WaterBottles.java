package WaterBottles;

class Solution {
    public int numWaterBottles(int numBottles, int numExchange) {
        return numBottles + (numBottles < numExchange ? 0 : (numBottles - numExchange) / (numExchange - 1) + 1);
    }
}
