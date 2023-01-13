module Messages

open Types
open Character.Types
open Dungeon.Types
open Game.Types
open Shop.Types

type CharacterMessage = 
    | ClearCharacter
    | LoadCharacter of (string * DataResult<Character>)
    | LoadCharacters of (string * DataResult<Character list>)
    | SubmitCharacter
    | SubmitCharacterResponse of (int * DataResult<string>)
    | UpdateCharacter of Character
    | FailedToLoadCharacter of exn

type GameMessage = 
    | LoadGame of (int * DataResult<Game>)
    | LoadGames of DataResult<Game list>
    | FailedToLoadGame of exn

type DungeonMessage = 
    | LoadDungeon of (int * DataResult<DungeonInfo>)
    | FailedToLoadDungeon of exn

type ShopMessage = 
    | LoadShop of DataResult<ShopItem list>
    | FailedToLoadShop of exn

type MainMessage = 
    | ChangePage of Page
    | LoadPage of (Page * MainMessage)
    | CharacterMsg of CharacterMessage
    | DungeonMsg of DungeonMessage
    | GameMsg of GameMessage
    | ShopMsg of ShopMessage
    | FailedToLoad of exn