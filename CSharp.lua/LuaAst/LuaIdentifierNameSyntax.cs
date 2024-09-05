/*
Copyright 2017 YANG Huan (sy.yanghuan@gmail.com).

Licensed under the Apache License, Version 2.0 (the "License";
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

namespace CSharpLua.LuaAst {
  public class LuaIdentifierNameSyntax : LuaExpressionSyntax {
    public string ValueText { get; }

    public static readonly LuaIdentifierNameSyntax Empty = new("", -1);
    public static readonly LuaIdentifierNameSyntax Placeholder = new("_", -1);
    public static readonly LuaIdentifierNameSyntax One = new(1.ToString(), -1);
    public static readonly LuaIdentifierNameSyntax System = new("System", -1);
    public static readonly LuaIdentifierNameSyntax Namespace = new("namespace", -1);
    public static readonly LuaIdentifierNameSyntax Class = new("class", -1);
    public static readonly LuaIdentifierNameSyntax Struct = new("struct", -1);
    public static readonly LuaIdentifierNameSyntax Interface = new("interface", -1);
    public static readonly LuaIdentifierNameSyntax Enum = new("enum", -1);
    public static readonly LuaIdentifierNameSyntax Value = new("value", -1);
    public static readonly LuaIdentifierNameSyntax This = new("this", -1);
    public static readonly LuaIdentifierNameSyntax True = new("true", -1);
    public static readonly LuaIdentifierNameSyntax False = new("false", -1);
    public static readonly LuaIdentifierNameSyntax Throw = new("System.throw", -1);
    public static readonly LuaIdentifierNameSyntax Each = new("System.each", -1);
    public static readonly LuaIdentifierNameSyntax Object = new("System.Object", -1);
    public static readonly LuaIdentifierNameSyntax Array = new("System.Array", -1);
    public static readonly LuaIdentifierNameSyntax EmptyArray = new("System.Array.Empty", -1);
    public static readonly LuaIdentifierNameSyntax Apply = new("System.apply", -1);
    public static readonly LuaIdentifierNameSyntax StaticCtor = new("static", -1);
    public static readonly LuaIdentifierNameSyntax Init = new("internal", -1);
    public static readonly LuaIdentifierNameSyntax Ctor = new("__ctor__", -1);
    public static readonly LuaIdentifierNameSyntax Inherits = new("base", -1);
    public static readonly LuaIdentifierNameSyntax SystemDefault = new("System.default", -1);
    public static readonly LuaIdentifierNameSyntax Property = new("System.property", -1);
    public static readonly LuaIdentifierNameSyntax Event = new("System.event", -1);
    public static readonly LuaIdentifierNameSyntax SystemVoid = new("System.Void", -1);
    public static readonly LuaIdentifierNameSyntax Nil = new("nil", -1);
    public static readonly LuaIdentifierNameSyntax TypeOf = new("System.typeof", -1);
    public static readonly LuaIdentifierNameSyntax Continue = new("continue", -1);
    public static readonly LuaIdentifierNameSyntax StringChar = new("string.char", -1);
    public static readonly LuaIdentifierNameSyntax ToStr = new("ToString", -1);
    public static readonly LuaIdentifierNameSyntax SystemToString = new("System.toString", -1);
    public static readonly LuaIdentifierNameSyntax EnumToString = new("EnumToString", -1);
    public static readonly LuaIdentifierNameSyntax DelegateMake = new("System.fn", -1);
    public static readonly LuaIdentifierNameSyntax DelegateBind = new("System.bind", -1);
    public static readonly LuaIdentifierNameSyntax DelegateCombine = new("System.DelegateCombine", -1);
    public static readonly LuaIdentifierNameSyntax DelegateRemove = new("System.DelegateRemove", -1);
    public static readonly LuaIdentifierNameSyntax IntegerDiv = new("System.div", -1);
    public static readonly LuaIdentifierNameSyntax Mod = new("System.mod", -1);
    public static readonly LuaIdentifierNameSyntax ModFloat = new("System.modf", -1);
    public static readonly LuaIdentifierNameSyntax BitNot = new("System.bnot", -1);
    public static readonly LuaIdentifierNameSyntax BitAnd = new("System.band", -1);
    public static readonly LuaIdentifierNameSyntax BitOr = new("System.bor", -1);
    public static readonly LuaIdentifierNameSyntax BitXor = new("System.xor", -1);
    public static readonly LuaIdentifierNameSyntax ShiftRight = new("System.sr", -1);
    public static readonly LuaIdentifierNameSyntax ShiftLeft = new("System.sl", -1);
    public static readonly LuaIdentifierNameSyntax Try = new("System.try", -1);
    public static readonly LuaIdentifierNameSyntax CatchFilter = new("System.when", -1);
    public static readonly LuaIdentifierNameSyntax Is = new("System.is", -1);
    public static readonly LuaIdentifierNameSyntax As = new("System.as", -1);
    public static readonly LuaIdentifierNameSyntax Cast = new("System.cast", -1);
    public static readonly LuaIdentifierNameSyntax Using = new("System.using", -1);
    public static readonly LuaIdentifierNameSyntax UsingX = new("System.usingX", -1);
    public static readonly LuaIdentifierNameSyntax Linq = new("Linq", -1);
    public static readonly LuaIdentifierNameSyntax SystemLinqEnumerable = new("System.Linq.Enumerable", -1);
    public static readonly LuaIdentifierNameSyntax Delegate = new("System.Delegate", -1);
    public static readonly LuaIdentifierNameSyntax Import = new("System.import", -1);
    public static readonly LuaIdentifierNameSyntax Global = new("out", -1);
    public static readonly LuaIdentifierNameSyntax Metadata = new("__metadata__", -1);
    public static readonly LuaIdentifierNameSyntax Fields = new("fields", -1);
    public static readonly LuaIdentifierNameSyntax Properties = new("properties", -1);
    public static readonly LuaIdentifierNameSyntax Events = new("events", -1);
    public static readonly LuaIdentifierNameSyntax Methods = new("methods", -1);
    public static readonly LuaIdentifierNameSyntax Clone = new("__clone__", -1);
    public static readonly LuaIdentifierNameSyntax NullableClone = new("System.Nullable.clone", -1);
    public static readonly LuaIdentifierNameSyntax CopyThis = new("__copy__", -1);
    public static readonly LuaIdentifierNameSyntax RecordMembers = new("__members__", -1);
    public static readonly LuaIdentifierNameSyntax DateTime = new("System.DateTime", -1);
    public static readonly LuaIdentifierNameSyntax TimeSpan = new("System.TimeSpan", -1);
    public static readonly LuaIdentifierNameSyntax AnonymousType = new("System.AnonymousType", -1);
    public static readonly LuaIdentifierNameSyntax New = new("new", -1);
    public static readonly LuaIdentifierNameSyntax SystemNew = new("System.new", -1);
    public static readonly LuaIdentifierNameSyntax StackAlloc = new("System.stackalloc", -1);
    public static readonly LuaIdentifierNameSyntax GenericT = new("__genericT__", -1);
    public static readonly LuaIdentifierNameSyntax Base = new("base", -1);
    public static readonly LuaIdentifierNameSyntax SystemBase = new("System.base", -1);
    public static readonly LuaIdentifierNameSyntax Tuple = new("System.Tuple", -1);
    public static readonly LuaIdentifierNameSyntax RecordType = new("System.RecordType", -1);
    public static readonly LuaIdentifierNameSyntax RecordValueType = new("System.RecordValueType", -1);
    public static readonly LuaIdentifierNameSyntax Deconstruct = new("Deconstruct", -1);
    public static readonly LuaIdentifierNameSyntax NullableType = new("System.Nullable", -1);
    public static readonly LuaIdentifierNameSyntax Range = new("System.Range", -1);
    public static readonly LuaIdentifierNameSyntax Index = new("System.Index", -1);
    public static readonly LuaIdentifierNameSyntax IndexGetOffset = new("System.Index.GetOffset", -1);
    public static readonly LuaIdentifierNameSyntax __GC = new("__gc", -1);
    public static readonly LuaIdentifierNameSyntax __ToString = new("__tostring", -1);
    public static readonly LuaIdentifierNameSyntax Await = new("await", -1);
    public static readonly LuaIdentifierNameSyntax AwaitAnything = new("Await", -1);
    public static readonly LuaIdentifierNameSyntax Async = new("async", -1);
    public static readonly LuaIdentifierNameSyntax AsyncEach = new("System.asynceach", -1);
    public static readonly LuaIdentifierNameSyntax MoreManyLocalVarTempTable = new("const", -1);
    public static readonly LuaIdentifierNameSyntax InterfaceDefaultMethodVar = new("extern", -1);
    public static readonly LuaIdentifierNameSyntax SystemInit = new("System.init", -1);
    public static readonly LuaIdentifierNameSyntax InlineReturnLabel = new("out", -1);

    #region QueryExpression
    public static readonly LuaIdentifierNameSyntax LinqCast = new("Linq.Cast", -1);
    public static readonly LuaIdentifierNameSyntax LinqWhere = new("Linq.Where", -1);
    public static readonly LuaIdentifierNameSyntax LinqSelect = new("Linq.Select", -1);
    public static readonly LuaIdentifierNameSyntax LinqSelectMany = new("Linq.SelectMany", -1);
    public static readonly LuaIdentifierNameSyntax LinqOrderBy = new("Linq.OrderBy", -1);
    public static readonly LuaIdentifierNameSyntax LinqOrderByDescending = new("Linq.OrderByDescending", -1);
    public static readonly LuaIdentifierNameSyntax LinqThenBy = new("Linq.ThenBy", -1);
    public static readonly LuaIdentifierNameSyntax LinqThenByDescending = new("Linq.ThenByDescending", -1);
    public static readonly LuaIdentifierNameSyntax LinqGroupBy = new("Linq.GroupBy", -1);
    public static readonly LuaIdentifierNameSyntax LinqJoin = new("Linq.Join", -1);
    public static readonly LuaIdentifierNameSyntax LinqGroupJoin = new("Linq.GroupJoin", -1);
    #endregion

    public LuaIdentifierNameSyntax(string valueText, int line): base(line) {
      ValueText = valueText;
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }

    internal LuaStringLiteralExpressionSyntax ToStringLiteral() => new(this);
  }

  public sealed class LuaPropertyOrEventIdentifierNameSyntax : LuaIdentifierNameSyntax {
    public bool IsGetOrAdd { get; set; }
    public bool IsProperty { get; }
    public LuaIdentifierNameSyntax Name { get; }

    public LuaPropertyOrEventIdentifierNameSyntax(bool isProperty, LuaIdentifierNameSyntax name) : this(isProperty, true, name) {
    }

    public LuaPropertyOrEventIdentifierNameSyntax(bool isProperty, bool isGetOrAdd, LuaIdentifierNameSyntax name) : base(string.Empty, name.line) {
      IsProperty = isProperty;
      IsGetOrAdd = isGetOrAdd;
      Name = name;
    }

    public string PrefixToken {
      get {
        if (IsProperty) {
          return IsGetOrAdd ? Tokens.Get : Tokens.Set;
        }

        return IsGetOrAdd ? Tokens.Add : Tokens.Remove;
      }
    }

    public LuaPropertyOrEventIdentifierNameSyntax GetClone() {
      return new(IsProperty, Name) { IsGetOrAdd = IsGetOrAdd };
    }

    internal override void Render(LuaRenderer renderer) {
      renderer.Render(this);
    }
  }

  public sealed class LuaSymbolNameSyntax : LuaIdentifierNameSyntax {
    public LuaExpressionSyntax NameExpression { get; private set; }

    public LuaSymbolNameSyntax(LuaExpressionSyntax identifierName) : base("", identifierName.line) {
      NameExpression = identifierName;
    }

    public void Update(string newName, int line) {
      NameExpression = new LuaIdentifierNameSyntax(newName, line);
    }

    internal override void Render(LuaRenderer renderer) {
      NameExpression.Render(renderer);
    }
  }

  public sealed class LuaImportNameSyntax : LuaIdentifierNameSyntax {
    public string TypeName { get; }

    public LuaImportNameSyntax(string shorName, string name, int line) : base(shorName, line) {
      TypeName = name;
    }
  }
}
