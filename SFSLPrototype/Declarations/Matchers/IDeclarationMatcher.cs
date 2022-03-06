using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFSLPrototype.Declarations;

namespace SFSLPrototype.Declarations.Matchers;

internal interface IDeclarationMatcher
{
    IEnumerable<bool> Match(MatchingContext context, TokenReader reader, ScopeContext scope);
    Declaration Build(MatchingContext context, TokenReader keptTokens);
}
