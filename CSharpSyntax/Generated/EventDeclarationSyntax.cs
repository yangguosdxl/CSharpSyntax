using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CSharpSyntax
{
    public sealed partial class EventDeclarationSyntax : BasePropertyDeclarationSyntax
    {
        public string Identifier { get; set; }
        
        public EventDeclarationSyntax()
            : base(SyntaxKind.EventDeclaration)
        {
        }
        
        [DebuggerStepThrough]
        public override void Accept(ISyntaxVisitor visitor)
        {
            if (!visitor.Done)
                visitor.VisitEventDeclaration(this);
        }
        
        [DebuggerStepThrough]
        public override T Accept<T>(ISyntaxVisitor<T> visitor)
        {
            return visitor.VisitEventDeclaration(this);
        }
    }
}
