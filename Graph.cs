using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

partial class ImgGraph {
    static Rgba32 white = new Rgba32(255, 255, 255);
    static Rgba32 black = new Rgba32(0, 0, 0);
    static Rgba32 red = new Rgba32(255, 0, 0);
    static Rgba32 green = new Rgba32(0, 255, 0);
    static Rgba32 blue = new Rgba32(0, 0, 255);

    private NodeType[,] map;
    public int width;
    public int height;

    public ImgGraph(Image<Rgba32> image) {
        width = image.Width;
        height = image.Height;

        map = new NodeType[width, height];

        for(int w = 0; w < width; w++) {
            for(int h = 0; h < height; h++) {
                Rgba32 pixel = image[w,h];
                
                if(pixel == red) {
                    map[w,h] = NodeType.start;
                }
                else if(pixel == green) {
                    map[w,h] = NodeType.goal;
                }
                else if(pixel == white) {
                    map[w,h] = NodeType.accessible;
                }
                else if(pixel == black) {
                    map[w,h] = NodeType.blocked;
                }
            }
        }
    }

    public override string ToString() {
        string output = "";

        for(int h = 0; h < height; h++) {
            for(int w = 0; w < width; w++) {
                NodeType n = map[w,h];
                switch(n) {
                    case NodeType.accessible:
                        output += "⬜";
                        break;
                    case NodeType.blocked:
                        output += "⬛";
                        break;
                    case NodeType.start:
                        output += "🟥";
                        break;
                    case NodeType.goal:
                        output += "🟩";
                        break;
                }
                //output += $"{w},{h}";
            }
            output += "\n";
        }

        return output;
    }
    public NodeType GetNode(Node node) {
        return map[node.x, node.y];
    }

    public Node[] Neighbors(int w, int h) {
        Node left = new Node(w + 1, h);
        Node right = new Node(w - 1, h);
        Node above = new Node(w, h + 1);
        Node below = new Node(w, h - 1);

        List<Node> neighbors = new List<Node>();

        try {
            if (GetNode(left) != NodeType.blocked) {
                neighbors.Add(left);
            }
        } catch (System.IndexOutOfRangeException e) {}

        try {
            if (GetNode(right) != NodeType.blocked) {
                neighbors.Add(right);
            }
        } catch (System.IndexOutOfRangeException e) {}

        try {
            if (GetNode(above) != NodeType.blocked) {
                neighbors.Add(above);
            }
        } catch (System.IndexOutOfRangeException e) {}

        try {
            if (GetNode(below) != NodeType.blocked) {
                neighbors.Add(below);
            }
        } catch (System.IndexOutOfRangeException e) {}

        return neighbors.ToArray();
    }

    public Node[] Neighbors(Node n) {
        return Neighbors(n.x, n.y);
    }

    public Image<Rgba32> ToImage() {
        Image<Rgba32> image = new Image<Rgba32>(Configuration.Default, width, height);
        for(int w = 0; w < width; w++) {
            for(int h = 0; h < height; h++) {
                switch(map[w,h]) {
                    case NodeType.accessible:
                        image[w,h] = white;
                        break;
                    case NodeType.blocked:
                        image[w,h] = black;
                        break;
                    case NodeType.start:
                        image[w,h] = red;
                        break;
                    case NodeType.goal:
                        image[w,h] = green;
                        break;
                    case NodeType.path:
                        image[w,h] = blue;
                        break;
                }
            }
        }

        return image;
    }
}