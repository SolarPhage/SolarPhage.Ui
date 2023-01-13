module Main.Types

open Types
open Character.Types
open Game.Types
open Dungeon.Types
open Shop.Types

type State = { 
    Count : int
    CurrentPage : Page
    DungeonState : DungeonState
    ShopState : ShopState
    GameState : GameState
    CharacterState : CharacterState}