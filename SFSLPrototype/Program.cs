using SFSLPrototype;
using SFSLPrototype.Declarations.Matchers;
using SFSLPrototype.Emit.GLSL;

var src = File.ReadAllText("sample.sfsl");
src = @"
struct MyStruct 
{
    int myIntegerValue;
    float myFloatingPointValue;
}

[thisstructisverycool]
struct ThisIsACoolStruct { myStruct value; }

buffer<int> myintBuffer2;

[whatausefultexture]
texture thisTextureIsMuchUseful;

int thisVariableIsSick;
in int thisVariableIsIn;
out int thisVariableIsOut;

void checkOutThisFunction(int andThisParameter)
{
    float myFloat = 2 * 4;
}

";

// do a thing
var tokens = Token.Tokenize(src);

var table = new DeclarationTable();
table.RegisterMatcher(new StructMatcher());
table.RegisterMatcher(new AttributeMatcher());
table.RegisterMatcher(new BufferMatcher());
table.RegisterMatcher(new TextureMatcher());
table.RegisterMatcher(new VariableMatcher());
table.RegisterMatcher(new FunctionMatcher());
table.Build(tokens);

// here the table is full of declarations, but no method bodies
// also emitter does nothing lmao
GlslEmitter emitter = new(Console.Out);
table.Accept(emitter);


//tokens.ForEach(token => Console.Write($"'{token}', "));
//var declarations = BuildDeclarations(tokens);
//Console.WriteLine();
//Console.WriteLine(declarations);

//DeclarationTable BuildDeclarations(List<string> tokens)
//{
//    DeclarationTable result = new();
//    List<DeclarationAttribute> attributes = new();
//    for (int i = 0; i < tokens.Count; i++)
//    {
//        switch (tokens[i])
//        {
//            case "[":
//                attributes.Add(new(tokens[++i]));
//                if (tokens[++i] != "]") throw new Exception("Expected ']'!");
//                break;
//            case "struct":
//                string name = tokens[++i];
//                List<StructMember> members = new();
//                if (tokens[++i] != "{")
//                    throw new Exception("expected '{'!");

//                while (tokens[i + 1] != "}")
//                {
//                    members.Add(new StructMember(tokens[++i], tokens[++i]));
//                    if (tokens[++i] != ";") throw new Exception("Expected ';'!");
//                }
//                i++; // skip }

//                result.structDeclarations.Add(new(name, members.ToArray())
//                {
//                    Attributes = attributes.ToArray()
//                });
//                attributes.Clear();
//                break;
//            case "buffer":
//                if (tokens[++i] != "<")
//                    throw new Exception("expected '<'!");
//                string type = tokens[++i];
//                if (tokens[++i] != ">")
//                    throw new Exception("expected '>'!");
//                name = tokens[++i];
//                if (tokens[++i] != ";")
//                    throw new Exception("expected ';'!");
//                result.bufferDeclarations.Add(new(name, type));
//                break;
//            case "texture":
//                name = tokens[++i];
//                if (tokens[++i] != ";")
//                    throw new Exception("expected ';'!");
//                result.textureDeclarations.Add(new(name));
//                break;
//            case "in":
//            case "out":
//                i++;
//                goto default;
//            default:
//                VariableModifier modifier = VariableModifier.None;
//                if (tokens[i - 1] == "in")
//                    modifier = VariableModifier.In;
//                if (tokens[i - 1] == "out")
//                    modifier = VariableModifier.Out;

//                type = tokens[i];
//                name = tokens[++i];
//                if (tokens[++i] == ";")
//                {
//                    result.variableDeclarations.Add(new(name, type, modifier)
//                    {
//                        Attributes = attributes.ToArray()
//                    });
//                    attributes.Clear();
//                }
//                else if (tokens[i] == "(" || tokens[i] == "()")
//                {
//                    List<FunctionParameter> parameters = new();
//                    if (tokens[i] != "()")
//                    {
//                        while (tokens[i + 1] != ")")
//                        {
//                            parameters.Add(new(tokens[++i], tokens[++i]));
//                            if (tokens[++i] != ",")
//                            {
//                                if (tokens[i] == ")")
//                                    break;
//                                else throw new Exception("Expected ','!");
//                            }
//                        }
//                    }

//                    if (tokens[++i] != "{")
//                        throw new Exception("Expected function body '{'!");
//                    int bodyBegin = i;
//                    int depth = 1;
//                    while (depth != 0)

//                    {
//                        i++;
//                        if (tokens[i] == "{") depth++;
//                        if (tokens[i] == "}") depth--;
//                    }

//                    result.functionDeclarations.Add(new(name, type, parameters.ToArray(), tokens.ToArray()[bodyBegin..(i+1)])
//                    {
//                        Attributes=attributes.ToArray()
//                    });
//                    attributes.Clear();
//                }
//                else throw new Exception("expected '(' or ';'");
//                break;
//        }
//    }

//    return result;
//}

//class DeclarationTable
//{
//    public readonly List<StructDeclaration> structDeclarations = new();
//    public readonly List<TextureDeclaration> textureDeclarations = new();
//    public readonly List<BufferDeclaration> bufferDeclarations = new();
//    public readonly List<VariableDeclaration> variableDeclarations = new();
//    public readonly List<FunctionDeclaration> functionDeclarations = new();
//}

//enum VariableModifier { None, In, Out };
//record DeclarationAttribute(string Name);
//record Declaration(string Name, params DeclarationAttribute[] Attributes);
//record TextureDeclaration(string Name) : Declaration(Name);
//record BufferDeclaration(string Name, string Type) : Declaration(Name);
//record VariableDeclaration(string Name, string Type, VariableModifier Modifier) : Declaration(Name);
//record StructDeclaration(string Name, params StructMember[] Members) : Declaration(Name);
//record StructMember(string Name, string Type);
//record FunctionDeclaration(string Name, string ReturnType, FunctionParameter[] Parameters, string[] bodyTokens) : Declaration(Name);
//record FunctionParameter(string Name, string Type);