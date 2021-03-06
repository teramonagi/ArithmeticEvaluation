// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 3 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
 
//抽象構文木の型を使いたいので読んでおく
open AST 

# 11 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | PLUS
  | MINUS
  | TIMES
  | DIVIDE
  | LPAREN
  | RPAREN
  | INT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIVIDE
    | TOKEN_LPAREN
    | TOKEN_RPAREN
    | TOKEN_INT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startExpr
    | NONTERM_Expr

// This function maps tokens to integers indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | PLUS  -> 1 
  | MINUS  -> 2 
  | TIMES  -> 3 
  | DIVIDE  -> 4 
  | LPAREN  -> 5 
  | RPAREN  -> 6 
  | INT _ -> 7 

// This function maps integers indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_PLUS 
  | 2 -> TOKEN_MINUS 
  | 3 -> TOKEN_TIMES 
  | 4 -> TOKEN_DIVIDE 
  | 5 -> TOKEN_LPAREN 
  | 6 -> TOKEN_RPAREN 
  | 7 -> TOKEN_INT 
  | 10 -> TOKEN_end_of_input
  | 8 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startExpr 
    | 1 -> NONTERM_Expr 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 10 
let _fsyacc_tagOfErrorTerminal = 8

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIVIDE  -> "DIVIDE" 
  | LPAREN  -> "LPAREN" 
  | RPAREN  -> "RPAREN" 
  | INT _ -> "INT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIVIDE  -> (null : System.Object) 
  | LPAREN  -> (null : System.Object) 
  | RPAREN  -> (null : System.Object) 
  | INT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 6us; 65535us; 0us; 1us; 8us; 3us; 9us; 4us; 10us; 5us; 11us; 6us; 12us; 7us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 5us; 0us; 2us; 3us; 4us; 5us; 1us; 1us; 5us; 2us; 2us; 3us; 4us; 5us; 5us; 2us; 3us; 3us; 4us; 5us; 5us; 2us; 3us; 4us; 4us; 5us; 5us; 2us; 3us; 4us; 5us; 5us; 5us; 2us; 3us; 4us; 5us; 6us; 1us; 2us; 1us; 3us; 1us; 4us; 1us; 5us; 1us; 6us; 1us; 6us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 8us; 10us; 16us; 22us; 28us; 34us; 40us; 42us; 44us; 46us; 48us; 50us; |]
let _fsyacc_action_rows = 14
let _fsyacc_actionTableElements = [|2us; 32768us; 5us; 12us; 7us; 2us; 4us; 49152us; 1us; 8us; 2us; 9us; 3us; 10us; 4us; 11us; 0us; 16385us; 2us; 16386us; 3us; 10us; 4us; 11us; 2us; 16387us; 3us; 10us; 4us; 11us; 0us; 16388us; 0us; 16389us; 5us; 32768us; 1us; 8us; 2us; 9us; 3us; 10us; 4us; 11us; 6us; 13us; 2us; 32768us; 5us; 12us; 7us; 2us; 2us; 32768us; 5us; 12us; 7us; 2us; 2us; 32768us; 5us; 12us; 7us; 2us; 2us; 32768us; 5us; 12us; 7us; 2us; 2us; 32768us; 5us; 12us; 7us; 2us; 0us; 16390us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 3us; 8us; 9us; 12us; 15us; 16us; 17us; 23us; 26us; 29us; 32us; 35us; 38us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 1us; 3us; 3us; 3us; 3us; 3us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 1us; 1us; 1us; 1us; 1us; |]
let _fsyacc_immediateActions = [|65535us; 65535us; 16385us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16390us; |]
let _fsyacc_reductions ()  =    [| 
# 115 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Expression)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startExpr));
# 124 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 21 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                                                     Int _1 
                   )
# 21 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                 : Expression));
# 135 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Expression)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Expression)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 22 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                                                     Plus (_1, _3) 
                   )
# 22 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                 : Expression));
# 147 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Expression)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Expression)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 23 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                                                     Minus (_1, _3) 
                   )
# 23 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                 : Expression));
# 159 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Expression)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Expression)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 24 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                                                     Times (_1, _3) 
                   )
# 24 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                 : Expression));
# 171 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Expression)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Expression)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 25 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                                                     Divide (_1, _3) 
                   )
# 25 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                 : Expression));
# 183 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Expression)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 26 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                                                     _2 
                   )
# 26 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\\Parser.fsy"
                 : Expression));
|]
# 195 "C:\Users\yana\Dropbox\code\FSharp\ArithmeticEvaluation\ArithmeticEvaluation\Parser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 11;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Expr lexer lexbuf : Expression =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
