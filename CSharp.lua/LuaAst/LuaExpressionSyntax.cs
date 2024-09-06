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
  public abstract class LuaExpressionSyntax : LuaSyntaxNode {
    private sealed class EmptyLuaExpressionSyntax : LuaExpressionSyntax {
      public EmptyLuaExpressionSyntax() : base(-1) {
      }

      internal override void Render(LuaRenderer renderer) {
      }
    }

    public static readonly LuaExpressionSyntax EmptyExpression = new EmptyLuaExpressionSyntax();

    public static implicit operator LuaExpressionSyntax(double number) {
      LuaNumberLiteralExpressionSyntax numberLiteral = number;
      return numberLiteral;
    }

    protected LuaExpressionSyntax(int line) : base(line) {
    }

    public LuaExpressionStatementSyntax ToStatementSyntax() {
      return this;
    }

    public LuaBinaryExpressionSyntax Plus(LuaExpressionSyntax right) {
      return Binary(Tokens.Plus, right);
    }

    public LuaBinaryExpressionSyntax Sub(LuaExpressionSyntax right) {
      return Binary(Tokens.Sub, right);
    }

    public LuaBinaryExpressionSyntax And(LuaExpressionSyntax right) {
      return Binary(Keyword.And, right);
    }

    public LuaBinaryExpressionSyntax Or(LuaExpressionSyntax right) {
      return Binary(Keyword.Or, right);
    }

    public LuaBinaryExpressionSyntax EqualsEquals(LuaExpressionSyntax right) {
      return Binary(Tokens.EqualsEquals, right);
    }

    public LuaBinaryExpressionSyntax NotEquals(LuaExpressionSyntax right) {
      return Binary(Tokens.NotEquals, right);
    }

    public LuaBinaryExpressionSyntax Binary(string operatorToken, LuaExpressionSyntax right) {
      return new(this, operatorToken, right);
    }

    public LuaMemberAccessExpressionSyntax MemberAccess(LuaExpressionSyntax name, bool isObjectColon = false) {
      return new(this, name, isObjectColon);
    }

    public LuaAssignmentExpressionSyntax Assignment(LuaExpressionSyntax right) {
      return new(this, right);
    }

    public LuaParenthesizedExpressionSyntax Parenthesized() {
      return new(this);
    }

    public LuaInvocationExpressionSyntax Invocation() {
      return new(this, line);
    }

    public LuaInvocationExpressionSyntax Invocation(params LuaExpressionSyntax[] arguments) {
      return new(this, line, arguments);
    }

    public LuaInvocationExpressionSyntax Invocation(IEnumerable<LuaExpressionSyntax> arguments) {
      return new(this, line, arguments);
    }

    public LuaPrefixUnaryExpressionSyntax Not() {
      return new(this, Keyword.Not);
    }
  }

  public sealed class LuaAssignmentExpressionSyntax : LuaExpressionSyntax {
    public LuaExpressionSyntax Left { get; }
    public string OperatorToken => Tokens.Equals;
    public LuaExpressionSyntax Right { get; }

    public LuaAssignmentExpressionSyntax(LuaExpressionSyntax left, LuaExpressionSyntax right): base(left.line < 0 ? right.line : left.line) {
      Left = left ?? throw new ArgumentNullException(nameof(left));
      Right = right ?? throw new ArgumentNullException(nameof(right));
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaMultipleAssignmentExpressionSyntax : LuaExpressionSyntax {
    public LuaMultipleAssignmentExpressionSyntax(int line) : base(line) {
    }

    public LuaSyntaxList<LuaExpressionSyntax> Lefts { get; } = new();
    public string OperatorToken => Tokens.Equals;
    public LuaSyntaxList<LuaExpressionSyntax> Rights { get; } = new();

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaLineMultipleExpressionSyntax : LuaExpressionSyntax {
    public LuaLineMultipleExpressionSyntax(int line) : base(line) {
    }

    public LuaSyntaxList<LuaExpressionSyntax> Assignments { get; } = new();

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaBinaryExpressionSyntax : LuaExpressionSyntax {
    public LuaExpressionSyntax Left { get; }
    public string OperatorToken { get; }
    public LuaExpressionSyntax Right { get; }

    public LuaBinaryExpressionSyntax(LuaExpressionSyntax left, string operatorToken, LuaExpressionSyntax right): base(left.line) {
      Left = left ?? throw new ArgumentNullException(nameof(left));
      OperatorToken = operatorToken;
      Right = right ?? throw new ArgumentNullException(nameof(right));
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }

    public bool IsLogic => OperatorToken == Tokens.And || OperatorToken == Tokens.Or;
  }

  public sealed class LuaPrefixUnaryExpressionSyntax : LuaExpressionSyntax {
    public LuaExpressionSyntax Operand { get; }
    public string OperatorToken { get; }

    public LuaPrefixUnaryExpressionSyntax(LuaExpressionSyntax operand, string operatorToken): base(operand.line) {
      Operand = operand ?? throw new ArgumentNullException(nameof(operand));
      OperatorToken = operatorToken;
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaParenthesizedExpressionSyntax : LuaExpressionSyntax {
    public LuaExpressionSyntax Expression { get; }
    public string OpenParenToken => Tokens.OpenParentheses;
    public string CloseParenToken => Tokens.CloseParentheses;

    public LuaParenthesizedExpressionSyntax(LuaExpressionSyntax expression): base(expression.line) {
      Expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaCodeTemplateExpressionSyntax : LuaExpressionSyntax {
    public readonly LuaSyntaxList<LuaExpressionSyntax> Expressions = new();

    public LuaCodeTemplateExpressionSyntax(int line): base(line) { }

    public LuaCodeTemplateExpressionSyntax(params LuaExpressionSyntax[] expressions): base(expressions.Length > 0 ? expressions[0].line : -1) {
      Expressions.AddRange(expressions);
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaArrayRankSpecifierSyntax : LuaSyntaxNode {
    public int Rank { get; }
    public readonly List<LuaExpressionSyntax> Sizes = new();

    public LuaArrayRankSpecifierSyntax(int rank, int line) : base(line) {
      Rank = rank;
    }
  }

  public sealed class LuaArrayTypeAdapterExpressionSyntax : LuaExpressionSyntax {
    public LuaExpressionSyntax TypeExpression { get; }
    public LuaArrayRankSpecifierSyntax RankSpecifier { get; }

    public LuaArrayTypeAdapterExpressionSyntax(LuaExpressionSyntax typeExpression, LuaArrayRankSpecifierSyntax rankSpecifier): base(typeExpression.line) {
      TypeExpression = typeExpression ?? throw new ArgumentNullException(nameof(typeExpression));
      RankSpecifier = rankSpecifier ?? throw new ArgumentNullException(nameof(rankSpecifier));
    }

    public bool IsSimpleArray {
      get {
        return RankSpecifier.Rank == 1;
      }
    }

    internal override void Render(LuaRenderer renderer) {
      TypeExpression.Render(renderer);
    }
  }

  public sealed class LuaInternalMethodExpressionSyntax : LuaExpressionSyntax {
    public LuaExpressionSyntax Expression { get; }

    public LuaInternalMethodExpressionSyntax(LuaExpressionSyntax expression): base(expression.line) {
      Expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }

    internal override void Render(LuaRenderer renderer) {
      Expression.Render(renderer);
    }
  }

  public sealed class LuaSequenceListExpressionSyntax : LuaExpressionSyntax {
    public readonly LuaSyntaxList<LuaExpressionSyntax> Expressions = new();

    public LuaSequenceListExpressionSyntax(int line): base(line) {
    }

    public LuaSequenceListExpressionSyntax(IEnumerable<LuaExpressionSyntax> expressions): base(-1) {
      Expressions.AddRange(expressions);
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }
}
