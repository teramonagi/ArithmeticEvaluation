//各種モジュールの読み込み
open AST
open Lexer
open Parser 
//文字列→抽象構文木へ
let parse txt =
  txt
  |> Lexing.LexBuffer<_>.FromString
  |> Parser.Expr Lexer.token
//評価器・数値に倒して実際の評価を実行
let rec eval = function
  | Int i        -> i
  | Plus (a,b)   -> eval a + eval b
  | Minus (a,b)  -> eval a - eval b
  | Times (a,b)  -> eval a * eval b
  | Divide (a,b) -> eval a / eval b
 
//試しの計算
do
  "(4 * (2 + 3))"
  |> parse 
  |> eval
  |> printfn "%d"