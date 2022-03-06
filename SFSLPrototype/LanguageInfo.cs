using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype;

public static class LanguageInfo
{
    public static IReadOnlyList<string> Keywords => keywordsList;

    private static readonly string[] keywordsList = new[]
    {
        "texture",
        "buffer",
        "in",
        "out",
        "struct",
        "void"
    };
}
