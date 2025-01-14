grammar UralLexer;

//Parser
program
    : codelines* EOF
    ;


codelines
    : statement | codeblock
    ;
    

statement
    : (assigment
    | funccall) ';'
    ;


codeblock
    : ifblock
    | whileblock
    | repeatblock
    ;

codechunk
    : '{' codelines+ '}'
    ;

funccall
    : Id '(' (expression (',' expression)*)? ')'
    ;

ifblock
    : If expression '{' codechunk '}' (Iff iffblock '}') (Finally codechunk)
    ;
    
iffblock
    : codechunk | ifblock
    ;

whileblock
    : While expression ':' codechunk (Iff iffblock) (Finally codechunk)
    ;

repeatblock
    : RepeatWhile Natural ':' codechunk
    ;

expression
    : constant                                      #expression_constant___
    | Id                                            #expression_id___
    | funccall                                      #expression_funccall___
    | '(' expression ')'                            #expression_brackets_expression___
    | RCIUniOperator expression                     #expression_unitary_operator___
    | expression RCIBinOperator expression          #expression_binary_operator___
    | expression powOperator expression             #expression_pow_operator___
    | expression multOperator expression            #expression_mult_operator___
    | expression addOperator expression             #expression_add_operator___
    | expression compareOperator expression         #expression_compare_operator___
    ;

powOperator
    : '^'
    ;
    
multOperator
    : '*' | '/' '%'
    ;

addOperator
    : '==' | '===' | '!=' | '!==' | '>' | '<' | '>=' | '<='
    ;



assigment
    : Id '=' expression
    ;

constant
    : numeric
    | string
    | RCI
    | VOID
    ;
    
numeric
    : natural
    | whole
    | rational
    ;
    
natural
    : NATCH32
    | NATCH16
    | NATCH64
    ;
    
whole
    : CELCH32
    | CELCH16
    | CELCH64
    ;
    
rational
    : DROBCH32
    | DROBCH16
    | DROBCH64
    ;
    
    
NATCH32
    : ([0-9]?|[1-9][0-9]*)'н'?
    ;

NATCH16
    : ([0-9]?|[1-9][0-9]*)'нн'?
    ;

If
    : 'Если' | 'if'
    ;

Iff
    : 'Иначе' | 'else'
    ;

While
    : 'Пока' | 'until'
    ;

RepeatWhile
    : 'Повтор' | 'repeat'
    ;
    
Finally
    : 'Также' | 'finally'
    ;    

RCIUniOperator
    : 'НТОЛ' | 'НВОП' | 'ВОП' | 'ТОЛ' | 'НЕ'
    ;

RCIBinOperator
    : 'НОР' | 'НАР' | 'АР' | 'КСОР' | 'НИ' | 'И' | 'ЭКВ' | 'ИМП' | 'ТОГД' | 'ИЛИ' 
    ;

RCIOperator
    : RCIUniOperator
    | RCIBinOperator
    ;

RCI
    : 'ИСТИНА' | 'ЛОЖЬ'
    ;

VOID
    : 'ВОИД'
    ;

Id
    : ([a-zA-Z][a-zA-Z0-9]*|[а-яА-Я][а-яА-Я0-9]*)
    ;

SkipBlanck
    : [\t\r\n] -> skip
    ;
        
EndLine
    : ';'
    ;