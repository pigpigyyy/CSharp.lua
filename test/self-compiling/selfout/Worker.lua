-- Generated by CSharp.lua Compiler 1.0.0.0
local System = System
local Linq = System.Linq.Enumerable
local MicrosoftCodeAnalysis = Microsoft.CodeAnalysis
local MicrosoftCodeAnalysisCSharp = Microsoft.CodeAnalysis.CSharp
local SystemIO = System.IO
local SystemRuntimeInteropServices = System.Runtime.InteropServices
local SystemThreading = System.Threading
local CSharpLua
local CSharpLuaLuaSyntaxGenerator
System.usingDeclare(function (global) 
    CSharpLua = global.CSharpLua
    CSharpLuaLuaSyntaxGenerator = CSharpLua.LuaSyntaxGenerator
end)
System.namespace("CSharpLua", function (namespace) 
    namespace.class("Worker", function (namespace) 
        local SystemDlls, getMetas, getLibs, Do, Compiler, __staticCtor__, __ctor__
        __staticCtor__ = function (this) 
            SystemDlls = System.Array(System.String)("mscorlib.dll", "System.dll", "System.Core.dll", "Microsoft.CSharp.dll")
        end
        __ctor__ = function (this, folder, output, lib, meta, defines, isClassic, indent, hasSemicolon, atts) 
            this.folder_ = folder
            this.output_ = output
            this.libs_ = CSharpLua.Utility.Split(lib, true)
            this.metas_ = CSharpLua.Utility.Split(meta, true)
            this.defines_ = CSharpLua.Utility.Split(defines, false)
            this.isNewest_ = not isClassic
            this.hasSemicolon_ = hasSemicolon
            local default
            default, this.indent_ = System.Int.TryParse(indent, this.indent_)
            if atts ~= nil then
                this.attributes_ = CSharpLua.Utility.Split(atts, false)
            end
        end
        getMetas = function (this) 
            local metas = System.List(System.String)()
            metas:Add(CSharpLua.Utility.GetCurrentDirectory("~/System.xml" --[[Worker.kSystemMeta]]))
            metas:AddRange(this.metas_)
            return metas
        end
        getLibs = function (this) 
            local runtimeDir = SystemRuntimeInteropServices.RuntimeEnvironment.GetRuntimeDirectory()
            local libs = System.List(System.String)()
            libs:AddRange(Linq.Select(SystemDlls, function (i) 
                return SystemIO.Path.Combine(runtimeDir, i)
            end, System.String))
            for _, lib in System.each(this.libs_) do
                local default
                if lib:EndsWith(".dll" --[[Worker.kDllSuffix]]) then
                    default = lib
                else
                    default = (lib or "") .. ".dll" --[[Worker.kDllSuffix]]
                end
                local path = default
                if not SystemIO.File.Exists(path) then
                    local file = SystemIO.Path.Combine(runtimeDir, SystemIO.Path.GetFileName(path))
                    if not SystemIO.File.Exists(file) then
                        System.throw(CSharpLua.CmdArgumentException(("lib '{0}' is not found"):Format(path)))
                    end
                    path = file
                end
                libs:Add(path)
            end
            return libs
        end
        Do = function (this) 
            Compiler(this)
        end
        Compiler = function (this) 
            local parseOptions = MicrosoftCodeAnalysisCSharp.CSharpParseOptions(6, 1, 0, this.defines_)
            local files = SystemIO.Directory.EnumerateFiles(this.folder_, "*.cs", 1 --[[SearchOption.AllDirectories]])
            local syntaxTrees = Linq.Select(files, function (file) 
                return MicrosoftCodeAnalysisCSharp.CSharpSyntaxTree.ParseText(SystemIO.File.ReadAllText(file), parseOptions, file, nil, System.default(SystemThreading.CancellationToken))
            end, MicrosoftCodeAnalysis.SyntaxTree)
            local references = Linq.Select(getLibs(this), function (i) 
                return MicrosoftCodeAnalysis.MetadataReference.CreateFromFile(i, System.default(MicrosoftCodeAnalysis.MetadataReferenceProperties), nil)
            end, MicrosoftCodeAnalysis.PortableExecutableReference)
            local setting = System.create(CSharpLuaLuaSyntaxGenerator.SettingInfo(), function (default) 
                default.IsNewest = this.isNewest_
                default.HasSemicolon = this.hasSemicolon_
                default:setIndent(this.indent_)
            end)
            local generator = CSharpLua.LuaSyntaxGenerator(syntaxTrees, references, getMetas(this), setting, this.attributes_)
            generator:Generate(this.folder_, this.output_)
        end
        return {
            isNewest_ = false, 
            indent_ = 0, 
            hasSemicolon_ = false, 
            Do = Do, 
            __staticCtor__ = __staticCtor__, 
            __ctor__ = __ctor__
        }
    end)
end)