﻿grammar CSharpNames;

options
{
	language = CSharp3;
	TokenLabelType = CommonToken;
	output = AST;
	ASTLabelType = CommonTree;
	backtrack=true;
	memoize=true;
	k=2;
}

@header
{
	// using Expressions.Ast;
}

@rulecatch
{
    catch (RecognitionException) 
    {
        throw;
    }
}

@lexer::namespace { CSharpSyntax.NameParsing }
@parser::namespace { CSharpSyntax.NameParsing }
@lexer::modifier { internal }
@parser::modifier { internal }

prog returns [TypeSyntax value]
    : an=any_name { $value = $an.value; } EOF
    ;

any_name returns [TypeSyntax value]
    : a=array { $value = $a.value; }
    ;

array returns [TypeSyntax value]
    : n=nullable ar=array_ranks {
        var result = new ArrayTypeSyntax
        {
            ElementType = $n.value
        };

        foreach (var item in $ar.value)
        {
            result.RankSpecifiers.Add(item);
        }

        $value = result;
      }
    | n=nullable { $value = $n.value; }
    ;

array_ranks returns [List<ArrayRankSpecifierSyntax> value]
    : '[' cl=comma_list ']' ar=array_ranks {
        $value = $ar.value;
        $value.Insert(0, BuildArrayRankSpecifier($cl.value));
      }
    | '[' cl=comma_list ']' {
        $value = new List<ArrayRankSpecifierSyntax>
        {
            BuildArrayRankSpecifier($cl.value)
        };
      }
    ;

nullable returns [TypeSyntax value]
    : gn=generic_name '?' {
        $value = new NullableTypeSyntax
        {
            ElementType = $gn.value
        };
      }
    | gn=generic_name { $value = $gn.value; }
    ;

generic_name returns [TypeSyntax value]
    : n=name '<' bga=bound_generic_arguments '>' {
        var result = new GenericNameSyntax
        {
            IsUnboundGenericName = false,
            TypeArgumentList = $bga.value
        };

        $value = FixupTree($n.value, result, (r, p) => r.Identifier = p.Identifier);
      }
    | n=name '<' cl=comma_list '>' {
        var result = new GenericNameSyntax
        {
            IsUnboundGenericName = true,
            TypeArgumentList = new TypeArgumentListSyntax()
        };

        for (int i = 0; i < $cl.value; i++)
        {
            result.TypeArgumentList.Arguments.Add(new OmittedTypeArgumentSyntax());
        }

        $value = FixupTree($n.value, result, (r, p) => r.Identifier = p.Identifier);
      }
    | n=name { $value = $n.value; }
    ;

bound_generic_arguments returns [TypeArgumentListSyntax value]
    : an=any_name ',' bga=bound_generic_arguments {
        $bga.value.Arguments.Insert(0, $an.value);
        $value = $bga.value;
      }
    | an=any_name {
        $value = new TypeArgumentListSyntax
        {
            Arguments =
            {
                $an.value
            }
        };
      }
    ;

comma_list returns [int value]
    : { $value = 1; }
    | ',' cl=comma_list { $value = $cl.value + 1; }
    ;

name returns [TypeSyntax value]
    : p=predefined { $value = $p.value; }
    | aq=alias_qualified { $value = $aq.value; }
    ;

alias_qualified returns [NameSyntax value]
    : i=identifier '::' q=qualified { $value = BuildAliasQualifiedName($i.value, $q.value); }
    | q=qualified { $value = $q.value; }
    ;

qualified returns [NameSyntax value]
    : i=identifier { $value = $i.value; }
    | i=identifier '.' q=qualified { $value = BuildQualifiedName($i.value, $q.value); }
    ;

predefined returns [PredefinedTypeSyntax value]
    : pt=predefined_type {
        $value = new PredefinedTypeSyntax
        {
            Type = $pt.value
        };
      }
    ;

predefined_type returns [PredefinedType value]
    : 'byte' { $value = PredefinedType.Byte; }
    | 'sbyte' { $value = PredefinedType.SByte; }
    | 'short' { $value = PredefinedType.Short; }
    | 'ushort' { $value = PredefinedType.UShort; }
    | 'int' { $value = PredefinedType.Int; }
    | 'uint' { $value = PredefinedType.UInt; }
    | 'long' { $value = PredefinedType.Long; }
    | 'ulong' { $value = PredefinedType.ULong; }
    | 'bool' { $value = PredefinedType.Bool; }
    | 'double' { $value = PredefinedType.Double; }
    | 'float' { $value = PredefinedType.Float; }
    | 'decimal' { $value = PredefinedType.Decimal; }
    | 'string' { $value = PredefinedType.String; }
    | 'char' { $value = PredefinedType.Char; }
    | 'void' { $value = PredefinedType.Void; }
    | 'object' { $value = PredefinedType.Object; }
    ;

identifier returns [IdentifierNameSyntax value]
    : IDENTIFIER {
        $value = new IdentifierNameSyntax
        {
            Identifier = $IDENTIFIER.text
        };
      }
    ;

IDENTIFIER
	: LETTER (LETTER|'0'..'9')*
	;

fragment
LETTER
	: 'A'..'Z'
	| 'a'..'z'
	| '_'
	;

WS
	: (' '|'\t'|'\r'|'\n')+
	{
		Skip();
	}
	;
