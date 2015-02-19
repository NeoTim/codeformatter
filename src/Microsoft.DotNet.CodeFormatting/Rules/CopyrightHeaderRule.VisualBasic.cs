// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using System.Collections.Immutable;

namespace Microsoft.DotNet.CodeFormatting.Rules
{
    internal partial class CopyrightHeaderRule
    {
        private sealed class VisualBasicRule : CommonRule
        {
            internal VisualBasicRule(ImmutableArray<string> header) : base(header)
            {
            }

            protected override SyntaxTriviaList CreateTriviaList(IEnumerable<SyntaxTrivia> e)
            {
                return SyntaxFactory.TriviaList(e);
            }

            protected override bool IsLineComment(SyntaxTrivia trivia)
            {
                return trivia.VBKind() == SyntaxKind.CommentTrivia;
            }

            protected override bool IsWhiteSpaceOrNewLine(SyntaxTrivia trivia)
            {
                return
                    trivia.VBKind() == SyntaxKind.WhitespaceTrivia ||
                    trivia.VBKind() == SyntaxKind.EndOfLineTrivia;
            }

            protected override SyntaxTrivia CreateLineComment(string commentText)
            {
                return SyntaxFactory.CommentTrivia("' " + commentText);
            }

            protected override SyntaxTrivia CreateNewLine()
            {
                return SyntaxFactory.CarriageReturnLineFeed;
            }
        }
    }
}
