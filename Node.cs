using System;

enum NodeType { start, goal, accessible, blocked, path }

class Node {
    public int x, y;

    public Node(int _x, int _y) {
        x = _x;
        y = _y;
    }

    public override string ToString() {
        return $"({x},{y})";
    }

    public override bool Equals(object obj) {
        return Equals(obj as Node);
    }

    public bool Equals(Node other) {
        return other != null && x == other.x && y == other.y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }
}