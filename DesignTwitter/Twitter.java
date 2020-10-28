package DesignTwitter;

import java.util.*;

class Twitter {
    private static final int LENGTH = 10;
    int ts;
    HashMap<Integer, LinkedList<Tweet>> tweets;
    HashMap<Integer, HashSet<Integer>> following;

    /** Initialize your data structure here. */
    public Twitter() {
        tweets = new HashMap<>();
        following = new HashMap<>();
    }

    /** Compose a new tweet. */
    public void postTweet(int userId, int tweetId) {
        if (!tweets.containsKey(userId)) tweets.put(userId, new LinkedList<>());
        var content = tweets.get(userId);
        if (content.size() == LENGTH) content.removeLast();
        content.addFirst(new Tweet(ts++, tweetId));
    }

    /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
    public List<Integer> getNewsFeed(int userId) {
        PriorityQueue<Tweet> news = new PriorityQueue<>(LENGTH);
        if (tweets.containsKey(userId)) {
            news.addAll(tweets.get(userId));
        }
        if (following.containsKey(userId)) {
            var followees = following.get(userId);
            for (int followee : followees) {
                if (!tweets.containsKey(followee)) continue;
                for (Tweet tweet : tweets.get(followee)) {
                    if (news.size() < LENGTH) news.offer(tweet);
                    else if (tweet.compareTo(news.peek()) > 0) {
                        news.poll();
                        news.offer(tweet);
                    }
                }
            }
        }
        ArrayList<Integer> feed = new ArrayList<>(LENGTH);
        while (!news.isEmpty()) feed.add(0, news.poll().getId());
        return feed;
    }

    /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
    public void follow(int followerId, int followeeId) {
        if (followerId == followeeId) return;
        if (!following.containsKey(followerId)) following.put(followerId, new HashSet<>());
        following.get(followerId).add(followeeId);
    }

    /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
    public void unfollow(int followerId, int followeeId) {
        if (following.containsKey(followerId)) following.get(followerId).remove(followeeId);
    }
}
class Tweet implements Comparable<Tweet> {
    private final int ts;
    private final int id;
    public Tweet(int ts, int id) {
        this.ts = ts;
        this.id = id;
    }
    public int getId() { return id; }
    public int getTs() { return ts; }
    public int compareTo(Tweet o) {
        return Integer.compare(ts, o.getTs());
    }
}
