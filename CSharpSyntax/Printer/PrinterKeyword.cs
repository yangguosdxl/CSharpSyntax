﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSyntax.Printer
{
    public enum PrinterKeyword
    {
        [EnumText("bool")]
        Bool,
        [EnumText("byte")]
        Byte,
        [EnumText("sbyte")]
        SByte,
        [EnumText("short")]
        Short,
        [EnumText("ushort")]
        UShort,
        [EnumText("int")]
        Int,
        [EnumText("uint")]
        UInt,
        [EnumText("long")]
        Long,
        [EnumText("ulong")]
        ULong,
        [EnumText("double")]
        Double,
        [EnumText("float")]
        Float,
        [EnumText("decimal")]
        Decimal,
        [EnumText("string")]
        String,
        [EnumText("char")]
        Char,
        [EnumText("void")]
        Void,
        [EnumText("object")]
        Object,
        [EnumText("as")]
        As,
        [EnumText("is")]
        Is,
        [EnumText("abstracat")]
        Abstract,
        [EnumText("const")]
        Const,
        [EnumText("extern")]
        Extern,
        [EnumText("internal")]
        Internal,
        [EnumText("new")]
        New,
        [EnumText("override")]
        Override,
        [EnumText("partial")]
        Partial,
        [EnumText("private")]
        Private,
        [EnumText("protected")]
        Protected,
        [EnumText("public")]
        Public,
        [EnumText("readonly")]
        ReadOnly,
        [EnumText("sealed")]
        Sealed,
        [EnumText("static")]
        Static,
        [EnumText("unset")]
        Unset,
        [EnumText("virtual")]
        Virtual,
        [EnumText("volatile")]
        Volatile,
        [EnumText("add")]
        Add,
        [EnumText("get")]
        Get,
        [EnumText("remove")]
        Remove,
        [EnumText("set")]
        Set,
        [EnumText("var")]
        Var,
        [EnumText("global")]
        Global,
        [EnumText("ref")]
        Ref,
        [EnumText("out")]
        Out,
        [EnumText("class")]
        Class,
        [EnumText("struct")]
        Struct,
        [EnumText("interface")]
        Interface,
        [EnumText("in")]
        In,
        [EnumText("where")]
        Where,
        [EnumText("assembly")]
        Assembly,
        [EnumText("event")]
        Event,
        [EnumText("field")]
        Field,
        [EnumText("method")]
        Method,
        [EnumText("module")]
        Module,
        [EnumText("param")]
        Param,
        [EnumText("property")]
        Property,
        [EnumText("return")]
        Return,
        [EnumText("type")]
        Type,
        [EnumText("base")]
        Base,
        [EnumText("this")]
        This,
        [EnumText("break")]
        Break,
        [EnumText("try")]
        Try,
        [EnumText("catch")]
        Catch,
        [EnumText("finally")]
        Finally,
        [EnumText("checked")]
        Checked,
        [EnumText("unchecked")]
        Unchecked,
        [EnumText("using")]
        Using,
        [EnumText("alias")]
        Alias,
        [EnumText("continue")]
        Continue,
        [EnumText("explicit")]
        Explicit,
        [EnumText("implicit")]
        Implicit,
        [EnumText("operator")]
        Operator,
        [EnumText("default")]
        Default,
        [EnumText("delegate")]
        Delegate,
        [EnumText("do")]
        Do,
        [EnumText("while")]
        While,
        [EnumText("if")]
        If,
        [EnumText("else")]
        Else,
        [EnumText("enum")]
        Enum,
        [EnumText("foreach")]
        ForEach,
        [EnumText("for")]
        For,
        [EnumText("goto")]
        Goto,
        [EnumText("case")]
        Case,
        [EnumText("lock")]
        Lock,
        [EnumText("namespace")]
        Namespace,
        [EnumText("false")]
        False,
        [EnumText("true")]
        True,
        [EnumText("sizeof")]
        SizeOf,
        [EnumText("switch")]
        Switch,
        [EnumText("throw")]
        Throw,
        [EnumText("typeof")]
        TypeOf,
        [EnumText("yield")]
        Yield,
        [EnumText("from")]
        From,
        [EnumText("select")]
        Select,
        [EnumText("on")]
        On,
        [EnumText("equals")]
        Equals,
        [EnumText("into")]
        Into,
        [EnumText("join")]
        Join,
        [EnumText("let")]
        Let,
        [EnumText("orderby")]
        OrderBy,
        // Ascending is the default orderby, so we don't output this.
        //[EnumText("ascending")]
        //Ascending,
        [EnumText("descending")]
        Descending,
        [EnumText("group")]
        Group,
        [EnumText("by")]
        By,
        [EnumText("await")]
        Await,
        [EnumText("async")]
        Async
    }
}
