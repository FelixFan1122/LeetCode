package AccountsMerge;

import java.util.*;

class Solution {
    public List<List<String>> accountsMerge(List<List<String>> accounts) {
        var emailToAccounts = groupByEmail(accounts);
        var uf = new UnionFind(accounts.size());
        for (var accs : emailToAccounts.values()) {
            for (int i = 1; i < accs.size(); i++) uf.union(accs.get(i - 1), accs.get(i));
        }
        var idToAccounts = new HashMap<Integer, TreeSet<String>>();
        var idToName = new HashMap<Integer, String>();
        for (int i = 0; i < accounts.size(); i++) {
            int id = uf.find(i);
            var account = accounts.get(i);
            if (!idToName.containsKey(id)) idToName.put(id, account.get(0));
            var emails = idToAccounts.computeIfAbsent(id, x -> new TreeSet<>());
            for (int j = 1; j < account.size(); j++) emails.add(account.get(j));
        }
        var merged = new ArrayList<List<String>>();
        for (var entry : idToName.entrySet()) {
            var account = new ArrayList<String>();
            account.add(entry.getValue());
            account.addAll(idToAccounts.get(entry.getKey()));
            merged.add(account);
        }
        return merged;
    }

    private static HashMap<String, ArrayList<Integer>> groupByEmail(List<List<String>> accounts) {
        var groups = new HashMap<String, ArrayList<Integer>>();
        for (int i = 0; i < accounts.size(); i++) {
            var account = accounts.get(i);
            for (int j = 1; j < account.size(); j++) {
                groups.computeIfAbsent(account.get(j), x -> new ArrayList<>()).add(i);
            }
        }
        return groups;
    }

    public static void main(String[] args) {
        var accounts = new ArrayList<List<String>>();
        accounts.add(List.of("John", "johnsmith@mail.com", "john00@mail.com"));
        accounts.add(List.of("John", "johnnybravo@mail.com"));
        accounts.add(List.of("John", "johnsmith@mail.com", "john_newyork@mail.com"));
        accounts.add(List.of("Mary", "mary@mail.com"));
        new Solution().accountsMerge(accounts);
    }
}

class UnionFind {

    private final int[] parents, sizes;

    public UnionFind(int n) {
        parents = new int[n];
        sizes = new int[n];
        for (int i = 0; i < n; i++) parents[i] = i;
        Arrays.fill(sizes, 1);
    }

    public int find(int p) {
        if (parents[p] != p) parents[p] = find(parents[p]);
        return parents[p];
    }

    public void union(int p, int q) {
        int pp = find(p), qq = find(q);
        if (pp == qq) return;
        if (sizes[pp] < sizes[qq]) {
            parents[pp] = qq;
            sizes[qq] += sizes[pp];
        } else {
            parents[qq] = pp;
            sizes[pp] += sizes[qq];
        }
    }
}
