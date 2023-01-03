module Main.Types

open Types
open Dungeon.Types
open Shop.Types

type State = { 
    Count : int
    CurrentPage : Page
    Dungeon : DungeonInfo
    ShopItems : ShopItem list
    GameState : Game.Types.GameState
    CharacterState : Character.Types.CharacterState}