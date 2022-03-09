using SFSLPrototype;
string src = @"
int myInt;
float myFloat
vector4 myVector4;
uvector4 myUVec4;

texture myTexture;
";

Compiler c = new();
var r = c.Compile(src);
Console.Read();