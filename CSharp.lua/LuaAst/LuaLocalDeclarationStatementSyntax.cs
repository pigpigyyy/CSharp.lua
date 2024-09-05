/*
Copyright 2017 YANG Huan (sy.yanghuan@gmail.com).

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLua.LuaAst {
  public sealed class LuaLocalVariablesSyntax : LuaVariableDeclarationSyntax {
    public string LocalKeyword => Keyword.Local;
    public readonly LuaSyntaxList<LuaIdentifierNameSyntax> Variables = new();
    public LuaEqualsValueClauseListSyntax Initializer { get; set; }

    public LuaLocalVariablesSyntax(int line): base(line) {
    }

    public LuaLocalVariablesSyntax(IEnumerable<LuaIdentifierNameSyntax> variables, IEnumerable<LuaExpressionSyntax> values = null): base(-1) {
      Variables.AddRange(variables);
      if (values != null) {
        Initializer = new LuaEqualsValueClauseListSyntax(values);
      }
    }

    public override bool IsEmpty => Variables.Count == 0;

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaEqualsValueClauseListSyntax : LuaSyntaxNode {
    public string EqualsToken => Tokens.Equals;
    public readonly LuaSyntaxList<LuaExpressionSyntax> Values = new();

    public LuaEqualsValueClauseListSyntax(int line): base(line) {

    }

    public LuaEqualsValueClauseListSyntax(LuaExpressionSyntax value): base(value.line) {
      Values.Add(value);
    }

    public LuaEqualsValueClauseListSyntax(IEnumerable<LuaExpressionSyntax> values): base(-1) {
      Values.AddRange(values);
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public abstract class LuaVariableDeclarationSyntax : LuaSyntaxNode {
    protected LuaVariableDeclarationSyntax(int line) : base(line) {
    }

    public abstract bool IsEmpty { get; }

    public static implicit operator LuaStatementSyntax(LuaVariableDeclarationSyntax node) {
      return new LuaLocalDeclarationStatementSyntax(node);
    }
  }

  public sealed class LuaVariableListDeclarationSyntax : LuaVariableDeclarationSyntax {
    public readonly LuaSyntaxList<LuaVariableDeclaratorSyntax> Variables = new();

    public LuaVariableListDeclarationSyntax(int line) : base(line) {
    }

    public override bool IsEmpty => Variables.Count == 0;

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaLocalDeclarationStatementSyntax : LuaStatementSyntax {
    public LuaVariableDeclarationSyntax Declaration { get; }

    public LuaLocalDeclarationStatementSyntax(LuaVariableDeclarationSyntax declaration): base(declaration.line) {
      Declaration = declaration ?? throw new ArgumentNullException(nameof(declaration));
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaVariableDeclaratorSyntax : LuaSyntaxNode {
    public string LocalKeyword => Keyword.Local;
    public LuaIdentifierNameSyntax Identifier { get; }
    public LuaEqualsValueClauseSyntax Initializer { get; set; }

    public LuaVariableDeclaratorSyntax(LuaIdentifierNameSyntax identifier, LuaExpressionSyntax expression = null): base(identifier.line) {
      Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
      if (expression != null) {
        Initializer = new LuaEqualsValueClauseSyntax(expression);
      }
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaLocalVariableDeclaratorSyntax : LuaStatementSyntax {
    public LuaVariableDeclaratorSyntax Declarator { get; }

    public LuaLocalVariableDeclaratorSyntax(LuaVariableDeclaratorSyntax declarator): base(declarator.line) {
      Declarator = declarator ?? throw new ArgumentNullException(nameof(declarator));
    }

    public LuaLocalVariableDeclaratorSyntax(LuaIdentifierNameSyntax identifier, LuaExpressionSyntax expression = null): base(identifier.line) {
      Declarator = new LuaVariableDeclaratorSyntax(identifier, expression);
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaEqualsValueClauseSyntax : LuaSyntaxNode {
    public string EqualsToken => Tokens.Equals;
    public LuaExpressionSyntax Value { get; }

    public LuaEqualsValueClauseSyntax(LuaExpressionSyntax value): base(value.line) {
      Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaLocalAreaSyntax : LuaStatementSyntax {
    public string LocalKeyword => Keyword.Local;
    public readonly LuaSyntaxList<LuaIdentifierNameSyntax> Variables = new();

    public LuaLocalAreaSyntax(int line) : base(line) {
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaLocalFunctionSyntax : LuaStatementSyntax {
    public readonly LuaStatementListSyntax Comments = new(-1);
    public string LocalKeyword => Keyword.Local;
    public LuaIdentifierNameSyntax IdentifierName { get; }
    public LuaFunctionExpressionSyntax FunctionExpression { get; }

    public LuaLocalFunctionSyntax(LuaIdentifierNameSyntax identifierName, LuaFunctionExpressionSyntax functionExpression, LuaDocumentStatement documentation = null): base(identifierName.line) {
      IdentifierName = identifierName ?? throw new ArgumentNullException(nameof(identifierName));
      FunctionExpression = functionExpression ?? throw new ArgumentNullException(nameof(functionExpression));
      if (documentation != null) {
        Comments.Statements.Add(documentation);
      }
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaLocalTupleVariableExpression : LuaExpressionSyntax {
    public string LocalKeyword => Keyword.Local;
    public readonly LuaSyntaxList<LuaIdentifierNameSyntax> Variables = new();

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }

    public LuaLocalTupleVariableExpression(int line) : base(line) {
    }

    public LuaLocalTupleVariableExpression(IEnumerable<LuaIdentifierNameSyntax> variables): base(-1) {
      Variables.AddRange(variables);
    }
  }
}
