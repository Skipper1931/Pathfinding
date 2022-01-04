using System.Collections.Generic;

partial class ImgGraph {
    public void Pathfind() {
        Node start = new Node(0,0);
        Node goal = new Node(0,0);

        bool sAssigned = false;
        bool gAssigned = false;
        for(int w = 0; w < width; w++) {
            for(int h = 0; h < height; h++) {
                NodeType t = map[w,h];
                if(t == NodeType.start) {
                    start = new Node(w, h);
                    sAssigned = true;
                }
                else if(t == NodeType.goal) {
                    goal = new Node(w,h);
                    gAssigned = true;
                }

                if(sAssigned && gAssigned) {
                    break;
                }
            }
        }
    
        // Adapted from https://www.redblobgames.com/pathfinding/a-star/introduction.html
        PriorityQueue<Node, double> frontier = new PriorityQueue<Node, double>();
        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        Dictionary<Node, int> sumCost = new Dictionary<Node, int>();
        frontier.Enqueue(start, 0);
        sumCost[start] = 0;

        int nodeNum = 0;
        while(frontier.Count != 0) {
            Node current = frontier.Dequeue();

            if(current.Equals(goal)) {
                break;
            }

            foreach(Node next in Neighbors(current)) {
                int newCost = sumCost[current] + 1;
                if((!sumCost.ContainsKey(next)) || (newCost < sumCost[next])) {
                    Console.Write($"\rChecking node {nodeNum++}");
                    sumCost[next] = newCost;
                    double priority = newCost + Math.Sqrt(Math.Pow(goal.x - next.x, 2) + Math.Pow(goal.y - next.y, 2));
                    frontier.Enqueue(next, priority);
                    cameFrom[next] = current;
                }
            }
        }
        Console.Write("\nPath found\n");

        Node n = goal;
        while(n != start) {
            n = cameFrom[n];
            map[n.x, n.y] = NodeType.path;
        }
    }
}