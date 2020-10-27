package DesignCircularDeque;

class MyCircularDeque {
    int capacity, size;
    Node front, last;
    /** Initialize your data structure here. Set the size of the deque to be k. */
    public MyCircularDeque(int k) {
        capacity = k;
    }

    /** Adds an item at the front of Deque. Return true if the operation is successful. */
    public boolean insertFront(int value) {
        if (size == capacity) return false;
        Node newFront = new Node(value);
        newFront.next = front;
        if (front != null) front.previous = newFront;
        front = newFront;
        if (size++ == 0) last = front;
        return true;
    }

    /** Adds an item at the rear of Deque. Return true if the operation is successful. */
    public boolean insertLast(int value) {
        if (size == capacity) return false;
        Node newLast = new Node(value);
        if (last != null) last.next = newLast;
        newLast.previous = last;
        last = newLast;
        if (size++ == 0) front = last;
        return true;
    }

    /** Deletes an item from the front of Deque. Return true if the operation is successful. */
    public boolean deleteFront() {
        if (size == 0) return false;
        if (front.next != null) front.next.previous = null;
        front = front.next;
        size--;
        return true;
    }

    /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
    public boolean deleteLast() {
        if (size == 0) return false;
        if (last.previous != null) last.previous.next = null;
        last = last.previous;
        size--;
        return true;
    }

    /** Get the front item from the deque. */
    public int getFront() {
        if (size == 0) return -1;
        return front.val;
    }

    /** Get the last item from the deque. */
    public int getRear() {
        if (size == 0) return -1;
        return last.val;
    }

    /** Checks whether the circular deque is empty or not. */
    public boolean isEmpty() {
        return size == 0;
    }

    /** Checks whether the circular deque is full or not. */
    public boolean isFull() {
        return size == capacity;
    }
}
class Node {
    int val;
    Node previous, next;
    Node(int val) { this.val = val; }
}
