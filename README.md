# Pathfinding

## Usage
`dotnet run -- <input file> <output file>` where `<input file>` is the path to an image, with the starting pixel in red, the ending pixel in green, obstacle pixels in black, and all other pixels in white. The program will find a path frmo the red pixel to the green pixel, avoiding black pixels, and output it to `<output file>`, with the path in blue.

## Supported image file types
* JPG
* PNG
* BMP
* GIF
* TGA
