package WordSquares;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class Solution {
    public List<List<String>> wordSquares(String[] words) {
        HashMap<String, List<String>> prefixes = buildPrefixes(words);
        var squares = new ArrayList<List<String>>();
        backtrack(prefixes, new ArrayList<>(), squares, 0, words[0].length());
        return squares;
    }

    private static void backtrack(HashMap<String, List<String>> words, List<String> square, List<List<String>> squares, int index, int length) {
        if (index == length) {
            squares.add(new ArrayList<>(square));
        } else {
            var prefix = new char[index];
            for (int i = 0; i < index; i++) prefix[i] = square.get(i).charAt(index);
            for (var word : words.getOrDefault(new String(prefix), new ArrayList<>())) {
                square.add(word);
                backtrack(words, square, squares, index + 1, length);
                square.remove(square.size() - 1);
            }
        }
    }

    private static HashMap<String, List<String>> buildPrefixes(String[] words) {
        var prefixes = new HashMap<String, List<String>>();
        for (var word : words) {
            for (int i = 0; i <= word.length(); i++) {
                prefixes.computeIfAbsent(word.substring(0, i), x -> new ArrayList<>()).add(word);
            }
        }
        return prefixes;
    }
}
